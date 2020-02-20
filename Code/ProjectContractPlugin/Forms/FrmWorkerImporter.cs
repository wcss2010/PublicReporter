using ProjectContractPlugin.DB;
using ProjectContractPlugin.DB.Entitys;
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

namespace ProjectContractPlugin.Forms
{
    public partial class FrmWorkerImporter : PublicReporterLib.SuperForm
    {
        private List<RenYuanBiao> newPersonList;
        public FrmWorkerImporter()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (ofdExcelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFile.Text = ofdExcelDialog.FileName;
                loadExcel(txtFile.Text);
            }
        }

        private RenYuanBiao[] getSelectedPersonList()
        {
            List<RenYuanBiao> results = new List<RenYuanBiao>();
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                DataGridViewCheckBoxCell checkboxCell = ((DataGridViewCheckBoxCell)dgvRow.Cells[0]);
                if (checkboxCell.Value == "true")
                {
                    results.Add((RenYuanBiao)dgvRow.Tag);
                }
            }
            return results.ToArray();
        }

        private void loadExcel(string xlsFile)
        {
            try
            {
                newPersonList = new List<RenYuanBiao>();
                
                //初始的课题ID
                string defaultSubjectID = ConnectionManager.Context.table("KeTiBiao").select("BianHao").getValue<string>("");

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
                    string roletypeOnlyProjectStr = dr["仅为项目负责人"] != null ? dr["仅为项目负责人"].ToString().Trim() : string.Empty;
                    string roletypeProjectAndSubjectStr = dr["项目负责人兼研究内容角色"] != null ? dr["项目负责人兼研究内容角色"].ToString().Trim() : string.Empty;
                    string roletypeOnlySubjectStr = dr["仅为研究内容角色"] != null ? dr["仅为研究内容角色"].ToString().Trim() : string.Empty;
                    string roleNameStr = dr["研究内容中职务（负责人或成员）"] != null ? dr["研究内容中职务（负责人或成员）"].ToString().Trim() : string.Empty;

                    if (string.IsNullOrEmpty(roletypeOnlyProjectStr))
                    {
                        roletypeOnlyProjectStr = "否";
                    }
                    if (string.IsNullOrEmpty(roletypeProjectAndSubjectStr))
                    {
                        roletypeProjectAndSubjectStr = "否";
                    }
                    if (string.IsNullOrEmpty(roletypeOnlySubjectStr))
                    {
                        roletypeOnlySubjectStr = "否";
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
                    if (roletypeOnlyProjectStr.Contains("否"))
                    {
                        int subjectCount = 0;
                        object countObj = ConnectionManager.Context.table("KeTiBiao").where("KeTiMingCheng='" + subjectStr + "'").select("count(*)").getValue();
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
                    RenYuanBiao ppObj = new RenYuanBiao();
                    ppObj.ShenFenZhengHao = idCardStr;
                    ppObj.XingMing = nameStr;
                    ppObj.XingBie = sexStr;
                    ppObj.ShengRi = DateTime.Parse(birthdayStr);
                    ppObj.ZhiCheng = jobStr;
                    ppObj.ZhuanYe = specStr;
                    ppObj.DianHua = telephoneStr;
                    ppObj.ShouJi = mobilephoneStr;
                    ppObj.GongZuoDanWei = workunitStr;
                    ppObj.MeiNianTouRuShiJian = int.Parse(timeforsubjectStr);
                    ppObj.RenWuFenGong = taskcontentStr;

                    //课题ID
                    ppObj.KeTiBiaoHao = ConnectionManager.Context.table("KeTiBiao").where("KeTiMingCheng='" + subjectStr + "'").select("BianHao").getValue<string>(defaultSubjectID);

                    //角色类型
                    if (roletypeOnlyProjectStr.Contains("是"))
                    {
                        ppObj.ShiXiangMuFuZeRen = FrmAddOrUpdateWorker.isOnlyProject;
                        roleNameStr = "成员";
                    }
                    else if (roletypeProjectAndSubjectStr.Contains("是"))
                    {
                        ppObj.ShiXiangMuFuZeRen = FrmAddOrUpdateWorker.isProjectAndSubject;
                    }
                    else
                    {
                        ppObj.ShiXiangMuFuZeRen = FrmAddOrUpdateWorker.isOnlySubject;
                    }

                    //角色名称
                    ppObj.ZhiWu = roleNameStr;
                    #endregion

                    newPersonList.Add(ppObj);
                }

                //查询研究内容列表
                List<KeTiBiao> subjectList = ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());
                //生成研究内容X字典
                int kindex = 0;
                Dictionary<string, string> ktDict = new Dictionary<string, string>();
                foreach (KeTiBiao ktb in subjectList)
                {
                    kindex++;
                    ktDict[ktb.BianHao] = "课题" + kindex;
                }
                dgvDetail.Rows.Clear();
                foreach (RenYuanBiao pObj in newPersonList)
                {
                    List<object> cells = new List<object>();
                    cells.Add("true");
                    cells.Add(pObj.XingMing);
                    cells.Add(pObj.XingBie);
                    cells.Add(pObj.ZhiCheng);
                    cells.Add(pObj.ZhuanYe);
                    cells.Add(pObj.GongZuoDanWei);
                    cells.Add(pObj.MeiNianTouRuShiJian);
                    cells.Add(pObj.RenWuFenGong);
                    cells.Add(pObj.ShenFenZhengHao);

                    if (pObj.ShiXiangMuFuZeRen == FrmAddOrUpdateWorker.isOnlyProject)
                    {
                        cells.Add("项目负责人");
                    }
                    else
                    {
                        cells.Add((pObj.ShiXiangMuFuZeRen == FrmAddOrUpdateWorker.isProjectAndSubject ? "项目负责人兼" : "") + ((ktDict.ContainsKey(pObj.KeTiBiaoHao) ? ktDict[pObj.KeTiBiaoHao] : string.Empty) + pObj.ZhiWu));
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            RenYuanBiao[] personList = getSelectedPersonList();
            if (personList.Length == 0)
            {
                MessageBox.Show("对不起，请选择要导入的人员！");
                return;
            }

            foreach (RenYuanBiao newObj in personList)
            {
                RenYuanBiao oldObj = ConnectionManager.Context.table("RenYuanBiao").where("ShenFenZhengHao='" + newObj.ShenFenZhengHao + "'").select("*").getItem<RenYuanBiao>(new RenYuanBiao());
                if (string.IsNullOrEmpty(oldObj.BianHao))
                {
                    //insert
                    newObj.BianHao = Guid.NewGuid().ToString();
                    newObj.copyTo(ConnectionManager.Context.table("RenYuanBiao")).insert();
                }
                else
                {
                    //update
                    newObj.BianHao = oldObj.BianHao;
                    newObj.copyTo(ConnectionManager.Context.table("RenYuanBiao")).where("BianHao='" + newObj.BianHao + "'").update();
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void llTemplete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sourcePath = Path.Combine(PluginRootObj.RootDir, Path.Combine("Helper", "personTemplete.xls"));

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
    }
}