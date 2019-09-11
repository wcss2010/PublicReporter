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
    public partial class TextContentEditor : BaseEditor
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

        public TextContentEditor()
        {
            InitializeComponent();
        }

        public TextContentEditor(string name, string info)
            : this()
        {
            EditorName = name;
            InfoLabelText = info;
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            File.WriteAllText(getTxtFilePath(), txtContent.Text);
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (PluginLoader.CurrentPlugin != null)
            {
                if (string.IsNullOrEmpty(EditorName))
                {
                    return;
                }
                else
                {
                    if (File.Exists(getTxtFilePath()))
                    {
                        txtContent.Text = File.ReadAllText(getTxtFilePath());
                    }
                }
            }
        }

        private string getTxtFilePath()
        {
            return Path.Combine(PluginRootObj.filesDir, EditorName + ".txt");
        }

        public override bool IsInputCompleted()
        {
            return File.Exists(getTxtFilePath());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                OnSaveEvent();
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