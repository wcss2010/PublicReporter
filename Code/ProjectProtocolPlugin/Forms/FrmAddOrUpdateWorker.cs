using ProjectProtocolPlugin.DB;
using ProjectProtocolPlugin.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectProtocolPlugin.Forms
{
    public partial class FrmAddOrUpdateWorker : PublicReporterLib.SuperForm
    {
        List<KeTiBiao> List = new List<KeTiBiao>();
        public FrmAddOrUpdateWorker(RenYuanBiao obj, List<KeTiBiao> list, double count = -1)
        {
            InitializeComponent();

            DataObj = obj;
            Count = count;
            List = list;

        }
        
        private void FrmAddOrUpdateWorker_Load(object sender, EventArgs e)
        {
            if (DataObj != null)
            {
                txtName.Text = DataObj.XingMing;
                txtBirthday.Value = DataObj.ShengRi;
                txtJob.Text = DataObj.ZhiCheng;
                txtSep.Text = DataObj.ZhuanYe;
                txtWorkUnit.Text = DataObj.GongZuoDanWei;
                txtIDCard.Text = DataObj.ShenFenZhengHao;
                txtTask.Text = DataObj.RenWuFenGong;
                cbxSexs.SelectedItem = DataObj.XingBie;
                txtMemo.Text = DataObj.ZhiWu;
                txtTotalTime.Value = DataObj.MeiNianTouRuShiJian;
                txtTelephone.Text = DataObj.DianHua;
                txtMobilephone.Text = DataObj.ShouJi;

                if (DataObj.ShiXiangMuFuZeRen == rbIsOnlyProject.Name)
                {
                    rbIsOnlyProject.Checked = true;
                }
            }
            else
            {
                DataObj = new RenYuanBiao();
                DataObj.ShiXiangMuFuZeRen = "rbIsOnlyProject";
            }
        }

        public RenYuanBiao DataObj { get; set; }
        public double Count { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text)
                || String.IsNullOrEmpty(txtJob.Text)
                || String.IsNullOrEmpty(txtSep.Text)
                || String.IsNullOrEmpty(txtWorkUnit.Text)
                || String.IsNullOrEmpty(txtIDCard.Text)
                || String.IsNullOrEmpty(txtTelephone.Text)
                || String.IsNullOrEmpty(txtMobilephone.Text)
                || String.IsNullOrEmpty(txtTask.Text)
                || (cbxSexs.SelectedItem == null && rbIsOnlyProject.Checked == false)
                || (String.IsNullOrEmpty(txtMemo.Text) && rbIsOnlyProject.Checked == false)
                || String.IsNullOrEmpty(txtTotalTime.Value.ToString())

                )
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }
            else
            {
                DataObj.XingMing = txtName.Text;
                DataObj.ShengRi = txtBirthday.Value;
                DataObj.ZhiCheng = txtJob.Text;
                DataObj.ZhuanYe = txtSep.Text;
                DataObj.GongZuoDanWei = txtWorkUnit.Text;
                DataObj.ShenFenZhengHao = txtIDCard.Text;
                DataObj.DianHua = txtTelephone.Text;
                DataObj.ShouJi = txtMobilephone.Text;
                DataObj.RenWuFenGong = txtTask.Text;
                DataObj.XingBie = cbxSexs.SelectedItem.ToString();
                DataObj.ZhiWu = txtMemo.Text;
                DataObj.MeiNianTouRuShiJian = Convert.ToInt32(txtTotalTime.Value);

                if (string.IsNullOrEmpty(DataObj.BianHao))
                {
                    DataObj.BianHao = Guid.NewGuid().ToString();
                    if (Count >= 0)
                        DataObj.ZhuangTai = Count;
                    DataObj.copyTo(ConnectionManager.Context.table("RenYuanBiao")).insert();
                }
                else
                {
                    DataObj.copyTo(ConnectionManager.Context.table("RenYuanBiao")).where("BianHao='" + DataObj.BianHao + "'").update();
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void rbIsOnlySubjectMaster_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                DataObj.ShiXiangMuFuZeRen = ((RadioButton)sender).Name;

                if (((RadioButton)sender).Name == "rbIsOnlyProject")
                {
                    txtMemo.Enabled = true;
                }
                else
                {
                    txtMemo.Enabled = false;
                }
            }
        }
    }
}