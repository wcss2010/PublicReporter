using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectMilitaryTechnologPlanPlugin.Forms
{
    public partial class FrmDateTimePickerBox : PublicReporterLib.SuperForm
    {
        public DateTime Value
        {
            get
            {
                return ibEdit15.Value;
            }
            set
            {
                ibEdit15.Value = value;
            }
        }

        public FrmDateTimePickerBox()
        {
            InitializeComponent();
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