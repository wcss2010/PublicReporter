using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicReporterLib.Utility;
using ProjectSocialFundPlugin.DB;
using ProjectSocialFundPlugin.DB.Entitys;
using Newtonsoft.Json;
using ProjectSocialFundPlugin.Forms;
using AbstractEditorPlugin;
using AbstractEditorPlugin.Controls;
using AbstractEditorPlugin.Forms;
using AbstractEditorPlugin.Utility;
using System.Reflection;
using Noear.Weed;
using PublicReporterLib;

namespace ProjectSocialFundPlugin.Editor
{
    public partial class SummaryEditor : BaseEditor
    {
        private InputControlDict ctrlDicts = new InputControlDict();

        public SummaryEditor()
        {
            InitializeComponent();

            ctrlDicts.InputControlTypeList.Add(typeof(TextBox));
            ctrlDicts.InputControlTypeList.Add(typeof(DateTimePicker));
            ctrlDicts.InputControlTypeList.Add(typeof(TextBoxWithOnlyNumber));
            ctrlDicts.InputControlTypeList.Add(typeof(ComboBox));
            ctrlDicts.InputControlTypeList.Add(typeof(RadioButton));
            ctrlDicts.searchAllControls(flowLayoutPanel1);
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

            foreach (Control ccc in ctrlDicts.CtrlDicts.Values)
            {
                if (ccc is RadioButton || ccc is DateTimePicker)
                {
                    continue;
                }
                else
                {
                    if (ccc is TextBox && string.IsNullOrEmpty(((TextBox)ccc).Text))
                    {
                        MessageBox.Show("对不起，请将信息填写完整！");
                        return;
                    }
                    else if (ccc is TextBoxWithOnlyNumber && string.IsNullOrEmpty(((TextBoxWithOnlyNumber)ccc).Text))
                    {
                        MessageBox.Show("对不起，请将信息填写完整！");
                        return;
                    }
                    else if (ccc is ComboBox && string.IsNullOrEmpty(((ComboBox)ccc).Text))
                    {
                        MessageBox.Show("对不起，请将信息填写完整！");
                        return;
                    }
                }
            }

            //检查是否需要创建项目对象
            if (PluginRootObj.projectObj == null)
            {
                PluginRootObj.projectObj = new Projects();
            }

            //获得项目对象
            Projects proj = PluginRootObj.getProjectObject<Projects>();

            proj.ProjectName = txtProjectName.Text;
            proj.KeyText = txtKeyText.Text;
            proj.ProjectType = getCurrentWithRadioList("ProjectType");
            proj.WorkType = getCurrentWithRadioList("WorkType");
            proj.ProjectMaster = txtProjectMaster.Text;
            proj.ProjectMasterSex = cbxProjectMasterSex.Text;
            proj.ProjectMasterNation = txtProjectMasterNation.Text;
            proj.ProjectMasterBirthday = dtpProjectMasterBirthday.Text;
            proj.WorkJob = txtWorkJob.Text;
            proj.ProfessionalTitle = txtProfessionalTitle.Text;
            proj.AreasOfSpecialization = txtAreasOfSpecialization.Text;
            proj.FinalEducation = txtFinalEducation.Text;
            proj.FinalDegree = txtFinalDegree.Text;
            proj.AsAMentor = txtAsAMentor.Text;
            proj.WorkUnit = txtWorkUnit.Text;
            proj.ContactPhone = txtContactPhone.Text;
            proj.OwnedSystem = txtOwnedSystem.Text;
            proj.IDCard = txtIDCard.Text;
            proj.FirstRecommender = txtFirstRecommender.Text;
            proj.FirstRecommenderTitle = txtFirstRecommenderTitle.Text;
            proj.FirstRecommenderUnit = txtFirstRecommenderUnit.Text;
            proj.SecondRecommender = txtSecondRecommender.Text;
            proj.SecondRecommenderTitle = txtSecondRecommenderTitle.Text;
            proj.SecondRecommenderUnit = txtSecondRecommenderUnit.Text;
            proj.ExpectedResults = getCurrentWithRadioList("ExpectedResults");
            proj.WordCount = int.Parse(txtWordCount.Text);
            proj.RequestMoney = int.Parse(txtRequestMoney.Text);
            proj.RequestDate = dtpRequestDate.Value;
            proj.CompleteDate = dtpCompleteDate.Value;

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
                txtKeyText.Text = proj.KeyText;
                setCurrentWithRadioList("ProjectType", proj.ProjectType);
                setCurrentWithRadioList("WorkType", proj.WorkType);
                txtProjectMaster.Text = proj.ProjectMaster;
                cbxProjectMasterSex.Text = proj.ProjectMasterSex;
                txtProjectMasterNation.Text = proj.ProjectMasterNation;
                dtpProjectMasterBirthday.Text = proj.ProjectMasterBirthday;
                txtWorkJob.Text = proj.WorkJob;
                txtProfessionalTitle.Text = proj.ProfessionalTitle;
                txtAreasOfSpecialization.Text = proj.AreasOfSpecialization;
                txtFinalEducation.Text = proj.FinalEducation;
                txtFinalDegree.Text = proj.FinalDegree;
                txtAsAMentor.Text = proj.AsAMentor;
                txtWorkUnit.Text = proj.WorkUnit;
                txtContactPhone.Text = proj.ContactPhone;
                txtOwnedSystem.Text = proj.OwnedSystem;
                txtIDCard.Text = proj.IDCard;
                txtFirstRecommender.Text = proj.FirstRecommender;
                txtFirstRecommenderTitle.Text = proj.FirstRecommenderTitle;
                txtFirstRecommenderUnit.Text = proj.FirstRecommenderUnit;
                txtSecondRecommender.Text = proj.SecondRecommender;
                txtSecondRecommenderTitle.Text = proj.SecondRecommenderTitle;
                txtSecondRecommenderUnit.Text = proj.SecondRecommenderUnit;
                setCurrentWithRadioList("ExpectedResults", proj.ExpectedResults);
                txtWordCount.Text = proj.WordCount + "";
                txtRequestMoney.Text = proj.RequestMoney + "";
                dtpRequestDate.Value = proj.RequestDate;
                dtpCompleteDate.Value = proj.CompleteDate;
            }
        }

        protected string getCurrentWithRadioList(string fieldName)
        {
            List<RadioButton> radioList = new List<RadioButton>();
            foreach (Control c in ctrlDicts.CtrlDicts.Values)
            {
                if (c.Name.Contains(fieldName))
                {
                    radioList.Add((RadioButton)c);
                }
            }

            string result = string.Empty;
            foreach (RadioButton rb in radioList)
            {
                if (rb.Checked)
                {
                    result = rb.Text;
                    break;
                }
            }
            return result;
        }

        protected void setCurrentWithRadioList(string fieldName,string value)
        {
            List<RadioButton> radioList = new List<RadioButton>();
            foreach (Control c in ctrlDicts.CtrlDicts.Values)
            {
                if (c.Name.Contains(fieldName))
                {
                    radioList.Add((RadioButton)c);
                }
            }

            foreach (RadioButton rb in radioList)
            {
                if (rb.Text == value)
                {
                    rb.Checked = true;
                    break;
                }
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

        public override bool isInputCompleted()
        {
            return true;
        }

        public override void clearView()
        {
            base.clearView();

            foreach (KeyValuePair<string, Control> kvp in ctrlDicts.CtrlDicts)
            {
                if (kvp.Value is TextBox)
                {
                    ((TextBox)kvp.Value).Text = string.Empty;
                }
                else if (kvp.Value is DateTimePicker)
                {
                    ((DateTimePicker)kvp.Value).Value = DateTime.Now;
                }
                else if (kvp.Value is TextBoxWithOnlyNumber)
                {
                    ((TextBoxWithOnlyNumber)kvp.Value).Text = "0";
                }
            }
        }
    }
}