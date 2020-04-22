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
        CustomDictionary<string, string> dictMoneys = new CustomDictionary<string, string>();
        private List<BoFuBiao> MSList;

        public UnitMoneyNodeEditor()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            double statusNum = 0;
            if (dgvDetail.SelectedRows.Count == 1)
            {
                statusNum = dgvDetail.SelectedRows[0].Index + 1;
            }
            else
            {
                statusNum = 1;
            }

            //显示编辑窗体
            FrmAddOrUpdateUnitMoneyNode form = new FrmAddOrUpdateUnitMoneyNode(string.Empty, statusNum);
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
                        ConnectionManager.Context.table("DanWeiJieDianJingFeiBiao").where("DanWeiMingCheng='" + dgvRow.Tag + "'").delete();
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
                    FrmAddOrUpdateUnitMoneyNode form = new FrmAddOrUpdateUnitMoneyNode(dgvDetail.Rows[e.RowIndex].Tag != null ? dgvDetail.Rows[e.RowIndex].Tag.ToString() : string.Empty, -1);
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
                        ConnectionManager.Context.table("DanWeiJieDianJingFeiBiao").where("DanWeiMingCheng='" + dgvDetail.Rows[e.RowIndex].Tag + "'").delete();

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
                FrmAddOrUpdateUnitMoneyNode form = new FrmAddOrUpdateUnitMoneyNode(dgvDetail.Rows[e.RowIndex].Tag != null ? dgvDetail.Rows[e.RowIndex].Tag.ToString() : string.Empty, -1);
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

            dictMoneys = new CustomDictionary<string, string>();
            MSList = ProjectContractPlugin.DB.ConnectionManager.Context.table("BoFuBiao").select("*").getList<BoFuBiao>(new BoFuBiao());
            MSList = MSList.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            int index = 0;
            foreach (BoFuBiao data in MSList)
            {
                index++;
                //dictMoneys[data.BianHao] = "节点" + index + "(" + data.BoFuTiaoJian + ")";
                dictMoneys[data.BianHao] = data.BoFuTiaoJian;
            }

            //读取单位经费数据并进行分类
            CustomDictionary<string, List<DanWeiJieDianJingFeiBiao>> unitDict = new CustomDictionary<string, List<DanWeiJieDianJingFeiBiao>>();
            List<DanWeiJieDianJingFeiBiao> list = ConnectionManager.Context.table("DanWeiJieDianJingFeiBiao").select("*").getList<DanWeiJieDianJingFeiBiao>(new DanWeiJieDianJingFeiBiao());
            list = list.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();

            foreach (DanWeiJieDianJingFeiBiao table in list)
            {
                if (unitDict.ContainsKey(table.DanWeiMingCheng))
                {
                    unitDict[table.DanWeiMingCheng].Add(table);
                }
                else
                {
                    unitDict[table.DanWeiMingCheng] = new List<DanWeiJieDianJingFeiBiao>();
                    unitDict[table.DanWeiMingCheng].Add(table);
                }
            }

            //显示列表
            dgvDetail.Rows.Clear();
            foreach (KeyValuePair<string, List<DanWeiJieDianJingFeiBiao>> kvp in unitDict)
            {
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, string> kvpps in dictMoneys)
                {
                    bool isNeedAdd = true;

                    foreach (DanWeiJieDianJingFeiBiao money in kvp.Value)
                    {
                        string nodeStr = string.Empty;
                        if (kvpps.Key == money.BoFuBianHao)
                        {
                            isNeedAdd = false;

                            nodeStr = dictMoneys[money.BoFuBianHao];
                            sb.Append(nodeStr).Append("：").Append(money.JingFei).AppendLine("万元");
                        }
                    }

                    if (isNeedAdd)
                    {
                        sb.Append(kvpps.Value).Append("：").Append(0).AppendLine("万元");
                    }
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