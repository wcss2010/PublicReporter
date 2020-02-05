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
    public partial class WorkerGroupEditor : BaseEditor
    {
        public WorkerGroupEditor()
        {
            InitializeComponent();
        }

        public override void clearView()
        {
            base.clearView();

            dgvDetail.Rows.Clear();
        }

        public override void refreshView()
        {
            base.refreshView();

            dgvDetail.Rows.Clear();
            List<Subjects> subList = ConnectionManager.Context.table("Subjects").select("*").getList<Subjects>(new Subjects());
            foreach(Subjects sub in subList)
            {
                Persons pObj = ConnectionManager.Context.table("Persons").where("SubjectID = '" + sub.ID + "' and RoleName='负责人'").select("*").getItem<Persons>(new Persons());
                if (string.IsNullOrEmpty(pObj.ID))
                {
                    continue;
                }

                List<object> cells = new List<object>();
                cells.Add(sub.SubjectName);
                cells.Add(pObj.Name);
                cells.Add(pObj.AttachInfo);
                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = pObj;
            }
        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && dgvDetail.Rows.Count > e.RowIndex && e.RowIndex >= 0)
            {
                Persons task = (Persons)dgvDetail.Rows[e.RowIndex].Tag;
                if (task != null)
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                    {
                        FrmInputBox inputFrm = new FrmInputBox(task.AttachInfo);
                        if (inputFrm.ShowDialog() == DialogResult.OK)
                        {
                            task.AttachInfo = inputFrm.SelectedText;
                            task.copyTo(ConnectionManager.Context.table("Persons")).where("ID='" + task.ID + "'").update();
                            PluginRootObj.refreshEditors();
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