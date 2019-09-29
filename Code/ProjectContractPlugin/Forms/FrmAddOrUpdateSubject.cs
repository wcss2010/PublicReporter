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
                txtUnitTask.Text = DataObj.KeTiCanJiaDanWeiFenGong;
                txtWorkUnit.Text = DataObj.KeTiFuZeDanWei;
                txtWorkOrg.Text = DataObj.KeTiSuoShuBuMen;
                txtWorkAddress.setAddress(DataObj.KeTiSuoShuDiDian);
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
                || String.IsNullOrEmpty(txtUnitTask.Text)
                ||String.IsNullOrEmpty(txtWorkDest.Text)
                || String.IsNullOrEmpty(txtWorkUnit.Text)
                || String.IsNullOrEmpty(txtWorkOrg.Text)
                || String.IsNullOrEmpty(txtWorkAddress.getAddress()))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }

            DataObj.KeTiMingCheng = txtSubjectName.Text;
            DataObj.KeTiFuZeDanWei = txtWorkUnit.Text;
            DataObj.KeTiSuoShuBuMen = txtWorkOrg.Text;
            DataObj.KeTiSuoShuDiDian = txtWorkAddress.getAddress();
            DataObj.KeTiYanJiuMuBiao = txtWorkDest.Text;
            DataObj.KeTiYanJiuNeiRong = txtWorkContent.Text;
            DataObj.KeTiCanJiaDanWeiFenGong = txtUnitTask.Text;

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
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
