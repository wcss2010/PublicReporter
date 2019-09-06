namespace ProjectContractPlugin.Editor
{
    partial class SubjectTableEditor
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.plTitle = new System.Windows.Forms.Panel();
            this.label1 = new ProjectContractPlugin.Controls.AutoHeightLabel();
            this.plContent = new System.Windows.Forms.Panel();
            this.kvKetiTabs = new System.Windows.Forms.TabControl();
            this.kpKetiItems = new System.Windows.Forms.TabPage();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.selpersonid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeTiMingCheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMiJi = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFuZeRen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonIDCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChengDanDanWeiMingCheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChengDanDanWeiKaiHuXhangHao = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colNeiRong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZongTiKeTi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMakePage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.plTitle.SuspendLayout();
            this.plContent.SuspendLayout();
            this.kvKetiTabs.SuspendLayout();
            this.kpKetiItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel15.Controls.Add(this.tableLayoutPanel1, 1, 3);
            this.tableLayoutPanel15.Controls.Add(this.plTitle, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.plContent, 1, 2);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 5;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(789, 511);
            this.tableLayoutPanel15.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 464);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(763, 34);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(666, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(566, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 27);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "增加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // plTitle
            // 
            this.plTitle.AutoSize = true;
            this.plTitle.Controls.Add(this.label1);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plTitle.Location = new System.Drawing.Point(14, 10);
            this.plTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.plTitle.Size = new System.Drawing.Size(761, 68);
            this.plTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoHeight = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("仿宋", 14.25F);
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(755, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "围绕如何全面的、有效的实现项目目标，进行课题分解，明确每个课题的密级，并简述研究内容；牵头申报单位承担的课题数不超过课题总数的三分之二";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.kvKetiTabs);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(13, 81);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(763, 377);
            this.plContent.TabIndex = 7;
            // 
            // kvKetiTabs
            // 
            this.kvKetiTabs.Controls.Add(this.kpKetiItems);
            this.kvKetiTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kvKetiTabs.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kvKetiTabs.Location = new System.Drawing.Point(0, 0);
            this.kvKetiTabs.Name = "kvKetiTabs";
            this.kvKetiTabs.SelectedIndex = 0;
            this.kvKetiTabs.Size = new System.Drawing.Size(763, 377);
            this.kvKetiTabs.TabIndex = 4;
            // 
            // kpKetiItems
            // 
            this.kpKetiItems.Controls.Add(this.dgvDetail);
            this.kpKetiItems.Location = new System.Drawing.Point(4, 26);
            this.kpKetiItems.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpKetiItems.Name = "kpKetiItems";
            this.kpKetiItems.Size = new System.Drawing.Size(755, 347);
            this.kpKetiItems.TabIndex = 0;
            this.kpKetiItems.Text = "课题列表";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvDetail.ColumnHeadersHeight = 35;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selpersonid,
            this.colKeTiMingCheng,
            this.colMiJi,
            this.colFuZeRen,
            this.colPersonIDCard,
            this.colChengDanDanWeiMingCheng,
            this.colChengDanDanWeiKaiHuXhangHao,
            this.colNeiRong,
            this.colZongTiKeTi,
            this.colMakePage,
            this.delete,
            this.colDetail});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.RowTemplate.Height = 35;
            this.dgvDetail.Size = new System.Drawing.Size(755, 347);
            this.dgvDetail.TabIndex = 3;
            this.dgvDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDetail_CellBeginEdit);
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
            // colKeTiMingCheng
            // 
            this.colKeTiMingCheng.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKeTiMingCheng.HeaderText = "课题名称";
            this.colKeTiMingCheng.Name = "colKeTiMingCheng";
            this.colKeTiMingCheng.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colMiJi
            // 
            this.colMiJi.DropDownWidth = 121;
            this.colMiJi.HeaderText = "密级";
            this.colMiJi.Name = "colMiJi";
            this.colMiJi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMiJi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMiJi.Width = 60;
            // 
            // colFuZeRen
            // 
            this.colFuZeRen.HeaderText = "负责人";
            this.colFuZeRen.Name = "colFuZeRen";
            this.colFuZeRen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFuZeRen.Width = 80;
            // 
            // colPersonIDCard
            // 
            this.colPersonIDCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPersonIDCard.HeaderText = "身份证号";
            this.colPersonIDCard.Name = "colPersonIDCard";
            this.colPersonIDCard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colChengDanDanWeiMingCheng
            // 
            this.colChengDanDanWeiMingCheng.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChengDanDanWeiMingCheng.HeaderText = "承担单位名称";
            this.colChengDanDanWeiMingCheng.Name = "colChengDanDanWeiMingCheng";
            // 
            // colChengDanDanWeiKaiHuXhangHao
            // 
            this.colChengDanDanWeiKaiHuXhangHao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChengDanDanWeiKaiHuXhangHao.HeaderText = "承担单位开户帐号";
            this.colChengDanDanWeiKaiHuXhangHao.Name = "colChengDanDanWeiKaiHuXhangHao";
            this.colChengDanDanWeiKaiHuXhangHao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colChengDanDanWeiKaiHuXhangHao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colChengDanDanWeiKaiHuXhangHao.Visible = false;
            // 
            // colNeiRong
            // 
            this.colNeiRong.HeaderText = "研究经费(万)";
            this.colNeiRong.Name = "colNeiRong";
            this.colNeiRong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colNeiRong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNeiRong.Width = 110;
            // 
            // colZongTiKeTi
            // 
            this.colZongTiKeTi.HeaderText = "总体课题";
            this.colZongTiKeTi.Name = "colZongTiKeTi";
            this.colZongTiKeTi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colZongTiKeTi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colZongTiKeTi.Visible = false;
            this.colZongTiKeTi.Width = 76;
            // 
            // colMakePage
            // 
            this.colMakePage.HeaderText = "";
            this.colMakePage.Name = "colMakePage";
            this.colMakePage.ReadOnly = true;
            this.colMakePage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMakePage.Text = "生成详细页";
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.Image = global::ProjectContractPlugin.Resource.DELETE_16;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Width = 60;
            // 
            // colDetail
            // 
            this.colDetail.HeaderText = "详细";
            this.colDetail.Image = global::ProjectContractPlugin.Resource.exclamation_16;
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            this.colDetail.Visible = false;
            this.colDetail.Width = 60;
            // 
            // SubjectTableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubjectTableEditor";
            this.Size = new System.Drawing.Size(789, 511);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.plTitle.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.kvKetiTabs.ResumeLayout(false);
            this.kpKetiItems.ResumeLayout(false);
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
        private ProjectContractPlugin.Controls.AutoHeightLabel label1;
        private System.Windows.Forms.TabControl kvKetiTabs;
        private System.Windows.Forms.TabPage kpKetiItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn selpersonid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeTiMingCheng;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMiJi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuZeRen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonIDCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChengDanDanWeiMingCheng;
        private System.Windows.Forms.DataGridViewButtonColumn colChengDanDanWeiKaiHuXhangHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNeiRong;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colZongTiKeTi;
        private System.Windows.Forms.DataGridViewButtonColumn colMakePage;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewImageColumn colDetail;
        private System.Windows.Forms.Button btnAdd;
    }
}