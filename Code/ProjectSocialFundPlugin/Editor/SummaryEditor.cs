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
                #region 读取数据
                Projects proj = PluginRootObj.getProjectObject<Projects>();
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict["ProjectName"] = proj.ProjectName;
                dict["KeyText"] = proj.KeyText;
                dict["ProjectType"] = proj.ProjectType;
                dict["WorkType"] = proj.WorkType;
                dict["ProjectMaster"] = proj.ProjectMaster;
                dict["ProjectMasterSex"] = proj.ProjectMasterSex;
                dict["ProjectMasterNation"] = proj.ProjectMasterNation;
                dict["ProjectMasterBirthday"] = proj.ProjectMasterBirthday;
                dict["WorkJob"] = proj.WorkJob;
                dict["ProfessionalTitle"] = proj.ProfessionalTitle;
                dict["AreasOfSpecialization"] = proj.AreasOfSpecialization;
                dict["FinalEducation"] = proj.FinalEducation;
                dict["FinalDegree"] = proj.FinalDegree;
                dict["AsAMentor"] = proj.AsAMentor;
                dict["WorkUnit"] = proj.WorkUnit;
                dict["ContactPhone"] = proj.ContactPhone;
                dict["OwnedSystem"] = proj.OwnedSystem;
                dict["IDCard"] = proj.IDCard;
                dict["FirstRecommender"] = proj.FirstRecommender;
                dict["FirstRecommenderTitle"] = proj.FirstRecommenderTitle;
                dict["FirstRecommenderUnit"] = proj.FirstRecommenderUnit;
                dict["SecondRecommender"] = proj.SecondRecommender;
                dict["SecondRecommenderTitle"] = proj.SecondRecommenderTitle;
                dict["SecondRecommenderUnit"] = proj.SecondRecommenderUnit;
                dict["ExpectedResults"] = proj.ExpectedResults;
                dict["WordCount"] = proj.WordCount;
                dict["RequestMoney"] = proj.RequestMoney;
                dict["RequestDate"] = proj.RequestDate;
                dict["CompleteDate"] = proj.CompleteDate;
                #endregion

                foreach (KeyValuePair<string, object> kvp in dict)
                {
                    bool isRadioType = true;

                    #region 设置数值TextBox,TextBoxWithOnlyNumber,DateTimePicker,ComboBox
                    foreach (Control cc in ctrlDicts.CtrlDicts.Values)
                    {
                        if (cc.Name.Contains(kvp.Key))
                        {
                            if (cc is TextBox)
                            {
                                ((TextBox)cc).Text = kvp.Value != null ? kvp.Value.ToString() : string.Empty;

                                isRadioType = false;
                                break;
                            }
                            else if (cc is TextBoxWithOnlyNumber)
                            {
                                ((TextBoxWithOnlyNumber)cc).Text = kvp.Value != null ? kvp.Value.ToString() : string.Empty;

                                isRadioType = false;
                                break;
                            }
                            else if (cc is DateTimePicker)
                            {
                                try
                                {
                                    ((DateTimePicker)cc).Value = DateTime.Parse(kvp.Value != null ? kvp.Value.ToString() : string.Empty);
                                }
                                catch (Exception ex)
                                {
                                    ((DateTimePicker)cc).Value = DateTime.Now;
                                }

                                isRadioType = false;
                                break;
                            }
                            else if (cc is ComboBox)
                            {
                                try
                                {
                                    ((ComboBox)cc).SelectedItem = kvp.Value != null ? kvp.Value.ToString() : string.Empty;
                                }
                                catch (Exception ex) { }

                                isRadioType = false;
                                break;
                            }
                        }
                    }
                    #endregion

                    if (isRadioType)
                    {
                        setCurrentWithRadioList(kvp.Key, kvp.Value != null ? kvp.Value.ToString() : string.Empty);
                    }
                }
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