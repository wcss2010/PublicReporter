namespace PublicReporter
{
    partial class StartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            this.btnStartA = new System.Windows.Forms.Button();
            this.btnStartB = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartA
            // 
            this.btnStartA.Font = new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartA.Location = new System.Drawing.Point(95, 369);
            this.btnStartA.Name = "btnStartA";
            this.btnStartA.Size = new System.Drawing.Size(222, 87);
            this.btnStartA.TabIndex = 0;
            this.btnStartA.Text = "启动重大专项填报";
            this.btnStartA.UseVisualStyleBackColor = true;
            this.btnStartA.Click += new System.EventHandler(this.btnStartA_Click);
            // 
            // btnStartB
            // 
            this.btnStartB.Font = new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartB.Location = new System.Drawing.Point(365, 369);
            this.btnStartB.Name = "btnStartB";
            this.btnStartB.Size = new System.Drawing.Size(222, 87);
            this.btnStartB.TabIndex = 0;
            this.btnStartB.Text = "启动产品填报";
            this.btnStartB.UseVisualStyleBackColor = true;
            this.btnStartB.Click += new System.EventHandler(this.btnStartB_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(704, 342);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 492);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStartB);
            this.Controls.Add(this.btnStartA);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartupForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择要启动的项目！";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartA;
        private System.Windows.Forms.Button btnStartB;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}