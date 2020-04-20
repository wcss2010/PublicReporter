namespace ProjectContractPlugin.Forms
{
    partial class FrmNewProject
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbFromReportPKG = new System.Windows.Forms.RadioButton();
            this.rbFromNormal = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbFromNormal);
            this.panel1.Controls.Add(this.rbFromReportPKG);
            this.panel1.Location = new System.Drawing.Point(25, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 133);
            this.panel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 12F);
            this.btnOK.Location = new System.Drawing.Point(104, 175);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 38);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F);
            this.btnCancel.Location = new System.Drawing.Point(272, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbFromReportPKG
            // 
            this.rbFromReportPKG.AutoSize = true;
            this.rbFromReportPKG.Font = new System.Drawing.Font("宋体", 12F);
            this.rbFromReportPKG.Location = new System.Drawing.Point(104, 30);
            this.rbFromReportPKG.Name = "rbFromReportPKG";
            this.rbFromReportPKG.Size = new System.Drawing.Size(202, 20);
            this.rbFromReportPKG.TabIndex = 0;
            this.rbFromReportPKG.TabStop = true;
            this.rbFromReportPKG.Text = "建议书数据包初始化项目";
            this.rbFromReportPKG.UseVisualStyleBackColor = true;
            // 
            // rbFromNormal
            // 
            this.rbFromNormal.AutoSize = true;
            this.rbFromNormal.Checked = true;
            this.rbFromNormal.Font = new System.Drawing.Font("宋体", 12F);
            this.rbFromNormal.Location = new System.Drawing.Point(104, 73);
            this.rbFromNormal.Name = "rbFromNormal";
            this.rbFromNormal.Size = new System.Drawing.Size(170, 20);
            this.rbFromNormal.TabIndex = 0;
            this.rbFromNormal.TabStop = true;
            this.rbFromNormal.Text = "示例数据初始化项目";
            this.rbFromNormal.UseVisualStyleBackColor = true;
            // 
            // FrmNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 240);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewProject";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建项目";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbFromReportPKG;
        private System.Windows.Forms.RadioButton rbFromNormal;
    }
}