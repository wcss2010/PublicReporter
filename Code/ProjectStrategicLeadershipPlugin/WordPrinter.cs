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
                writeStringToBookmark(wd, "基本信息_研究周期", projObj.TotalTime + "");
                writeStringToBookmark(wd, "基本信息_研究经费", projObj.TotalMoney + "");
                writeStringToBookmark(wd, "基本信息_联系人", projObj.UnitContact);
                writeStringToBookmark(wd, "基本信息_联系电话", projObj.UnitContactPhone);
                writeStringToBookmark(wd, "基本信息_单位所在省市", projObj.UnitAddress);
                writeStringToBookmark(wd, "基本信息_所属大单位", projObj.UnitType2);
                writeStringToBookmark(wd, "基本信息_申报日期", projObj.RequestTime.ToShortDateString());

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
                string subjectFileHeadString = ProjectStrategicLeadershipPlugin.Editor.SubjectDetailEditor.SubjectFileFlag + "_";

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

                    sb.Append("     ").Append("研究内容").Append(GlobalTool.NumberToChinese(sssIndexx.ToString())).Append("负责人:").Append(",").Append(pObj.AttachInfo).AppendLine();
                }
                #endregion

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

                #region 生成----(研究内容_详细内容)
                #endregion

                #region 生成----(*经费表)
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
                #endregion

                #region 生成----(*人员表)
                List<Persons> personList = ConnectionManager.Context.table("Persons").select("*").getList<Persons>(new Persons());
                //填充数据
                foreach (Node node in ncc)
                {
                    Aspose.Words.Tables.Table t = (Aspose.Words.Tables.Table)node;
                    if (t.GetText().Contains("任务分工") && t.GetText().Contains("身份证号码") && t.GetText().Contains("项目中职务"))
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

                #region 生成----(*联系方式表)
                #endregion

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
            if (wd.WordDocBuilder.MoveToBookmark(bookmarkString))
            {
                wd.WordDocBuilder.Write(value);
            }
        }
    }
}