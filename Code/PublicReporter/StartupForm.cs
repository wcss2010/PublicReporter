using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void btnStartA_Click(object sender, EventArgs e)
        {
            Hide();
            DisplayForm df = new DisplayForm();
            df.FormClosed += df_FormClosed;
            df.loadPlugin(DisplayForm.PluginDirs);
            df.Show();
            df.WindowState = FormWindowState.Maximized;
        }

        void df_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void btnStartB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("对不起，正在开发中...", "提示");
        }
    }
}