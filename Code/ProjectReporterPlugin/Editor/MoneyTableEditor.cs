using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ProjectReporterPlugin.DB.Entitys;
using ProjectReporterPlugin.DB;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace ProjectReporterPlugin.Editor
{
    public class MoneyTableEditor : BaseEditor
	{
		private IContainer components;

		private TableLayoutPanel tableLayoutPanel1;

		private TextBox ProjectRFA2_1Rm;

		private TextBox ProjectRFA2Rm;

		private TextBox ProjectRFA1_9Rm;

		private TextBox ProjectRFA1_8Rm;

		private TextBox ProjectRFA1_7Rm;

		private TextBox ProjectRFA1_6Rm;

		private TextBox ProjectRFA1_5Rm;

		private TextBox ProjectRFA1_4Rm;

		private TextBox ProjectRFA1_3Rm;

		private TextBox ProjectRFA1_2Rm;

		private TextBox ProjectRFA1_1_3Rm;

		private TextBox ProjectRFA1_1_2Rm;

		private TextBox ProjectRFA1_1_1Rm;

		private TextBox ProjectRFA1_1Rm;

		private Label kryptonLabel39;

		private Label kryptonLabel38;

		private Label kryptonLabel37;

		private Label kryptonLabel36;

		private Label kryptonLabel30;

		private Label ProjectRFA;

		private TextBox ProjectRFARm;

		private Label kryptonLabel42;

		private Label kryptonLabel43;

		private Label kryptonLabel44;

		private Label kryptonLabel41;

		private Label kryptonLabel46;

		private Label kryptonLabel47;

		private Label kryptonLabel48;

		private Label ProjectRFA1;

		private Label kryptonLabel50;

		private Label kryptonLabel51;

		private Label kryptonLabel52;

		private Label kryptonLabel53;

		private Label kryptonLabel54;

		private Label kryptonLabel55;

		private Label kryptonLabel56;

		private Label kryptonLabel57;

		private Label ProjectRFA1_1;

		private TextBox ProjectRFA1_1_1;

		private TextBox ProjectRFA1_1_2;

		private TextBox ProjectRFA1_1_3;

		private TextBox ProjectRFA1_2;

        private TextBox ProjectRFA1_3;

		private TextBox ProjectRFA1_4;

		private TextBox ProjectRFA1Rm;

		private TextBox ProjectRFA1_5;

		private TextBox ProjectRFA1_6;

		private TextBox ProjectRFA1_7;

		private TextBox ProjectRFA1_8;

		private TextBox ProjectRFA1_9;

		private TextBox ProjectRFA2_1;

		private Label ProjectRFA2;

		private Label ProjectRFA1_5zb;

		private Label ProjectRFA1zb;

		private Label ProjectRFA1_1zb;

		private Label ProjectRFA1_1_1zb;

		private Label ProjectRFA1_1_2zb;

		private Label ProjectRFA1_1_3zb;

		private Label ProjectRFA1_2zb;

		private Label ProjectRFA1_3zb;

		private Label ProjectRFA1_4zb;

		private Label ProjectRFA1_6zb;

		private Label ProjectRFA1_8zb;

		private Label ProjectRFA1_7zb;

		private Label ProjectRFA1_9zb;

		private Label ProjectRFA2zb;

		private Label ProjectRFA2_1zb;

		private Panel kryptonPanel18;

		private Label kryptonLabel92;

		private Label kryptonLabel93;

		private Label kryptonLabel94;

		private Label kryptonLabel95;

		private Label kryptonLabel96;

		private Label kryptonLabel97;

		private TextBox ProjectOutlay1;

		private TextBox ProjectOutlay2;

		private TextBox ProjectOutlay3;

		private TextBox ProjectOutlay4;

        private TextBox ProjectOutlay5;

		private ProjectReporterPlugin.Controls.HSkinTableLayoutPanel tableLayoutPanel2;

        private ProjectReporterPlugin.Controls.HSkinTableLayoutPanel tableLayoutPanel3;

        private ProjectBudgetInfo pbinfo = new ProjectBudgetInfo();
        private TableLayoutPanel tableLayoutPanel4;
        private Button btnSave;
        private Label kryptonLabel1;
        private Panel panel1;
        private TextBox txtZiChouJingFei;
        private Panel panel3;
        private Label kryptonLabel3;
        private Label kryptonLabel4;
        private Panel plBottomInfoBox;
        private Panel panel2;
        private Label kryptonLabel2;
        private LinkLabel lklDownloadFuJian;
        private Label kryptonLabel5;
        private Label kryptonLabel6;
        private Label kryptonLabel7;
        private TextBox ProjectRFA1_3_2Rm;
        private TextBox ProjectRFA1_3_1Rm;
        private TextBox ProjectRFA1_3_1;
        private TextBox ProjectRFA1_3_2;
        private Panel panel4;
        private LinkLabel lklDownloadExcel;
        private Button btnExcelLoad;
        private OpenFileDialog ofdExcelDialog;
        private bool issaved;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new ProjectReporterPlugin.Controls.HSkinTableLayoutPanel();
            this.kryptonLabel6 = new System.Windows.Forms.Label();
            this.ProjectRFA2_1Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA2Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_9Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_8Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_7Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_6Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_5Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_4Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_3Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_2Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_1_3Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_1_2Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_1_1Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_1Rm = new System.Windows.Forms.TextBox();
            this.kryptonLabel39 = new System.Windows.Forms.Label();
            this.kryptonLabel38 = new System.Windows.Forms.Label();
            this.kryptonLabel37 = new System.Windows.Forms.Label();
            this.kryptonLabel36 = new System.Windows.Forms.Label();
            this.kryptonLabel30 = new System.Windows.Forms.Label();
            this.ProjectRFA = new System.Windows.Forms.Label();
            this.ProjectRFARm = new System.Windows.Forms.TextBox();
            this.kryptonLabel42 = new System.Windows.Forms.Label();
            this.kryptonLabel43 = new System.Windows.Forms.Label();
            this.kryptonLabel44 = new System.Windows.Forms.Label();
            this.kryptonLabel41 = new System.Windows.Forms.Label();
            this.kryptonLabel46 = new System.Windows.Forms.Label();
            this.kryptonLabel47 = new System.Windows.Forms.Label();
            this.kryptonLabel48 = new System.Windows.Forms.Label();
            this.ProjectRFA1 = new System.Windows.Forms.Label();
            this.kryptonLabel50 = new System.Windows.Forms.Label();
            this.kryptonLabel51 = new System.Windows.Forms.Label();
            this.kryptonLabel52 = new System.Windows.Forms.Label();
            this.kryptonLabel53 = new System.Windows.Forms.Label();
            this.kryptonLabel54 = new System.Windows.Forms.Label();
            this.kryptonLabel55 = new System.Windows.Forms.Label();
            this.kryptonLabel56 = new System.Windows.Forms.Label();
            this.kryptonLabel57 = new System.Windows.Forms.Label();
            this.ProjectRFA1_1 = new System.Windows.Forms.Label();
            this.ProjectRFA1_1_1 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_1_2 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_1_3 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_2 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_3 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_4 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_5 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_6 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_7 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_8 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_9 = new System.Windows.Forms.TextBox();
            this.ProjectRFA2_1 = new System.Windows.Forms.TextBox();
            this.ProjectRFA2 = new System.Windows.Forms.Label();
            this.ProjectRFA1_5zb = new System.Windows.Forms.Label();
            this.ProjectRFA1zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_1zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_1_1zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_1_2zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_1_3zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_2zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_3zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_4zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_6zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_8zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_7zb = new System.Windows.Forms.Label();
            this.ProjectRFA1_9zb = new System.Windows.Forms.Label();
            this.ProjectRFA2zb = new System.Windows.Forms.Label();
            this.ProjectRFA2_1zb = new System.Windows.Forms.Label();
            this.kryptonLabel7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new ProjectReporterPlugin.Controls.HSkinTableLayoutPanel();
            this.kryptonPanel18 = new System.Windows.Forms.Panel();
            this.ProjectRFA1_3_1 = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_3_1Rm = new System.Windows.Forms.TextBox();
            this.ProjectRFA1_3_2Rm = new System.Windows.Forms.TextBox();
            this.kryptonLabel92 = new System.Windows.Forms.Label();
            this.ProjectRFA1_3_2 = new System.Windows.Forms.TextBox();
            this.kryptonLabel93 = new System.Windows.Forms.Label();
            this.kryptonLabel94 = new System.Windows.Forms.Label();
            this.kryptonLabel95 = new System.Windows.Forms.Label();
            this.kryptonLabel96 = new System.Windows.Forms.Label();
            this.kryptonLabel97 = new System.Windows.Forms.Label();
            this.ProjectOutlay1 = new System.Windows.Forms.TextBox();
            this.ProjectOutlay2 = new System.Windows.Forms.TextBox();
            this.ProjectOutlay3 = new System.Windows.Forms.TextBox();
            this.ProjectOutlay4 = new System.Windows.Forms.TextBox();
            this.ProjectOutlay5 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonLabel1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.plBottomInfoBox = new System.Windows.Forms.Panel();
            this.txtZiChouJingFei = new System.Windows.Forms.TextBox();
            this.kryptonLabel4 = new System.Windows.Forms.Label();
            this.kryptonLabel3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lklDownloadFuJian = new System.Windows.Forms.LinkLabel();
            this.kryptonLabel5 = new System.Windows.Forms.Label();
            this.kryptonLabel2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExcelLoad = new System.Windows.Forms.Button();
            this.lklDownloadExcel = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ofdExcelDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.kryptonPanel18.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.plBottomInfoBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(906, 677);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.BorderColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel6, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA2_1Rm, 2, 18);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA2Rm, 2, 17);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_9Rm, 2, 16);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_8Rm, 2, 15);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_7Rm, 2, 14);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_6Rm, 2, 13);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_5Rm, 2, 12);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_4Rm, 2, 11);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_3Rm, 2, 8);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_2Rm, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1_3Rm, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1_2Rm, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1_1Rm, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1Rm, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel39, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel38, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel37, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel36, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel30, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFARm, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel42, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel43, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel44, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel41, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel46, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel47, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel48, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel50, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel51, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel52, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel53, 0, 14);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel54, 0, 15);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel55, 0, 16);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel56, 0, 17);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel57, 0, 18);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1_1, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1_2, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1_3, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_2, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_3, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_4, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1Rm, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_5, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_6, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_7, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_8, 1, 15);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_9, 1, 16);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA2_1, 1, 18);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA2, 1, 17);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_5zb, 3, 12);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1zb, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1zb, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1_1zb, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1_2zb, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_1_3zb, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_2zb, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_3zb, 3, 8);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_4zb, 3, 11);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_6zb, 3, 13);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_8zb, 3, 15);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_7zb, 3, 14);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA1_9zb, 3, 16);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA2zb, 3, 17);
            this.tableLayoutPanel2.Controls.Add(this.ProjectRFA2_1zb, 3, 18);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel7, 0, 10);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(184, 56);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 19;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(537, 510);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel6.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel6.Location = new System.Drawing.Point(3, 270);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.kryptonLabel6.Size = new System.Drawing.Size(211, 1);
            this.kryptonLabel6.TabIndex = 11;
            this.kryptonLabel6.Text = "（1）检验、测试、化验、加工费";
            // 
            // ProjectRFA2_1Rm
            // 
            this.ProjectRFA2_1Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA2_1Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA2_1Rm.Location = new System.Drawing.Point(339, 482);
            this.ProjectRFA2_1Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA2_1Rm.Name = "ProjectRFA2_1Rm";
            this.ProjectRFA2_1Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA2_1Rm.TabIndex = 86;
            // 
            // ProjectRFA2Rm
            // 
            this.ProjectRFA2Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA2Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA2Rm.Location = new System.Drawing.Point(339, 452);
            this.ProjectRFA2Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA2Rm.Name = "ProjectRFA2Rm";
            this.ProjectRFA2Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA2Rm.TabIndex = 85;
            // 
            // ProjectRFA1_9Rm
            // 
            this.ProjectRFA1_9Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_9Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_9Rm.Location = new System.Drawing.Point(339, 422);
            this.ProjectRFA1_9Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_9Rm.Name = "ProjectRFA1_9Rm";
            this.ProjectRFA1_9Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_9Rm.TabIndex = 84;
            // 
            // ProjectRFA1_8Rm
            // 
            this.ProjectRFA1_8Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_8Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_8Rm.Location = new System.Drawing.Point(339, 392);
            this.ProjectRFA1_8Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_8Rm.Name = "ProjectRFA1_8Rm";
            this.ProjectRFA1_8Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_8Rm.TabIndex = 83;
            // 
            // ProjectRFA1_7Rm
            // 
            this.ProjectRFA1_7Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_7Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_7Rm.Location = new System.Drawing.Point(339, 362);
            this.ProjectRFA1_7Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_7Rm.Name = "ProjectRFA1_7Rm";
            this.ProjectRFA1_7Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_7Rm.TabIndex = 82;
            // 
            // ProjectRFA1_6Rm
            // 
            this.ProjectRFA1_6Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_6Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_6Rm.Location = new System.Drawing.Point(339, 332);
            this.ProjectRFA1_6Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_6Rm.Name = "ProjectRFA1_6Rm";
            this.ProjectRFA1_6Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_6Rm.TabIndex = 81;
            // 
            // ProjectRFA1_5Rm
            // 
            this.ProjectRFA1_5Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_5Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_5Rm.Location = new System.Drawing.Point(339, 302);
            this.ProjectRFA1_5Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_5Rm.Name = "ProjectRFA1_5Rm";
            this.ProjectRFA1_5Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_5Rm.TabIndex = 80;
            // 
            // ProjectRFA1_4Rm
            // 
            this.ProjectRFA1_4Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_4Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_4Rm.Location = new System.Drawing.Point(339, 272);
            this.ProjectRFA1_4Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_4Rm.Name = "ProjectRFA1_4Rm";
            this.ProjectRFA1_4Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_4Rm.TabIndex = 79;
            // 
            // ProjectRFA1_3Rm
            // 
            this.ProjectRFA1_3Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_3Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_3Rm.Location = new System.Drawing.Point(339, 242);
            this.ProjectRFA1_3Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_3Rm.Name = "ProjectRFA1_3Rm";
            this.ProjectRFA1_3Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_3Rm.TabIndex = 78;
            // 
            // ProjectRFA1_2Rm
            // 
            this.ProjectRFA1_2Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_2Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_2Rm.Location = new System.Drawing.Point(339, 212);
            this.ProjectRFA1_2Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_2Rm.Name = "ProjectRFA1_2Rm";
            this.ProjectRFA1_2Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_2Rm.TabIndex = 77;
            // 
            // ProjectRFA1_1_3Rm
            // 
            this.ProjectRFA1_1_3Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_1_3Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1_3Rm.Location = new System.Drawing.Point(339, 182);
            this.ProjectRFA1_1_3Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_1_3Rm.Name = "ProjectRFA1_1_3Rm";
            this.ProjectRFA1_1_3Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_1_3Rm.TabIndex = 76;
            // 
            // ProjectRFA1_1_2Rm
            // 
            this.ProjectRFA1_1_2Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_1_2Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1_2Rm.Location = new System.Drawing.Point(339, 152);
            this.ProjectRFA1_1_2Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_1_2Rm.Name = "ProjectRFA1_1_2Rm";
            this.ProjectRFA1_1_2Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_1_2Rm.TabIndex = 75;
            // 
            // ProjectRFA1_1_1Rm
            // 
            this.ProjectRFA1_1_1Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_1_1Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1_1Rm.Location = new System.Drawing.Point(339, 122);
            this.ProjectRFA1_1_1Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_1_1Rm.Name = "ProjectRFA1_1_1Rm";
            this.ProjectRFA1_1_1Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_1_1Rm.TabIndex = 74;
            // 
            // ProjectRFA1_1Rm
            // 
            this.ProjectRFA1_1Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_1Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1Rm.Location = new System.Drawing.Point(339, 92);
            this.ProjectRFA1_1Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_1Rm.Name = "ProjectRFA1_1Rm";
            this.ProjectRFA1_1Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1_1Rm.TabIndex = 73;
            // 
            // kryptonLabel39
            // 
            this.kryptonLabel39.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel39.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonLabel39.Location = new System.Drawing.Point(3, 30);
            this.kryptonLabel39.Name = "kryptonLabel39";
            this.kryptonLabel39.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel39.TabIndex = 4;
            this.kryptonLabel39.Text = "一、项目总经费";
            // 
            // kryptonLabel38
            // 
            this.kryptonLabel38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel38.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel38.Location = new System.Drawing.Point(540, 0);
            this.kryptonLabel38.Name = "kryptonLabel38";
            this.kryptonLabel38.Size = new System.Drawing.Size(1, 30);
            this.kryptonLabel38.TabIndex = 3;
            this.kryptonLabel38.Text = "占比";
            this.kryptonLabel38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.kryptonLabel38.Visible = false;
            // 
            // kryptonLabel37
            // 
            this.kryptonLabel37.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel37.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel37.Location = new System.Drawing.Point(340, 0);
            this.kryptonLabel37.Name = "kryptonLabel37";
            this.kryptonLabel37.Size = new System.Drawing.Size(194, 30);
            this.kryptonLabel37.TabIndex = 2;
            this.kryptonLabel37.Text = "备注";
            this.kryptonLabel37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonLabel36
            // 
            this.kryptonLabel36.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel36.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel36.Location = new System.Drawing.Point(220, 0);
            this.kryptonLabel36.Name = "kryptonLabel36";
            this.kryptonLabel36.Size = new System.Drawing.Size(114, 30);
            this.kryptonLabel36.TabIndex = 1;
            this.kryptonLabel36.Text = "申请经费(万)";
            this.kryptonLabel36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonLabel30
            // 
            this.kryptonLabel30.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel30.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonLabel30.Location = new System.Drawing.Point(3, 0);
            this.kryptonLabel30.Name = "kryptonLabel30";
            this.kryptonLabel30.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel30.TabIndex = 0;
            this.kryptonLabel30.Text = "科目名称";
            this.kryptonLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectRFA
            // 
            this.ProjectRFA.BackColor = System.Drawing.Color.Transparent;
            this.ProjectRFA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProjectRFA.Location = new System.Drawing.Point(220, 30);
            this.ProjectRFA.Name = "ProjectRFA";
            this.ProjectRFA.Size = new System.Drawing.Size(114, 30);
            this.ProjectRFA.TabIndex = 5;
            this.ProjectRFA.Text = "0";
            this.ProjectRFA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ProjectRFA.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFARm
            // 
            this.ProjectRFARm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFARm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFARm.Location = new System.Drawing.Point(339, 32);
            this.ProjectRFARm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFARm.Name = "ProjectRFARm";
            this.ProjectRFARm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFARm.TabIndex = 71;
            // 
            // kryptonLabel42
            // 
            this.kryptonLabel42.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel42.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonLabel42.Location = new System.Drawing.Point(3, 90);
            this.kryptonLabel42.Name = "kryptonLabel42";
            this.kryptonLabel42.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel42.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel42.TabIndex = 8;
            this.kryptonLabel42.Text = "1.设备费";
            // 
            // kryptonLabel43
            // 
            this.kryptonLabel43.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel43.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel43.Location = new System.Drawing.Point(3, 120);
            this.kryptonLabel43.Name = "kryptonLabel43";
            this.kryptonLabel43.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.kryptonLabel43.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel43.TabIndex = 9;
            this.kryptonLabel43.Text = "（1）设备购置费";
            // 
            // kryptonLabel44
            // 
            this.kryptonLabel44.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel44.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel44.Location = new System.Drawing.Point(3, 150);
            this.kryptonLabel44.Name = "kryptonLabel44";
            this.kryptonLabel44.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.kryptonLabel44.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel44.TabIndex = 10;
            this.kryptonLabel44.Text = "（2）设备试制费";
            // 
            // kryptonLabel41
            // 
            this.kryptonLabel41.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel41.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonLabel41.Location = new System.Drawing.Point(3, 60);
            this.kryptonLabel41.Name = "kryptonLabel41";
            this.kryptonLabel41.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel41.TabIndex = 12;
            this.kryptonLabel41.Text = "（一）直接费用";
            // 
            // kryptonLabel46
            // 
            this.kryptonLabel46.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel46.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel46.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel46.Location = new System.Drawing.Point(3, 210);
            this.kryptonLabel46.Name = "kryptonLabel46";
            this.kryptonLabel46.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel46.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel46.TabIndex = 13;
            this.kryptonLabel46.Text = "2.材料费";
            // 
            // kryptonLabel47
            // 
            this.kryptonLabel47.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel47.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel47.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel47.Location = new System.Drawing.Point(3, 180);
            this.kryptonLabel47.Name = "kryptonLabel47";
            this.kryptonLabel47.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.kryptonLabel47.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel47.TabIndex = 14;
            this.kryptonLabel47.Text = "（3）其他";
            // 
            // kryptonLabel48
            // 
            this.kryptonLabel48.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel48.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel48.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel48.Location = new System.Drawing.Point(3, 240);
            this.kryptonLabel48.Name = "kryptonLabel48";
            this.kryptonLabel48.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel48.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel48.TabIndex = 15;
            this.kryptonLabel48.Text = "3.外部协作费";
            // 
            // ProjectRFA1
            // 
            this.ProjectRFA1.BackColor = System.Drawing.Color.Transparent;
            this.ProjectRFA1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProjectRFA1.Location = new System.Drawing.Point(220, 60);
            this.ProjectRFA1.Name = "ProjectRFA1";
            this.ProjectRFA1.Size = new System.Drawing.Size(114, 30);
            this.ProjectRFA1.TabIndex = 16;
            this.ProjectRFA1.Text = "0";
            this.ProjectRFA1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kryptonLabel50
            // 
            this.kryptonLabel50.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel50.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel50.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel50.Location = new System.Drawing.Point(3, 270);
            this.kryptonLabel50.Name = "kryptonLabel50";
            this.kryptonLabel50.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel50.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel50.TabIndex = 17;
            this.kryptonLabel50.Text = "4.燃料动力费";
            // 
            // kryptonLabel51
            // 
            this.kryptonLabel51.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel51.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel51.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel51.Location = new System.Drawing.Point(3, 300);
            this.kryptonLabel51.Name = "kryptonLabel51";
            this.kryptonLabel51.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel51.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel51.TabIndex = 18;
            this.kryptonLabel51.Text = "5.会议、差旅、国际合作与交流费";
            // 
            // kryptonLabel52
            // 
            this.kryptonLabel52.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel52.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel52.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel52.Location = new System.Drawing.Point(3, 330);
            this.kryptonLabel52.Name = "kryptonLabel52";
            this.kryptonLabel52.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel52.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel52.TabIndex = 19;
            this.kryptonLabel52.Text = "6.出版、文献、信息传播、知识产权事务费";
            // 
            // kryptonLabel53
            // 
            this.kryptonLabel53.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel53.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel53.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel53.Location = new System.Drawing.Point(3, 360);
            this.kryptonLabel53.Name = "kryptonLabel53";
            this.kryptonLabel53.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel53.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel53.TabIndex = 20;
            this.kryptonLabel53.Text = "7.劳务费";
            // 
            // kryptonLabel54
            // 
            this.kryptonLabel54.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel54.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel54.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel54.Location = new System.Drawing.Point(3, 390);
            this.kryptonLabel54.Name = "kryptonLabel54";
            this.kryptonLabel54.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel54.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel54.TabIndex = 21;
            this.kryptonLabel54.Text = "8.专家咨询费";
            // 
            // kryptonLabel55
            // 
            this.kryptonLabel55.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel55.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel55.Location = new System.Drawing.Point(3, 420);
            this.kryptonLabel55.Name = "kryptonLabel55";
            this.kryptonLabel55.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel55.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel55.TabIndex = 22;
            this.kryptonLabel55.Text = "9.其他支出";
            // 
            // kryptonLabel56
            // 
            this.kryptonLabel56.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel56.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel56.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonLabel56.Location = new System.Drawing.Point(3, 450);
            this.kryptonLabel56.Name = "kryptonLabel56";
            this.kryptonLabel56.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel56.TabIndex = 23;
            this.kryptonLabel56.Text = "（二）间接费用";
            // 
            // kryptonLabel57
            // 
            this.kryptonLabel57.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel57.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel57.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel57.Location = new System.Drawing.Point(3, 480);
            this.kryptonLabel57.Name = "kryptonLabel57";
            this.kryptonLabel57.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel57.Size = new System.Drawing.Size(211, 30);
            this.kryptonLabel57.TabIndex = 24;
            this.kryptonLabel57.Text = "10.管理费、科研绩效支出";
            // 
            // ProjectRFA1_1
            // 
            this.ProjectRFA1_1.BackColor = System.Drawing.Color.Transparent;
            this.ProjectRFA1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_1.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1.Location = new System.Drawing.Point(220, 90);
            this.ProjectRFA1_1.Name = "ProjectRFA1_1";
            this.ProjectRFA1_1.Size = new System.Drawing.Size(114, 30);
            this.ProjectRFA1_1.TabIndex = 26;
            this.ProjectRFA1_1.Text = "0";
            this.ProjectRFA1_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProjectRFA1_1_1
            // 
            this.ProjectRFA1_1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_1_1.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1_1.Location = new System.Drawing.Point(219, 122);
            this.ProjectRFA1_1_1.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_1_1.Name = "ProjectRFA1_1_1";
            this.ProjectRFA1_1_1.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_1_1.TabIndex = 27;
            this.ProjectRFA1_1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_1_1.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_1_1.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1_1_2
            // 
            this.ProjectRFA1_1_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_1_2.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1_2.Location = new System.Drawing.Point(219, 152);
            this.ProjectRFA1_1_2.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_1_2.Name = "ProjectRFA1_1_2";
            this.ProjectRFA1_1_2.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_1_2.TabIndex = 28;
            this.ProjectRFA1_1_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_1_2.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_1_2.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1_1_3
            // 
            this.ProjectRFA1_1_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_1_3.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1_3.Location = new System.Drawing.Point(219, 182);
            this.ProjectRFA1_1_3.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_1_3.Name = "ProjectRFA1_1_3";
            this.ProjectRFA1_1_3.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_1_3.TabIndex = 29;
            this.ProjectRFA1_1_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_1_3.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_1_3.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1_2
            // 
            this.ProjectRFA1_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_2.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_2.Location = new System.Drawing.Point(219, 212);
            this.ProjectRFA1_2.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_2.Name = "ProjectRFA1_2";
            this.ProjectRFA1_2.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_2.TabIndex = 30;
            this.ProjectRFA1_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_2.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_2.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1_3
            // 
            this.ProjectRFA1_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_3.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_3.Location = new System.Drawing.Point(219, 242);
            this.ProjectRFA1_3.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_3.Name = "ProjectRFA1_3";
            this.ProjectRFA1_3.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_3.TabIndex = 31;
            this.ProjectRFA1_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_3.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_3.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1_4
            // 
            this.ProjectRFA1_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_4.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_4.Location = new System.Drawing.Point(219, 272);
            this.ProjectRFA1_4.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_4.Name = "ProjectRFA1_4";
            this.ProjectRFA1_4.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_4.TabIndex = 33;
            this.ProjectRFA1_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_4.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_4.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1Rm
            // 
            this.ProjectRFA1Rm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1Rm.Location = new System.Drawing.Point(339, 62);
            this.ProjectRFA1Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1Rm.Name = "ProjectRFA1Rm";
            this.ProjectRFA1Rm.Size = new System.Drawing.Size(196, 26);
            this.ProjectRFA1Rm.TabIndex = 72;
            // 
            // ProjectRFA1_5
            // 
            this.ProjectRFA1_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_5.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_5.Location = new System.Drawing.Point(219, 302);
            this.ProjectRFA1_5.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_5.Name = "ProjectRFA1_5";
            this.ProjectRFA1_5.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_5.TabIndex = 34;
            this.ProjectRFA1_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_5.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_5.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1_6
            // 
            this.ProjectRFA1_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_6.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_6.Location = new System.Drawing.Point(219, 332);
            this.ProjectRFA1_6.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_6.Name = "ProjectRFA1_6";
            this.ProjectRFA1_6.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_6.TabIndex = 35;
            this.ProjectRFA1_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_6.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_6.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1_7
            // 
            this.ProjectRFA1_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_7.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_7.Location = new System.Drawing.Point(219, 362);
            this.ProjectRFA1_7.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_7.Name = "ProjectRFA1_7";
            this.ProjectRFA1_7.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_7.TabIndex = 36;
            this.ProjectRFA1_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_7.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_7.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1_8
            // 
            this.ProjectRFA1_8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_8.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_8.Location = new System.Drawing.Point(219, 392);
            this.ProjectRFA1_8.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_8.Name = "ProjectRFA1_8";
            this.ProjectRFA1_8.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_8.TabIndex = 37;
            this.ProjectRFA1_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_8.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_8.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1_9
            // 
            this.ProjectRFA1_9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA1_9.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_9.Location = new System.Drawing.Point(219, 422);
            this.ProjectRFA1_9.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_9.Name = "ProjectRFA1_9";
            this.ProjectRFA1_9.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA1_9.TabIndex = 38;
            this.ProjectRFA1_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_9.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_9.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA2_1
            // 
            this.ProjectRFA2_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA2_1.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA2_1.Location = new System.Drawing.Point(219, 482);
            this.ProjectRFA2_1.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA2_1.Name = "ProjectRFA2_1";
            this.ProjectRFA2_1.Size = new System.Drawing.Size(116, 26);
            this.ProjectRFA2_1.TabIndex = 39;
            this.ProjectRFA2_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA2_1.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA2_1.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA2
            // 
            this.ProjectRFA2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectRFA2.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProjectRFA2.Location = new System.Drawing.Point(220, 450);
            this.ProjectRFA2.Name = "ProjectRFA2";
            this.ProjectRFA2.Size = new System.Drawing.Size(114, 30);
            this.ProjectRFA2.TabIndex = 41;
            this.ProjectRFA2.Text = "0";
            this.ProjectRFA2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProjectRFA1_5zb
            // 
            this.ProjectRFA1_5zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_5zb.Location = new System.Drawing.Point(540, 300);
            this.ProjectRFA1_5zb.Name = "ProjectRFA1_5zb";
            this.ProjectRFA1_5zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_5zb.TabIndex = 53;
            this.ProjectRFA1_5zb.Text = "0";
            this.ProjectRFA1_5zb.Visible = false;
            // 
            // ProjectRFA1zb
            // 
            this.ProjectRFA1zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1zb.Location = new System.Drawing.Point(540, 60);
            this.ProjectRFA1zb.Name = "ProjectRFA1zb";
            this.ProjectRFA1zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1zb.TabIndex = 58;
            this.ProjectRFA1zb.Text = "0";
            this.ProjectRFA1zb.Visible = false;
            // 
            // ProjectRFA1_1zb
            // 
            this.ProjectRFA1_1zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1zb.Location = new System.Drawing.Point(540, 90);
            this.ProjectRFA1_1zb.Name = "ProjectRFA1_1zb";
            this.ProjectRFA1_1zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_1zb.TabIndex = 59;
            this.ProjectRFA1_1zb.Text = "0";
            this.ProjectRFA1_1zb.Visible = false;
            // 
            // ProjectRFA1_1_1zb
            // 
            this.ProjectRFA1_1_1zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1_1zb.Location = new System.Drawing.Point(540, 120);
            this.ProjectRFA1_1_1zb.Name = "ProjectRFA1_1_1zb";
            this.ProjectRFA1_1_1zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_1_1zb.TabIndex = 60;
            this.ProjectRFA1_1_1zb.Text = "0";
            this.ProjectRFA1_1_1zb.Visible = false;
            // 
            // ProjectRFA1_1_2zb
            // 
            this.ProjectRFA1_1_2zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1_2zb.Location = new System.Drawing.Point(540, 150);
            this.ProjectRFA1_1_2zb.Name = "ProjectRFA1_1_2zb";
            this.ProjectRFA1_1_2zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_1_2zb.TabIndex = 61;
            this.ProjectRFA1_1_2zb.Text = "0";
            this.ProjectRFA1_1_2zb.Visible = false;
            // 
            // ProjectRFA1_1_3zb
            // 
            this.ProjectRFA1_1_3zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_1_3zb.Location = new System.Drawing.Point(540, 180);
            this.ProjectRFA1_1_3zb.Name = "ProjectRFA1_1_3zb";
            this.ProjectRFA1_1_3zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_1_3zb.TabIndex = 62;
            this.ProjectRFA1_1_3zb.Text = "0";
            this.ProjectRFA1_1_3zb.Visible = false;
            // 
            // ProjectRFA1_2zb
            // 
            this.ProjectRFA1_2zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_2zb.Location = new System.Drawing.Point(540, 210);
            this.ProjectRFA1_2zb.Name = "ProjectRFA1_2zb";
            this.ProjectRFA1_2zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_2zb.TabIndex = 63;
            this.ProjectRFA1_2zb.Text = "0";
            this.ProjectRFA1_2zb.Visible = false;
            // 
            // ProjectRFA1_3zb
            // 
            this.ProjectRFA1_3zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_3zb.Location = new System.Drawing.Point(540, 240);
            this.ProjectRFA1_3zb.Name = "ProjectRFA1_3zb";
            this.ProjectRFA1_3zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_3zb.TabIndex = 64;
            this.ProjectRFA1_3zb.Text = "0";
            this.ProjectRFA1_3zb.Visible = false;
            // 
            // ProjectRFA1_4zb
            // 
            this.ProjectRFA1_4zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_4zb.Location = new System.Drawing.Point(540, 270);
            this.ProjectRFA1_4zb.Name = "ProjectRFA1_4zb";
            this.ProjectRFA1_4zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_4zb.TabIndex = 65;
            this.ProjectRFA1_4zb.Text = "0";
            this.ProjectRFA1_4zb.Visible = false;
            // 
            // ProjectRFA1_6zb
            // 
            this.ProjectRFA1_6zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_6zb.Location = new System.Drawing.Point(540, 330);
            this.ProjectRFA1_6zb.Name = "ProjectRFA1_6zb";
            this.ProjectRFA1_6zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_6zb.TabIndex = 66;
            this.ProjectRFA1_6zb.Text = "0";
            this.ProjectRFA1_6zb.Visible = false;
            // 
            // ProjectRFA1_8zb
            // 
            this.ProjectRFA1_8zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_8zb.Location = new System.Drawing.Point(540, 390);
            this.ProjectRFA1_8zb.Name = "ProjectRFA1_8zb";
            this.ProjectRFA1_8zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_8zb.TabIndex = 67;
            this.ProjectRFA1_8zb.Text = "0";
            this.ProjectRFA1_8zb.Visible = false;
            // 
            // ProjectRFA1_7zb
            // 
            this.ProjectRFA1_7zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_7zb.Location = new System.Drawing.Point(540, 360);
            this.ProjectRFA1_7zb.Name = "ProjectRFA1_7zb";
            this.ProjectRFA1_7zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_7zb.TabIndex = 68;
            this.ProjectRFA1_7zb.Text = "0";
            this.ProjectRFA1_7zb.Visible = false;
            // 
            // ProjectRFA1_9zb
            // 
            this.ProjectRFA1_9zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_9zb.Location = new System.Drawing.Point(540, 420);
            this.ProjectRFA1_9zb.Name = "ProjectRFA1_9zb";
            this.ProjectRFA1_9zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA1_9zb.TabIndex = 69;
            this.ProjectRFA1_9zb.Text = "0";
            this.ProjectRFA1_9zb.Visible = false;
            // 
            // ProjectRFA2zb
            // 
            this.ProjectRFA2zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA2zb.Location = new System.Drawing.Point(540, 450);
            this.ProjectRFA2zb.Name = "ProjectRFA2zb";
            this.ProjectRFA2zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA2zb.TabIndex = 70;
            this.ProjectRFA2zb.Text = "0";
            this.ProjectRFA2zb.Visible = false;
            // 
            // ProjectRFA2_1zb
            // 
            this.ProjectRFA2_1zb.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA2_1zb.Location = new System.Drawing.Point(540, 480);
            this.ProjectRFA2_1zb.Name = "ProjectRFA2_1zb";
            this.ProjectRFA2_1zb.Size = new System.Drawing.Size(1, 23);
            this.ProjectRFA2_1zb.TabIndex = 71;
            this.ProjectRFA2_1zb.Text = "0";
            this.ProjectRFA2_1zb.Visible = false;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel7.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel7.Location = new System.Drawing.Point(3, 270);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.kryptonLabel7.Size = new System.Drawing.Size(120, 1);
            this.kryptonLabel7.TabIndex = 11;
            this.kryptonLabel7.Text = "（2）其他";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BorderColor = System.Drawing.Color.Black;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.kryptonPanel18, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel93, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel94, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel95, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel96, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel97, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.ProjectOutlay1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.ProjectOutlay2, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.ProjectOutlay3, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.ProjectOutlay4, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.ProjectOutlay5, 4, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(184, 566);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(537, 90);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // kryptonPanel18
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.kryptonPanel18, 5);
            this.kryptonPanel18.Controls.Add(this.ProjectRFA1_3_1);
            this.kryptonPanel18.Controls.Add(this.ProjectRFA1_3_1Rm);
            this.kryptonPanel18.Controls.Add(this.ProjectRFA1_3_2Rm);
            this.kryptonPanel18.Controls.Add(this.kryptonLabel92);
            this.kryptonPanel18.Controls.Add(this.ProjectRFA1_3_2);
            this.kryptonPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel18.Location = new System.Drawing.Point(1, 1);
            this.kryptonPanel18.Margin = new System.Windows.Forms.Padding(1);
            this.kryptonPanel18.Name = "kryptonPanel18";
            this.kryptonPanel18.Size = new System.Drawing.Size(535, 27);
            this.kryptonPanel18.TabIndex = 0;
            // 
            // ProjectRFA1_3_1
            // 
            this.ProjectRFA1_3_1.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_3_1.Location = new System.Drawing.Point(180, -1);
            this.ProjectRFA1_3_1.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_3_1.Name = "ProjectRFA1_3_1";
            this.ProjectRFA1_3_1.Size = new System.Drawing.Size(56, 26);
            this.ProjectRFA1_3_1.TabIndex = 31;
            this.ProjectRFA1_3_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_3_1.Visible = false;
            this.ProjectRFA1_3_1.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_3_1.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // ProjectRFA1_3_1Rm
            // 
            this.ProjectRFA1_3_1Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_3_1Rm.Location = new System.Drawing.Point(486, 3);
            this.ProjectRFA1_3_1Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_3_1Rm.Name = "ProjectRFA1_3_1Rm";
            this.ProjectRFA1_3_1Rm.Size = new System.Drawing.Size(33, 26);
            this.ProjectRFA1_3_1Rm.TabIndex = 87;
            this.ProjectRFA1_3_1Rm.Visible = false;
            // 
            // ProjectRFA1_3_2Rm
            // 
            this.ProjectRFA1_3_2Rm.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_3_2Rm.Location = new System.Drawing.Point(410, 3);
            this.ProjectRFA1_3_2Rm.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_3_2Rm.Name = "ProjectRFA1_3_2Rm";
            this.ProjectRFA1_3_2Rm.Size = new System.Drawing.Size(46, 26);
            this.ProjectRFA1_3_2Rm.TabIndex = 87;
            this.ProjectRFA1_3_2Rm.Visible = false;
            // 
            // kryptonLabel92
            // 
            this.kryptonLabel92.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel92.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonLabel92.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel92.Name = "kryptonLabel92";
            this.kryptonLabel92.Size = new System.Drawing.Size(193, 27);
            this.kryptonLabel92.TabIndex = 0;
            this.kryptonLabel92.Text = "年度申请经费预算(万元)";
            // 
            // ProjectRFA1_3_2
            // 
            this.ProjectRFA1_3_2.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectRFA1_3_2.Location = new System.Drawing.Point(323, 3);
            this.ProjectRFA1_3_2.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectRFA1_3_2.Name = "ProjectRFA1_3_2";
            this.ProjectRFA1_3_2.Size = new System.Drawing.Size(34, 26);
            this.ProjectRFA1_3_2.TabIndex = 32;
            this.ProjectRFA1_3_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectRFA1_3_2.Visible = false;
            this.ProjectRFA1_3_2.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            this.ProjectRFA1_3_2.Leave += new System.EventHandler(this.ProjectRFA_Leave);
            // 
            // kryptonLabel93
            // 
            this.kryptonLabel93.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel93.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel93.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel93.Location = new System.Drawing.Point(3, 29);
            this.kryptonLabel93.Name = "kryptonLabel93";
            this.kryptonLabel93.Size = new System.Drawing.Size(101, 29);
            this.kryptonLabel93.TabIndex = 1;
            this.kryptonLabel93.Text = "第一年";
            this.kryptonLabel93.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonLabel94
            // 
            this.kryptonLabel94.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel94.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel94.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel94.Location = new System.Drawing.Point(110, 29);
            this.kryptonLabel94.Name = "kryptonLabel94";
            this.kryptonLabel94.Size = new System.Drawing.Size(101, 29);
            this.kryptonLabel94.TabIndex = 2;
            this.kryptonLabel94.Text = "第二年";
            this.kryptonLabel94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonLabel95
            // 
            this.kryptonLabel95.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel95.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel95.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel95.Location = new System.Drawing.Point(324, 29);
            this.kryptonLabel95.Name = "kryptonLabel95";
            this.kryptonLabel95.Size = new System.Drawing.Size(101, 29);
            this.kryptonLabel95.TabIndex = 3;
            this.kryptonLabel95.Text = "第四年";
            this.kryptonLabel95.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonLabel96
            // 
            this.kryptonLabel96.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel96.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel96.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel96.Location = new System.Drawing.Point(217, 29);
            this.kryptonLabel96.Name = "kryptonLabel96";
            this.kryptonLabel96.Size = new System.Drawing.Size(101, 29);
            this.kryptonLabel96.TabIndex = 4;
            this.kryptonLabel96.Text = "第三年";
            this.kryptonLabel96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonLabel97
            // 
            this.kryptonLabel97.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel97.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel97.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel97.Location = new System.Drawing.Point(431, 29);
            this.kryptonLabel97.Name = "kryptonLabel97";
            this.kryptonLabel97.Size = new System.Drawing.Size(103, 29);
            this.kryptonLabel97.TabIndex = 5;
            this.kryptonLabel97.Text = "第五年";
            this.kryptonLabel97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectOutlay1
            // 
            this.ProjectOutlay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectOutlay1.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectOutlay1.Location = new System.Drawing.Point(3, 61);
            this.ProjectOutlay1.Name = "ProjectOutlay1";
            this.ProjectOutlay1.Size = new System.Drawing.Size(101, 26);
            this.ProjectOutlay1.TabIndex = 40;
            this.ProjectOutlay1.Text = "0";
            this.ProjectOutlay1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectOutlay1.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            // 
            // ProjectOutlay2
            // 
            this.ProjectOutlay2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectOutlay2.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectOutlay2.Location = new System.Drawing.Point(110, 61);
            this.ProjectOutlay2.Name = "ProjectOutlay2";
            this.ProjectOutlay2.Size = new System.Drawing.Size(101, 26);
            this.ProjectOutlay2.TabIndex = 41;
            this.ProjectOutlay2.Text = "0";
            this.ProjectOutlay2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectOutlay2.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            // 
            // ProjectOutlay3
            // 
            this.ProjectOutlay3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectOutlay3.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectOutlay3.Location = new System.Drawing.Point(217, 61);
            this.ProjectOutlay3.Name = "ProjectOutlay3";
            this.ProjectOutlay3.Size = new System.Drawing.Size(101, 26);
            this.ProjectOutlay3.TabIndex = 42;
            this.ProjectOutlay3.Text = "0";
            this.ProjectOutlay3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectOutlay3.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            // 
            // ProjectOutlay4
            // 
            this.ProjectOutlay4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectOutlay4.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectOutlay4.Location = new System.Drawing.Point(324, 61);
            this.ProjectOutlay4.Name = "ProjectOutlay4";
            this.ProjectOutlay4.Size = new System.Drawing.Size(101, 26);
            this.ProjectOutlay4.TabIndex = 43;
            this.ProjectOutlay4.Text = "0";
            this.ProjectOutlay4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectOutlay4.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            // 
            // ProjectOutlay5
            // 
            this.ProjectOutlay5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectOutlay5.Font = new System.Drawing.Font("仿宋", 12F);
            this.ProjectOutlay5.Location = new System.Drawing.Point(431, 61);
            this.ProjectOutlay5.Name = "ProjectOutlay5";
            this.ProjectOutlay5.Size = new System.Drawing.Size(103, 26);
            this.ProjectOutlay5.TabIndex = 44;
            this.ProjectOutlay5.Text = "0";
            this.ProjectOutlay5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProjectOutlay5.TextChanged += new System.EventHandler(this.ProjectRFA_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.kryptonLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(184, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 29);
            this.panel1.TabIndex = 8;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Font = new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(537, 29);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Text = "经费预算表";
            this.kryptonLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.plBottomInfoBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(184, 664);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(537, 41);
            this.panel3.TabIndex = 9;
            // 
            // plBottomInfoBox
            // 
            this.plBottomInfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.plBottomInfoBox.Controls.Add(this.txtZiChouJingFei);
            this.plBottomInfoBox.Controls.Add(this.kryptonLabel4);
            this.plBottomInfoBox.Controls.Add(this.kryptonLabel3);
            this.plBottomInfoBox.Location = new System.Drawing.Point(134, 3);
            this.plBottomInfoBox.Name = "plBottomInfoBox";
            this.plBottomInfoBox.Size = new System.Drawing.Size(482, 34);
            this.plBottomInfoBox.TabIndex = 30;
            // 
            // txtZiChouJingFei
            // 
            this.txtZiChouJingFei.Font = new System.Drawing.Font("仿宋", 12F);
            this.txtZiChouJingFei.Location = new System.Drawing.Point(323, 2);
            this.txtZiChouJingFei.Margin = new System.Windows.Forms.Padding(2);
            this.txtZiChouJingFei.Name = "txtZiChouJingFei";
            this.txtZiChouJingFei.Size = new System.Drawing.Size(72, 26);
            this.txtZiChouJingFei.TabIndex = 45;
            this.txtZiChouJingFei.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel4.Location = new System.Drawing.Point(416, 5);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel4.Size = new System.Drawing.Size(65, 23);
            this.kryptonLabel4.TabIndex = 29;
            this.kryptonLabel4.Text = "万元";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel3.Location = new System.Drawing.Point(4, 5);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel3.Size = new System.Drawing.Size(299, 23);
            this.kryptonLabel3.TabIndex = 29;
            this.kryptonLabel3.Text = "本项目申请经费0万元，各自自筹经费";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lklDownloadFuJian);
            this.panel2.Controls.Add(this.kryptonLabel5);
            this.panel2.Controls.Add(this.kryptonLabel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(184, 711);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 58);
            this.panel2.TabIndex = 10;
            // 
            // lklDownloadFuJian
            // 
            this.lklDownloadFuJian.Dock = System.Windows.Forms.DockStyle.Left;
            this.lklDownloadFuJian.Font = new System.Drawing.Font("仿宋", 10.5F);
            this.lklDownloadFuJian.Location = new System.Drawing.Point(102, 23);
            this.lklDownloadFuJian.Name = "lklDownloadFuJian";
            this.lklDownloadFuJian.Size = new System.Drawing.Size(153, 35);
            this.lklDownloadFuJian.TabIndex = 31;
            this.lklDownloadFuJian.TabStop = true;
            this.lklDownloadFuJian.Text = "经费预算填报说明.doc";
            this.lklDownloadFuJian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lklDownloadFuJian.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklDownloadFuJian_LinkClicked);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel5.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel5.Location = new System.Drawing.Point(0, 23);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(102, 35);
            this.kryptonLabel5.TabIndex = 32;
            this.kryptonLabel5.Text = "填写说明：";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonLabel2.Font = new System.Drawing.Font("仿宋", 12F);
            this.kryptonLabel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.kryptonLabel2.Size = new System.Drawing.Size(537, 23);
            this.kryptonLabel2.TabIndex = 30;
            this.kryptonLabel2.Text = "注：经费预算按照《军队单位科研经费使用管理规定（试行）》（[2017]8号）有关要求编制。";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.Controls.Add(this.btnSave, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnExcelLoad, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.lklDownloadExcel, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 677);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(906, 40);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(759, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExcelLoad
            // 
            this.btnExcelLoad.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExcelLoad.Location = new System.Drawing.Point(639, 3);
            this.btnExcelLoad.Name = "btnExcelLoad";
            this.btnExcelLoad.Size = new System.Drawing.Size(114, 29);
            this.btnExcelLoad.TabIndex = 7;
            this.btnExcelLoad.Text = "从Excel导入";
            this.btnExcelLoad.Click += new System.EventHandler(this.btnExcelLoad_Click);
            // 
            // lklDownloadExcel
            // 
            this.lklDownloadExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lklDownloadExcel.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lklDownloadExcel.Location = new System.Drawing.Point(298, 0);
            this.lklDownloadExcel.Name = "lklDownloadExcel";
            this.lklDownloadExcel.Size = new System.Drawing.Size(185, 40);
            this.lklDownloadExcel.TabIndex = 6;
            this.lklDownloadExcel.TabStop = true;
            this.lklDownloadExcel.Text = "经费预算导入模板.xls";
            this.lklDownloadExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lklDownloadExcel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklDownloadExcel_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 717);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(906, 20);
            this.panel4.TabIndex = 2;
            // 
            // ofdExcelDialog
            // 
            this.ofdExcelDialog.Filter = "*.xls|*.xls";
            // 
            // MoneyTableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.panel4);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MoneyTableEditor";
            this.Size = new System.Drawing.Size(906, 737);
            this.Leave += new System.EventHandler(this.frmbudget_Leave);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.kryptonPanel18.ResumeLayout(false);
            this.kryptonPanel18.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.plBottomInfoBox.ResumeLayout(false);
            this.plBottomInfoBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        public MoneyTableEditor()
		{
			this.InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
            this.RefreshCall();
			base.OnLoad(e);
		}

		private void SetBudgettoUI()
		{
            if (this.pbinfo != null)
            {
                this.txtZiChouJingFei.Text = pbinfo.ProjectZiChouJingFei + "";
                this.ProjectRFA1_1_1.Text = ((!this.pbinfo.ProjectRFA1_1_1.HasValue) ? "" : this.pbinfo.ProjectRFA1_1_1.ToString());
                this.ProjectRFA1_1_2.Text = ((!this.pbinfo.ProjectRFA1_1_2.HasValue) ? "" : this.pbinfo.ProjectRFA1_1_2.ToString());
                this.ProjectRFA1_1_3.Text = ((!this.pbinfo.ProjectRFA1_1_3.HasValue) ? "" : this.pbinfo.ProjectRFA1_1_3.ToString());
                this.ProjectRFA1_2.Text = ((!this.pbinfo.ProjectRFA1_2.HasValue) ? "" : this.pbinfo.ProjectRFA1_2.ToString());
                this.ProjectRFA1_3.Text = ((!this.pbinfo.ProjectRFA1_3.HasValue) ? "" : this.pbinfo.ProjectRFA1_3.ToString());
                this.ProjectRFA1_3_1.Text = ((!this.pbinfo.ProjectRFA1_3_1.HasValue) ? "" : this.pbinfo.ProjectRFA1_3_1.ToString());
                this.ProjectRFA1_3_2.Text = ((!this.pbinfo.ProjectRFA1_3_2.HasValue) ? "" : this.pbinfo.ProjectRFA1_3_2.ToString());
                this.ProjectRFA1_4.Text = ((!this.pbinfo.ProjectRFA1_4.HasValue) ? "" : this.pbinfo.ProjectRFA1_4.ToString());
                this.ProjectRFA1_5.Text = ((!this.pbinfo.ProjectRFA1_5.HasValue) ? "" : this.pbinfo.ProjectRFA1_5.ToString());
                this.ProjectRFA1_6.Text = ((!this.pbinfo.ProjectRFA1_6.HasValue) ? "" : this.pbinfo.ProjectRFA1_6.ToString());
                this.ProjectRFA1_7.Text = ((!this.pbinfo.ProjectRFA1_7.HasValue) ? "" : this.pbinfo.ProjectRFA1_7.ToString());
                this.ProjectRFA1_8.Text = ((!this.pbinfo.ProjectRFA1_8.HasValue) ? "" : this.pbinfo.ProjectRFA1_8.ToString());
                this.ProjectRFA1_9.Text = ((!this.pbinfo.ProjectRFA1_9.HasValue) ? "" : this.pbinfo.ProjectRFA1_9.ToString());
                this.ProjectRFA2_1.Text = ((!this.pbinfo.ProjectRFA2_1.HasValue) ? "" : this.pbinfo.ProjectRFA2_1.ToString());
                this.ProjectRFARm.Text = this.pbinfo.ProjectRFArm;
                this.ProjectRFA1Rm.Text = this.pbinfo.ProjectRFA1rm;
                this.ProjectRFA1_1Rm.Text = this.pbinfo.ProjectRFA1_1rm;
                this.ProjectRFA1_1_1Rm.Text = this.pbinfo.ProjectRFA1_1_1rm;
                this.ProjectRFA1_1_2Rm.Text = this.pbinfo.ProjectRFA1_1_2rm;
                this.ProjectRFA1_1_3Rm.Text = this.pbinfo.ProjectRFA1_1_3rm;
                this.ProjectRFA1_2Rm.Text = this.pbinfo.ProjectRFA1_2rm;
                this.ProjectRFA1_3Rm.Text = this.pbinfo.ProjectRFA1_3rm;
                this.ProjectRFA1_3_1Rm.Text = this.pbinfo.ProjectRFA1_3_1rm;
                this.ProjectRFA1_3_2Rm.Text = this.pbinfo.ProjectRFA1_3_2rm;
                this.ProjectRFA1_4Rm.Text = this.pbinfo.ProjectRFA1_4rm;
                this.ProjectRFA1_5Rm.Text = this.pbinfo.ProjectRFA1_5rm;
                this.ProjectRFA1_6Rm.Text = this.pbinfo.ProjectRFA1_6rm;
                this.ProjectRFA1_7Rm.Text = this.pbinfo.ProjectRFA1_7rm;
                this.ProjectRFA1_8Rm.Text = this.pbinfo.ProjectRFA1_8rm;
                this.ProjectRFA1_9Rm.Text = this.pbinfo.ProjectRFA1_9rm;
                this.ProjectRFA2Rm.Text = this.pbinfo.ProjectRFA2rm;
                this.ProjectRFA2_1Rm.Text = this.pbinfo.ProjectRFA2_1rm;

                this.ProjectOutlay1.Text = this.pbinfo.Projectoutlay1.HasValue ? this.pbinfo.Projectoutlay1.Value.ToString() : "0";
                this.ProjectOutlay2.Text = this.pbinfo.Projectoutlay2.HasValue ? this.pbinfo.Projectoutlay2.Value.ToString() : "0";
                this.ProjectOutlay3.Text = this.pbinfo.Projectoutlay3.HasValue ? this.pbinfo.Projectoutlay3.Value.ToString() : "0";
                this.ProjectOutlay4.Text = this.pbinfo.Projectoutlay4.HasValue ? this.pbinfo.Projectoutlay4.Value.ToString() : "0";
                this.ProjectOutlay5.Text = this.pbinfo.Projectoutlay5.HasValue ? this.pbinfo.Projectoutlay5.Value.ToString() : "0";
            }
		}

		private void ProjectRFA_TextChanged(object sender, EventArgs e)
		{
            if (sender is TextBox)
            {
                TextBox kryptonTextBox = (TextBox)sender;
                if (kryptonTextBox.Text != string.Empty)
                {
                    decimal d = 0m;
                    if (!decimal.TryParse(kryptonTextBox.Text, out d) || d < 0m)
                    {
                        kryptonTextBox.Focus();
                        kryptonTextBox.Text = "";
                    }
                }
            }

            kryptonLabel3.Text = "本项目申请经费" + ProjectRFA.Text + "万元，各自自筹经费";
        }

		private void ProjectRFA_Leave(object sender, EventArgs e)
		{
            if (pbinfo != null)
            {
                if (sender is TextBox)
                {
                    TextBox kryptonTextBox = (TextBox)sender;
                    decimal value = 0m;
                    bool flag = string.IsNullOrEmpty(kryptonTextBox.Text.Trim());
                    decimal.TryParse(kryptonTextBox.Text, out value);
                    string name;
                    switch (name = kryptonTextBox.Name)
                    {
                        case "ProjectRFA1_1_1":
                            this.pbinfo.ProjectRFA1_1_1 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_1_2":
                            this.pbinfo.ProjectRFA1_1_2 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_1_3":
                            this.pbinfo.ProjectRFA1_1_3 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_2":
                            this.pbinfo.ProjectRFA1_2 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_3":
                            this.pbinfo.ProjectRFA1_3 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_3_1":
                            this.pbinfo.ProjectRFA1_3_1 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_3_2":
                            this.pbinfo.ProjectRFA1_3_2 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_4":
                            this.pbinfo.ProjectRFA1_4 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_5":
                            this.pbinfo.ProjectRFA1_5 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_6":
                            this.pbinfo.ProjectRFA1_6 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_7":
                            this.pbinfo.ProjectRFA1_7 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_8":
                            this.pbinfo.ProjectRFA1_8 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA1_9":
                            this.pbinfo.ProjectRFA1_9 = (flag ? 0 : new decimal?(value));
                            break;
                        case "ProjectRFA2_1":
                            this.pbinfo.ProjectRFA2_1 = (flag ? 0 : new decimal?(value));
                            break;
                    }
                    this.pbinfo.Calc();
                    this.SetBudgetRatiovalue();
                }
            }
        }

		private void GetAdditionInfo()
		{
            decimal value = 0m;
            decimal.TryParse(this.ProjectOutlay1.Text, out value);
            this.pbinfo.Projectoutlay1 = new decimal?(value);
            decimal.TryParse(this.ProjectOutlay2.Text, out value);
            this.pbinfo.Projectoutlay2 = new decimal?(value);
            decimal.TryParse(this.ProjectOutlay3.Text, out value);
            this.pbinfo.Projectoutlay3 = new decimal?(value);
            decimal.TryParse(this.ProjectOutlay4.Text, out value);
            this.pbinfo.Projectoutlay4 = new decimal?(value);
            decimal.TryParse(this.ProjectOutlay5.Text, out value);
            this.pbinfo.Projectoutlay5 = new decimal?(value);
            this.pbinfo.ProjectRFArm = this.ProjectRFARm.Text;
            this.pbinfo.ProjectRFA1rm = this.ProjectRFA1Rm.Text;
            this.pbinfo.ProjectRFA1_1rm = this.ProjectRFA1_1Rm.Text;
            this.pbinfo.ProjectRFA1_1_1rm = this.ProjectRFA1_1_1Rm.Text;
            this.pbinfo.ProjectRFA1_1_2rm = this.ProjectRFA1_1_2Rm.Text;
            this.pbinfo.ProjectRFA1_1_3rm = this.ProjectRFA1_1_3Rm.Text;
            this.pbinfo.ProjectRFA1_2rm = this.ProjectRFA1_2Rm.Text;
            this.pbinfo.ProjectRFA1_3rm = this.ProjectRFA1_3Rm.Text;
            this.pbinfo.ProjectRFA1_3_1rm = this.ProjectRFA1_3_1Rm.Text;
            this.pbinfo.ProjectRFA1_3_2rm = this.ProjectRFA1_3_2Rm.Text;
            this.pbinfo.ProjectRFA1_4rm = this.ProjectRFA1_4Rm.Text;
            this.pbinfo.ProjectRFA1_5rm = this.ProjectRFA1_5Rm.Text;
            this.pbinfo.ProjectRFA1_6rm = this.ProjectRFA1_6Rm.Text;
            this.pbinfo.ProjectRFA1_7rm = this.ProjectRFA1_7Rm.Text;
            this.pbinfo.ProjectRFA1_8rm = this.ProjectRFA1_8Rm.Text;
            this.pbinfo.ProjectRFA1_9rm = this.ProjectRFA1_9Rm.Text;
            this.pbinfo.ProjectRFA2rm = this.ProjectRFA2Rm.Text;
            this.pbinfo.ProjectRFA2_1rm = this.ProjectRFA2_1Rm.Text;
		}

		private void SetBudgetRatiovalue()
		{
            if (this.pbinfo != null)
            {
                this.ProjectRFA.Text = this.pbinfo.ProjectRFA.ToString();
                this.ProjectRFA1.Text = this.pbinfo.ProjectRFA1.ToString();
                this.ProjectRFA1_1.Text = this.pbinfo.ProjectRFA1_1.ToString();
                //this.ProjectRFA1_3.Text = this.pbinfo.ProjectRFA1_3.ToString();
                this.ProjectRFA2.Text = this.pbinfo.ProjectRFA2.ToString();
                this.ProjectRFA1zb.Text = this.pbinfo.ProjectRFA1zb.ToString() + "%";
                this.ProjectRFA2zb.Text = this.pbinfo.ProjectRFA2zb.ToString() + "%";
                this.ProjectRFA1_1zb.Text = this.pbinfo.ProjectRFA1_1zb.ToString() + "%";
                this.ProjectRFA1_1_1zb.Text = this.pbinfo.ProjectRFA1_1_1zb.ToString() + "%";
                this.ProjectRFA1_1_2zb.Text = this.pbinfo.ProjectRFA1_1_2zb.ToString() + "%";
                this.ProjectRFA1_1_3zb.Text = this.pbinfo.ProjectRFA1_1_3zb.ToString() + "%";
                this.ProjectRFA1_2zb.Text = this.pbinfo.ProjectRFA1_2zb.ToString() + "%";
                this.ProjectRFA1_3zb.Text = this.pbinfo.ProjectRFA1_3zb.ToString() + "%";
                this.ProjectRFA1_4zb.Text = this.pbinfo.ProjectRFA1_4zb.ToString() + "%";
                this.ProjectRFA1_5zb.Text = this.pbinfo.ProjectRFA1_5zb.ToString() + "%";
                this.ProjectRFA1_6zb.Text = this.pbinfo.ProjectRFA1_6zb.ToString() + "%";
                this.ProjectRFA1_7zb.Text = this.pbinfo.ProjectRFA1_7zb.ToString() + "%";
                this.ProjectRFA1_8zb.Text = this.pbinfo.ProjectRFA1_8zb.ToString() + "%";
                this.ProjectRFA1_9zb.Text = this.pbinfo.ProjectRFA1_9zb.ToString() + "%";
                this.ProjectRFA2_1zb.Text = this.pbinfo.ProjectRFA2_1zb.ToString() + "%";
            }
		}

		private void CollMarkInfo()
		{
            if (pbinfo != null)
            {
                try
                {
                    this.pbinfo.ProjectZiChouJingFei = decimal.Parse(txtZiChouJingFei.Text);
                }
                catch (Exception ex) { }

                this.pbinfo.ProjectRFArm = this.ProjectRFARm.Text;
                this.pbinfo.ProjectRFA1rm = this.ProjectRFA1Rm.Text;
                this.pbinfo.ProjectRFA1_1rm = this.ProjectRFA1_1Rm.Text;
                this.pbinfo.ProjectRFA1_1_1rm = this.ProjectRFA1_1_1Rm.Text;
                this.pbinfo.ProjectRFA1_1_2rm = this.ProjectRFA1_1_2Rm.Text;
                this.pbinfo.ProjectRFA1_1_3rm = this.ProjectRFA1_1_3Rm.Text;
                this.pbinfo.ProjectRFA1_2rm = this.ProjectRFA1_2Rm.Text;
                this.pbinfo.ProjectRFA1_3rm = this.ProjectRFA1_3Rm.Text;
                this.pbinfo.ProjectRFA1_3_1rm = this.ProjectRFA1_3_1Rm.Text;
                this.pbinfo.ProjectRFA1_3_2rm = this.ProjectRFA1_3_2Rm.Text;
                this.pbinfo.ProjectRFA1_4rm = this.ProjectRFA1_4Rm.Text;
                this.pbinfo.ProjectRFA1_5rm = this.ProjectRFA1_5Rm.Text;
                this.pbinfo.ProjectRFA1_6rm = this.ProjectRFA1_6Rm.Text;
                this.pbinfo.ProjectRFA1_7rm = this.ProjectRFA1_7Rm.Text;
                this.pbinfo.ProjectRFA1_8rm = this.ProjectRFA1_8Rm.Text;
                this.pbinfo.ProjectRFA1_9rm = this.ProjectRFA1_9Rm.Text;
                this.pbinfo.ProjectRFA2rm = this.ProjectRFA2Rm.Text;
                this.pbinfo.ProjectRFA2_1rm = this.ProjectRFA2_1Rm.Text;
                decimal value = 0m;
                if (this.ProjectOutlay1.Text.Trim() == "")
                {
                    this.pbinfo.Projectoutlay1 = null;
                }
                else if (decimal.TryParse(this.ProjectOutlay1.Text.Trim(), out value))
                {
                    this.pbinfo.Projectoutlay1 = new decimal?(value);
                }
                else
                {
                    this.pbinfo.Projectoutlay1 = null;
                }
                if (this.ProjectOutlay2.Text.Trim() == "")
                {
                    this.pbinfo.Projectoutlay2 = null;
                }
                else if (decimal.TryParse(this.ProjectOutlay2.Text.Trim(), out value))
                {
                    this.pbinfo.Projectoutlay2 = new decimal?(value);
                }
                else
                {
                    this.pbinfo.Projectoutlay2 = null;
                }
                if (this.ProjectOutlay3.Text.Trim() == "")
                {
                    this.pbinfo.Projectoutlay3 = null;
                }
                else if (decimal.TryParse(this.ProjectOutlay3.Text.Trim(), out value))
                {
                    this.pbinfo.Projectoutlay3 = new decimal?(value);
                }
                else
                {
                    this.pbinfo.Projectoutlay3 = null;
                }
                if (this.ProjectOutlay4.Text.Trim() == "")
                {
                    this.pbinfo.Projectoutlay4 = null;
                }
                else if (decimal.TryParse(this.ProjectOutlay4.Text.Trim(), out value))
                {
                    this.pbinfo.Projectoutlay4 = new decimal?(value);
                }
                else
                {
                    this.pbinfo.Projectoutlay4 = null;
                }
                if (this.ProjectOutlay5.Text.Trim() == "")
                {
                    this.pbinfo.Projectoutlay5 = null;
                    return;
                }
                if (decimal.TryParse(this.ProjectOutlay5.Text.Trim(), out value))
                {
                    this.pbinfo.Projectoutlay5 = new decimal?(value);
                    return;
                }
                this.pbinfo.Projectoutlay5 = null;
            }
		}

		private bool CanSave()
		{
			decimal d = 0m;
			decimal d2 = 0m;
			decimal num = 0m;
			decimal.TryParse(this.ProjectRFA.Text, out d);
			decimal.TryParse(this.ProjectOutlay1.Text, out d2);
			num += d2;
			decimal.TryParse(this.ProjectOutlay2.Text, out d2);
			num += d2;
			decimal.TryParse(this.ProjectOutlay3.Text, out d2);
			num += d2;
			decimal.TryParse(this.ProjectOutlay4.Text, out d2);
			num += d2;
			decimal.TryParse(this.ProjectOutlay5.Text, out d2);
			num += d2;
			string text = "";
			if (d != num)
			{
				text = "请注意，分年度经费预算之和与项目总经费不等，正确无误后方能保存。\r\n";
			}
            //else if (d > 500m)
            //{
            //    text += "请注意，经费总额超过500万,需要重新制定，正确无误后方能保存。\r\n";
            //}
			decimal d3 = 0m;
			decimal d4 = 0m;
			decimal d5 = 0m;
			decimal d6 = 0m;
			decimal.TryParse(this.ProjectRFA2.Text, out d3);
			decimal.TryParse(this.ProjectRFA1.Text, out d4);
			decimal.TryParse(this.ProjectRFA1_1_1.Text, out d5);
			decimal.TryParse(this.ProjectRFA1_3.Text, out d6);
			if (d3 > (d4 - d5 - d6) * 0.2m)
			{
				text += "请注意，间接经费不超过直接经费减去设备购置费和外协费的20%，正确无误后方能保存。\r\n";
			}
            if (text != string.Empty)
            {
                MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            else
            {
                return true;
            }
		}

		private void SaveProgress()
		{
			this.CollMarkInfo();

            //if (pbinfo != null)
            //{
            //    this._projectBudgetInfoService.UpdateProjectBudgetInfo(this.pbinfo);
            //}
		}

        public void RefreshCall()
        {
            //this.pbinfo = this._projectBudgetInfoService.GetProjectBudgetInfo();
            if (this.pbinfo == null)
            {
                this.pbinfo = new ProjectBudgetInfo();
            }
            this.pbinfo.Calc();
            this.SetBudgettoUI();
            this.SetBudgetRatiovalue();
        }

		private void frmbudget_Leave(object sender, EventArgs e)
		{
			if (this.issaved)
			{
				this.issaved = false;
				return;
			}
			if (!this.CanSave())
			{
				return;
			}
			this.SaveProgress();
		}

        private void btnSave_Click(object sender, EventArgs e)
        {
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                OnSaveEvent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！Ex:" + ex.ToString());
            }
            finally
            {
                upf.CloseProgressWithOnlyUI();
            }
        }
        
        public override void ClearView()
        {
            base.ClearView();

            pbinfo = new ProjectBudgetInfo();
            RefreshCall();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            ConvertMoneyData();
            RefreshCall();
        }

        private void ConvertMoneyData()
        {
            pbinfo = GetBudgetInfoObject(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID);
        }

        public static ProjectBudgetInfo GetBudgetInfoObject(string projectId)
        {
            ProjectBudgetInfo result = new ProjectBudgetInfo();
            List<MoneyAndYear> list = ConnectionManager.Context.table("MoneyAndYear").where("ProjectID='" + projectId + "'").select("*").getList<MoneyAndYear>(new MoneyAndYear());
            if (list != null)
            {
                PropertyInfo[] props = result.GetType().GetProperties();
                foreach (MoneyAndYear may in list)
                {
                    foreach (PropertyInfo pi in props)
                    {
                        if (pi.Name.Equals(may.Name))
                        {
                            try
                            {
                                if (pi.PropertyType.Name.Equals(typeof(string).Name))
                                {
                                    //System.String
                                    pi.SetValue(result, may.Value, null);
                                }
                                else
                                {
                                    //System.Decimal
                                    pi.SetValue(result, decimal.Parse(may.Value), null);
                                }
                            }
                            catch (Exception ex) { }
                        }
                    }
                }
            }

            return result;
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            #region 保存数据到pbinfo
            if (!this.CanSave())
            {
                return;
            }
            this.SaveProgress();
            this.issaved = true;
            #endregion

            //清空年度经费表
            if (((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj != null)
            {
                ConnectionManager.Context.table("MoneyAndYear").where("ProjectID='" + ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID + "'").delete();
                if (pbinfo != null)
                {
                    PropertyInfo[] props = pbinfo.GetType().GetProperties();
                    foreach (PropertyInfo pi in props)
                    {
                        object val = null;
                        try
                        {
                            val = pi.GetValue(pbinfo, null);
                        }
                        catch (Exception ex) { }

                        if (val != null)
                        {
                            MoneyAndYear may = new MoneyAndYear();
                            may.ID = Guid.NewGuid().ToString();
                            may.ProjectID = ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.ID;
                            may.Name = pi.Name;
                            may.Value = val.ToString();

                            may.copyTo(ConnectionManager.Context.table("MoneyAndYear")).insert();
                        }
                    }
                }
            }
        }

        public override bool IsInputCompleted()
        {
            return CanSave();
        }
         
        private void lklDownloadFuJian_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sourcePath = Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).RootDir, Path.Combine("Helper", "TianBaoShuoMing.docx"));

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.docx|*.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(sourcePath, sfd.FileName, true);
                    Process.Start(sfd.FileName);

                    MessageBox.Show("下载完成！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("下载失败！Ex:" + ex.ToString());
                }
            }
        }

        private void lklDownloadExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sourcePath = Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).RootDir, Path.Combine("Helper", "jingfei.xls"));

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xls|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(sourcePath, sfd.FileName, true);
                    Process.Start(sfd.FileName);

                    MessageBox.Show("下载完成！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("下载失败！Ex:" + ex.ToString());
                }
            }
        }

        private void btnExcelLoad_Click(object sender, EventArgs e)
        {
            if (ofdExcelDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataSet ds = ProjectReporterPlugin.Utility.ExcelHelper.ExcelToDataSet(ofdExcelDialog.FileName);
                    if (ds != null && ds.Tables.Count >= 1)
                    {
                        //显示提示窗体
                        Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
                        upf.LabalText = "正在导入，请稍等...";
                        upf.ShowProgressWithOnlyUI();
                        upf.PlayProgressWithOnlyUI(80);

                        insertDataFromData(ds.Tables[0]);

                        upf.CloseProgressWithOnlyUI();

                        btnSave.PerformClick();
                        MessageBox.Show("操作完成！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导入失败!Ex:" + ex.ToString());
                }
            }
        }

        private void insertDataFromData(DataTable dataTable)
        {
            try
            {
                #region 设置数据
                //金额
                ProjectRFA1_1_1.Text = dataTable.Rows[3].ItemArray[1] != null ? dataTable.Rows[3].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_1_1, new EventArgs());
                ProjectRFA1_1_2.Text = dataTable.Rows[4].ItemArray[1] != null ? dataTable.Rows[4].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_1_2, new EventArgs());
                ProjectRFA1_1_3.Text = dataTable.Rows[5].ItemArray[1] != null ? dataTable.Rows[5].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_1_3, new EventArgs());
                ProjectRFA1_2.Text = dataTable.Rows[6].ItemArray[1] != null ? dataTable.Rows[6].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_2, new EventArgs());
                ProjectRFA1_3.Text = dataTable.Rows[7].ItemArray[1] != null ? dataTable.Rows[7].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_3, new EventArgs());
                //ProjectRFA1_3_1.Text = dataTable.Rows[8].ItemArray[1] != null ? dataTable.Rows[8].ItemArray[1].ToString() : "0";
                //ProjectRFA_Leave(ProjectRFA1_3_1, new EventArgs());
                //ProjectRFA1_3_2.Text = dataTable.Rows[9].ItemArray[1] != null ? dataTable.Rows[9].ItemArray[1].ToString() : "0";
                //ProjectRFA_Leave(ProjectRFA1_3_2, new EventArgs());
                ProjectRFA1_4.Text = dataTable.Rows[8].ItemArray[1] != null ? dataTable.Rows[8].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_4, new EventArgs());
                ProjectRFA1_5.Text = dataTable.Rows[9].ItemArray[1] != null ? dataTable.Rows[9].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_5, new EventArgs());
                ProjectRFA1_6.Text = dataTable.Rows[10].ItemArray[1] != null ? dataTable.Rows[10].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_6, new EventArgs());
                ProjectRFA1_7.Text = dataTable.Rows[11].ItemArray[1] != null ? dataTable.Rows[11].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_7, new EventArgs());
                ProjectRFA1_8.Text = dataTable.Rows[12].ItemArray[1] != null ? dataTable.Rows[12].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_8, new EventArgs());
                ProjectRFA1_9.Text = dataTable.Rows[13].ItemArray[1] != null ? dataTable.Rows[13].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA1_9, new EventArgs());
                ProjectRFA2_1.Text = dataTable.Rows[15].ItemArray[1] != null ? dataTable.Rows[15].ItemArray[1].ToString() : "0";
                ProjectRFA_Leave(ProjectRFA2_1, new EventArgs());

                //备注
                ProjectRFARm.Text = dataTable.Rows[0].ItemArray[2] != null ? dataTable.Rows[0].ItemArray[2].ToString() : "";
                ProjectRFA1Rm.Text = dataTable.Rows[1].ItemArray[2] != null ? dataTable.Rows[1].ItemArray[2].ToString() : "";
                ProjectRFA1_1Rm.Text = dataTable.Rows[2].ItemArray[2] != null ? dataTable.Rows[2].ItemArray[2].ToString() : "";
                ProjectRFA1_1_1Rm.Text = dataTable.Rows[3].ItemArray[2] != null ? dataTable.Rows[3].ItemArray[2].ToString() : "";
                ProjectRFA1_1_2Rm.Text = dataTable.Rows[4].ItemArray[2] != null ? dataTable.Rows[4].ItemArray[2].ToString() : "";
                ProjectRFA1_1_3Rm.Text = dataTable.Rows[5].ItemArray[2] != null ? dataTable.Rows[5].ItemArray[2].ToString() : "";
                ProjectRFA1_2Rm.Text = dataTable.Rows[6].ItemArray[2] != null ? dataTable.Rows[6].ItemArray[2].ToString() : "";
                ProjectRFA1_3Rm.Text = dataTable.Rows[7].ItemArray[2] != null ? dataTable.Rows[7].ItemArray[2].ToString() : "";
                //ProjectRFA1_3_1Rm.Text = dataTable.Rows[8].ItemArray[2] != null ? dataTable.Rows[8].ItemArray[2].ToString() : "";
                //ProjectRFA1_3_2Rm.Text = dataTable.Rows[9].ItemArray[2] != null ? dataTable.Rows[9].ItemArray[2].ToString() : "";
                ProjectRFA1_4Rm.Text = dataTable.Rows[8].ItemArray[2] != null ? dataTable.Rows[8].ItemArray[2].ToString() : "";
                ProjectRFA1_5Rm.Text = dataTable.Rows[9].ItemArray[2] != null ? dataTable.Rows[9].ItemArray[2].ToString() : "";
                ProjectRFA1_6Rm.Text = dataTable.Rows[10].ItemArray[2] != null ? dataTable.Rows[10].ItemArray[2].ToString() : "";
                ProjectRFA1_7Rm.Text = dataTable.Rows[11].ItemArray[2] != null ? dataTable.Rows[11].ItemArray[2].ToString() : "";
                ProjectRFA1_8Rm.Text = dataTable.Rows[12].ItemArray[2] != null ? dataTable.Rows[12].ItemArray[2].ToString() : "";
                ProjectRFA1_9Rm.Text = dataTable.Rows[13].ItemArray[2] != null ? dataTable.Rows[13].ItemArray[2].ToString() : "";
                ProjectRFA2Rm.Text = dataTable.Rows[14].ItemArray[2] != null ? dataTable.Rows[14].ItemArray[2].ToString() : "";
                ProjectRFA2_1Rm.Text = dataTable.Rows[15].ItemArray[2] != null ? dataTable.Rows[15].ItemArray[2].ToString() : "";
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入错误！Ex:" + ex.ToString(), "错误");
            }
        }
    }
}