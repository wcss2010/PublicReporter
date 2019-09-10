using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectContractPlugin.DB.Entitys;
using ProjectContractPlugin.Forms;
using ProjectContractPlugin.DB;
using PublicReporterLib;
using System.IO;

namespace ProjectContractPlugin.Editor
{
    public partial class WorkProgressEditor : BaseEditor
    {
        List<JinDuBiao> list = new List<JinDuBiao>();
        public WorkProgressEditor()
        {
            InitializeComponent();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            dgvDetail.Rows.Clear();
            list = ProjectContractPlugin.DB.ConnectionManager.Context.table("JinDuBiao").select("*").getList<JinDuBiao>(new JinDuBiao());
            list = list.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            int index = 0;
            foreach (JinDuBiao data in list)
            {
                index++;
                List<object> cells = new List<object>();
                cells.Add(index.ToString());
                cells.Add(data.ShiJian.ToString("yyyy年MM月dd日"));
                cells.Add(data.JieDuanMuBiao);
                cells.Add(data.WanChengNeiRong);
                cells.Add(data.JieDuanChengGuo);
                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = data;
            }

        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            //显示编辑窗体
            FrmAddOrUpdateWorkProgress form = new FrmAddOrUpdateWorkProgress(null, list.Count);
            if (form.ShowDialog() == DialogResult.OK)
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
                        ConnectionManager.Context.table("JinDuBiao").where("BianHao='" + ((JinDuBiao)dgvRow.Tag).BianHao + "'").delete();
                    }

                    //刷新
                    RefreshView();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    //编辑

                    //显示编辑窗体
                    FrmAddOrUpdateWorkProgress form = new FrmAddOrUpdateWorkProgress((JinDuBiao)dgvDetail.Rows[e.RowIndex].Tag);
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
                        ConnectionManager.Context.table("JiShuBiao").where("BianHao='" + ((JinDuBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao + "'").delete();

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
                FrmAddOrUpdateWorkProgress form = new FrmAddOrUpdateWorkProgress((JinDuBiao)dgvDetail.Rows[e.RowIndex].Tag);
                form.ShowDialog();

                //刷新列表
                RefreshView();
            }
        }

        public override bool IsInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }
    }
}
