using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectMoneyProtocolPlugin.Forms
{
    public partial class FrmEditOrder : AbstractEditorPlugin.BaseForm
    {
        public decimal OrderNum
        {
            get
            {
                return txtNumber.Value;
            }
            set
            {
                txtNumber.Value = value;
            }
        }

        public FrmEditOrder()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}