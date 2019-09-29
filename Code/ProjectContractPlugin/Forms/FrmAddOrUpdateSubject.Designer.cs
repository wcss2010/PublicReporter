namespace ProjectContractPlugin.Forms
{
    partial class FrmAddOrUpdateSubject
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtWorkDest = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.txtWorkContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnitTask = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWorkUnit = new System.Windows.Forms.TextBox();
            this.txtWorkOrg = new System.Windows.Forms.ComboBox();
            this.txtWorkAddress = new ProjectContractPlugin.Editor.ProjectAddressEditor();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(37, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "课题名称：";
            // 
            // txtWorkDest
            // 
            this.txtWorkDest.AcceptsReturn = true;
            this.txtWorkDest.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtWorkDest.Location = new System.Drawing.Point(148, 58);
            this.txtWorkDest.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkDest.Multiline = true;
            this.txtWorkDest.Name = "txtWorkDest";
            this.txtWorkDest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWorkDest.Size = new System.Drawing.Size(647, 119);
            this.txtWorkDest.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnSave.Location = new System.Drawing.Point(550, 638);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 43);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("仿宋", 12F);
            this.label2.Location = new System.Drawing.Point(38, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "研究目标：";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnClose.Location = new System.Drawing.Point(668, 638);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(148, 19);
            this.txtSubjectName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(647, 26);
            this.txtSubjectName.TabIndex = 4;
            // 
            // txtWorkContent
            // 
            this.txtWorkContent.AcceptsReturn = true;
            this.txtWorkContent.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtWorkContent.Location = new System.Drawing.Point(148, 192);
            this.txtWorkContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkContent.Multiline = true;
            this.txtWorkContent.Name = "txtWorkContent";
            this.txtWorkContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWorkContent.Size = new System.Drawing.Size(647, 141);
            this.txtWorkContent.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(38, 268);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "研究内容：";
            // 
            // txtUnitTask
            // 
            this.txtUnitTask.AcceptsReturn = true;
            this.txtUnitTask.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtUnitTask.Location = new System.Drawing.Point(147, 350);
            this.txtUnitTask.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitTask.Multiline = true;
            this.txtUnitTask.Name = "txtUnitTask";
            this.txtUnitTask.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtUnitTask.Size = new System.Drawing.Size(647, 116);
            this.txtUnitTask.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("仿宋", 12F);
            this.label4.Location = new System.Drawing.Point(3, 384);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 59);
            this.label4.TabIndex = 7;
            this.label4.Text = "参加单位分工：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("仿宋", 12F);
            this.label5.Location = new System.Drawing.Point(37, 489);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "负责单位：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("仿宋", 12F);
            this.label6.Location = new System.Drawing.Point(37, 537);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "所属部门：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("仿宋", 12F);
            this.label7.Location = new System.Drawing.Point(37, 579);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "所属地点：";
            // 
            // txtWorkUnit
            // 
            this.txtWorkUnit.Location = new System.Drawing.Point(147, 486);
            this.txtWorkUnit.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkUnit.Name = "txtWorkUnit";
            this.txtWorkUnit.Size = new System.Drawing.Size(647, 26);
            this.txtWorkUnit.TabIndex = 4;
            // 
            // txtWorkOrg
            // 
            this.txtWorkOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtWorkOrg.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtWorkOrg.FormattingEnabled = true;
            this.txtWorkOrg.ItemHeight = 16;
            this.txtWorkOrg.Items.AddRange(new object[] {
            "陆军",
            "海军",
            "空军",
            "火箭军",
            "战略支援部队",
            "联合勤务保障部队",
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
            this.txtWorkOrg.Location = new System.Drawing.Point(147, 534);
            this.txtWorkOrg.Name = "txtWorkOrg";
            this.txtWorkOrg.Size = new System.Drawing.Size(261, 24);
            this.txtWorkOrg.TabIndex = 10;
            // 
            // txtWorkAddress
            // 
            this.txtWorkAddress.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtWorkAddress.Location = new System.Drawing.Point(147, 576);
            this.txtWorkAddress.Margin = new System.Windows.Forms.Padding(5);
            this.txtWorkAddress.Name = "txtWorkAddress";
            this.txtWorkAddress.Size = new System.Drawing.Size(519, 27);
            this.txtWorkAddress.TabIndex = 11;
            // 
            // FrmAddOrUpdateSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 681);
            this.Controls.Add(this.txtWorkAddress);
            this.Controls.Add(this.txtWorkOrg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUnitTask);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWorkContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWorkUnit);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtWorkDest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddOrUpdateSubject";
            this.Text = "新增/编辑课题情况";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWorkDest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.TextBox txtWorkContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnitTask;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWorkUnit;
        private System.Windows.Forms.ComboBox txtWorkOrg;
        private Editor.ProjectAddressEditor txtWorkAddress;
    }
}