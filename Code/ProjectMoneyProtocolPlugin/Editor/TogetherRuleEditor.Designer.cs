namespace ProjectMoneyProtocolPlugin.Editor
{
    partial class TogetherRuleEditor
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
            this.lblInfo = new ProjectMoneyProtocolPlugin.Controls.AutoHeightLabel();
            this.plMain = new System.Windows.Forms.Panel();
            this.plContent = new System.Windows.Forms.Panel();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.ibEdit4 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ibEdit3 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ibEdit2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ibEdit1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.plMain.SuspendLayout();
            this.plContent.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit1)).BeginInit();
            this.SuspendLayout();
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
            this.lblInfo.Size = new System.Drawing.Size(1063, 51);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Visible = false;
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
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.SystemColors.Control;
            this.plContent.Controls.Add(this.txtContent);
            this.plContent.Controls.Add(this.panel1);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(10, 61);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1063, 500);
            this.plContent.TabIndex = 1;
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtContent.Location = new System.Drawing.Point(0, 28);
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.Size = new System.Drawing.Size(1063, 472);
            this.txtContent.TabIndex = 0;
            this.txtContent.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ibEdit4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ibEdit3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ibEdit2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ibEdit1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1063, 28);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("仿宋", 12F);
            this.label5.Location = new System.Drawing.Point(701, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "份";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // ibEdit4
            // 
            this.ibEdit4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibEdit4.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit4.Location = new System.Drawing.Point(652, 0);
            this.ibEdit4.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ibEdit4.Name = "ibEdit4";
            this.ibEdit4.Size = new System.Drawing.Size(49, 26);
            this.ibEdit4.TabIndex = 8;
            this.ibEdit4.Visible = false;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("仿宋", 12F);
            this.label4.Location = new System.Drawing.Point(611, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "份。";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ibEdit3
            // 
            this.ibEdit3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibEdit3.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit3.Location = new System.Drawing.Point(560, 0);
            this.ibEdit3.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ibEdit3.Name = "ibEdit3";
            this.ibEdit3.Size = new System.Drawing.Size(51, 26);
            this.ibEdit3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(452, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "份，承研方执";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ibEdit2
            // 
            this.ibEdit2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibEdit2.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit2.Location = new System.Drawing.Point(403, 0);
            this.ibEdit2.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ibEdit2.Name = "ibEdit2";
            this.ibEdit2.Size = new System.Drawing.Size(49, 26);
            this.ibEdit2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("仿宋", 12F);
            this.label2.Location = new System.Drawing.Point(151, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "份，具有同等法律效力，委托方执";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ibEdit1
            // 
            this.ibEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibEdit1.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit1.Location = new System.Drawing.Point(100, 0);
            this.ibEdit1.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ibEdit1.Name = "ibEdit1";
            this.ibEdit1.Size = new System.Drawing.Size(51, 26);
            this.ibEdit1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "本协议一式";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnSave.Location = new System.Drawing.Point(976, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TogetherRuleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.plMain);
            this.Name = "TogetherRuleEditor";
            this.Size = new System.Drawing.Size(1083, 571);
            this.plMain.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProjectMoneyProtocolPlugin.Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ibEdit1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ibEdit2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ibEdit3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ibEdit4;
        private System.Windows.Forms.Label label5;
    }
}
