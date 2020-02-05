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
    public partial class SubjectStepEditor : BaseEditor
    {
        public SubjectStepEditor()
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

            dgvDetail.Rows.Clear();
            List<Subjects> subList = ConnectionManager.Context.table("Subjects").select("*").getList<Subjects>(new Subjects());
            List<ProjectStep> psList = ConnectionManager.Context.table("ProjectStep").select("*").getList<ProjectStep>(new ProjectStep());
            foreach (Subjects sub in subList)
            {
                int stepIndexx = 0;
                foreach (ProjectStep ps in psList)
                {
                    stepIndexx++;

                    Steps stepObj = ConnectionManager.Context.table("Steps").where("SubjectID = '" + sub.ID + "' and StepID = '" + ps.ID + "'").select("*").getItem<Steps>(new Steps());
                    if (string.IsNullOrEmpty(stepObj.ID))
                    {
                        //没有这个记录
                        stepObj.SubjectID = sub.ID;
                        stepObj.StepID = ps.ID;
                        stepObj.StepTag1 = "空";
                        stepObj.StepTag2 = "空";
                        stepObj.StepTag3 = "空";
                        stepObj.StepTag4 = "空";
                    }

                    List<object> cells = new List<object>();
                    cells.Add(sub.SubjectName);
                    cells.Add(stepIndexx.ToString());
                    cells.Add(stepObj.StepTag1);
                    cells.Add(stepObj.StepTag2);
                    cells.Add(stepObj.StepTag3);
                    
                    int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                    dgvDetail.Rows[rowIndex].Tag = stepObj;
                }   
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && dgvDetail.Rows.Count > e.RowIndex && e.RowIndex >= 0)
            {
                Steps task = (Steps)dgvDetail.Rows[e.RowIndex].Tag;
                if (task != null)
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1 && dgvDetail.Rows[e.RowIndex].Cells[0].Value != null && dgvDetail.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        FrmAddOrUpdateSubjectStep form = new FrmAddOrUpdateSubjectStep(task, dgvDetail.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvDetail.Rows[e.RowIndex].Cells[1].Value.ToString());
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            refreshView();
                        }
                    }
                }
            }
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectStrategicLeadershipPlugin.Resource.Question_16;
        }
    }
}