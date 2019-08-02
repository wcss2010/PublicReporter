namespace PublicReporter
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ssHintBar = new System.Windows.Forms.StatusStrip();
            this.tsslHint = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsButtonBar = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.tvSubjects = new System.Windows.Forms.TreeView();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ssHintBar.SuspendLayout();
            this.tsButtonBar.SuspendLayout();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssHintBar
            // 
            this.ssHintBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslHint});
            this.ssHintBar.Location = new System.Drawing.Point(0, 555);
            this.ssHintBar.Name = "ssHintBar";
            this.ssHintBar.Size = new System.Drawing.Size(982, 22);
            this.ssHintBar.TabIndex = 0;
            this.ssHintBar.Text = "statusStrip1";
            // 
            // tsslHint
            // 
            this.tsslHint.Name = "tsslHint";
            this.tsslHint.Size = new System.Drawing.Size(0, 17);
            // 
            // tsButtonBar
            // 
            this.tsButtonBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsButtonBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnExit});
            this.tsButtonBar.Location = new System.Drawing.Point(0, 0);
            this.tsButtonBar.Name = "tsButtonBar";
            this.tsButtonBar.Size = new System.Drawing.Size(982, 59);
            this.tsButtonBar.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 56);
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // scContent
            // 
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.Location = new System.Drawing.Point(0, 59);
            this.scContent.Name = "scContent";
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.tvSubjects);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.scContent.Size = new System.Drawing.Size(982, 496);
            this.scContent.SplitterDistance = 327;
            this.scContent.TabIndex = 2;
            // 
            // tvSubjects
            // 
            this.tvSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSubjects.Location = new System.Drawing.Point(0, 0);
            this.tvSubjects.Name = "tvSubjects";
            this.tvSubjects.Size = new System.Drawing.Size(327, 496);
            this.tvSubjects.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 59);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 577);
            this.Controls.Add(this.scContent);
            this.Controls.Add(this.tsButtonBar);
            this.Controls.Add(this.ssHintBar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "申报系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ssHintBar.ResumeLayout(false);
            this.ssHintBar.PerformLayout();
            this.tsButtonBar.ResumeLayout(false);
            this.tsButtonBar.PerformLayout();
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssHintBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslHint;
        private System.Windows.Forms.ToolStrip tsButtonBar;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.TreeView tvSubjects;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

