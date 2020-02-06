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

            txtInfo.SaveFile(getInfoFilePath());
            //txtDest.SaveDoc(GetDestFilePath());
            //txtContent.SaveDoc(GetContentFilePath());
            //txtNeed.SaveDoc(GetNeedFilePath());
        }

        public string getNeedFilePath()
        {
            return Path.Combine(PluginRootObj.filesDir, RTFFileFirstName + Name + "_" + kpNeed.Text + ".doc");
        }

        public string getContentFilePath()
        {
            return Path.Combine(PluginRootObj.filesDir, RTFFileFirstName + Name + "_" + kpContent.Text + ".doc");
        }

        public string getDestFilePath()
        {
            return Path.Combine(PluginRootObj.filesDir, RTFFileFirstName + Name + "_" + kpDest.Text + ".doc");
        }

        public string getInfoFilePath()
        {
            return Path.Combine(PluginRootObj.filesDir, RTFFileFirstName + Name + "_" + kpInfo.Text + ".txt");
        }

        public override void refreshView()
        {
            base.refreshView();

            if (File.Exists(getInfoFilePath()))
            {
                txtInfo.LoadFile(getInfoFilePath());
            }
        }

        public override bool isInputCompleted()
        {
            return File.Exists(getInfoFilePath()) && File.Exists(getDestFilePath()) && File.Exists(getContentFilePath()) && File.Exists(getNeedFilePath());
        }

        private void btnEditDest_Click(object sender, EventArgs e)
        {
            string tempFile = getDestFilePath();

            if (File.Exists(tempFile))
            {
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(tempFile);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                }
            }
        }

        private void btnEditContent_Click(object sender, EventArgs e)
        {
            //临时文件
            string tempFile = getContentFilePath();

            if (File.Exists(tempFile))
            {
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(tempFile);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                }
            }
        }

        private void btnEditNeed_Click(object sender, EventArgs e)
        {
            string tempFile = getNeedFilePath();

            if (File.Exists(tempFile))
            {
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(tempFile);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                }
            }
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
    }
}