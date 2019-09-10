using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjectContractPlugin.Forms
{
    public partial class FrmHelpBox : PublicReporterLib.SuperForm
    {
        public FrmHelpBox()
        {
            InitializeComponent();

            this.txtContent.LoadFile(Path.Combine(((PluginRoot)PluginLoader.CurrentPlugin).RootDir, Path.Combine("Helper", "help.rtf")));
        }
    }
}