using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicReporterLib.Utility;
using ProjectSocialFundPlugin.DB;
using ProjectSocialFundPlugin.DB.Entitys;
using Newtonsoft.Json;
using ProjectSocialFundPlugin.Forms;
using AbstractEditorPlugin;
using AbstractEditorPlugin.Controls;
using AbstractEditorPlugin.Forms;
using AbstractEditorPlugin.Utility;
using System.IO;
using System.Diagnostics;

namespace ProjectSocialFundPlugin.Editor
{
    public partial class WorkerEditor : BaseEditor
    {
        private List<Persons> list;
        public WorkerEditor()
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

            ////查询研究内容列表
            //subjectList = ConnectionManager.Context.table("Subjects").select("*").getList<Subjects>(new Subjects());

            ////生成研究内容X字典
            //int kindex = 0;
            //Dictionary<string, string> ktDict = new Dictionary<string, string>();
            //foreach (Subjects ktb in subjectList)
            //{
            //    kindex++;
            //    ktDict[ktb.ID] = "研究内容" + kindex;
            //}

            ////查询人员列表
            //list = ConnectionManager.Context.table("Persons").select("*").getList<Persons>(new Persons());

            //dgvDetail.Rows.Clear();
            //int index = 0;
            //foreach (Persons data in list)
            //{
            //    index++;
            //    List<object> cells = new List<object>();
            //    cells.Add(index.ToString());
            //    cells.Add(data.Name);
            //    cells.Add(data.Sex);
            //    cells.Add(data.Job);
            //    cells.Add(data.Specialty);
            //    cells.Add(data.UnitName);
            //    cells.Add(data.TimeForSubject);
            //    cells.Add(data.TaskContent);
            //    cells.Add(data.IDCard);

            //    if (data.RoleType == FrmAddOrUpdateWorker.isOnlyProject)
            //    {
            //        cells.Add("项目负责人");
            //    }
            //    else
            //    {
            //        cells.Add((data.RoleType == FrmAddOrUpdateWorker.isProjectAndSubject ? "项目负责人兼" : "") + ((ktDict.ContainsKey(data.SubjectID) ? ktDict[data.SubjectID] : string.Empty) + data.RoleName));
            //    }

            //    int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
            //    dgvDetail.Rows[rowIndex].Tag = data;
            //}
        }

        public override void onSaveEvent(ref bool result)
        {
            base.onSaveEvent(ref result);
        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            //{
            //    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
            //    {
            //        //编辑

            //        //显示编辑窗体
            //        FrmAddOrUpdateWorker form = new FrmAddOrUpdateWorker((Persons)dgvDetail.Rows[e.RowIndex].Tag, subjectList);
            //        if (form.ShowDialog() == DialogResult.OK)
            //        {
            //            //刷新列表
            //            PluginRootObj.refreshEditors();
            //        }
            //    }
            //    else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
            //    {
            //        //删除
            //        if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            //删除数据
            //            ConnectionManager.Context.table("Persons").where("ID='" + ((Persons)dgvDetail.Rows[e.RowIndex].Tag).ID + "'").delete();

            //            //刷新列表
            //            PluginRootObj.refreshEditors(); ;
            //        }
            //    }
            //}
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectSocialFundPlugin.Resource.Question_16;
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 2, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectSocialFundPlugin.Resource.DELETE_28;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ////显示编辑窗体
            //FrmAddOrUpdateWorker form = new FrmAddOrUpdateWorker(null, subjectList);
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    //刷新列表
            //    PluginRootObj.refreshEditors();
            //}
        }
    }
}