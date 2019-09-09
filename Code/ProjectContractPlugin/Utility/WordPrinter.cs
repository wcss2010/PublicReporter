using Aspose.Words;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ProjectContractPlugin.DB;
using ProjectContractPlugin.DB.Entitys;
using ProjectContractPlugin.Editor;

namespace ProjectContractPlugin.Utility
{
    public class WordPrinter
    {
        /// <summary>
        /// 经费概算附件
        /// </summary>
        private static string uploadA = string.Empty;

        /// <summary>
        /// 输出word内容
        /// </summary>
        /// <param name="progressDialog"></param>
        public static void wordOutput(CircleProgressBarDialog progressDialog)
        {
            //判断是否加载了项目信息
            PluginRoot pt = ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin);
            if (pt.projectObj == null)
            {
                return;
            }

            Report(progressDialog, 10, "准备Word...", 1000);

            //创建word文档
            string fileName = pt.projectObj.BianHao + "-合同书.docx";
            WordUtility wu = new WordUtility();
            wu.createNewDocument(Path.Combine(Path.Combine(pt.RootDir, "Helper"), "template.doc"));

            try
            {
                Report(progressDialog, 20, "准备数据...", 1000);

                Report(progressDialog, 30, "写入基本信息...", 1000);

                #region 固定文本替换
                wu.insertValue("首页_合同编号", pt.projectObj.HeTongBianHao);
                wu.insertValue("首页_密级", pt.projectObj.HeTongMiJi);
                wu.insertValue("首页_密级期限", pt.projectObj.HeTongMiQi.ToString());
                wu.insertValue("首页_合同名称", pt.projectObj.HeTongMingCheng);
                wu.insertValue("首页_承研单位", pt.projectObj.ChengYanDanWeiMingCheng);
                wu.insertValue("首页_项目负责人", pt.projectObj.HeTongFuZeRen);
                wu.insertValue("首页_起止时间", pt.projectObj.HeTongKaiShiShiJian.ToString("yyyy年MM月dd日") + " 至" + pt.projectObj.HeTongJieShuShiJian.ToString("yyyy年MM月dd日"));
                wu.insertValue("基本信息_合同编号", pt.projectObj.HeTongBianHao);
                wu.insertValue("基本信息_合同名称", pt.projectObj.HeTongMingCheng);
                wu.insertValue("基本信息_起止时间", pt.projectObj.HeTongKaiShiShiJian.ToString("yyyy年MM月dd日") + " 至" + pt.projectObj.HeTongJieShuShiJian.ToString("yyyy年MM月dd日"));
                wu.insertValue("基本信息_合同价款", pt.projectObj.HeTongJiaKuan.ToString());
                wu.insertValue("基本信息_经费管理模式", pt.projectObj.HeTongJingFeiGuanLiMoShi);
                wu.insertValue("基本信息_委托_单位名称", pt.projectObj.WeiTuoDanWeiMingCheng);
                wu.insertValue("基本信息_承研_单位名称", pt.projectObj.ChengYanDanWeiMingCheng);
                wu.insertValue("基本信息_委托_单位性质", pt.projectObj.WeiTuoDanWeiXingZhi);
                wu.insertValue("基本信息_承研_单位性质", pt.projectObj.ChengYanDanWeiXingZhi);
                wu.insertValue("基本信息_委托_法定代表人", pt.projectObj.WeiTuoDanWeiFaDingDaiBiaoRen);
                wu.insertValue("基本信息_承研_法定代表人", pt.projectObj.ChengYanDanWeiFaDingDaiBiaoRen);
                wu.insertValue("基本信息_委托_联系人", pt.projectObj.WeiTuoDanWeiLianXiRen);
                wu.insertValue("基本信息_承研_联系人", pt.projectObj.ChengYanDanWeiLianXiRen);
                wu.insertValue("基本信息_委托_联系电话", pt.projectObj.WeiTuoDanWeiLianXiRenDianHua);
                wu.insertValue("基本信息_承研_联系电话", pt.projectObj.ChengYanDanWeiLianXiRenDianHua);
                wu.insertValue("基本信息_委托_通信地址", pt.projectObj.WeiTuoDanWeiTongXinDiZhi);
                wu.insertValue("基本信息_承研_通信地址", pt.projectObj.ChengYanDanWeiTongXinDiZhi);
                wu.insertValue("基本信息_委托_邮政编码", pt.projectObj.WeiTuoDanWeiYouZhengBianMa);
                wu.insertValue("基本信息_承研_邮政编码", pt.projectObj.ChengYanDanWeiYouZhengBianMa);
                wu.insertValue("基本信息_委托_组织机构代码", pt.projectObj.WeiTuoDanWeiZuZhiJiGouDaiMa);
                wu.insertValue("基本信息_承研_组织机构代码", pt.projectObj.ChengYanDanWeiZuZhiJiGouDaiMa);
                wu.insertValue("基本信息_委托_税号", pt.projectObj.WeiTuoDanWeiShuiHao);
                wu.insertValue("基本信息_承研_税号", pt.projectObj.ChengYanDanWeiShuiHao);
                wu.insertValue("基本信息_委托_开户名称", pt.projectObj.WeiTuoDanWeiKaiHuMingCheng);
                wu.insertValue("基本信息_承研_开户名称", pt.projectObj.ChengYanDanWeiKaiHuMingCheng);
                wu.insertValue("基本信息_委托_开户银行", pt.projectObj.WeiTuoDanWeiKaiHuYingHang);
                wu.insertValue("基本信息_承研_开户银行", pt.projectObj.ChengYanDanWeiKaiHuYingHang);
                wu.insertValue("基本信息_委托_银行帐号", pt.projectObj.WeiTuoDanWeiYinHangZhangHao);
                wu.insertValue("基本信息_承研_银行帐号", pt.projectObj.ChengYanDanWeiYinHangZhangHao);
                wu.insertValue("基本信息_委托_财务负责人", pt.projectObj.WeiTuoDanWeiCaiWuFuZeRen);
                wu.insertValue("基本信息_承研_财务负责人", pt.projectObj.ChengYanDanWeiCaiWuFuZeRen);
                wu.insertValue("基本信息_委托_财务联系电话", pt.projectObj.WeiTuoDanWeiCaiWuFuZeRenDianHua);
                wu.insertValue("基本信息_承研_财务联系电话", pt.projectObj.ChengYanDanWeiCaiWuFuZeRenDianHua);
                
                #endregion

                Report(progressDialog, 40, "写入文档文件...", 1000);

                #region 插入文档文件
                wu.insertTxtFile("研究目标", Path.Combine(pt.filesDir, "研究目标.txt"));
                wu.insertFile("主要研究内容_项目分解情况", Path.Combine(pt.filesDir, "项目分解情况.doc"), true);
                wu.insertTxtFile("技术要求及指标_总技术要求", Path.Combine(pt.filesDir, "技术要求.txt"));
                wu.insertTxtFile("经费预算_双方认为需要说明的经费使用事项", Path.Combine(pt.filesDir, "双方认为需要说明的经费使用事项.txt"));
                #endregion

                Report(progressDialog, 60, "写入表格数据...", 1000);
                #region 写入表格数据

                #endregion

                Report(progressDialog, 80, "更新目录...", 1000);

                #region 更新目录

                //try
                //{   
                //    wu.WordDoc.Styles["目录 1"].Font.NameFarEast = "黑体";
                //    wu.WordDoc.Styles["目录 1"].Font.Size = 14;
                //    wu.WordDoc.Styles["目录 1"].Font.Bold = 0;
                //    wu.WordDoc.Styles["目录 1"].Font.Italic = 0;

                //    wu.WordDoc.Styles["目录 2"].Font.NameFarEast = "楷体";
                //    wu.WordDoc.Styles["目录 2"].Font.NameAscii = wu.WordDoc.Styles["目录 1"].Font.NameAscii;
                //    wu.WordDoc.Styles["目录 2"].Font.NameBi = wu.WordDoc.Styles["目录 1"].Font.NameBi;
                //    wu.WordDoc.Styles["目录 2"].Font.NameOther = wu.WordDoc.Styles["目录 1"].Font.NameOther;
                //    wu.WordDoc.Styles["目录 2"].Font.Size = 12;
                //    wu.WordDoc.Styles["目录 2"].Font.Bold = 0;
                //    wu.WordDoc.Styles["目录 2"].Font.Italic = 0;

                //    wu.WordDoc.Styles["目录 3"].Font.NameFarEast = "楷体";
                //    wu.WordDoc.Styles["目录 3"].Font.NameAscii = wu.WordDoc.Styles["目录 1"].Font.NameAscii;
                //    wu.WordDoc.Styles["目录 3"].Font.NameBi = wu.WordDoc.Styles["目录 1"].Font.NameBi;
                //    wu.WordDoc.Styles["目录 3"].Font.NameOther = wu.WordDoc.Styles["目录 1"].Font.NameOther;
                //    wu.WordDoc.Styles["目录 3"].Font.Size = 12;
                //    wu.WordDoc.Styles["目录 3"].Font.Bold = 0;
                //    wu.WordDoc.Styles["目录 3"].Font.Italic = 0;

                //    object missing = System.Reflection.Missing.Value;
                //    Microsoft.Office.Interop.Word.Range myRange = wu.WordDoc.TablesOfContents[1].Range;
                //    wu.WordDoc.TablesOfContents[1].Delete();                    
                //    object useHeadingStyle = true; //使用Head样式
                //    object upperHeadingLevel = 1;  //最大一级
                //    object lowerHeadingLevel = 2;  //最小三级
                //    object useHypeLinks = true;
                //    //TablesOfContents的Add方法添加目录
                //    wu.WordDoc.TablesOfContents.Add(myRange, ref useHeadingStyle,
                //        ref upperHeadingLevel, ref lowerHeadingLevel,
                //        ref missing, ref missing, ref missing, ref missing,
                //        ref missing, ref useHypeLinks, ref missing, ref missing);
                //    wu.WordDoc.TablesOfContents[1].TabLeader = Microsoft.Office.Interop.Word.WdTabLeader.wdTabLeaderDots;
                //}
                //catch (Exception ex) { }

                //wu.WordDoc.ResetFormFields();
                //wu.WordDoc.Fields.Update();
                wu.Document.WordDoc.UpdateFields();
                wu.Document.WordDoc.UpdateListLabels();
                wu.Document.WordDoc.UpdatePageLayout();
                wu.Document.WordDoc.UpdateTableLayout();
                wu.Document.WordDoc.UpdateThumbnail();
                wu.Document.WordDoc.UpdateWordCount();
                #endregion

                Report(progressDialog, 90, "生成文档...", 1000);

                #region 显示文档或生成文档
                //关闭word
                wu.killWinWordProcess();

                //保存word
                string docFile = Path.Combine(pt.dataDir, "合同书.doc");
                wu.saveDocument(docFile);
                Process.Start(docFile);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Report(progressDialog, 95, "", 1000);
        }

        /// <summary>
        /// 显示进度
        /// </summary>
        /// <param name="progressDialog"></param>
        /// <param name="progress"></param>
        /// <param name="txt"></param>
        /// <param name="sleepTime"></param>
        private static void Report(CircleProgressBarDialog progressDialog, int progress, string txt, int sleepTime)
        {
            progressDialog.ReportProgress(progress, 100);
            progressDialog.ReportInfo(txt);
            try
            {
                Thread.Sleep(sleepTime);
            }
            catch (Exception ex) { }
        }
    }
}