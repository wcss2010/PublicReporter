using ProjectStrategicLeadershipPlugin.DB.Entitys;
using ProjectStrategicLeadershipPlugin.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectStrategicLeadershipPlugin.Forms
{
    public partial class FrmAddOrUpdateSubject : AbstractEditorPlugin.BaseForm
    {
        public FrmAddOrUpdateSubject(Subjects obj)
        {
            InitializeComponent();

            DataObj = obj;
        }
        
        private void FrmAddOrUpdateWorker_Load(object sender, EventArgs e)
        {
            if (DataObj != null)
            {
                txtName.Text = DataObj.SubjectName;
                txtUnitName.Text = DataObj.UnitName;
                txtUnitContactPhone.Text = DataObj.UnitContactPhone;
                txtUnitContactAddress.Text = DataObj.UnitAddress;
                txtUnitContact.Text = DataObj.UnitContact;
            }
            else
            {
                DataObj = new Subjects();
            }
        }

        public Subjects DataObj { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text)
                || String.IsNullOrEmpty(txtUnitName.Text)
                || String.IsNullOrEmpty(txtUnitContactPhone.Text)
                || String.IsNullOrEmpty(txtUnitContactAddress.Text)
                || String.IsNullOrEmpty(txtUnitContact.Text))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }
            else
            {
                DataObj.SubjectName = txtName.Text;
                DataObj.UnitName = txtUnitName.Text;
                DataObj.UnitContactPhone = txtUnitContactPhone.Text;
                DataObj.UnitAddress = txtUnitContactAddress.Text;
                DataObj.UnitContact = txtUnitContact.Text;

                if (string.IsNullOrEmpty(DataObj.ID))
                {
                    DataObj.ID = Guid.NewGuid().ToString();
                    DataObj.copyTo(ConnectionManager.Context.table("Subjects")).insert();
                }
                else
                {
                    DataObj.copyTo(ConnectionManager.Context.table("Subjects")).where("ID='" + DataObj.ID + "'").update();
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}