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
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnitContactPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUnitContactAddress = new Controls.ProjectAddressControl();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUnitContact = new System.Windows.Forms.TextBox();
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
            this.btnSave.Location = new System.Drawing.Point(550, 311);
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
            this.btnClose.Location = new System.Drawing.Point(668, 311);
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
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(196, 81);
            this.txtUnitName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(581, 26);
            this.txtUnitName.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(68, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "责任单位名称：";
            // 
            // txtUnitContactPhone
            // 
            this.txtUnitContactPhone.Location = new System.Drawing.Point(196, 198);
            this.txtUnitContactPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitContactPhone.Name = "txtUnitContactPhone";
            this.txtUnitContactPhone.Size = new System.Drawing.Size(583, 26);
            this.txtUnitContactPhone.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("仿宋", 12F);
            this.label7.Location = new System.Drawing.Point(20, 201);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "责任单位联系人电话：";
            // 
            // txtUnitContactAddress
            // 
            this.txtUnitContactAddress.Location = new System.Drawing.Point(196, 257);
            this.txtUnitContactAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitContactAddress.Name = "txtUnitContactAddress";
            this.txtUnitContactAddress.Size = new System.Drawing.Size(581, 26);
            this.txtUnitContactAddress.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("仿宋", 12F);
            this.label8.Location = new System.Drawing.Point(36, 260);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "责任单位通信地址：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("仿宋", 12F);
            this.label11.Location = new System.Drawing.Point(52, 140);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "责任单位联系人：";
            // 
            // txtUnitContact
            // 
            this.txtUnitContact.Location = new System.Drawing.Point(196, 137);
            this.txtUnitContact.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitContact.Name = "txtUnitContact";
            this.txtUnitContact.Size = new System.Drawing.Size(581, 26);
            this.txtUnitContact.TabIndex = 14;
            // 
            // FrmAddOrUpdateSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 373);
            this.Controls.Add(this.txtUnitContactAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUnitContactPhone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUnitContact);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtUnitName);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnitContactPhone;
        private System.Windows.Forms.Label label7;
        private Controls.ProjectAddressControl txtUnitContactAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUnitContact;
    }
}