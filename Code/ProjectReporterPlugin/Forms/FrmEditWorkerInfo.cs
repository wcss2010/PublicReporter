using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectReporterPlugin.DB;
using ProjectReporterPlugin.DB.Entitys;
using PublicReporterLib.ControlAndForms;
using ProjectReporterPlugin.Editor;
using AbstractEditorPlugin.Utility;

namespace ProjectReporterPlugin.Forms
{
    public partial class FrmEditWorkerInfo : AbstractEditorPlugin.BaseForm
    {
        public PersonObject PersonInfo { get; set; }

        public FrmEditWorkerInfo(PersonObject pObject)
        {
            InitializeComponent();

            PersonInfo = pObject;

            initData();
        }

        public void initData()
        {
            #region 显示课题列表
            List<Project> subjectList = ConnectionManager.Context.table("Project").where("ParentID in ('" + ((Project)PluginRootObj.projectObj).ID + "')").select("*").getList<Project>(new Project());
            cbxSubjects.Items.Clear();
            foreach (Project subject in subjectList)
            {
                ComboboxItem ci = new ComboboxItem();
                ci.Text = subject.Name;
                ci.Value = subject;
                cbxSubjects.Items.Add(ci);
            }
            #endregion

            #region 显示默认选项
            cbxPersonSex.SelectedIndex = 0;
            cbxJobInProjects.SelectedIndex = 0;
            if (cbxSubjects.Items.Count >= 1)
            {
                cbxSubjects.SelectedIndex = 0;
            }
            #endregion

            if (PersonInfo != null)
            {
                if (PersonInfo.PersonObj != null)
                {
                    btnOK.Enabled = true;

                    txtPersonName.Text = PersonInfo.PersonObj.Name;                    
                    cbxPersonSex.Text = PersonInfo.PersonObj.Sex;
                    dePersonBirthday.Value = PersonInfo.PersonObj.Birthday != null ? PersonInfo.PersonObj.Birthday.Value : DateTime.MinValue;
                    txtPersonIDCard.Text = PersonInfo.PersonObj.IDCard;
                    txtPersonJob.Text = PersonInfo.PersonObj.Job;
                    txtPersonSpecialty.Text = PersonInfo.PersonObj.Specialty;
                    //txtPersonAddress.Text = PersonInfo.PersonObj.Address;
                    txtPersonTelephone.Text = PersonInfo.PersonObj.Telephone;
                    txtPersonMobilePhone.Text = PersonInfo.PersonObj.MobilePhone;

                    if (PersonInfo.UnitObj != null)
                    {
                        txtUnitName.Text = PersonInfo.UnitObj.UnitName;
                        //txtUnitAddress.Text = PersonInfo.UnitObj.Address;
                        //txtUnitContactName.Text = PersonInfo.UnitObj.ContactName;
                        //txtUnitTelephone.Text = PersonInfo.UnitObj.Telephone;
                    }

                    txtTaskContent.Text = PersonInfo.TaskObj.Content;
                    txtWorkTimeInYear.Value = PersonInfo.TaskObj.TotalTime != null ? PersonInfo.TaskObj.TotalTime.Value : 0;

                    #region 项目角色类型判断
                    if (PersonInfo.TaskObj.ProjectID == ((Project)PluginRootObj.projectObj).ID)
                    {
                        //仅为项目负责人
                        rbIsOnlyProject.Checked = true;
                    }
                    else
                    {
                        //查询此人有无其它的角色
                        Task projectMasterTask = ConnectionManager.Context.table("Task").where("IDCard='" + PersonInfo.PersonObj.IDCard + "' and ProjectID='" + ((Project)PluginRootObj.projectObj).ID + "' and Type = '项目' and Role='负责人'").select("*").getItem<Task>(new Task());
                        if (string.IsNullOrEmpty(projectMasterTask.ID))
                        {
                            //仅为课题角色
                            rbIsOnlySubject.Checked = true;
                        }
                        else
                        {
                            //项目角色兼课题角色
                            rbIsProjectAndSubject.Checked = true;
                        }
                    }
                    #endregion

                    //角色名
                    cbxJobInProjects.SelectedItem = PersonInfo.TaskObj.Role;

                    //课题名
                    ComboboxItem firstItem = (ComboboxItem)cbxSubjects.Items[0];
                    foreach (object obj in cbxSubjects.Items)
                    {
                        ComboboxItem item = (ComboboxItem)obj;
                        if (item.Value != null)
                        {
                            if (((Project)item.Value).ID == PersonInfo.TaskObj.ProjectID)
                            {
                                firstItem = item;
                                break;
                            }
                        }
                    }
                    cbxSubjects.SelectedItem = firstItem;
                }
            }
            else
            {
                btnOK.Enabled = false;

                PersonInfo = new PersonObject(new Project(), new Unit(), new Person(), new Task());
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
            //if (string.IsNullOrEmpty(txtUnitAddress.Text))
            //{
            //    MessageBox.Show("对不起，请输入单位通信地址！");
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtUnitContactName.Text))
            //{
            //    MessageBox.Show("对不起，请输入单位联系人！");
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtUnitTelephone.Text))
            //{
            //    MessageBox.Show("对不起，请输入单位联系电话！");
            //    return;
            //}
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
            //if (string.IsNullOrEmpty(txtPersonAddress.Text))
            //{
            //    MessageBox.Show("对不起，请输入人员通信地址！");
            //    return;
            //}
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

            //项目负责人显示序号
            int masterDiaplayOrder = 0;
            //XXXX普通人显示序号
            int personDisplayOrder = 0;
            //检查当前人员是什么角色
            if (rbIsOnlyProject.Checked)
            {
                //仅为项目负责人,需要删除当前的项目负责人,也删除此人原来的职务
                masterDiaplayOrder = ConnectionManager.Context.table("Task").where("ProjectID='" + ((Project)PluginRootObj.projectObj).ID + "' and Type = '项目' and Role='负责人'").select("DisplayOrder").getValue<int>((ProjectWorkerInfoEditor.GetMaxDisplayOrder() + 1));
                ConnectionManager.Context.table("Task").where("ProjectID='" + ((Project)PluginRootObj.projectObj).ID + "' and Type = '项目' and Role='负责人'").delete();

                ConnectionManager.Context.table("Task").where("ID='" + PersonInfo.TaskObj.ID + "'").delete();
            }
            else if (rbIsProjectAndSubject.Checked)
            {
                //项目兼课题角色,需要删除当前的项目负责人和课题角色
                masterDiaplayOrder = ConnectionManager.Context.table("Task").where("ProjectID='" + ((Project)PluginRootObj.projectObj).ID + "' and Type = '项目' and Role='负责人'").select("DisplayOrder").getValue<int>((ProjectWorkerInfoEditor.GetMaxDisplayOrder() + 1));
                ConnectionManager.Context.table("Task").where("ProjectID='" + ((Project)PluginRootObj.projectObj).ID + "' and Type = '项目' and Role='负责人'").delete();

                personDisplayOrder = PersonInfo.TaskObj.DisplayOrder != null ? PersonInfo.TaskObj.DisplayOrder.Value : (ProjectWorkerInfoEditor.GetMaxDisplayOrder() + 1);
                ConnectionManager.Context.table("Task").where("ID='" + PersonInfo.TaskObj.ID + "'").delete();
            }
            else if (rbIsOnlySubject.Checked)
            {
                //课题角色,需要删除当前的课题角色,如果此人原来是项目负责人，也删除
                personDisplayOrder = PersonInfo.TaskObj.DisplayOrder != null ? PersonInfo.TaskObj.DisplayOrder.Value : (ProjectWorkerInfoEditor.GetMaxDisplayOrder() + 1);
                ConnectionManager.Context.table("Task").where("ID='" + PersonInfo.TaskObj.ID + "'").delete();

                ConnectionManager.Context.table("Task").where("ProjectID='" + ((Project)PluginRootObj.projectObj).ID + "' and Type = '项目' and Role='负责人' and IDCard = '" + PersonInfo.PersonObj.IDCard + "'").delete();
            }
            
            //工作单位ID
            string workUnitID = string.IsNullOrEmpty(PersonInfo.UnitObj.ID) ? Guid.NewGuid().ToString() : PersonInfo.UnitObj.ID;
            //创建工作单位
            //ProjectEditor.BuildUnitRecord(workUnitID, txtUnitName.Text, txtUnitName.Text, txtUnitName.Text, txtUnitContactName.Text, txtUnitTelephone.Text, "课题单位", txtUnitAddress.Text);
            ProjectEditor.BuildUnitRecord(workUnitID, txtUnitName.Text, txtUnitName.Text, txtUnitName.Text, string.Empty, string.Empty, "课题单位", string.Empty);

            //输入人员信息
            PersonInfo.PersonObj = new Person();
            PersonInfo.PersonObj.UnitID = workUnitID;
            PersonInfo.PersonObj.ID = Guid.NewGuid().ToString();
            PersonInfo.PersonObj.Name = txtPersonName.Text;
            PersonInfo.PersonObj.Sex = cbxPersonSex.Text;
            PersonInfo.PersonObj.Birthday = dePersonBirthday.Value != null ? dePersonBirthday.Value : DateTime.Now;
            PersonInfo.PersonObj.IDCard = txtPersonIDCard.Text;
            PersonInfo.PersonObj.Job = txtPersonJob.Text;
            PersonInfo.PersonObj.Specialty = txtPersonSpecialty.Text;
            //PersonInfo.PersonObj.Address = txtPersonAddress.Text;
            PersonInfo.PersonObj.Address = string.Empty;
            PersonInfo.PersonObj.Telephone = txtPersonTelephone.Text;
            PersonInfo.PersonObj.MobilePhone = txtPersonMobilePhone.Text;

            //输入项目信息
            PersonInfo.TaskObj = new Task();
            PersonInfo.TaskObj.PersonID = PersonInfo.PersonObj.ID;
            PersonInfo.TaskObj.IDCard = PersonInfo.PersonObj.IDCard;
            PersonInfo.TaskObj.Content = txtTaskContent.Text;
            PersonInfo.TaskObj.TotalTime = (int)txtWorkTimeInYear.Value;
            PersonInfo.TaskObj.Role = cbxJobInProjects.SelectedItem.ToString();
            
            //清理人员信息引用
            clearAndUpdatePersonRef(PersonInfo.PersonObj.IDCard, PersonInfo.PersonObj.ID);

            //检查当前人员是什么角色
            if (rbIsOnlyProject.Checked)
            {
                //仅为项目负责人
                PersonInfo.TaskObj.ProjectID = ((Project)PluginRootObj.projectObj).ID;
                PersonInfo.TaskObj.ID = Guid.NewGuid().ToString();
                PersonInfo.TaskObj.Type = "项目";
                PersonInfo.TaskObj.Role = "负责人";
                PersonInfo.TaskObj.DisplayOrder = masterDiaplayOrder;
                PersonInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();
            }
            else if (rbIsProjectAndSubject.Checked)
            {
                //项目兼课题角色
                PersonInfo.TaskObj.ProjectID = ((Project)PluginRootObj.projectObj).ID;
                PersonInfo.TaskObj.ID = Guid.NewGuid().ToString();
                PersonInfo.TaskObj.Type = "项目";
                PersonInfo.TaskObj.Role = "负责人";
                PersonInfo.TaskObj.DisplayOrder = masterDiaplayOrder;
                PersonInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();

                PersonInfo.TaskObj.ProjectID = ((Project)((ComboboxItem)cbxSubjects.SelectedItem).Value).ID;
                PersonInfo.TaskObj.ID = Guid.NewGuid().ToString();
                PersonInfo.TaskObj.Type = "课题";
                PersonInfo.TaskObj.Role = cbxJobInProjects.SelectedItem.ToString();
                PersonInfo.TaskObj.DisplayOrder = personDisplayOrder;
                PersonInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();
            }
            else if (rbIsOnlySubject.Checked)
            {
                //课题角色
                PersonInfo.TaskObj.ProjectID = ((Project)((ComboboxItem)cbxSubjects.SelectedItem).Value).ID;
                PersonInfo.TaskObj.ID = Guid.NewGuid().ToString();
                PersonInfo.TaskObj.Type = "课题";
                PersonInfo.TaskObj.Role = cbxJobInProjects.SelectedItem.ToString();
                PersonInfo.TaskObj.DisplayOrder = personDisplayOrder;
                PersonInfo.TaskObj.copyTo(ConnectionManager.Context.table("Task")).insert();
            }

            //添加人员信息
            PersonInfo.PersonObj.copyTo(ConnectionManager.Context.table("Person")).insert();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 以身份证号为基础清理并更新人员信息的引用
        /// </summary>
        /// <param name="personIDCard"></param>
        /// <param name="personId"></param>
        private void clearAndUpdatePersonRef(string personIDCard, string personId)
        {
            //创建人员
            ConnectionManager.Context.table("Person").where("IDCard = '" + personIDCard + "'").delete();
            //更新人员ID
            ConnectionManager.Context.table("Task").where("IDCard = '" + personIDCard + "'").set("PersonID", personId).update();
        }

        private void rbIsOnlyProject_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbCurrent = ((RadioButton)sender);
            if (rbCurrent == rbIsOnlyProject)
            {
                cbxSubjects.Enabled = false;
                cbxJobInProjects.Enabled = false;
                cbxJobInProjects.SelectedItem = "负责人";
            }
            else
            {
                cbxSubjects.Enabled = true;
                cbxJobInProjects.Enabled = true;
                cbxJobInProjects.SelectedItem = "负责人";
            }
        }

        private void txtPersonIDCard_TextChanged(object sender, EventArgs e)
        {
            bool isOK = false;
            GetIDCardInfoCls gci = new GetIDCardInfoCls();
            try
            {
                string[] teamss = gci.AnalyzeIDCard(txtPersonIDCard.Text.Trim(), out isOK);
                if (isOK)
                {
                    dePersonBirthday.Value = DateTime.Parse(teamss[0]);
                    btnOK.Enabled = true;
                    lblError.Text = string.Empty;
                }
                else
                {
                    btnOK.Enabled = false;
                    lblError.Text = "对不起，身份证号错误！";
                }
            }
            catch (Exception ex)
            {
                dePersonBirthday.Value = DateTime.Now;

                btnOK.Enabled = false;
                lblError.Text = "对不起，身份证号错误！";
            }
        }
    }

    /// <summary>
    /// 人员信息对象
    /// </summary>
    public class PersonObject
    {
        public PersonObject(Project subject, Unit unit, Person person,Task task)
        {
            SubjectObj = subject;
            UnitObj = unit;
            PersonObj = person;
            TaskObj = task;
        }

        public Project SubjectObj { get; set; }
        public Unit UnitObj { get; set; }
        public Person PersonObj { get; set; }
        public Task TaskObj { get; set; }
    }
}