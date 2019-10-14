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
using System.Data;

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
            PluginRoot pt = PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>();
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

                wu.insertValue("共同条款_合同数字1", ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TogetherRuleEditor.TRCode1Key + "'").select("ShuJu").getValue<string>("0"));
                wu.insertValue("共同条款_合同数字2", ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TogetherRuleEditor.TRCode2Key + "'").select("ShuJu").getValue<string>("0"));
                wu.insertValue("共同条款_合同数字3", ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TogetherRuleEditor.TRCode3Key + "'").select("ShuJu").getValue<string>("0"));
                wu.insertValue("共同条款_合同数字4", ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TogetherRuleEditor.TRCode4Key + "'").select("ShuJu").getValue<string>("0"));
                #endregion

                Report(progressDialog, 40, "写入文档文件...", 1000);

                #region 插入文档文件
                wu.insertTxtFile("研究目标", Path.Combine(pt.filesDir, "研究目标.txt"));
                wu.insertFile("主要研究内容_项目分解情况", Path.Combine(pt.filesDir, "项目分解情况.doc"), true);
                wu.insertTxtFile("技术要求及指标_总技术要求", Path.Combine(pt.filesDir, "技术要求.txt"));
                wu.insertTxtFile("经费预算_双方认为需要说明的经费使用事项", Path.Combine(pt.filesDir, "双方认为需要说明的经费使用事项.txt"));
                wu.insertFile("附件2", Path.Combine(pt.filesDir, "附件2.doc"), true);
                #endregion

                Report(progressDialog, 60, "写入表格数据...", 1000);
                #region 写入表格数据

                //查找所有表格
                NodeCollection ncc = wu.Document.WordDoc.GetChildNodes(NodeType.Table, true);

                #region 插入经费预算数据
                List<YuSuanBiao> ysList = ConnectionManager.Context.table("YuSuanBiao").orderBy("ZhuangTai,ModifyTime").select("*").getList<YuSuanBiao>(new YuSuanBiao());

                //取数放于字典中
                Dictionary<string, string> tempDict = new Dictionary<string, string>();
                foreach (YuSuanBiao ysb in ysList)
                {
                    tempDict[ysb.MingCheng] = ysb.ShuJu;
                }

                //生成年份名称
                int yearStart = pt.projectObj.HeTongKaiShiShiJian.Year;
                for (int kk = 0; kk < 5; kk++)
                {
                    tempDict["YearName" + (kk + 1)] = (yearStart + kk).ToString();
                }

                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("科目名称") && t.GetText().Contains("年度经费预算"))
                    {
                        //金额
                        t.Rows[2].Cells[1].RemoveAllChildren();
                        t.Rows[2].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money1"]));
                        ((Paragraph)t.Rows[2].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[3].Cells[1].RemoveAllChildren();
                        t.Rows[3].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money2"]));
                        ((Paragraph)t.Rows[3].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[4].Cells[1].RemoveAllChildren();
                        t.Rows[4].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money3"]));
                        ((Paragraph)t.Rows[4].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[5].Cells[1].RemoveAllChildren();
                        t.Rows[5].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money3_1"]));
                        ((Paragraph)t.Rows[5].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[6].Cells[1].RemoveAllChildren();
                        t.Rows[6].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money3_2"]));
                        ((Paragraph)t.Rows[6].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[7].Cells[1].RemoveAllChildren();
                        t.Rows[7].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money3_3"]));
                        ((Paragraph)t.Rows[7].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[8].Cells[1].RemoveAllChildren();
                        t.Rows[8].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money4"]));
                        ((Paragraph)t.Rows[8].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[9].Cells[1].RemoveAllChildren();
                        t.Rows[9].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money5"]));
                        ((Paragraph)t.Rows[9].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[10].Cells[1].RemoveAllChildren();
                        t.Rows[10].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money5_1"]));
                        ((Paragraph)t.Rows[10].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[11].Cells[1].RemoveAllChildren();
                        t.Rows[11].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money5_2"]));
                        ((Paragraph)t.Rows[11].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[12].Cells[1].RemoveAllChildren();
                        t.Rows[12].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money6"]));
                        ((Paragraph)t.Rows[12].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[13].Cells[1].RemoveAllChildren();
                        t.Rows[13].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money7"]));
                        ((Paragraph)t.Rows[13].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[14].Cells[1].RemoveAllChildren();
                        t.Rows[14].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money8"]));
                        ((Paragraph)t.Rows[14].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[15].Cells[1].RemoveAllChildren();
                        t.Rows[15].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money9"]));
                        ((Paragraph)t.Rows[15].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[16].Cells[1].RemoveAllChildren();
                        t.Rows[16].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money10"]));
                        ((Paragraph)t.Rows[16].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[17].Cells[1].RemoveAllChildren();
                        t.Rows[17].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money11"]));
                        ((Paragraph)t.Rows[17].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[18].Cells[1].RemoveAllChildren();
                        t.Rows[18].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money12"]));
                        ((Paragraph)t.Rows[18].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[19].Cells[1].RemoveAllChildren();
                        t.Rows[19].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Money13"]));
                        ((Paragraph)t.Rows[19].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        //备注
                        t.Rows[2].Cells[2].RemoveAllChildren();
                        t.Rows[2].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info1"]));
                        t.Rows[2].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[3].Cells[2].RemoveAllChildren();
                        t.Rows[3].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info2"]));
                        t.Rows[3].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[4].Cells[2].RemoveAllChildren();
                        t.Rows[4].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info3"]));
                        t.Rows[4].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[5].Cells[2].RemoveAllChildren();
                        t.Rows[5].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info3_1"]));
                        t.Rows[5].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[6].Cells[2].RemoveAllChildren();
                        t.Rows[6].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info3_2"]));
                        t.Rows[6].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[7].Cells[2].RemoveAllChildren();
                        t.Rows[7].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info3_3"]));
                        t.Rows[7].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[8].Cells[2].RemoveAllChildren();
                        t.Rows[8].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info4"]));
                        t.Rows[8].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[9].Cells[2].RemoveAllChildren();
                        t.Rows[9].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info5"]));
                        t.Rows[9].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[10].Cells[2].RemoveAllChildren();
                        t.Rows[10].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info5_1"]));
                        t.Rows[10].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[11].Cells[2].RemoveAllChildren();
                        t.Rows[11].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info5_2"]));
                        t.Rows[11].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[12].Cells[2].RemoveAllChildren();
                        t.Rows[12].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info6"]));
                        t.Rows[12].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[13].Cells[2].RemoveAllChildren();
                        t.Rows[13].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info7"]));
                        t.Rows[13].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[14].Cells[2].RemoveAllChildren();
                        t.Rows[14].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info8"]));
                        t.Rows[14].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[15].Cells[2].RemoveAllChildren();
                        t.Rows[15].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info9"]));
                        t.Rows[15].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[16].Cells[2].RemoveAllChildren();
                        t.Rows[16].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info10"]));
                        t.Rows[16].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[17].Cells[2].RemoveAllChildren();
                        t.Rows[17].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info11"]));
                        t.Rows[17].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[18].Cells[2].RemoveAllChildren();
                        t.Rows[18].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info12"]));
                        t.Rows[18].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[19].Cells[2].RemoveAllChildren();
                        t.Rows[19].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Info13"]));
                        t.Rows[19].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        //年份
                        t.Rows[t.Rows.Count - 2].Cells[0].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 2].Cells[0].AppendChild(wu.Document.newParagraph(t.Document, tempDict["YearName1"] + "年度"));
                        ((Paragraph)t.Rows[t.Rows.Count - 2].Cells[0].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[t.Rows.Count - 2].Cells[1].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 2].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["YearName2"] + "年度"));
                        ((Paragraph)t.Rows[t.Rows.Count - 2].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[t.Rows.Count - 2].Cells[2].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 2].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["YearName3"] + "年度"));
                        ((Paragraph)t.Rows[t.Rows.Count - 2].Cells[2].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[t.Rows.Count - 2].Cells[3].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 2].Cells[3].AppendChild(wu.Document.newParagraph(t.Document, tempDict["YearName4"] + "年度"));
                        ((Paragraph)t.Rows[t.Rows.Count - 2].Cells[3].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[t.Rows.Count - 2].Cells[4].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 2].Cells[4].AppendChild(wu.Document.newParagraph(t.Document, tempDict["YearName5"] + "年度"));
                        ((Paragraph)t.Rows[t.Rows.Count - 2].Cells[4].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        //年度金额
                        t.Rows[t.Rows.Count - 1].Cells[0].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[0].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Year1"]));
                        ((Paragraph)t.Rows[t.Rows.Count - 1].Cells[0].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[t.Rows.Count - 1].Cells[1].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Year2"]));
                        ((Paragraph)t.Rows[t.Rows.Count - 1].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[t.Rows.Count - 1].Cells[2].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Year3"]));
                        ((Paragraph)t.Rows[t.Rows.Count - 1].Cells[2].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[t.Rows.Count - 1].Cells[3].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[3].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Year4"]));
                        ((Paragraph)t.Rows[t.Rows.Count - 1].Cells[3].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                        t.Rows[t.Rows.Count - 1].Cells[4].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[4].AppendChild(wu.Document.newParagraph(t.Document, tempDict["Year5"]));
                        ((Paragraph)t.Rows[t.Rows.Count - 1].Cells[4].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                        break;
                    }
                }
                #endregion

                #region 插入提交要求数据
                //查询数据
                List<TiJiaoYaoQiuBiao> tjyqList = ConnectionManager.Context.table("TiJiaoYaoQiuBiao").orderBy("ZhuangTai,ModifyTime").select("*").getList<TiJiaoYaoQiuBiao>(new TiJiaoYaoQiuBiao());
                //填充数据
                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("序号") && t.GetText().Contains("名称") && t.GetText().Contains("要求"))
                    {
                        //创建行
                        for (int k = 0; k < tjyqList.Count - 1; k++)
                        {
                            t.Rows.Add((Aspose.Words.Tables.Row)t.Rows[t.Rows.Count - 1].Clone(true));
                        }

                        int rowStart = 1;
                        foreach (TiJiaoYaoQiuBiao data in tjyqList)
                        {
                            t.Rows[rowStart].Cells[0].RemoveAllChildren();
                            t.Rows[rowStart].Cells[0].AppendChild(wu.Document.newParagraph(t.Document, (rowStart).ToString()));
                            ((Paragraph)t.Rows[rowStart].Cells[0].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[rowStart].Cells[1].RemoveAllChildren();
                            t.Rows[rowStart].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, data.MingCheng));
                            t.Rows[rowStart].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[2].RemoveAllChildren();
                            wu.Document.addRangeToNodeCollection(t.Rows[rowStart].Cells[2].ChildNodes, wu.Document.getParagraphListWithNewLine(t.Document, data.YaoQiu));
                            t.Rows[rowStart].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            rowStart++;
                        }
                    }
                }
                #endregion

                #region 插入经费拨付约定数据
                //查询数据
                List<BoFuBiao> bfydList = ConnectionManager.Context.table("BoFuBiao").orderBy("ZhuangTai,ModifyTime").select("*").getList<BoFuBiao>(new BoFuBiao());
                //填充数据
                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("拨付条件") && t.GetText().Contains("预计时间") && t.GetText().Contains("经费金额"))
                    {
                        //创建行
                        for (int k = 0; k < bfydList.Count - 1; k++)
                        {
                            t.Rows.Add((Aspose.Words.Tables.Row)t.Rows[t.Rows.Count - 1].Clone(true));
                        }

                        int rowStart = 1;
                        foreach (BoFuBiao data in bfydList)
                        {
                            t.Rows[rowStart].Cells[0].RemoveAllChildren();
                            t.Rows[rowStart].Cells[0].AppendChild(wu.Document.newParagraph(t.Document, (rowStart).ToString()));
                            ((Paragraph)t.Rows[rowStart].Cells[0].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[rowStart].Cells[1].RemoveAllChildren();
                            wu.Document.addRangeToNodeCollection(t.Rows[rowStart].Cells[1].ChildNodes, wu.Document.getParagraphListWithNewLine(t.Document, data.BoFuTiaoJian));
                            t.Rows[rowStart].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[2].RemoveAllChildren();
                            t.Rows[rowStart].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, data.YuJiShiJian.ToString("yyyy年MM月")));
                            t.Rows[rowStart].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[3].RemoveAllChildren();
                            t.Rows[rowStart].Cells[3].AppendChild(wu.Document.newParagraph(t.Document, data.JingFeiJinQian.ToString()));
                            ((Paragraph)t.Rows[rowStart].Cells[3].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[rowStart].Cells[4].RemoveAllChildren();
                            wu.Document.addRangeToNodeCollection(t.Rows[rowStart].Cells[4].ChildNodes, wu.Document.getParagraphListWithNewLine(t.Document, data.BeiZhu));
                            t.Rows[rowStart].Cells[4].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            rowStart++;
                        }
                    }
                }
                #endregion

                #region 插入研究进度安排数据
                //查询数据
                List<JinDuBiao> jdList = ConnectionManager.Context.table("JinDuBiao").orderBy("ZhuangTai,ModifyTime").select("*").getList<JinDuBiao>(new JinDuBiao());
                //填充数据
                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("节点") && t.GetText().Contains("时间") && t.GetText().Contains("进度要求"))
                    {
                        //创建行
                        for (int k = 0; k < jdList.Count - 1; k++)
                        {
                            t.Rows.Add((Aspose.Words.Tables.Row)t.Rows[t.Rows.Count - 1].Clone(true));
                        }

                        int rowStart = 1;
                        foreach (JinDuBiao data in jdList)
                        {
                            t.Rows[rowStart].Cells[0].RemoveAllChildren();
                            t.Rows[rowStart].Cells[0].AppendChild(wu.Document.newParagraph(t.Document, rowStart.ToString()));
                            ((Paragraph)t.Rows[rowStart].Cells[0].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[rowStart].Cells[1].RemoveAllChildren();
                            t.Rows[rowStart].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, data.ShiJian.ToString("yyyy年MM月")));
                            t.Rows[rowStart].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[2].RemoveAllChildren();
                            Paragraph p = wu.Document.newParagraph(t.Document, "阶段目标与研究内容：");
                            ((Run)p.ChildNodes[0]).Font.Bold = true;
                            t.Rows[rowStart].Cells[2].AppendChild(p);
                            wu.Document.addRangeToNodeCollection(t.Rows[rowStart].Cells[2].ChildNodes, wu.Document.getParagraphListWithNewLine(t.Document, data.JieDuanMuBiao));
                            p = wu.Document.newParagraph(t.Document, "阶段成果、考核指标及考核方式：");
                            ((Run)p.ChildNodes[0]).Font.Bold = true;
                            t.Rows[rowStart].Cells[2].AppendChild(p);
                            wu.Document.addRangeToNodeCollection(t.Rows[rowStart].Cells[2].ChildNodes, wu.Document.getParagraphListWithNewLine(t.Document, data.JieDuanChengGuo));
                            t.Rows[rowStart].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            rowStart++;
                        }
                    }
                }
                #endregion

                #region 插入技术要求数据
                wu.Document.WordDocBuilder.MoveToBookmark("技术要求及指标_年度技术要求");
                //查询数据
                List<JiShuBiao> jsList = ConnectionManager.Context.table("JiShuBiao").orderBy("ZhuangTai,ModifyTime").select("*").getList<JiShuBiao>(new JiShuBiao());

                int index = 1;
                foreach (JiShuBiao data in jsList)
                {
                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write((index == 1 ? "" : " ") + "(" + index + ") " + data.NianDu + "年度：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.writeWithNewLine(data.NeiRong, index == jsList.Count ? false : true);

                    index++;
                }
                #endregion

                #region 插入考核方式数据
                wu.Document.WordDocBuilder.MoveToBookmark("技术要求及指标_主要指标名称及要求与考核方式");
                List<ZhiBiaoBiao> zbbList = ConnectionManager.Context.table("ZhiBiaoBiao").orderBy("ZhuangTai,ModifyTime").select("*").getList<ZhiBiaoBiao>(new ZhiBiaoBiao());
                index = 1;
                foreach (ZhiBiaoBiao data in zbbList)
                {
                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write(index + ".指标名称：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.writeWithNewLine(data.ZhiBiaoMingCheng);

                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write("(1) 指标要求：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.writeWithNewLine(data.ZhiBiaoYaoQiu);

                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write("(2) 考核方式：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.writeWithNewLine(data.KaoHeFangShi, index == zbbList.Count ? false : true);

                    index++;
                }
                #endregion

                //课题关系表
                Dictionary<string, string> subjectDict = new Dictionary<string, string>();

                #region 插入课题情况数据
                wu.Document.WordDocBuilder.MoveToBookmark("主要研究内容_各课题情况_摘要");
                List<KeTiBiao> ktList = ConnectionManager.Context.table("KeTiBiao").orderBy("ZhuangTai,ModifyTime").select("*").getList<KeTiBiao>(new KeTiBiao());

                index = 1;
                foreach (KeTiBiao data in ktList)
                {
                    string subjectRealName = "课题" + index;
                    subjectDict[data.BianHao] = subjectRealName;

                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write(subjectRealName + "：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.writeWithNewLine(data.KeTiMingCheng);

                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write("（1）研究目标：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.writeWithNewLine(data.KeTiYanJiuMuBiao);

                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Writeln("（2）研究内容：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.writeWithNewLine(data.KeTiYanJiuNeiRong);

                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Writeln("（3）参加单位分工：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.writeWithNewLine(data.KeTiCanJiaDanWeiFenGong, index == ktList.Count ? false : true);

                    index++;
                }
                #endregion

                #region 插入人员数据
                //查询数据
                List<RenYuanBiao> rylist = ConnectionManager.Context.table("RenYuanBiao").orderBy("ZhuangTai,ModifyTime").select("*").getList<RenYuanBiao>(new RenYuanBiao());
                //填充数据
                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("任务分工") && t.GetText().Contains("身份证号码") && t.GetText().Contains("项目中职务"))
                    {
                        //创建行
                        for (int k = 0; k < rylist.Count - 1; k++)
                        {
                            t.Rows.Insert(1, (Aspose.Words.Tables.Row)t.Rows[t.Rows.Count - 2].Clone(true));
                        }

                        int totalMonth = 0;
                        int rowStart = 1;
                        foreach (RenYuanBiao data in rylist)
                        {
                            totalMonth += data.MeiNianTouRuShiJian;

                            t.Rows[rowStart].Cells[0].RemoveAllChildren();
                            t.Rows[rowStart].Cells[0].AppendChild(wu.Document.newParagraph(t.Document, (rowStart).ToString()));
                            ((Paragraph)t.Rows[rowStart].Cells[0].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[rowStart].Cells[1].RemoveAllChildren();
                            t.Rows[rowStart].Cells[1].AppendChild(wu.Document.newParagraph(t.Document, data.XingMing));
                            t.Rows[rowStart].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[2].RemoveAllChildren();
                            t.Rows[rowStart].Cells[2].AppendChild(wu.Document.newParagraph(t.Document, data.XingBie));
                            t.Rows[rowStart].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[3].RemoveAllChildren();
                            t.Rows[rowStart].Cells[3].AppendChild(wu.Document.newParagraph(t.Document, data.ZhiCheng));
                            t.Rows[rowStart].Cells[3].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[4].RemoveAllChildren();
                            t.Rows[rowStart].Cells[4].AppendChild(wu.Document.newParagraph(t.Document, data.ZhuanYe));
                            t.Rows[rowStart].Cells[4].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[5].RemoveAllChildren();
                            t.Rows[rowStart].Cells[5].AppendChild(wu.Document.newParagraph(t.Document, data.GongZuoDanWei));
                            t.Rows[rowStart].Cells[5].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[6].RemoveAllChildren();
                            t.Rows[rowStart].Cells[6].AppendChild(wu.Document.newParagraph(t.Document, data.MeiNianTouRuShiJian + ""));
                            ((Paragraph)t.Rows[rowStart].Cells[6].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[rowStart].Cells[7].RemoveAllChildren();
                            t.Rows[rowStart].Cells[7].AppendChild(wu.Document.newParagraph(t.Document, data.RenWuFenGong));
                            t.Rows[rowStart].Cells[7].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[8].RemoveAllChildren();
                            t.Rows[rowStart].Cells[8].AppendChild(wu.Document.newParagraph(t.Document, data.ShenFenZhengHao));
                            t.Rows[rowStart].Cells[8].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            string roleName = "未知";

                            switch (data.ShiXiangMuFuZeRen)
                            {
                                case "rbIsOnlyProject":
                                    roleName = "项目负责人";
                                    break;
                                case "rbIsProjectAndSubject":
                                    roleName = "项目负责人兼" + (subjectDict.ContainsKey(data.KeTiBiaoHao) ? subjectDict[data.KeTiBiaoHao] + data.ZhiWu : "未知");
                                    break;
                                case "rbIsOnlySubject":
                                    roleName = subjectDict.ContainsKey(data.KeTiBiaoHao) ? subjectDict[data.KeTiBiaoHao] + data.ZhiWu : "未知";
                                    break;
                            }

                            t.Rows[rowStart].Cells[9].RemoveAllChildren();
                            t.Rows[rowStart].Cells[9].AppendChild(wu.Document.newParagraph(t.Document, roleName));
                            t.Rows[rowStart].Cells[9].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            rowStart++;
                        }

                        t.Rows[t.Rows.Count - 1].Cells[t.Rows[t.Rows.Count - 1].Cells.Count - 1].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[t.Rows[t.Rows.Count - 1].Cells.Count - 1].AppendChild(wu.Document.newParagraph(t.Document, ((float)totalMonth / (float)12).ToString("0.00")));
                        ((Paragraph)t.Rows[t.Rows.Count - 1].Cells[t.Rows[t.Rows.Count - 1].Cells.Count - 1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                    }
                }
                #endregion

                #region 插入项目分解说明数据

                List<RenWuBiao> rwlist = ConnectionManager.Context.table("RenWuBiao").select("*").getList<RenWuBiao>(new RenWuBiao());
                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("课题编号") && t.GetText().Contains("课题名称") && t.GetText().Contains("所有参研单位"))
                    {
                        Dictionary<string, List<RenWuBiao>> dict = new Dictionary<string, List<RenWuBiao>>();
                        foreach (RenWuBiao rwb in rwlist)
                        {
                            if (dict.ContainsKey(rwb.KeTiBianHao))
                            {
                                dict[rwb.KeTiBianHao].Add(rwb);
                            }
                            else
                            {
                                dict[rwb.KeTiBianHao] = new List<RenWuBiao>();
                                dict[rwb.KeTiBianHao].Add(rwb);
                            }
                        }

                        //插入行
                        Aspose.Words.Tables.Row r = t.Rows[t.Rows.Count - 1];
                        for (int kk = 0; kk < ktList.Count; kk++)
                        {
                            t.Rows.Add(r.Clone(true));
                        }

                        int rowIndex = 1;
                        foreach (KeTiBiao ktb in ktList)
                        {
                            t.Rows[rowIndex].Cells[0].RemoveAllChildren();
                            t.Rows[rowIndex].Cells[0].AppendChild(wu.Document.newParagraph(t.Document, ktb.KeTiMingCheng));
                            ((Paragraph)t.Rows[rowIndex].Cells[0].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;


                            rowIndex++;
                        }
                    }
                }
                #endregion

                #region 插入课题经费年度分配数据

                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("20XX年度") && t.GetText().Contains("年度") && t.GetText().Contains("课题"))
                    {

                    }
                }
                #endregion

                #region 插入课题经费预算

                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("课题XX") && t.GetText().Contains("课题") && t.GetText().Contains("科目名称"))
                    {

                    }
                }
                #endregion

                #region 插入单位经费年度分配

                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("20XX年度") && t.GetText().Contains("年度") && t.GetText().Contains("单位"))
                    {

                    }
                }
                #endregion

                #region 插入联系方式

                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("各课题联系方式") && t.GetText().Contains("职务职称") && t.GetText().Contains("出生年月"))
                    {

                    }
                }
                #endregion

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