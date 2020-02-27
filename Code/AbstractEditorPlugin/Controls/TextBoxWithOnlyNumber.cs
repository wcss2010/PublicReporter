using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AbstractEditorPlugin.Controls
{
    public class TextBoxWithOnlyNumber : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == 0x0D) e.KeyChar = (char)0;  //禁止回车键 
            if (e.KeyChar == 0x0A) e.KeyChar = (char)0;  //禁止换行键 
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键 
            if ((e.KeyChar == 0x2D) && (Text.Length == 0)) return;   //处理负数 
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符 
                }
            }
        }
    }
}