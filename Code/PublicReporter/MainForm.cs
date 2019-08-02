using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PublicReporter
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 插件目录
        /// </summary>
        public static string PluginDir = Path.Combine(Application.StartupPath, "Plugins");

        public MainForm()
        {
            InitializeComponent();

            try
            {
                Directory.CreateDirectory(MainForm.PluginDir);
            }
            catch (Exception ex) { }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //检查是否加载了插件
            if (PluginLoader.CurrentPlugin != null)
            {
                //检查当前是否允行退出
                if (PluginLoader.CurrentPlugin.IsEnableClosing())
                {
                    //插件停止
                    PluginLoader.CurrentPlugin.Stop();
                }
                else 
                {
                    //取消关闭
                    e.Cancel = true;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //加载插件
                PluginLoader.searchAndLoadPlugin(PluginDir);

                //判断是否可用
                if (PluginLoader.CurrentPlugin != null)
                {
                    //设置程序标题
                    this.Text = PluginLoader.CurrentPlugin.Title;

                    //设置工作目录
                    PluginLoader.CurrentPlugin.WorkDir = PluginDir;

                    //初始化
                    PluginLoader.CurrentPlugin.Init(tsButtonBar, tvSubjects, scContent.Panel2, ssHintBar, tsslHint);

                    //启动插件
                    PluginLoader.CurrentPlugin.Start();
                }
                else
                {
                    throw new Exception("没有找到填报插件！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("对不起，插件加载失败！Ex:" + ex.ToString());
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}