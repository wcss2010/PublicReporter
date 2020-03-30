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
    public partial class MoneySendRuleEditor : AbstractEditorPlugin.BaseEditor
    {
        List<BoFuBiao> list = new List<BoFuBiao>();
        public MoneySendRuleEditor()
        {
            InitializeComponent();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            dgvDetail.Rows.Clear();
            list = ProjectContractPlugin.DB.ConnectionManager.Context.table("BoFuBiao").select("*").getList<BoFuBiao>(new BoFuBiao());
            list = list.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            int index = 0;
            foreach (BoFuBiao data in list)
            {
                index++;
                List<object> cells = new List<object>();
                cells.Add(index.ToString());
                cells.Add(data.BoFuTiaoJian);
                cells.Add(data.YuJiShiJian.ToString("yyyy年MM月dd日"));
                cells.Add(data.JingFeiJinQian);
                cells.Add(data.BeiZhu);
                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = data;
            }

        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    //编辑

                    //显示编辑窗体
                    FrmAddOrUpdateMoneySendRule form = new FrmAddOrUpdateMoneySendRule((BoFuBiao)dgvDetail.Rows[e.RowIndex].Tag);
                    if (form.ShowDialog() == DialogResult.OK)
                        //刷新列表
                        RefreshView();
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    //删除
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //删除数据
                        ConnectionManager.Context.table("BoFuBiao").where("BianHao='" + ((BoFuBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao + "'").delete();

                        //刷新
                        RefreshView();
                    }
                }
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                //编辑

                //显示编辑窗体
                FrmAddOrUpdateMoneySendRule form = new FrmAddOrUpdateMoneySendRule((BoFuBiao)dgvDetail.Rows[e.RowIndex].Tag);
                form.ShowDialog();

                //刷新列表
                RefreshView();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //显示编辑窗体
            FrmAddOrUpdateMoneySendRule form = new FrmAddOrUpdateMoneySendRule(null, list.Count);
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
                        ConnectionManager.Context.table("BoFuBiao").where("BianHao='" + ((BoFuBiao)dgvRow.Tag).BianHao + "'").delete();
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
                double statusNum = 0;
                try
                {
                    if (dgvDetail.SelectedRows[0].Index + 1 == dgvDetail.Rows.Count)
                    {
                        statusNum = ((BoFuBiao)dgvDetail.SelectedRows[0].Tag).ZhuangTai + 1;
                    }
                    else
                    {
                        double a = ((BoFuBiao)dgvDetail.SelectedRows[0].Tag).ZhuangTai;
                        double b = ((BoFuBiao)dgvDetail.Rows[dgvDetail.SelectedRows[0].Index + 1].Tag).ZhuangTai;

                        statusNum = (a + b) / 2;
                    }
                }
                catch (Exception ex) { }

                //显示编辑窗体
                FrmAddOrUpdateMoneySendRule form = new FrmAddOrUpdateMoneySendRule(null, statusNum);
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

        public override bool IsInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }
    }
}
