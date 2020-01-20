using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AbstractEditorPlugin.Forms
{
    public partial class FrmHelpBox : BaseForm
    {
        public FrmHelpBox(string rtfFile)
        {
            InitializeComponent();

            if (File.Exists(rtfFile))
            {
                this.txtContent.LoadFile(rtfFile);
            }
        }
    }
}