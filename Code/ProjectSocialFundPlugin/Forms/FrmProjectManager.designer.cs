namespace ProjectSocialFundPlugin.Forms
{
    partial class FrmProjectManager
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
            this.plContent = new System.Windows.Forms.Panel();
            this.tvProject = new System.Windows.Forms.TreeView();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.ofdSelect = new System.Windows.Forms.OpenFileDialog();
            this.plContent.SuspendLayout();
            this.plButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContent
            // 
            this.plContent.Controls.Add(this.tvProject);
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(0, 0);
            this.plContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(913, 768);
            this.plContent.TabIndex = 9;
            // 
            // tvProject
            // 
            this.tvProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProject.Font = new System.Drawing.Font("仿宋", 14.25F);
            this.tvProject.FullRowSelect = true;
            this.tvProject.HideSelection = false;
            this.tvProject.Location = new System.Drawing.Point(0, 0);
            this.tvProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tvProject.Name = "tvProject";
            this.tvProject.Size = new System.Drawing.Size(913, 720);
            this.tvProject.TabIndex = 8;
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnDel);
            this.plButtons.Controls.Add(this.btnOpen);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(0, 720);
            this.plButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(913, 48);
            this.plButtons.TabIndex = 7;
            // 
            // btnDel
            // 
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDel.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(713, 0);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 48);
            this.btnDel.TabIndex = 31;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpen.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpen.Location = new System.Drawing.Point(813, 0);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 48);
            this.btnOpen.TabIndex = 29;
            this.btnOpen.Text = "切换";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // ofdSelect
            // 
            this.ofdSelect.Filter = "Zip压缩文件(*.zip)|*.zip";
            // 
            // FrmProjectManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 768);
            this.Controls.Add(this.plContent);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProjectManager";
            this.Text = "项目管理";
            this.plContent.ResumeLayout(false);
            this.plButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.TreeView tvProject;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog ofdSelect;
        private System.Windows.Forms.Button btnDel;
    }
}