using System;
using System.Collections.Generic;
using System.IO;
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
        public static string chineseToNumber(string chineseStr1)
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
        public static string numberToChinese(string numberStr)
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

        /// <summary>
        /// 文件是否存在使用
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool isFileUsing(string filePath)
        {
            bool result = false;
            System.IO.FileStream fs = null;
            try
            {
                fs = File.OpenWrite(filePath);
                fs.Close();
            }
            catch (Exception ex)
            {
                result = true;
            }
            return result;//true 打开 false 没有打开
        }

        /// <summary>
        /// 检查目录是否被占用(仅当前目录)
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static bool isDirUsing(string dirPath)
        {
            bool result = false;
            try
            {
                string sourceDir = dirPath;
                string destDir = Path.Combine(Directory.GetParent(dirPath).FullName, Guid.NewGuid().ToString() + "_" + DateTime.Now.Ticks);
                Directory.Move(sourceDir, destDir);
                Directory.Move(destDir, sourceDir);
            }
            catch (Exception ex)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 检查目录是否被占用
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool isDirUsingWithAll(string path)
        {
            bool result = false;            
            //检查目录
            string[] dirss = Directory.GetDirectories(path);
            foreach (string s in dirss)
            {
                result = isDirUsing(s);
                if (result)
                {
                    break;
                }
                else
                {
                    result = isDirUsingWithAll(s);
                    if (result)
                    {
                        break;
                    }
                }
            }
            if (result == false)
            {
                //检查文件
                string[] filesss = Directory.GetFiles(path);
                foreach (string s in filesss)
                {
                    result = isFileUsing(s);
                    if (result)
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }
}