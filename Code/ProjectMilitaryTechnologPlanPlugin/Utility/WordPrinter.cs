using Aspose.Words;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ProjectMilitaryTechnologPlanPlugin.DB;
using ProjectMilitaryTechnologPlanPlugin.DB.Entitys;
using ProjectMilitaryTechnologPlanPlugin.Editor;
using System.Data;
using PublicReporterLib;

namespace ProjectMilitaryTechnologPlanPlugin.Utility
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
            string fileName = pt.projectObj.BianHao + "-论证报告.docx";
            WordUtility wu = new WordUtility();
            wu.createNewDocument(Path.Combine(Path.Combine(pt.RootDir, "Helper"), "template.doc"));

            try
            {
                Report(progressDialog, 20, "准备数据...", 1000);
                List<RenYuanBiao> workerList = ConnectionManager.Context.table("RenYuanBiao").select("*").getList<RenYuanBiao>(new RenYuanBiao());

                Report(progressDialog, 30, "写入基本信息...", 1000);

                #region 固定文本替换
                wu.insertValue("首页_项目名称", pt.projectObj.XiangMuMingCheng);
                wu.insertValue("首页_责任单位", pt.projectObj.ZeRenDanWei);
                wu.insertValue("首页_填表日期", DateTime.Now.ToString("yyyy年MM月dd日"));

                wu.insertValue("基本信息_项目名称", pt.projectObj.XiangMuMingCheng);
                wu.insertValue("基本信息_牵头人", pt.projectObj.QianTouRen);
                wu.insertValue("基本信息_牵头人性别", pt.projectObj.QianTouRenXingBie);
                wu.insertValue("基本信息_牵头人民族", pt.projectObj.QianTouRenMinZu);
                wu.insertValue("基本信息_牵头人出生年月", pt.projectObj.QianTouRenShengRi.ToString("yyyy年MM月dd日"));
                wu.insertValue("基本信息_部职别", pt.projectObj.BuZhiBie);
                wu.insertValue("基本信息_联合研究单位", pt.projectObj.LianHeYanJiuDanWei);

                StringBuilder wantResult = new StringBuilder();
                if (pt.projectObj.YuQiChengGuo != null && pt.projectObj.YuQiChengGuo.Contains(UIControlConfig.rowFlag))
                {
                    string[] tttt = pt.projectObj.YuQiChengGuo.Split(new string[] { UIControlConfig.rowFlag }, StringSplitOptions.None);
                    if (tttt != null)
                    {
                        foreach (string ss in tttt)
                        {
                            string[] vvvv = ss.Split(new string[] { UIControlConfig.cellFlag }, StringSplitOptions.None);
                            if (vvvv != null && vvvv.Length >= 2)
                            {
                                if (string.IsNullOrEmpty(vvvv[0])) { continue; }

                                wantResult.Append(vvvv[0].Insert(vvvv[0].IndexOf("("), vvvv[1]).Replace("(", string.Empty).Replace(")", string.Empty)).AppendLine();
                            }
                        }
                    }
                }
                wu.insertValue("基本信息_预期成果", wantResult.ToString());
                wu.insertValue("基本信息_审请经费", pt.projectObj.ShenQingJingFei + "");
                wu.insertValue("基本信息_计划完成时间", pt.projectObj.JiHuaWanChengShiJian.ToString("yyyy年MM月dd日"));
                #endregion
                
                Report(progressDialog, 40, "写入文档文件...", 1000);

                #region 插入文档文件
                wu.insertFile("项目设计论证_研究状况及选题价值", Path.Combine(pt.filesDir, "研究状况及选题价值.doc"), true);
                wu.insertFile("项目设计论证_总体框架和预期目标", Path.Combine(pt.filesDir, "总体框架和预期目标.doc"), true);
                wu.insertFile("项目设计论证_研究思路和研究方法", Path.Combine(pt.filesDir, "研究思路和研究方法.doc"), true);
                wu.insertFile("项目设计论证_重点难点和创新之处", Path.Combine(pt.filesDir, "重点难点和创新之处.doc"), true);
                wu.insertFile("项目设计论证_研究进度和任务分工", Path.Combine(pt.filesDir, "研究进度和任务分工.doc"), true);
                #endregion

                Report(progressDialog, 60, "写入表格数据...", 1000);
                #region 写入表格数据

                ////查找所有表格
                NodeCollection ncc = wu.Document.WordDoc.GetChildNodes(NodeType.Table, true);

                #region 插入经费预算数据
                List<YuSuanBiao> ysList = ConnectionManager.Context.table("YuSuanBiao").select("*").getList<YuSuanBiao>(new YuSuanBiao());

                //取数放于字典中
                Dictionary<string, string> tempDict = new Dictionary<string, string>();
                foreach (YuSuanBiao ysb in ysList)
                {
                    tempDict[ysb.MingCheng] = ysb.ShuJu;
                }

                //生成年份名称
                int yearStart = pt.projectObj.JiHuaWanChengShiJian.Year - 2;
                for (int kk = 0; kk < 3; kk++)
                {
                    tempDict["Year" + (kk + 1) + "Name"] = (yearStart + kk).ToString();
                }

                //总费用
                decimal total = 0;
                //计算总费用
                for (int k = 1; k <= 11; k++)
                {
                    if (tempDict.ContainsKey("Money" + k))
                    {
                        string cnt = tempDict["Money" + k];
                        try
                        {
                            total += decimal.Parse(cnt);
                        }
                        catch (Exception ex) { }
                    }
                }
                tempDict["Total"] = total + "";

                foreach (KeyValuePair<string, string> kvp in tempDict)
                {
                    wu.insertValue("研究经费_" + kvp.Key, kvp.Value);
                }
                #endregion

                #region 写人员表格
                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("专业职务") && t.GetText().Contains("研究专长") && t.GetText().Contains("工作单位"))
                    {
                        //创建行
                        for (int k = 0; k < workerList.Count; k++)
                        {
                            t.Rows.Insert(4, (Aspose.Words.Tables.Row)t.Rows[4].Clone(true));
                        }

                        //写数据
                        int rowStart = 5;
                        foreach (RenYuanBiao worker in workerList)
                        {
                            t.Rows[rowStart].Cells[0].RemoveAllChildren();
                            wu.Document.fillCell(true, t.Rows[rowStart].Cells[1], wu.Document.newParagraph(wu.Document.WordDoc, worker.XingMing));
                            wu.Document.fillCell(true, t.Rows[rowStart].Cells[2], wu.Document.newParagraph(wu.Document.WordDoc, worker.XingBie));
                            wu.Document.fillCell(true, t.Rows[rowStart].Cells[3], wu.Document.newParagraph(wu.Document.WordDoc, worker.ShengRi.ToString("yyyy年MM月dd日")));
                            wu.Document.fillCell(true, t.Rows[rowStart].Cells[4], wu.Document.newParagraph(wu.Document.WordDoc, worker.ZhuanYeZhiWu));
                            wu.Document.fillCell(true, t.Rows[rowStart].Cells[5], wu.Document.newParagraph(wu.Document.WordDoc, worker.YanJiuZhuanChang));
                            wu.Document.fillCell(true, t.Rows[rowStart].Cells[6], wu.Document.newParagraph(wu.Document.WordDoc, worker.GongZuoDanWei));
                            rowStart++;
                        }

                        //合并第一列
                        wu.Document.mergeCells(t.Rows[4].Cells[0], t.Rows[4 + workerList.Count].Cells[0], t);
                        break;
                    }
                }
                #endregion

                #endregion

                Report(progressDialog, 90, "生成文档...", 1000);

                #region 显示文档或生成文档
                //关闭word
                wu.killWinWordProcess();

                //保存word
                string docFile = Path.Combine(pt.dataDir, "论证报告.doc");
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