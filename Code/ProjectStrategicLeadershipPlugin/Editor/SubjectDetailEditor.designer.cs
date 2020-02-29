namespace ProjectStrategicLeadershipPlugin.Editor
{
    partial class SubjectDetailEditor
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEditContent2 = new System.Windows.Forms.Button();
            this.btnEditContent3 = new System.Windows.Forms.Button();
            this.btnEditContent4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.plTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new AbstractEditorPlugin.Controls.AutoHeightLabel();
            this.plContent = new System.Windows.Forms.Panel();
            this.txtReadme = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel15.SuspendLayout();
            this.plTitle.SuspendLayout();
            this.plContent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditContent2
            // 
            this.btnEditContent2.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditContent2.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnEditContent2.Location = new System.Drawing.Point(10, 10);
            this.btnEditContent2.Name = "btnEditContent2";
            this.btnEditContent2.Size = new System.Drawing.Size(196, 35);
            this.btnEditContent2.TabIndex = 2;
            this.btnEditContent2.Tag = "具体研究内容";
            this.btnEditContent2.Text = "编辑\"具体研究内容\"文档";
            this.btnEditContent2.Click += new System.EventHandler(this.btnEditContent2_Click);
            // 
            // btnEditContent3
            // 
            this.btnEditContent3.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditContent3.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnEditContent3.Location = new System.Drawing.Point(206, 10);
            this.btnEditContent3.Name = "btnEditContent3";
            this.btnEditContent3.Size = new System.Drawing.Size(166, 35);
            this.btnEditContent3.TabIndex = 2;
            this.btnEditContent3.Tag = "关键问题";
            this.btnEditContent3.Text = "编辑\"关键问题\"文档";
            this.btnEditContent3.Click += new System.EventHandler(this.btnEditContent3_Click);
            // 
            // btnEditContent4
            // 
            this.btnEditContent4.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditContent4.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnEditContent4.Location = new System.Drawing.Point(372, 10);
            this.btnEditContent4.Name = "btnEditContent4";
            this.btnEditContent4.Size = new System.Drawing.Size(208, 35);
            this.btnEditContent4.TabIndex = 2;
            this.btnEditContent4.Tag = "研究思路与方法";
            this.btnEditContent4.Text = "编辑\"研究思路与方法\"文档";
            this.btnEditContent4.Click += new System.EventHandler(this.btnEditContent4_Click);
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel15.Controls.Add(this.plTitle, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.plContent, 1, 2);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 4;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(858, 502);
            this.tableLayoutPanel15.TabIndex = 5;
            // 
            // plTitle
            // 
            this.plTitle.AutoSize = true;
            this.plTitle.Controls.Add(this.lblTitle);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plTitle.Location = new System.Drawing.Point(9, 5);
            this.plTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Size = new System.Drawing.Size(840, 28);
            this.plTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoHeight = false;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("仿宋", 15F);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(840, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = ".............";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.txtReadme);
            this.plContent.Controls.Add(this.panel1);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(8, 36);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(842, 458);
            this.plContent.TabIndex = 7;
            this.plContent.SizeChanged += new System.EventHandler(this.plContent_SizeChanged);
            // 
            // txtReadme
            // 
            this.txtReadme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReadme.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtReadme.Location = new System.Drawing.Point(0, 55);
            this.txtReadme.Name = "txtReadme";
            this.txtReadme.ReadOnly = true;
            this.txtReadme.Size = new System.Drawing.Size(842, 403);
            this.txtReadme.TabIndex = 4;
            this.txtReadme.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEditContent4);
            this.panel1.Controls.Add(this.btnEditContent3);
            this.panel1.Controls.Add(this.btnEditContent2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(842, 55);
            this.panel1.TabIndex = 3;
            // 
            // SubjectDetailEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubjectDetailEditor";
            this.Size = new System.Drawing.Size(858, 502);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.plTitle.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Panel plTitle;
        private AbstractEditorPlugin.Controls.AutoHeightLabel lblTitle;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Button btnEditContent2;
        private System.Windows.Forms.Button btnEditContent3;
        private System.Windows.Forms.Button btnEditContent4;
        private System.Windows.Forms.RichTextBox txtReadme;
        private System.Windows.Forms.Panel panel1;
    }
}