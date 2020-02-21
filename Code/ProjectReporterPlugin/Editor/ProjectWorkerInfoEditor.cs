using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProjectReporterPlugin.DB;
using ProjectReporterPlugin.DB.Entitys;
using ProjectReporterPlugin.Forms;
using ProjectReporterPlugin.DB.Services;
using System.IO;
using System.Diagnostics;

namespace ProjectReporterPlugin.Editor
{
    public partial class ProjectWorkerInfoEditor : BaseEditor
    {
        public ProjectWorkerInfoEditor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FrmEditWorkerInfo form = new FrmEditWorkerInfo(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().refreshEditors();
            }
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = global::ProjectReporterPlugin.Resource.DELETE_28;
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 2, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = "编辑";
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 3, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = "向下";
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 4, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = "向上";
        }

        public override void ClearView()
        {
            base.ClearView();

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();
        }

        public List<Task> TaskList { get; set; }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 3)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;
                        MoveToDown(e.RowIndex, task);
                    }
                }

                if (e.ColumnIndex == dgvDetail.Columns.Count - 4)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;
                        MoveToUp(e.RowIndex, task);
                    }
                }

                if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;

                        FrmEditWorkerInfo form = new FrmEditWorkerInfo(task);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().refreshEditors();
                        }
                    }
                }

                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ConnectionManager.Context.table("Task").where("ID='" + task.ID + "'").delete();
                            PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().refreshEditors();
                        }
                    }
                    else
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
                                    //UpdateTaskList();
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 向上移动
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="task"></param>
        private void MoveToUp(int rowIndex, Task task)
        {
            if (TaskList != null)
            {
                int taskIndex = TaskList.IndexOf(task);
                if (taskIndex >= 1)
                {
                    TaskList.Remove(task);
                    TaskList.Insert(taskIndex - 1, task);

                    int ri = 0;
                    foreach (Task t in TaskList)
                    {
                        t.DisplayOrder = ri;
                        ri++;

                        t.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + t.ID + "'").update();
                    }

                    //UpdateTaskList();
                    if (taskIndex >= 1)
                    {
                        dgvDetail.Rows[taskIndex - 1].Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// 向下移动
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="task"></param>
        private void MoveToDown(int rowIndex, Task task)
        {
            if (TaskList != null)
            {
                int taskIndex = TaskList.IndexOf(task);
                if (taskIndex <= TaskList.Count - 2)
                {
                    TaskList.Remove(task);
                    TaskList.Insert(taskIndex + 1, task);

                    int ri = 0;
                    foreach (Task t in TaskList)
                    {
                        t.DisplayOrder = ri;
                        ri++;

                        t.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + t.ID + "'").update();
                    }

                    //UpdateTaskList();
                    if (taskIndex < dgvDetail.Rows.Count - 1)
                    {
                        dgvDetail.Rows[taskIndex + 1].Selected = true;
                    }
                    else
                    {
                        dgvDetail.Rows[dgvDetail.Rows.Count - 1].Selected = true;
                    }
                }
            }
        }

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请输入研究骨干信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }

        private void dgvDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows[e.RowIndex].Tag != null)
            {
                Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;
                FrmEditWorkerInfo form = new FrmEditWorkerInfo(task);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().refreshEditors();
                }
            }
        }

        /// <summary>
        /// 获得最大的记录号
        /// </summary>
        /// <returns></returns>
        public static int GetMaxDisplayOrder()
        {
            try
            {
                return (int)ConnectionManager.Context.table("Task").select("max(DisplayOrder)").getValue<long>(0);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            FrmEditWorkerInfo workerInfo = new FrmEditWorkerInfo(null);
            if (workerInfo.ShowDialog() == DialogResult.OK)
            {
                PluginRootObj.refreshEditors();
            }
        }

        private void btnImporter_Click(object sender, EventArgs e)
        {
            FrmWorkerImporter importerForm = new FrmWorkerImporter();
            if (importerForm.ShowDialog() == DialogResult.OK)
            {
                PluginRootObj.refreshEditors();
            }
        }
    }
}