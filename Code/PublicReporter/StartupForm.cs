using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PublicReporter
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        void df_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                    {
                        try
                        {
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                        }
                        catch (Exception ex) { }
                    }));
            }
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
            try
            {
                //载入欢迎画面
                if (File.Exists(Path.Combine(Application.StartupPath, "welcome.jpg")))
                {
                    pbLog.Image = Image.FromFile(Path.Combine(Application.StartupPath, "welcome.jpg"));
                }

                //启动一个第三方线程进行这个操作
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(delegate(object obj)
                    {
                        //稍微停留一会显示欢迎画面
                        try
                        {
                            Thread.Sleep(1500);
                        }
                        catch (Exception ex) { }

                        //准备显示界面
                        if (IsHandleCreated)
                        {
                            Invoke(new MethodInvoker(delegate()
                                {
                                    try
                                    {
                                        //尝试载入插件
                                        if (PluginConfig.CurrentConfig != null && Directory.Exists(Path.Combine(DisplayForm.PluginDirs, PluginConfig.CurrentConfig.PluginName)))
                                        {
                                            //创建并显示窗体
                                            DisplayForm df = new DisplayForm();
                                            df.FormClosed += df_FormClosed;
                                            df.loadPlugin(Path.Combine(DisplayForm.PluginDirs, PluginConfig.CurrentConfig.PluginName));
                                            df.Show();
                                            df.WindowState = FormWindowState.Maximized;

                                            //隐藏这个界面
                                            this.Width = 0;
                                            this.Height = 0;
                                        }
                                        else
                                        {
                                            MessageBox.Show("对不起，没有找到填报插件！");
                                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("对不起，填报系统启动失败！Ex:" + ex.ToString());
                                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                                    }
                                }));
                        }
                    }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("对不起，填报系统启动失败！Ex:" + ex.ToString());
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }
}