using PublicReporterLib.ControlAndForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AbstractEditorPlugin
{
    public partial class BaseForm : PluginForm<AbstractPluginRoot>
    {
        public BaseForm()
        {
            InitializeComponent();
        }
    }
}