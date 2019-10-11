namespace ProjectContractPlugin.Editor
{
    partial class ExtFile2Editor
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
            this.plContent = new System.Windows.Forms.Panel();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnEditDocument = new System.Windows.Forms.Button();
            this.lblInfo = new ProjectContractPlugin.Controls.AutoHeightLabel();
            this.plMain = new System.Windows.Forms.Panel();
            this.plContent.SuspendLayout();
            this.plButtons.SuspendLayout();
            this.plMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.SystemColors.Control;
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(10, 61);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(780, 516);
            this.plContent.TabIndex = 1;
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnEditDocument);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.plButtons.Location = new System.Drawing.Point(0, 0);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(780, 38);
            this.plButtons.TabIndex = 1;
            // 
            // btnEditDocument
            // 
            this.btnEditDocument.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditDocument.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditDocument.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnEditDocument.Location = new System.Drawing.Point(610, 0);
            this.btnEditDocument.Name = "btnEditDocument";
            this.btnEditDocument.Size = new System.Drawing.Size(170, 38);
            this.btnEditDocument.TabIndex = 0;
            this.btnEditDocument.Text = "使用Word编辑该文档";
            this.btnEditDocument.UseVisualStyleBackColor = false;
            this.btnEditDocument.Click += new System.EventHandler(this.btnEditDocument_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoHeight = true;
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("仿宋", 15.75F);
            this.lblInfo.Location = new System.Drawing.Point(10, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblInfo.Size = new System.Drawing.Size(780, 51);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "项目经费预算编制说明";
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
            this.plMain.Size = new System.Drawing.Size(800, 587);
            this.plMain.TabIndex = 1;
            // 
            // ExtFile2Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.plMain);
            this.Name = "ExtFile2Editor";
            this.Size = new System.Drawing.Size(800, 587);
            this.plContent.ResumeLayout(false);
            this.plButtons.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Button btnEditDocument;
        private Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel plMain;

    }
}
