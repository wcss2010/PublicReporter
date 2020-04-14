using AbstractEditorPlugin.Utility;
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
    public partial class FrmAddOrUpdateWorker : AbstractEditorPlugin.BaseForm
    {
        /// <summary>
        /// 仅为项目负责人
        /// </summary>
        public const string isOnlyProject = "rbIsOnlyProject";
        /// <summary>
        /// 项目负责人兼研究内容负责人或成员
        /// </summary>
        public const string isProjectAndSubject = "rbIsProjectAndSubject";
        /// <summary>
        /// 仅为研究内容负责人或成员
        /// </summary>
        public const string isOnlySubject = "rbIsOnlySubject";

        List<KeTiBiao> List = new List<KeTiBiao>();
        public FrmAddOrUpdateWorker(RenYuanBiao obj, List<KeTiBiao> list, double count = -1)
        {
            InitializeComponent();

            DataObj = obj;
            Count = count;
            List = list;

            initData();
        }

        private void initData()
        {
            cbxSubjects.DisplayMember = "KeTiMingCheng";
            cbxSubjects.ValueMember = "BianHao";
            cbxSubjects.DataSource = List;

            if (DataObj != null)
            {
                btnSave.Enabled = true;

                txtName.Text = DataObj.XingMing;
                txtBirthday.Value = DataObj.ShengRi;
                txtJob.Text = DataObj.ZhiCheng;
                txtSep.Text = DataObj.ZhuanYe;
                txtWorkUnit.Text = DataObj.GongZuoDanWei;
                txtIDCard.Text = DataObj.ShenFenZhengHao;
                txtTask.Text = DataObj.RenWuFenGong;
                cbxSexs.SelectedItem = DataObj.XingBie;
                cbxSubjects.SelectedValue = DataObj.KeTiBiaoHao;
                cbxJobInProjects.SelectedItem = DataObj.ZhiWu;
                txtTotalTime.Value = DataObj.MeiNianTouRuShiJian;
                txtTelephone.Text = DataObj.DianHua;
                txtMobilephone.Text = DataObj.ShouJi;

                if (DataObj.ShiXiangMuFuZeRen == rbIsOnlyProject.Name)
                {
                    rbIsOnlyProject.Checked = true;
                }
                else if (DataObj.ShiXiangMuFuZeRen == rbIsOnlySubject.Name)
                {
                    rbIsOnlySubject.Checked = true;
                }
                else if (DataObj.ShiXiangMuFuZeRen == rbIsProjectAndSubject.Name)
                {
                    rbIsProjectAndSubject.Checked = true;
                }
            }
            else
            {
                btnSave.Enabled = false;

                DataObj = new RenYuanBiao();
                DataObj.ShiXiangMuFuZeRen = "rbIsOnlySubject";
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
                || (cbxJobInProjects.SelectedItem == null && rbIsOnlyProject.Checked == false)
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
                DataObj.KeTiBiaoHao = cbxSubjects.SelectedValue.ToString();
                DataObj.ZhiWu = cbxJobInProjects.SelectedItem != null ? cbxJobInProjects.SelectedItem.ToString() : "负责人";
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
                    if (cbxSubjects.Items.Count >= 1)
                    {
                        cbxSubjects.SelectedItem = cbxSubjects.Items[0];
                    }
                    cbxSubjects.Enabled = false;
                    cbxJobInProjects.SelectedItem = "成员";
                    cbxJobInProjects.Enabled = false;
                }
                else
                {
                    cbxSubjects.Enabled = true;
                    cbxJobInProjects.Enabled = true;
                }
            }
        }

        private void txtIDCard_TextChanged(object sender, EventArgs e)
        {
            bool isOK = false;
            GetIDCardInfoCls gci = new GetIDCardInfoCls();
            try
            {
                string[] teamss = gci.AnalyzeIDCard(txtIDCard.Text.Trim(), out isOK);
                if (isOK)
                {
                    txtBirthday.Value = DateTime.Parse(teamss[0]);
                    btnSave.Enabled = true;
                    lblError.Text = string.Empty;
                }
                else
                {
                    btnSave.Enabled = false;
                    lblError.Text = "对不起，身份证号错误！";
                }
            }
            catch (Exception ex)
            {
                txtBirthday.Value = DateTime.Now;

                btnSave.Enabled = false;
                lblError.Text = "对不起，身份证号错误！";
            }
        }
    }
}