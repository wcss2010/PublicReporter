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
                PluginRootObj.refreshEditors();
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && dgvDetail.Rows.Count > e.RowIndex && e.RowIndex >= 0)
            {
                Subjects kett = ((Subjects)dgvDetail.Rows[e.RowIndex].Tag);
                if (kett != null)
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                    {
                        #region 编辑数据
                        FrmAddOrUpdateSubject form = new FrmAddOrUpdateSubject(kett);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            PluginRootObj.refreshEditors();
                        }
                        #endregion
                    }
                    else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                    {
                        #region 删除数据
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ConnectionManager.Context.table("Subjects").where("ID='" + kett.ID + "'").delete();
                            ConnectionManager.Context.table("Steps").where("SubjectID='" + kett.ID + "'").delete();
                            ConnectionManager.Context.table("Persons").where("SubjectID='" + kett.ID + "'").delete();

                            PluginRootObj.refreshEditors();
                        }
                        #endregion
                    }
                    else if (e.ColumnIndex == dgvDetail.Columns.Count - 3)
                    {
                        #region 切换到详细页
                        buildOneSubjectDetailPageWithSubjectRow(e.RowIndex);
                        #endregion
                    }
                }
            }
        }

        private void buildOneSubjectDetailPageWithSubjectRow(int rowIndex)
        {
            if (dgvDetail.Rows[rowIndex].Cells[1].Value == null)
            {
                return;
            }

            string ketiName = dgvDetail.Rows[rowIndex].Cells[1].Value.ToString();
            string ketiID = string.Empty;
            Subjects ketiProj = (Subjects)dgvDetail.Rows[rowIndex].Tag;
            if (ketiProj == null)
            {
                if (dgvDetail.Rows[rowIndex].Cells[0].Tag == null)
                {
                    //需要生成一个课题ID,然后生成标签
                    ketiID = Guid.NewGuid().ToString();

                    //记录一下提前生成的课题ID
                    dgvDetail.Rows[rowIndex].Cells[0].Tag = ketiID;
                }
                else
                {
                    ketiID = dgvDetail.Rows[rowIndex].Cells[0].Tag.ToString();
                }
            }
            else
            {
                //直接重新生成标签就可以
                ketiID = ketiProj.ID;
            }

            //查找是否已存在
            TabPage oldPage = null;
            foreach (TabPage kp in kvKetiTabs.TabPages)
            {
                if (kp.Name == ketiID)
                {
                    oldPage = kp;
                    break;
                }
            }

            if (oldPage == null)
            {
                oldPage = buildOneSubjectReadmePage(ketiID, ketiName);
            }

            kvKetiTabs.SelectedTab = oldPage;
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectStrategicLeadershipPlugin.Resource.Question_16;
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 2, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectStrategicLeadershipPlugin.Resource.DELETE_28;
        }
    }
}