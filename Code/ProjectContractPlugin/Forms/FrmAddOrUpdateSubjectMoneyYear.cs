using ProjectContractPlugin.DB;
using ProjectContractPlugin.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectContractPlugin.Forms
{
    public partial class FrmAddOrUpdateSubjectMoneyYear : PublicReporterLib.SuperForm
    {
        public FrmAddOrUpdateSubjectMoneyYear(string subjectId)
        {
            InitializeComponent();

            cbxSubjectList.DataSource = ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());
            cbxSubjectList.DisplayMember = "KeTiMingCheng";
            cbxSubjectList.ValueMember = "BianHao";

            cbxSubjectList.SelectedValue = subjectId;

            List<KeTiJingFeiNianDuBiao> list = ConnectionManager.Context.table("KeTiJingFeiNianDuBiao").where("KeTiBianHao = '" + subjectId + "'").select("*").getList<KeTiJingFeiNianDuBiao>(new KeTiJingFeiNianDuBiao());
            if (list != null && list.Count >= 1)
            {
                foreach (KeTiJingFeiNianDuBiao obj in list)
                {
                    List<object> cells = new List<object>();
                    cells.Add(obj.NianDu);
                    cells.Add(obj.JingFei);
                    dgvDetail.Rows.Add(cells.ToArray());
                }
            }
            else
            {
                try
                {
                    int start = PluginRootObj.projectObj.HeTongKaiShiShiJian.Year;
                    int end = PluginRootObj.projectObj.HeTongJieShuShiJian.Year;
                    for (int kkk = start; kkk <= end; kkk++)
                    {
                        dgvDetail.Rows.Add(new object[] { kkk, 0 });
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxSubjectList.SelectedValue == null)
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }

            //删除当前课题的所有年度经费
            ConnectionManager.Context.table("KeTiJingFeiNianDuBiao").where("KeTiBianHao = '" + cbxSubjectList.SelectedValue + "'").delete();

            //填写数据
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                if (dgvRow.Cells[0].Value == null)
                {
                    continue;
                }
                if (dgvRow.Cells[1].Value == null)
                {
                    continue;
                }
                int niandu = 0;
                decimal jingfei = 0;
                if (int.TryParse(dgvRow.Cells[0].Value.ToString(), out niandu) == false)
                {
                    continue;
                }
                if (decimal.TryParse(dgvRow.Cells[1].Value.ToString(), out jingfei) == false)
                {
                    continue;
                }

                KeTiJingFeiNianDuBiao obj = new KeTiJingFeiNianDuBiao();
                obj.KeTiBianHao = cbxSubjectList.SelectedValue.ToString();
                obj.NianDu = dgvRow.Cells[0].Value != null ? int.Parse(dgvRow.Cells[0].Value.ToString()) : DateTime.Now.Year;
                obj.JingFei = dgvRow.Cells[1].Value != null ? decimal.Parse(dgvRow.Cells[1].Value.ToString()) : 0;
                obj.ZhuangTai = 0;
                obj.ModifyTime = DateTime.Now;
                obj.copyTo(ConnectionManager.Context.table("KeTiJingFeiNianDuBiao")).insert();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        dgvDetail.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
    }
}