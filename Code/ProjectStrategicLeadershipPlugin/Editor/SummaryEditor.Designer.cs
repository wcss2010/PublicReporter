﻿namespace ProjectStrategicLeadershipPlugin.Editor
{
    partial class SummaryEditor
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
            this.btnSave = new System.Windows.Forms.Button();
            this.plMain = new System.Windows.Forms.Panel();
            this.plContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtProjectTopic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxSecretLevel = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProjectDirection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtDutyUnitName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtDutyUnitNormalName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbxDutyUnit2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDutyUnitAddress = new ProjectStrategicLeadershipPlugin.Controls.ProjectAddressControl();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtDutyUnitContactJob = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDutyUnitContactTelephone = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDutyUnitContact = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtRegisterDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalTimes = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalMoneys = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.txtProjectMasterName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInfo = new AbstractEditorPlugin.Controls.AutoHeightLabel();
            this.plButtons = new System.Windows.Forms.Panel();
            this.plMain.SuspendLayout();
            this.plContent.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMoneys)).BeginInit();
            this.plButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(979, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 29);
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
            this.plMain.Padding = new System.Windows.Forms.Padding(10);
            this.plMain.Size = new System.Drawing.Size(1092, 727);
            this.plMain.TabIndex = 3;
            // 
            // plContent
            // 
            this.plContent.AutoScroll = true;
            this.plContent.BackColor = System.Drawing.SystemColors.Control;
            this.plContent.Controls.Add(this.flowLayoutPanel1);
            this.plContent.Controls.Add(this.lblInfo);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(10, 10);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1072, 672);
            this.plContent.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel7);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Controls.Add(this.panel10);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 51);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1072, 621);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtProjectName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 29);
            this.panel1.TabIndex = 0;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectName.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtProjectName.Location = new System.Drawing.Point(155, 0);
            this.txtProjectName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(892, 26);
            this.txtProjectName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "项目名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtProjectTopic);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1047, 29);
            this.panel2.TabIndex = 1;
            // 
            // txtProjectTopic
            // 
            this.txtProjectTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectTopic.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtProjectTopic.Location = new System.Drawing.Point(155, 0);
            this.txtProjectTopic.Margin = new System.Windows.Forms.Padding(4);
            this.txtProjectTopic.Name = "txtProjectTopic";
            this.txtProjectTopic.Size = new System.Drawing.Size(892, 26);
            this.txtProjectTopic.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("仿宋", 12F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "项目主题：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbxSecretLevel);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtProjectDirection);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(3, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1047, 29);
            this.panel3.TabIndex = 2;
            // 
            // cbxSecretLevel
            // 
            this.cbxSecretLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxSecretLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecretLevel.DropDownWidth = 121;
            this.cbxSecretLevel.Font = new System.Drawing.Font("仿宋", 12F);
            this.cbxSecretLevel.Items.AddRange(new object[] {
            "公开",
            "秘密",
            "机密"});
            this.cbxSecretLevel.Location = new System.Drawing.Point(819, 0);
            this.cbxSecretLevel.Name = "cbxSecretLevel";
            this.cbxSecretLevel.Size = new System.Drawing.Size(99, 24);
            this.cbxSecretLevel.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("仿宋", 12F);
            this.label12.Location = new System.Drawing.Point(699, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 29);
            this.label12.TabIndex = 3;
            this.label12.Text = "保密等级：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProjectDirection
            // 
            this.txtProjectDirection.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectDirection.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtProjectDirection.Location = new System.Drawing.Point(155, 0);
            this.txtProjectDirection.Margin = new System.Windows.Forms.Padding(4);
            this.txtProjectDirection.Name = "txtProjectDirection";
            this.txtProjectDirection.Size = new System.Drawing.Size(544, 26);
            this.txtProjectDirection.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "项目方向：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtDutyUnitName);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(3, 113);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1047, 29);
            this.panel5.TabIndex = 4;
            // 
            // txtDutyUnitName
            // 
            this.txtDutyUnitName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDutyUnitName.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtDutyUnitName.Location = new System.Drawing.Point(155, 0);
            this.txtDutyUnitName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDutyUnitName.Name = "txtDutyUnitName";
            this.txtDutyUnitName.Size = new System.Drawing.Size(892, 26);
            this.txtDutyUnitName.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("仿宋", 12F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "责任单位名称：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtDutyUnitNormalName);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(3, 148);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1047, 29);
            this.panel6.TabIndex = 5;
            // 
            // txtDutyUnitNormalName
            // 
            this.txtDutyUnitNormalName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDutyUnitNormalName.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtDutyUnitNormalName.Location = new System.Drawing.Point(155, 0);
            this.txtDutyUnitNormalName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDutyUnitNormalName.Name = "txtDutyUnitNormalName";
            this.txtDutyUnitNormalName.Size = new System.Drawing.Size(892, 26);
            this.txtDutyUnitNormalName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("仿宋", 12F);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "责任单位常用名称：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cbxDutyUnit2);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.txtDutyUnitAddress);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(3, 183);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1047, 29);
            this.panel7.TabIndex = 6;
            // 
            // cbxDutyUnit2
            // 
            this.cbxDutyUnit2.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxDutyUnit2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDutyUnit2.Font = new System.Drawing.Font("仿宋", 12F);
            this.cbxDutyUnit2.FormattingEnabled = true;
            this.cbxDutyUnit2.Items.AddRange(new object[] {
            "陆军",
            "海军",
            "空军",
            "火箭军",
            "战略支援部队",
            "联勤保障部队",
            "军委机关直属单位",
            "军事科学院",
            "国防大学",
            "国防科技大学",
            "武警部队",
            "教育部",
            "工信部",
            "中国科学院",
            "中国兵器工业集团公司",
            "中国兵器装备集团公司",
            "中国船舶工业集团公司",
            "中国船舶重工集团公司",
            "中国电子科技集团公司",
            "中国电子信息产业集团公司",
            "中国航空发动机集团公司",
            "中国航空工业集团公司",
            "中国航天科工集团公司",
            "中国航天科技集团公司",
            "中国核工业集团公司",
            "中国工程物理研究院",
            "其它"});
            this.cbxDutyUnit2.Location = new System.Drawing.Point(745, 0);
            this.cbxDutyUnit2.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDutyUnit2.Name = "cbxDutyUnit2";
            this.cbxDutyUnit2.Size = new System.Drawing.Size(190, 24);
            this.cbxDutyUnit2.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("仿宋", 12F);
            this.label8.Location = new System.Drawing.Point(546, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 29);
            this.label8.TabIndex = 15;
            this.label8.Text = "责任单位所属大单位：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDutyUnitAddress
            // 
            this.txtDutyUnitAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDutyUnitAddress.EnabledEditAddressDetail = true;
            this.txtDutyUnitAddress.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtDutyUnitAddress.Location = new System.Drawing.Point(155, 0);
            this.txtDutyUnitAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtDutyUnitAddress.Name = "txtDutyUnitAddress";
            this.txtDutyUnitAddress.Size = new System.Drawing.Size(391, 29);
            this.txtDutyUnitAddress.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("仿宋", 12F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 29);
            this.label7.TabIndex = 2;
            this.label7.Text = "责任单位地址：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtDutyUnitContactJob);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.txtDutyUnitContactTelephone);
            this.panel8.Controls.Add(this.label13);
            this.panel8.Controls.Add(this.txtDutyUnitContact);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Location = new System.Drawing.Point(3, 218);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1047, 27);
            this.panel8.TabIndex = 7;
            // 
            // txtDutyUnitContactJob
            // 
            this.txtDutyUnitContactJob.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDutyUnitContactJob.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtDutyUnitContactJob.Location = new System.Drawing.Point(745, 0);
            this.txtDutyUnitContactJob.Margin = new System.Windows.Forms.Padding(4);
            this.txtDutyUnitContactJob.Name = "txtDutyUnitContactJob";
            this.txtDutyUnitContactJob.Size = new System.Drawing.Size(190, 26);
            this.txtDutyUnitContactJob.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("仿宋", 12F);
            this.label11.Location = new System.Drawing.Point(546, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(199, 27);
            this.label11.TabIndex = 36;
            this.label11.Text = "责任单位联系人职务：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDutyUnitContactTelephone
            // 
            this.txtDutyUnitContactTelephone.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDutyUnitContactTelephone.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtDutyUnitContactTelephone.Location = new System.Drawing.Point(418, 0);
            this.txtDutyUnitContactTelephone.Margin = new System.Windows.Forms.Padding(4);
            this.txtDutyUnitContactTelephone.Name = "txtDutyUnitContactTelephone";
            this.txtDutyUnitContactTelephone.Size = new System.Drawing.Size(128, 26);
            this.txtDutyUnitContactTelephone.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("仿宋", 12F);
            this.label13.Location = new System.Drawing.Point(247, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(171, 27);
            this.label13.TabIndex = 3;
            this.label13.Text = "责任单位联系人手机：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDutyUnitContact
            // 
            this.txtDutyUnitContact.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDutyUnitContact.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtDutyUnitContact.Location = new System.Drawing.Point(155, 0);
            this.txtDutyUnitContact.Margin = new System.Windows.Forms.Padding(4);
            this.txtDutyUnitContact.Name = "txtDutyUnitContact";
            this.txtDutyUnitContact.Size = new System.Drawing.Size(92, 26);
            this.txtDutyUnitContact.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("仿宋", 12F);
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 27);
            this.label9.TabIndex = 2;
            this.label9.Text = "责任单位联系人：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txtRegisterDate);
            this.panel10.Controls.Add(this.label15);
            this.panel10.Controls.Add(this.txtTotalTimes);
            this.panel10.Controls.Add(this.label10);
            this.panel10.Controls.Add(this.txtTotalMoneys);
            this.panel10.Controls.Add(this.label14);
            this.panel10.Controls.Add(this.txtProjectMasterName);
            this.panel10.Controls.Add(this.label4);
            this.panel10.Location = new System.Drawing.Point(3, 251);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1047, 29);
            this.panel10.TabIndex = 9;
            // 
            // txtRegisterDate
            // 
            this.txtRegisterDate.CustomFormat = "yyyy年MM月dd日";
            this.txtRegisterDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtRegisterDate.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtRegisterDate.Location = new System.Drawing.Point(720, 0);
            this.txtRegisterDate.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.txtRegisterDate.Name = "txtRegisterDate";
            this.txtRegisterDate.Size = new System.Drawing.Size(141, 26);
            this.txtRegisterDate.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Font = new System.Drawing.Font("仿宋", 12F);
            this.label15.Location = new System.Drawing.Point(592, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 29);
            this.label15.TabIndex = 4;
            this.label15.Text = "年，申报日期：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalTimes
            // 
            this.txtTotalTimes.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTotalTimes.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtTotalTimes.Location = new System.Drawing.Point(534, 0);
            this.txtTotalTimes.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtTotalTimes.Name = "txtTotalTimes";
            this.txtTotalTimes.Size = new System.Drawing.Size(58, 26);
            this.txtTotalTimes.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("仿宋", 12F);
            this.label10.Location = new System.Drawing.Point(427, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 29);
            this.label10.TabIndex = 2;
            this.label10.Text = "万，总时间：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalMoneys
            // 
            this.txtTotalMoneys.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTotalMoneys.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtTotalMoneys.Location = new System.Drawing.Point(352, 0);
            this.txtTotalMoneys.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtTotalMoneys.Name = "txtTotalMoneys";
            this.txtTotalMoneys.Size = new System.Drawing.Size(75, 26);
            this.txtTotalMoneys.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Font = new System.Drawing.Font("仿宋", 12F);
            this.label14.Location = new System.Drawing.Point(247, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 29);
            this.label14.TabIndex = 3;
            this.label14.Text = "总经费：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProjectMasterName
            // 
            this.txtProjectMasterName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectMasterName.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtProjectMasterName.Location = new System.Drawing.Point(155, 0);
            this.txtProjectMasterName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProjectMasterName.Name = "txtProjectMasterName";
            this.txtProjectMasterName.Size = new System.Drawing.Size(92, 26);
            this.txtProjectMasterName.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("仿宋", 12F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 29);
            this.label4.TabIndex = 34;
            this.label4.Text = "项目负责人：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoHeight = true;
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("仿宋", 15.75F);
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblInfo.Size = new System.Drawing.Size(1072, 51);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "请科学严谨、实事求是填写，表述要清晰准确。";
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnSave);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(10, 682);
            this.plButtons.Name = "plButtons";
            this.plButtons.Padding = new System.Windows.Forms.Padding(3);
            this.plButtons.Size = new System.Drawing.Size(1072, 35);
            this.plButtons.TabIndex = 0;
            // 
            // SummaryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.plMain);
            this.Name = "SummaryEditor";
            this.Size = new System.Drawing.Size(1092, 727);
            this.plMain.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMoneys)).EndInit();
            this.plButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel plButtons;
        private AbstractEditorPlugin.Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.TextBox txtProjectTopic;
        private System.Windows.Forms.TextBox txtProjectDirection;
        private System.Windows.Forms.TextBox txtDutyUnitName;
        private System.Windows.Forms.TextBox txtDutyUnitNormalName;
        private Controls.ProjectAddressControl txtDutyUnitAddress;
        private System.Windows.Forms.ComboBox cbxSecretLevel;
        private System.Windows.Forms.TextBox txtDutyUnitContactTelephone;
        private System.Windows.Forms.TextBox txtDutyUnitContact;
        private System.Windows.Forms.NumericUpDown txtTotalTimes;
        private System.Windows.Forms.NumericUpDown txtTotalMoneys;
        private System.Windows.Forms.DateTimePicker txtRegisterDate;
        private System.Windows.Forms.ComboBox cbxDutyUnit2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDutyUnitContactJob;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProjectMasterName;
        private System.Windows.Forms.Label label4;
    }
}