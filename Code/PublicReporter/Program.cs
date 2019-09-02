using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PublicReporter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //添加忽略
            PublicReporterLib.PluginLoader.IgnoreLoadDllFiles.Add("PublicReporterLib.dll");
            PublicReporterLib.PluginLoader.IgnoreLoadDllFiles.Add("Noear.Weed3.dll");
            PublicReporterLib.PluginLoader.IgnoreLoadDllFiles.Add("Aspose.Words.dll");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartupForm());
        }
    }
}