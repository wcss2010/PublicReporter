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
            this.txtWordReadme = new System.Windows.Forms.RichTextBox();
            this.plButtons = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditDocument = new System.Windows.Forms.Button();
            this.plMain = new System.Windows.Forms.Panel();
            this.lblInfo = new ProjectContractPlugin.Controls.AutoHeightLabel();
            this.plContent.SuspendLayout();
            this.plButtons.SuspendLayout();
            this.plMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.SystemColors.Control;
            this.plContent.Controls.Add(this.txtWordReadme);
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(13, 64);
            this.plContent.Margin = new System.Windows.Forms.Padding(4);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1154, 706);
            this.plContent.TabIndex = 1;
            // 
            // txtWordReadme
            // 
            this.txtWordReadme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWordReadme.Enabled = false;
            this.txtWordReadme.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtWordReadme.Location = new System.Drawing.Point(0, 60);
            this.txtWordReadme.Margin = new System.Windows.Forms.Padding(4);
            this.txtWordReadme.Name = "txtWordReadme";
            this.txtWordReadme.ReadOnly = true;
            this.txtWordReadme.Size = new System.Drawing.Size(1154, 646);
            this.txtWordReadme.TabIndex = 3;
            this.txtWordReadme.Text = "";
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.label1);
            this.plButtons.Controls.Add(this.btnEditDocument);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.plButtons.Location = new System.Drawing.Point(0, 0);
            this.plButtons.Margin = new System.Windows.Forms.Padding(4);
            this.plButtons.Name = "plButtons";
            this.plButtons.Padding = new System.Windows.Forms.Padding(13);
            this.plButtons.Size = new System.Drawing.Size(1154, 60);
            this.plButtons.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("仿宋", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(965, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "请先仔细阅读下面的说明文字,然后再点击\"使用Word编辑该文档\"按钮！";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEditDocument
            // 
            this.btnEditDocument.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditDocument.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditDocument.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnEditDocument.Location = new System.Drawing.Point(978, 13);
            this.btnEditDocument.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditDocument.Name = "btnEditDocument";
            this.btnEditDocument.Size = new System.Drawing.Size(163, 34);
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
            this.plMain.Padding = new System.Windows.Forms.Padding(13);
            this.plMain.Size = new System.Drawing.Size(1180, 783);
            this.plMain.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoHeight = true;
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("仿宋", 15.75F);
            this.lblInfo.Location = new System.Drawing.Point(13, 13);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lblInfo.Size = new System.Drawing.Size(1154, 51);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "项目经费预算编制说明";
            // 
            // ExtFile2Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.plMain);
            this.Font = new System.Drawing.Font("仿宋", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExtFile2Editor";
            this.Size = new System.Drawing.Size(1180, 783);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtWordReadme;

    }
}
