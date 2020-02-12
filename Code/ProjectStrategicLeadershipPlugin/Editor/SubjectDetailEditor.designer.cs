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
            this.txtInfo = new AbstractEditorPlugin.Controls.TextBoxExt();
            this.btnSave = new System.Windows.Forms.Button();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnEditDest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditContent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditNeed = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.plTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new AbstractEditorPlugin.Controls.AutoHeightLabel();
            this.plContent = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.plButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.plTitle.SuspendLayout();
            this.plContent.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.EnabledMiddleInParentBox = false;
            this.txtInfo.Font = new System.Drawing.Font("仿宋", 14.25F);
            this.txtInfo.Location = new System.Drawing.Point(155, 0);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(632, 110);
            this.txtInfo.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnSave.Location = new System.Drawing.Point(787, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 110);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnEditDest);
            this.plButtons.Controls.Add(this.label2);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.plButtons.Location = new System.Drawing.Point(0, 110);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(842, 38);
            this.plButtons.TabIndex = 3;
            // 
            // btnEditDest
            // 
            this.btnEditDest.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditDest.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnEditDest.Location = new System.Drawing.Point(681, 0);
            this.btnEditDest.Name = "btnEditDest";
            this.btnEditDest.Size = new System.Drawing.Size(161, 38);
            this.btnEditDest.TabIndex = 2;
            this.btnEditDest.Text = "使用Word编辑该文档";
            this.btnEditDest.Click += new System.EventHandler(this.btnEditDest_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("仿宋", 12F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "具体研究内容：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEditContent);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 38);
            this.panel1.TabIndex = 3;
            // 
            // btnEditContent
            // 
            this.btnEditContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditContent.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnEditContent.Location = new System.Drawing.Point(681, 0);
            this.btnEditContent.Name = "btnEditContent";
            this.btnEditContent.Size = new System.Drawing.Size(161, 38);
            this.btnEditContent.TabIndex = 2;
            this.btnEditContent.Text = "使用Word编辑该文档";
            this.btnEditContent.Click += new System.EventHandler(this.btnEditContent_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 38);
            this.label3.TabIndex = 1;
            this.label3.Text = "关键问题：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEditNeed);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 186);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(842, 38);
            this.panel2.TabIndex = 3;
            // 
            // btnEditNeed
            // 
            this.btnEditNeed.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditNeed.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnEditNeed.Location = new System.Drawing.Point(681, 0);
            this.btnEditNeed.Name = "btnEditNeed";
            this.btnEditNeed.Size = new System.Drawing.Size(161, 38);
            this.btnEditNeed.TabIndex = 2;
            this.btnEditNeed.Text = "使用Word编辑该文档";
            this.btnEditNeed.Click += new System.EventHandler(this.btnEditNeed_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("仿宋", 12F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 38);
            this.label4.TabIndex = 1;
            this.label4.Text = "研究思路与方法：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.plContent.AutoScroll = true;
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.panel2);
            this.plContent.Controls.Add(this.panel1);
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Controls.Add(this.panel3);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(8, 36);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(842, 458);
            this.plContent.TabIndex = 7;
            this.plContent.SizeChanged += new System.EventHandler(this.plContent_SizeChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtInfo);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(842, 110);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 110);
            this.label1.TabIndex = 1;
            this.label1.Text = "概述(200字以内)：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.plButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.plTitle.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Panel plTitle;
        private AbstractEditorPlugin.Controls.AutoHeightLabel lblTitle;
        private System.Windows.Forms.Panel plContent;
        private AbstractEditorPlugin.Controls.TextBoxExt txtInfo;
        private System.Windows.Forms.Button btnEditDest;
        private System.Windows.Forms.Button btnEditContent;
        private System.Windows.Forms.Button btnEditNeed;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
    }
}