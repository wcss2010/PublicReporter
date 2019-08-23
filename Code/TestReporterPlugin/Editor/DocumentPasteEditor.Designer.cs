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
            this.btnEditDocument = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plContent.SuspendLayout();
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
            this.plContent.Controls.Add(this.btnEditDocument);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(10, 56);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1063, 505);
            this.plContent.TabIndex = 1;
            // 
            // btnEditDocument
            // 
            this.btnEditDocument.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditDocument.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnEditDocument.Location = new System.Drawing.Point(6, 8);
            this.btnEditDocument.Name = "btnEditDocument";
            this.btnEditDocument.Size = new System.Drawing.Size(167, 43);
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TestReporterPlugin.Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Button btnEditDocument;
        private System.Windows.Forms.Panel panel1;
    }
}
