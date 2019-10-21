using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Aspose.Words;
using Microsoft.Win32;

namespace ProjectContractPlugin.Utility
{
    public class WordUtility
    {
        public WordDocument Document { get; set; }

        /// <summary>
        /// 通过模板创建新文件
        /// </summary>
        /// <param name="filePath"></param>
        public void createNewDocument(string filePath)
        {
            Document = new WordDocument(filePath);
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <param name="filePath"></param>
        public void saveDocument(string filePath)
        {
            Document.WordDoc.Save(filePath, SaveFormat.Doc);
        }

        /// <summary>
        /// 选择书签
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <returns></returns>
        public bool selectBookMark(string bookmark)
        {
            return Document.WordDocBuilder.MoveToBookmark(bookmark);
        }

        public bool insertValue(string bookmark, string value)
        {
            return insertValue(bookmark, value, false);
        }

        /// <summary>
        /// 在书签处插入值
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="value">要插入的值</param>
        /// <returns></returns>
        public bool insertValue(string bookmark, string value, bool isNeedNewLine)
        {
            object bkObj = bookmark;
            if (Document.WordDocBuilder.MoveToBookmark(bookmark))
            {
                if (isNeedNewLine)
                {
                    Document.WordDocBuilder.Writeln(value);
                }
                else
                {
                    Document.WordDocBuilder.Write(value);
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// 在书签处插入值(改变字体在小及是否加粗)
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="value">要插入的值</param>
        /// <returns></returns>
        public bool insertValue(string bookmark, string value, int fontSize, bool isBold, bool isItalic, bool isUnderline)
        {
            object bkObj = bookmark;
            if (Document.WordDocBuilder.MoveToBookmark(bookmark))
            {
                //保存先前的设置
                double lastSize = Document.WordDocBuilder.Font.Size;
                bool lastBold = Document.WordDocBuilder.Font.Bold;
                bool lastItalic = Document.WordDocBuilder.Font.Italic;
                Underline lastUnderline = Document.WordDocBuilder.Font.Underline;

                //设置字号及是否加粗
                Document.WordDocBuilder.Font.Size = fontSize;
                Document.WordDocBuilder.Font.Bold = isBold;
                Document.WordDocBuilder.Font.Italic = isItalic;
                Document.WordDocBuilder.Font.Underline = isUnderline ? Underline.Single : Underline.None;

                Document.WordDocBuilder.Write(value);

                //恢复先前的设置
                Document.WordDocBuilder.Font.Size = lastSize;
                Document.WordDocBuilder.Font.Bold = lastBold;
                Document.WordDocBuilder.Font.Italic = lastItalic;
                Document.WordDocBuilder.Font.Underline = lastUnderline;

                return true;
            }
            return false;
        }

        /// <summary>
        /// 在书签处插入文件
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="value">要插入的文件路径</param>
        /// <returns></returns>
        public bool insertFile(string bookmark, string filePath, bool enabledDeleteEnterFlag)
        {
            if (File.Exists(filePath))
            {
                object bkObj = bookmark;
                if (File.Exists(filePath))
                {
                    if (Document.WordDocBuilder.MoveToBookmark(bookmark))
                    {
                        Document.insertDocumentAfterBookMark(new Document(filePath), bookmark, enabledDeleteEnterFlag);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 插入文本文件
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool insertTxtFile(string bookmark, string filePath)
        {
            if (File.Exists(filePath))
            {
                insertValue(bookmark, File.ReadAllText(filePath));
            }
            return true;
        }

        public void delete()
        {
            if (Document.WordDocBuilder.CurrentParagraph != null)
            {
                Document.WordDocBuilder.CurrentParagraph.RemoveAllChildren();
            }
        }

        public void deleteCurrentAll()
        {
            if (Document.WordDocBuilder.CurrentParagraph != null)
            {
                Document.WordDocBuilder.CurrentParagraph.RemoveAllChildren();
            }
        }

        public void deleteCurrentAndLast()
        {
            //object _unitObj = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            //object _countObj = 1;
            //object _extendObj = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;

            //wordApp.Selection.MoveUp(ref _unitObj, ref _countObj,ref _extendObj);

            //object objValue = System.Reflection.Missing.Value;
            //wordApp.Selection.Delete(ref objValue, ref objValue);
        }

        /// <summary> 
        /// 字符串替换A 
        /// </summary> 
        /// <param name="strOld">旧的</param> 
        /// <param name="strNew">新的</param> 
        public void replaceA(string strOld, string strNew)
        {
            Document.WordDoc.Range.Replace(strOld, strNew, false, false);
        }

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="picturePath"></param>
        public void insertPicture(string bookmark, string picturePath)
        {
            if (File.Exists(picturePath))
            {
                if (Document.WordDocBuilder.MoveToBookmark(bookmark))
                {
                    Document.WordDocBuilder.InsertImage(picturePath);
                }
            }
        }

        /// <summary>
        /// 关闭Word进程
        /// </summary>
        public void killWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
            }
        }
    }
}