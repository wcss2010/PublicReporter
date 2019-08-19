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

namespace TestReporterPlugin.Controls
{
    /// <summary>
    /// 文档编辑控件
    /// </summary>
    public partial class DocumentPasteEditor : BaseEditor
    {
        private string filesDir;
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

        public DocumentPasteEditor()
        {
            InitializeComponent();

            filesDir = Path.Combine(PublicReporterLib.PluginLoader.CurrentPlugin.WorkDir, Path.Combine("Data", "Files"));
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
                    string file = Path.Combine(filesDir, EditorName + ".doc");
                    if (File.Exists(file))
                    {
                        try
                        {
                            Process.Start(file);
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
                            WordDocument wd = new WordDocument();
                            wd.WordDoc.Save(file);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("写入文档" + EditorName + "失败！Ex:" + ex.ToString());
                        }

                        try
                        {
                            Process.Start(file);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("打开文档" + EditorName + "失败！Ex:" + ex.ToString());
                        }
                    }
                }
            }
        }

        public override bool IsInputCompleted()
        {
            string file = Path.Combine(filesDir, EditorName + ".doc");
            return File.Exists(file);
        }
    }
}