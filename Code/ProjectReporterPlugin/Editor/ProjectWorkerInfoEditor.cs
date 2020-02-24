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
        private List<PersonObject> personList = new List<PersonObject>();

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

            List<Task> taskList = ConnectionManager.Context.table("Task").where("ProjectID in (select ID from Project where ParentID = '" + PluginRootObj.projectObj.ID + "') or ProjectID='" + PluginRootObj.projectObj.ID + "'").orderBy("DisplayOrder").select("*").getList<Task>(new Task());

            //查找项目负责人
            Task masterTask = null;
            Task masterSecondTask = null;
            foreach (Task taskObjj in taskList)
            {
                if (taskObjj.ProjectID == PluginRootObj.projectObj.ID)
                {
                    masterTask = taskObjj;
                    break;
                }
            }
            //查找项目负责人兼任
            if (masterTask != null)
            {                
                foreach (Task taskObjj in taskList)
                {
                    if (taskObjj.PersonID == masterTask.PersonID && taskObjj.ProjectID != masterTask.ProjectID)
                    {
                        masterSecondTask = taskObjj;
                        break;
                    }
                }
            }

            personList = new List<PersonObject>();
            int indexx = 0;
            dgvDetail.Rows.Clear();
            foreach (Task taskObj in taskList)
            {
                indexx++;

                PersonObject pObject = new PersonObject(null, null, null, null);
                #region 构造Person汇总对象
                pObject.TaskObj = taskObj;
                pObject.SubjectObj = ConnectionManager.Context.table("Project").where("ID='" + taskObj.ProjectID + "'").select("*").getItem<Project>(new Project());
                if (pObject.SubjectObj == null || string.IsNullOrEmpty(pObject.SubjectObj.ID))
                {
                    continue;
                }
                pObject.PersonObj = ConnectionManager.Context.table("Person").where("ID='" + taskObj.PersonID + "'").select("*").getItem<Person>(new Person());
                if (pObject.PersonObj == null || string.IsNullOrEmpty(pObject.PersonObj.ID))
                {
                    continue;
                }
                pObject.UnitObj = ConnectionManager.Context.table("Unit").where("ID='" + pObject.PersonObj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                if (pObject.UnitObj == null || string.IsNullOrEmpty(pObject.UnitObj.ID))
                {
                    continue;
                }
                #endregion

                List<object> cells = new List<object>();
                cells.Add(indexx + "");
                cells.Add(pObject.PersonObj.Name);
                cells.Add(pObject.PersonObj.Sex);
                cells.Add(pObject.PersonObj.Job);
                cells.Add(pObject.PersonObj.Specialty);
                cells.Add(pObject.UnitObj.UnitName);
                cells.Add(pObject.TaskObj.TotalTime);
                cells.Add(pObject.TaskObj.Content);
                cells.Add(pObject.PersonObj.IDCard);

                string roleName = string.Empty;
                if (pObject.SubjectObj.ID == PluginRootObj.projectObj.ID)
                {
                    if (masterSecondTask != null)
                    {
                        indexx--;
                        continue;
                    }

                    roleName = "项目" + pObject.TaskObj.Role;
                }
                else
                {
                    if (masterSecondTask != null && masterSecondTask.PersonID == pObject.PersonObj.ID)
                    {
                        roleName = "项目负责人兼" + pObject.SubjectObj.Name + pObject.TaskObj.Role;
                    }
                    else
                    {
                        roleName = pObject.SubjectObj.Name + pObject.TaskObj.Role;
                    }
                }
                cells.Add(roleName);                
                
                cells.Add("向上");
                cells.Add("向下");
                cells.Add("编辑");

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = pObject;

                personList.Add(pObject);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 3)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        PersonObject task = (PersonObject)dgvDetail.Rows[e.RowIndex].Tag;
                        MoveToDown(e.RowIndex, task);
                    }
                }

                if (e.ColumnIndex == dgvDetail.Columns.Count - 4)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        PersonObject task = (PersonObject)dgvDetail.Rows[e.RowIndex].Tag;
                        MoveToUp(e.RowIndex, task);
                    }
                }

                if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        PersonObject task = (PersonObject)dgvDetail.Rows[e.RowIndex].Tag;

                        FrmEditWorkerInfo form = new FrmEditWorkerInfo(task);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            PluginRootObj.refreshEditors();
                        }
                    }
                }

                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        PersonObject task = (PersonObject)dgvDetail.Rows[e.RowIndex].Tag;
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ConnectionManager.Context.table("Task").where("ID='" + task.TaskObj.ID + "'").delete();
                            PluginRootObj.refreshEditors();
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
        private void MoveToUp(int rowIndex, PersonObject task)
        {
            if (personList != null)
            {
                int taskIndex = personList.IndexOf(task);
                if (taskIndex >= 1)
                {
                    personList.Remove(task);
                    personList.Insert(taskIndex - 1, task);

                    int ri = 0;
                    foreach (PersonObject t in personList)
                    {
                        t.TaskObj.DisplayOrder = ri;
                        ri++;

                        t.TaskObj.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + t.TaskObj.ID + "'").update();
                    }

                    RefreshView();

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
        private void MoveToDown(int rowIndex, PersonObject task)
        {
            if (personList != null)
            {
                int taskIndex = personList.IndexOf(task);
                if (taskIndex <= personList.Count - 2)
                {
                    personList.Remove(task);
                    personList.Insert(taskIndex + 1, task);

                    int ri = 0;
                    foreach (PersonObject t in personList)
                    {
                        t.TaskObj.DisplayOrder = ri;
                        ri++;

                        t.TaskObj.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + t.TaskObj.ID + "'").update();
                    }

                    RefreshView();

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
                PersonObject task = (PersonObject)dgvDetail.Rows[e.RowIndex].Tag;
                FrmEditWorkerInfo form = new FrmEditWorkerInfo(task);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    PluginRootObj.refreshEditors();
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