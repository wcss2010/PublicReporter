namespace ProjectMilitaryTechnologPlanPlugin.Editor
{
	partial class SummaryEditor
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
            this.lblInfo = new ProjectMilitaryTechnologPlanPlugin.Controls.AutoHeightLabel();
            this.plMain = new System.Windows.Forms.Panel();
            this.plContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ibEdit1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibEdit2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ibEdit3 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ibEdit4 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ibEdit7 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ibEdit6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ibEdit5 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ibEdit10 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ibEdit9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ibEdit8 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.plMain.SuspendLayout();
            this.plContent.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit4)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.plButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoHeight = true;
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("仿宋", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.Location = new System.Drawing.Point(10, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblInfo.Size = new System.Drawing.Size(1063, 51);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "请科学严谨、实事求是填写，表述要清晰准确。";
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.plContent);
            this.plMain.Controls.Add(this.plButtons);
            this.plMain.Controls.Add(this.lblInfo);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Margin = new System.Windows.Forms.Padding(0);
            this.plMain.Name = "plMain";
            this.plMain.Padding = new System.Windows.Forms.Padding(10);
            this.plMain.Size = new System.Drawing.Size(1083, 669);
            this.plMain.TabIndex = 1;
            // 
            // plContent
            // 
            this.plContent.AutoScroll = true;
            this.plContent.BackColor = System.Drawing.SystemColors.Control;
            this.plContent.Controls.Add(this.flowLayoutPanel1);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(10, 61);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1063, 563);
            this.plContent.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1063, 563);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ibEdit1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 29);
            this.panel1.TabIndex = 0;
            // 
            // ibEdit1
            // 
            this.ibEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibEdit1.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit1.Location = new System.Drawing.Point(92, 0);
            this.ibEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.ibEdit1.Name = "ibEdit1";
            this.ibEdit1.Size = new System.Drawing.Size(879, 26);
            this.ibEdit1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("仿宋", 12F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "项目名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ibEdit2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(971, 108);
            this.panel2.TabIndex = 1;
            // 
            // ibEdit2
            // 
            this.ibEdit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibEdit2.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit2.Location = new System.Drawing.Point(92, 0);
            this.ibEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.ibEdit2.Multiline = true;
            this.ibEdit2.Name = "ibEdit2";
            this.ibEdit2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ibEdit2.Size = new System.Drawing.Size(879, 108);
            this.ibEdit2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("仿宋", 12F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 108);
            this.label2.TabIndex = 1;
            this.label2.Text = "研究目标：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ibEdit3);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(3, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(971, 229);
            this.panel3.TabIndex = 2;
            // 
            // ibEdit3
            // 
            this.ibEdit3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ibEdit3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5});
            this.ibEdit3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibEdit3.Location = new System.Drawing.Point(92, 0);
            this.ibEdit3.MultiSelect = false;
            this.ibEdit3.Name = "ibEdit3";
            this.ibEdit3.RowTemplate.Height = 23;
            this.ibEdit3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ibEdit3.Size = new System.Drawing.Size(879, 229);
            this.ibEdit3.TabIndex = 2;
            this.ibEdit3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ibEdit3_CellContentClick);
            this.ibEdit3.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ibEdit3_RowPostPaint);
            this.ibEdit3.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ibEdit3_RowsAdded);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "内容";
            this.Column1.Name = "Column1";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "";
            this.Column5.MinimumWidth = 60;
            this.Column5.Name = "Column5";
            this.Column5.Text = "删除";
            this.Column5.UseColumnTextForButtonValue = true;
            this.Column5.Width = 60;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("仿宋", 12F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 229);
            this.label3.TabIndex = 1;
            this.label3.Text = "研究内容：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ibEdit4);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(3, 387);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(971, 226);
            this.panel4.TabIndex = 3;
            // 
            // ibEdit4
            // 
            this.ibEdit4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ibEdit4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4});
            this.ibEdit4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibEdit4.Location = new System.Drawing.Point(92, 0);
            this.ibEdit4.MultiSelect = false;
            this.ibEdit4.Name = "ibEdit4";
            this.ibEdit4.RowTemplate.Height = 23;
            this.ibEdit4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ibEdit4.Size = new System.Drawing.Size(879, 226);
            this.ibEdit4.TabIndex = 3;
            this.ibEdit4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ibEdit4_CellContentClick);
            this.ibEdit4.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ibEdit4_RowPostPaint);
            this.ibEdit4.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ibEdit4_RowsAdded);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "项目";
            this.Column2.Items.AddRange(new object[] {
            "著作(本)",
            "综合报告(份)",
            "分报告(份)",
            "学术论文(篇)",
            "作战想定(份)",
            "工具手册(本)",
            "译著(本)",
            "标准规范(套)",
            "需求清单(套)",
            "思维导图集(套)",
            "专利(项)",
            "软件系统(套)",
            "分析算法(套)",
            "数据库(套)",
            "资料整编(份)"});
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "值";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.MinimumWidth = 60;
            this.Column4.Name = "Column4";
            this.Column4.Text = "删除";
            this.Column4.UseColumnTextForButtonValue = true;
            this.Column4.Width = 60;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("仿宋", 12F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 226);
            this.label4.TabIndex = 1;
            this.label4.Text = "预期成果：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ibEdit7);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.ibEdit6);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.ibEdit5);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(3, 619);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(971, 28);
            this.panel5.TabIndex = 4;
            // 
            // ibEdit7
            // 
            this.ibEdit7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibEdit7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ibEdit7.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit7.FormattingEnabled = true;
            this.ibEdit7.Items.AddRange(new object[] {
            "未知"});
            this.ibEdit7.Location = new System.Drawing.Point(544, 0);
            this.ibEdit7.Margin = new System.Windows.Forms.Padding(4);
            this.ibEdit7.Name = "ibEdit7";
            this.ibEdit7.Size = new System.Drawing.Size(427, 24);
            this.ibEdit7.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("仿宋", 12F);
            this.label7.Location = new System.Drawing.Point(449, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 28);
            this.label7.TabIndex = 1;
            this.label7.Text = "项目类别：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("仿宋", 12F);
            this.label11.Location = new System.Drawing.Point(407, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 28);
            this.label11.TabIndex = 6;
            this.label11.Text = "万元";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ibEdit6
            // 
            this.ibEdit6.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibEdit6.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit6.Location = new System.Drawing.Point(307, 0);
            this.ibEdit6.Margin = new System.Windows.Forms.Padding(4);
            this.ibEdit6.Name = "ibEdit6";
            this.ibEdit6.Size = new System.Drawing.Size(100, 26);
            this.ibEdit6.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("仿宋", 12F);
            this.label6.Location = new System.Drawing.Point(215, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "经费概算：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ibEdit5
            // 
            this.ibEdit5.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibEdit5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ibEdit5.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit5.FormattingEnabled = true;
            this.ibEdit5.Items.AddRange(new object[] {
            "未知"});
            this.ibEdit5.Location = new System.Drawing.Point(92, 0);
            this.ibEdit5.Margin = new System.Windows.Forms.Padding(4);
            this.ibEdit5.Name = "ibEdit5";
            this.ibEdit5.Size = new System.Drawing.Size(123, 24);
            this.ibEdit5.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("仿宋", 12F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "研究周期：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ibEdit10);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.ibEdit9);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.ibEdit8);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(3, 653);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(971, 30);
            this.panel6.TabIndex = 5;
            // 
            // ibEdit10
            // 
            this.ibEdit10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibEdit10.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit10.Location = new System.Drawing.Point(784, 0);
            this.ibEdit10.Margin = new System.Windows.Forms.Padding(4);
            this.ibEdit10.Name = "ibEdit10";
            this.ibEdit10.Size = new System.Drawing.Size(187, 30);
            this.ibEdit10.TabIndex = 4;
            this.ibEdit10.Text = "选择";
            this.ibEdit10.UseVisualStyleBackColor = true;
            this.ibEdit10.Click += new System.EventHandler(this.ibEdit10_Click);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("仿宋", 12F);
            this.label10.Location = new System.Drawing.Point(718, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 30);
            this.label10.TabIndex = 1;
            this.label10.Text = "备注：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ibEdit9
            // 
            this.ibEdit9.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibEdit9.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit9.Location = new System.Drawing.Point(499, 0);
            this.ibEdit9.Margin = new System.Windows.Forms.Padding(4);
            this.ibEdit9.Name = "ibEdit9";
            this.ibEdit9.Size = new System.Drawing.Size(219, 26);
            this.ibEdit9.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("仿宋", 12F);
            this.label9.Location = new System.Drawing.Point(407, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 30);
            this.label9.TabIndex = 1;
            this.label9.Text = "下级单位：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ibEdit8
            // 
            this.ibEdit8.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibEdit8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ibEdit8.Font = new System.Drawing.Font("仿宋", 12F);
            this.ibEdit8.FormattingEnabled = true;
            this.ibEdit8.Items.AddRange(new object[] {
            "未知"});
            this.ibEdit8.Location = new System.Drawing.Point(92, 0);
            this.ibEdit8.Margin = new System.Windows.Forms.Padding(4);
            this.ibEdit8.Name = "ibEdit8";
            this.ibEdit8.Size = new System.Drawing.Size(315, 24);
            this.ibEdit8.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("仿宋", 12F);
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "责任单位：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnSave);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(10, 624);
            this.plButtons.Name = "plButtons";
            this.plButtons.Padding = new System.Windows.Forms.Padding(3);
            this.plButtons.Size = new System.Drawing.Size(1063, 35);
            this.plButtons.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(970, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SummaryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.plMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SummaryEditor";
            this.Size = new System.Drawing.Size(1083, 669);
            this.plMain.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit3)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibEdit4)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.plButtons.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private Controls.AutoHeightLabel lblInfo;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ibEdit1;
        private System.Windows.Forms.TextBox ibEdit2;
        private System.Windows.Forms.DataGridView ibEdit3;
        private System.Windows.Forms.DataGridView ibEdit4;
        private System.Windows.Forms.ComboBox ibEdit5;
        private System.Windows.Forms.TextBox ibEdit6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ibEdit7;
        private System.Windows.Forms.ComboBox ibEdit8;
        private System.Windows.Forms.TextBox ibEdit9;
        private System.Windows.Forms.Button ibEdit10;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
    }
}