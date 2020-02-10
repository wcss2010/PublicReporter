using ProjectStrategicLeadershipPlugin.DB;
using ProjectStrategicLeadershipPlugin.DB.Entitys;
using PublicReporterLib.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectStrategicLeadershipPlugin.Forms
{
    public partial class FrmPersonImporter : Form
    {
        private List<Persons> newPersonList = new List<Persons>();

        public FrmPersonImporter()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Persons[] personList = getSelectedPersonList();
            if (personList.Length == 0)
            {
                MessageBox.Show("对不起，请选择要导入的人员！");
                return;
            }

            foreach (Persons newObj in personList)
            {
                Persons oldObj = ConnectionManager.Context.table("Persons").where("IDCard='" + newObj.IDCard + "'").select("*").getItem<Persons>(new Persons());
                if (string.IsNullOrEmpty(oldObj.ID))
                {
                    //insert
                    newObj.ID = Guid.NewGuid().ToString();
                    newObj.copyTo(ConnectionManager.Context.table("Persons")).insert();
                }
                else
                {
                    //update
                    newObj.ID = oldObj.ID;
                    newObj.copyTo(ConnectionManager.Context.table("Persons")).where("ID='" + newObj.ID + "'").update();
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private Persons[] getSelectedPersonList()
        {
            List<Persons> results = new List<Persons>();
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                DataGridViewCheckBoxCell checkboxCell = ((DataGridViewCheckBoxCell)dgvRow.Cells[0]);
                if (checkboxCell.Value == "true")
                {
                    results.Add((Persons)dgvRow.Tag);
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
                newPersonList = new List<Persons>();

                //初始的课题ID
                string defaultSubjectID = ConnectionManager.Context.table("Subjects").select("ID").getValue<string>("");

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
                    string timeforsubjectStr = dr["每年投入时间"] != null ? dr["每年投入时间"].ToString().Trim() : string.Empty;
                    string taskcontentStr = dr["任务分工"] != null ? dr["任务分工"].ToString().Trim() : string.Empty;
                    string subjectStr = dr["研究内容名称(如是仅为项目负责人则为空)"] != null ? dr["研究内容名称(如是仅为项目负责人则为空)"].ToString().Trim() : string.Empty;
                    string roletypeOnlyProjectStr = dr["（仅为项目负责人"] != null ? dr["（仅为项目负责人"].ToString().Trim() : string.Empty;
                    string roletypeProjectAndSubjectStr = dr["项目负责人兼研究内容角色"] != null ? dr["项目负责人兼研究内容角色"].ToString().Trim() : string.Empty;
                    string roletypeOnlySubjectStr = dr["仅为研究内容角色）"] != null ? dr["仅为研究内容角色）"].ToString().Trim() : string.Empty;
                    string roleNameStr = dr["研究内容中职务（负责人或成员）"] != null ? dr["研究内容中职务（负责人或成员）"].ToString().Trim() : string.Empty;

                    //检查非空
                    foreach (DataColumn dc in dr.Table.Columns)
                    {
                        if (dc.ColumnName == "研究内容名称(如是仅为项目负责人则为空)" || dc.ColumnName == "（仅为项目负责人" || dc.ColumnName == "项目负责人兼研究内容角色" || dc.ColumnName == "仅为研究内容角色）")
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
                    if (int.TryParse(timeforsubjectStr, out intResult) == false)
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
                    if (roletypeOnlyProjectStr.Contains("no"))
                    {
                        int subjectCount = 0;
                        object countObj = ConnectionManager.Context.table("Subjects").where("SubjectName='" + subjectStr + "'").select("count(*)").getValue();
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

                    #region 生成Persons对象
                    Persons ppObj = new Persons();
                    ppObj.IDCard = idCardStr;
                    ppObj.Name = nameStr;
                    ppObj.Sex = sexStr;
                    ppObj.Birthday = DateTime.Parse(birthdayStr);
                    ppObj.Job = jobStr;
                    ppObj.Specialty = specStr;
                    ppObj.Telephone = telephoneStr;
                    ppObj.MobilePhone = mobilephoneStr;
                    ppObj.UnitName = workunitStr;
                    ppObj.TimeForSubject = int.Parse(timeforsubjectStr);
                    ppObj.TaskContent = taskcontentStr;

                    //课题ID
                    ppObj.SubjectID = ConnectionManager.Context.table("Subjects").where("SubjectName='" + subjectStr + "'").select("ID").getValue<string>(defaultSubjectID);

                    //角色类型
                    if (roletypeOnlyProjectStr.Contains("yes"))
                    {
                        ppObj.RoleType = FrmAddOrUpdateWorker.isOnlyProject;
                    }
                    else if (roletypeProjectAndSubjectStr.Contains("yes"))
                    {
                        ppObj.RoleType = FrmAddOrUpdateWorker.isProjectAndSubject;
                    }
                    else
                    {
                        ppObj.RoleType = FrmAddOrUpdateWorker.isOnlySubject;
                    }

                    //角色名称
                    ppObj.RoleName = roleNameStr;
                    #endregion

                    newPersonList.Add(ppObj);
                }

                //查询研究内容列表
                List<Subjects> subjectList = ConnectionManager.Context.table("Subjects").select("*").getList<Subjects>(new Subjects());
                //生成研究内容X字典
                int kindex = 0;
                Dictionary<string, string> ktDict = new Dictionary<string, string>();
                foreach (Subjects ktb in subjectList)
                {
                    kindex++;
                    ktDict[ktb.ID] = "研究内容" + kindex;
                }
                dgvDetail.Rows.Clear();
                foreach (Persons pObj in newPersonList)
                {
                    List<object> cells = new List<object>();
                    cells.Add(false);
                    cells.Add(pObj.Name);
                    cells.Add(pObj.Sex);
                    cells.Add(pObj.Job);
                    cells.Add(pObj.Specialty);
                    cells.Add(pObj.UnitName);
                    cells.Add(pObj.TimeForSubject);
                    cells.Add(pObj.TaskContent);
                    cells.Add(pObj.IDCard);

                    if (pObj.RoleType == FrmAddOrUpdateWorker.isOnlyProject)
                    {
                        cells.Add("项目负责人");
                    }
                    else
                    {
                        cells.Add((pObj.RoleType == FrmAddOrUpdateWorker.isProjectAndSubject ? "项目负责人兼" : "") + ((ktDict.ContainsKey(pObj.SubjectID) ? ktDict[pObj.SubjectID] : string.Empty) + pObj.RoleName));
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
    }
}