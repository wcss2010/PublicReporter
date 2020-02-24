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
        private List<Person> newPersonList = new List<Person>();

        public FrmWorkerImporter()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Person[] personList = getSelectedPersonList();
            if (personList.Length == 0)
            {
                MessageBox.Show("对不起，请选择要导入的人员！");
                return;
            }

            foreach (Person newObj in personList)
            {
                Person oldObj = ConnectionManager.Context.table("Person").where("IDCard='" + newObj.IDCard + "'").select("*").getItem<Person>(new Person());
                if (string.IsNullOrEmpty(oldObj.ID))
                {
                    //insert
                    newObj.ID = Guid.NewGuid().ToString();
                    newObj.copyTo(ConnectionManager.Context.table("Person")).insert();
                }
                else
                {
                    //update
                    newObj.ID = oldObj.ID;
                    newObj.copyTo(ConnectionManager.Context.table("Person")).where("ID='" + newObj.ID + "'").update();
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private Person[] getSelectedPersonList()
        {
            List<Person> results = new List<Person>();
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                DataGridViewCheckBoxCell checkboxCell = ((DataGridViewCheckBoxCell)dgvRow.Cells[0]);
                if (checkboxCell.Value == "true")
                {
                    results.Add((Person)dgvRow.Tag);
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
                newPersonList = new List<Person>();

                //初始的课题ID
                string defaultSubjectID = ConnectionManager.Context.table("Project").select("ID").getValue<string>("");

                DataTable dtData = ExcelBuilder.excelToDataTable(xlsFile, "Person", true);
                foreach (DataRow dr in dtData.Rows)
                {
                    string idCardStr = dr["身份证"] != null ? dr["身份证"].ToString().Trim() : string.Empty;
                    string nameStr = dr["姓名"] != null ? dr["姓名"].ToString().Trim() : string.Empty;
                    string sexStr = dr["性别"] != null ? dr["性别"].ToString().Trim() : string.Empty;
                    string birthdayStr = dr["出生年月"] != null ? dr["出生年月"].ToString().Trim() : string.Empty;
                    string jobStr = dr["职务/职称"] != null ? dr["职务/职称"].ToString().Trim() : string.Empty;
                    string specStr = dr["所学专业"] != null ? dr["所学专业"].ToString().Trim() : string.Empty;
                    string telephoneStr = dr["电话"] != null ? dr["电话"].ToString().Trim() : string.Empty;
                    string mobilephoneStr = dr["手机"] != null ? dr["手机"].ToString().Trim() : string.Empty;
                    string workunitStr = dr["工作单位"] != null ? dr["工作单位"].ToString().Trim() : string.Empty;
                    string timeforProjecttr = dr["每年投入时间"] != null ? dr["每年投入时间"].ToString().Trim() : string.Empty;
                    string taskcontentStr = dr["任务分工"] != null ? dr["任务分工"].ToString().Trim() : string.Empty;
                    string Projecttr = dr["研究内容名称(如是仅为项目负责人则为空)"] != null ? dr["研究内容名称(如是仅为项目负责人则为空)"].ToString().Trim() : string.Empty;
                    string roletypeOnlyProjectStr = dr["仅为项目负责人"] != null ? dr["仅为项目负责人"].ToString().Trim() : string.Empty;
                    string roletypeProjectAndProjecttr = dr["项目负责人兼研究内容角色"] != null ? dr["项目负责人兼研究内容角色"].ToString().Trim() : string.Empty;
                    string roletypeOnlyProjecttr = dr["仅为研究内容角色"] != null ? dr["仅为研究内容角色"].ToString().Trim() : string.Empty;
                    string roleNameStr = dr["研究内容中职务（负责人或成员）"] != null ? dr["研究内容中职务（负责人或成员）"].ToString().Trim() : string.Empty;

                    if (string.IsNullOrEmpty(roletypeOnlyProjectStr))
                    {
                        roletypeOnlyProjectStr = "否";
                    }
                    if (string.IsNullOrEmpty(roletypeProjectAndProjecttr))
                    {
                        roletypeProjectAndProjecttr = "否";
                    }
                    if (string.IsNullOrEmpty(roletypeOnlyProjecttr))
                    {
                        roletypeOnlyProjecttr = "否";
                    }

                    //检查非空
                    foreach (DataColumn dc in dr.Table.Columns)
                    {
                        if (dc.ColumnName == "研究内容名称(如是仅为项目负责人则为空)" || dc.ColumnName == "仅为项目负责人" || dc.ColumnName == "项目负责人兼研究内容角色" || dc.ColumnName == "仅为研究内容角色")
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

                    if (sexStr != "男" && sexStr != "女")
                    {
                        throw new Exception("性别只能为'男'或'女'！");
                    }

                    int intResult = 0;
                    if (int.TryParse(timeforProjecttr, out intResult) == false)
                    {
                        throw new Exception("'每年投入时间'只能是数字！");
                    }

                    if (roleNameStr != "负责人" && roleNameStr != "成员")
                    {
                        throw new Exception("'研究内容中职务'只能是负责人或成员！");
                    }

                    DateTime dtResult = DateTime.MinValue;
                    if (DateTime.TryParse(birthdayStr, out dtResult) == false)
                    {
                        throw new Exception("'出生年月'格式有误！例如：" + DateTime.Now.ToShortDateString());
                    }

                    //判断研究内容名称是否正确
                    if (roletypeOnlyProjectStr.Contains("否"))
                    {
                        int subjectCount = 0;
                        object countObj = ConnectionManager.Context.table("Project").where("SubjectName='" + Projecttr + "'").select("count(*)").getValue();
                        try
                        {
                            subjectCount = int.Parse(countObj.ToString());
                        }
                        catch (Exception ex) { }

                        if (subjectCount == 0)
                        {
                            throw new Exception("'研究内容名称'有误！");
                        }
                    }

                    #region 生成Person对象
                    Person ppObj = new Person();
                    ppObj.IDCard = idCardStr;
                    ppObj.Name = nameStr;
                    ppObj.Sex = sexStr;
                    ppObj.Birthday = DateTime.Parse(birthdayStr);
                    ppObj.Job = jobStr;
                    ppObj.Specialty = specStr;
                    ppObj.Telephone = telephoneStr;
                    ppObj.MobilePhone = mobilephoneStr;
                    //ppObj.UnitName = workunitStr;
                    //ppObj.TimeForSubject = int.Parse(timeforProjecttr);
                    //ppObj.TaskContent = taskcontentStr;

                    //课题ID
                    //ppObj.SubjectID = ConnectionManager.Context.table("Project").where("SubjectName='" + Projecttr + "'").select("ID").getValue<string>(defaultSubjectID);

                    //角色类型
                    //if (roletypeOnlyProjectStr.Contains("是"))
                    //{
                    //    ppObj.RoleType = FrmAddOrUpdateWorker.isOnlyProject;
                    //    roleNameStr = "成员";
                    //}
                    //else if (roletypeProjectAndProjecttr.Contains("是"))
                    //{
                    //    ppObj.RoleType = FrmAddOrUpdateWorker.isProjectAndSubject;
                    //}
                    //else
                    //{
                    //    ppObj.RoleType = FrmAddOrUpdateWorker.isOnlySubject;
                    //}

                    ////角色名称
                    //ppObj.RoleName = roleNameStr;
                    #endregion

                    newPersonList.Add(ppObj);
                }

                //查询研究内容列表
                List<Project> subjectList = ConnectionManager.Context.table("Project").select("*").getList<Project>(new Project());
                //生成研究内容X字典
                int kindex = 0;
                Dictionary<string, string> ktDict = new Dictionary<string, string>();
                foreach (Project ktb in subjectList)
                {
                    kindex++;
                    ktDict[ktb.ID] = "研究内容" + kindex;
                }
                dgvDetail.Rows.Clear();
                foreach (Person pObj in newPersonList)
                {
                    List<object> cells = new List<object>();
                    cells.Add("true");
                    cells.Add(pObj.Name);
                    cells.Add(pObj.Sex);
                    cells.Add(pObj.Job);
                    cells.Add(pObj.Specialty);
                    //cells.Add(pObj.UnitName);
                    //cells.Add(pObj.TimeForSubject);
                    //cells.Add(pObj.TaskContent);
                    //cells.Add(pObj.IDCard);

                    //if (pObj.RoleType == FrmAddOrUpdateWorker.isOnlyProject)
                    //{
                    //    cells.Add("项目负责人");
                    //}
                    //else
                    //{
                    //    cells.Add((pObj.RoleType == FrmAddOrUpdateWorker.isProjectAndSubject ? "项目负责人兼" : "") + ((ktDict.ContainsKey(pObj.SubjectID) ? ktDict[pObj.SubjectID] : string.Empty) + pObj.RoleName));
                    //}

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
            if (dgvDetail.Rows.Count > e.RowIndex && e.RowIndex >= 0)
            {
                if (dgvDetail.Rows[e.RowIndex].Cells[0].Value == "true")
                {
                    dgvDetail.Rows[e.RowIndex].Cells[0].Value = "false";
                }
                else
                {
                    dgvDetail.Rows[e.RowIndex].Cells[0].Value = "true";
                }
                dgvDetail.EndEdit();
            }
        }

        private void dgvDetail_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvDetail.ClearSelection();
                string firstValue = string.Empty;
                foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
                {
                    if (string.IsNullOrEmpty(firstValue))
                    {
                        if (dgvRow.Cells[0].Value == "true")
                        {
                            firstValue = "false";
                        }
                        else
                        {
                            firstValue = "true";
                        }
                    }
                    ((DataGridViewCheckBoxCell)dgvRow.Cells[0]).Value = firstValue;
                }
                dgvDetail.EndEdit();
            }
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
        /// <param name="personInfo"></param>
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
        private void insertOrUpdatePerson(PersonObject personInfo,string unitName, string unitAddress, string unitContactName, string unitTelephone, string personName, string personIDCard, string personJob, string personSpecialty, string personSex, DateTime personBirthday, string personTelephone, string personMobilePhone, string personAddress, int workTimeInYear, string taskContent, string jobInProjects, string subjectID, bool isOnlyProject, bool isProjectAndSubject, bool isOnlySubject)
        {
            //项目负责人显示序号
            int masterDiaplayOrder = 0;
            //XXXX普通人显示序号
            int personDisplayOrder = 0;
            //检查当前人员是什么角色
            if (isOnlyProject)
            {
                //仅为项目负责人,需要先删除当前的项目负责人
                masterDiaplayOrder = ConnectionManager.Context.table("Task").where("ProjectID='" + PluginRootObj.projectObj.ID + "' and Type = '项目' and Role='负责人'").select("DisplayOrder").getValue<int>(0);
                ConnectionManager.Context.table("Task").where("ProjectID='" + PluginRootObj.projectObj.ID + "' and Type = '项目' and Role='负责人'").delete();
            }
            else if (isProjectAndSubject)
            {
                //项目兼课题角色,需要先删除当前的项目负责人和课题角色
                masterDiaplayOrder = ConnectionManager.Context.table("Task").where("ProjectID='" + PluginRootObj.projectObj.ID + "' and Type = '项目' and Role='负责人'").select("DisplayOrder").getValue<int>(0);
                ConnectionManager.Context.table("Task").where("ProjectID='" + PluginRootObj.projectObj.ID + "' and Type = '项目' and Role='负责人'").delete();

                personDisplayOrder = personInfo.TaskObj.DisplayOrder != null ? personInfo.TaskObj.DisplayOrder.Value : 0;
                ConnectionManager.Context.table("Task").where("ID='" + personInfo.TaskObj.ID + "'").delete();
            }
            else if (isOnlySubject)
            {
                //课题角色,需要先删除当前的课题角色
                personDisplayOrder = personInfo.TaskObj.DisplayOrder != null ? personInfo.TaskObj.DisplayOrder.Value : 0;
                ConnectionManager.Context.table("Task").where("ID='" + personInfo.TaskObj.ID + "'").delete();
            }

            //工作单位ID
            string workUnitID = string.IsNullOrEmpty(personInfo.UnitObj.ID) ? Guid.NewGuid().ToString() : personInfo.UnitObj.ID;
            //创建工作单位
            ProjectEditor.BuildUnitRecord(workUnitID, unitName, unitName, unitName, unitContactName, unitTelephone, "课题单位", unitAddress);

            //输入人员信息
            personInfo.PersonObj = new Person();
            personInfo.PersonObj.UnitID = workUnitID;
            personInfo.PersonObj.ID = Guid.NewGuid().ToString();
            personInfo.PersonObj.Name = personName;
            personInfo.PersonObj.Sex = personSex;
            personInfo.PersonObj.Birthday = personBirthday != null ? personBirthday : DateTime.Now;
            personInfo.PersonObj.IDCard = personIDCard;
            personInfo.PersonObj.Job = personJob;
            personInfo.PersonObj.Specialty = personSpecialty;
            personInfo.PersonObj.Address = personAddress;
            personInfo.PersonObj.Telephone = personTelephone;
            personInfo.PersonObj.MobilePhone = personMobilePhone;

            //输入项目信息
            personInfo.TaskObj = new Task();
            personInfo.TaskObj.PersonID = personInfo.PersonObj.ID;
            personInfo.TaskObj.IDCard = personInfo.PersonObj.IDCard;
            personInfo.TaskObj.Content = taskContent;
            personInfo.TaskObj.TotalTime = workTimeInYear;
            personInfo.TaskObj.Role = jobInProjects;

            //清理人员信息引用
            clearAndUpdatePersonRef(personInfo.PersonObj.IDCard, personInfo.PersonObj.ID);

            //检查当前人员是什么角色
            if (isOnlyProject)
            {
                //仅为项目负责人
                personInfo.TaskObj.ProjectID = PluginRootObj.projectObj.ID;
                personInfo.TaskObj.ID = Guid.NewGuid().ToString();
                personInfo.TaskObj.Type = "项目";
                personInfo.TaskObj.Role = "负责人";
                personInfo.TaskObj.DisplayOrder = masterDiaplayOrder;
                personInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();
            }
            else if (isProjectAndSubject)
            {
                //项目兼课题角色
                personInfo.TaskObj.ProjectID = PluginRootObj.projectObj.ID;
                personInfo.TaskObj.ID = Guid.NewGuid().ToString();
                personInfo.TaskObj.Type = "项目";
                personInfo.TaskObj.Role = "负责人";
                personInfo.TaskObj.DisplayOrder = masterDiaplayOrder;
                personInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();

                personInfo.TaskObj.ProjectID = subjectID;
                personInfo.TaskObj.ID = Guid.NewGuid().ToString();
                personInfo.TaskObj.Type = "课题";
                personInfo.TaskObj.Role = jobInProjects;
                personInfo.TaskObj.DisplayOrder = personDisplayOrder;
                personInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();
            }
            else if (isOnlySubject)
            {
                //课题角色
                personInfo.TaskObj.ProjectID = subjectID;
                personInfo.TaskObj.ID = Guid.NewGuid().ToString();
                personInfo.TaskObj.Type = "课题";
                personInfo.TaskObj.Role = jobInProjects;
                personInfo.TaskObj.DisplayOrder = personDisplayOrder;
                personInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();
            }

            //添加人员信息
            personInfo.PersonObj.copyTo(ConnectionManager.Context.table("Person")).insert();
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
}