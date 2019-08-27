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
    /// 显示一个假的进度条
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
        public void ShowProgress()
        {
            TransparencyKey = BackColor;
            ProgressBar.ForeColor = Color.Red;
            MessageLabel.ForeColor = Color.Blue;
            FormBorderStyle = FormBorderStyle.None;
            Start(new EventHandler<CircleProgressBarEventArgs>(delegate(object thisObject, CircleProgressBarEventArgs argss)
                {
                    ReportProgress(10, 100);
                    try
                    {
                        Thread.Sleep(500);
                    }
                    catch (Exception ex) { }

                    ReportProgress(20, 100);
                    try
                    {
                        Thread.Sleep(500);
                    }
                    catch (Exception ex) { }

                    ReportProgress(30, 100);
                    try
                    {
                        Thread.Sleep(500);
                    }
                    catch (Exception ex) { }

                    ReportProgress(70, 100);
                    try
                    {
                        Thread.Sleep(500);
                    }
                    catch (Exception ex) { }

                    if (IsDisposed)
                    {
                        ReportProgress(100, 100);
                        try
                        {
                            Thread.Sleep(500);
                        }
                        catch (Exception ex) { }
                        return;
                    }
                    else
                    {
                        try
                        {
                            Thread.Sleep(500);
                        }
                        catch (Exception ex) { }
                    }
                }));
        }
    }
}