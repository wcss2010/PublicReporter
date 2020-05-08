using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectContractPlugin.Forms
{
    public partial class FrmNewProject : Form
    {
        public FrmNewProject()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbFromReportPKG.Checked)
            {
                ProjectType = NewProjectType.UseReporterPKG;
            }
            else if (rbFromOldContactPKG.Checked)
            {
                ProjectType = NewProjectType.UseOldContactPKG;
            }
            else
            {
                ProjectType = NewProjectType.UseNewContactPKG;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public NewProjectType ProjectType { get; set; }
    }

    public enum NewProjectType
    {
        UseReporterPKG,UseOldContactPKG,UseNewContactPKG
    }
}