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
using System.Diagnostics;
using System.IO;


namespace ProjectStrategicLeadershipPlugin.Editor
{
    public partial class ConfidentialQualificationEditor : BaseEditor
    {
        public ConfidentialQualificationEditor()
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
            List<ExtFiles> list = ConnectionManager.Context.table("ExtFiles").select("*").getList<ExtFiles>(new ExtFiles());
            int index = 0;
            foreach (ExtFiles efl in list)
            {
                index++;
                List<object> cells = new List<object>();
                cells.Add(index.ToString());
                cells.Add(efl.ExtName);
                cells.Add(efl.SourceFileName);
                cells.Add(efl.IsIgnore == 1 ? true : false);

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = efl;
            }
        }

        public override bool isInputCompleted()
        {
            return true;
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && dgvDetail.Rows.Count > e.RowIndex && e.RowIndex >= 0)
            {
                ExtFiles task = (ExtFiles)dgvDetail.Rows[e.RowIndex].Tag;
                if (task != null)
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                    {
                        #region 编辑
                        FrmAddOrUpdateConfidentialQualification form = new FrmAddOrUpdateConfidentialQualification(task);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            refreshView();
                        }
                        #endregion
                    }
                    else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                    {
                        #region 删除
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                File.Delete(Path.Combine(PluginRootObj.filesDir, task.RealFileName));
                            }
                            catch (Exception ex) { }

                            ConnectionManager.Context.table("ExtFiles").where("ID='" + task.ID + "'").delete();
                            refreshView();
                        }
                        #endregion
                    }
                    else if (e.ColumnIndex == dgvDetail.Columns.Count - 4)
                    {
                        #region 打开
                        if (string.IsNullOrEmpty(task.RealFileName))
                        {
                            return;
                        }
                        else
                        {
                            try
                            {
                                Process.Start(Path.Combine(PluginRootObj.filesDir, task.RealFileName));
                            }
                            catch (Exception ex) { }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddOrUpdateConfidentialQualification form = new FrmAddOrUpdateConfidentialQualification(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                refreshView();
            }
        }
    }
}