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
    public partial class FrmAddOrUpdateSubjectStep : AbstractEditorPlugin.BaseForm
    {
        public FrmAddOrUpdateSubjectStep(Steps obj,string subjectName,string stepNum)
        {
            InitializeComponent();

            DataObj = obj;
            txtSubjectName.Text = subjectName;
            txtStep.Text = stepNum;
        }
        
        private void FrmAddOrUpdateWorker_Load(object sender, EventArgs e)
        {
            if (DataObj != null)
            {
                txtTag1.Text = DataObj.StepTag1;
                txtTag2.Text = DataObj.StepTag2;
                txtTag3.Text = DataObj.StepTag3;
            }
        }

        public Steps DataObj { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTag1.Text)
                || String.IsNullOrEmpty(txtTag2.Text)
                || String.IsNullOrEmpty(txtTag3.Text))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }
            else
            {
                DataObj.StepTag1 = txtTag1.Text;
                DataObj.StepTag2 = txtTag2.Text;
                DataObj.StepTag3 = txtTag3.Text;

                if (string.IsNullOrEmpty(DataObj.ID))
                {
                    DataObj.ID = Guid.NewGuid().ToString();
                    DataObj.copyTo(ConnectionManager.Context.table("Steps")).insert();
                }
                else
                {
                    DataObj.copyTo(ConnectionManager.Context.table("Steps")).where("ID='" + DataObj.ID + "'").update();
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}