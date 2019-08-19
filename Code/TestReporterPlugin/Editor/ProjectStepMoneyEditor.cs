using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TestReporterPlugin.DB;
using TestReporterPlugin.DB.Entitys;

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
            Forms.FrmUIDoWorkProcess upf = new Forms.FrmUIDoWorkProcess();
            upf.EnabledDisplayProgress = false;
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

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        public override void ClearView()
        {
            base.ClearView();

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            UpdateStepList();
        }

        private void UpdateStepList()
        {
            StepList = ConnectionManager.Context.table("Step").where("ProjectID='" + ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).ProjectObj.ID + "'").select("*").getList<Step>(new Step());
            if (StepList != null)
            {
                int indexx = 0;
                dgvDetail.Rows.Clear();
                foreach (Step step in StepList)
                {
                    string stepContent = string.Empty;
                    ProjectAndStep projectAndStep = ConnectionManager.Context.table("ProjectAndStep").where("StepID='" + step.ID + "'").select("*").getItem<ProjectAndStep>(new ProjectAndStep());
                    if (projectAndStep != null)
                    {
                        stepContent = projectAndStep.StepContent;
                    }

                    indexx++;
                    List<object> cells = new List<object>();
                    cells.Add(indexx + "");
                    cells.Add(step.StepIndex);
                    cells.Add(stepContent);
                    cells.Add(step.StepDest);
                    cells.Add(step.StepMoney);

                    int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                    dgvDetail.Rows[rowIndex].Tag = step;
                }  
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                if (dgvRow.Tag != null)
                {
                    Step step = (Step)dgvRow.Tag;

                    if (dgvRow.Cells[2].Value == null || string.IsNullOrEmpty(dgvRow.Cells[2].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入阶段内容");
                        return;
                    }
                    if (dgvRow.Cells[3].Value == null || string.IsNullOrEmpty(dgvRow.Cells[3].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入阶段目标");
                        return;
                    }
                    if (dgvRow.Cells[4].Value == null || string.IsNullOrEmpty(dgvRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入阶段经费");
                        return;
                    }

                    ProjectAndStep pas = ConnectionManager.Context.table("ProjectAndStep").where("StepID='" + step.ID + "'").select("*").getItem<ProjectAndStep>(new ProjectAndStep());
                    if (pas != null)
                    {
                        pas.StepContent = dgvRow.Cells[2].Value.ToString();
                        pas.copyTo(ConnectionManager.Context.table("ProjectAndStep")).where("ID='" + pas.ID + "'").update();
                    }

                    step.StepDest = dgvRow.Cells[3].Value.ToString();
                    step.StepMoney = decimal.Parse(dgvRow.Cells[4].Value.ToString());

                    step.copyTo(ConnectionManager.Context.table("Step")).where("ID='" + step.ID + "'").update();
                }
            }

            UpdateStepList();
        }

        public List<Step> StepList { get; set; }

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请输入项目阶段信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }
    }
}