namespace ProjectSocialFundPlugin.Controls
{
    partial class ProjectAddressControl
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
            this.txtDetailAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDetailAddress
            // 
            this.txtDetailAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetailAddress.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtDetailAddress.Location = new System.Drawing.Point(396, 0);
            this.txtDetailAddress.Name = "txtDetailAddress";
            this.txtDetailAddress.Size = new System.Drawing.Size(332, 26);
            this.txtDetailAddress.TabIndex = 11;
            // 
            // ProjectAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDetailAddress);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ProjectAddressControl";
            this.Size = new System.Drawing.Size(728, 23);
            this.Controls.SetChildIndex(this.txtDetailAddress, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDetailAddress;
    }
}
