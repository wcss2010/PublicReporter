namespace ProjectStrategicLeadershipPlugin.Forms
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUnitContactAddress = new ProjectStrategicLeadershipPlugin.Controls.ProjectAddressControl();
            this.label8 = new System.Windows.Forms.Label();
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
            this.label1.Text = "研究内容名称：";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnSave.Location = new System.Drawing.Point(549, 128);
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
            this.btnClose.Location = new System.Drawing.Point(667, 128);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(196, 19);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(581, 26);
            this.txtName.TabIndex = 4;
            // 
            // txtUnitContactAddress
            // 
            this.txtUnitContactAddress.EnabledEditAddressDetail = true;
            this.txtUnitContactAddress.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtUnitContactAddress.Location = new System.Drawing.Point(198, 75);
            this.txtUnitContactAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitContactAddress.Name = "txtUnitContactAddress";
            this.txtUnitContactAddress.Size = new System.Drawing.Size(581, 26);
            this.txtUnitContactAddress.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("仿宋", 12F);
            this.label8.Location = new System.Drawing.Point(38, 78);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "责任单位通信地址：";
            // 
            // FrmAddOrUpdateSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 189);
            this.Controls.Add(this.txtUnitContactAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddOrUpdateSubject";
            this.Text = "新增/编辑研究内容";
            this.Load += new System.EventHandler(this.FrmAddOrUpdateWorker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtName;
        private Controls.ProjectAddressControl txtUnitContactAddress;
        private System.Windows.Forms.Label label8;
    }
}