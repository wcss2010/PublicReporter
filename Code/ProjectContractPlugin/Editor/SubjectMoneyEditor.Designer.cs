namespace ProjectContractPlugin.Editor
{
    partial class SubjectMoneyEditor
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
            this.lblInfo = new ProjectContractPlugin.Controls.AutoHeightLabel();
            this.plMain = new System.Windows.Forms.Panel();
            this.tcMoneys = new System.Windows.Forms.TabControl();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.plMain.SuspendLayout();
            this.plButtons.SuspendLayout();
            this.SuspendLayout();
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
            this.lblInfo.Size = new System.Drawing.Size(1130, 51);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Visible = false;
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.tcMoneys);
            this.plMain.Controls.Add(this.plButtons);
            this.plMain.Controls.Add(this.lblInfo);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Margin = new System.Windows.Forms.Padding(0);
            this.plMain.Name = "plMain";
            this.plMain.Padding = new System.Windows.Forms.Padding(13);
            this.plMain.Size = new System.Drawing.Size(1156, 848);
            this.plMain.TabIndex = 3;
            // 
            // tcMoneys
            // 
            this.tcMoneys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMoneys.Location = new System.Drawing.Point(13, 64);
            this.tcMoneys.Margin = new System.Windows.Forms.Padding(4);
            this.tcMoneys.Name = "tcMoneys";
            this.tcMoneys.SelectedIndex = 0;
            this.tcMoneys.Size = new System.Drawing.Size(1130, 741);
            this.tcMoneys.TabIndex = 1;
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnSave);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(13, 805);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(1130, 30);
            this.plButtons.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(1040, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SubjectMoneyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.plMain);
            this.Font = new System.Drawing.Font("仿宋", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubjectMoneyEditor";
            this.Size = new System.Drawing.Size(1156, 848);
            this.plMain.ResumeLayout(false);
            this.plButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.TabControl tcMoneys;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Button btnSave;

    }
}
