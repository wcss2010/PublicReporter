using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AbstractEditorPlugin.Forms
{
    public partial class FrmUploadUserPDF : BaseForm
    {
        /// <summary>
        /// PDF目标文件名
        /// </summary>
        public string PDFDestName { get; set; }

        public FrmUploadUserPDF(string welcomeText, string pdfName)
        {
            InitializeComponent();

            lblWelcome.Text = welcomeText;
            PDFDestName = pdfName;

            if (string.IsNullOrEmpty(PDFDestName))
            {
                PDFDestName = "用户上传的PDF";
            }

            lklPDFFile.Text = Path.GetFileName(getPDFFile());
            if (string.IsNullOrEmpty(lklPDFFile.Text))
            {
                lklPDFFile.Text = "......";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //删除原来的PDF文件
                string source = getPDFFile();
                if (File.Exists(source))
                {
                    File.Delete(source);
                }

                //复制PDF到目标位置
                File.Copy(ofdPDFS.FileName, Path.Combine(PluginRootObj.dataDir, PDFDestName + ".pdf"), true);

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("对不起，上传失败！Ex:" + ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (ofdPDFS.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lklPDFFile.Text = ofdPDFS.FileName;
            }
        }

        private void lklPDFFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string destPDF = Path.Combine(PluginRootObj.dataDir, lklPDFFile.Text);

            if (File.Exists(destPDF))
            {
                try
                {
                    Process.Start(destPDF);
                }
                catch (Exception ex) { }
            }
        }

        /// <summary>
        /// 本地PDF文件
        /// </summary>
        /// <returns></returns>
        public static string getPDFFile()
        {
            string result = string.Empty;
            string[] files = Directory.GetFiles(((AbstractPluginRoot)PluginLoader.CurrentPlugin).dataDir);
            foreach (string s in files)
            {
                if (s != null && s.EndsWith(".pdf"))
                {
                    result = s;
                    break;
                }
            }

            return result;
        }
    }
}