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
    public partial class FrmAddOrUpdateUnitMoneyYear : AbstractEditorPlugin.BaseForm
    {
        private string lastUnit;
        public FrmAddOrUpdateUnitMoneyYear(string unitName)
        {
            InitializeComponent();

            try
            {
                int start = ((JiBenXinXiBiao)PluginRootObj.projectObj).HeTongKaiShiShiJian.Year;
                int end = ((JiBenXinXiBiao)PluginRootObj.projectObj).HeTongJieShuShiJian.Year;
                for (int kkk = start; kkk <= end; kkk++)
                {
                    ((DataGridViewComboBoxColumn)dgvDetail.Columns[0]).Items.Add(kkk.ToString());
                }
            }
            catch (Exception ex) { }

            lastUnit = unitName;
            txtUnitName.Text = unitName;

            List<DanWeiJingFeiNianDuBiao> list = ConnectionManager.Context.table("DanWeiJingFeiNianDuBiao").where("DanWeiMing = '" + unitName + "'").select("*").getList<DanWeiJingFeiNianDuBiao>(new DanWeiJingFeiNianDuBiao());
            if (list != null && list.Count >= 1)
            {
                foreach (DanWeiJingFeiNianDuBiao obj in list)
                {
                    List<object> cells = new List<object>();
                    if (((JiBenXinXiBiao)PluginRootObj.projectObj).HeTongJieShuShiJian.Year >= obj.NianDu && obj.NianDu >= ((JiBenXinXiBiao)PluginRootObj.projectObj).HeTongKaiShiShiJian.Year)
                    {
                        cells.Add(obj.NianDu.ToString());
                    }
                    else
                    {
                        cells.Add(((JiBenXinXiBiao)PluginRootObj.projectObj).HeTongKaiShiShiJian.Year.ToString());
                    }
                    cells.Add(obj.JingFei);
                    dgvDetail.Rows.Add(cells.ToArray());
                }
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }

            //删除当前课题的所有年度经费
            ConnectionManager.Context.table("DanWeiJingFeiNianDuBiao").where("DanWeiMing = '" + lastUnit + "'").delete();
            ConnectionManager.Context.table("DanWeiJingFeiNianDuBiao").where("DanWeiMing = '" + txtUnitName.Text + "'").delete();

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

                DanWeiJingFeiNianDuBiao obj = new DanWeiJingFeiNianDuBiao();
                obj.DanWeiMing = txtUnitName.Text;
                obj.NianDu = dgvRow.Cells[0].Value != null ? int.Parse(dgvRow.Cells[0].Value.ToString()) : DateTime.Now.Year;
                obj.JingFei = dgvRow.Cells[1].Value != null ? decimal.Parse(dgvRow.Cells[1].Value.ToString()) : 0;
                obj.ZhuangTai = 0;
                obj.ModifyTime = DateTime.Now;
                obj.copyTo(ConnectionManager.Context.table("DanWeiJingFeiNianDuBiao")).insert();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}