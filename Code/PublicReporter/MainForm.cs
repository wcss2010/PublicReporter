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

        private void tvSubjects_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}