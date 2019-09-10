using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PublicReporterLib.ControlAndForms
{
    public partial class PluginControl<PluginRootClass> : UserControl where PluginRootClass : IReportPluginRoot
    {
        public PluginControl()
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