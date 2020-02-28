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

        List<Subjects> List = new List<Subjects>();
        public FrmAddOrUpdateWorker(Persons obj, List<Subjects> list)
        {
            InitializeComponent();

            DataObj = obj;
            List = list;
        }
        
        private void FrmAddOrUpdateWorker_Load(object sender, EventArgs e)
        {
            cbxSubjects.DisplayMember = "SubjectName";
            cbxSubjects.ValueMember = "ID";
            cbxSubjects.DataSource = List;

            if (DataObj != null)
            {
                txtName.Text = DataObj.Name;
                txtBirthday.Value = DataObj.Birthday;
                txtJob.Text = DataObj.Job;
                txtSep.Text = DataObj.Specialty;
                txtWorkUnit.Text = DataObj.UnitName;
                txtIDCard.Text = DataObj.IDCard;
                txtTask.Text = DataObj.TaskContent;
                cbxSexs.SelectedItem = DataObj.Sex;
                cbxSubjects.SelectedValue = DataObj.SubjectID;
                cbxJobInProjects.SelectedItem = DataObj.RoleName;
                txtTotalTime.Value = DataObj.TimeForSubject;
                txtTelephone.Text = DataObj.Telephone;
                txtMobilephone.Text = DataObj.MobilePhone;

                if (DataObj.RoleType == rbIsOnlyProject.Name)
                {
                    rbIsOnlyProject.Checked = true;
                }
                else if (DataObj.RoleType == rbIsOnlySubject.Name)
                {
                    rbIsOnlySubject.Checked = true;
                }
                else if (DataObj.RoleType == rbIsProjectAndSubject.Name)
                {
                    rbIsProjectAndSubject.Checked = true;
                }
            }
            else
            {
                DataObj = new Persons();
                DataObj.RoleType = "rbIsOnlySubject";
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
                || String.IsNullOrEmpty(txtTelephone.Text)
                || String.IsNullOrEmpty(txtMobilephone.Text)
                || String.IsNullOrEmpty(txtTask.Text)
                || (cbxSexs.SelectedItem == null && rbIsOnlyProject.Checked == false)
                || (cbxJobInProjects.SelectedItem == null && rbIsOnlyProject.Checked == false)
                || String.IsNullOrEmpty(txtTotalTime.Value.ToString())
                || cbxSubjects.SelectedValue == null)
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
                DataObj.TaskContent = txtTask.Text;
                DataObj.Sex = cbxSexs.SelectedItem.ToString();
                DataObj.SubjectID = cbxSubjects.SelectedValue.ToString();
                DataObj.RoleName = cbxJobInProjects.SelectedItem != null ? cbxJobInProjects.SelectedItem.ToString() : "负责人";
                DataObj.TimeForSubject = Convert.ToInt32(txtTotalTime.Value);

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

        private void rbIsOnlySubjectMaster_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                DataObj.RoleType = ((RadioButton)sender).Name;

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
    }
}