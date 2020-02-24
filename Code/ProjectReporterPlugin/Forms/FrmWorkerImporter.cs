using ProjectReporterPlugin.DB;
using ProjectReporterPlugin.DB.Entitys;
using ProjectReporterPlugin.Editor;
using PublicReporterLib.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectReporterPlugin.Forms
{
    public partial class FrmWorkerImporter : PublicReporterLib.SuperForm
    {
        private List<PersonImportRecord> newPersonList = new List<PersonImportRecord>();

        public FrmWorkerImporter()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PersonImportRecord[] personList = getSelectedPersonList();
            if (personList.Length == 0)
            {
                MessageBox.Show("对不起，请选择要导入的人员！");
                return;
            }

            foreach (PersonImportRecord newObj in personList)
            {
                try
                {
                    //生成对象
                    PersonObject po = new PersonObject(null, null, null, null);

                    string subjectID = string.Empty;
                    if (string.IsNullOrEmpty(newObj.subjectStr))
                    {
                        //项目ID
                        subjectID = PluginRootObj.projectObj.ID;
                    }
                    else
                    {
                        //课题ID
                        subjectID = ConnectionManager.Context.table("Project").where("Name='" + newObj.subjectStr + "'").select("ID").getValue<string>(string.Empty);
                    }

                    //查询当前记录
                    po.SubjectObj = ConnectionManager.Context.table("Project").where("ID='" + subjectID + "'").select("*").getItem<Project>(new Project());
                    po.UnitObj = ConnectionManager.Context.table("Unit").where("UnitName='" + newObj.unitName + "'").select("*").getItem<Unit>(new Unit());
                    po.PersonObj = ConnectionManager.Context.table("Person").where("IDCard='" + newObj.personIDCard + "'").select("*").getItem<Person>(new Person());
                    po.TaskObj = ConnectionManager.Context.table("Task").where("IDCard='" + newObj.personIDCard + "' and ProjectID in (select ID from Project where Name = '" + (string.IsNullOrEmpty(newObj.subjectStr) ? PluginRootObj.projectObj.Name : newObj.subjectStr) + "')").select("*").getItem<Task>(new Task());

                    //更新数据
                    insertOrUpdatePerson(po, newObj.unitName, newObj.unitAddress, newObj.unitContact, newObj.unitTelephone, newObj.personName, newObj.personIDCard, newObj.personJob, newObj.personSpecialty, newObj.personSex, DateTime.Parse(newObj.personBirthday), newObj.personTelephone, newObj.personMobilePhone, newObj.personAddress, int.Parse(newObj.timeInProject), newObj.taskInProject, newObj.roleNameStr, subjectID, newObj.roletypeOnlyProjectStr == "是", newObj.roletypeProjectAndSubjectStr == "是", newObj.roletypeOnlySubjectStr == "是");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("对不起，人员(" + newObj.personName + ")的信息导入失败！");
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private PersonImportRecord[] getSelectedPersonList()
        {
            List<PersonImportRecord> results = new List<PersonImportRecord>();
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                DataGridViewCheckBoxCell checkboxCell = ((DataGridViewCheckBoxCell)dgvRow.Cells[0]);
                if (checkboxCell.Value == "true")
                {
                    results.Add((PersonImportRecord)dgvRow.Tag);
                }
            }
            return results.ToArray();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (ofdExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFile.Text = ofdExcelDialog.FileName;
                loadExcel(txtFile.Text);
            }
        }

        private void loadExcel(string xlsFile)
        {
            try
            {
                newPersonList = new List<PersonImportRecord>();

                DataTable dtData = ExcelBuilder.excelToDataTable(xlsFile, "Person", true);
                foreach (DataRow dr in dtData.Rows)
                {
                    PersonImportRecord pir = new PersonImportRecord();

                    pir.unitName = dr["单位名称"] != null ? dr["单位名称"].ToString() : string.Empty;
                    //string unitType = dr["隶属部门"] != null ? dr["隶属部门"].ToString() : string.Empty;
                    pir.unitType = "其它";
                    pir.unitAddress = dr["单位通信地址"] != null ? dr["单位通信地址"].ToString() : string.Empty;
                    pir.unitContact = dr["单位联系人"] != null ? dr["单位联系人"].ToString() : string.Empty;
                    pir.unitTelephone = dr["单位联系电话"] != null ? dr["单位联系电话"].ToString() : string.Empty;
                    pir.personName = dr["姓名"] != null ? dr["姓名"].ToString() : string.Empty;
                    pir.personIDCard = dr["身份证"] != null ? dr["身份证"].ToString() : string.Empty;
                    pir.personJob = dr["职务职称"] != null ? dr["职务职称"].ToString() : string.Empty;
                    pir.personSpecialty = dr["从事专业"] != null ? dr["从事专业"].ToString() : string.Empty;
                    pir.personSex = dr["性别"] != null ? dr["性别"].ToString() : string.Empty;
                    pir.personBirthday = dr["出生年月"] != null ? dr["出生年月"].ToString() : string.Empty;
                    pir.personTelephone = dr["座机"] != null ? dr["座机"].ToString() : string.Empty;
                    pir.personMobilePhone = dr["手机"] != null ? dr["手机"].ToString() : string.Empty;
                    pir.personAddress = dr["通信地址"] != null ? dr["通信地址"].ToString() : string.Empty;
                    pir.taskInProject = dr["任务分工"] != null ? dr["任务分工"].ToString() : string.Empty;
                    pir.timeInProject = dr["每年为本项目工作时间(月)"] != null ? dr["每年为本项目工作时间(月)"].ToString() : string.Empty;

                    pir.subjectStr = dr["课题名称(如是仅为项目负责人则为空)"] != null ? dr["课题名称(如是仅为项目负责人则为空)"].ToString().Trim() : string.Empty;
                    pir.roletypeOnlyProjectStr = dr["仅为项目负责人"] != null ? dr["仅为项目负责人"].ToString().Trim() : string.Empty;
                    pir.roletypeProjectAndSubjectStr = dr["项目负责人兼课题角色"] != null ? dr["项目负责人兼课题角色"].ToString().Trim() : string.Empty;
                    pir.roletypeOnlySubjectStr = dr["仅为课题角色"] != null ? dr["仅为课题角色"].ToString().Trim() : string.Empty;
                    pir.roleNameStr = dr["项目或课题中职务（负责人或成员）"] != null ? dr["项目或课题中职务（负责人或成员）"].ToString().Trim() : string.Empty;

                    if (string.IsNullOrEmpty(pir.roletypeOnlyProjectStr))
                    {
                        pir.roletypeOnlyProjectStr = "否";
                    }
                    if (string.IsNullOrEmpty(pir.roletypeProjectAndSubjectStr))
                    {
                        pir.roletypeProjectAndSubjectStr = "否";
                    }
                    if (string.IsNullOrEmpty(pir.roletypeOnlySubjectStr))
                    {
                        pir.roletypeOnlySubjectStr = "否";
                    }

                    //检查非空
                    foreach (DataColumn dc in dr.Table.Columns)
                    {
                        if (dc.ColumnName == "课题名称(如是仅为项目负责人则为空)" || dc.ColumnName == "仅为项目负责人" || dc.ColumnName == "项目负责人兼课题角色" || dc.ColumnName == "仅为课题角色")
                        {
                            continue;
                        }
                        else
                        {
                            if (dr[dc.ColumnName] == null || dr[dc.ColumnName].ToString() == string.Empty)
                            {
                                throw new Exception("'" + dc.ColumnName + "'不能为空！");
                            }
                        }
                    }

                    if (pir.personSex != "男" && pir.personSex != "女")
                    {
                        throw new Exception("性别只能为'男'或'女'！");
                    }

                    int intResult = 0;
                    if (int.TryParse(pir.timeInProject, out intResult) == false)
                    {
                        throw new Exception("'每年投入时间'只能是数字！");
                    }

                    if (pir.roleNameStr != "负责人" && pir.roleNameStr != "成员")
                    {
                        throw new Exception("'项目或课题中职务'只能是负责人或成员！");
                    }

                    DateTime dtResult = DateTime.MinValue;
                    if (DateTime.TryParse(pir.personBirthday, out dtResult) == false)
                    {
                        throw new Exception("'出生年月'格式有误！例如：" + DateTime.Now.ToShortDateString());
                    }

                    //判断研究内容名称是否正确
                    if (pir.roletypeOnlyProjectStr.Contains("否"))
                    {
                        int subjectCount = 0;
                        object countObj = ConnectionManager.Context.table("Project").where("Name='" + pir.subjectStr + "'").select("count(*)").getValue();
                        try
                        {
                            subjectCount = int.Parse(countObj.ToString());
                        }
                        catch (Exception ex) { }

                        if (subjectCount == 0)
                        {
                            throw new Exception("'课题名称'有误！");
                        }
                    }

                    newPersonList.Add(pir);
                }

                dgvDetail.Rows.Clear();
                foreach (PersonImportRecord pObj in newPersonList)
                {
                    List<object> cells = new List<object>();
                    cells.Add("true");
                    cells.Add(pObj.personName);
                    cells.Add(pObj.personSex);
                    cells.Add(pObj.personJob);
                    cells.Add(pObj.personSpecialty);
                    cells.Add(pObj.unitName);
                    cells.Add(pObj.timeInProject);
                    cells.Add(pObj.taskInProject);
                    cells.Add(pObj.personIDCard);

                    if (pObj.roletypeOnlyProjectStr =="是")
                    {
                        cells.Add("项目负责人");
                    }
                    else
                    {
                        cells.Add((pObj.roletypeProjectAndSubjectStr == "是" ? "项目负责人兼" : "") + pObj.subjectStr + pObj.roleNameStr);
                    }

                    int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                    dgvDetail.Rows[rowIndex].Tag = pObj;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("对不起，导入失败！错误:" + ex.ToString());
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void llTemplete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sourcePath = Path.Combine(PluginRootObj.RootDir, Path.Combine("Helper", "lianxiren.xls"));

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xls|*.xls";
            sfd.FileName = "人员导入模板.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(sourcePath, sfd.FileName, true);
                    Process.Start(sfd.FileName);

                    MessageBox.Show("下载完成！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("下载失败！Ex:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 插入人员信息
        /// </summary>
        /// <param name="newPersonInfo"></param>
        /// <param name="unitName"></param>
        /// <param name="unitAddress"></param>
        /// <param name="unitContactName"></param>
        /// <param name="unitTelephone"></param>
        /// <param name="personName"></param>
        /// <param name="personIDCard"></param>
        /// <param name="personJob"></param>
        /// <param name="personSpecialty"></param>
        /// <param name="personSex"></param>
        /// <param name="personBirthday"></param>
        /// <param name="personTelephone"></param>
        /// <param name="personMobilePhone"></param>
        /// <param name="personAddress"></param>
        /// <param name="workTimeInYear"></param>
        /// <param name="taskContent"></param>
        /// <param name="jobInProjects"></param>
        /// <param name="subjectID"></param>
        /// <param name="isOnlyProject"></param>
        /// <param name="isProjectAndSubject"></param>
        /// <param name="isOnlySubject"></param>
        private void insertOrUpdatePerson(PersonObject newPersonInfo,string unitName, string unitAddress, string unitContactName, string unitTelephone, string personName, string personIDCard, string personJob, string personSpecialty, string personSex, DateTime personBirthday, string personTelephone, string personMobilePhone, string personAddress, int workTimeInYear, string taskContent, string jobInProjects, string subjectID, bool isOnlyProject, bool isProjectAndSubject, bool isOnlySubject)
        {
            //项目负责人显示序号
            int masterDiaplayOrder = 0;
            //XXXX普通人显示序号
            int personDisplayOrder = 0;
            if (isOnlyProject)
            {
                //仅为项目负责人,需要删除当前的项目负责人,也删除此人原来的职务
                masterDiaplayOrder = ConnectionManager.Context.table("Task").where("ProjectID='" + PluginRootObj.projectObj.ID + "' and Type = '项目' and Role='负责人'").select("DisplayOrder").getValue<int>(0);
                ConnectionManager.Context.table("Task").where("ProjectID='" + PluginRootObj.projectObj.ID + "' and Type = '项目' and Role='负责人'").delete();

                ConnectionManager.Context.table("Task").where("ID='" + newPersonInfo.TaskObj.ID + "'").delete();
            }
            else if (isProjectAndSubject)
            {
                //项目兼课题角色,需要删除当前的项目负责人和课题角色
                masterDiaplayOrder = ConnectionManager.Context.table("Task").where("ProjectID='" + PluginRootObj.projectObj.ID + "' and Type = '项目' and Role='负责人'").select("DisplayOrder").getValue<int>(0);
                ConnectionManager.Context.table("Task").where("ProjectID='" + PluginRootObj.projectObj.ID + "' and Type = '项目' and Role='负责人'").delete();

                personDisplayOrder = newPersonInfo.TaskObj.DisplayOrder != null ? newPersonInfo.TaskObj.DisplayOrder.Value : 0;
                ConnectionManager.Context.table("Task").where("ID='" + newPersonInfo.TaskObj.ID + "'").delete();
            }
            else if (isOnlySubject)
            {
                //课题角色,需要删除当前的课题角色,如果此人原来是项目负责人，也删除
                personDisplayOrder = newPersonInfo.TaskObj.DisplayOrder != null ? newPersonInfo.TaskObj.DisplayOrder.Value : 0;
                ConnectionManager.Context.table("Task").where("ID='" + newPersonInfo.TaskObj.ID + "'").delete();

                ConnectionManager.Context.table("Task").where("ProjectID='" + PluginRootObj.projectObj.ID + "' and Type = '项目' and Role='负责人' and IDCard = '" + newPersonInfo.PersonObj.IDCard + "'").delete();
            }

            //工作单位ID
            string workUnitID = string.IsNullOrEmpty(newPersonInfo.UnitObj.ID) ? Guid.NewGuid().ToString() : newPersonInfo.UnitObj.ID;
            //创建工作单位
            ProjectEditor.BuildUnitRecord(workUnitID, unitName, unitName, unitName, unitContactName, unitTelephone, "课题单位", unitAddress);

            //输入人员信息
            newPersonInfo.PersonObj = new Person();
            newPersonInfo.PersonObj.UnitID = workUnitID;
            newPersonInfo.PersonObj.ID = Guid.NewGuid().ToString();
            newPersonInfo.PersonObj.Name = personName;
            newPersonInfo.PersonObj.Sex = personSex;
            newPersonInfo.PersonObj.Birthday = personBirthday != null ? personBirthday : DateTime.Now;
            newPersonInfo.PersonObj.IDCard = personIDCard;
            newPersonInfo.PersonObj.Job = personJob;
            newPersonInfo.PersonObj.Specialty = personSpecialty;
            newPersonInfo.PersonObj.Address = personAddress;
            newPersonInfo.PersonObj.Telephone = personTelephone;
            newPersonInfo.PersonObj.MobilePhone = personMobilePhone;

            //输入项目信息
            newPersonInfo.TaskObj = new Task();
            newPersonInfo.TaskObj.PersonID = newPersonInfo.PersonObj.ID;
            newPersonInfo.TaskObj.IDCard = newPersonInfo.PersonObj.IDCard;
            newPersonInfo.TaskObj.Content = taskContent;
            newPersonInfo.TaskObj.TotalTime = workTimeInYear;
            newPersonInfo.TaskObj.Role = jobInProjects;

            //清理人员信息引用
            clearAndUpdatePersonRef(newPersonInfo.PersonObj.IDCard, newPersonInfo.PersonObj.ID);

            //检查当前人员是什么角色
            if (isOnlyProject)
            {
                //仅为项目负责人
                newPersonInfo.TaskObj.ProjectID = PluginRootObj.projectObj.ID;
                newPersonInfo.TaskObj.ID = Guid.NewGuid().ToString();
                newPersonInfo.TaskObj.Type = "项目";
                newPersonInfo.TaskObj.Role = "负责人";
                newPersonInfo.TaskObj.DisplayOrder = masterDiaplayOrder;
                newPersonInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();
            }
            else if (isProjectAndSubject)
            {
                //项目兼课题角色
                newPersonInfo.TaskObj.ProjectID = PluginRootObj.projectObj.ID;
                newPersonInfo.TaskObj.ID = Guid.NewGuid().ToString();
                newPersonInfo.TaskObj.Type = "项目";
                newPersonInfo.TaskObj.Role = "负责人";
                newPersonInfo.TaskObj.DisplayOrder = masterDiaplayOrder;
                newPersonInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();

                newPersonInfo.TaskObj.ProjectID = subjectID;
                newPersonInfo.TaskObj.ID = Guid.NewGuid().ToString();
                newPersonInfo.TaskObj.Type = "课题";
                newPersonInfo.TaskObj.Role = jobInProjects;
                newPersonInfo.TaskObj.DisplayOrder = personDisplayOrder;
                newPersonInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();
            }
            else if (isOnlySubject)
            {
                //课题角色
                newPersonInfo.TaskObj.ProjectID = subjectID;
                newPersonInfo.TaskObj.ID = Guid.NewGuid().ToString();
                newPersonInfo.TaskObj.Type = "课题";
                newPersonInfo.TaskObj.Role = jobInProjects;
                newPersonInfo.TaskObj.DisplayOrder = personDisplayOrder;
                newPersonInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();
            }

            //添加人员信息
            newPersonInfo.PersonObj.copyTo(ConnectionManager.Context.table("Person")).insert();
        }

        /// <summary>
        /// 以身份证号为基础清理并更新人员信息的引用
        /// </summary>
        /// <param name="personIDCard"></param>
        /// <param name="personId"></param>
        private void clearAndUpdatePersonRef(string personIDCard, string personId)
        {
            //创建人员
            ConnectionManager.Context.table("Person").where("IDCard = '" + personIDCard + "'").delete();
            //更新人员ID
            ConnectionManager.Context.table("Task").where("IDCard = '" + personIDCard + "'").set("PersonID", personId).update();
        }
    }

    public class PersonImportRecord
    {
        public string unitName;
        public string unitType;
        public string unitAddress;
        public string unitContact;
        public string unitTelephone;
        public string personName;
        public string personIDCard;
        public string personJob;
        public string personSpecialty;
        public string personSex;
        public string personBirthday;
        public string personTelephone;
        public string personMobilePhone;
        public string personAddress;
        public string taskInProject;
        public string timeInProject;
        public string subjectStr;
        public string roletypeOnlyProjectStr;
        public string roletypeProjectAndSubjectStr;
        public string roletypeOnlySubjectStr;
        public string roleNameStr;
    }
}