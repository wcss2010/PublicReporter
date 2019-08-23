using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TestReporterPlugin.Controls
{
    /// <summary>
    /// 带右上角标签的文本框
    /// </summary>
    public class TextBoxAndHintLabel :TextBox
    {
        private Label infoLabel;
        /// <summary>
        /// 说明标签
        /// </summary>
        public Label InfoLabel
        {
            get { return infoLabel; }
        }

        public TextBoxAndHintLabel() : base()
        {
            Multiline = true;
            infoLabel = new Label();
            infoLabel.AutoSize = true;
            infoLabel.Font = new System.Drawing.Font("仿宋", 9);
            infoLabel.Dock = DockStyle.Right;
            Controls.Add(infoLabel);
            infoLabel.BringToFront();
        }

        /// <summary>
        /// 提示文本
        /// </summary>
        public string HintText
        {
            get { return InfoLabel.Text; }
            set { InfoLabel.Text = value; }
        }        
    }
}