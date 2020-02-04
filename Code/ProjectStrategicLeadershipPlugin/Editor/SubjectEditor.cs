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
    public partial class SubjectEditor : BaseEditor
    {
        private List<Subjects> subjectList;
        public SubjectEditor()
        {
            InitializeComponent();
        }

        public void buildSubjectReadmPages()
        {
            //删除除第一页之外其它标签页
            List<TabPage> deletePageList = new List<TabPage>();
            foreach (TabPage kp in kvKetiTabs.TabPages)
            {
                if (kp.Tag != null && kp.Tag.ToString() == "KeTiDynamic")
                {
                    deletePageList.Add(kp);
                }
            }
            foreach (TabPage kpp in deletePageList)
            {
                kvKetiTabs.TabPages.Remove(kpp);
            }

            if (subjectList != null)
            {
                foreach (Subjects proj in subjectList)
                {
                    buildOneSubjectReadmePage(proj.ID, proj.SubjectName);
                }
            }
        }

        private TabPage buildOneSubjectReadmePage(string ketiID, string ketiName)
        {
            TabPage kp = new TabPage();
            kp.Name = ketiID;
            kp.Text = ketiName;
            kp.Tag = "KeTiDynamic";

            SubjectDetailEditor rtfTextEditor = new SubjectDetailEditor();
            rtfTextEditor.TitleLabelText = "研究内容(" + ketiName + ")详细内容";
            rtfTextEditor.Dock = DockStyle.Fill;
            rtfTextEditor.BackColor = Color.White;

            rtfTextEditor.Name = ketiName;
            rtfTextEditor.refreshView();

            kp.Controls.Add(rtfTextEditor);

            //插入到课题关系之后
            kvKetiTabs.TabPages.Add(kp);
            return kp;
        }

        public override void clearView()
        {
            base.clearView();

            //删除除第一页之外其它标签页
            List<TabPage> deletePageList = new List<TabPage>();
            foreach (TabPage kp in kvKetiTabs.TabPages)
            {
                if (kp.Tag != null && kp.Tag.ToString() == "KeTiDynamic")
                {
                    deletePageList.Add(kp);
                }
            }
            foreach (TabPage kpp in deletePageList)
            {
                kvKetiTabs.TabPages.Remove(kpp);
            }

            //清空数据
            dgvDetail.Rows.Clear();
        }

        public override void refreshView()
        {
            base.refreshView();

            subjectList = ConnectionManager.Context.table("Subjects").select("*").getList<Subjects>(new Subjects());

            int indexx = 0;
            dgvDetail.Rows.Clear();
            foreach (Subjects subject in subjectList)
            {
                indexx++;
                List<object> cells = new List<object>();
                cells.Add(indexx + "");
                cells.Add(subject.SubjectName);
                cells.Add(subject.UnitName);
                cells.Add(subject.UnitContact);
                cells.Add(subject.UnitContactPhone);
                cells.Add(subject.UnitAddress);

                cells.Add("填报研究内容");

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = subject;
            }

            //创建详细信息页
            buildSubjectReadmPages();
        }

        public override void onSaveEvent(ref bool result)
        {
            base.onSaveEvent(ref result);
        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddOrUpdateSubject form = new FrmAddOrUpdateSubject(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                refreshView();
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectStrategicLeadershipPlugin.Resource.w5;
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 2, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectStrategicLeadershipPlugin.Resource.DELETE_28;
        }
    }
}