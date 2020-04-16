using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectContractPlugin.DB.Entitys;
using ProjectContractPlugin.Forms;
using ProjectContractPlugin.DB;
using PublicReporterLib;
using System.IO;
using System.Text;
using AbstractEditorPlugin;

namespace ProjectContractPlugin.Editor
{
    public partial class SubjectEditor : AbstractEditorPlugin.BaseEditor
    {
        public List<KeTiBiao> list = new List<KeTiBiao>();
        public SubjectEditor()
        {
            InitializeComponent();
        }

        public override void refreshView()
        {
            base.refreshView();

            dgvDetail.Rows.Clear();
            list = ProjectContractPlugin.DB.ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());
            list = list.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            int index = 0;
            foreach (KeTiBiao data in list)
            {
                index++;
                List<object> cells = new List<object>();
                cells.Add(index.ToString());
                cells.Add(data.KeTiMingCheng);
                cells.Add(data.KeTiBaoMiDengJi);
                cells.Add(data.KeTiFuZeDanWei);
                cells.Add(data.KeTiSuoShuBuMen);
                cells.Add(getAddress(data.KeTiSuoShuDiDian));
                cells.Add(data.KeTiYanJiuMuBiao);
                cells.Add(data.KeTiYanJiuNeiRong);
                cells.Add(getWorkTasks(data));
                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = data;
            }
        }

        private string getWorkTasks(KeTiBiao data)
        {
            StringBuilder sb = new StringBuilder();
            List<RenWuBiao> items = ConnectionManager.Context.table("RenWuBiao").where("KeTiBianHao='" + data.BianHao + "'").select("*").getList<RenWuBiao>(new RenWuBiao());
            foreach (RenWuBiao rwb in items)
            {
                sb.Append(rwb.DanWeiMing).Append(":").Append(rwb.RenWuFenGong).Append("\n");
            }
            return sb.ToString();
        }

        private object getAddress(string temp)
        {
            string result = temp;
            if (temp != null && temp.Contains("%|||%"))
            {
                string[] tt = temp.Split(new string[] { "%|||%" }, StringSplitOptions.None);
                if (tt != null && tt.Length >= 3)
                {
                    if (!tt[1].Contains(tt[0]))
                    {
                        result = tt[0] + tt[1] + tt[2];
                    }
                    else
                    {
                        result = tt[1] + tt[2];
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            //显示编辑窗体
            FrmAddOrUpdateSubject form = new FrmAddOrUpdateSubject(null, list.Count);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //刷新列表
                refreshView();

                //刷新其它页面
                refreshOtherView();
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
                        ConnectionManager.Context.table("KeTiBiao").where("BianHao='" + ((KeTiBiao)dgvRow.Tag).BianHao + "'").delete();
                        ConnectionManager.Context.table("KeTiYuSuanBiao").where("KeTiBianHao='" + ((KeTiBiao)dgvRow.Tag).BianHao + "'").delete();
                        ConnectionManager.Context.table("KeTiJingFeiNianDuBiao").where("KeTiBianHao='" + ((KeTiBiao)dgvRow.Tag).BianHao + "'").delete();
                    }

                    //刷新列表
                    refreshView();

                    //刷新其它页面
                    refreshOtherView();
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
                        statusNum = ((KeTiBiao)dgvDetail.SelectedRows[0].Tag).ZhuangTai + 1;
                    }
                    else
                    {
                        double a = ((KeTiBiao)dgvDetail.SelectedRows[0].Tag).ZhuangTai;
                        double b = ((KeTiBiao)dgvDetail.Rows[dgvDetail.SelectedRows[0].Index + 1].Tag).ZhuangTai;

                        statusNum = (a + b) / 2;
                    }
                }
                catch (Exception ex) { }

                //显示编辑窗体
                FrmAddOrUpdateSubject form = new FrmAddOrUpdateSubject(null, statusNum);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //刷新列表
                    refreshView();

                    //刷新其它页面
                    refreshOtherView();
                }
            }
            else
            {
                MessageBox.Show("请选中需要一条数据，新数据将在其后插入");
                return;
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
                    FrmAddOrUpdateSubject form = new FrmAddOrUpdateSubject((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //刷新列表
                        refreshView();

                        //刷新其它页面
                        refreshOtherView();
                    }
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    //删除
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //删除数据                        
                        ConnectionManager.Context.table("KeTiBiao").where("BianHao='" + ((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao + "'").delete();
                        ConnectionManager.Context.table("KeTiYuSuanBiao").where("KeTiBianHao='" + ((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao + "'").delete();
                        ConnectionManager.Context.table("KeTiJingFeiNianDuBiao").where("KeTiBianHao='" + ((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao + "'").delete();

                        //刷新列表
                        refreshView();

                        //刷新其它页面
                        refreshOtherView();
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
                FrmAddOrUpdateSubject form = new FrmAddOrUpdateSubject((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //刷新列表
                    refreshView();

                    //刷新其它页面
                    refreshOtherView();
                }
            }
        }

        public void refreshOtherView()
        {
            foreach (BaseEditor be in PluginRootObj.editorMap.Values)
            {
                if (be is SubjectMoneyYearEditor)
                {
                    ((SubjectMoneyYearEditor)be).refreshView();
                }
                else if (be is SubjectMoneyEditor)
                {
                    ((SubjectMoneyEditor)be).refreshView();
                }
            }
        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }
    }
}