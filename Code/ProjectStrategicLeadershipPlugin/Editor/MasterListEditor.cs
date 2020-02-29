using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AbstractEditorPlugin;
using ProjectStrategicLeadershipPlugin.DB.Entitys;
using AbstractEditorPlugin.Forms;
using ProjectStrategicLeadershipPlugin.DB;

namespace ProjectStrategicLeadershipPlugin.Editor
{
    public partial class MasterListEditor : BaseEditor
    {
        public MasterListEditor()
        {
            InitializeComponent();
        }

        public override void clearView()
        {
            base.clearView();

            txtProjectMasterName.Text = "";
            txtProjectMasterSex.Text = "";
            txtProjectMasterBirthday.Value = DateTime.Now;
            txtProjectMasterJob.Text = "";
            txtProjectMasterTelephone.Text = "";
            txtProjectMasterMobilephone.Text = "";
            txtTeamContactName.Text = "";
            txtTeamContactSex.Text = "";
            txtTeamContactBirthday.Text = "";
            txtTeamContactJob.Text = "";
            txtTeamContactTelephone.Text = "";
            txtTeamContactMobilephone.Text = "";
            txtTeamContactAddress.setAddress(string.Empty);
            txtUnitName.Text = "";
            txtUnitAddress.setAddress(string.Empty);
            txtUnitContact.Text = "";
            txtUnitContactJob.Text = "";
            txtUnitContactPhone.Text = "";
        }

        public override void refreshView()
        {
            base.refreshView();

            if (PluginRootObj.projectObj != null)
            {
                Projects obj = (Projects)PluginRootObj.projectObj;

                txtProjectMasterName.Text = obj.ProjectMasterName;
                txtProjectMasterSex.Text = obj.ProjectMasterSex;
                txtProjectMasterBirthday.Value = obj.ProjectMasterBirthday;
                txtProjectMasterJob.Text = obj.ProjectMasterJob;
                txtProjectMasterTelephone.Text = obj.ProjectMasterTelephone;
                txtProjectMasterMobilephone.Text = obj.ProjectMasterMobilephone;
                txtTeamContactName.Text = obj.TeamContactName;
                txtTeamContactSex.Text = obj.TeamContactSex;
                txtTeamContactBirthday.Value = obj.TeamContactBirthday;
                txtTeamContactJob.Text = obj.TeamContactJob;
                txtTeamContactTelephone.Text = obj.TeamContactTelephone;
                txtTeamContactMobilephone.Text = obj.TeamContactMobilephone;
                txtTeamContactAddress.setAddress(obj.TeamContactAddress);
                txtUnitName.Text = obj.UnitName;
                txtUnitAddress.setAddress(obj.UnitAddress);
                txtUnitContact.Text = obj.UnitContact;
                txtUnitContactJob.Text = obj.UnitContactJob;
                txtUnitContactPhone.Text = obj.UnitContactPhone;
            }
        }

        public override bool isInputCompleted()
        {
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FrmWorkProcess upf = new FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                bool result = true;
                onSaveEvent(ref result);
                PluginRootObj.refreshEditors();

                //更新保存日期
                PluginRootObj.updateSaveDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！Ex:" + ex.ToString());
            }
            finally
            {
                upf.CloseProgressWithOnlyUI();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (flowLayoutPanel1 != null)
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    c.Width = flowLayoutPanel1.Width - 20;
                    c.Margin = new Padding(0, 30, 0, 0);
                }
            }
        }

        public override void onSaveEvent(ref bool result)
        {
            base.onSaveEvent(ref result);

            if (txtProjectMasterSex.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目负责人性别!");
                result = false;
                return;
            }
            DateTime ddProjectMasterBirthday;
            if (DateTime.TryParse(txtProjectMasterBirthday.Text, out ddProjectMasterBirthday) == false)
            {
                MessageBox.Show("对不起，请输入项目负责人出生日期!");
                result = false;
                return;
            }
            if (txtProjectMasterJob.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目负责人职务/职称!");
                result = false;
                return;
            }
            if (txtProjectMasterTelephone.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目负责人电话!");
                result = false;
                return;
            }
            if (txtProjectMasterMobilephone.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目负责人手机!");
                result = false;
                return;
            }
            if (txtTeamContactName.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目组联系人!");
                result = false;
                return;
            }
            if (txtTeamContactSex.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目组联系人性别!");
                result = false;
                return;
            }
            DateTime ddTeamContactBirthday;
            if (DateTime.TryParse(txtTeamContactBirthday.Text, out ddTeamContactBirthday) == false)
            {
                MessageBox.Show("对不起，请输入项目组联系人出生年月!");
                result = false;
                return;
            }
            if (txtTeamContactJob.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目组联系人职务/职称!");
                result = false;
                return;
            }
            if (txtTeamContactTelephone.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目组联系人电话!");
                result = false;
                return;
            }
            if (txtTeamContactMobilephone.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目组联系人手机!");
                result = false;
                return;
            }
            if (txtTeamContactAddress.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目组联系人通信地址!");
                result = false;
                return;
            }

            //检查是否需要创建项目对象
            if (PluginRootObj.projectObj == null)
            {
                PluginRootObj.projectObj = new Projects();
            }

            //获得项目对象
            Projects proj = PluginRootObj.getProjectObject<Projects>();

            //proj.ProjectMasterName = txtProjectMasterName.Text;
            proj.ProjectMasterSex = txtProjectMasterSex.Text;
            proj.ProjectMasterBirthday = txtProjectMasterBirthday.Value;
            proj.ProjectMasterJob = txtProjectMasterJob.Text;
            proj.ProjectMasterTelephone = txtProjectMasterTelephone.Text;
            proj.ProjectMasterMobilephone = txtProjectMasterMobilephone.Text;
            proj.TeamContactName = txtTeamContactName.Text;
            proj.TeamContactSex = txtTeamContactSex.Text;
            proj.TeamContactBirthday = txtTeamContactBirthday.Value;
            proj.TeamContactJob = txtTeamContactJob.Text;
            proj.TeamContactTelephone = txtTeamContactTelephone.Text;
            proj.TeamContactMobilephone = txtTeamContactMobilephone.Text;
            proj.TeamContactAddress = txtTeamContactAddress.Text;

            //更新数据库
            if (string.IsNullOrEmpty(proj.ID))
            {
                proj.ID = Guid.NewGuid().ToString();
                proj.copyTo(ConnectionManager.Context.table("Projects")).insert();
            }
            else
            {
                proj.copyTo(ConnectionManager.Context.table("Projects")).where("ID='" + proj.ID + "'").update();
            }
        }
    }
}