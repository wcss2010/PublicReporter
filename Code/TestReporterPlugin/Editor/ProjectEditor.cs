using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TestReporterPlugin.DB.Services;
using TestReporterPlugin.DB.Entitys;
using TestReporterPlugin.Forms;
using TestReporterPlugin.DB;

namespace TestReporterPlugin.Editor
{
    public partial class ProjectEditor : BaseEditor
    {   
        UnitExtService _unitInforService = new UnitExtService();

        public Person ProjectPersonObj { get; private set; }

        public ProjectEditor()
        {
            InitializeComponent();
            //toCenter();
            cbxSecret.SelectedIndex = 0;
        }

        public void toCenter()
        {
            //if (plMainddd != null)
            //{
            //    plMainddd.Left = (Width - plMainddd.Width) / 2;
            //    plMainddd.Top = (Height - plMainddd.Height) / 2;
            //}
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            //toCenter();
        }

        public void LoadProject()
        {
            if (((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj != null)
            {
                txtProjectName.Text = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.Name;
                cbxSecret.SelectedItem = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.SecretLevel;
                txtTotalTime.Text = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.TotalTime + "";
                txtTotalMoney.Text = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.TotalMoney + "";
                txtKeyWords.Text = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.Keywords;
                txtDomain.Text = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.Domain;
                txtDirection.Text = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.Direction;
                txtDirectionCode.Value = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.DirectionCode != null ? ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.DirectionCode.Value : 0;

                Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                if (unitObj != null)
                {
                    txtUnitName.Text = unitObj.UnitName;
                    //txtFlagName.Text = unitObj.FlagName;
                    txtNormalName.Text = unitObj.NormalName;
                    txtContactName.Text = unitObj.ContactName;
                    txtAddress.Text = unitObj.Address;
                    txtTelephone.Text = unitObj.Telephone;
                }
            }

            UpdateUnitList();
            UpdatePersonList();
        }

        public override void ClearView()
        {
            //cbxPersonList.Items.Clear();
            //leSearchList.Properties.DataSource = null;
            //cbxUnitA.Items.Clear();
            //cbxUnitB.Items.Clear();
            //cbxUnitC.Items.Clear();

            txtProjectName.Text = string.Empty;
            txtTotalTime.Text = string.Empty;
            txtTotalMoney.Text = string.Empty;
            cbxSecret.SelectedIndex = 0;
            txtMPersonName.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtKeyWords.Text = string.Empty;
        }

        private void UpdateUnitList()
        {
            //var unitList = _unitInforService.GetUnitInforList();

            //leSearchList.Properties.DataSource = unitList;
            //leSearchList.Properties.DisplayMember = "UnitBankNo";
            //leSearchList.Properties.ValueMember = "ID";

            //if (((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).ProjectObj != null)
            //{
            //    leSearchList.EditValue = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).ProjectObj.UnitID;
            //}
        }

        private void UpdatePersonList()
        {   
            if (((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj != null)
            {
                ProjectPersonObj = ConnectionManager.Context.table("Person").where("ID in (select PersonID from task where Role='负责人' and Type='项目' and ProjectID = '" + ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID + "')").select("*").getItem<Person>(new Person());

            }

            //显示项目负责人信息
            if (ProjectPersonObj != null)
            {
                txtMPersonName.Text = ProjectPersonObj.Name;
                txtMPersonIDCard.Text = ProjectPersonObj.IDCard;
                //cbxMPersonSex.Text = ProjectPersonObj.Sex;
                //txtMPersonJob.Text = ProjectPersonObj.Job;
                //txtMPersonTelephone.Text = ProjectPersonObj.Telephone;
                //txtMPersonMobilephone.Text = ProjectPersonObj.MobilePhone;
                //txtMPersonBirthday.DateTime = ProjectPersonObj.Birthday != null ? ProjectPersonObj.Birthday.Value : DateTime.Now;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                SaveProject();
                ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).refreshEditors();
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

        public long SaveProject()
        {
            if (string.IsNullOrEmpty(txtMPersonName.Text))
            {
                MessageBox.Show("对不起,请输入项目负责人姓名!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtMPersonIDCard.Text))
            {
                MessageBox.Show("对不起,请输入项目负责人身份证!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                MessageBox.Show("对不起,请输入单位名称!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageBox.Show("对不起,请输入工程名称!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtTotalTime.Text))
            {
                MessageBox.Show("对不起,请输入研究周期!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtTotalMoney.Text))
            {
                MessageBox.Show("对不起,请输入研究经费!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtKeyWords.Text))
            {
                MessageBox.Show("对不起,请输入关键字!");
                return -1;
            }
            int result = 0;
            decimal result2 = 0;
            if (int.TryParse(txtTotalTime.Text, out result) == false)
            {
                MessageBox.Show("对不起,研究周期格式不正确");
                return -1;
            }
            if (decimal.TryParse(txtTotalMoney.Text, out result2) == false)
            {
                MessageBox.Show("对不起,研究经费格式不正确");
                return -1;
            }

            //if (leSearchList.EditValue == null || leSearchList.EditValue == "")
            //{
            //    MessageBox.Show("对不起，请选择申报单位");
            //    return -1;
            //}

            if (string.IsNullOrEmpty(txtContactName.Text))
            {
                MessageBox.Show("对不起，请输入联系人");
                return -1;
            }

            if (string.IsNullOrEmpty(txtTelephone.Text))
            {
                MessageBox.Show("对不起，请输入联系电话");
                return -1;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("对不起，请输入通信地址");
                return -1;
            }
            if (string.IsNullOrEmpty(txtDomain.Text))
            {
                MessageBox.Show("对不起，请输入申报领域");
                return -1;
            }

            //if (string.IsNullOrEmpty(txtFlagName.Text))
            //{
            //    MessageBox.Show("对不起，请输入公章名称");
            //    return -1;
            //}

            //if (string.IsNullOrEmpty(txtNormalName.Text))
            //{
            //    MessageBox.Show("对不起，请输入常用名");
            //    return -1;
            //}
            
            //创建单位信息
            string unitExtId = (((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj != null && !string.IsNullOrEmpty(((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.UnitID)) ? ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.UnitID : Guid.NewGuid().ToString();
            BuildUnitRecord(unitExtId, txtUnitName.Text, txtUnitName.Text, txtNormalName.Text, txtContactName.Text, txtTelephone.Text, "申报单位", txtAddress.Text);

            string projectIDs = string.Empty;
            if (((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj == null)
            {
                projectIDs = Guid.NewGuid().ToString();
            }
            else
            {
                projectIDs = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID;
            }

            //新的人员ID
            string newPersonId = Guid.NewGuid().ToString();

            if (ProjectPersonObj != null)
            {
                ConnectionManager.Context.table("Person").where("IDCard = '" + ProjectPersonObj.IDCard + "'").delete();

                //更新人员ID
                ConnectionManager.Context.table("Task").where("IDCard = '" + ProjectPersonObj.IDCard + "'").set("PersonID", newPersonId).update();
            }
            else
            {
                ProjectPersonObj = new Person();
            }

            ProjectPersonObj.ID = newPersonId;
            ProjectPersonObj.Name = txtMPersonName.Text;
            ProjectPersonObj.UnitID = unitExtId;
            ProjectPersonObj.IDCard = txtMPersonIDCard.Text;
            //ProjectPersonObj.IDCard = txtMPersonIDCard.Text;
            //ProjectPersonObj.Sex = cbxMPersonSex.Text;
            //ProjectPersonObj.Job = txtMPersonJob.Text;
            //ProjectPersonObj.Birthday = txtMPersonBirthday.DateTime;
            //ProjectPersonObj.Telephone = txtMPersonTelephone.Text;
            //ProjectPersonObj.MobilePhone = txtMPersonMobilephone.Text;
            ProjectPersonObj.copyTo(ConnectionManager.Context.table("Person")).insert();

            //删除这个记录
            Task projectPerson = ConnectionManager.Context.table("Task").where("Role = '负责人' and Type = '项目'").select("*").getItem<Task>(new Task());
            ConnectionManager.Context.table("Task").where("Role = '负责人' and Type = '项目'").delete();

            if (projectPerson == null)
            {
                projectPerson = new Task();
            }

            projectPerson.ID = Guid.NewGuid().ToString();
            projectPerson.PersonID = ProjectPersonObj.ID;
            projectPerson.IDCard = ProjectPersonObj.IDCard;
            projectPerson.ProjectID = projectIDs;
            projectPerson.Role = "负责人";
            projectPerson.Type = "项目";
            projectPerson.copyTo(ConnectionManager.Context.table("Task")).insert();

            //工程
            if (((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj == null)
            {
                ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj = new Project();
            }

            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ParentID = string.Empty;
            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.UnitID = unitExtId;
            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.Type = "项目";
            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.SecretLevel = cbxSecret.SelectedItem != null ? cbxSecret.SelectedItem.ToString() : "公开";
            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.Name = txtProjectName.Text;
            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.TotalTime = int.Parse(txtTotalTime.Text);
            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.TotalMoney = decimal.Parse(txtTotalMoney.Text);
            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.Keywords = txtKeyWords.Text;
            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.Domain = txtDomain.Text;
            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.Direction = txtDirection.Text;
            ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.DirectionCode = (int)txtDirectionCode.Value;

            //添加/修改工程
            if (string.IsNullOrEmpty(((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID))
            {
                ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID = projectIDs;

                //创建候选单位
                BuildWhiteList();

                return ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.copyTo(ConnectionManager.Context.table("Project")).insert();
            }
            else
            {
                //创建候选单位
                BuildWhiteList();

                return ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.copyTo(ConnectionManager.Context.table("Project")).where("ID='" + ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID + "'").update();
            }
        }

        private void cbxPersonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxPersonList.SelectedItem != null)
            //{
            //    ComboboxItem selected = (ComboboxItem)cbxPersonList.SelectedItem;
            //    Person pp = (Person)selected.Value;
            //    txtTelphone.Text = pp.Telephone;
            //    txtAddress.Text = pp.Address;
            //}
        }

        private void cbxUnitA_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxUnitA.SelectedIndex >= 0)
            //{
            //    Unit uu = (Unit)((ComboboxItem)cbxUnitA.Items[cbxUnitA.SelectedIndex]).Value;
            //    txtFlagName.Text = uu.FlagName;
            //    txtNormalName.Text = uu.NormalName;
            //}
        }
        
        /// <summary>
        /// 创建单位信息
        /// </summary>
        /// <param name="unitId">单位ID</param>
        /// <param name="unitName">单位名称</param>
        /// <param name="flagName">公章名称</param>
        /// <param name="normalName">单位常用名</param>
        /// <param name="contactName">联系人</param>
        /// <param name="telephone">电话</param>
        /// <param name="unitType">单位类型</param>
        /// <param name="unitAddress">通信地址</param>
        public static void BuildUnitRecord(string unitId, string unitName, string flagName,string normalName,string contactName, string telephone, string unitType, string unitAddress)
        {
            ConnectionManager.Context.table("Unit").where("ID='" + unitId + "'").delete();

            Unit newUnit = new Unit();
            newUnit.ID = unitId;
            newUnit.UnitName = unitName;
            newUnit.FlagName = flagName;
            newUnit.NormalName = normalName;
            newUnit.ContactName = contactName;
            newUnit.Telephone = telephone;
            newUnit.Address = unitAddress;
            newUnit.UnitType = unitType;
            newUnit.SecretQualification = "未知";
            newUnit.copyTo(ConnectionManager.Context.table("Unit")).insert();
        }

        /// <summary>
        /// 创建候选牵头单位
        /// </summary>
        private void BuildWhiteList()
        {
            //删除所有记录
            ConnectionManager.Context.table("WhiteList").delete();

            //创建新的记录
            WhiteList wl = new WhiteList();
            wl.ID = Guid.NewGuid().ToString();
            wl.ProjectID = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID;
            wl.UnitID = ((TestReporterPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.UnitID;
            wl.copyTo(ConnectionManager.Context.table("WhiteList")).insert();
        }

        private void leSearchList_EditValueChanged(object sender, EventArgs e)
        {
            //Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + leSearchList.EditValue + "'").select("*").getItem<Unit>(new Unit());
            //if (unitObj != null)
            //{
            //    txtUnitName.Text = unitObj.UnitName;
            //    txtContactName.Text = unitObj.ContactName;
            //    txtTelephone.Text = unitObj.Telephone;
            //    txtAddress.Text = unitObj.Address;
            //    txtNormalName.Text = unitObj.NormalName;
            //}
        }

        private void NewProjectEditor_SizeChanged(object sender, EventArgs e)
        {
            //plMain.Left = (Width - plMain.Width) / 2;
            //plMain.Top = (Height - plMain.Height) / 2;
        }

        public override void RefreshView()
        {
            base.RefreshView();

            LoadProject();
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            SaveProject();
        }

        public override bool IsInputCompleted()
        {
            return true;
        }
    }

    public delegate void EditValueChangedDelegate(object sender, EventArgs e);

    public class BankSelectButton : Button
    {
        public BankSelectButton():base()
        {
            Text = "请选择开户帐号！";
        }

        public event EditValueChangedDelegate EditValueChanged;

        private object _editValue = null;

        public object EditValue
        {
            get
            {
                return _editValue;
            }

            set
            {
                _editValue = value;
                if (value != null && ConnectionManager.Context != null)
                {
                    EditText = ConnectionManager.Context.table("UnitExt").where("ID='" + value + "'").select("UnitBankNo").getValue<string>("请选择开户帐号！");
                }
            }
        }

        public string EditText
        {
            get { return Text; }

            set { Text = value; }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);            
        }
    }
}