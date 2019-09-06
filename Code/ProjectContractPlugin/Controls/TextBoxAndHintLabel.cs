using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProjectContractPlugin.Controls
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
            infoLabel.Font = new System.Drawing.Font("仿宋", 12, System.Drawing.FontStyle.Italic);
            infoLabel.ForeColor = System.Drawing.Color.Blue;
            infoLabel.Dock = DockStyle.Right;
            Controls.Add(infoLabel);
            infoLabel.BringToFront();
        }

        /// <summary>
        /// 提示文本
        /// </summary>
        public string HintText
        {
            get { return InfoLabel.Text.Replace("#", string.Empty); }
            set { InfoLabel.Text = "#" + value; }
        }
    }
}