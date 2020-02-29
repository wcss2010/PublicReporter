namespace ProjectStrategicLeadershipPlugin.Editor
{
    partial class MasterListEditor
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.plMain = new System.Windows.Forms.Panel();
            this.plContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtProjectMasterMobilephone = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProjectMasterTelephone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtProjectMasterJob = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProjectMasterBirthday = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProjectMasterSex = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProjectMasterName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtUnitAddress = new ProjectStrategicLeadershipPlugin.Controls.ProjectAddressControl();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtUnitContactPhone = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtUnitContactJob = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtUnitContact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtTeamContactAddress = new ProjectStrategicLeadershipPlugin.Controls.ProjectAddressControl();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTeamContactMobilephone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTeamContactTelephone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTeamContactJob = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTeamContactBirthday = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTeamContactSex = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTeamContactName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblInfo = new AbstractEditorPlugin.Controls.AutoHeightLabel();
            this.plButtons.SuspendLayout();
            this.plMain.SuspendLayout();
            this.plContent.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnSave);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(13, 673);
            this.plButtons.Margin = new System.Windows.Forms.Padding(4);
            this.plButtons.Name = "plButtons";
            this.plButtons.Padding = new System.Windows.Forms.Padding(4);
            this.plButtons.Size = new System.Drawing.Size(1407, 47);
            this.plButtons.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(1283, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 39);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.plContent);
            this.plMain.Controls.Add(this.plButtons);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Margin = new System.Windows.Forms.Padding(0);
            this.plMain.Name = "plMain";
            this.plMain.Padding = new System.Windows.Forms.Padding(13);
            this.plMain.Size = new System.Drawing.Size(1433, 733);
            this.plMain.TabIndex = 4;
            // 
            // plContent
            // 
            this.plContent.AutoScroll = true;
            this.plContent.BackColor = System.Drawing.SystemColors.Control;
            this.plContent.Controls.Add(this.flowLayoutPanel1);
            this.plContent.Controls.Add(this.lblInfo);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(13, 13);
            this.plContent.Margin = new System.Windows.Forms.Padding(4);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1407, 660);
            this.plContent.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 51);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1407, 609);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(4, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1396, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目负责人";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtProjectMasterMobilephone);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.txtProjectMasterTelephone);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 51);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1388, 29);
            this.panel4.TabIndex = 2;
            // 
            // txtProjectMasterMobilephone
            // 
            this.txtProjectMasterMobilephone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectMasterMobilephone.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtProjectMasterMobilephone.Location = new System.Drawing.Point(539, 0);
            this.txtProjectMasterMobilephone.Margin = new System.Windows.Forms.Padding(5);
            this.txtProjectMasterMobilephone.Name = "txtProjectMasterMobilephone";
            this.txtProjectMasterMobilephone.Size = new System.Drawing.Size(849, 26);
            this.txtProjectMasterMobilephone.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("仿宋", 12F);
            this.label13.Location = new System.Drawing.Point(421, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 29);
            this.label13.TabIndex = 35;
            this.label13.Text = "手  机：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProjectMasterTelephone
            // 
            this.txtProjectMasterTelephone.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectMasterTelephone.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtProjectMasterTelephone.Location = new System.Drawing.Point(107, 0);
            this.txtProjectMasterTelephone.Margin = new System.Windows.Forms.Padding(5);
            this.txtProjectMasterTelephone.Name = "txtProjectMasterTelephone";
            this.txtProjectMasterTelephone.Size = new System.Drawing.Size(314, 26);
            this.txtProjectMasterTelephone.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("仿宋", 12F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "座  机：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtProjectMasterJob);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtProjectMasterBirthday);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtProjectMasterSex);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtProjectMasterName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1388, 28);
            this.panel1.TabIndex = 1;
            // 
            // txtProjectMasterJob
            // 
            this.txtProjectMasterJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectMasterJob.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtProjectMasterJob.Location = new System.Drawing.Point(836, 0);
            this.txtProjectMasterJob.Margin = new System.Windows.Forms.Padding(5);
            this.txtProjectMasterJob.Name = "txtProjectMasterJob";
            this.txtProjectMasterJob.Size = new System.Drawing.Size(552, 26);
            this.txtProjectMasterJob.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("仿宋", 12F);
            this.label12.Location = new System.Drawing.Point(718, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 28);
            this.label12.TabIndex = 33;
            this.label12.Text = "职务职称：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProjectMasterBirthday
            // 
            this.txtProjectMasterBirthday.CustomFormat = "yyyy年MM月dd日";
            this.txtProjectMasterBirthday.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectMasterBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtProjectMasterBirthday.Location = new System.Drawing.Point(539, 0);
            this.txtProjectMasterBirthday.Name = "txtProjectMasterBirthday";
            this.txtProjectMasterBirthday.Size = new System.Drawing.Size(179, 26);
            this.txtProjectMasterBirthday.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("仿宋", 12F);
            this.label11.Location = new System.Drawing.Point(421, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 28);
            this.label11.TabIndex = 12;
            this.label11.Text = "出生年月：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProjectMasterSex
            // 
            this.txtProjectMasterSex.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectMasterSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtProjectMasterSex.FormattingEnabled = true;
            this.txtProjectMasterSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.txtProjectMasterSex.Location = new System.Drawing.Point(345, 0);
            this.txtProjectMasterSex.Margin = new System.Windows.Forms.Padding(5);
            this.txtProjectMasterSex.Name = "txtProjectMasterSex";
            this.txtProjectMasterSex.Size = new System.Drawing.Size(76, 24);
            this.txtProjectMasterSex.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("仿宋", 12F);
            this.label10.Location = new System.Drawing.Point(238, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 28);
            this.label10.TabIndex = 7;
            this.label10.Text = "性  别：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProjectMasterName
            // 
            this.txtProjectMasterName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectMasterName.Enabled = false;
            this.txtProjectMasterName.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtProjectMasterName.Location = new System.Drawing.Point(107, 0);
            this.txtProjectMasterName.Margin = new System.Windows.Forms.Padding(5);
            this.txtProjectMasterName.Name = "txtProjectMasterName";
            this.txtProjectMasterName.Size = new System.Drawing.Size(131, 26);
            this.txtProjectMasterName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "姓  名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(4, 112);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1396, 119);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "申报单位";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtUnitAddress);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(4, 82);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1388, 29);
            this.panel7.TabIndex = 3;
            // 
            // txtUnitAddress
            // 
            this.txtUnitAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitAddress.EnabledEditAddressDetail = true;
            this.txtUnitAddress.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtUnitAddress.Location = new System.Drawing.Point(107, 0);
            this.txtUnitAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitAddress.Name = "txtUnitAddress";
            this.txtUnitAddress.Size = new System.Drawing.Size(1281, 29);
            this.txtUnitAddress.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("仿宋", 12F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 29);
            this.label7.TabIndex = 2;
            this.label7.Text = "通信地址：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtUnitContactPhone);
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.txtUnitContactJob);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.txtUnitContact);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(4, 52);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1388, 30);
            this.panel6.TabIndex = 2;
            // 
            // txtUnitContactPhone
            // 
            this.txtUnitContactPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitContactPhone.Enabled = false;
            this.txtUnitContactPhone.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtUnitContactPhone.Location = new System.Drawing.Point(826, 0);
            this.txtUnitContactPhone.Margin = new System.Windows.Forms.Padding(5);
            this.txtUnitContactPhone.Name = "txtUnitContactPhone";
            this.txtUnitContactPhone.Size = new System.Drawing.Size(562, 26);
            this.txtUnitContactPhone.TabIndex = 38;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Font = new System.Drawing.Font("仿宋", 12F);
            this.label18.Location = new System.Drawing.Point(718, 0);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(108, 30);
            this.label18.TabIndex = 37;
            this.label18.Text = "手  机：";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUnitContactJob
            // 
            this.txtUnitContactJob.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtUnitContactJob.Enabled = false;
            this.txtUnitContactJob.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtUnitContactJob.Location = new System.Drawing.Point(356, 0);
            this.txtUnitContactJob.Margin = new System.Windows.Forms.Padding(5);
            this.txtUnitContactJob.Name = "txtUnitContactJob";
            this.txtUnitContactJob.Size = new System.Drawing.Size(362, 26);
            this.txtUnitContactJob.TabIndex = 36;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Font = new System.Drawing.Font("仿宋", 12F);
            this.label17.Location = new System.Drawing.Point(238, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 30);
            this.label17.TabIndex = 35;
            this.label17.Text = "职务职称：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUnitContact
            // 
            this.txtUnitContact.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtUnitContact.Enabled = false;
            this.txtUnitContact.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtUnitContact.Location = new System.Drawing.Point(107, 0);
            this.txtUnitContact.Margin = new System.Windows.Forms.Padding(5);
            this.txtUnitContact.Name = "txtUnitContact";
            this.txtUnitContact.Size = new System.Drawing.Size(131, 26);
            this.txtUnitContact.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("仿宋", 12F);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 30);
            this.label6.TabIndex = 2;
            this.label6.Text = "联 系 人：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtUnitName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1388, 29);
            this.panel2.TabIndex = 1;
            // 
            // txtUnitName
            // 
            this.txtUnitName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitName.Enabled = false;
            this.txtUnitName.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtUnitName.Location = new System.Drawing.Point(107, 0);
            this.txtUnitName.Margin = new System.Windows.Forms.Padding(5);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(1281, 26);
            this.txtUnitName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("仿宋", 12F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "单位名称：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel8);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.panel5);
            this.groupBox3.Location = new System.Drawing.Point(4, 239);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1396, 117);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "项目组联系人";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtTeamContactAddress);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(4, 80);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1388, 29);
            this.panel8.TabIndex = 5;
            // 
            // txtTeamContactAddress
            // 
            this.txtTeamContactAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTeamContactAddress.EnabledEditAddressDetail = true;
            this.txtTeamContactAddress.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtTeamContactAddress.Location = new System.Drawing.Point(107, 0);
            this.txtTeamContactAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtTeamContactAddress.Name = "txtTeamContactAddress";
            this.txtTeamContactAddress.Size = new System.Drawing.Size(1281, 29);
            this.txtTeamContactAddress.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Font = new System.Drawing.Font("仿宋", 12F);
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 29);
            this.label16.TabIndex = 2;
            this.label16.Text = "通信地址：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTeamContactMobilephone);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtTeamContactTelephone);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(4, 51);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1388, 29);
            this.panel3.TabIndex = 4;
            // 
            // txtTeamContactMobilephone
            // 
            this.txtTeamContactMobilephone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTeamContactMobilephone.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtTeamContactMobilephone.Location = new System.Drawing.Point(539, 0);
            this.txtTeamContactMobilephone.Margin = new System.Windows.Forms.Padding(5);
            this.txtTeamContactMobilephone.Name = "txtTeamContactMobilephone";
            this.txtTeamContactMobilephone.Size = new System.Drawing.Size(849, 26);
            this.txtTeamContactMobilephone.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(421, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 29);
            this.label3.TabIndex = 35;
            this.label3.Text = "手  机：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTeamContactTelephone
            // 
            this.txtTeamContactTelephone.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTeamContactTelephone.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtTeamContactTelephone.Location = new System.Drawing.Point(107, 0);
            this.txtTeamContactTelephone.Margin = new System.Windows.Forms.Padding(5);
            this.txtTeamContactTelephone.Name = "txtTeamContactTelephone";
            this.txtTeamContactTelephone.Size = new System.Drawing.Size(314, 26);
            this.txtTeamContactTelephone.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("仿宋", 12F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "座  机：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtTeamContactJob);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.txtTeamContactBirthday);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.txtTeamContactSex);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.txtTeamContactName);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(4, 23);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1388, 28);
            this.panel5.TabIndex = 3;
            // 
            // txtTeamContactJob
            // 
            this.txtTeamContactJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTeamContactJob.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtTeamContactJob.Location = new System.Drawing.Point(836, 0);
            this.txtTeamContactJob.Margin = new System.Windows.Forms.Padding(5);
            this.txtTeamContactJob.Name = "txtTeamContactJob";
            this.txtTeamContactJob.Size = new System.Drawing.Size(552, 26);
            this.txtTeamContactJob.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("仿宋", 12F);
            this.label8.Location = new System.Drawing.Point(718, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 28);
            this.label8.TabIndex = 33;
            this.label8.Text = "职务职称：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTeamContactBirthday
            // 
            this.txtTeamContactBirthday.CustomFormat = "yyyy年MM月dd日";
            this.txtTeamContactBirthday.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTeamContactBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTeamContactBirthday.Location = new System.Drawing.Point(539, 0);
            this.txtTeamContactBirthday.Name = "txtTeamContactBirthday";
            this.txtTeamContactBirthday.Size = new System.Drawing.Size(179, 26);
            this.txtTeamContactBirthday.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("仿宋", 12F);
            this.label9.Location = new System.Drawing.Point(421, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 28);
            this.label9.TabIndex = 12;
            this.label9.Text = "出生年月：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTeamContactSex
            // 
            this.txtTeamContactSex.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTeamContactSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTeamContactSex.FormattingEnabled = true;
            this.txtTeamContactSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.txtTeamContactSex.Location = new System.Drawing.Point(345, 0);
            this.txtTeamContactSex.Margin = new System.Windows.Forms.Padding(5);
            this.txtTeamContactSex.Name = "txtTeamContactSex";
            this.txtTeamContactSex.Size = new System.Drawing.Size(76, 24);
            this.txtTeamContactSex.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Font = new System.Drawing.Font("仿宋", 12F);
            this.label14.Location = new System.Drawing.Point(238, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 28);
            this.label14.TabIndex = 7;
            this.label14.Text = "性  别：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTeamContactName
            // 
            this.txtTeamContactName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTeamContactName.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtTeamContactName.Location = new System.Drawing.Point(107, 0);
            this.txtTeamContactName.Margin = new System.Windows.Forms.Padding(5);
            this.txtTeamContactName.Name = "txtTeamContactName";
            this.txtTeamContactName.Size = new System.Drawing.Size(131, 26);
            this.txtTeamContactName.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Font = new System.Drawing.Font("仿宋", 12F);
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 28);
            this.label15.TabIndex = 2;
            this.label15.Text = "姓  名：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoHeight = true;
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("仿宋", 15.75F);
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lblInfo.Size = new System.Drawing.Size(1407, 51);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "请科学严谨、实事求是填写，表述要清晰准确。";
            // 
            // MasterListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plMain);
            this.Font = new System.Drawing.Font("仿宋", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MasterListEditor";
            this.Size = new System.Drawing.Size(1433, 733);
            this.plButtons.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private AbstractEditorPlugin.Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtProjectMasterName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtProjectMasterTelephone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtUnitContact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox txtProjectMasterSex;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker txtProjectMasterBirthday;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtProjectMasterJob;
        private System.Windows.Forms.TextBox txtProjectMasterMobilephone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTeamContactMobilephone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTeamContactTelephone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtTeamContactJob;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker txtTeamContactBirthday;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox txtTeamContactSex;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTeamContactName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtUnitContactJob;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtUnitContactPhone;
        private System.Windows.Forms.Label label18;
        private Controls.ProjectAddressControl txtUnitAddress;
        private Controls.ProjectAddressControl txtTeamContactAddress;
    }
}
