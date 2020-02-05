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
    public partial class FrmAddOrUpdateProjectStep : AbstractEditorPlugin.BaseForm
    {
        public FrmAddOrUpdateProjectStep(ProjectStep obj)
        {
            InitializeComponent();

            DataObj = obj;
        }
        
        private void FrmAddOrUpdateWorker_Load(object sender, EventArgs e)
        {
            cbxMonths.SelectedIndex = 0;

            if (DataObj != null)
            {
                cbxMonths.SelectedItem = DataObj.StepTime;
                txtTag1.Text = DataObj.StepTag1;
                txtTag2.Text = DataObj.StepTag2;
                txtTag3.Text = DataObj.StepTag3;
            }
            else
            {
                DataObj = new ProjectStep();
            }
        }

        public ProjectStep DataObj { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxMonths.SelectedItem == null
                || String.IsNullOrEmpty(txtTag1.Text)
                || String.IsNullOrEmpty(txtTag2.Text)
                || String.IsNullOrEmpty(txtTag3.Text))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }
            else
            {
                DataObj.StepTime = int.Parse(cbxMonths.SelectedItem.ToString());
                DataObj.StepTag1 = txtTag1.Text;
                DataObj.StepTag2 = txtTag2.Text;
                DataObj.StepTag3 = txtTag3.Text;

                if (string.IsNullOrEmpty(DataObj.ID))
                {
                    DataObj.ID = Guid.NewGuid().ToString();
                    DataObj.copyTo(ConnectionManager.Context.table("ProjectStep")).insert();
                }
                else
                {
                    DataObj.copyTo(ConnectionManager.Context.table("ProjectStep")).where("ID='" + DataObj.ID + "'").update();
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}