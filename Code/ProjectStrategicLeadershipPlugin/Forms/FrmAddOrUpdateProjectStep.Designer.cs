namespace ProjectStrategicLeadershipPlugin.Forms
{
    partial class FrmAddOrUpdateProjectStep
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTag1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTag3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTag2 = new System.Windows.Forms.TextBox();
            this.cbxMonths = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(68, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "阶段时间(月)：";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnSave.Location = new System.Drawing.Point(551, 593);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 43);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnClose.Location = new System.Drawing.Point(669, 593);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTag1
            // 
            this.txtTag1.Location = new System.Drawing.Point(196, 67);
            this.txtTag1.Margin = new System.Windows.Forms.Padding(4);
            this.txtTag1.Multiline = true;
            this.txtTag1.Name = "txtTag1";
            this.txtTag1.Size = new System.Drawing.Size(581, 157);
            this.txtTag1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(100, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "完成内容：";
            // 
            // txtTag3
            // 
            this.txtTag3.Location = new System.Drawing.Point(196, 437);
            this.txtTag3.Margin = new System.Windows.Forms.Padding(4);
            this.txtTag3.Multiline = true;
            this.txtTag3.Name = "txtTag3";
            this.txtTag3.Size = new System.Drawing.Size(583, 136);
            this.txtTag3.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("仿宋", 12F);
            this.label7.Location = new System.Drawing.Point(100, 498);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "考核指标：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("仿宋", 12F);
            this.label11.Location = new System.Drawing.Point(100, 320);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "阶段成果：";
            // 
            // txtTag2
            // 
            this.txtTag2.Location = new System.Drawing.Point(196, 249);
            this.txtTag2.Margin = new System.Windows.Forms.Padding(4);
            this.txtTag2.Multiline = true;
            this.txtTag2.Name = "txtTag2";
            this.txtTag2.Size = new System.Drawing.Size(581, 163);
            this.txtTag2.TabIndex = 14;
            // 
            // cbxMonths
            // 
            this.cbxMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonths.FormattingEnabled = true;
            this.cbxMonths.Items.AddRange(new object[] {
            "18",
            "12",
            "12",
            "18"});
            this.cbxMonths.Location = new System.Drawing.Point(195, 19);
            this.cbxMonths.Name = "cbxMonths";
            this.cbxMonths.Size = new System.Drawing.Size(142, 24);
            this.cbxMonths.TabIndex = 17;
            // 
            // FrmAddOrUpdateProjectStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 655);
            this.Controls.Add(this.cbxMonths);
            this.Controls.Add(this.txtTag3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTag2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTag1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddOrUpdateProjectStep";
            this.Text = "新增/编辑项目阶段";
            this.Load += new System.EventHandler(this.FrmAddOrUpdateWorker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTag1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTag3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTag2;
        private System.Windows.Forms.ComboBox cbxMonths;
    }
}