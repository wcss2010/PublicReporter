namespace ProjectStrategicLeadershipPlugin.Forms
{
    partial class FrmPkgExport
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModifyWords = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnCancel.Location = new System.Drawing.Point(347, 121);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 31);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnOK.Location = new System.Drawing.Point(229, 121);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 31);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确认导出";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(689, 43);
            this.label1.TabIndex = 9;
            this.label1.Text = "1.\t导出数据包时，最后一次生成的文档将作为导出数据包时的最终申报文档被导出到数据包中。";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(689, 43);
            this.label2.TabIndex = 10;
            this.label2.Text = "2.\t申报者仅可在此处对生成文档中的格式进行适当修改后再导出。";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnModifyWords
            // 
            this.btnModifyWords.ForeColor = System.Drawing.Color.Black;
            this.btnModifyWords.Location = new System.Drawing.Point(471, 49);
            this.btnModifyWords.Name = "btnModifyWords";
            this.btnModifyWords.Size = new System.Drawing.Size(95, 31);
            this.btnModifyWords.TabIndex = 11;
            this.btnModifyWords.Text = "修改格式";
            this.btnModifyWords.UseVisualStyleBackColor = true;
            this.btnModifyWords.Click += new System.EventHandler(this.btnModifyWords_Click);
            // 
            // FrmPkgExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 174);
            this.Controls.Add(this.btnModifyWords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPkgExport";
            this.Text = "数据包导出";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModifyWords;
    }
}