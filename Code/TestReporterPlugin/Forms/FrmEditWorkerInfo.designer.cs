namespace TestReporterPlugin.Forms
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
            this.label18 = new System.Windows.Forms.Label();
            this.plPersonInfo = new System.Windows.Forms.GroupBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.dePersonBirthday = new System.Windows.Forms.DateTimePicker();
            this.txtPersonIDCard = new System.Windows.Forms.TextBox();
            this.cbxPersonSex = new System.Windows.Forms.ComboBox();
            this.txtPersonJob = new System.Windows.Forms.TextBox();
            this.txtPersonAddress = new System.Windows.Forms.TextBox();
            this.txtPersonMobilePhone = new System.Windows.Forms.TextBox();
            this.txtPersonTelephone = new System.Windows.Forms.TextBox();
            this.txtPersonSpecialty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.plWorkUnit = new System.Windows.Forms.GroupBox();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.txtUnitAddress = new System.Windows.Forms.TextBox();
            this.txtUnitContactName = new System.Windows.Forms.TextBox();
            this.txtUnitTelephone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtWorkTimeInYear = new System.Windows.Forms.NumericUpDown();
            this.cbxItemJobs = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaskContent = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.plContent.SuspendLayout();
            this.plPersonInfo.SuspendLayout();
            this.plWorkUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkTimeInYear)).BeginInit();
            this.plButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContent
            // 
            this.plContent.Controls.Add(this.label18);
            this.plContent.Controls.Add(this.plPersonInfo);
            this.plContent.Controls.Add(this.plWorkUnit);
            this.plContent.Controls.Add(this.txtWorkTimeInYear);
            this.plContent.Controls.Add(this.cbxItemJobs);
            this.plContent.Controls.Add(this.label2);
            this.plContent.Controls.Add(this.txtTaskContent);
            this.plContent.Controls.Add(this.label11);
            this.plContent.Controls.Add(this.label12);
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(0, 0);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(478, 600);
            this.plContent.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(266, 534);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 19;
            this.label18.Text = "月";
            // 
            // plPersonInfo
            // 
            this.plPersonInfo.Controls.Add(this.txtPersonName);
            this.plPersonInfo.Controls.Add(this.dePersonBirthday);
            this.plPersonInfo.Controls.Add(this.txtPersonIDCard);
            this.plPersonInfo.Controls.Add(this.cbxPersonSex);
            this.plPersonInfo.Controls.Add(this.txtPersonJob);
            this.plPersonInfo.Controls.Add(this.txtPersonAddress);
            this.plPersonInfo.Controls.Add(this.txtPersonMobilePhone);
            this.plPersonInfo.Controls.Add(this.txtPersonTelephone);
            this.plPersonInfo.Controls.Add(this.txtPersonSpecialty);
            this.plPersonInfo.Controls.Add(this.label3);
            this.plPersonInfo.Controls.Add(this.label4);
            this.plPersonInfo.Controls.Add(this.label5);
            this.plPersonInfo.Controls.Add(this.label7);
            this.plPersonInfo.Controls.Add(this.label17);
            this.plPersonInfo.Controls.Add(this.label8);
            this.plPersonInfo.Controls.Add(this.label16);
            this.plPersonInfo.Controls.Add(this.label9);
            this.plPersonInfo.Controls.Add(this.label10);
            this.plPersonInfo.Location = new System.Drawing.Point(8, 147);
            this.plPersonInfo.Name = "plPersonInfo";
            this.plPersonInfo.Size = new System.Drawing.Size(456, 279);
            this.plPersonInfo.TabIndex = 18;
            this.plPersonInfo.TabStop = false;
            this.plPersonInfo.Text = "人员信息";
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(142, 19);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(300, 21);
            this.txtPersonName.TabIndex = 5;
            // 
            // dePersonBirthday
            // 
            this.dePersonBirthday.Location = new System.Drawing.Point(142, 160);
            this.dePersonBirthday.Name = "dePersonBirthday";
            this.dePersonBirthday.Size = new System.Drawing.Size(300, 21);
            this.dePersonBirthday.TabIndex = 10;
            this.dePersonBirthday.Value = new System.DateTime(2019, 8, 22, 16, 5, 41, 162);
            // 
            // txtPersonIDCard
            // 
            this.txtPersonIDCard.Location = new System.Drawing.Point(142, 47);
            this.txtPersonIDCard.Name = "txtPersonIDCard";
            this.txtPersonIDCard.Size = new System.Drawing.Size(300, 21);
            this.txtPersonIDCard.TabIndex = 6;
            // 
            // cbxPersonSex
            // 
            this.cbxPersonSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPersonSex.DropDownWidth = 300;
            this.cbxPersonSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbxPersonSex.Location = new System.Drawing.Point(142, 131);
            this.cbxPersonSex.Name = "cbxPersonSex";
            this.cbxPersonSex.Size = new System.Drawing.Size(300, 20);
            this.cbxPersonSex.TabIndex = 9;
            // 
            // txtPersonJob
            // 
            this.txtPersonJob.Location = new System.Drawing.Point(142, 75);
            this.txtPersonJob.Name = "txtPersonJob";
            this.txtPersonJob.Size = new System.Drawing.Size(300, 21);
            this.txtPersonJob.TabIndex = 7;
            // 
            // txtPersonAddress
            // 
            this.txtPersonAddress.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonAddress.Location = new System.Drawing.Point(142, 243);
            this.txtPersonAddress.Name = "txtPersonAddress";
            this.txtPersonAddress.Size = new System.Drawing.Size(300, 21);
            this.txtPersonAddress.TabIndex = 13;
            // 
            // txtPersonMobilePhone
            // 
            this.txtPersonMobilePhone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonMobilePhone.Location = new System.Drawing.Point(142, 215);
            this.txtPersonMobilePhone.Name = "txtPersonMobilePhone";
            this.txtPersonMobilePhone.Size = new System.Drawing.Size(300, 21);
            this.txtPersonMobilePhone.TabIndex = 12;
            // 
            // txtPersonTelephone
            // 
            this.txtPersonTelephone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonTelephone.Location = new System.Drawing.Point(142, 187);
            this.txtPersonTelephone.Name = "txtPersonTelephone";
            this.txtPersonTelephone.Size = new System.Drawing.Size(300, 21);
            this.txtPersonTelephone.TabIndex = 11;
            // 
            // txtPersonSpecialty
            // 
            this.txtPersonSpecialty.Location = new System.Drawing.Point(142, 103);
            this.txtPersonSpecialty.Name = "txtPersonSpecialty";
            this.txtPersonSpecialty.Size = new System.Drawing.Size(300, 21);
            this.txtPersonSpecialty.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "  姓    名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = " 身 份 证：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "职务职称：";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(65, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "  技术方向：";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(65, 246);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 14);
            this.label17.TabIndex = 8;
            this.label17.Text = "  通信地址：";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(53, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "    性    别：";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(53, 218);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 14);
            this.label16.TabIndex = 8;
            this.label16.Text = "    手    机：";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(65, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "  出生年月：";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(53, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 14);
            this.label10.TabIndex = 8;
            this.label10.Text = "    座    机：";
            // 
            // plWorkUnit
            // 
            this.plWorkUnit.Controls.Add(this.txtUnitName);
            this.plWorkUnit.Controls.Add(this.txtUnitAddress);
            this.plWorkUnit.Controls.Add(this.txtUnitContactName);
            this.plWorkUnit.Controls.Add(this.txtUnitTelephone);
            this.plWorkUnit.Controls.Add(this.label6);
            this.plWorkUnit.Controls.Add(this.label13);
            this.plWorkUnit.Controls.Add(this.label14);
            this.plWorkUnit.Controls.Add(this.label15);
            this.plWorkUnit.Location = new System.Drawing.Point(8, 2);
            this.plWorkUnit.Name = "plWorkUnit";
            this.plWorkUnit.Size = new System.Drawing.Size(456, 140);
            this.plWorkUnit.TabIndex = 17;
            this.plWorkUnit.TabStop = false;
            this.plWorkUnit.Text = "工作单位";
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(142, 17);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(300, 21);
            this.txtUnitName.TabIndex = 1;
            // 
            // txtUnitAddress
            // 
            this.txtUnitAddress.Location = new System.Drawing.Point(142, 45);
            this.txtUnitAddress.Name = "txtUnitAddress";
            this.txtUnitAddress.Size = new System.Drawing.Size(300, 21);
            this.txtUnitAddress.TabIndex = 2;
            // 
            // txtUnitContactName
            // 
            this.txtUnitContactName.Location = new System.Drawing.Point(142, 73);
            this.txtUnitContactName.Name = "txtUnitContactName";
            this.txtUnitContactName.Size = new System.Drawing.Size(300, 21);
            this.txtUnitContactName.TabIndex = 3;
            // 
            // txtUnitTelephone
            // 
            this.txtUnitTelephone.Location = new System.Drawing.Point(142, 101);
            this.txtUnitTelephone.Name = "txtUnitTelephone";
            this.txtUnitTelephone.Size = new System.Drawing.Size(300, 21);
            this.txtUnitTelephone.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(78, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "单位名称：";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(78, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 14);
            this.label13.TabIndex = 8;
            this.label13.Text = "通信地址：";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(72, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 14);
            this.label14.TabIndex = 8;
            this.label14.Text = " 联 系 人：";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(78, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 14);
            this.label15.TabIndex = 8;
            this.label15.Text = "联系电话：";
            // 
            // txtWorkTimeInYear
            // 
            this.txtWorkTimeInYear.Location = new System.Drawing.Point(152, 530);
            this.txtWorkTimeInYear.Name = "txtWorkTimeInYear";
            this.txtWorkTimeInYear.Size = new System.Drawing.Size(112, 21);
            this.txtWorkTimeInYear.TabIndex = 16;
            // 
            // cbxItemJobs
            // 
            this.cbxItemJobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxItemJobs.DropDownWidth = 300;
            this.cbxItemJobs.Location = new System.Drawing.Point(152, 436);
            this.cbxItemJobs.Name = "cbxItemJobs";
            this.cbxItemJobs.Size = new System.Drawing.Size(313, 20);
            this.cbxItemJobs.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "每年为本项目工作时间：";
            // 
            // txtTaskContent
            // 
            this.txtTaskContent.Location = new System.Drawing.Point(152, 464);
            this.txtTaskContent.Multiline = true;
            this.txtTaskContent.Name = "txtTaskContent";
            this.txtTaskContent.Size = new System.Drawing.Size(313, 57);
            this.txtTaskContent.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-24, 481);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "                  任务分工：";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-18, 439);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 14);
            this.label12.TabIndex = 8;
            this.label12.Text = "               项目中职务：";
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnOK);
            this.plButtons.Controls.Add(this.btnCancel);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(0, 562);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(478, 38);
            this.plButtons.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Font = new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(298, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 38);
            this.btnOK.TabIndex = 17;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Font = new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(388, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 38);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmEditWorkerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 600);
            this.Controls.Add(this.plContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmEditWorkerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加/修改负责人及研究骨干";
            this.plContent.ResumeLayout(false);
            this.plContent.PerformLayout();
            this.plPersonInfo.ResumeLayout(false);
            this.plPersonInfo.PerformLayout();
            this.plWorkUnit.ResumeLayout(false);
            this.plWorkUnit.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbxItemJobs;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUnitTelephone;
        private System.Windows.Forms.TextBox txtUnitContactName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtUnitAddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox plWorkUnit;
        private System.Windows.Forms.GroupBox plPersonInfo;
        private System.Windows.Forms.TextBox txtPersonAddress;
        private System.Windows.Forms.TextBox txtPersonMobilePhone;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
    }
}