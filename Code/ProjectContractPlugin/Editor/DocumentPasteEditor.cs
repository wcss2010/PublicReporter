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
using ProjectContractPlugin.Controls;

namespace ProjectContractPlugin.Editor
{
    /// <summary>
    /// 文档编辑控件
    /// </summary>
    public partial class DocumentPasteEditor : BaseEditor
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

        public DocumentPasteEditor()
        {
            InitializeComponent();
        }

        public DocumentPasteEditor(string name,string info) : this()
        {
            EditorName = name;
            InfoLabelText = info;
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
                    string file = Path.Combine(((PluginRoot)PluginLoader.CurrentPlugin).filesDir, EditorName + ".doc");
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
                            WordDocument wd = new WordDocument();
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

        public override void RefreshView()
        {
            base.RefreshView();
        }

        public override bool IsInputCompleted()
        {
            return File.Exists(Path.Combine(((PluginRoot)PluginLoader.CurrentPlugin).filesDir, EditorName + ".doc"));
        }
    }
}