﻿namespace ProjectContractPlugin.Editor
{
    partial class DocumentPasteEditor
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo = new ProjectContractPlugin.Controls.AutoHeightLabel();
            this.plContent = new System.Windows.Forms.Panel();
            this.plWordViewConent = new System.Windows.Forms.Panel();
            this.pbWordView = new System.Windows.Forms.PictureBox();
            this.lblViewHint = new System.Windows.Forms.Label();
            this.plButtons = new System.Windows.Forms.Panel();
            this.lblWordInfo = new System.Windows.Forms.Label();
            this.btnEditDocument = new System.Windows.Forms.Button();
            this.plMain = new System.Windows.Forms.Panel();
            this.plContent.SuspendLayout();
            this.plWordViewConent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWordView)).BeginInit();
            this.plButtons.SuspendLayout();
            this.plMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoHeight = true;
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.Location = new System.Drawing.Point(10, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(1063, 46);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "label1";
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.SystemColors.Control;
            this.plContent.Controls.Add(this.plWordViewConent);
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(10, 56);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1063, 505);
            this.plContent.TabIndex = 1;
            // 
            // plWordViewConent
            // 
            this.plWordViewConent.AutoScroll = true;
            this.plWordViewConent.BackColor = System.Drawing.Color.White;
            this.plWordViewConent.Controls.Add(this.pbWordView);
            this.plWordViewConent.Controls.Add(this.lblViewHint);
            this.plWordViewConent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plWordViewConent.Location = new System.Drawing.Point(0, 38);
            this.plWordViewConent.Name = "plWordViewConent";
            this.plWordViewConent.Size = new System.Drawing.Size(1063, 467);
            this.plWordViewConent.TabIndex = 4;
            this.plWordViewConent.Visible = false;
            // 
            // pbWordView
            // 
            this.pbWordView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbWordView.Location = new System.Drawing.Point(0, 19);
            this.pbWordView.Name = "pbWordView";
            this.pbWordView.Size = new System.Drawing.Size(1063, 206);
            this.pbWordView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbWordView.TabIndex = 4;
            this.pbWordView.TabStop = false;
            // 
            // lblViewHint
            // 
            this.lblViewHint.BackColor = System.Drawing.Color.White;
            this.lblViewHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblViewHint.Font = new System.Drawing.Font("仿宋", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblViewHint.ForeColor = System.Drawing.Color.Red;
            this.lblViewHint.Location = new System.Drawing.Point(0, 0);
            this.lblViewHint.Name = "lblViewHint";
            this.lblViewHint.Size = new System.Drawing.Size(1063, 19);
            this.lblViewHint.TabIndex = 3;
            this.lblViewHint.Text = "以下内容只用于查看，实际效果以Word中显示的为准！";
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.lblWordInfo);
            this.plButtons.Controls.Add(this.btnEditDocument);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.plButtons.Location = new System.Drawing.Point(0, 0);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(1063, 38);
            this.plButtons.TabIndex = 1;
            // 
            // lblWordInfo
            // 
            this.lblWordInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWordInfo.Font = new System.Drawing.Font("仿宋", 12F);
            this.lblWordInfo.Location = new System.Drawing.Point(0, 0);
            this.lblWordInfo.Name = "lblWordInfo";
            this.lblWordInfo.Size = new System.Drawing.Size(893, 38);
            this.lblWordInfo.TabIndex = 1;
            this.lblWordInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWordInfo.Visible = false;
            // 
            // btnEditDocument
            // 
            this.btnEditDocument.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditDocument.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditDocument.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnEditDocument.Location = new System.Drawing.Point(893, 0);
            this.btnEditDocument.Name = "btnEditDocument";
            this.btnEditDocument.Size = new System.Drawing.Size(170, 38);
            this.btnEditDocument.TabIndex = 0;
            this.btnEditDocument.Text = "使用Word编辑该文档";
            this.btnEditDocument.UseVisualStyleBackColor = false;
            this.btnEditDocument.Click += new System.EventHandler(this.btnEditDocument_Click);
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.plContent);
            this.plMain.Controls.Add(this.lblInfo);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Margin = new System.Windows.Forms.Padding(0);
            this.plMain.Name = "plMain";
            this.plMain.Padding = new System.Windows.Forms.Padding(10);
            this.plMain.Size = new System.Drawing.Size(1083, 571);
            this.plMain.TabIndex = 0;
            // 
            // DocumentPasteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.plMain);
            this.Name = "DocumentPasteEditor";
            this.Size = new System.Drawing.Size(1083, 571);
            this.plContent.ResumeLayout(false);
            this.plWordViewConent.ResumeLayout(false);
            this.plWordViewConent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWordView)).EndInit();
            this.plButtons.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ProjectContractPlugin.Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Button btnEditDocument;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Label lblWordInfo;
        private System.Windows.Forms.Panel plWordViewConent;
        private System.Windows.Forms.Label lblViewHint;
        private System.Windows.Forms.PictureBox pbWordView;
    }
}
