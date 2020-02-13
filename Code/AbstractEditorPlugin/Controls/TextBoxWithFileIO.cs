using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AbstractEditorPlugin.Controls
{
    public class TextBoxWithFileIO : TextBox
    {
        public TextBoxWithFileIO()
        {
            EnabledMiddleInParentBox = false;
        }

        /// <summary>
        /// 是否在父控件里居中
        /// </summary>
        public bool EnabledMiddleInParentBox { get; set; }

        public void SaveFile(string file)
        {
            File.WriteAllText(file, Text);
        }

        public void LoadFile(string file)
        {
            if (File.Exists(file))
            {
                Text = File.ReadAllText(file);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            //是否在父控件里居中
            if (EnabledMiddleInParentBox)
            {
                if (Parent is HSkinTableLayoutPanel)
                {
                    HSkinTableLayoutPanel table = ((HSkinTableLayoutPanel)Parent);
                    TableLayoutPanelCellPosition cellObj = table.GetCellPosition(this);
                    RowStyle rs = table.RowStyles[cellObj.Row];
                    float topVal = (rs.Height - this.Height) / 2;
                    Margin = new Padding(3, (int)topVal, 3, 3);
                }
                else if (Parent is Panel)
                {
                    Panel panel = (Panel)Parent;
                    Top = (panel.Height - Height) / 2;
                    Left = (panel.Width - Width) / 2;
                }
            }
        }
    }
}