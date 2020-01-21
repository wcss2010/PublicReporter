namespace ProjectStrategicLeadershipPlugin.Editor
{
    partial class SubjectEditor
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
            this.plMain = new System.Windows.Forms.Panel();
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
            this.lblInfo = new AbstractEditorPlugin.Controls.AutoHeightLabel();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.plMain.SuspendLayout();
            this.plContent.SuspendLayout();
            this.kvKetiTabs.SuspendLayout();
            this.kpKetiItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.plButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.plContent);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Margin = new System.Windows.Forms.Padding(0);
            this.plMain.Name = "plMain";
            this.plMain.Padding = new System.Windows.Forms.Padding(10);
            this.plMain.Size = new System.Drawing.Size(1095, 691);
            this.plMain.TabIndex = 4;
            // 
            // plContent
            // 
            this.plContent.AutoScroll = true;
            this.plContent.BackColor = System.Drawing.SystemColors.Control;
            this.plContent.Controls.Add(this.kvKetiTabs);
            this.plContent.Controls.Add(this.lblInfo);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(10, 10);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1075, 671);
            this.plContent.TabIndex = 1;
            // 
            // kvKetiTabs
            // 
            this.kvKetiTabs.Controls.Add(this.kpKetiItems);
            this.kvKetiTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kvKetiTabs.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kvKetiTabs.Location = new System.Drawing.Point(0, 51);
            this.kvKetiTabs.Name = "kvKetiTabs";
            this.kvKetiTabs.SelectedIndex = 0;
            this.kvKetiTabs.Size = new System.Drawing.Size(1075, 620);
            this.kvKetiTabs.TabIndex = 5;
            // 
            // kpKetiItems
            // 
            this.kpKetiItems.Controls.Add(this.dgvDetail);
            this.kpKetiItems.Controls.Add(this.plButtons);
            this.kpKetiItems.Location = new System.Drawing.Point(4, 26);
            this.kpKetiItems.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpKetiItems.Name = "kpKetiItems";
            this.kpKetiItems.Size = new System.Drawing.Size(1067, 590);
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
            this.dgvDetail.Size = new System.Drawing.Size(1067, 555);
            this.dgvDetail.TabIndex = 3;
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
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Width = 60;
            // 
            // colDetail
            // 
            this.colDetail.HeaderText = "详细";
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            this.colDetail.Visible = false;
            this.colDetail.Width = 60;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoHeight = true;
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("仿宋", 15.75F);
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblInfo.Size = new System.Drawing.Size(1075, 51);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "请科学严谨、实事求是填写，表述要清晰准确。";
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnAdd);
            this.plButtons.Controls.Add(this.btnEdit);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(0, 555);
            this.plButtons.Name = "plButtons";
            this.plButtons.Padding = new System.Windows.Forms.Padding(3);
            this.plButtons.Size = new System.Drawing.Size(1067, 35);
            this.plButtons.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(884, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 29);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "增加";
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(974, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 29);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "编辑";
            // 
            // SubjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.plMain);
            this.Name = "SubjectEditor";
            this.Size = new System.Drawing.Size(1095, 691);
            this.plMain.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.kvKetiTabs.ResumeLayout(false);
            this.kpKetiItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.plButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Panel plContent;
        private AbstractEditorPlugin.Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.TabControl kvKetiTabs;
        private System.Windows.Forms.TabPage kpKetiItems;
        private System.Windows.Forms.DataGridView dgvDetail;
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
        private System.Windows.Forms.Button btnEdit;
    }
}
