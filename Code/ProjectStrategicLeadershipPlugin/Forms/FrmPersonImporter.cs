using ProjectStrategicLeadershipPlugin.DB;
using ProjectStrategicLeadershipPlugin.DB.Entitys;
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

namespace ProjectStrategicLeadershipPlugin.Forms
{
    public partial class FrmPersonImporter : AbstractEditorPlugin.BaseForm
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
                    newObj.DisplayOrder = ProjectStrategicLeadershipPlugin.Editor.WorkerEditor.GetMaxDisplayOrder() + 1;
                    newObj.copyTo(ConnectionManager.Context.table("Persons")).insert();
                }
                else
                {
                    //update
                    newObj.ID = oldObj.ID;
                    newObj.DisplayOrder = oldObj.DisplayOrder;
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

                DataTable dtData = ExcelBuilder.excelToDataTable(xlsFile, "Person", true);

                int eRowIndex = 1;
                foreach (DataRow dr in dtData.Rows)
                {
                    eRowIndex++;

                    string idCardStr = dr["身份证号"] != null ? dr["身份证号"].ToString().Trim() : string.Empty;
                    string nameStr = dr["姓名"] != null ? dr["姓名"].ToString().Trim() : string.Empty;
                    string jobStr = dr["职务/职称"] != null ? dr["职务/职称"].ToString().Trim() : string.Empty;
                    string specStr = dr["从事专业"] != null ? dr["从事专业"].ToString().Trim() : string.Empty;
                    string workunitStr = dr["工作单位"] != null ? dr["工作单位"].ToString().Trim() : string.Empty;
                    string taskcontentStr = dr["项目任务分工"] != null ? dr["项目任务分工"].ToString().Trim() : string.Empty;

                    //检查非空
                    foreach (DataColumn dc in dr.Table.Columns)
                    {
                        if (dr[dc.ColumnName] == null || dr[dc.ColumnName].ToString() == string.Empty)
                        {
                            if (string.IsNullOrEmpty(nameStr))
                            {
                                throw new Exception("第" + eRowIndex + "行的'" + dc.ColumnName + "'不能为空！");
                            }
                            else
                            {
                                throw new Exception("第" + eRowIndex + "行的" + nameStr + "的'" + dc.ColumnName + "'不能为空！");
                            }
                        }
                    }
                    
                    #region 生成Persons对象
                    Persons ppObj = new Persons();
                    ppObj.IDCard = idCardStr;
                    ppObj.Name = nameStr;
                    ppObj.Job = jobStr;
                    ppObj.Specialty = specStr;
                    ppObj.UnitName = workunitStr;
                    ppObj.TaskContent = taskcontentStr;
                    #endregion

                    newPersonList.Add(ppObj);
                }

                dgvDetail.Rows.Clear();
                foreach (Persons pObj in newPersonList)
                {
                    List<object> cells = new List<object>();
                    cells.Add("true");
                    cells.Add(pObj.Name);
                    cells.Add(pObj.IDCard);
                    cells.Add(pObj.UnitName);
                    cells.Add(pObj.Job);
                    cells.Add(pObj.Specialty);
                    cells.Add(pObj.TaskContent);
                    
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
    }
}