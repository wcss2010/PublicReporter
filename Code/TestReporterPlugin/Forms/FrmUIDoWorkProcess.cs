using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestReporterPlugin.Forms
{
    public partial class FrmUIDoWorkProcess : Form
    {
        /// <summary>
        /// 是否显示进度条
        /// </summary>
        public bool EnabledDisplayProgress
        {
            get
            {
                return pbProgress.Visible;
            }
            set
            {
                pbProgress.Visible = value;
            }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        public int ProgresBarMaximum
        {
            get
            {
                return pbProgress.Maximum;
            }
            set
            {
                pbProgress.Maximum = value;
                pbProgress.Value = 0;
            }
        }

        /// <summary>
        /// 标签文本
        /// </summary>
        public string LabalText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public FrmUIDoWorkProcess()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 进度条+1
        /// </summary>
        public void Next()
        {
            if (pbProgress.Value + 1 > pbProgress.Maximum)
            {
                return;
            }
            else
            {
                pbProgress.Value++;
            }

            //立即执行
            Application.DoEvents();
        }

        public void ShowProgress()
        {
            Show();

            //立即执行
            Application.DoEvents();
        }
    }
}