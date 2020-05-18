using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using PublicReporterLib;
using Aspose.Words;

namespace ProjectMoneyProtocolPlugin.Editor
{
    public partial class ExtFile2Editor : AbstractEditorPlugin.BaseEditor
    {
        /// <summary>
        /// 编辑器名称
        /// </summary>
        public override string EditorName
        {
            get
            {
                return base.EditorName;
            }
            set
            {
                base.EditorName = value;
            }
        }

        /// <summary>
        /// 编辑器说明文本
        /// </summary>
        public string InfoLabelText
        {
            get
            {
                return lblInfo.Text;
            }
            set
            {
                lblInfo.Text = value;
            }
        }

        /// <summary>
        /// 编辑器说明标签高度
        /// </summary>
        public int InfoLabelHeight
        {
            get
            {
                return lblInfo.Height;
            }
            set
            {
                lblInfo.Height = value;
            }
        }

        /// <summary>
        /// 自动适应说明标签高度
        /// </summary>
        public bool InfoLabelAutoHeight
        {
            get
            {
                return lblInfo.AutoHeight;
            }
            set
            {
                lblInfo.AutoHeight = value;
            }
        }

        public ExtFile2Editor()
        {
            InitializeComponent();

            txtWordReadme.LoadFile(((NewPluginRoot)PluginRootObj).getDocumentPasteReadmeFile());
        }

        private void btnEditDocument_Click(object sender, EventArgs e)
        {
            if (PluginLoader.CurrentPlugin != null)
            {
                if (string.IsNullOrEmpty(EditorName))
                {
                    return;
                }
                else
                {
                    string file = Path.Combine(PluginRootObj.filesDir, EditorName + ".doc");
                    if (File.Exists(file))
                    {
                        try
                        {
                            //启动word
                            Process p = Process.Start(file);
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
                            WordDocument wd = new WordDocument(Path.Combine(PluginRootObj.RootDir, Path.Combine("Helper", "readonlyD.doc")));
                            wd.WordDoc.Save(file);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("写入文档" + EditorName + "失败！Ex:" + ex.ToString());
                        }

                        try
                        {
                            //启动word
                            Process p = Process.Start(file);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                        }
                    }
                }
            }
        }

        public override void refreshView()
        {
            base.refreshView();
        }

        public override bool isInputCompleted()
        {
            return File.Exists(Path.Combine(PluginRootObj.filesDir, EditorName + ".doc"));
        }
    }
}