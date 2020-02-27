using Aspose.Words;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ProjectStrategicLeadershipPlugin.DB;
using ProjectStrategicLeadershipPlugin.DB.Entitys;
using System.Data;
using PublicReporterLib;
using AbstractEditorPlugin.Utility;
using ProjectStrategicLeadershipPlugin.Forms;

namespace ProjectStrategicLeadershipPlugin
{
    public class WordPrinter
    {
        /// <summary>
        /// Doc输出文件名
        /// </summary>
        public static string outputDocFileName = "战略先导计划.doc";

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

            AbstractEditorPlugin.AbstractPluginRoot.report(progressDialog, 10, "准备Word...", 1000);

            Projects projObj = ((Projects)pt.projectObj);

            //创建word文档
            string fileName = projObj.ID + "-" + outputDocFileName;
            WordDocument wd = new WordDocument(Path.Combine(Path.Combine(pt.RootDir, "Helper"), "template.doc"));

            try
            {
                #region 查找需要生成的节点的样式
                Aspose.Words.Lists.List flag22_numberList = null;
                ParagraphFormat flag22_paragraphFormat = null;
                Aspose.Words.Lists.List flag33_numberList = null;
                ParagraphFormat flag33_paragraphFormat = null;
                NodeCollection nodes = wd.WordDoc.GetChildNodes(NodeType.Paragraph, true);
                foreach (Node node in nodes)
                {
                    if (node.Range.Text.Contains("研究内容二级标题模板"))
                    {
                        if (flag22_numberList == null)
                        {
                            flag22_numberList = ((Paragraph)node).ListFormat.List;
                            flag22_paragraphFormat = ((Paragraph)node).ParagraphFormat;
                        }

                        node.Remove();
                    }
                    else if (node.Range.Text.Contains("研究内容三级标题模板"))
                    {
                        if (flag33_numberList == null)
                        {
                            flag33_numberList = ((Paragraph)node).ListFormat.List;
                            flag33_paragraphFormat = ((Paragraph)node).ParagraphFormat;
                        }

                        node.Remove();
                    }
                }
                #endregion

                AbstractEditorPlugin.AbstractPluginRoot.report(progressDialog, 20, "准备数据...", 1000);
                #region 准备数据
                List<Subjects> subjectList = ConnectionManager.Context.table("Subjects").select("*").getList<Subjects>(new Subjects());
                List<ProjectStep> projectstepList = ConnectionManager.Context.table("ProjectStep").select("*").getList<ProjectStep>(new ProjectStep());
                #endregion

                AbstractEditorPlugin.AbstractPluginRoot.report(progressDialog, 30, "写入基本信息...", 1000);
                #region 写基本信息
                writeStringToBookmark(wd, "基本信息_密级", projObj.ProjectSecretLevel);
                writeStringToBookmark(wd, "基本信息_申报主题", projObj.ProjectTopic);
                writeStringToBookmark(wd, "基本信息_申报方向", projObj.ProjectDirection);
                writeStringToBookmark(wd, "基本信息_项目名称", projObj.ProjectName);
                writeStringToBookmark(wd, "基本信息_申报单位名称", projObj.UnitName);
                writeStringToBookmark(wd, "基本信息_申报单位常用名称", projObj.UnitRealName);
                writeStringToBookmark(wd, "基本信息_项目负责人", projObj.ProjectMasterName);
                writeStringToBookmark(wd, "基本信息_研究周期", projObj.TotalTime + "年");
                writeStringToBookmark(wd, "基本信息_研究经费", projObj.TotalMoney + "万");
                writeStringToBookmark(wd, "基本信息_联系人", projObj.UnitContact);
                writeStringToBookmark(wd, "基本信息_联系电话", projObj.UnitContactPhone);
                writeStringToBookmark(wd, "基本信息_单位所在省市", projObj.UnitAddress != null ? projObj.UnitAddress.Replace(PublicReporterLib.JsonConfigObject.cellFlag, string.Empty) : string.Empty);
                writeStringToBookmark(wd, "基本信息_所属大单位", projObj.UnitType2);
                writeStringToBookmark(wd, "基本信息_申报日期", projObj.RequestTime.ToString("yyyy年MM月dd日"));

                writeStringToBookmark(wd, "研究内容_研究内容数量", subjectList.Count + "");
                writeStringToBookmark(wd, "研究周期与进度安排_周期", projObj.TotalTime + "");
                writeStringToBookmark(wd, "研究周期与进度安排_经费", projObj.TotalMoney + "");
                writeStringToBookmark(wd, "研究周期与进度安排_阶段数", projectstepList.Count + "");
                #endregion

                AbstractEditorPlugin.AbstractPluginRoot.report(progressDialog, 40, "写入文档文件...", 1000);
                #region 写文档文件
                writeFileToBookmark(wd, "项目摘要", Path.Combine(pt.filesDir, PluginRoot.tnode_1_Name) + ".txt", true);
                writeFileToBookmark(wd, "概述_需求分析", Path.Combine(pt.filesDir, PluginRoot.tnode_2_0_Name) + ".doc", true);
                writeFileToBookmark(wd, "概述_研究现状", Path.Combine(pt.filesDir, PluginRoot.tnode_2_1_Name) + ".doc", true);
                writeFileToBookmark(wd, "研究目标", Path.Combine(pt.filesDir, PluginRoot.tnode_3_Name) + ".doc", true);
                writeFileToBookmark(wd, "研究内容_之间关系", Path.Combine(pt.filesDir, PluginRoot.tnode_4_1_Name) + ".doc", true);
                writeFileToBookmark(wd, "研究成果_研究成果及考核指标", Path.Combine(pt.filesDir, PluginRoot.tnode_5_0_Name) + ".doc", true);
                writeFileToBookmark(wd, "研究成果_成果服务方式", Path.Combine(pt.filesDir, PluginRoot.tnode_5_1_Name) + ".doc", true);
                writeFileToBookmark(wd, "研究基础与保障条件", Path.Combine(pt.filesDir, PluginRoot.tnode_7_Name) + ".doc", true);
                writeFileToBookmark(wd, "项目负责人和研究团队_项目负责人", Path.Combine(pt.filesDir, PluginRoot.tnode_8_0_Name) + ".doc", true);
                writeFileToBookmark(wd, "附件文件1", Path.Combine(pt.filesDir, PluginRoot.tnode_10_Name) + ".doc", true);
                #endregion

                AbstractEditorPlugin.AbstractPluginRoot.report(progressDialog, 60, "写入表格列表数据...", 1000);
                #region 写表格列表数据

                //查找所有表格
                NodeCollection ncc = wd.WordDoc.GetChildNodes(NodeType.Table, true);

                //课题附件头
                string subjectFileHeadString = ProjectStrategicLeadershipPlugin.Editor.SubjectDetailEditor.SubjectFileFlag;

                //课题名称字典
                Dictionary<string, string> subjectNameDict = new Dictionary<string, string>();

                #region 生成----(研究内容_概述列表)
                StringBuilder sb = new StringBuilder();
                int subIndex = 0;
                foreach (Subjects sub in subjectList)
                {
                    subIndex++;
                    string subFlag = "内容" + GlobalTool.NumberToChinese(subIndex.ToString());

                    subjectNameDict[sub.ID] = "研究内容" + GlobalTool.NumberToChinese(subIndex.ToString());

                    string infoString = string.Empty;
                    string infoFile = Path.Combine(pt.filesDir, subjectFileHeadString + sub.SubjectName + "_概述.txt");
                    if (File.Exists(infoFile))
                    {
                        infoString = File.ReadAllText(infoFile);
                    }
                    sb.Append(subFlag).Append("：").Append(sub.SubjectName).Append("，").Append(infoString).AppendLine("。");
                }
                #endregion
                writeStringToBookmark(wd, "研究内容_概述列表", sb.ToString());

                if (wd.WordDocBuilder.CurrentParagraph != null)
                {
                    wd.WordDocBuilder.CurrentParagraph.Remove();
                }

                #region 生成----(附件文件2)
                List<ExtFiles> list = ConnectionManager.Context.table("ExtFiles").select("*").getList<ExtFiles>(new ExtFiles());
                foreach (ExtFiles efl in list)
                {
                    if (efl.IsIgnore == 0)
                    {
                        //图片文件
                        string picFile = Path.Combine(pt.filesDir, efl.RealFileName);

                        //检查图片是否存在，如果存在则插入
                        if (File.Exists(picFile))
                        {
                            writeImageToBookmark(wd, "附件文件2", picFile);
                        }
                    }
                }
                #endregion

                #region 生成----(项目负责人和研究团队_研究团队)
                sb = new StringBuilder();
                int sssIndexx = 0;
                List<Subjects> subList = ConnectionManager.Context.table("Subjects").select("*").getList<Subjects>(new Subjects());
                foreach (Subjects sub in subList)
                {
                    sssIndexx++;

                    Persons pObj = ConnectionManager.Context.table("Persons").where("SubjectID = '" + sub.ID + "' and RoleName='负责人' and (RoleType = '" + FrmAddOrUpdateWorker.isProjectAndSubject + "' or RoleType = '" + FrmAddOrUpdateWorker.isOnlySubject + "')").select("*").getItem<Persons>(new Persons());
                    if (string.IsNullOrEmpty(pObj.ID))
                    {
                        continue;
                    }

                    sb.Append("研究内容").Append(GlobalTool.NumberToChinese(sssIndexx.ToString())).Append("负责人:").Append(pObj.Name).Append(",").Append(pObj.AttachInfo).AppendLine();
                }
                #endregion
                writeStringToBookmark(wd, "项目负责人和研究团队_研究团队", sb.ToString());

                #region 生成----(研究周期与进度安排_阶段详细)
                int ssssIndex = 0;
                sb = new StringBuilder();
                foreach (ProjectStep ps in projectstepList)
                {
                    ssssIndex++;
                    sb.Append("     ").Append("（").Append(GlobalTool.NumberToChinese(ssssIndex.ToString())).Append("）第").Append(GlobalTool.NumberToChinese(ssssIndex.ToString())).Append("阶段：").Append(ps.StepTime).AppendLine("月");
                    sb.Append("     ").Append("完成内容：").AppendLine(ps.StepTag1);
                    sb.Append("     ").Append("阶段成果：").AppendLine(ps.StepTag2);
                    sb.Append("     ").Append("考核指标：").AppendLine(ps.StepTag3);
                }
                #endregion
                writeStringToBookmark(wd, "研究周期与进度安排_阶段详细", sb.ToString());

                #region 生成----(研究内容_详细内容)的书签
                wd.WordDocBuilder.MoveToBookmark("研究内容_详细内容");

                //旧的缩进样式
                double oldFirstLineIndent = wd.WordDocBuilder.ParagraphFormat.FirstLineIndent;
                
                //生成内容书签
                foreach (Subjects sub in subjectList)
                {
                    string indexStringg = subjectNameDict[sub.ID];

                    //应用数字样式
                    wd.WordDocBuilder.ListFormat.List = flag22_numberList;
                    wd.WordDocBuilder.ParagraphFormat.FirstLineIndent = flag22_paragraphFormat.FirstLineIndent;
                    wd.WordDocBuilder.ParagraphFormat.LeftIndent = 0;
                    wd.WordDocBuilder.ParagraphFormat.RightIndent = 0;

                    wd.WordDocBuilder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading2;
                    wd.WordDocBuilder.Font.Name = "楷体_GB2312";
                    wd.WordDocBuilder.Font.Size = 15.75;
                    wd.WordDocBuilder.Writeln(indexStringg + "：" + sub.SubjectName);
                    wd.WordDocBuilder.Font.Name = "仿宋_GB2312";
                    wd.WordDocBuilder.Font.Size = 14.2;
                    //恢复之前的样式
                    wd.WordDocBuilder.ListFormat.RemoveNumbers();
                    wd.WordDocBuilder.ParagraphFormat.FirstLineIndent = oldFirstLineIndent;

                    wd.WordDocBuilder.Writeln("     1.具体研究内容");
                    wd.WordDocBuilder.StartBookmark(indexStringg + "_1");
                    wd.WordDocBuilder.EndBookmark(indexStringg + "_1");

                    wd.WordDocBuilder.Writeln("     2.关键问题");
                    wd.WordDocBuilder.StartBookmark(indexStringg + "_2");
                    wd.WordDocBuilder.EndBookmark(indexStringg + "_2");

                    wd.WordDocBuilder.Writeln("     3.研究思路与方法");
                    wd.WordDocBuilder.StartBookmark(indexStringg + "_3");
                    wd.WordDocBuilder.EndBookmark(indexStringg + "_3");
                }
                #endregion

                wd.WordDocBuilder.Font.Name = "仿宋_GB2312";
                wd.WordDocBuilder.Font.Size = 12;

                #region 生成----(*经费表)
                try
                {
                    List<Moneys> moneyList = ConnectionManager.Context.table("Moneys").select("*").getList<Moneys>(new Moneys());
                    //取数放于字典中
                    Dictionary<string, string> tempDict = new Dictionary<string, string>();
                    foreach (Moneys ysb in moneyList)
                    {
                        tempDict[ysb.Name] = ysb.Value;
                    }
                    foreach (Node node in ncc)
                    {
                        Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                        if (t.GetText().Contains("科目名称") && t.GetText().Contains("年度申请经费"))
                        {
                            //金额
                            t.Rows[2].Cells[1].RemoveAllChildren();
                            t.Rows[2].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money1"]));
                            ((Paragraph)t.Rows[2].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[3].Cells[1].RemoveAllChildren();
                            t.Rows[3].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money2"]));
                            ((Paragraph)t.Rows[3].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[4].Cells[1].RemoveAllChildren();
                            t.Rows[4].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money3"]));
                            ((Paragraph)t.Rows[4].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[5].Cells[1].RemoveAllChildren();
                            t.Rows[5].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money3_1"]));
                            ((Paragraph)t.Rows[5].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[6].Cells[1].RemoveAllChildren();
                            t.Rows[6].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money3_2"]));
                            ((Paragraph)t.Rows[6].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[7].Cells[1].RemoveAllChildren();
                            t.Rows[7].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money3_3"]));
                            ((Paragraph)t.Rows[7].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[8].Cells[1].RemoveAllChildren();
                            t.Rows[8].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money4"]));
                            ((Paragraph)t.Rows[8].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[9].Cells[1].RemoveAllChildren();
                            t.Rows[9].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money5"]));
                            ((Paragraph)t.Rows[9].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[10].Cells[1].RemoveAllChildren();
                            t.Rows[10].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money5_1"]));
                            ((Paragraph)t.Rows[10].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[11].Cells[1].RemoveAllChildren();
                            t.Rows[11].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money5_2"]));
                            ((Paragraph)t.Rows[11].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[12].Cells[1].RemoveAllChildren();
                            t.Rows[12].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money6"]));
                            ((Paragraph)t.Rows[12].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[13].Cells[1].RemoveAllChildren();
                            t.Rows[13].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money7"]));
                            ((Paragraph)t.Rows[13].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[14].Cells[1].RemoveAllChildren();
                            t.Rows[14].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money8"]));
                            ((Paragraph)t.Rows[14].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[15].Cells[1].RemoveAllChildren();
                            t.Rows[15].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money9"]));
                            ((Paragraph)t.Rows[15].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[16].Cells[1].RemoveAllChildren();
                            t.Rows[16].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money10"]));
                            ((Paragraph)t.Rows[16].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[17].Cells[1].RemoveAllChildren();
                            t.Rows[17].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money11"]));
                            ((Paragraph)t.Rows[17].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[18].Cells[1].RemoveAllChildren();
                            t.Rows[18].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money12"]));
                            ((Paragraph)t.Rows[18].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[19].Cells[1].RemoveAllChildren();
                            t.Rows[19].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Money13"]));
                            ((Paragraph)t.Rows[19].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            //备注
                            t.Rows[2].Cells[2].RemoveAllChildren();
                            t.Rows[2].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info1"]));
                            t.Rows[2].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[3].Cells[2].RemoveAllChildren();
                            t.Rows[3].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info2"]));
                            t.Rows[3].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[4].Cells[2].RemoveAllChildren();
                            t.Rows[4].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info3"]));
                            t.Rows[4].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[5].Cells[2].RemoveAllChildren();
                            t.Rows[5].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info3_1"]));
                            t.Rows[5].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[6].Cells[2].RemoveAllChildren();
                            t.Rows[6].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info3_2"]));
                            t.Rows[6].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[7].Cells[2].RemoveAllChildren();
                            t.Rows[7].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info3_3"]));
                            t.Rows[7].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[8].Cells[2].RemoveAllChildren();
                            t.Rows[8].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info4"]));
                            t.Rows[8].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[9].Cells[2].RemoveAllChildren();
                            t.Rows[9].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info5"]));
                            t.Rows[9].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[10].Cells[2].RemoveAllChildren();
                            t.Rows[10].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info5_1"]));
                            t.Rows[10].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[11].Cells[2].RemoveAllChildren();
                            t.Rows[11].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info5_2"]));
                            t.Rows[11].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[12].Cells[2].RemoveAllChildren();
                            t.Rows[12].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info6"]));
                            t.Rows[12].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[13].Cells[2].RemoveAllChildren();
                            t.Rows[13].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info7"]));
                            t.Rows[13].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[14].Cells[2].RemoveAllChildren();
                            t.Rows[14].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info8"]));
                            t.Rows[14].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[15].Cells[2].RemoveAllChildren();
                            t.Rows[15].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info9"]));
                            t.Rows[15].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[16].Cells[2].RemoveAllChildren();
                            t.Rows[16].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info10"]));
                            t.Rows[16].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[17].Cells[2].RemoveAllChildren();
                            t.Rows[17].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info11"]));
                            t.Rows[17].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[18].Cells[2].RemoveAllChildren();
                            t.Rows[18].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info12"]));
                            t.Rows[18].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            t.Rows[19].Cells[2].RemoveAllChildren();
                            t.Rows[19].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Info13"]));
                            t.Rows[19].Cells[2].CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                            //年度金额
                            t.Rows[t.Rows.Count - 1].Cells[0].RemoveAllChildren();
                            t.Rows[t.Rows.Count - 1].Cells[0].AppendChild(wd.newParagraph(t.Document, tempDict["Year1"]));
                            ((Paragraph)t.Rows[t.Rows.Count - 1].Cells[0].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[t.Rows.Count - 1].Cells[1].RemoveAllChildren();
                            t.Rows[t.Rows.Count - 1].Cells[1].AppendChild(wd.newParagraph(t.Document, tempDict["Year2"]));
                            ((Paragraph)t.Rows[t.Rows.Count - 1].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;

                            t.Rows[t.Rows.Count - 1].Cells[2].RemoveAllChildren();
                            t.Rows[t.Rows.Count - 1].Cells[2].AppendChild(wd.newParagraph(t.Document, tempDict["Year3"]));
                            ((Paragraph)t.Rows[t.Rows.Count - 1].Cells[2].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                            break;
                        }
                    }
                }
                catch (Exception ex) { }
                #endregion

                wd.WordDocBuilder.Font.Name = "仿宋_GB2312";
                wd.WordDocBuilder.Font.Size = 12;

                #region 生成----(*人员表)
                List<Persons> personList = ConnectionManager.Context.table("Persons").select("*").getList<Persons>(new Persons());
                //填充数据
                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("身份证号码") && t.GetText().Contains("工作单位") && t.GetText().Contains("项目任务分工"))
                    {
                        //创建行
                        for (int k = 0; k < personList.Count - 1; k++)
                        {
                            t.Rows.Insert(1, (Aspose.Words.Tables.Row)t.Rows[t.Rows.Count - 2].Clone(true));
                        }

                        int rowStart = 1;
                        foreach (Persons data in personList)
                        {
                            wd.fillCell(true, t.Rows[rowStart].Cells[0], wd.newParagraph(wd.WordDoc, rowStart + ""));
                            wd.fillCell(true, t.Rows[rowStart].Cells[1], wd.newParagraph(wd.WordDoc, data.Name));
                            wd.fillCell(true, t.Rows[rowStart].Cells[2], wd.newParagraph(wd.WordDoc, data.IDCard));
                            wd.fillCell(true, t.Rows[rowStart].Cells[3], wd.newParagraph(wd.WordDoc, data.UnitName));
                            wd.fillCell(true, t.Rows[rowStart].Cells[4], wd.newParagraph(wd.WordDoc, data.Job));
                            wd.fillCell(true, t.Rows[rowStart].Cells[5], wd.newParagraph(wd.WordDoc, data.Specialty));

                            string roleNamess = "未知";

                            switch (data.RoleType)
                            {
                                case FrmAddOrUpdateWorker.isOnlyProject:
                                    roleNamess = "项目负责人";
                                    break;
                                case FrmAddOrUpdateWorker.isProjectAndSubject:
                                    roleNamess = "项目负责人兼" + (subjectNameDict.ContainsKey(data.SubjectID) ? subjectNameDict[data.SubjectID] + data.RoleName : "未知");
                                    break;
                                case FrmAddOrUpdateWorker.isOnlySubject:
                                    roleNamess = subjectNameDict.ContainsKey(data.SubjectID) ? subjectNameDict[data.SubjectID] + data.RoleName : "未知";
                                    break;
                            }
                            wd.fillCell(true, t.Rows[rowStart].Cells[6], wd.newParagraph(wd.WordDoc, roleNamess));

                            wd.fillCell(true, t.Rows[rowStart].Cells[7], wd.newParagraph(wd.WordDoc, data.TimeForSubject.ToString()));

                            rowStart++;
                        }
                    }
                }
                #endregion

                wd.WordDocBuilder.Font.Name = "仿宋_GB2312";
                wd.WordDocBuilder.Font.Size = 10.5;

                #region 生成----(*联系方式表)
                try
                {
                    foreach (Aspose.Words.Tables.Table table in ncc)
                    {
                        if (table.Range.Text.Contains("项目组联系方式"))
                        {
                            int titleIndex = table.Rows.Count - 1;
                            int dataIndex = table.Rows.Count - 1;

                            //构造联系方式行
                            int rowCountt = (subjectList.Count * 3) - 1;
                            for (int k = 0; k < rowCountt; k++)
                            {
                                //table.Select();
                                table.Rows.Add((Aspose.Words.Tables.Row)table.Rows[table.Rows.Count - 1].Clone(true));
                            }
                            //合并单元格
                            if (rowCountt >= 2)
                            {
                                for (int k = 0; k < subjectList.Count; k++)
                                {
                                    //计算开始位置
                                    int rowStart = dataIndex + (k * 3);
                                    int rowEnd = rowStart + 2;

                                    #region 写入标签
                                    wd.WordDocBuilder.Font.Name = "黑体";
                                    wd.WordDocBuilder.Font.Size = 12;
                                    wd.fillCell(true, table.Rows[rowStart].Cells[0], wd.newParagraph(wd.WordDoc, subjectNameDict[subjectList[k].ID]));
                                    wd.WordDocBuilder.Font.Name = "仿宋_GB2312";
                                    wd.WordDocBuilder.Font.Size = 10.5;

                                    wd.fillCell(true, table.Rows[rowStart].Cells[1], wd.newParagraph(wd.WordDoc, "负 责 人"));
                                    wd.fillCell(true, table.Rows[rowStart].Cells[3], wd.newParagraph(wd.WordDoc, "性  别"));
                                    wd.fillCell(true, table.Rows[rowStart].Cells[5], wd.newParagraph(wd.WordDoc, "出生年月"));
                                    wd.fillCell(true, table.Rows[rowStart + 1].Cells[1], wd.newParagraph(wd.WordDoc, "职务职称"));
                                    wd.fillCell(true, table.Rows[rowStart + 1].Cells[3], wd.newParagraph(wd.WordDoc, "座  机"));
                                    wd.fillCell(true, table.Rows[rowStart + 1].Cells[5], wd.newParagraph(wd.WordDoc, "手  机"));
                                    wd.fillCell(true, table.Rows[rowStart + 2].Cells[1], wd.newParagraph(wd.WordDoc, "通信地址"));
                                    #endregion

                                    #region 写入数据
                                    Persons pObj = ConnectionManager.Context.table("Persons").where("SubjectID = '" + subjectList[k].ID + "' and RoleName='负责人' and (RoleType = '" + FrmAddOrUpdateWorker.isProjectAndSubject + "' or RoleType = '" + FrmAddOrUpdateWorker.isOnlySubject + "')").select("*").getItem<Persons>(new Persons());
                                    if (string.IsNullOrEmpty(pObj.ID))
                                    {
                                        //无数据
                                        wd.fillCell(true, table.Rows[rowStart].Cells[2], wd.newParagraph(wd.WordDoc, "空"));
                                        wd.fillCell(true, table.Rows[rowStart].Cells[4], wd.newParagraph(wd.WordDoc, "空"));
                                        wd.fillCell(true, table.Rows[rowStart].Cells[6], wd.newParagraph(wd.WordDoc, "空"));
                                        wd.fillCell(true, table.Rows[rowStart + 1].Cells[2], wd.newParagraph(wd.WordDoc, "空"));
                                        wd.fillCell(true, table.Rows[rowStart + 1].Cells[4], wd.newParagraph(wd.WordDoc, "空"));
                                        wd.fillCell(true, table.Rows[rowStart + 1].Cells[6], wd.newParagraph(wd.WordDoc, "空"));
                                        wd.fillCell(true, table.Rows[rowStart + 2].Cells[2], wd.newParagraph(wd.WordDoc, "空"), false);
                                    }
                                    else
                                    {
                                        //有数据
                                        wd.fillCell(true, table.Rows[rowStart].Cells[2], wd.newParagraph(wd.WordDoc, pObj.Name));
                                        wd.fillCell(true, table.Rows[rowStart].Cells[4], wd.newParagraph(wd.WordDoc, pObj.Sex));
                                        wd.fillCell(true, table.Rows[rowStart].Cells[6], wd.newParagraph(wd.WordDoc, pObj.Birthday.ToString("yyyy年MM月dd日")));
                                        wd.fillCell(true, table.Rows[rowStart + 1].Cells[2], wd.newParagraph(wd.WordDoc, pObj.Job));
                                        wd.fillCell(true, table.Rows[rowStart + 1].Cells[4], wd.newParagraph(wd.WordDoc, pObj.Telephone));
                                        wd.fillCell(true, table.Rows[rowStart + 1].Cells[6], wd.newParagraph(wd.WordDoc, pObj.MobilePhone));
                                        wd.fillCell(true, table.Rows[rowStart + 2].Cells[2], wd.newParagraph(wd.WordDoc, subjectList[k].UnitAddress != null ? subjectList[k].UnitAddress.Replace(PublicReporterLib.JsonConfigObject.cellFlag, string.Empty) : string.Empty), false);
                                    }
                                    #endregion

                                    //合并单元格
                                    wd.mergeCells(table.Rows[rowEnd].Cells[2], table.Rows[rowEnd].Cells[6], table);
                                    wd.mergeCells(table.Rows[rowStart].Cells[0], table.Rows[rowEnd].Cells[0], table);
                                }
                            }
                            else
                            {
                                table.Rows[titleIndex].Remove();
                                table.Rows[dataIndex].Remove();
                            }
                        }
                    }
                }
                catch (Exception ex) { }

                #endregion

                #region 写入联系方式中的固定字段
                Persons masterObj = ConnectionManager.Context.table("Persons").where("RoleType='" + FrmAddOrUpdateWorker.isOnlyProject + "' or (RoleType='" + FrmAddOrUpdateWorker.isProjectAndSubject + "' and RoleName='负责人')").select("*").getItem<Persons>(new Persons());
                writeStringToBookmark(wd, "联系方式_项目负责人_姓名", masterObj.Name);
                writeStringToBookmark(wd, "联系方式_项目负责人_性别", masterObj.Sex);
                writeStringToBookmark(wd, "联系方式_项目负责人_出生年月", masterObj.Birthday.ToString("yyyy年MM月dd日"));
                writeStringToBookmark(wd, "联系方式_项目负责人_职务职称", masterObj.Job);
                writeStringToBookmark(wd, "联系方式_项目负责人_座机", masterObj.Telephone);
                writeStringToBookmark(wd, "联系方式_项目负责人_手机", masterObj.MobilePhone);
                writeStringToBookmark(wd, "联系方式_申报单位_单位名称", projObj.UnitName);
                writeStringToBookmark(wd, "联系方式_申报单位_单位联系人", projObj.UnitContact);
                writeStringToBookmark(wd, "联系方式_申报单位_单位联系人职务职称", projObj.UnitContactJob);
                writeStringToBookmark(wd, "联系方式_申报单位_单位联系人手机", projObj.UnitContactPhone);
                writeStringToBookmark(wd, "联系方式_申报单位_通信地址", projObj.UnitAddress != null ? projObj.UnitAddress.Replace(PublicReporterLib.JsonConfigObject.cellFlag, string.Empty) : string.Empty);
                wd.WordDocBuilder.InsertParagraph();
                #endregion

                #region 插入研究内容附件
                foreach (Subjects sub in subjectList)
                {
                    string indexStringg = subjectNameDict[sub.ID];

                    string file1Path = Path.Combine(pt.filesDir, subjectFileHeadString + sub.SubjectName + "_具体研究内容.doc");
                    string file2Path = Path.Combine(pt.filesDir, subjectFileHeadString + sub.SubjectName + "_关键问题.doc");
                    string file3Path = Path.Combine(pt.filesDir, subjectFileHeadString + sub.SubjectName + "_研究思路与方法.doc");

                    if (File.Exists(file1Path))
                    {
                        InsertDocumentWithCustomBookmark.insertDocumentAfterBookMark(wd.WordDoc, new Document(file1Path), indexStringg + "_1", false);
                    }
                    if (File.Exists(file2Path))
                    {
                        InsertDocumentWithCustomBookmark.insertDocumentAfterBookMark(wd.WordDoc, new Document(file2Path), indexStringg + "_2", false);
                    }
                    if (File.Exists(file3Path))
                    {
                        InsertDocumentWithCustomBookmark.insertDocumentAfterBookMark(wd.WordDoc, new Document(file3Path), indexStringg + "_3", false);
                    }
                }
                if (wd.WordDocBuilder.CurrentParagraph != null)
                {
                    wd.WordDocBuilder.CurrentParagraph.Remove();
                }
                #endregion

                #endregion

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
                wd.WordDoc.UpdateFields();
                wd.WordDoc.UpdateListLabels();
                wd.WordDoc.UpdatePageLayout();
                wd.WordDoc.UpdateTableLayout();
                wd.WordDoc.UpdateThumbnail();
                wd.WordDoc.UpdateWordCount();
                #endregion

                AbstractEditorPlugin.AbstractPluginRoot.report(progressDialog, 90, "生成文档...", 1000);

                #region 显示文档或生成文档
                //保存word
                string docFile = Path.Combine(pt.dataDir, outputDocFileName);
                wd.WordDoc.Save(docFile);
                Process.Start(docFile);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            AbstractEditorPlugin.AbstractPluginRoot.report(progressDialog, 95, "", 1000);
        }

        /// <summary>
        /// 向固定的书签写图片
        /// </summary>
        /// <param name="wd"></param>
        /// <param name="bookmark"></param>
        /// <param name="picturePath"></param>
        private static void writeImageToBookmark(WordDocument wd, string bookmark, string picturePath)
        {
            if (File.Exists(picturePath))
            {
                if (wd.WordDocBuilder.MoveToBookmark(bookmark))
                {
                    wd.WordDocBuilder.InsertImage(picturePath);
                }
            }
        }

        /// <summary>
        /// 向固定的书签写文件
        /// </summary>
        /// <param name="wd"></param>
        /// <param name="bookmarkString"></param>
        /// <param name="docFile"></param>
        /// <param name="isDeleteEnterFlag"></param>        
        private static void writeFileToBookmark(WordDocument wd, string bookmarkString, string docFile, bool isDeleteEnterFlag)
        {
            if (docFile != null && File.Exists(docFile))
            {
                if (docFile.EndsWith(".txt"))
                {
                    //写文本文件
                    if (wd.WordDocBuilder.MoveToBookmark(bookmarkString))
                    {
                        wd.writeWithNewLine(File.ReadAllText(docFile));
                    }
                }
                else if (docFile.EndsWith(".doc") || docFile.EndsWith(".docx"))
                {
                    //写Doc文件
                    wd.insertDocumentAfterBookMark(new Document(docFile), bookmarkString, isDeleteEnterFlag);
                }
            }
        }

        /// <summary>
        /// 向固定的书签写文字
        /// </summary>
        /// <param name="wd"></param>
        /// <param name="bookmarkString"></param>
        /// <param name="value"></param>
        private static void writeStringToBookmark(WordDocument wd, string bookmarkString, string value)
        {
            if (wd.WordDocBuilder.MoveToBookmark(bookmarkString) && value != null)
            {
                wd.WordDocBuilder.Write(value);
            }
        }
    }

    /// <summary>
    /// 专用于在自定义书签下面插入文档
    /// </summary>
    class InsertDocumentWithCustomBookmark
    {
        public static Document insertDocumentAfterBookMark(Document mainDoc, Document tobeInserted, string bookmark,bool isNeedDeleteEnterFlag)
        {
            // check maindoc
            if (mainDoc == null)
            {
                return null;
            }
            // check to be inserted doc
            if (tobeInserted == null)
            {
                return mainDoc;
            }
            DocumentBuilder mainDocBuilder = new DocumentBuilder(mainDoc);
            // check bookmark and then process
            if (bookmark != null && bookmark.Trim().Length > 0)
            {
                Bookmark bm = mainDoc.Range.Bookmarks[bookmark];
                if (bm != null)
                {
                    mainDocBuilder.MoveToBookmark(bookmark);

                    Node insertAfterNode = mainDocBuilder.CurrentParagraph.PreviousSibling;
                    insertDocumentAfterNode(insertAfterNode, mainDoc, tobeInserted);

                    if (isNeedDeleteEnterFlag)
                    {
                        if (mainDocBuilder.CurrentParagraph != null)
                        {
                            mainDocBuilder.CurrentParagraph.Remove();
                        }
                    }
                }
            }
            return mainDoc;
        }

        public static void insertDocumentAfterNode(Node insertAfterNode, Document mainDoc, Document srcDoc)
        {
            // Make sure that the node is either a pargraph or table.
            if ((insertAfterNode.NodeType != NodeType.Paragraph)
            & (insertAfterNode.NodeType != NodeType.Table))
                throw new Exception("The destination node should be either a paragraph or table.");

            //We will be inserting into the parent of the destination paragraph.
            CompositeNode dstStory = insertAfterNode.ParentNode;
            //Remove empty paragraphs from the end of document
            while (null != srcDoc.LastSection.Body.LastParagraph && !srcDoc.LastSection.Body.LastParagraph.HasChildNodes)
            {
                srcDoc.LastSection.Body.LastParagraph.Remove();
            }
            NodeImporter importer = new NodeImporter(srcDoc, mainDoc, ImportFormatMode.KeepSourceFormatting);
            //Loop through all sections in the source document.
            int sectCount = srcDoc.Sections.Count;
            for (int sectIndex = 0; sectIndex < sectCount; sectIndex++)
            {
                Section srcSection = srcDoc.Sections[sectIndex];
                //Loop through all block level nodes (paragraphs and tables) in the body of the section.
                int nodeCount = srcSection.Body.ChildNodes.Count;
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    Node srcNode = srcSection.Body.ChildNodes[nodeIndex];
                    Node newNode = importer.ImportNode(srcNode, true);
                    dstStory.InsertAfter(newNode, insertAfterNode);
                    insertAfterNode = newNode;
                }
            }
        }
    }
}