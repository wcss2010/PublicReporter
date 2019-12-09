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
using ProjectMilitaryTechnologPlanPlugin.Controls;

namespace ProjectMilitaryTechnologPlanPlugin.Editor
{
    /// <summary>
    /// 文档编辑控件
    /// </summary>
    public partial class TextReadOnlyEditor : BaseEditor
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

        public TextReadOnlyEditor()
        {
            InitializeComponent();
        }

        public TextReadOnlyEditor(string name, string info,string rtfFile)
            : this()
        {
            EditorName = name;
            InfoLabelText = info;
            RTFFile = rtfFile;

            updateTextControl();
        }

        private void updateTextControl()
        {
            if (File.Exists(RTFFile))
            {
                txtContent.LoadFile(RTFFile);
            }
        }

        public override bool IsInputCompleted()
        {
            return true;
        }

        public string RTFFile { get; set; }
    }
}