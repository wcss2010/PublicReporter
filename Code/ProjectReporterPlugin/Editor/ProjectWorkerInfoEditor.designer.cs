namespace ProjectReporterPlugin.Editor
{
    partial class ProjectWorkerInfoEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.plTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNewPerson = new System.Windows.Forms.Button();
            this.btnImporter = new System.Windows.Forms.Button();
            this.plContent = new System.Windows.Forms.Panel();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.ofdExcelDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.selpersonid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXingMing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZhiWu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCongShiZhuanYe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGongZuoDanWei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeiNianGongZuoShiJian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRenWuFenGong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXiangMuZhongZhiWu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.plTitle.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.plContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // plTitle
            // 
            this.plTitle.Controls.Add(this.label1);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plTitle.Location = new System.Drawing.Point(14, 10);
            this.plTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Size = new System.Drawing.Size(1153, 40);
            this.plTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("仿宋", 15F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(1153, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "负责人及研究骨干情况表";
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
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(1181, 572);
            this.tableLayoutPanel15.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnNewPerson, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImporter, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 525);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1155, 34);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnNewPerson
            // 
            this.btnNewPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewPerson.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewPerson.Location = new System.Drawing.Point(1058, 3);
            this.btnNewPerson.Name = "btnNewPerson";
            this.btnNewPerson.Size = new System.Drawing.Size(94, 28);
            this.btnNewPerson.TabIndex = 3;
            this.btnNewPerson.Text = "新增";
            this.btnNewPerson.Click += new System.EventHandler(this.btnNewPerson_Click);
            // 
            // btnImporter
            // 
            this.btnImporter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImporter.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImporter.Location = new System.Drawing.Point(958, 3);
            this.btnImporter.Name = "btnImporter";
            this.btnImporter.Size = new System.Drawing.Size(94, 28);
            this.btnImporter.TabIndex = 4;
            this.btnImporter.Text = "人员导入";
            this.btnImporter.Click += new System.EventHandler(this.btnImporter_Click);
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.dgvDetail);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(13, 53);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1155, 466);
            this.plContent.TabIndex = 7;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dgvDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvDetail.ColumnHeadersHeight = 35;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selpersonid,
            this.colXingMing,
            this.colSex,
            this.colZhiWu,
            this.colCongShiZhuanYe,
            this.colGongZuoDanWei,
            this.colMeiNianGongZuoShiJian,
            this.colRenWuFenGong,
            this.colIDCard,
            this.colXiangMuZhongZhiWu,
            this.delete,
            this.Column1,
            this.Column2});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowTemplate.Height = 35;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(1155, 466);
            this.dgvDetail.TabIndex = 5;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            this.dgvDetail.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentDoubleClick);
            this.dgvDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDetail_RowsAdded);
            // 
            // ofdExcelDialog
            // 
            this.ofdExcelDialog.Filter = "*.xls|*.xls";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "删除";
            this.dataGridViewImageColumn1.Image = global::ProjectReporterPlugin.Resource.DELETE_16;
            this.dataGridViewImageColumn1.MinimumWidth = 45;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 45;
            // 
            // selpersonid
            // 
            this.selpersonid.HeaderText = "序号";
            this.selpersonid.MinimumWidth = 60;
            this.selpersonid.Name = "selpersonid";
            this.selpersonid.ReadOnly = true;
            this.selpersonid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.selpersonid.Width = 60;
            // 
            // colXingMing
            // 
            this.colXingMing.HeaderText = "姓名";
            this.colXingMing.MinimumWidth = 60;
            this.colXingMing.Name = "colXingMing";
            this.colXingMing.ReadOnly = true;
            this.colXingMing.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colXingMing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colXingMing.Width = 60;
            // 
            // colSex
            // 
            this.colSex.HeaderText = "性别";
            this.colSex.MinimumWidth = 60;
            this.colSex.Name = "colSex";
            this.colSex.ReadOnly = true;
            this.colSex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSex.Width = 60;
            // 
            // colZhiWu
            // 
            this.colZhiWu.HeaderText = "职称";
            this.colZhiWu.MinimumWidth = 90;
            this.colZhiWu.Name = "colZhiWu";
            this.colZhiWu.ReadOnly = true;
            this.colZhiWu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colZhiWu.Width = 90;
            // 
            // colCongShiZhuanYe
            // 
            this.colCongShiZhuanYe.HeaderText = "专业";
            this.colCongShiZhuanYe.MinimumWidth = 90;
            this.colCongShiZhuanYe.Name = "colCongShiZhuanYe";
            this.colCongShiZhuanYe.ReadOnly = true;
            this.colCongShiZhuanYe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCongShiZhuanYe.Width = 90;
            // 
            // colGongZuoDanWei
            // 
            this.colGongZuoDanWei.HeaderText = "工作单位";
            this.colGongZuoDanWei.MinimumWidth = 90;
            this.colGongZuoDanWei.Name = "colGongZuoDanWei";
            this.colGongZuoDanWei.ReadOnly = true;
            this.colGongZuoDanWei.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colGongZuoDanWei.Width = 90;
            // 
            // colMeiNianGongZuoShiJian
            // 
            this.colMeiNianGongZuoShiJian.HeaderText = "每年投入时间";
            this.colMeiNianGongZuoShiJian.MinimumWidth = 110;
            this.colMeiNianGongZuoShiJian.Name = "colMeiNianGongZuoShiJian";
            this.colMeiNianGongZuoShiJian.ReadOnly = true;
            this.colMeiNianGongZuoShiJian.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMeiNianGongZuoShiJian.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMeiNianGongZuoShiJian.Width = 110;
            // 
            // colRenWuFenGong
            // 
            this.colRenWuFenGong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRenWuFenGong.HeaderText = "任务分工";
            this.colRenWuFenGong.MinimumWidth = 80;
            this.colRenWuFenGong.Name = "colRenWuFenGong";
            this.colRenWuFenGong.ReadOnly = true;
            this.colRenWuFenGong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colIDCard
            // 
            this.colIDCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colIDCard.HeaderText = "身份证号码";
            this.colIDCard.MinimumWidth = 70;
            this.colIDCard.Name = "colIDCard";
            this.colIDCard.ReadOnly = true;
            this.colIDCard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colXiangMuZhongZhiWu
            // 
            this.colXiangMuZhongZhiWu.HeaderText = "项目中职务";
            this.colXiangMuZhongZhiWu.MinimumWidth = 100;
            this.colXiangMuZhongZhiWu.Name = "colXiangMuZhongZhiWu";
            this.colXiangMuZhongZhiWu.ReadOnly = true;
            this.colXiangMuZhongZhiWu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colXiangMuZhongZhiWu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.MinimumWidth = 30;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.delete.Width = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 30;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.MinimumWidth = 30;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 30;
            // 
            // ProjectWorkerInfoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProjectWorkerInfoEditor";
            this.Size = new System.Drawing.Size(1181, 572);
            this.plTitle.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnNewPerson;
        private System.Windows.Forms.OpenFileDialog ofdExcelDialog;
        private System.Windows.Forms.Button btnImporter;
        private System.Windows.Forms.DataGridViewTextBoxColumn selpersonid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colXingMing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZhiWu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCongShiZhuanYe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGongZuoDanWei;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeiNianGongZuoShiJian;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRenWuFenGong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colXiangMuZhongZhiWu;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
    }
}
