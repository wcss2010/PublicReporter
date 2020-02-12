using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using PublicReporterLib.Utility;
using ProjectStrategicLeadershipPlugin.DB;
using ProjectStrategicLeadershipPlugin.DB.Entitys;
using Newtonsoft.Json;
using ProjectStrategicLeadershipPlugin.Forms;
using AbstractEditorPlugin;
using AbstractEditorPlugin.Controls;
using AbstractEditorPlugin.Forms;
using AbstractEditorPlugin.Utility;

namespace ProjectStrategicLeadershipPlugin.Editor
{
    public partial class SubjectDetailEditor : AbstractEditorPlugin.BaseEditor
    {
        private string subjectDocumentTempleteFile = string.Empty;

        public const string SubjectFileFlag = "详细内容附件_";

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

            RTFFileFirstName = SubjectFileFlag;
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

            txtInfo.SaveFile(getDestTxtFilePath(plSubjectContent1.Tag.ToString().Trim()));
        }

        /// <summary>
        /// 生成存储位置
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="fileExt">扩展名</param>
        /// <returns></returns>
        public string getDestFilePath(string moduleName, string fileExt)
        {
            return Path.Combine(PluginRootObj.filesDir, RTFFileFirstName + Name + "_" + moduleName + fileExt);
        }

        /// <summary>
        /// 生成文本文件存储位置
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public string getDestTxtFilePath(string moduleName)
        {
            return getDestFilePath(moduleName, ".txt");
        }

        /// <summary>
        /// 生成Doc文件存储位置
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public string getDestDocFilePath(string moduleName)
        {
            return getDestFilePath(moduleName, ".doc");
        }

        public override void refreshView()
        {
            base.refreshView();

            if (File.Exists(getDestTxtFilePath(plSubjectContent1.Tag.ToString().Trim())))
            {
                txtInfo.LoadFile(getDestTxtFilePath(plSubjectContent1.Tag.ToString().Trim()));
            }

            lblTitle.Text = "研究内容(" + Name + ")的详细内容页";
        }

        public override bool isInputCompleted()
        {
            return File.Exists(getInfoFilePath()) && File.Exists(getDestFilePath()) && File.Exists(getContentFilePath()) && File.Exists(getNeedFilePath());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FrmWorkProcess upf = new FrmWorkProcess();
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

        private void plContent_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control c in plContent.Controls)
            {
                c.Margin = new Padding(0, 25, 0, 0);
            }
        }

        private void btnEditContent2_Click(object sender, EventArgs e)
        {
            AbstractEditorPlugin.Editor.DocumentPasteEditor.openOrCreateWord(EditorName, subjectDocumentTempleteFile, getDestDocFilePath(plSubjectContent2.Tag.ToString().Trim()));
        }

        private void btnEditContent3_Click(object sender, EventArgs e)
        {
            AbstractEditorPlugin.Editor.DocumentPasteEditor.openOrCreateWord(EditorName, subjectDocumentTempleteFile, getDestDocFilePath(plSubjectContent3.Tag.ToString().Trim()));
        }

        private void btnEditContent4_Click(object sender, EventArgs e)
        {
            AbstractEditorPlugin.Editor.DocumentPasteEditor.openOrCreateWord(EditorName, subjectDocumentTempleteFile, getDestDocFilePath(plSubjectContent4.Tag.ToString().Trim()));
        }
    }
}