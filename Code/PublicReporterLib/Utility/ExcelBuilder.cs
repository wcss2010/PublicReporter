﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace PublicReporterLib.Utility
{
    /// <summary>
    /// 基于NPOI的Excel工具类(.xlsx)
    /// </summary>
    public class ExcelBuilder
    {
        /// <summary>
        /// 内容字体
        /// </summary>
        public NPOI.SS.UserModel.IFont ContentCellFont { get; set; }
        /// <summary>
        /// 内容样式
        /// </summary>
        public NPOI.SS.UserModel.ICellStyle ContentCellStyle { get; set; }

        /// <summary>
        /// 标题字体
        /// </summary>
        public NPOI.SS.UserModel.IFont TitleCellFont { get; set; }
        /// <summary>
        /// 标题样式
        /// </summary>
        public NPOI.SS.UserModel.ICellStyle TitleCellStyle { get; set; }

        /// <summary>
        /// 工作表对象
        /// </summary>
        public NPOI.XSSF.UserModel.XSSFWorkbook WorkBookObj { get; set; }

        /// <summary>
        /// 初始化样式
        /// </summary>
        public virtual void initStyles()
        {
            //创建单元格设置对象(普通内容)
            ContentCellStyle = WorkBookObj.CreateCellStyle();
            ContentCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            ContentCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            ContentCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            ContentCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            ContentCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            ContentCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            ContentCellStyle.WrapText = true;

            //创建单元格设置对象(标题内容)
            TitleCellStyle = WorkBookObj.CreateCellStyle();
            TitleCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            TitleCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            TitleCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            TitleCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            TitleCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            TitleCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            TitleCellStyle.WrapText = true;

            //创建设置字体对象(内容字体)
            ContentCellFont = WorkBookObj.CreateFont();
            ContentCellFont.FontHeightInPoints = 16;//设置字体大小
            ContentCellFont.FontName = "宋体";
            ContentCellStyle.SetFont(ContentCellFont);

            //创建设置字体对象(标题字体)
            TitleCellFont = WorkBookObj.CreateFont();
            TitleCellFont.FontHeightInPoints = 16;//设置字体大小
            TitleCellFont.FontName = "宋体";
            TitleCellFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            TitleCellStyle.SetFont(TitleCellFont);
        }

        /// <summary>
        /// 输出数据表格
        /// </summary>
        /// <param name="workbook">工作文档</param>
        /// <param name="normalStyle">普通样式(用于表格内容)</param>
        /// <param name="boldStyle">粗体样式(用于表格头部)</param>
        /// <param name="table">表格数据</param>
        public static void writeSheet(NPOI.XSSF.UserModel.XSSFWorkbook workbook, NPOI.SS.UserModel.ICellStyle normalStyle, NPOI.SS.UserModel.ICellStyle boldStyle, DataTable table)
        {
            //创建Sheet页
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet();

            //行号
            int rowIndex = 0;

            //是否需要输出表头
            bool isNeedCreateHeader = true;

            //输出数据到Excel
            foreach (DataRow rowData in table.Rows)
            {
                //忽略空数据行
                if (rowData.ItemArray == null || rowData.ItemArray.Length != table.Columns.Count)
                {
                    continue;
                }

                //列号
                int colIndex = 0;

                //Excel行
                NPOI.SS.UserModel.IRow row = null;

                //是否需要输入表头
                if (isNeedCreateHeader)
                {
                    isNeedCreateHeader = false;

                    //创建行
                    row = sheet.CreateRow(rowIndex);
                    //输出列名到Excel
                    colIndex = 0;
                    foreach (DataColumn kvp in table.Columns)
                    {
                        //列名
                        //创建列
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(colIndex);
                        //设置样式
                        cell.CellStyle = boldStyle;
                        //设置数据
                        cell.SetCellValue(kvp.ColumnName);
                        colIndex++;
                    }
                    rowIndex++;
                }

                //创建行
                row = sheet.CreateRow(rowIndex);
                //输出列值到Excel
                colIndex = 0;
                foreach (object val in rowData.ItemArray)
                {
                    //列值
                    //创建列
                    NPOI.SS.UserModel.ICell cell = row.CreateCell(colIndex);
                    //设置样式
                    cell.CellStyle = normalStyle;
                    //设置数据
                    //判断是否为空
                    if (val != null)
                    {
                        //不为空
                        //判断是否为RTF内容
                        if (val.GetType().Name.Equals(typeof(NPOI.XSSF.UserModel.XSSFRichTextString).Name))
                        {
                            //RTF内容
                            cell.SetCellValue((NPOI.XSSF.UserModel.XSSFRichTextString)val);
                        }
                        else
                        {
                            //文本内容
                            cell.SetCellValue(val.ToString());
                        }
                    }
                    else
                    {
                        //为空
                        cell.SetCellValue(string.Empty);
                    }
                    colIndex++;
                }
                rowIndex++;
            }

            //Excel列宽自动适应
            if (table.Rows.Count >= 1 && sheet.GetRow(0) != null)
            {
                for (int k = 0; k < sheet.GetRow(0).Cells.Count; k++)
                {
                    sheet.AutoSizeColumn(k);
                }
            }
        }

        /// <summary>
        /// 输出数据表格
        /// </summary>
        /// <param name="tables">表格数据</param>
        public virtual void writeTheSheet(DataTable tables)
        {
            writeSheet(WorkBookObj, ContentCellStyle, TitleCellStyle, tables);
        }

        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="excelFile"></param>
        public virtual void saveWorkbookToFile(string excelFile)
        {
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                //输出到流
                WorkBookObj.Write(memoryStream);

                //写Excel文件
                File.WriteAllBytes(excelFile, memoryStream.ToArray());
            }
            finally
            {
                memoryStream.Dispose();
            }
        }

        /// <summary>
        /// 写入DataTable到Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="excelFile"></param>
        public virtual void writeDataTableToExcel(DataTable dt, string excelFile)
        {
            //Excel数据
            MemoryStream memoryStream = new MemoryStream();

            //创建Workbook
            NPOI.XSSF.UserModel.XSSFWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();

            #region 设置Excel样式
            //创建单元格设置对象(普通内容)
            NPOI.SS.UserModel.ICellStyle cellStyleA = workbook.CreateCellStyle();
            cellStyleA.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            cellStyleA.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cellStyleA.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyleA.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyleA.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyleA.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyleA.WrapText = true;

            //创建单元格设置对象(普通内容)
            NPOI.SS.UserModel.ICellStyle cellStyleB = workbook.CreateCellStyle();
            cellStyleB.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cellStyleB.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cellStyleB.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyleB.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyleB.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyleB.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyleB.WrapText = true;

            //创建设置字体对象(内容字体)
            NPOI.SS.UserModel.IFont fontA = workbook.CreateFont();
            fontA.FontHeightInPoints = 16;//设置字体大小
            fontA.FontName = "宋体";
            cellStyleA.SetFont(fontA);

            //创建设置字体对象(标题字体)
            NPOI.SS.UserModel.IFont fontB = workbook.CreateFont();
            fontB.FontHeightInPoints = 16;//设置字体大小
            fontB.FontName = "宋体";
            fontB.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            cellStyleB.SetFont(fontB);
            #endregion

            //写入基本数据
            writeSheet(workbook, cellStyleA, cellStyleB, dt);

            #region 输出文件
            //输出到流
            workbook.Write(memoryStream);

            //写Excel文件
            File.WriteAllBytes(excelFile, memoryStream.ToArray());
            #endregion
        }

        /// <summary>
        /// 导出DataGridView到DataTable
        /// </summary>
        /// <param name="myDGV"></param>
        /// <returns></returns>
        public virtual DataTable toDataTable(DataGridView myDGV)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < myDGV.ColumnCount; i++)
            {
                dt.Columns.Add(myDGV.Columns[i].HeaderText);
            }
            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                List<object> values = new List<object>();
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    values.Add(myDGV.Rows[r].Cells[i].Value);
                }
                dt.Rows.Add(values.ToArray());
            }
            return dt;
        }

        /// <summary>
        /// 导出DataGrid中的数据到Excel文件并打开该文件(带文件保存对话框)
        /// </summary>
        /// <param name="dgv"></param>
        public virtual void exportToExcel(DataGridView dgv)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Empty;
            sfd.Filter = "*.xlsx|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //导出DataGridView的数据到DataTable
                    DataTable dt = toDataTable(dgv);

                    //写入Excel文件
                    writeDataTableToExcel(dt, sfd.FileName);

                    //弹出提示
                    MessageBox.Show("Excel导出完成！" + sfd.FileName);

                    //打开文件
                    if (File.Exists(sfd.FileName))
                    {
                        Process.Start(sfd.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("对不起，Excel导出失败！Ex:" + ex.ToString());
                }
            }
        }
    }
}