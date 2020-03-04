using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            bool canCreateNew;
            //限制单例运行
            Mutex m = new Mutex(true, "PublicReporter-Main", out canCreateNew);
            if (canCreateNew)
            {
                //添加忽略
                PublicReporterLib.PluginLoader.IgnoreLoadDllFiles.Add("PublicReporterLib.dll");
                PublicReporterLib.PluginLoader.IgnoreLoadDllFiles.Add("Noear.Weed3.dll");
                PublicReporterLib.PluginLoader.IgnoreLoadDllFiles.Add("Aspose.Words.dll");
                PublicReporterLib.PluginLoader.IgnoreLoadDllFiles.Add("Newtonsoft.Json.dll");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new StartupForm());

                m.ReleaseMutex();    //必须
            }
            else
            {
                MessageBox.Show("对不起，本软件已经在运行了，请不要重复运行");
            }
        }
    }
}