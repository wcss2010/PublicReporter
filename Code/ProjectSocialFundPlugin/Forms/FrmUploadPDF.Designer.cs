namespace ProjectSocialFundPlugin.Forms
{
    partial class FrmUploadPDF
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
            this.txtImgFile = new System.Windows.Forms.LinkLabel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ofdUpload = new System.Windows.Forms.OpenFileDialog();
            this.llTemplete = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtImgFile
            // 
            this.txtImgFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtImgFile.Location = new System.Drawing.Point(76, 20);
            this.txtImgFile.Name = "txtImgFile";
            this.txtImgFile.Size = new System.Drawing.Size(526, 29);
            this.txtImgFile.TabIndex = 22;
            this.txtImgFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtImgFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txtImgFile_LinkClicked);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(608, 20);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(50, 29);
            this.btnSelect.TabIndex = 21;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("仿宋", 12F);
            this.label11.Location = new System.Drawing.Point(13, 26);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "附件：";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnClose.Location = new System.Drawing.Point(547, 66);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 43);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnSave.Location = new System.Drawing.Point(429, 66);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 43);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ofdUpload
            // 
            this.ofdUpload.Filter = "*.PDF|*.PDF";
            // 
            // llTemplete
            // 
            this.llTemplete.Font = new System.Drawing.Font("仿宋", 12F);
            this.llTemplete.Location = new System.Drawing.Point(133, 75);
            this.llTemplete.Name = "llTemplete";
            this.llTemplete.Size = new System.Drawing.Size(280, 25);
            this.llTemplete.TabIndex = 23;
            this.llTemplete.TabStop = true;
            this.llTemplete.Text = "点击下载\"文档模板.doc\"";
            this.llTemplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llTemplete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llTemplete_LinkClicked);
            // 
            // FrmUploadPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 124);
            this.Controls.Add(this.llTemplete);
            this.Controls.Add(this.txtImgFile);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUploadPDF";
            this.Text = "上传PDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel txtImgFile;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog ofdUpload;
        private System.Windows.Forms.LinkLabel llTemplete;
    }
}