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
    public partial class ProjectWorkerInfoEditor : AbstractEditorPlugin.BaseEditor
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
                PublicReporterLib.PluginLoader.getLocalPluginRoot<NewPluginRoot>().refreshEditors();
            }
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectReporterPlugin.Resource.Question_162;
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 2, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectReporterPlugin.Resource.DELETE_28;
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 3, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectReporterPlugin.Resource.orderEdit;
        }

        public override void clearView()
        {
            base.clearView();

            dgvDetail.Rows.Clear();
        }

        public override void refreshView()
        {
            base.refreshView();

            List<Task> taskList = ConnectionManager.Context.table("Task").where("ProjectID in (select ID from Project where ParentID = '" + ((Project)PluginRootObj.projectObj).ID + "') or ProjectID='" + ((Project)PluginRootObj.projectObj).ID + "'").orderBy("DisplayOrder").select("*").getList<Task>(new Task());

            //查找项目负责人
            Task masterTask = null;
            Task masterSecondTask = null;
            foreach (Task taskObjj in taskList)
            {
                if (taskObjj.ProjectID == ((Project)PluginRootObj.projectObj).ID)
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
                if (pObject.SubjectObj.ID == ((Project)PluginRootObj.projectObj).ID)
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

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = pObject;

                personList.Add(pObject);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    #region 编辑
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        PersonObject task = (PersonObject)dgvDetail.Rows[e.RowIndex].Tag;

                        FrmEditWorkerInfo form = new FrmEditWorkerInfo(task);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            PluginRootObj.refreshEditors();
                        }
                    }
                    #endregion
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    #region 删除
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        PersonObject task = (PersonObject)dgvDetail.Rows[e.RowIndex].Tag;
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ConnectionManager.Context.table("Task").where("ID='" + task.TaskObj.ID + "'").delete();
                            PluginRootObj.refreshEditors();
                        }
                    }
                    #endregion
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 3)
                {
                    PersonObject task = (PersonObject)dgvDetail.Rows[e.RowIndex].Tag;

                    #region 编辑序号
                    FrmEditOrder feo = new FrmEditOrder();
                    feo.OrderNum = task.TaskObj.DisplayOrder != null ? (decimal)task.TaskObj.DisplayOrder.Value : 0;
                    if (feo.ShowDialog() == DialogResult.OK)
                    {
                        //对后面的记录重新排序
                        reorderPersonList(task, (int)feo.OrderNum);

                        //刷新列表
                        PluginRootObj.refreshEditors();
                    }
                    #endregion
                }
            }
        }

        private void reorderPersonList(PersonObject pObj, int newPersonIndex)
        {
            if (pObj.TaskObj != null && pObj.TaskObj.DisplayOrder != newPersonIndex)
            {
                int pIndex = newPersonIndex - 1;

                if (pIndex >= personList.Count - 1)
                {
                    personList.Remove(pObj);
                    personList.Add(pObj);
                }
                else if (pIndex <= 0)
                {
                    personList.Remove(pObj);
                    personList.Insert(0, pObj);
                }
                else
                {
                    personList.Remove(pObj);
                    personList.Insert(pIndex, pObj);
                }

                int rindexx = 0;
                foreach (PersonObject pp in personList)
                {
                    rindexx++;
                    pp.TaskObj.DisplayOrder = rindexx;
                    pp.TaskObj.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + pp.TaskObj.ID + "'").update();
                }
            }
        }
        
        public override bool isInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请输入研究骨干信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }

        private void dgvDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetail.Rows.Count >= 1)
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