using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublicReporterLib.ControlAndForms
{
    public partial class PluginForm<PluginRootClass> : Form where PluginRootClass : IReportPluginRoot
    {
        public PluginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 插件入口
        /// </summary>
        public PluginRootClass PluginRootObj
        {
            get
            {
                if (PluginLoader.CurrentPlugin is PluginRootClass)
                {
                    return (PluginRootClass)PluginLoader.CurrentPlugin;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}