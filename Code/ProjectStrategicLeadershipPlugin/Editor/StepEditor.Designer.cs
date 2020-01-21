namespace ProjectStrategicLeadershipPlugin.Editor
{
    partial class StepEditor
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
            this.plMain = new System.Windows.Forms.Panel();
            this.plContent = new System.Windows.Forms.Panel();
            this.lblInfo = new AbstractEditorPlugin.Controls.AutoHeightLabel();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.selpersonid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeTi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJieDuanHuaHuaFen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJieDuanJingFei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.plMain.SuspendLayout();
            this.plContent.SuspendLayout();
            this.plButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.plContent);
            this.plMain.Controls.Add(this.plButtons);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Margin = new System.Windows.Forms.Padding(0);
            this.plMain.Name = "plMain";
            this.plMain.Padding = new System.Windows.Forms.Padding(10);
            this.plMain.Size = new System.Drawing.Size(1100, 699);
            this.plMain.TabIndex = 4;
            // 
            // plContent
            // 
            this.plContent.AutoScroll = true;
            this.plContent.BackColor = System.Drawing.SystemColors.Control;
            this.plContent.Controls.Add(this.dgvDetail);
            this.plContent.Controls.Add(this.lblInfo);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(10, 10);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1080, 644);
            this.plContent.TabIndex = 1;
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
            this.lblInfo.Size = new System.Drawing.Size(1080, 51);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "请科学严谨、实事求是填写，表述要清晰准确。";
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnAdd);
            this.plButtons.Controls.Add(this.btnEdit);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(10, 654);
            this.plButtons.Name = "plButtons";
            this.plButtons.Padding = new System.Windows.Forms.Padding(3);
            this.plButtons.Size = new System.Drawing.Size(1080, 35);
            this.plButtons.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(897, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 29);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "增加";
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(987, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 29);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "编辑";
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
            this.colKeTi,
            this.colJieDuanHuaHuaFen,
            this.colDest,
            this.colContent,
            this.colResult,
            this.colTarget,
            this.colJieDuanJingFei,
            this.delete});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 51);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("仿宋", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("仿宋", 12F);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.RowTemplate.Height = 35;
            this.dgvDetail.Size = new System.Drawing.Size(1080, 593);
            this.dgvDetail.TabIndex = 6;
            // 
            // selpersonid
            // 
            this.selpersonid.HeaderText = "序号";
            this.selpersonid.MinimumWidth = 80;
            this.selpersonid.Name = "selpersonid";
            this.selpersonid.Visible = false;
            this.selpersonid.Width = 80;
            // 
            // colKeTi
            // 
            this.colKeTi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colKeTi.HeaderText = "课题";
            this.colKeTi.MinimumWidth = 69;
            this.colKeTi.Name = "colKeTi";
            this.colKeTi.ReadOnly = true;
            this.colKeTi.Width = 69;
            // 
            // colJieDuanHuaHuaFen
            // 
            this.colJieDuanHuaHuaFen.HeaderText = "阶段";
            this.colJieDuanHuaHuaFen.MinimumWidth = 60;
            this.colJieDuanHuaHuaFen.Name = "colJieDuanHuaHuaFen";
            this.colJieDuanHuaHuaFen.ReadOnly = true;
            this.colJieDuanHuaHuaFen.Width = 60;
            // 
            // colDest
            // 
            this.colDest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDest.HeaderText = "阶段目标与研究内容";
            this.colDest.Name = "colDest";
            this.colDest.ReadOnly = true;
            // 
            // colContent
            // 
            this.colContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colContent.HeaderText = "完成内容";
            this.colContent.Name = "colContent";
            this.colContent.Visible = false;
            // 
            // colResult
            // 
            this.colResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colResult.HeaderText = "阶段成果、考核指标及考核方式";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            // 
            // colTarget
            // 
            this.colTarget.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTarget.HeaderText = "考核指标";
            this.colTarget.Name = "colTarget";
            this.colTarget.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTarget.Visible = false;
            // 
            // colJieDuanJingFei
            // 
            this.colJieDuanJingFei.HeaderText = "阶段经费(万)";
            this.colJieDuanJingFei.MinimumWidth = 110;
            this.colJieDuanJingFei.Name = "colJieDuanJingFei";
            this.colJieDuanJingFei.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colJieDuanJingFei.Width = 110;
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.MinimumWidth = 60;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Visible = false;
            this.delete.Width = 60;
            // 
            // StepEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.plMain);
            this.Name = "StepEditor";
            this.Size = new System.Drawing.Size(1100, 699);
            this.plMain.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.plButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Panel plContent;
        private AbstractEditorPlugin.Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn selpersonid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeTi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJieDuanHuaHuaFen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJieDuanJingFei;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}
