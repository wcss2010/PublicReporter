using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectReporterPlugin.DB;
using ProjectReporterPlugin.DB.Entitys;

namespace ProjectReporterPlugin.Forms
{
    public partial class FrmEditWorkerInfo : Form
    {
        protected Dictionary<string, Project> JobDict = new Dictionary<string, Project>();

        public Unit UnitObj { get; private set; }

        public Task TaskObj { get; private set; }

        public Person PersonObj { get; private set; }

        public FrmEditWorkerInfo(Task taskObj)
        {
            InitializeComponent();

            TaskObj = taskObj;
            InitData();
        }

        public void InitData()
        {
            //更新项目中职务
            UpdateProjectJobs();

            if (TaskObj != null)
            {
                PersonObj = ConnectionManager.Context.table("Person").where("ID = '" + TaskObj.PersonID + "'").select("*").getItem<Person>(new Person());
                if (PersonObj != null)
                {
                    txtPersonName.Text = PersonObj.Name;
                    txtPersonIDCard.Text = PersonObj.IDCard;
                    cbxPersonSex.Text = PersonObj.Sex;
                    dePersonBirthday.Value = PersonObj.Birthday != null ? PersonObj.Birthday.Value : DateTime.MinValue;
                    txtPersonJob.Text = PersonObj.Job;
                    txtPersonSpecialty.Text = PersonObj.Specialty;
                    txtPersonAddress.Text = PersonObj.Address;
                    txtPersonTelephone.Text = PersonObj.Telephone;
                    txtPersonMobilePhone.Text = PersonObj.MobilePhone;

                    //UnitExtObj = ConnectionManager.Context.table("UnitExt").where("ID='" + PersonObj.UnitID + "'").select("*").getItem<UnitExt>(new UnitExt());
                    UnitObj = ConnectionManager.Context.table("Unit").where("ID='" + PersonObj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                    if (UnitObj != null)
                    {   
                        txtUnitName.Text = UnitObj.UnitName;
                        txtUnitAddress.Text = UnitObj.Address;
                        txtUnitContactName.Text = UnitObj.ContactName;
                        txtUnitTelephone.Text = UnitObj.Telephone;
                    }

                    txtTaskContent.Text = TaskObj.Content;
                    txtWorkTimeInYear.Value = TaskObj.TotalTime != null ? TaskObj.TotalTime.Value : 0;

                    string roleName = string.Empty;
                    foreach (KeyValuePair<string, Project> kvp in JobDict)
                    {
                        if (kvp.Value.ID != null && kvp.Value.ID.Equals(TaskObj.ProjectID))
                        {
                            if (kvp.Key.EndsWith(TaskObj.Role))
                            {
                                roleName = kvp.Key;
                                break;
                            }
                        }
                    }
                    cbxItemJobs.Text = roleName;
                }
            }
        }

        private void UpdateProjectJobs()
        {
            //项目的负责人和成员
            string projectA = "项目负责人";
            //string projectB = "项目-成员";
            cbxItemJobs.Items.Add(projectA);
            //cbxItemJobs.Items.Add(projectB);
            JobDict.Add(projectA, ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj);
            //JobDict.Add(projectB, MainForm.Instance.ProjectObj);

            List<Project> ketiList = ConnectionManager.Context.table("Project").where("ParentID='" + ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID + "'").select("*").getList<Project>(new Project());
            if (ketiList != null)
            {
                foreach (Project proj in ketiList)
                {
                    projectA = proj.Name + "负责人";
                    string projectB = proj.Name + "成员";

                    cbxItemJobs.Items.Add(projectA);
                    cbxItemJobs.Items.Add(projectB);

                    JobDict.Add(projectA, proj);
                    JobDict.Add(projectB, proj);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                MessageBox.Show("对不起，请输入单位名称！");
                return;
            }
            if (string.IsNullOrEmpty(txtUnitAddress.Text))
            {
                MessageBox.Show("对不起，请输入单位通信地址！");
                return;
            }
            if (string.IsNullOrEmpty(txtUnitContactName.Text))
            {
                MessageBox.Show("对不起，请输入单位联系人！");
                return;
            }
            if (string.IsNullOrEmpty(txtUnitTelephone.Text))
            {
                MessageBox.Show("对不起，请输入单位联系电话！");
                return;
            }
            if (string.IsNullOrEmpty(txtPersonName.Text))
            {
                MessageBox.Show("对不起，请输入人员名称！");
                return;
            }
            if (string.IsNullOrEmpty(txtPersonIDCard.Text))
            {
                MessageBox.Show("对不起，请输入人员身份证！");
                return;
            }
            if (string.IsNullOrEmpty(txtPersonJob.Text))
            {
                MessageBox.Show("对不起，请输入人员职务职称！");
                return;
            }
            if (string.IsNullOrEmpty(txtPersonSpecialty.Text))
            {
                MessageBox.Show("对不起，请输入人员从事专业！");
                return;
            }
            if (string.IsNullOrEmpty(cbxPersonSex.Text))
            {
                MessageBox.Show("对不起，请输入人员性别！");
                return;
            }
            if (string.IsNullOrEmpty(dePersonBirthday.Text))
            {
                MessageBox.Show("对不起，请输入人员生日！");
                return;
            }
            if (string.IsNullOrEmpty(txtPersonTelephone.Text))
            {
                MessageBox.Show("对不起，请输入人员座机！");
                return;
            }
            if (string.IsNullOrEmpty(txtPersonMobilePhone.Text))
            {
                MessageBox.Show("对不起，请输入人员手机！");
                return;
            }
            if (string.IsNullOrEmpty(txtPersonAddress.Text))
            {
                MessageBox.Show("对不起，请输入人员通信地址！");
                return;
            }
            if (string.IsNullOrEmpty(txtWorkTimeInYear.Text))
            {
                MessageBox.Show("对不起，请输入每年为项目工作时间(月)！");
                return;
            }
            if (string.IsNullOrEmpty(txtTaskContent.Text))
            {
                MessageBox.Show("对不起，请输入任务分工！");
                return;
            }
            if (string.IsNullOrEmpty(cbxItemJobs.Text))
            {
                MessageBox.Show("对不起，请输入项目内职务！");
                return;
            }

            //单位ID
            string unitExtId = (PersonObj != null && !string.IsNullOrEmpty(PersonObj.UnitID)) ? PersonObj.UnitID : Guid.NewGuid().ToString();

            //创建单位
            ProjectReporterPlugin.Editor.ProjectEditor.BuildUnitRecord(unitExtId, txtUnitName.Text, txtUnitName.Text, txtUnitName.Text, txtUnitContactName.Text, txtUnitTelephone.Text, "课题单位", txtUnitAddress.Text);

            //新的人员ID
            string newPersonId = Guid.NewGuid().ToString();

            //创建人员
            ConnectionManager.Context.table("Person").where("IDCard = '" + txtPersonIDCard.Text.Trim() + "'").delete();

            //更新人员ID
            ConnectionManager.Context.table("Task").where("IDCard = '" + txtPersonIDCard.Text.Trim() + "'").set("PersonID", newPersonId).update();

            //添加人员
            PersonObj = new Person();
            PersonObj.UnitID = unitExtId;
            PersonObj.ID = newPersonId;
            PersonObj.Name = txtPersonName.Text;
            PersonObj.Sex = cbxPersonSex.Text;
            PersonObj.Birthday = dePersonBirthday.Value != null ? dePersonBirthday.Value : DateTime.Now;
            PersonObj.IDCard = txtPersonIDCard.Text;
            PersonObj.Job = txtPersonJob.Text;
            PersonObj.Specialty = txtPersonSpecialty.Text;
            PersonObj.Address = txtPersonAddress.Text;
            PersonObj.Telephone = txtPersonTelephone.Text;
            PersonObj.MobilePhone = txtPersonMobilePhone.Text;
            PersonObj.copyTo(ConnectionManager.Context.table("Person")).insert();
            
            //添加/修改Task
            Task task = null;
            if (TaskObj == null)
            {
                //新行
                task = new Task();
                task.ProjectID = ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID;
                task.Type = "项目";
            }
            else
            {
                //已存在
                task = TaskObj;
            }

            task.PersonID = PersonObj.ID;
            task.IDCard = PersonObj.IDCard;

            string roleName = cbxItemJobs.Text;
            if (JobDict.ContainsKey(roleName))
            {
                if (roleName.StartsWith("项目"))
                {
                    //项目
                    task.Type = "项目";
                    task.Role = roleName.Replace("项目", string.Empty);
                }
                else
                {
                    //课题
                    task.Type = "课题";
                    if (roleName.EndsWith("成员"))
                    {
                        task.Role = "成员";
                    }
                    else
                    {
                        task.Role = "负责人";
                    }
                }

                task.ProjectID = JobDict[roleName].ID;
            }

            task.Content = txtTaskContent.Text;
            task.TotalTime = (int)txtWorkTimeInYear.Value;

            if (string.IsNullOrEmpty(task.ID))
            {
                //insert
                task.ID = Guid.NewGuid().ToString();
                task.copyTo(ConnectionManager.Context.table("Task")).insert();
            }
            else
            {
                //update
                task.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + task.ID + "'").update();
            }

            DialogResult = DialogResult.OK;
        }
    }
}