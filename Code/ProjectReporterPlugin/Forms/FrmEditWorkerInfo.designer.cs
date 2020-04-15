namespace ProjectReporterPlugin.Forms
{
    partial class FrmEditWorkerInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plContent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbIsOnlySubject = new System.Windows.Forms.RadioButton();
            this.rbIsProjectAndSubject = new System.Windows.Forms.RadioButton();
            this.rbIsOnlyProject = new System.Windows.Forms.RadioButton();
            this.cbxJobInProjects = new System.Windows.Forms.ComboBox();
            this.dePersonBirthday = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.cbxSubjects = new System.Windows.Forms.ComboBox();
            this.txtPersonIDCard = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.txtTaskContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWorkTimeInYear = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPersonJob = new System.Windows.Forms.TextBox();
            this.txtPersonMobilePhone = new System.Windows.Forms.TextBox();
            this.cbxPersonSex = new System.Windows.Forms.ComboBox();
            this.txtPersonTelephone = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPersonSpecialty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.plButtons = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.plContent.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTimeInYear)).BeginInit();
            this.plButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContent
            // 
            this.plContent.Controls.Add(this.lblError);
            this.plContent.Controls.Add(this.panel1);
            this.plContent.Controls.Add(this.cbxJobInProjects);
            this.plContent.Controls.Add(this.dePersonBirthday);
            this.plContent.Controls.Add(this.label1);
            this.plContent.Controls.Add(this.txtPersonName);
            this.plContent.Controls.Add(this.cbxSubjects);
            this.plContent.Controls.Add(this.txtPersonIDCard);
            this.plContent.Controls.Add(this.label12);
            this.plContent.Controls.Add(this.label9);
            this.plContent.Controls.Add(this.label18);
            this.plContent.Controls.Add(this.txtUnitName);
            this.plContent.Controls.Add(this.txtTaskContent);
            this.plContent.Controls.Add(this.label2);
            this.plContent.Controls.Add(this.label4);
            this.plContent.Controls.Add(this.txtWorkTimeInYear);
            this.plContent.Controls.Add(this.label11);
            this.plContent.Controls.Add(this.txtPersonJob);
            this.plContent.Controls.Add(this.txtPersonMobilePhone);
            this.plContent.Controls.Add(this.cbxPersonSex);
            this.plContent.Controls.Add(this.txtPersonTelephone);
            this.plContent.Controls.Add(this.label16);
            this.plContent.Controls.Add(this.label5);
            this.plContent.Controls.Add(this.label10);
            this.plContent.Controls.Add(this.txtPersonSpecialty);
            this.plContent.Controls.Add(this.label6);
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Controls.Add(this.label7);
            this.plContent.Controls.Add(this.label3);
            this.plContent.Controls.Add(this.label8);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Font = new System.Drawing.Font("仿宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plContent.Location = new System.Drawing.Point(0, 0);
            this.plContent.Margin = new System.Windows.Forms.Padding(4);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(836, 568);
            this.plContent.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbIsOnlySubject);
            this.panel1.Controls.Add(this.rbIsProjectAndSubject);
            this.panel1.Controls.Add(this.rbIsOnlyProject);
            this.panel1.Font = new System.Drawing.Font("仿宋", 12F);
            this.panel1.Location = new System.Drawing.Point(144, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 33);
            this.panel1.TabIndex = 35;
            // 
            // rbIsOnlySubject
            // 
            this.rbIsOnlySubject.AutoSize = true;
            this.rbIsOnlySubject.Checked = true;
            this.rbIsOnlySubject.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbIsOnlySubject.Location = new System.Drawing.Point(324, 0);
            this.rbIsOnlySubject.Name = "rbIsOnlySubject";
            this.rbIsOnlySubject.Size = new System.Drawing.Size(122, 33);
            this.rbIsOnlySubject.TabIndex = 2;
            this.rbIsOnlySubject.TabStop = true;
            this.rbIsOnlySubject.Text = "仅为课题角色";
            this.rbIsOnlySubject.UseVisualStyleBackColor = true;
            this.rbIsOnlySubject.CheckedChanged += new System.EventHandler(this.rbIsOnlyProject_CheckedChanged);
            // 
            // rbIsProjectAndSubject
            // 
            this.rbIsProjectAndSubject.AutoSize = true;
            this.rbIsProjectAndSubject.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbIsProjectAndSubject.Location = new System.Drawing.Point(138, 0);
            this.rbIsProjectAndSubject.Name = "rbIsProjectAndSubject";
            this.rbIsProjectAndSubject.Size = new System.Drawing.Size(186, 33);
            this.rbIsProjectAndSubject.TabIndex = 1;
            this.rbIsProjectAndSubject.Text = "项目负责人兼课题角色";
            this.rbIsProjectAndSubject.UseVisualStyleBackColor = true;
            this.rbIsProjectAndSubject.CheckedChanged += new System.EventHandler(this.rbIsOnlyProject_CheckedChanged);
            // 
            // rbIsOnlyProject
            // 
            this.rbIsOnlyProject.AutoSize = true;
            this.rbIsOnlyProject.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbIsOnlyProject.Location = new System.Drawing.Point(0, 0);
            this.rbIsOnlyProject.Name = "rbIsOnlyProject";
            this.rbIsOnlyProject.Size = new System.Drawing.Size(138, 33);
            this.rbIsOnlyProject.TabIndex = 0;
            this.rbIsOnlyProject.Text = "仅为项目负责人";
            this.rbIsOnlyProject.UseVisualStyleBackColor = true;
            this.rbIsOnlyProject.CheckedChanged += new System.EventHandler(this.rbIsOnlyProject_CheckedChanged);
            // 
            // cbxJobInProjects
            // 
            this.cbxJobInProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJobInProjects.Font = new System.Drawing.Font("仿宋", 12F);
            this.cbxJobInProjects.FormattingEnabled = true;
            this.cbxJobInProjects.Items.AddRange(new object[] {
            "负责人",
            "成员"});
            this.cbxJobInProjects.Location = new System.Drawing.Point(599, 461);
            this.cbxJobInProjects.Margin = new System.Windows.Forms.Padding(4);
            this.cbxJobInProjects.Name = "cbxJobInProjects";
            this.cbxJobInProjects.Size = new System.Drawing.Size(167, 24);
            this.cbxJobInProjects.TabIndex = 34;
            // 
            // dePersonBirthday
            // 
            this.dePersonBirthday.Enabled = false;
            this.dePersonBirthday.Font = new System.Drawing.Font("仿宋", 12F);
            this.dePersonBirthday.Location = new System.Drawing.Point(599, 269);
            this.dePersonBirthday.Margin = new System.Windows.Forms.Padding(4);
            this.dePersonBirthday.Name = "dePersonBirthday";
            this.dePersonBirthday.Size = new System.Drawing.Size(167, 26);
            this.dePersonBirthday.TabIndex = 10;
            this.dePersonBirthday.Value = new System.DateTime(2019, 8, 22, 16, 5, 41, 162);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(79, 461);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "课题：";
            // 
            // txtPersonName
            // 
            this.txtPersonName.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtPersonName.Location = new System.Drawing.Point(144, 30);
            this.txtPersonName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(260, 26);
            this.txtPersonName.TabIndex = 5;
            // 
            // cbxSubjects
            // 
            this.cbxSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSubjects.Font = new System.Drawing.Font("仿宋", 12F);
            this.cbxSubjects.FormattingEnabled = true;
            this.cbxSubjects.Items.AddRange(new object[] {
            "负责人",
            "成员"});
            this.cbxSubjects.Location = new System.Drawing.Point(144, 461);
            this.cbxSubjects.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSubjects.Name = "cbxSubjects";
            this.cbxSubjects.Size = new System.Drawing.Size(260, 24);
            this.cbxSubjects.TabIndex = 32;
            // 
            // txtPersonIDCard
            // 
            this.txtPersonIDCard.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtPersonIDCard.Location = new System.Drawing.Point(144, 269);
            this.txtPersonIDCard.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonIDCard.Name = "txtPersonIDCard";
            this.txtPersonIDCard.Size = new System.Drawing.Size(260, 26);
            this.txtPersonIDCard.TabIndex = 6;
            this.txtPersonIDCard.TextChanged += new System.EventHandler(this.txtPersonIDCard_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("仿宋", 12F);
            this.label12.Location = new System.Drawing.Point(492, 467);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 16);
            this.label12.TabIndex = 31;
            this.label12.Text = "课题中职务：";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("仿宋", 12F);
            this.label9.Location = new System.Drawing.Point(531, 272);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 19);
            this.label9.TabIndex = 8;
            this.label9.Text = "生日：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("仿宋", 12F);
            this.label18.Location = new System.Drawing.Point(190, 411);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 16);
            this.label18.TabIndex = 19;
            this.label18.Text = "月";
            // 
            // txtUnitName
            // 
            this.txtUnitName.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtUnitName.Location = new System.Drawing.Point(144, 212);
            this.txtUnitName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(621, 26);
            this.txtUnitName.TabIndex = 1;
            // 
            // txtTaskContent
            // 
            this.txtTaskContent.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtTaskContent.Location = new System.Drawing.Point(144, 326);
            this.txtTaskContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtTaskContent.Name = "txtTaskContent";
            this.txtTaskContent.Size = new System.Drawing.Size(260, 26);
            this.txtTaskContent.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("仿宋", 12F);
            this.label2.Location = new System.Drawing.Point(465, 329);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "每年投入时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("仿宋", 12F);
            this.label4.Location = new System.Drawing.Point(47, 272);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "身份证号：";
            // 
            // txtWorkTimeInYear
            // 
            this.txtWorkTimeInYear.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtWorkTimeInYear.Location = new System.Drawing.Point(599, 326);
            this.txtWorkTimeInYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkTimeInYear.Name = "txtWorkTimeInYear";
            this.txtWorkTimeInYear.Size = new System.Drawing.Size(167, 26);
            this.txtWorkTimeInYear.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("仿宋", 12F);
            this.label11.Location = new System.Drawing.Point(47, 329);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "任务分工：";
            // 
            // txtPersonJob
            // 
            this.txtPersonJob.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtPersonJob.Location = new System.Drawing.Point(144, 89);
            this.txtPersonJob.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonJob.Name = "txtPersonJob";
            this.txtPersonJob.Size = new System.Drawing.Size(260, 26);
            this.txtPersonJob.TabIndex = 7;
            // 
            // txtPersonMobilePhone
            // 
            this.txtPersonMobilePhone.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtPersonMobilePhone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonMobilePhone.Location = new System.Drawing.Point(599, 153);
            this.txtPersonMobilePhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonMobilePhone.Name = "txtPersonMobilePhone";
            this.txtPersonMobilePhone.Size = new System.Drawing.Size(167, 26);
            this.txtPersonMobilePhone.TabIndex = 12;
            // 
            // cbxPersonSex
            // 
            this.cbxPersonSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPersonSex.DropDownWidth = 300;
            this.cbxPersonSex.Font = new System.Drawing.Font("仿宋", 12F);
            this.cbxPersonSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbxPersonSex.Location = new System.Drawing.Point(599, 31);
            this.cbxPersonSex.Margin = new System.Windows.Forms.Padding(4);
            this.cbxPersonSex.Name = "cbxPersonSex";
            this.cbxPersonSex.Size = new System.Drawing.Size(167, 24);
            this.cbxPersonSex.TabIndex = 9;
            // 
            // txtPersonTelephone
            // 
            this.txtPersonTelephone.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtPersonTelephone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonTelephone.Location = new System.Drawing.Point(144, 150);
            this.txtPersonTelephone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonTelephone.Name = "txtPersonTelephone";
            this.txtPersonTelephone.Size = new System.Drawing.Size(260, 26);
            this.txtPersonTelephone.TabIndex = 11;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("仿宋", 12F);
            this.label16.Location = new System.Drawing.Point(505, 157);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 19);
            this.label16.TabIndex = 8;
            this.label16.Text = "    手机：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("仿宋", 12F);
            this.label5.Location = new System.Drawing.Point(79, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "职称：";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("仿宋", 12F);
            this.label10.Location = new System.Drawing.Point(80, 153);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 19);
            this.label10.TabIndex = 8;
            this.label10.Text = "电话：";
            // 
            // txtPersonSpecialty
            // 
            this.txtPersonSpecialty.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtPersonSpecialty.Location = new System.Drawing.Point(599, 89);
            this.txtPersonSpecialty.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonSpecialty.Name = "txtPersonSpecialty";
            this.txtPersonSpecialty.Size = new System.Drawing.Size(167, 26);
            this.txtPersonSpecialty.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("仿宋", 12F);
            this.label6.Location = new System.Drawing.Point(47, 216);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "工作单位：";
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnOK);
            this.plButtons.Controls.Add(this.btnCancel);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Font = new System.Drawing.Font("仿宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plButtons.Location = new System.Drawing.Point(0, 528);
            this.plButtons.Margin = new System.Windows.Forms.Padding(4);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(836, 40);
            this.plButtons.TabIndex = 7;
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(150, 297);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(167, 19);
            this.lblError.TabIndex = 33;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(662, 0);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 40);
            this.btnOK.TabIndex = 17;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(749, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 40);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("仿宋", 12F);
            this.label7.Location = new System.Drawing.Point(537, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "专业：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(65, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "  姓名：";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("仿宋", 12F);
            this.label8.Location = new System.Drawing.Point(505, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "    性别：";
            // 
            // FrmEditWorkerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 568);
            this.Controls.Add(this.plContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditWorkerInfo";
            this.Text = "添加/修改负责人及研究骨干";
            this.plContent.ResumeLayout(false);
            this.plContent.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTimeInYear)).EndInit();
            this.plButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.DateTimePicker dePersonBirthday;
        private System.Windows.Forms.ComboBox cbxPersonSex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaskContent;
        private System.Windows.Forms.TextBox txtPersonTelephone;
        private System.Windows.Forms.TextBox txtPersonSpecialty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPersonJob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPersonIDCard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown txtWorkTimeInYear;
        private System.Windows.Forms.TextBox txtPersonMobilePhone;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbIsOnlySubject;
        private System.Windows.Forms.RadioButton rbIsProjectAndSubject;
        private System.Windows.Forms.RadioButton rbIsOnlyProject;
        private System.Windows.Forms.ComboBox cbxJobInProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSubjects;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblError;
    }
}