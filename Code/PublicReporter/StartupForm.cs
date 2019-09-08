using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
            //载入配置
            PluginConfig.loadConfig();

            //尝试载入插件
            if (PluginConfig.CurrentConfig != null && Directory.Exists(Path.Combine(DisplayForm.PluginDirs, PluginConfig.CurrentConfig.PluginName)))
            {
                Hide();
                DisplayForm df = new DisplayForm();
                df.FormClosed += df_FormClosed;
                df.loadPlugin(Path.Combine(DisplayForm.PluginDirs, PluginConfig.CurrentConfig.PluginName));
                df.Show();
                df.WindowState = FormWindowState.Maximized;
            }
            else
            {
                MessageBox.Show("对不起，没有找到填报插件！");
            }
        }
    }
}