using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aspose.Words;

namespace ProjectContractPlugin.Editor
{
    public partial class SubjectDetailEditor : BaseEditor
    {
        public string RTFFileFirstName { get; set; }

        public string TitleLabelText { get { return TitleLabelControl.Text; } set { TitleLabelControl.Text = value; } }

        public Label TitleLabelControl
        {
            get { return lblTitle; }
        }

        public TabControl DetailTabs
        {
            get { return knKetiDetailTabs; }
        }

        public SubjectDetailEditor()
        {
            InitializeComponent();

            RTFFileFirstName = "课题详细_";
        }

        public override void ClearView()
        {
            base.ClearView();

            txtInfo.Clear();
            //txtDest.Clear();
            //txtContent.Clear();
            //txtNeed.Clear();
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            txtInfo.SaveFile(GetInfoFilePath());
            //txtDest.SaveDoc(GetDestFilePath());
            //txtContent.SaveDoc(GetContentFilePath());
            //txtNeed.SaveDoc(GetNeedFilePath());
        }

        public string GetNeedFilePath()
        {
            return Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).filesDir, RTFFileFirstName + Name + "_研究思路" + ".doc");
        }

        public string GetContentFilePath()
        {
            return Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).filesDir, RTFFileFirstName + Name + "_研究内容" + ".doc");
        }

        public string GetDestFilePath()
        {
            return Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).filesDir, RTFFileFirstName + Name + "_研究目标" + ".doc");
        }

        public string GetInfoFilePath()
        {
            return Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).filesDir, RTFFileFirstName + Name + "_简介" + ".txt");
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (File.Exists(GetInfoFilePath()))
            {
                txtInfo.LoadFile(GetInfoFilePath());
            }

            if (File.Exists(GetDestFilePath()))
            {
                updateDestDocumentLabel(GetDestFilePath());
            }

            if (File.Exists(GetContentFilePath()))
            {
                updateContentDocumentLabel(GetContentFilePath());
            }

            if (File.Exists(GetNeedFilePath()))
            {
                updateNeedDocumentLabel(GetNeedFilePath());
            }
        }

        public override bool IsInputCompleted()
        {
            return File.Exists(GetInfoFilePath()) && File.Exists(GetDestFilePath()) && File.Exists(GetContentFilePath()) && File.Exists(GetNeedFilePath());
        }

        private void btnEditDest_Click(object sender, EventArgs e)
        {
            string tempFile = GetDestFilePath();

            if (File.Exists(tempFile))
            {
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(tempFile);
                    p.WaitForExit();

                    //更新显示标签
                    updateDestDocumentLabel(tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                }
            }
            else
            {
                try
                {
                    Aspose.Words.WordDocument wd = new Aspose.Words.WordDocument();
                    wd.WordDoc.Save(tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("写入文档" + EditorName + "失败！Ex:" + ex.ToString());
                }

                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(tempFile);
                    p.WaitForExit();

                    //更新显示标签
                    updateDestDocumentLabel(tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 更新研究目标标签
        /// </summary>
        /// <param name="tempFile"></param>
        private void updateDestDocumentLabel(string tempFile)
        {
            if (File.Exists(tempFile))
            {
                WordDocument wd = new WordDocument(tempFile);
                int pageCount = wd.WordDoc.BuiltInDocumentProperties.Pages;
                int wordCount = wd.WordDoc.BuiltInDocumentProperties.Words;
                lblDestWordInfo.Text = "当前文档总页数为" + pageCount + "页，总字数为" + wordCount + "字。";
            }
        }

        private void btnEditContent_Click(object sender, EventArgs e)
        {
            //临时文件
            string tempFile = GetContentFilePath();

            if (File.Exists(tempFile))
            {
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(tempFile);
                    p.WaitForExit();

                    //更新显示标签
                    updateContentDocumentLabel(tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                }
            }
            else
            {
                try
                {
                    Aspose.Words.WordDocument wd = new Aspose.Words.WordDocument();
                    wd.WordDoc.Save(tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("写入文档" + EditorName + "失败！Ex:" + ex.ToString());
                }
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(tempFile);
                    p.WaitForExit();

                    //更新显示标签
                    updateContentDocumentLabel(tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 更新研究内容标签
        /// </summary>
        /// <param name="tempFile"></param>
        private void updateContentDocumentLabel(string tempFile)
        {
            if (File.Exists(tempFile))
            {
                WordDocument wd = new WordDocument(tempFile);
                int pageCount = wd.WordDoc.BuiltInDocumentProperties.Pages;
                int wordCount = wd.WordDoc.BuiltInDocumentProperties.Words;
                lblContentWordInfo.Text = "当前文档总页数为" + pageCount + "页，总字数为" + wordCount + "字。";
            }
        }

        private void btnEditNeed_Click(object sender, EventArgs e)
        {
            string tempFile = GetNeedFilePath();

            if (File.Exists(tempFile))
            {
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(tempFile);
                    p.WaitForExit();

                    //更新显示标签
                    updateNeedDocumentLabel(tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                }
            }
            else
            {
                try
                {
                    Aspose.Words.WordDocument wd = new Aspose.Words.WordDocument();
                    wd.WordDoc.Save(tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("写入文档" + EditorName + "失败！Ex:" + ex.ToString());
                }

                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(tempFile);
                    p.WaitForExit();

                    //更新显示标签
                    updateNeedDocumentLabel(tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 更新研究思路标签
        /// </summary>
        /// <param name="tempFile"></param>
        private void updateNeedDocumentLabel(string tempFile)
        {
            if (File.Exists(tempFile))
            {
                WordDocument wd = new WordDocument(tempFile);
                int pageCount = wd.WordDoc.BuiltInDocumentProperties.Pages;
                int wordCount = wd.WordDoc.BuiltInDocumentProperties.Words;
                lblNeedWordInfo.Text = "当前文档总页数为" + pageCount + "页，总字数为" + wordCount + "字。";                
            }
        }
    }
}