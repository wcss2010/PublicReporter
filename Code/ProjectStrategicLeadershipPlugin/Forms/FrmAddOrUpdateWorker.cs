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
                txtJob.Text = DataObj.Job;
                txtSep.Text = DataObj.Specialty;
                txtWorkUnit.Text = DataObj.UnitName;
                txtIDCard.Text = DataObj.IDCard;
                txtTask.Text = DataObj.TaskContent;
            }
            else
            {
                DataObj = new Persons();
            }
        }

        public Persons DataObj { get; set; }
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
                || String.IsNullOrEmpty(txtTask.Text))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }
            else
            {
                DataObj.Name = txtName.Text;
                DataObj.Job = txtJob.Text;
                DataObj.Specialty = txtSep.Text;
                DataObj.UnitName = txtWorkUnit.Text;
                DataObj.IDCard = txtIDCard.Text;
                DataObj.TaskContent = txtTask.Text;

                if (string.IsNullOrEmpty(DataObj.ID))
                {
                    DataObj.ID = Guid.NewGuid().ToString();
                    DataObj.DisplayOrder = ProjectStrategicLeadershipPlugin.Editor.WorkerEditor.GetMaxDisplayOrder() + 1;
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