namespace TestReporterPlugin.Editor
{
    partial class SubjectStepMoneyEditor
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
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.plTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.plContent = new System.Windows.Forms.Panel();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.selpersonid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJieDuanHuaFen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYanJiuNeiRong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJieDuanMuBiao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJieDuanJingFei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.plTitle.SuspendLayout();
            this.plContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel15.Controls.Add(this.tableLayoutPanel1, 1, 3);
            this.tableLayoutPanel15.Controls.Add(this.plTitle, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.plContent, 1, 2);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 5;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(1043, 637);
            this.tableLayoutPanel15.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(53, 580);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(937, 34);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(740, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // plTitle
            // 
            this.plTitle.Controls.Add(this.label1);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plTitle.Location = new System.Drawing.Point(54, 20);
            this.plTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.plTitle.Size = new System.Drawing.Size(935, 30);
            this.plTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("仿宋", 14.25F);
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(929, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "项目阶段划分和经费安排";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.dgvDetail);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(53, 53);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(937, 521);
            this.plContent.TabIndex = 7;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvDetail.ColumnHeadersHeight = 35;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selpersonid,
            this.colJieDuanHuaFen,
            this.colYanJiuNeiRong,
            this.colJieDuanMuBiao,
            this.colJieDuanJingFei,
            this.delete});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.RowTemplate.Height = 35;
            this.dgvDetail.Size = new System.Drawing.Size(937, 521);
            this.dgvDetail.TabIndex = 5;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            this.dgvDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDetail_RowsAdded);
            // 
            // selpersonid
            // 
            this.selpersonid.HeaderText = "序号";
            this.selpersonid.Name = "selpersonid";
            this.selpersonid.ReadOnly = true;
            this.selpersonid.Width = 60;
            // 
            // colJieDuanHuaFen
            // 
            this.colJieDuanHuaFen.HeaderText = "阶段";
            this.colJieDuanHuaFen.Name = "colJieDuanHuaFen";
            this.colJieDuanHuaFen.ReadOnly = true;
            this.colJieDuanHuaFen.Width = 60;
            // 
            // colYanJiuNeiRong
            // 
            this.colYanJiuNeiRong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colYanJiuNeiRong.HeaderText = "研究内容";
            this.colYanJiuNeiRong.Name = "colYanJiuNeiRong";
            // 
            // colJieDuanMuBiao
            // 
            this.colJieDuanMuBiao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colJieDuanMuBiao.HeaderText = "阶段目标";
            this.colJieDuanMuBiao.Name = "colJieDuanMuBiao";
            // 
            // colJieDuanJingFei
            // 
            this.colJieDuanJingFei.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colJieDuanJingFei.HeaderText = "阶段经费";
            this.colJieDuanJingFei.Name = "colJieDuanJingFei";
            this.colJieDuanJingFei.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.Image = global::TestReporterPlugin.Resource.DELETE_16;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Visible = false;
            this.delete.Width = 60;
            // 
            // SubjectStepMoneyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubjectStepMoneyEditor";
            this.Size = new System.Drawing.Size(1043, 637);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.plTitle.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel plTitle;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn selpersonid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJieDuanHuaFen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYanJiuNeiRong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJieDuanMuBiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJieDuanJingFei;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}
