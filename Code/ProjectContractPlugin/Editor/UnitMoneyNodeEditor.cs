using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectContractPlugin.DB.Entitys;
using ProjectContractPlugin.DB;
using PublicReporterLib;
using ProjectContractPlugin.Forms;

namespace ProjectContractPlugin.Editor
{
    public partial class UnitMoneyNodeEditor : AbstractEditorPlugin.BaseEditor
    {
        public UnitMoneyNodeEditor()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //显示编辑窗体
            FrmAddOrUpdateUnitMoneyYear form = new FrmAddOrUpdateUnitMoneyYear(string.Empty);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //刷新列表
                refreshView();
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
                        ConnectionManager.Context.table("DanWeiJingFeiNianDuBiao").where("DanWeiMing='" + dgvRow.Tag + "'").delete();
                    }

                    //刷新
                    refreshView();
                }
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
                    FrmAddOrUpdateUnitMoneyYear form = new FrmAddOrUpdateUnitMoneyYear(dgvDetail.Rows[e.RowIndex].Tag != null ? dgvDetail.Rows[e.RowIndex].Tag.ToString() : string.Empty);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //刷新列表
                        refreshView();
                    }
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    //删除
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //删除数据
                        ConnectionManager.Context.table("DanWeiJingFeiNianDuBiao").where("DanWeiMing='" + dgvDetail.Rows[e.RowIndex].Tag + "'").delete();
                        //刷新
                        refreshView();
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
                FrmAddOrUpdateUnitMoneyYear form = new FrmAddOrUpdateUnitMoneyYear(dgvDetail.Rows[e.RowIndex].Tag != null ? dgvDetail.Rows[e.RowIndex].Tag.ToString() : string.Empty);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //刷新列表
                    refreshView();
                }
            }
        }

        public override void refreshView()
        {
            base.refreshView();

            //读取单位经费数据并进行分类
            CustomDictionary<string, List<DanWeiJingFeiNianDuBiao>> unitDict = new CustomDictionary<string, List<DanWeiJingFeiNianDuBiao>>();
            List<DanWeiJingFeiNianDuBiao> list = ConnectionManager.Context.table("DanWeiJingFeiNianDuBiao").select("*").getList<DanWeiJingFeiNianDuBiao>(new DanWeiJingFeiNianDuBiao());
            foreach (DanWeiJingFeiNianDuBiao table in list)
            {
                if (unitDict.ContainsKey(table.DanWeiMing))
                {
                    unitDict[table.DanWeiMing].Add(table);
                }
                else
                {
                    unitDict[table.DanWeiMing] = new List<DanWeiJingFeiNianDuBiao>();
                    unitDict[table.DanWeiMing].Add(table);
                }
            }

            //显示列表
            dgvDetail.Rows.Clear();
            foreach (KeyValuePair<string, List<DanWeiJingFeiNianDuBiao>> kvp in unitDict)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DanWeiJingFeiNianDuBiao money in kvp.Value)
                {
                    sb.Append(money.NianDu).Append("年度：").Append(money.JingFei).AppendLine("万元");
                }

                List<object> cells = new List<object>();
                cells.Add(kvp.Key);
                cells.Add(sb.ToString());

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = kvp.Key;
            }
        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }
    }
}