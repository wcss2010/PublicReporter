using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void llMainDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}