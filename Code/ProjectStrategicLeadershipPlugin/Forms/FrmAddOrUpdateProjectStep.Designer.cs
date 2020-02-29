namespace ProjectStrategicLeadershipPlugin.Forms
{
    partial class FrmAddOrUpdateProjectStep
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTag1 = new System.Windows.Forms.TextBox();
            this.txtStepTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtStepTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(68, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "阶段时间(月)：";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnSave.Location = new System.Drawing.Point(548, 403);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 43);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnClose.Location = new System.Drawing.Point(666, 403);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("仿宋", 12F);
            this.label11.Location = new System.Drawing.Point(100, 199);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "阶段成果：";
            // 
            // txtTag1
            // 
            this.txtTag1.Location = new System.Drawing.Point(196, 66);
            this.txtTag1.Margin = new System.Windows.Forms.Padding(4);
            this.txtTag1.MaxLength = 1000;
            this.txtTag1.Multiline = true;
            this.txtTag1.Name = "txtTag1";
            this.txtTag1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTag1.Size = new System.Drawing.Size(581, 314);
            this.txtTag1.TabIndex = 14;
            // 
            // txtStepTime
            // 
            this.txtStepTime.Location = new System.Drawing.Point(196, 20);
            this.txtStepTime.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.txtStepTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtStepTime.Name = "txtStepTime";
            this.txtStepTime.Size = new System.Drawing.Size(83, 26);
            this.txtStepTime.TabIndex = 18;
            this.txtStepTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmAddOrUpdateProjectStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 465);
            this.Controls.Add(this.txtStepTime);
            this.Controls.Add(this.txtTag1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddOrUpdateProjectStep";
            this.Text = "新增/编辑项目阶段";
            this.Load += new System.EventHandler(this.FrmAddOrUpdateWorker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtStepTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTag1;
        private System.Windows.Forms.NumericUpDown txtStepTime;
    }
}