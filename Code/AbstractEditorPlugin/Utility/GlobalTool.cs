using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractEditorPlugin.Utility
{
    /// <summary>
    /// 公共函数
    /// </summary>
    public class GlobalTool
    {
        /// <summary>
        /// 中文数字到阿拉伯数字
        /// </summary>
        /// <param name="chineseStr1"></param>
        /// <returns></returns>
        public static string ChineseToNumber(string chineseStr1)
        {
            string numStr = "0123456789";
            string chineseStr = "零一二三四五六七八九";
            char[] c = chineseStr1.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                int index = chineseStr.IndexOf(c[i]);
                if (index != -1)
                    c[i] = numStr.ToCharArray()[index];
            }
            numStr = null;
            chineseStr = null;
            return new string(c);
        }

        /// <summary>
        /// 阿拉伯数字到中文数字
        /// </summary>
        /// <param name="numberStr"></param>
        /// <returns></returns>
        public static string NumberToChinese(string numberStr)
        {
            string numStr = "0123456789";
            string chineseStr = "零一二三四五六七八九";
            char[] c = numberStr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                int index = numStr.IndexOf(c[i]);
                if (index != -1)
                    c[i] = chineseStr.ToCharArray()[index];
            }
            numStr = null;
            chineseStr = null;
            return new string(c);
        }
    }
}