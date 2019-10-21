using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectProtocolPlugin.DB.Entitys;
using ProjectProtocolPlugin.Forms;
using ProjectProtocolPlugin.DB;
using PublicReporterLib;
using System.IO;

namespace ProjectProtocolPlugin.Editor
{
    public partial class WorkerEditor : BaseEditor
    {
        List<RenYuanBiao> list = new List<RenYuanBiao>();
        List<KeTiBiao> ktList = new List<KeTiBiao>();
        public WorkerEditor()
        {
            InitializeComponent();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            //查询人员列表
            list = ProjectProtocolPlugin.DB.ConnectionManager.Context.table("RenYuanBiao").select("*").getList<RenYuanBiao>(new RenYuanBiao());
            list = list.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();

            dgvDetail.Rows.Clear();
            int index = 0;
            foreach (RenYuanBiao data in list)
            {
                index++;
                List<object> cells = new List<object>();
                cells.Add(index.ToString());
                cells.Add(data.XingMing);
                cells.Add(data.XingBie);
                cells.Add(data.ZhiCheng);
                cells.Add(data.ZhuanYe);
                cells.Add(data.GongZuoDanWei);
                cells.Add(data.MeiNianTouRuShiJian);
                cells.Add(data.RenWuFenGong);
                cells.Add(data.ShenFenZhengHao);

                if (data.ShiXiangMuFuZeRen == "rbIsOnlyProject")
                {
                    cells.Add("项目负责人");
                }
                else
                {
                    cells.Add(data.ZhiWu);
                }

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = data;
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //显示编辑窗体
            FrmAddOrUpdateWorker form = new FrmAddOrUpdateWorker(null, ktList, list.Count);
            if (form.ShowDialog() == DialogResult.OK)
                //刷新列表
                RefreshView();
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    //编辑

                    //显示编辑窗体
                    FrmAddOrUpdateWorker form = new FrmAddOrUpdateWorker((RenYuanBiao)dgvDetail.Rows[e.RowIndex].Tag, ktList);
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
                        ConnectionManager.Context.table("RenYuanBiao").where("BianHao='" + ((RenYuanBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao + "'").delete();

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
                FrmAddOrUpdateWorker form = new FrmAddOrUpdateWorker((RenYuanBiao)dgvDetail.Rows[e.RowIndex].Tag, ktList);
                if (form.ShowDialog() == DialogResult.OK)
                    //刷新列表
                    RefreshView();
            }

        }

        public override bool IsInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
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
                        statusNum = ((RenYuanBiao)dgvDetail.SelectedRows[0].Tag).ZhuangTai + 1;
                    }
                    else
                    {
                        double a = ((RenYuanBiao)dgvDetail.SelectedRows[0].Tag).ZhuangTai;
                        double b = ((RenYuanBiao)dgvDetail.Rows[dgvDetail.SelectedRows[0].Index + 1].Tag).ZhuangTai;

                        statusNum = (a + b) / 2;
                    }
                }
                catch (Exception ex) { }

                //显示编辑窗体
                FrmAddOrUpdateWorker form = new FrmAddOrUpdateWorker(null, ktList, statusNum);
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

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count >= 1)
            {
                if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //删除数据
                    foreach (DataGridViewRow dgvRow in dgvDetail.SelectedRows)
                    {
                        ConnectionManager.Context.table("RenYuanBiao").where("BianHao='" + ((RenYuanBiao)dgvRow.Tag).BianHao + "'").delete();
                    }

                    //刷新
                    RefreshView();
                }
            }
        }
    }
}