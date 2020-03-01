using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjectStrategicLeadershipPlugin.Forms
{
    public partial class FrmPkgExport : AbstractEditorPlugin.BaseForm
    {
        public FrmPkgExport()
        {
            InitializeComponent();

            llMainDocument.Text = "使用word打开'" + WordPrinter.outputDocFileName + "'";
            txtReadme.LoadFile(Path.Combine(PluginRootObj.RootDir, Path.Combine("Helper", "exportReadme.rtf")));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void llMainDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string docFile = Path.Combine(PluginRootObj.dataDir, WordPrinter.outputDocFileName);
            if (File.Exists(docFile))
            {
                try
                {
                    Process.Start(docFile);
                }
                catch (Exception ex) { }
            }
        }
    }
}