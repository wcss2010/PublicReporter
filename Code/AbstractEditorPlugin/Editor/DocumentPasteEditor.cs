using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PublicReporterLib;
using System.Diagnostics;
using Aspose.Words;
using AbstractEditorPlugin.Controls;

namespace AbstractEditorPlugin.Editor
{
    /// <summary>
    /// 文档编辑控件
    /// </summary>
    public partial class DocumentPasteEditor : BaseEditor
    {
        /// <summary>
        /// 空模板文件
        /// </summary>
        public string EmptyTempleteFile { get; set; }

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

        public DocumentPasteEditor()
        {
            InitializeComponent();
        }

        public DocumentPasteEditor(string name,string info,string templeteFile) : this()
        {
            EditorName = name;
            InfoLabelText = info;
            EmptyTempleteFile = templeteFile;
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
                    //目标存储位置
                    string file = Path.Combine(PluginRootObj.filesDir, EditorName + ".doc");

                    //打开或创建文档
                    openOrCreateWord(EditorName, EmptyTempleteFile, file);
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
        
        /// <summary>
        /// 打开或创建word文档
        /// </summary>
        /// <param name="editorName">编辑名称</param>
        /// <param name="docTempleteFile">模板文件地址</param>
        /// <param name="destDocFile">目标存储位置</param>
        public static void openOrCreateWord(string editorName, string docTempleteFile, string destDocFile)
        {
            if (File.Exists(destDocFile))
            {
                try
                {
                    System.Diagnostics.Process.Start(destDocFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + editorName + "失败！Ex:" + ex.ToString());
                }
            }
            else
            {
                if (File.Exists(docTempleteFile) && File.Exists(destDocFile) == false)
                {
                    try
                    {
                        File.Copy(docTempleteFile, destDocFile, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("写入文档" + editorName + "失败！Ex:" + ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        Aspose.Words.WordDocument wd = new Aspose.Words.WordDocument();
                        wd.WordDoc.Save(destDocFile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("写入文档" + editorName + "失败！Ex:" + ex.ToString());
                    }
                }

                try
                {
                    System.Diagnostics.Process.Start(destDocFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文档" + editorName + "失败！Ex:" + ex.ToString());
                }
            }
        }
    }
}