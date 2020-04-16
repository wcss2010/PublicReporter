using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectContractPlugin.DB;
using ProjectContractPlugin.DB.Entitys;
using ProjectContractPlugin.Forms;

namespace ProjectContractPlugin.Editor
{
    public partial class SubjectMoneyNodeEditor : AbstractEditorPlugin.BaseEditor
    {
        Dictionary<string, string> dictMoneys = new Dictionary<string, string>();
        private List<BoFuBiao> MSList;
        public SubjectMoneyNodeEditor()
        {
            InitializeComponent();
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    //编辑

                    //显示编辑窗体
                    FrmAddOrUpdateSubjectMoneyUnit form = new FrmAddOrUpdateSubjectMoneyUnit(((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao);
                    if (form.ShowDialog() == DialogResult.OK)
                        //刷新列表
                        refreshView();
                }
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                //编辑

                //显示编辑窗体
                FrmAddOrUpdateSubjectMoneyUnit form = new FrmAddOrUpdateSubjectMoneyUnit(((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao);
                form.ShowDialog();

                //刷新列表
                refreshView();
            }
        }

        public override void refreshView()
        {
            base.refreshView();

            MSList = ProjectContractPlugin.DB.ConnectionManager.Context.table("BoFuBiao").select("*").getList<BoFuBiao>(new BoFuBiao());
            MSList = MSList.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            int index = 0;
            foreach (BoFuBiao data in MSList)
            {
                index++;
                dictMoneys[data.BianHao] = "节点" + index + "(" + data.BoFuTiaoJian + ")";
            }

            dgvDetail.Rows.Clear();
            List<KeTiBiao> subjectList = ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());
            foreach (KeTiBiao subject in subjectList)
            {
                //生成年度经费字符
                List<KeTiJieDianJingFeiBiao> moneyList = ConnectionManager.Context.table("KeTiJieDianJingFeiBiao").where("KeTiBianHao='" + subject.BianHao + "'").select("*").getList<KeTiJieDianJingFeiBiao>(new KeTiJieDianJingFeiBiao());
                StringBuilder sb = new StringBuilder();
                foreach (KeTiJieDianJingFeiBiao money in moneyList)
                {
                    string nodeStr = string.Empty;
                    if (dictMoneys.ContainsKey(money.BoFuBianHao))
                    {
                        nodeStr = dictMoneys[money.BoFuBianHao];
                        sb.Append(nodeStr).Append("：").Append(money.JingFei).AppendLine("万元");
                    }
                }

                List<object> cells = new List<object>();
                cells.Add(subject.KeTiMingCheng);
                cells.Add(sb.ToString());

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = subject;
            }
        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }
    }
}