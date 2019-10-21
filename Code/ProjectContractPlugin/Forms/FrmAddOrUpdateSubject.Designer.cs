namespace ProjectContractPlugin.Forms
{
    partial class FrmAddOrUpdateSubject
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWorkDest = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.txtWorkContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWorkUnit = new System.Windows.Forms.TextBox();
            this.txtWorkOrg = new System.Windows.Forms.ComboBox();
            this.txtWorkAddress = new ProjectContractPlugin.Editor.ProjectAddressEditor();
            this.txtWorkUnitAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(54, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "课题名称：";
            // 
            // txtWorkDest
            // 
            this.txtWorkDest.AcceptsReturn = true;
            this.txtWorkDest.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtWorkDest.Location = new System.Drawing.Point(148, 47);
            this.txtWorkDest.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkDest.Multiline = true;
            this.txtWorkDest.Name = "txtWorkDest";
            this.txtWorkDest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWorkDest.Size = new System.Drawing.Size(647, 79);
            this.txtWorkDest.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnSave.Location = new System.Drawing.Point(550, 649);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 43);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("仿宋", 12F);
            this.label2.Location = new System.Drawing.Point(55, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "研究目标：";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("仿宋", 12F);
            this.btnClose.Location = new System.Drawing.Point(668, 649);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(148, 10);
            this.txtSubjectName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(647, 26);
            this.txtSubjectName.TabIndex = 4;
            // 
            // txtWorkContent
            // 
            this.txtWorkContent.AcceptsReturn = true;
            this.txtWorkContent.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtWorkContent.Location = new System.Drawing.Point(148, 138);
            this.txtWorkContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkContent.Multiline = true;
            this.txtWorkContent.Name = "txtWorkContent";
            this.txtWorkContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWorkContent.Size = new System.Drawing.Size(647, 89);
            this.txtWorkContent.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(55, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "研究内容：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("仿宋", 12F);
            this.label5.Location = new System.Drawing.Point(55, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "负责单位：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("仿宋", 12F);
            this.label6.Location = new System.Drawing.Point(55, 319);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "所属部门：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("仿宋", 12F);
            this.label7.Location = new System.Drawing.Point(55, 355);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "所属地点：";
            // 
            // txtWorkUnit
            // 
            this.txtWorkUnit.Location = new System.Drawing.Point(148, 239);
            this.txtWorkUnit.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkUnit.Name = "txtWorkUnit";
            this.txtWorkUnit.Size = new System.Drawing.Size(647, 26);
            this.txtWorkUnit.TabIndex = 4;
            this.txtWorkUnit.TextChanged += new System.EventHandler(this.txtWorkUnit_TextChanged);
            // 
            // txtWorkOrg
            // 
            this.txtWorkOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtWorkOrg.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtWorkOrg.FormattingEnabled = true;
            this.txtWorkOrg.ItemHeight = 16;
            this.txtWorkOrg.Items.AddRange(new object[] {
            "陆军",
            "海军",
            "空军",
            "火箭军",
            "战略支援部队",
            "联勤保障部队",
            "军委机关直属单位",
            "军事科学院",
            "国防大学",
            "国防科技大学",
            "武警部队",
            "教育部",
            "工信部",
            "中国科学院",
            "中国兵器工业集团公司",
            "中国兵器装备集团公司",
            "中国船舶工业集团公司",
            "中国船舶重工集团公司",
            "中国电子科技集团公司",
            "中国电子信息产业集团公司",
            "中国航空发动机集团公司",
            "中国航空工业集团公司",
            "中国航天科工集团公司",
            "中国航天科技集团公司",
            "中国核工业集团公司",
            "中国工程物理研究院",
            "其它"});
            this.txtWorkOrg.Location = new System.Drawing.Point(148, 316);
            this.txtWorkOrg.Name = "txtWorkOrg";
            this.txtWorkOrg.Size = new System.Drawing.Size(261, 24);
            this.txtWorkOrg.TabIndex = 10;
            // 
            // txtWorkAddress
            // 
            this.txtWorkAddress.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtWorkAddress.Location = new System.Drawing.Point(148, 352);
            this.txtWorkAddress.Margin = new System.Windows.Forms.Padding(5);
            this.txtWorkAddress.Name = "txtWorkAddress";
            this.txtWorkAddress.Size = new System.Drawing.Size(519, 27);
            this.txtWorkAddress.TabIndex = 11;
            // 
            // txtWorkUnitAddress
            // 
            this.txtWorkUnitAddress.Location = new System.Drawing.Point(148, 278);
            this.txtWorkUnitAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkUnitAddress.Name = "txtWorkUnitAddress";
            this.txtWorkUnitAddress.Size = new System.Drawing.Size(647, 26);
            this.txtWorkUnitAddress.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("仿宋", 12F);
            this.label8.Location = new System.Drawing.Point(55, 281);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "通信地址：";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dgvDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("仿宋", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.Location = new System.Drawing.Point(148, 387);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(647, 246);
            this.dgvDetail.TabIndex = 12;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("仿宋", 12F);
            this.label4.Location = new System.Drawing.Point(54, 495);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "单位分工：";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "单位名称";
            this.Column1.MinimumWidth = 150;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "任务分工";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.MinimumWidth = 60;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Text = "删除";
            this.Column3.UseColumnTextForButtonValue = true;
            this.Column3.Width = 60;
            // 
            // FrmAddOrUpdateSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 696);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.txtWorkAddress);
            this.Controls.Add(this.txtWorkOrg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWorkContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWorkUnitAddress);
            this.Controls.Add(this.txtWorkUnit);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtWorkDest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddOrUpdateSubject";
            this.Text = "新增/编辑课题情况";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWorkDest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.TextBox txtWorkContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWorkUnit;
        private System.Windows.Forms.ComboBox txtWorkOrg;
        private Editor.ProjectAddressEditor txtWorkAddress;
        private System.Windows.Forms.TextBox txtWorkUnitAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
    }
}