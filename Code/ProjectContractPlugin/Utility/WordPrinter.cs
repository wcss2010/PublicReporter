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
                    if (t.GetText().Contains("科目名称"))
                    {
                        //金额
                        t.Rows[2].Cells[1].RemoveAllChildren();
                        t.Rows[2].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money1"]));
                        t.Rows[2].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[3].Cells[1].RemoveAllChildren();
                        t.Rows[3].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money2"]));
                        t.Rows[3].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[4].Cells[1].RemoveAllChildren();
                        t.Rows[4].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money3"]));
                        t.Rows[4].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[5].Cells[1].RemoveAllChildren();
                        t.Rows[5].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money4"]));
                        t.Rows[5].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[6].Cells[1].RemoveAllChildren();
                        t.Rows[6].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money5"]));
                        t.Rows[6].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[7].Cells[1].RemoveAllChildren();
                        t.Rows[7].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money6"]));
                        t.Rows[7].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[8].Cells[1].RemoveAllChildren();
                        t.Rows[8].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money7"]));
                        t.Rows[8].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[9].Cells[1].RemoveAllChildren();
                        t.Rows[9].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money8"]));
                        t.Rows[9].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[10].Cells[1].RemoveAllChildren();
                        t.Rows[10].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money9"]));
                        t.Rows[10].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[11].Cells[1].RemoveAllChildren();
                        t.Rows[11].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money10"]));
                        t.Rows[11].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[12].Cells[1].RemoveAllChildren();
                        t.Rows[12].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money11"]));
                        t.Rows[12].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[13].Cells[1].RemoveAllChildren();
                        t.Rows[13].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money12"]));
                        t.Rows[13].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[14].Cells[1].RemoveAllChildren();
                        t.Rows[14].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Money13"]));
                        t.Rows[14].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        //备注
                        t.Rows[2].Cells[2].RemoveAllChildren();
                        t.Rows[2].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info1"]));
                        t.Rows[2].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[3].Cells[2].RemoveAllChildren();
                        t.Rows[3].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info2"]));
                        t.Rows[3].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[4].Cells[2].RemoveAllChildren();
                        t.Rows[4].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info3"]));
                        t.Rows[4].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[5].Cells[2].RemoveAllChildren();
                        t.Rows[5].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info4"]));
                        t.Rows[5].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[6].Cells[2].RemoveAllChildren();
                        t.Rows[6].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info5"]));
                        t.Rows[6].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[7].Cells[2].RemoveAllChildren();
                        t.Rows[7].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info6"]));
                        t.Rows[7].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[8].Cells[2].RemoveAllChildren();
                        t.Rows[8].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info7"]));
                        t.Rows[8].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[9].Cells[2].RemoveAllChildren();
                        t.Rows[9].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info8"]));
                        t.Rows[9].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[10].Cells[2].RemoveAllChildren();
                        t.Rows[10].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info9"]));
                        t.Rows[10].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[11].Cells[2].RemoveAllChildren();
                        t.Rows[11].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info10"]));
                        t.Rows[11].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[12].Cells[2].RemoveAllChildren();
                        t.Rows[12].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info11"]));
                        t.Rows[12].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[13].Cells[2].RemoveAllChildren();
                        t.Rows[13].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info12"]));
                        t.Rows[13].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[14].Cells[2].RemoveAllChildren();
                        t.Rows[14].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Info13"]));
                        t.Rows[14].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        //年份
                        t.Rows[t.Rows.Count - 2].Cells[0].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 2].Cells[0].AppendChild(wu.getCellContentObj(t, tempDict["YearName1"]));
                        t.Rows[t.Rows.Count - 2].Cells[0].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[t.Rows.Count - 2].Cells[1].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 2].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["YearName2"]));
                        t.Rows[t.Rows.Count - 2].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[t.Rows.Count - 2].Cells[2].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 2].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["YearName3"]));
                        t.Rows[t.Rows.Count - 2].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[t.Rows.Count - 2].Cells[3].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 2].Cells[3].AppendChild(wu.getCellContentObj(t, tempDict["YearName4"]));
                        t.Rows[t.Rows.Count - 2].Cells[3].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[t.Rows.Count - 2].Cells[4].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 2].Cells[4].AppendChild(wu.getCellContentObj(t, tempDict["YearName5"]));
                        t.Rows[t.Rows.Count - 2].Cells[4].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        //年度金额
                        t.Rows[t.Rows.Count - 1].Cells[0].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[0].AppendChild(wu.getCellContentObj(t, tempDict["Year1"]));
                        t.Rows[t.Rows.Count - 1].Cells[0].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[t.Rows.Count - 1].Cells[1].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[1].AppendChild(wu.getCellContentObj(t, tempDict["Year2"]));
                        t.Rows[t.Rows.Count - 1].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[t.Rows.Count - 1].Cells[2].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[2].AppendChild(wu.getCellContentObj(t, tempDict["Year3"]));
                        t.Rows[t.Rows.Count - 1].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[t.Rows.Count - 1].Cells[3].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[3].AppendChild(wu.getCellContentObj(t, tempDict["Year4"]));
                        t.Rows[t.Rows.Count - 1].Cells[3].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        t.Rows[t.Rows.Count - 1].Cells[4].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[4].AppendChild(wu.getCellContentObj(t, tempDict["Year5"]));
                        t.Rows[t.Rows.Count - 1].Cells[4].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;
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
                            t.Rows[rowStart].Cells[0].AppendChild(wu.getCellContentObj(t, (rowStart).ToString()));
                            t.Rows[rowStart].Cells[0].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[1].RemoveAllChildren();
                            t.Rows[rowStart].Cells[1].AppendChild(wu.getCellContentObj(t, data.MingCheng));
                            t.Rows[rowStart].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[2].RemoveAllChildren();
                            t.Rows[rowStart].Cells[2].AppendChild(wu.getCellContentObj(t, data.YaoQiu));
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
                            t.Rows[rowStart].Cells[0].AppendChild(wu.getCellContentObj(t, (rowStart).ToString()));
                            t.Rows[rowStart].Cells[0].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[1].RemoveAllChildren();
                            t.Rows[rowStart].Cells[1].AppendChild(wu.getCellContentObj(t, data.BoFuTiaoJian));
                            t.Rows[rowStart].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[2].RemoveAllChildren();
                            t.Rows[rowStart].Cells[2].AppendChild(wu.getCellContentObj(t, data.YuJiShiJian.ToString("yyyy年MM月")));
                            t.Rows[rowStart].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[3].RemoveAllChildren();
                            t.Rows[rowStart].Cells[3].AppendChild(wu.getCellContentObj(t, data.JingFeiJinQian.ToString()));
                            t.Rows[rowStart].Cells[3].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

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
                            t.Rows[rowStart].Cells[0].AppendChild(wu.getCellContentObj(t, data.JieDian.ToString()));
                            t.Rows[rowStart].Cells[0].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[1].RemoveAllChildren();
                            t.Rows[rowStart].Cells[1].AppendChild(wu.getCellContentObj(t, data.ShiJian.ToString("yyyy年MM月")));
                            t.Rows[rowStart].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[2].RemoveAllChildren();
                            Paragraph p = wu.getCellContentObj(t, "阶段目标：");
                            ((Run)p.ChildNodes[0]).Font.Bold = true;
                            t.Rows[rowStart].Cells[2].AppendChild(p);
                            t.Rows[rowStart].Cells[2].AppendChild(wu.getCellContentObj(t, data.JieDuanMuBiao));
                            p = wu.getCellContentObj(t, "完成内容：");
                            ((Run)p.ChildNodes[0]).Font.Bold = true;
                            t.Rows[rowStart].Cells[2].AppendChild(p);
                            t.Rows[rowStart].Cells[2].AppendChild(wu.getCellContentObj(t, data.WanChengNeiRong));
                            p = wu.getCellContentObj(t, "阶段成果：");
                            ((Run)p.ChildNodes[0]).Font.Bold = true;
                            t.Rows[rowStart].Cells[2].AppendChild(p);
                            t.Rows[rowStart].Cells[2].AppendChild(wu.getCellContentObj(t, data.JieDuanChengGuo));
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
                    wu.Document.WordDocBuilder.Write("(" + index + ") " + data.NianDu + "年度：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.WordDocBuilder.Write(data.NeiRong);
                    wu.Document.WordDocBuilder.Writeln();

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
                    wu.Document.WordDocBuilder.Write(data.ZhiBiaoMingCheng);
                    wu.Document.WordDocBuilder.Writeln();
                    
                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write("(1) 指标要求：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.WordDocBuilder.Write(data.ZhiBiaoYaoQiu);
                    wu.Document.WordDocBuilder.Writeln();

                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write("(2) 考核方式：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.WordDocBuilder.Write(data.KaoHeFangShi);
                    wu.Document.WordDocBuilder.Writeln();

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
                    wu.Document.WordDocBuilder.Write(data.KeTiMingCheng);
                    wu.Document.WordDocBuilder.Writeln();

                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write("（1）研究目标：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.WordDocBuilder.Write(data.KeTiYanJiuMuBiao);
                    wu.Document.WordDocBuilder.Writeln();

                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write("（2）研究内容：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.WordDocBuilder.Write(data.KeTiYanJiuNeiRong);
                    wu.Document.WordDocBuilder.Writeln();

                    wu.Document.WordDocBuilder.Font.Bold = true;
                    wu.Document.WordDocBuilder.Write("（3）参加单位分工：");
                    wu.Document.WordDocBuilder.Font.Bold = false;
                    wu.Document.WordDocBuilder.Write(data.KeTiCanJiaDanWeiFenGong);
                    wu.Document.WordDocBuilder.Writeln();

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
                            t.Rows[rowStart].Cells[0].AppendChild(wu.getCellContentObj(t, (rowStart).ToString()));
                            t.Rows[rowStart].Cells[0].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[1].RemoveAllChildren();
                            t.Rows[rowStart].Cells[1].AppendChild(wu.getCellContentObj(t, data.XingMing));
                            t.Rows[rowStart].Cells[1].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[2].RemoveAllChildren();
                            t.Rows[rowStart].Cells[2].AppendChild(wu.getCellContentObj(t, data.XingBie));
                            t.Rows[rowStart].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[3].RemoveAllChildren();
                            t.Rows[rowStart].Cells[3].AppendChild(wu.getCellContentObj(t, data.ZhiCheng));
                            t.Rows[rowStart].Cells[3].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[4].RemoveAllChildren();
                            t.Rows[rowStart].Cells[4].AppendChild(wu.getCellContentObj(t, data.ZhuanYe));
                            t.Rows[rowStart].Cells[4].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[5].RemoveAllChildren();
                            t.Rows[rowStart].Cells[5].AppendChild(wu.getCellContentObj(t, data.GongZuoDanWei));
                            t.Rows[rowStart].Cells[5].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[6].RemoveAllChildren();
                            t.Rows[rowStart].Cells[6].AppendChild(wu.getCellContentObj(t, data.MeiNianTouRuShiJian + ""));
                            t.Rows[rowStart].Cells[6].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[7].RemoveAllChildren();
                            t.Rows[rowStart].Cells[7].AppendChild(wu.getCellContentObj(t, data.RenWuFenGong));
                            t.Rows[rowStart].Cells[7].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[rowStart].Cells[8].RemoveAllChildren();
                            t.Rows[rowStart].Cells[8].AppendChild(wu.getCellContentObj(t, data.ShenFenZhengHao));
                            t.Rows[rowStart].Cells[8].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            string roleName = subjectDict.ContainsKey(data.KeTiBiaoHao) ? subjectDict[data.KeTiBiaoHao] + data.ZhiWu : "未知";

                            t.Rows[rowStart].Cells[9].RemoveAllChildren();
                            t.Rows[rowStart].Cells[9].AppendChild(wu.getCellContentObj(t, (data.ShiXiangMuFuZeRen == "true"?"项目负责人兼":"") + roleName));
                            t.Rows[rowStart].Cells[9].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            rowStart++;
                        }

                        t.Rows[t.Rows.Count - 1].Cells[t.Rows[t.Rows.Count - 1].Cells.Count - 1].RemoveAllChildren();
                        t.Rows[t.Rows.Count - 1].Cells[t.Rows[t.Rows.Count - 1].Cells.Count - 1].AppendChild(wu.getCellContentObj(t, (totalMonth / 12).ToString()));
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