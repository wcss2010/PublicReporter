namespace TestReporterPlugin.Editor
{
    partial class MoneySummaryEditor
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
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.plTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.plContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel20 = new TestReporterPlugin.Controls.HSkinTableLayoutPanel();
            this.btnComsel = new System.Windows.Forms.Button();
            this.kryptonLabel67 = new System.Windows.Forms.Label();
            this.lbcomattpath = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lklDownloadFuJian = new System.Windows.Forms.LinkLabel();
            this.kryptonLabel1 = new System.Windows.Forms.Label();
            this.ofdUpload = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.plTitle.SuspendLayout();
            this.plContent.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel15.Controls.Add(this.tableLayoutPanel1, 1, 3);
            this.tableLayoutPanel15.Controls.Add(this.plTitle, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.plContent, 1, 2);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 5;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(1050, 562);
            this.tableLayoutPanel15.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(53, 505);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 34);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(847, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // plTitle
            // 
            this.plTitle.Controls.Add(this.label1);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plTitle.Location = new System.Drawing.Point(54, 20);
            this.plTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.plTitle.Size = new System.Drawing.Size(942, 30);
            this.plTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("仿宋", 14.25F);
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(936, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "介绍本项目总经费预算构成，应能够支撑对项目总经费及相关课题经费安排合理性进行审核评估";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.tableLayoutPanel20);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(53, 53);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(944, 446);
            this.plContent.TabIndex = 7;
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.BorderColor = System.Drawing.Color.Black;
            this.tableLayoutPanel20.ColumnCount = 3;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel20.Controls.Add(this.btnComsel, 2, 0);
            this.tableLayoutPanel20.Controls.Add(this.kryptonLabel67, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.lbcomattpath, 1, 0);
            this.tableLayoutPanel20.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel20.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 2;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(944, 81);
            this.tableLayoutPanel20.TabIndex = 5;
            // 
            // btnComsel
            // 
            this.btnComsel.Location = new System.Drawing.Point(797, 3);
            this.btnComsel.Name = "btnComsel";
            this.btnComsel.Size = new System.Drawing.Size(82, 34);
            this.btnComsel.TabIndex = 5;
            this.btnComsel.Text = "上传附件";
            this.btnComsel.Click += new System.EventHandler(this.btnComsel_Click);
            // 
            // kryptonLabel67
            // 
            this.kryptonLabel67.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel67.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel67.Location = new System.Drawing.Point(3, 0);
            this.kryptonLabel67.Name = "kryptonLabel67";
            this.kryptonLabel67.Size = new System.Drawing.Size(54, 40);
            this.kryptonLabel67.TabIndex = 1;
            this.kryptonLabel67.Text = "附件";
            this.kryptonLabel67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbcomattpath
            // 
            this.lbcomattpath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbcomattpath.Font = new System.Drawing.Font("仿宋", 12F);
            this.lbcomattpath.Location = new System.Drawing.Point(63, 0);
            this.lbcomattpath.Name = "lbcomattpath";
            this.lbcomattpath.Size = new System.Drawing.Size(728, 40);
            this.lbcomattpath.TabIndex = 8;
            this.lbcomattpath.TabStop = true;
            this.lbcomattpath.Text = "0";
            this.lbcomattpath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lklDownloadFuJian);
            this.panel1.Controls.Add(this.kryptonLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(63, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 35);
            this.panel1.TabIndex = 9;
            // 
            // lklDownloadFuJian
            // 
            this.lklDownloadFuJian.Dock = System.Windows.Forms.DockStyle.Left;
            this.lklDownloadFuJian.Font = new System.Drawing.Font("仿宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lklDownloadFuJian.ForeColor = System.Drawing.Color.Black;
            this.lklDownloadFuJian.Location = new System.Drawing.Point(102, 0);
            this.lklDownloadFuJian.Name = "lklDownloadFuJian";
            this.lklDownloadFuJian.Size = new System.Drawing.Size(152, 35);
            this.lklDownloadFuJian.TabIndex = 0;
            this.lklDownloadFuJian.TabStop = true;
            this.lklDownloadFuJian.Text = "项目经费概算说明.doc";
            this.lklDownloadFuJian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lklDownloadFuJian.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklDownloadFuJian_LinkClicked);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel1.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(102, 35);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Text = "附件模板：";
            this.kryptonLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ofdUpload
            // 
            this.ofdUpload.Filter = "DOC文件|*.doc|DOCX文件|*.docx";
            // 
            // MoneySummaryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MoneySummaryEditor";
            this.Size = new System.Drawing.Size(1050, 562);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.plTitle.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.tableLayoutPanel20.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel plTitle;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Label label1;
        private TestReporterPlugin.Controls.HSkinTableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.Button btnComsel;
        private System.Windows.Forms.Label kryptonLabel67;
        private System.Windows.Forms.LinkLabel lbcomattpath;
        private System.Windows.Forms.OpenFileDialog ofdUpload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lklDownloadFuJian;
        private System.Windows.Forms.Label kryptonLabel1;
    }
}