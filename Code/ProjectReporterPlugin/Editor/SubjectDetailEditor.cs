using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aspose.Words;

namespace ProjectReporterPlugin.Editor
{
    public partial class SubjectDetailEditor : AbstractEditorPlugin.BaseEditor
    {
        private string subjectDocumentTempleteFile;
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

            txtWordReadme.LoadFile(((NewPluginRoot)PluginRootObj).getDocumentPasteReadmeFile());
            txtWordReadme2.LoadFile(((NewPluginRoot)PluginRootObj).getDocumentPasteReadmeFile());
            txtWordReadme3.LoadFile(((NewPluginRoot)PluginRootObj).getDocumentPasteReadmeFile());

            subjectDocumentTempleteFile = Path.Combine(PluginRootObj.RootDir, Path.Combine("Helper", "subjectEmptyPaste.doc"));
        }

        public override void clearView()
        {
            base.clearView();

            txtInfo.Clear();
            //txtDest.Clear();
            //txtContent.Clear();
            //txtNeed.Clear();
        }

        public override void onSaveEvent(ref bool result)
        {
            base.onSaveEvent(ref result);

            txtInfo.SaveFile(GetInfoFilePath());
            //txtDest.SaveDoc(GetDestFilePath());
            //txtContent.SaveDoc(GetContentFilePath());
            //txtNeed.SaveDoc(GetNeedFilePath());
        }

        public string GetNeedFilePath()
        {
            return Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<NewPluginRoot>().filesDir, RTFFileFirstName + Name + "_研究思路" + ".doc");
        }

        public string GetContentFilePath()
        {
            return Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<NewPluginRoot>().filesDir, RTFFileFirstName + Name + "_研究内容" + ".doc");
        }

        public string GetDestFilePath()
        {
            return Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<NewPluginRoot>().filesDir, RTFFileFirstName + Name + "_研究目标" + ".doc");
        }

        public string GetInfoFilePath()
        {
            return Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<NewPluginRoot>().filesDir, RTFFileFirstName + Name + "_简介" + ".txt");
        }

        public override void refreshView()
        {
            base.refreshView();

            if (File.Exists(GetInfoFilePath()))
            {
                txtInfo.LoadFile(GetInfoFilePath());
            }
        }

        public override bool isInputCompleted()
        {
            return File.Exists(GetInfoFilePath()) && File.Exists(GetDestFilePath()) && File.Exists(GetContentFilePath()) && File.Exists(GetNeedFilePath());
        }

        private void btnEditDest_Click(object sender, EventArgs e)
        {
            string tempFile = GetDestFilePath();

            AbstractEditorPlugin.Editor.DocumentPasteEditor.openOrCreateWord(EditorName, subjectDocumentTempleteFile, tempFile);
        }

        private void btnEditContent_Click(object sender, EventArgs e)
        {
            //临时文件
            string tempFile = GetContentFilePath();

            
            AbstractEditorPlugin.Editor.DocumentPasteEditor.openOrCreateWord(EditorName, subjectDocumentTempleteFile, tempFile);
        }

        private void btnEditNeed_Click(object sender, EventArgs e)
        {
            string tempFile = GetNeedFilePath();

            
            AbstractEditorPlugin.Editor.DocumentPasteEditor.openOrCreateWord(EditorName, subjectDocumentTempleteFile, tempFile);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                bool result = true;
                onSaveEvent(ref result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！Ex:" + ex.ToString());
            }
            finally
            {
                upf.CloseProgressWithOnlyUI();
            }
        }
    }
}