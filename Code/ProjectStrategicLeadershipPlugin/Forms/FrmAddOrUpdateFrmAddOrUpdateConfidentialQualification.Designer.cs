namespace ProjectStrategicLeadershipPlugin.Forms
{
    partial class FrmAddOrUpdateConfidentialQualification
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
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtImgFile = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbNormalUnit = new System.Windows.Forms.RadioButton();
            this.rbArmyUnit = new System.Windows.Forms.RadioButton();
            this.ofdUpload = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "单位名称：";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnSave.Location = new System.Drawing.Point(477, 150);
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
            this.btnClose.Location = new System.Drawing.Point(595, 150);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(125, 18);
            this.txtUnitName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(581, 26);
            this.txtUnitName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(29, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "单位类型：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("仿宋", 12F);
            this.label11.Location = new System.Drawing.Point(61, 110);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "附件：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(656, 104);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(50, 29);
            this.btnSelect.TabIndex = 16;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtImgFile
            // 
            this.txtImgFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtImgFile.Location = new System.Drawing.Point(124, 104);
            this.txtImgFile.Name = "txtImgFile";
            this.txtImgFile.Size = new System.Drawing.Size(526, 29);
            this.txtImgFile.TabIndex = 17;
            this.txtImgFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtImgFile.Click += new System.EventHandler(this.txtImgFile_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbArmyUnit);
            this.panel1.Controls.Add(this.rbNormalUnit);
            this.panel1.Location = new System.Drawing.Point(125, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 26);
            this.panel1.TabIndex = 18;
            // 
            // rbNormalUnit
            // 
            this.rbNormalUnit.AutoSize = true;
            this.rbNormalUnit.Checked = true;
            this.rbNormalUnit.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbNormalUnit.Location = new System.Drawing.Point(0, 0);
            this.rbNormalUnit.Name = "rbNormalUnit";
            this.rbNormalUnit.Size = new System.Drawing.Size(106, 26);
            this.rbNormalUnit.TabIndex = 0;
            this.rbNormalUnit.TabStop = true;
            this.rbNormalUnit.Text = "非军队单位";
            this.rbNormalUnit.UseVisualStyleBackColor = true;
            this.rbNormalUnit.CheckedChanged += new System.EventHandler(this.rbNormalUnit_CheckedChanged);
            // 
            // rbArmyUnit
            // 
            this.rbArmyUnit.AutoSize = true;
            this.rbArmyUnit.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbArmyUnit.Location = new System.Drawing.Point(106, 0);
            this.rbArmyUnit.Name = "rbArmyUnit";
            this.rbArmyUnit.Size = new System.Drawing.Size(90, 26);
            this.rbArmyUnit.TabIndex = 1;
            this.rbArmyUnit.Text = "军队单位";
            this.rbArmyUnit.UseVisualStyleBackColor = true;
            this.rbArmyUnit.CheckedChanged += new System.EventHandler(this.rbArmyUnit_CheckedChanged);
            // 
            // ofdUpload
            // 
            this.ofdUpload.Filter = "PNG文件|*.png|JPG文件|*.jpg|JPEG文件|*.jpeg|BMP文件|*.bmp";
            // 
            // FrmAddOrUpdateConfidentialQualification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 210);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtImgFile);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUnitName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddOrUpdateConfidentialQualification";
            this.Text = "新增/编辑保密资质";
            this.Load += new System.EventHandler(this.FrmAddOrUpdateWorker_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.LinkLabel txtImgFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbArmyUnit;
        private System.Windows.Forms.RadioButton rbNormalUnit;
        private System.Windows.Forms.OpenFileDialog ofdUpload;
    }
}