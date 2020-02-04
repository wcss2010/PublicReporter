using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicReporterLib.Utility;
using ProjectStrategicLeadershipPlugin.DB;
using ProjectStrategicLeadershipPlugin.DB.Entitys;
using Newtonsoft.Json;
using ProjectStrategicLeadershipPlugin.Forms;
using AbstractEditorPlugin;
using AbstractEditorPlugin.Controls;
using AbstractEditorPlugin.Forms;
using AbstractEditorPlugin.Utility;

namespace ProjectStrategicLeadershipPlugin.Editor
{
    public partial class SummaryEditor : BaseEditor
    {
        public SummaryEditor()
        {
            InitializeComponent();
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

        public override void onSaveEvent(ref bool result)
        {
            base.onSaveEvent(ref result);

            if (txtProjectName.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目名称!");
                result = false;
                return;
            }
            if (txtProjectTopic.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目主题!");
                result = false;
                return;
            }
            if (txtProjectDirection.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目方向!");
                result = false;
                return;
            }
            if (txtDutyUnitName.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位名称!");
                result = false;
                return;
            }
            if (txtDutyUnitNormalName.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位常用名称!");
                result = false;
                return;
            }
            if (txtDutyUnitAddress.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位通信地址!");
                result = false;
                return;
            }
            if (txtDutyUnitContact.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位联系人!");
                result = false;
                return;
            }
            if (txtDutyUnitContactTelephone.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位联系人电话!");
                result = false;
                return;
            }
            if (cbxSecretLevel.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入保密等级!");
                result = false;
                return;
            }
            if (cbxDutyUnit2.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入责任单位所属大单位!");
                result = false;
                return;
            }
            if (txtTotalMoneys.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入总经费!");
                result = false;
                return;
            }
            if (txtTotalTimes.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入总时间!");
                result = false;
                return;
            }
            if (txtRegisterDate.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入申报日期!");
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

            proj.ProjectName = txtProjectName.Text;
            proj.ProjectTopic = txtProjectTopic.Text;
            proj.ProjectDirection = txtProjectDirection.Text;
            proj.ProjectSecretLevel = cbxSecretLevel.Text;
            proj.UnitName = txtDutyUnitName.Text;
            proj.UnitRealName = txtDutyUnitNormalName.Text;
            proj.UnitContact = txtDutyUnitContact.Text;
            proj.UnitContactPhone = txtDutyUnitContactTelephone.Text;
            proj.UnitAddress = txtDutyUnitAddress.Text;
            proj.UnitType2 = cbxDutyUnit2.Text;
            proj.TotalMoney = txtTotalMoneys.Value;
            proj.TotalTime = (int)txtTotalTimes.Value;
            proj.RequestTime = txtRegisterDate.Value;

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

        public override void refreshView()
        {
            base.refreshView();

            //加载数据
            if (PluginRootObj.projectObj != null)
            {
                Projects proj = PluginRootObj.getProjectObject<Projects>();

                txtProjectName.Text = proj.ProjectName;
                txtProjectTopic.Text = proj.ProjectTopic;
                txtProjectDirection.Text = proj.ProjectDirection;
                cbxSecretLevel.SelectedItem = proj.ProjectSecretLevel;
                txtDutyUnitName.Text = proj.UnitName;
                txtDutyUnitNormalName.Text = proj.UnitRealName;
                txtDutyUnitAddress.Text = proj.UnitAddress;
                txtDutyUnitContact.Text = proj.UnitContact;
                txtDutyUnitContactTelephone.Text = proj.UnitContactPhone;
                txtTotalMoneys.Value = proj.TotalMoney;
                txtTotalTimes.Value = proj.TotalTime;
                txtRegisterDate.Value = proj.RequestTime;
                cbxDutyUnit2.SelectedItem = proj.UnitType2;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (flowLayoutPanel1 != null)
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    c.Width = flowLayoutPanel1.Width - 40;
                }
            }
        }

        public override bool isInputCompleted()
        {
            return true;
        }

        public override void clearView()
        {
            base.clearView();

            txtProjectName.Text = string.Empty;
            txtProjectTopic.Text = string.Empty;
            txtProjectDirection.Text = string.Empty;
            cbxSecretLevel.SelectedItem = "公开";
            txtDutyUnitName.Text = string.Empty;
            txtDutyUnitNormalName.Text = string.Empty;
            txtDutyUnitAddress.Text = string.Empty;
            txtDutyUnitContact.Text = string.Empty;
            txtDutyUnitContactTelephone.Text = string.Empty;
            txtTotalMoneys.Value = 0;
            txtTotalTimes.Value = 0;
            txtRegisterDate.Value = DateTime.Now;
            if (cbxDutyUnit2.Items.Count >= 1)
            {
                cbxDutyUnit2.SelectedItem = cbxDutyUnit2.Items[cbxDutyUnit2.Items.Count - 1];
            }
        }
    }
}