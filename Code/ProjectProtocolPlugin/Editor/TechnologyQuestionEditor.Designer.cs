namespace ProjectProtocolPlugin.Editor
{
    partial class TechnologyQuestionEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblInfo = new ProjectProtocolPlugin.Controls.AutoHeightLabel();
            this.plMain = new System.Windows.Forms.Panel();
            this.plContent = new System.Windows.Forms.Panel();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelAll = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.plMain.SuspendLayout();
            this.plContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.lblInfo.Location = new System.Drawing.Point(10, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblInfo.Size = new System.Drawing.Size(1155, 51);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "填写总技术要求以及年度技术要求";
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
            this.plMain.Size = new System.Drawing.Size(1175, 701);
            this.plMain.TabIndex = 3;
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.SystemColors.Control;
            this.plContent.Controls.Add(this.dgvDetail);
            this.plContent.Controls.Add(this.panel1);
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(10, 61);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1155, 630);
            this.plContent.TabIndex = 1;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dgvDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvDetail.ColumnHeadersHeight = 35;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 73);
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("仿宋", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("仿宋", 12F);
            this.dgvDetail.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(1155, 527);
            this.dgvDetail.TabIndex = 1;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.MinimumWidth = 40;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "年度";
            this.Column2.MinimumWidth = 60;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "内容";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Text = "删除";
            this.Column4.UseColumnTextForButtonValue = true;
            this.Column4.Width = 5;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Text = "编辑";
            this.Column5.UseColumnTextForButtonValue = true;
            this.Column5.Width = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtContent);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1155, 73);
            this.panel1.TabIndex = 3;
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtContent.Location = new System.Drawing.Point(112, 0);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(991, 73);
            this.txtContent.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 73);
            this.label1.TabIndex = 6;
            this.label1.Text = "总技术要求：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(1103, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 73);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnNew);
            this.plButtons.Controls.Add(this.btnDelAll);
            this.plButtons.Controls.Add(this.button1);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(0, 600);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(1155, 30);
            this.plButtons.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNew.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Location = new System.Drawing.Point(885, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 30);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelAll
            // 
            this.btnDelAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelAll.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelAll.Location = new System.Drawing.Point(975, 0);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Size = new System.Drawing.Size(90, 30);
            this.btnDelAll.TabIndex = 2;
            this.btnDelAll.Text = "删除选中";
            this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1065, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "插入";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TechnologyQuestionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.plMain);
            this.Name = "TechnologyQuestionEditor";
            this.Size = new System.Drawing.Size(1175, 701);
            this.plMain.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.plButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Button btnDelAll;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
