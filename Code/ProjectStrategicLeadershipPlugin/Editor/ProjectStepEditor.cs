using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicReporterLib.Utility;
using ProjectStrategicLeadershipPlugin.DB;
using ProjectStrategicLeadershipPlugin.DB.Entitys;
using Newtonsoft.Json;
using ProjectStrategicLeadershipPlugin.Forms;
using AbstractEditorPlugin;
using AbstractEditorPlugin.Controls;
using AbstractEditorPlugin.Forms;
using AbstractEditorPlugin.Utility;

namespace ProjectStrategicLeadershipPlugin.Editor
{
    public partial class ProjectStepEditor : BaseEditor
    {
        private List<ProjectStep> list;
        public ProjectStepEditor()
        {
            InitializeComponent();
        }

        public override void clearView()
        {
            base.clearView();

            dgvDetail.Rows.Clear();
        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }

        public override void refreshView()
        {
            base.refreshView();

            //检查是否需要创建阶段
            buildProjectSteps();

            dgvDetail.Rows.Clear();
            list = ConnectionManager.Context.table("ProjectStep").select("*").getList<ProjectStep>(new ProjectStep());
            int indexx = 0;
            foreach (ProjectStep ps in list)
            {
                indexx++;

                List<object> cells = new List<object>();
                cells.Add(indexx.ToString());
                cells.Add(ps.StepTime);
                cells.Add(ps.StepTag1);

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = ps;
            }
        }

        private void buildProjectSteps()
        {
            int rowCount = 0;
            object objCount = ConnectionManager.Context.table("ProjectStep").select("count(*)").getValue();
            try
            {
                rowCount = int.Parse(objCount.ToString());
            }
            catch (Exception ex) { }

            if (rowCount == 0)
            {
               //需要创建
                ProjectStep psObj = new ProjectStep();
                psObj.ID = Guid.NewGuid().ToString();
                psObj.StepTime = 18;
                psObj.StepTag1 = "空";
                psObj.StepTag2 = "空";
                psObj.StepTag3 = "空";
                psObj.StepTag4 = "空";
                psObj.copyTo(ConnectionManager.Context.table("ProjectStep")).insert();

                psObj = new ProjectStep();
                psObj.ID = Guid.NewGuid().ToString();
                psObj.StepTime = 12;
                psObj.StepTag1 = "空";
                psObj.StepTag2 = "空";
                psObj.StepTag3 = "空";
                psObj.StepTag4 = "空";
                psObj.copyTo(ConnectionManager.Context.table("ProjectStep")).insert();

                psObj = new ProjectStep();
                psObj.ID = Guid.NewGuid().ToString();
                psObj.StepTime = 12;
                psObj.StepTag1 = "空";
                psObj.StepTag2 = "空";
                psObj.StepTag3 = "空";
                psObj.StepTag4 = "空";
                psObj.copyTo(ConnectionManager.Context.table("ProjectStep")).insert();

                psObj = new ProjectStep();
                psObj.ID = Guid.NewGuid().ToString();
                psObj.StepTime = 18;
                psObj.StepTag1 = "空";
                psObj.StepTag2 = "空";
                psObj.StepTag3 = "空";
                psObj.StepTag4 = "空";
                psObj.copyTo(ConnectionManager.Context.table("ProjectStep")).insert();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddOrUpdateProjectStep form = new FrmAddOrUpdateProjectStep(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                PluginRootObj.refreshEditors();
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && dgvDetail.Rows.Count > e.RowIndex && e.RowIndex >= 0)
            {
                ProjectStep task = (ProjectStep)dgvDetail.Rows[e.RowIndex].Tag;
                if (task != null)
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                    {
                        #region 编辑
                        FrmAddOrUpdateProjectStep form = new FrmAddOrUpdateProjectStep(task);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            PluginRootObj.refreshEditors();
                        }
                        #endregion
                    }
                    else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                    {
                        #region 删除
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ConnectionManager.Context.table("ProjectStep").where("ID='" + task.ID + "'").delete();
                            ConnectionManager.Context.table("Steps").where("StepID='" + task.ID + "'").delete();

                            PluginRootObj.refreshEditors();
                        }
                        #endregion
                    }
                }
            }
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectStrategicLeadershipPlugin.Resource.Question_16;
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 2, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectStrategicLeadershipPlugin.Resource.DELETE_28;
        }
    }
}