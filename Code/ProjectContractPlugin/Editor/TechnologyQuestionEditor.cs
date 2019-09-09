using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectContractPlugin.DB.Entitys;
using ProjectContractPlugin.Forms;
using ProjectContractPlugin.DB;
using PublicReporterLib;
using System.IO;
using System.Linq;

namespace ProjectContractPlugin.Editor
{
    public partial class TechnologyQuestionEditor : BaseEditor
    {
        List<JiShuBiao> list = new List<JiShuBiao>();
        public TechnologyQuestionEditor()
        {
            InitializeComponent();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            dgvDetail.Rows.Clear();
            list = ProjectContractPlugin.DB.ConnectionManager.Context.table("JiShuBiao").select("*").getList<JiShuBiao>(new JiShuBiao());
            list = list.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            int index = 0;
            foreach (JiShuBiao data in list)
            {
                index++;

                List<object> cells = new List<object>();
                cells.Add(index.ToString());
                cells.Add(data.NianDu);
                cells.Add(data.NeiRong);

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = data;
            }

            if (File.Exists(getTxtFilePath()))
            {
                txtContent.Text = File.ReadAllText(getTxtFilePath());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //新增

            //显示编辑窗体
            FrmAddOrUpdateTechnologyQuestion form = new FrmAddOrUpdateTechnologyQuestion(null, list.Count);
            form.ShowDialog();

            //刷新列表
            RefreshView();
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count >= 1)
            {
                if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //删除数据
                    foreach (DataGridViewRow dgvRow in dgvDetail.SelectedRows)
                    {
                        ConnectionManager.Context.table("JiShuBiao").where("BianHao='" + ((JiShuBiao)dgvRow.Tag).BianHao + "'").delete();
                    }

                    //刷新
                    RefreshView();
                }
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    //编辑

                    //显示编辑窗体
                    FrmAddOrUpdateTechnologyQuestion form = new FrmAddOrUpdateTechnologyQuestion((JiShuBiao)dgvDetail.Rows[e.RowIndex].Tag);
                    form.ShowDialog();

                    //刷新列表
                    RefreshView();
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    //删除
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //删除数据
                        ConnectionManager.Context.table("JiShuBiao").where("BianHao='" + ((JiShuBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao + "'").delete();                        

                        //刷新
                        RefreshView();
                    }
                }
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                //编辑

                //显示编辑窗体
                FrmAddOrUpdateTechnologyQuestion form = new FrmAddOrUpdateTechnologyQuestion((JiShuBiao)dgvDetail.Rows[e.RowIndex].Tag);
                form.ShowDialog();

                //刷新列表
                RefreshView();
            }
        }

        private string getTxtFilePath()
        {
            return Path.Combine(((PluginRoot)PluginLoader.CurrentPlugin).filesDir, EditorName + ".txt");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(getTxtFilePath(), txtContent.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count == 1)
            {

                //显示编辑窗体
                FrmAddOrUpdateWorkProgress form = new FrmAddOrUpdateWorkProgress(null, dgvDetail.SelectedRows[0].Index);
                if (form.ShowDialog() == DialogResult.OK)
                    //刷新列表
                    RefreshView();

            }
            else
            {
                MessageBox.Show("请选中需要一条数据，新数据将在其后插入");
                return;
            }
        }
    }
}