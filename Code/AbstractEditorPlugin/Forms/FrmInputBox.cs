using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AbstractEditorPlugin.Forms
{
    public partial class FrmInputBox : BaseForm
    {
        public string SelectedText { get { return txtContent.Text; } }

        public bool SelectedTextReadOnly
        {
            get { return txtContent.ReadOnly; }
            set { txtContent.ReadOnly = value; }
        }

        public FrmInputBox(string txt)
        {
            InitializeComponent();

            txtContent.Text = txt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}