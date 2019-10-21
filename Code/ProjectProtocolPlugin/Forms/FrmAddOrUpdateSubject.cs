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
    public partial class FrmAddOrUpdateSubject : PublicReporterLib.SuperForm
    {
        public FrmAddOrUpdateSubject(KeTiBiao obj, double count = -1)
        {
            InitializeComponent();

            DataObj = obj;
            Count = count;
            if (DataObj != null)
            {
                txtSubjectName.Text = DataObj.KeTiMingCheng;
                txtWorkDest.Text = DataObj.KeTiYanJiuMuBiao;
                txtWorkContent.Text = DataObj.KeTiYanJiuNeiRong;
                //txtUnitTask.Text = DataObj.KeTiCanJiaDanWeiFenGong;
                txtWorkUnit.Text = DataObj.KeTiFuZeDanWei;
                txtWorkUnitAddress.Text = DataObj.KeTiFuZeDanWeiTongXunDiZhi;
                txtWorkOrg.Text = DataObj.KeTiSuoShuBuMen;
                txtWorkAddress.setAddress(DataObj.KeTiSuoShuDiDian);

                List<RenWuBiao> items = ConnectionManager.Context.table("RenWuBiao").where("KeTiBianHao='" + DataObj.BianHao + "'").select("*").getList<RenWuBiao>(new RenWuBiao());
                dgvDetail.Rows.Clear();
                foreach (RenWuBiao rwb in items)
                {
                    List<object> cells = new List<object>();
                    cells.Add(rwb.DanWeiMing);
                    cells.Add(rwb.RenWuFenGong);
                    dgvDetail.Rows.Add(cells.ToArray());
                }
            }
            else
            {
                DataObj = new KeTiBiao();
            }
        }

        public KeTiBiao DataObj { get; set; }
        public double Count { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSubjectName.Text)
                || String.IsNullOrEmpty(txtWorkContent.Text)
                //|| String.IsNullOrEmpty(txtUnitTask.Text)
                ||String.IsNullOrEmpty(txtWorkDest.Text)
                || String.IsNullOrEmpty(txtWorkUnit.Text)
                || String.IsNullOrEmpty(txtWorkUnitAddress.Text)
                || String.IsNullOrEmpty(txtWorkOrg.Text)
                || String.IsNullOrEmpty(txtWorkAddress.getAddress()))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }

            DataObj.KeTiMingCheng = txtSubjectName.Text;
            DataObj.KeTiFuZeDanWei = txtWorkUnit.Text;
            DataObj.KeTiFuZeDanWeiTongXunDiZhi = txtWorkUnitAddress.Text;
            DataObj.KeTiSuoShuBuMen = txtWorkOrg.Text;
            DataObj.KeTiSuoShuDiDian = txtWorkAddress.getAddress();
            DataObj.KeTiYanJiuMuBiao = txtWorkDest.Text;
            DataObj.KeTiYanJiuNeiRong = txtWorkContent.Text;
            //DataObj.KeTiCanJiaDanWeiFenGong = txtUnitTask.Text;

            if (string.IsNullOrEmpty(DataObj.BianHao))
            {
                DataObj.BianHao = Guid.NewGuid().ToString();
                if (Count >= 0)
                    DataObj.ZhuangTai = Count;
                DataObj.copyTo(ConnectionManager.Context.table("KeTiBiao")).insert();
            }
            else
            {
                DataObj.copyTo(ConnectionManager.Context.table("KeTiBiao")).where("BianHao='" + DataObj.BianHao + "'").update();
            }

            //处理单位任务表
            ConnectionManager.Context.table("RenWuBiao").where("KeTiBianHao='" + DataObj.BianHao + "'").delete();
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                if (dgvRow.Cells[0].Value == null)
                {
                    continue;
                }

                RenWuBiao rwb = new RenWuBiao();
                rwb.BianHao = Guid.NewGuid().ToString();
                rwb.KeTiBianHao = DataObj.BianHao;
                rwb.DanWeiMing = dgvRow.Cells[0].Value != null ? dgvRow.Cells[0].Value.ToString() : string.Empty;
                rwb.RenWuFenGong = dgvRow.Cells[1].Value != null ? dgvRow.Cells[1].Value.ToString() : string.Empty;
                rwb.ZhuangTai = 0;
                rwb.ModifyTime = DateTime.Now;
                rwb.copyTo(ConnectionManager.Context.table("RenWuBiao")).insert();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void txtWorkUnit_TextChanged(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                dgvDetail.Rows[0].Cells[0].Value = txtWorkUnit.Text;
            }
        }
    }
}