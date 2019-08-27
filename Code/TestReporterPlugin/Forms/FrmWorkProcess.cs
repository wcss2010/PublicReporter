using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TestReporterPlugin.Forms
{
    /// <summary>
    /// 显示一个假的进度条(只能在UI线程下用)
    /// </summary>
    public partial class FrmWorkProcess : CircleProgressBarDialog
    {
        /// <summary>
        /// 标签文本
        /// </summary>
        public string LabalText
        {
            get { return MessageLabel.Text; }
            set { MessageLabel.Text = value; }
        }

        public FrmWorkProcess()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示进度条
        /// </summary>
        public void ShowProgressWithOnlyUI()
        {
            TransparencyKey = BackColor;
            ProgressBar.ForeColor = Color.Red;
            MessageLabel.ForeColor = Color.Blue;
            FormBorderStyle = FormBorderStyle.None;
            Show();            
        }

        /// <summary>
        /// 播放进度条动画
        /// </summary>
        /// <param name="playProgressMax">进度值</param>
        public void PlayProgressWithOnlyUI(int playProgressMax)
        {
            for (int kk = 1; kk <= playProgressMax; kk++)
            {
                ReportProgressWithOnlyUI(kk);
            }
        }

        /// <summary>
        /// 设置进度(只能在UI线程下用)
        /// </summary>
        /// <param name="value"></param>
        public void ReportProgressWithOnlyUI(int value)
        {
            ProgressBar.CurrentProgress = value;
            Application.DoEvents();
        }

        /// <summary>
        /// 设置文本(只能在UI线程下用)
        /// </summary>
        /// <param name="txt"></param>
        public void ReportInfoWithOnlyUI(string txt)
        {
            MessageLabel.Text = txt;
            Application.DoEvents();
        }

        /// <summary>
        /// 关闭进度条
        /// </summary>
        public void CloseProgressWithOnlyUI()
        {
            ProgressBar.CurrentProgress = 100;
            Application.DoEvents();
            Close();
        }
    }
}