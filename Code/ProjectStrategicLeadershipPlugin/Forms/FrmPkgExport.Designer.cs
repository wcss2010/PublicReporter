namespace ProjectStrategicLeadershipPlugin.Forms
{
    partial class FrmPkgExport
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.llMainDocument = new System.Windows.Forms.LinkLabel();
            this.txtReadme = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnCancel.Location = new System.Drawing.Point(422, 388);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 31);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnOK.Location = new System.Drawing.Point(304, 388);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 31);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确认导出";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // llMainDocument
            // 
            this.llMainDocument.Location = new System.Drawing.Point(517, 392);
            this.llMainDocument.Name = "llMainDocument";
            this.llMainDocument.Size = new System.Drawing.Size(280, 24);
            this.llMainDocument.TabIndex = 8;
            this.llMainDocument.TabStop = true;
            this.llMainDocument.Text = "查看报告";
            this.llMainDocument.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llMainDocument.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llMainDocument_LinkClicked);
            // 
            // txtReadme
            // 
            this.txtReadme.Enabled = false;
            this.txtReadme.Location = new System.Drawing.Point(12, 12);
            this.txtReadme.Name = "txtReadme";
            this.txtReadme.Size = new System.Drawing.Size(787, 369);
            this.txtReadme.TabIndex = 9;
            this.txtReadme.Text = "";
            // 
            // FrmPkgExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 432);
            this.Controls.Add(this.txtReadme);
            this.Controls.Add(this.llMainDocument);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPkgExport";
            this.Text = "数据包导出";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel llMainDocument;
        private System.Windows.Forms.RichTextBox txtReadme;
    }
}