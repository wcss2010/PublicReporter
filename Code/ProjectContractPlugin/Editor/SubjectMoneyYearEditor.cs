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
    public partial class SubjectMoneyYearEditor : AbstractEditorPlugin.BaseEditor
    {
        public SubjectMoneyYearEditor()
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
                    FrmAddOrUpdateSubjectMoneyYear form = new FrmAddOrUpdateSubjectMoneyYear(((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao);
                    if (form.ShowDialog() == DialogResult.OK)
                        //刷新列表
                        RefreshView();
                }
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                //编辑

                //显示编辑窗体
                FrmAddOrUpdateSubjectMoneyYear form = new FrmAddOrUpdateSubjectMoneyYear(((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao);
                form.ShowDialog();

                //刷新列表
                RefreshView();
            }
        }

        public override void RefreshView()
        {
            base.RefreshView();

            dgvDetail.Rows.Clear();
            List<KeTiBiao> subjectList = ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());
            foreach (KeTiBiao subject in subjectList)
            {
                //生成年度经费字符
                List<KeTiJingFeiNianDuBiao> moneyList = ConnectionManager.Context.table("KeTiJingFeiNianDuBiao").where("KeTiBianHao='" + subject.BianHao + "'").select("*").getList<KeTiJingFeiNianDuBiao>(new KeTiJingFeiNianDuBiao());
                StringBuilder sb = new StringBuilder();
                foreach (KeTiJingFeiNianDuBiao money in moneyList)
                {
                    sb.Append(money.NianDu).Append("年度：").Append(money.JingFei).AppendLine("万元");
                }

                List<object> cells = new List<object>();
                cells.Add(subject.KeTiMingCheng);
                cells.Add(sb.ToString());

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = subject;
            }
        }

        public override bool IsInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }
    }
}