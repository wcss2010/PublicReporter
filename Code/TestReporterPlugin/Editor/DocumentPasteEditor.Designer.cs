namespace TestReporterPlugin.Editor
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
            this.lblInfo = new TestReporterPlugin.Controls.AutoHeightLabel();
            this.plContent = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.wbWordView = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWordInfo = new System.Windows.Forms.Label();
            this.btnEditDocument = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plContent.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.plContent.Controls.Add(this.panel3);
            this.plContent.Controls.Add(this.panel2);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(10, 56);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1063, 505);
            this.plContent.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.wbWordView);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1063, 467);
            this.panel3.TabIndex = 4;
            // 
            // wbWordView
            // 
            this.wbWordView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbWordView.IsWebBrowserContextMenuEnabled = false;
            this.wbWordView.Location = new System.Drawing.Point(0, 19);
            this.wbWordView.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbWordView.Name = "wbWordView";
            this.wbWordView.Size = new System.Drawing.Size(1063, 448);
            this.wbWordView.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("仿宋", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1063, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "以下内容只用于查看，实际效果以Word中显示的为准！";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblWordInfo);
            this.panel2.Controls.Add(this.btnEditDocument);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1063, 38);
            this.panel2.TabIndex = 1;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.plContent);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1083, 571);
            this.panel1.TabIndex = 0;
            // 
            // DocumentPasteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Name = "DocumentPasteEditor";
            this.Size = new System.Drawing.Size(1083, 571);
            this.plContent.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TestReporterPlugin.Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Button btnEditDocument;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWordInfo;
        private System.Windows.Forms.WebBrowser wbWordView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
    }
}
