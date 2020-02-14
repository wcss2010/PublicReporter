using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectSocialFundPlugin.DB.Entitys;
using ProjectSocialFundPlugin.DB;

namespace ProjectSocialFundPlugin.Forms
{
    public partial class FrmAddOrUpdateWorker : AbstractEditorPlugin.BaseForm
    {
        public FrmAddOrUpdateWorker(Persons obj)
        {
            InitializeComponent();

            DataObj = obj;
        }
        
        private void FrmAddOrUpdateWorker_Load(object sender, EventArgs e)
        {
            if (DataObj != null)
            {
                txtName.Text = DataObj.Name;
                txtBirthday.Value = DataObj.Birthday;
                txtJob.Text = DataObj.Job;
                txtSep.Text = DataObj.Specialty;
                txtWorkUnit.Text = DataObj.UnitName;
                txtIDCard.Text = DataObj.IDCard;
                cbxSexs.SelectedItem = DataObj.Sex;
                txtTelephone.Text = DataObj.Telephone;
                txtMobilephone.Text = DataObj.MobilePhone;
            }
            else
            {
                DataObj = new Persons();
            }
        }

        public Persons DataObj { get; set; }

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
                || cbxSexs.SelectedItem == null)
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }
            else
            {
                DataObj.Name = txtName.Text;
                DataObj.Birthday = txtBirthday.Value;
                DataObj.Job = txtJob.Text;
                DataObj.Specialty = txtSep.Text;
                DataObj.UnitName = txtWorkUnit.Text;
                DataObj.IDCard = txtIDCard.Text;
                DataObj.Telephone = txtTelephone.Text;
                DataObj.MobilePhone = txtMobilephone.Text;
                DataObj.Sex = cbxSexs.SelectedItem.ToString();

                if (string.IsNullOrEmpty(DataObj.ID))
                {
                    DataObj.ID = Guid.NewGuid().ToString();
                    DataObj.copyTo(ConnectionManager.Context.table("Persons")).insert();
                }
                else
                {
                    DataObj.copyTo(ConnectionManager.Context.table("Persons")).where("ID='" + DataObj.ID + "'").update();
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}