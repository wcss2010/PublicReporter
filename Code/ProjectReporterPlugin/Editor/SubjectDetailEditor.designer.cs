namespace ProjectReporterPlugin.Editor
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
            this.knKetiDetailTabs = new System.Windows.Forms.TabControl();
            this.kpInfo = new System.Windows.Forms.TabPage();
            this.txtInfo = new ProjectReporterPlugin.Controls.TextBoxExt();
            this.kryptonPanel1 = new System.Windows.Forms.Panel();
            this.autoHeightLabel1 = new ProjectReporterPlugin.Controls.AutoHeightLabel();
            this.kpDest = new System.Windows.Forms.TabPage();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnEditDest = new System.Windows.Forms.Button();
            this.kpContent = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditContent = new System.Windows.Forms.Button();
            this.kpNeed = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditNeed = new System.Windows.Forms.Button();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.plTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new ProjectReporterPlugin.Controls.AutoHeightLabel();
            this.plContent = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.knKetiDetailTabs.SuspendLayout();
            this.kpInfo.SuspendLayout();
            this.kryptonPanel1.SuspendLayout();
            this.kpDest.SuspendLayout();
            this.plButtons.SuspendLayout();
            this.kpContent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.kpNeed.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.plTitle.SuspendLayout();
            this.plContent.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // knKetiDetailTabs
            // 
            this.knKetiDetailTabs.Controls.Add(this.kpInfo);
            this.knKetiDetailTabs.Controls.Add(this.kpDest);
            this.knKetiDetailTabs.Controls.Add(this.kpContent);
            this.knKetiDetailTabs.Controls.Add(this.kpNeed);
            this.knKetiDetailTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knKetiDetailTabs.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.knKetiDetailTabs.Location = new System.Drawing.Point(0, 0);
            this.knKetiDetailTabs.Name = "knKetiDetailTabs";
            this.knKetiDetailTabs.SelectedIndex = 0;
            this.knKetiDetailTabs.Size = new System.Drawing.Size(842, 458);
            this.knKetiDetailTabs.TabIndex = 0;
            this.knKetiDetailTabs.Text = "kryptonNavigator1";
            // 
            // kpInfo
            // 
            this.kpInfo.Controls.Add(this.txtInfo);
            this.kpInfo.Controls.Add(this.panel3);
            this.kpInfo.Controls.Add(this.kryptonPanel1);
            this.kpInfo.Location = new System.Drawing.Point(4, 26);
            this.kpInfo.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpInfo.Name = "kpInfo";
            this.kpInfo.Size = new System.Drawing.Size(834, 428);
            this.kpInfo.TabIndex = 0;
            this.kpInfo.Text = "简述";
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Font = new System.Drawing.Font("仿宋", 14.25F);
            this.txtInfo.Location = new System.Drawing.Point(0, 34);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(834, 361);
            this.txtInfo.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.AutoSize = true;
            this.kryptonPanel1.Controls.Add(this.autoHeightLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.kryptonPanel1.Size = new System.Drawing.Size(834, 34);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // autoHeightLabel1
            // 
            this.autoHeightLabel1.AutoHeight = false;
            this.autoHeightLabel1.BackColor = System.Drawing.Color.Transparent;
            this.autoHeightLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.autoHeightLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoHeightLabel1.Font = new System.Drawing.Font("仿宋", 15F);
            this.autoHeightLabel1.Location = new System.Drawing.Point(6, 0);
            this.autoHeightLabel1.Name = "autoHeightLabel1";
            this.autoHeightLabel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.autoHeightLabel1.Size = new System.Drawing.Size(828, 34);
            this.autoHeightLabel1.TabIndex = 0;
            this.autoHeightLabel1.Text = "(200字以内,此部分无需缩进,请顶格填写)";
            this.autoHeightLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpDest
            // 
            this.kpDest.Controls.Add(this.plButtons);
            this.kpDest.Location = new System.Drawing.Point(4, 26);
            this.kpDest.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpDest.Name = "kpDest";
            this.kpDest.Size = new System.Drawing.Size(834, 428);
            this.kpDest.TabIndex = 1;
            this.kpDest.Text = "研究目标";
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnEditDest);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.plButtons.Location = new System.Drawing.Point(0, 0);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(834, 38);
            this.plButtons.TabIndex = 3;
            // 
            // btnEditDest
            // 
            this.btnEditDest.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditDest.Location = new System.Drawing.Point(667, 0);
            this.btnEditDest.Name = "btnEditDest";
            this.btnEditDest.Size = new System.Drawing.Size(167, 38);
            this.btnEditDest.TabIndex = 2;
            this.btnEditDest.Text = "使用Word编辑该文档";
            this.btnEditDest.Click += new System.EventHandler(this.btnEditDest_Click);
            // 
            // kpContent
            // 
            this.kpContent.Controls.Add(this.panel1);
            this.kpContent.Location = new System.Drawing.Point(4, 26);
            this.kpContent.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpContent.Name = "kpContent";
            this.kpContent.Size = new System.Drawing.Size(834, 428);
            this.kpContent.TabIndex = 2;
            this.kpContent.Text = "研究内容";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEditContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 38);
            this.panel1.TabIndex = 3;
            // 
            // btnEditContent
            // 
            this.btnEditContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditContent.Location = new System.Drawing.Point(650, 0);
            this.btnEditContent.Name = "btnEditContent";
            this.btnEditContent.Size = new System.Drawing.Size(184, 38);
            this.btnEditContent.TabIndex = 2;
            this.btnEditContent.Text = "使用Word编辑该文档";
            this.btnEditContent.Click += new System.EventHandler(this.btnEditContent_Click);
            // 
            // kpNeed
            // 
            this.kpNeed.Controls.Add(this.panel2);
            this.kpNeed.Location = new System.Drawing.Point(4, 26);
            this.kpNeed.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpNeed.Name = "kpNeed";
            this.kpNeed.Size = new System.Drawing.Size(834, 428);
            this.kpNeed.TabIndex = 3;
            this.kpNeed.Text = "研究思路";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEditNeed);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(834, 38);
            this.panel2.TabIndex = 3;
            // 
            // btnEditNeed
            // 
            this.btnEditNeed.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditNeed.Location = new System.Drawing.Point(670, 0);
            this.btnEditNeed.Name = "btnEditNeed";
            this.btnEditNeed.Size = new System.Drawing.Size(164, 38);
            this.btnEditNeed.TabIndex = 2;
            this.btnEditNeed.Text = "使用Word编辑该文档";
            this.btnEditNeed.Click += new System.EventHandler(this.btnEditNeed_Click);
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
            this.plContent.Controls.Add(this.knKetiDetailTabs);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(8, 36);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(842, 458);
            this.plContent.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 395);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(834, 33);
            this.panel3.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(768, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 33);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.knKetiDetailTabs.ResumeLayout(false);
            this.kpInfo.ResumeLayout(false);
            this.kpInfo.PerformLayout();
            this.kryptonPanel1.ResumeLayout(false);
            this.kpDest.ResumeLayout(false);
            this.plButtons.ResumeLayout(false);
            this.kpContent.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.kpNeed.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.plTitle.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl knKetiDetailTabs;
        private System.Windows.Forms.TabPage kpInfo;
        private System.Windows.Forms.TabPage kpDest;
        private System.Windows.Forms.TabPage kpContent;
        private System.Windows.Forms.TabPage kpNeed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Panel plTitle;
        private ProjectReporterPlugin.Controls.AutoHeightLabel lblTitle;
        private System.Windows.Forms.Panel plContent;
        private ProjectReporterPlugin.Controls.TextBoxExt txtInfo;
        private System.Windows.Forms.Panel kryptonPanel1;
        private ProjectReporterPlugin.Controls.AutoHeightLabel autoHeightLabel1;
        private System.Windows.Forms.Button btnEditDest;
        private System.Windows.Forms.Button btnEditContent;
        private System.Windows.Forms.Button btnEditNeed;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
    }
}