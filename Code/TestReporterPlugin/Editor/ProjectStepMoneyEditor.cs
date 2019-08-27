using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TestReporterPlugin.DB;
using TestReporterPlugin.DB.Entitys;
using TestReporterPlugin.Utility;
using System.IO;
using System.Diagnostics;

namespace TestReporterPlugin.Editor
{
    public partial class ProjectStepMoneyEditor : BaseEditor
    {
        public ProjectStepMoneyEditor()
        {
            InitializeComponent();

            //dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = global::TestReporterPlugin.Resource.DELETE_28;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgress();

            try
            {
                OnSaveEvent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！Ex:" + ex.ToString());
            }
            finally
            {
                upf.Close();
            }
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = global::TestReporterPlugin.Resource.DELETE_28;
        }

        public override void ClearView()
        {
            base.ClearView();

            txtTotalTime.Text = "";
            txtTotalMoney.Text = "";
            txtStepCount.Text = "";

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj != null)
            {
                txtTotalTime.Text = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.TotalTime != null ? ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.TotalTime.Value + "" : "0";
                txtTotalMoney.Text = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.TotalMoney != null ? ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.TotalMoney.Value + "" : "0";
                txtStepCount.Text = "0";

                UpdateStepList();
            }
        }

        public void UpdateStepList()
        {
            StepList = ConnectionManager.Context.table("Step").where("ProjectID='" + ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID + "'").select("*").getList<Step>(new Step());
            KeTiList = ConnectionManager.Context.table("Project").where("Type='" + "课题" + "' and ParentID='" + ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID + "'").select("*").getList<Project>(new Project());

            int indexx = 0;
            dgvDetail.Rows.Clear();
            ((DataGridViewImageColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 1]).Image = TestReporterPlugin.Resource.DELETE_28;
            foreach (Step step in StepList)
            {
                List<object> cells = new List<object>();
                indexx++;
                cells.Add(indexx+"");
                cells.Add(step.StepIndex != null ? step.StepIndex.Value : 0);
                cells.Add(step.StepTime != null ? step.StepTime.Value : 0);
                cells.Add(step.StepDest);
                cells.Add(step.StepContent);
                cells.Add(step.StepResult);
                cells.Add(step.StepTarget);
                cells.Add(step.StepMoney);

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = step;
            }

            txtStepCount.Text = StepList != null ? StepList.Count + "" : "0";
        }

        public void Build4StepItems()
        {
            if (StepList == null || StepList.Count == 0)
            {
                int[] times = new int[] { 18, 12, 12, 18 };
                for (int k = 0; k < 4; k++)
                {
                    List<object> cells = new List<object>();
                    cells.Add(k + 1);
                    cells.Add(k + 1);
                    cells.Add(times[k]);
                    cells.Add("空");
                    cells.Add("空");
                    cells.Add("空");
                    cells.Add("空");
                    cells.Add("0");

                    dgvDetail.Rows.Add(cells.ToArray());
                }
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            try
            {
                foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
                {
                    int lastStepIndex = -1;

                    #region 添加Step到项目
                    Step step = null;
                    if (dgvRow.Tag == null)
                    {
                        //新行
                        step = new Step();
                        step.ProjectID = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID;
                    }
                    else
                    {
                        //已在数据
                        step = (Step)dgvRow.Tag;

                        //当前的StepIndex 
                        lastStepIndex = step.StepIndex != null ? step.StepIndex.Value : -1;
                    }

                    if (dgvRow.Cells[1].Value == null)
                    {
                        break;
                    }

                    if (dgvRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("对不起,请输入阶段时长(月)");
                        break;
                    }

                    if (dgvRow.Cells[3].Value == null || string.IsNullOrEmpty(dgvRow.Cells[3].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入完成内容及阶段目标");
                        return;
                    }
                    dgvRow.Cells[4].Value = "暂时不用";
                    if (dgvRow.Cells[4].Value == null || string.IsNullOrEmpty(dgvRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入完成内容");
                        return;
                    }
                    if (dgvRow.Cells[5].Value == null || string.IsNullOrEmpty(dgvRow.Cells[5].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入阶段成果、考核指标及考核方式");
                        return;
                    }

                    dgvRow.Cells[6].Value = "暂时不用";
                    if (dgvRow.Cells[6].Value == null || string.IsNullOrEmpty(dgvRow.Cells[6].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入考核指标");
                        return;
                    }
                    if (dgvRow.Cells[7].Value == null || string.IsNullOrEmpty(dgvRow.Cells[7].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入阶段经费(万)");
                        return;
                    }

                    step.StepIndex = Int32.Parse(((DataGridViewTextBoxCell)dgvRow.Cells[1]).Value.ToString());
                    step.StepTime = Int32.Parse(((DataGridViewTextBoxCell)dgvRow.Cells[2]).Value.ToString());
                    step.StepDest = dgvRow.Cells[3].Value.ToString();
                    step.StepContent = dgvRow.Cells[4].Value.ToString();
                    step.StepResult = dgvRow.Cells[5].Value.ToString();
                    step.StepTarget = dgvRow.Cells[6].Value.ToString();
                    step.StepMoney = decimal.Parse(dgvRow.Cells[7].Value.ToString());

                    if (string.IsNullOrEmpty(step.ID))
                    {
                        step.ID = Guid.NewGuid().ToString();
                        step.copyTo(ConnectionManager.Context.table("Step")).insert();
                    }
                    else
                    {
                        step.copyTo(ConnectionManager.Context.table("Step")).where("ID='" + step.ID + "'").update();
                    }
                    #endregion

                    #region 添加课题的Step
                    if (KeTiList != null)
                    {
                        if (lastStepIndex == -1)
                        {
                            lastStepIndex = step.StepIndex != null ? step.StepIndex.Value : -1;
                        }

                        foreach (Project keti in KeTiList)
                        {
                            Step ketiStep = ConnectionManager.Context.table("Step").where("ProjectID='" + keti.ID + "' and StepIndex = " + lastStepIndex).select("*").getItem<Step>(new Step());
                            if (ketiStep != null && !string.IsNullOrEmpty(ketiStep.ID))
                            {
                                //已存在
                                ketiStep.StepIndex = step.StepIndex;
                                ketiStep.StepTime = step.StepTime;

                                ketiStep.copyTo(ConnectionManager.Context.table("Step")).where("ID='" + ketiStep.ID + "'").update();
                            }
                            else
                            {
                                //要添加
                                ketiStep = new Step();
                                ketiStep.ID = Guid.NewGuid().ToString();
                                ketiStep.ProjectID = keti.ID;
                                ketiStep.StepIndex = step.StepIndex;
                                ketiStep.StepTime = step.StepTime;

                                ketiStep.copyTo(ConnectionManager.Context.table("Step")).insert();

                                //添加ProjectAndStep数据
                                ProjectAndStep projectAndStep = new ProjectAndStep();
                                projectAndStep.ID = Guid.NewGuid().ToString();
                                projectAndStep.StepID = ketiStep.ID;
                                projectAndStep.copyTo(ConnectionManager.Context.table("ProjectAndStep")).insert();
                            }
                        }
                    }
                    #endregion
                }

                //刷新当前页
                RefreshView();

                //刷新课题阶段划分表
                foreach (BaseEditor be in ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).editorMap.Values)
                {
                    if (be is SubjectStepMoneyEditor)
                    {
                        //刷新列表
                        be.RefreshView();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        public void SaveOnly()
        {
            try
            {
                foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
                {
                    int lastStepIndex = -1;

                    #region 添加Step到项目
                    Step step = null;
                    if (dgvRow.Tag == null)
                    {
                        //新行
                        step = new Step();
                        step.ProjectID = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID;
                    }
                    else
                    {
                        //已在数据
                        step = (Step)dgvRow.Tag;

                        //当前的StepIndex 
                        lastStepIndex = step.StepIndex != null ? step.StepIndex.Value : -1;
                    }

                    if (dgvRow.Cells[1].Value == null)
                    {
                        dgvRow.Cells[1].Value = 0;
                    }

                    if (dgvRow.Cells[2].Value == null)
                    {
                        dgvRow.Cells[2].Value = 6;
                    }

                    if (dgvRow.Cells[3].Value == null)
                    {
                        dgvRow.Cells[3].Value = string.Empty;
                    }
                    dgvRow.Cells[4].Value = "暂时不用";
                    if (dgvRow.Cells[4].Value == null || string.IsNullOrEmpty(dgvRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入完成内容");
                        return;
                    }
                    if (dgvRow.Cells[5].Value == null)
                    {
                        dgvRow.Cells[5].Value = string.Empty;
                    }

                    dgvRow.Cells[6].Value = "暂时不用";
                    if (dgvRow.Cells[6].Value == null || string.IsNullOrEmpty(dgvRow.Cells[6].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入考核指标");
                        return;
                    }
                    if (dgvRow.Cells[7].Value == null)
                    {
                        dgvRow.Cells[7].Value = 0;
                    }

                    step.StepIndex = Int32.Parse(((DataGridViewTextBoxCell)dgvRow.Cells[1]).Value.ToString());
                    step.StepTime = Int32.Parse(((DataGridViewTextBoxCell)dgvRow.Cells[2]).Value.ToString());
                    step.StepDest = dgvRow.Cells[3].Value.ToString();
                    step.StepContent = dgvRow.Cells[4].Value.ToString();
                    step.StepResult = dgvRow.Cells[5].Value.ToString();
                    step.StepTarget = dgvRow.Cells[6].Value.ToString();
                    step.StepMoney = decimal.Parse(dgvRow.Cells[7].Value.ToString());

                    if (string.IsNullOrEmpty(step.ID))
                    {
                        step.ID = Guid.NewGuid().ToString();
                        step.copyTo(ConnectionManager.Context.table("Step")).insert();
                    }
                    else
                    {
                        step.copyTo(ConnectionManager.Context.table("Step")).where("ID='" + step.ID + "'").update();
                    }
                    #endregion

                    #region 添加课题的Step
                    if (KeTiList != null)
                    {
                        if (lastStepIndex == -1)
                        {
                            lastStepIndex = step.StepIndex != null ? step.StepIndex.Value : -1;
                        }

                        foreach (Project keti in KeTiList)
                        {
                            Step ketiStep = ConnectionManager.Context.table("Step").where("ProjectID='" + keti.ID + "' and StepIndex = " + lastStepIndex).select("*").getItem<Step>(new Step());
                            if (ketiStep != null && !string.IsNullOrEmpty(ketiStep.ID))
                            {
                                //已存在
                                ketiStep.StepIndex = step.StepIndex;
                                ketiStep.StepTime = step.StepTime;

                                ketiStep.copyTo(ConnectionManager.Context.table("Step")).where("ID='" + ketiStep.ID + "'").update();
                            }
                            else
                            {
                                //要添加
                                ketiStep = new Step();
                                ketiStep.ID = Guid.NewGuid().ToString();
                                ketiStep.ProjectID = keti.ID;
                                ketiStep.StepIndex = step.StepIndex;
                                ketiStep.StepTime = step.StepTime;

                                ketiStep.copyTo(ConnectionManager.Context.table("Step")).insert();

                                //添加ProjectAndStep数据
                                ProjectAndStep projectAndStep = new ProjectAndStep();
                                projectAndStep.ID = Guid.NewGuid().ToString();
                                projectAndStep.StepID = ketiStep.ID;
                                projectAndStep.copyTo(ConnectionManager.Context.table("ProjectAndStep")).insert();
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        public List<Step> StepList { get; set; }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && dgvDetail.Rows.Count > e.RowIndex && e.RowIndex >= 0)
            {
                Step step = (Step)dgvDetail.Rows[e.RowIndex].Tag;
                if (step != null && e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //先保存当前的
                        if (dgvDetail.Rows.Count >= 2)
                        {
                            SaveOnly();
                        }

                        ConnectionManager.Context.table("Step").where("ID='" + step.ID + "'").delete();
                        ConnectionManager.Context.table("ProjectAndStep").where("StepID='" + step.ID + "'").delete();

                        if (KeTiList != null)
                        {
                            foreach (Project keti in KeTiList)
                            {
                                Step substep = ConnectionManager.Context.table("Step").where("ProjectID='" + keti.ID + "' and StepIndex =" + step.StepIndex).select("*").getItem<Step>(new Step());
                                ConnectionManager.Context.table("Step").where("ProjectID='" + keti.ID + "' and StepIndex =" + step.StepIndex).delete();

                                if (substep == null || string.IsNullOrEmpty(substep.ID))
                                {
                                    continue;
                                }

                                ConnectionManager.Context.table("ProjectAndStep").where("StepID='" + substep.ID + "'").delete();
                            }
                        }

                        ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).refreshEditors();
                    }
                }else
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                    {
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                dgvDetail.Rows.RemoveAt(e.RowIndex);
                            }
                            catch (Exception ex)
                            {
                                UpdateStepList();
                            }
                        }
                    }
                }
            }
        }

        public List<Project> KeTiList { get; set; }

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请输入阶段信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }

        private void dgvDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string content = dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : string.Empty;
                Forms.FrmInputBox textboxForm = new Forms.FrmInputBox(content);
                if (textboxForm.ShowDialog() == DialogResult.OK)
                {
                    dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = textboxForm.SelectedText;
                }
            }
            else if (e.ColumnIndex == 5)
            {
                string content = dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : string.Empty;
                Forms.FrmInputBox textboxForm = new Forms.FrmInputBox(content);
                if (textboxForm.ShowDialog() == DialogResult.OK)
                {
                    dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = textboxForm.SelectedText;
                }
            }
        }

        private void btnExcelLoad_Click(object sender, EventArgs e)
        {
            if (ofdExcelDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataSet ds = ExcelHelper.ExcelToDataSet(ofdExcelDialog.FileName);
                    if (ds != null && ds.Tables.Count >= 1)
                    {
                        //显示提示窗体
                        Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
                        upf.LabalText = "正在导入，请稍等...";
                        upf.ShowProgress();

                        foreach (DataTable dt in ds.Tables)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr.ItemArray != null)
                                {
                                    //插入数据
                                    insertDataFromDataRow(dr);
                                }
                            }
                        }

                        upf.Close();

                        RefreshView();
                        MessageBox.Show("操作完成！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导入失败!Ex:" + ex.ToString());
                }
            }
        }

        private void insertDataFromDataRow(DataRow dr)
        {
            try
            {
                //加载字段
                string stepIndex = dr["阶段"] != null ? dr["阶段"].ToString() : string.Empty;
                string stepTime = dr["阶段时间(月)"] != null ? dr["阶段时间(月)"].ToString() : string.Empty;
                string stepContent = dr["完成内容及阶段目标"] != null ? dr["完成内容及阶段目标"].ToString() : string.Empty;
                string stepResult = dr["阶段成果、考核指标及考核方式"] != null ? dr["阶段成果、考核指标及考核方式"].ToString() : string.Empty;
                string stepMoney = dr["阶段经费(万)"] != null ? dr["阶段经费(万)"].ToString() : string.Empty;

                //进行必要字段的校验
                int timeResult = 0;
                if (int.TryParse(stepIndex, out timeResult) == false)
                {
                    throw new Exception("对不起，'序号'只能是数字！");
                }
                timeResult = 0;
                if (int.TryParse(stepTime, out timeResult) == false)
                {
                    throw new Exception("对不起，'阶段时间(月)'只能是数字！");
                }
                if (timeResult <= 5 || timeResult >= 19)
                {
                    throw new Exception("对不起，'阶段时间(月)'的范围应该在6~18之间！");
                }
                timeResult = 0;
                if (int.TryParse(stepMoney, out timeResult) == false)
                {
                    throw new Exception("对不起，'阶段经费(万)'只能是数字！");
                }

                //检查非空
                foreach (DataColumn dc in dr.Table.Columns)
                {
                     if (dr[dc.ColumnName] == null || dr[dc.ColumnName].ToString() == string.Empty)
                    {
                        throw new Exception("对不起，'" + dc.ColumnName + "'不能为空！");
                    }
                }

                bool needInsert = true;
                foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
                {
                    if (dgvRow.Cells[1].Value != null && dgvRow.Cells[1].Value.ToString().Equals(stepIndex))
                    {
                        needInsert = false;

                        dgvRow.Cells[2].Value = stepTime;
                        dgvRow.Cells[3].Value = stepContent;
                        dgvRow.Cells[5].Value = stepResult;
                        dgvRow.Cells[7].Value = stepMoney;
                    }
                }

                if (needInsert)
                {
                    DataGridViewRow dgvRow = dgvDetail.Rows[dgvDetail.Rows.Add()];
                    dgvRow.Cells[1].Value = stepIndex;
                    dgvRow.Cells[2].Value = stepTime;
                    dgvRow.Cells[3].Value = stepContent;
                    dgvRow.Cells[5].Value = stepResult;
                    dgvRow.Cells[7].Value = stepMoney;
                }

                btnSave.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("插入错误！Ex:" + ex.ToString(), "错误");
            }
        }

        private void lklDownloadFuJian_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sourcePath = Path.Combine(Application.StartupPath, Path.Combine("Helper", "jieduanhuafen.xls"));

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xls|*.xls";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvDetail.Rows.Add();
            dgvDetail.Rows[rowIndex].Cells[1].Value = (dgvDetail.Rows.Count).ToString();
        }
    }
}