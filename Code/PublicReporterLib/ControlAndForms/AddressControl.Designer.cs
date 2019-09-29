namespace PublicReporterLib.ControlAndForms
{
    partial class AddressControl
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
            this.Town = new System.Windows.Forms.ComboBox();
            this.County = new System.Windows.Forms.ComboBox();
            this.City = new System.Windows.Forms.ComboBox();
            this.Province = new System.Windows.Forms.ComboBox();
            this.lblProvince = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Town
            // 
            this.Town.Dock = System.Windows.Forms.DockStyle.Left;
            this.Town.FormattingEnabled = true;
            this.Town.Location = new System.Drawing.Point(435, 0);
            this.Town.Name = "Town";
            this.Town.Size = new System.Drawing.Size(121, 24);
            this.Town.TabIndex = 7;
            // 
            // County
            // 
            this.County.Dock = System.Windows.Forms.DockStyle.Left;
            this.County.FormattingEnabled = true;
            this.County.Location = new System.Drawing.Point(290, 0);
            this.County.Name = "County";
            this.County.Size = new System.Drawing.Size(121, 24);
            this.County.TabIndex = 6;
            this.County.SelectedIndexChanged += new System.EventHandler(this.County_SelectedIndexChanged);
            // 
            // City
            // 
            this.City.Dock = System.Windows.Forms.DockStyle.Left;
            this.City.FormattingEnabled = true;
            this.City.Location = new System.Drawing.Point(145, 0);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(121, 24);
            this.City.TabIndex = 5;
            this.City.SelectedIndexChanged += new System.EventHandler(this.City_SelectedIndexChanged);
            // 
            // Province
            // 
            this.Province.Dock = System.Windows.Forms.DockStyle.Left;
            this.Province.FormattingEnabled = true;
            this.Province.Location = new System.Drawing.Point(0, 0);
            this.Province.Name = "Province";
            this.Province.Size = new System.Drawing.Size(121, 24);
            this.Province.TabIndex = 4;
            this.Province.SelectedIndexChanged += new System.EventHandler(this.Province_SelectedIndexChanged);
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProvince.Location = new System.Drawing.Point(121, 0);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(24, 16);
            this.lblProvince.TabIndex = 8;
            this.lblProvince.Text = "省";
            this.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCity.Location = new System.Drawing.Point(266, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 16);
            this.lblCity.TabIndex = 9;
            this.lblCity.Text = "市";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblArea.Location = new System.Drawing.Point(411, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(24, 16);
            this.lblArea.TabIndex = 10;
            this.lblArea.Text = "区";
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Town);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.County);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.City);
            this.Controls.Add(this.lblProvince);
            this.Controls.Add(this.Province);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("仿宋", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddressControl";
            this.Size = new System.Drawing.Size(556, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Town;
        private System.Windows.Forms.ComboBox County;
        private System.Windows.Forms.ComboBox City;
        private System.Windows.Forms.ComboBox Province;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblArea;
    }
}
