using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TestReporterPlugin.Utility
{
    public class WordReView
    {
        /// <summary>
        /// 输出word内容
        /// </summary>
        /// <param name="progressDialog"></param>
        public static void wordOutput(CircleProgressBarDialog progressDialog)
        {
            PluginRoot pt = ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin);
            if (pt.projectObj == null)
            {
                return;
            }

            Report(progressDialog, 10, "准备Word...", 1000);

            string fileName = pt.projectObj.Name + "-项目建议书.docx";
            WordUtility wu = new WordUtility();
            wu.CreateNewDocument(Path.Combine(Path.Combine(pt.WorkDir, "Helper"), "newtemplete.docx"));

            try
            {
                Report(progressDialog, 20, "准备数据...", 1000);

                Report(progressDialog, 30, "写入基本信息...", 1000);

                Report(progressDialog, 40, "写入文档文件...", 1000);

                Report(progressDialog, 50, "写入阶段信息...", 1000);

                Report(progressDialog, 60, "写入课题负责人及研究骨干信息...", 1000);

                Report(progressDialog, 70, "写入经费预算...", 1000);

                Report(progressDialog, 75, "写入联系方式...", 1000);

                Report(progressDialog, 80, "更新目录...", 1000);

                Report(progressDialog, 90, "生成文档...", 1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Report(progressDialog, 95, "", 1000);
        }

        /// <summary>
        /// 显示进度
        /// </summary>
        /// <param name="progressDialog"></param>
        /// <param name="progress"></param>
        /// <param name="txt"></param>
        /// <param name="sleepTime"></param>
        private static void Report(CircleProgressBarDialog progressDialog, int progress, string txt, int sleepTime)
        {
            progressDialog.ReportProgress(progress, 100);
            progressDialog.ReportInfo(txt);
            try
            {
                Thread.Sleep(sleepTime);
            }
            catch (Exception ex) { }
        }
    }
}