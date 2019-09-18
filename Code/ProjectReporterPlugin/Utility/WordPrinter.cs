using Aspose.Words;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ProjectReporterPlugin.DB;
using ProjectReporterPlugin.DB.Entitys;
using ProjectReporterPlugin.Editor;

namespace ProjectReporterPlugin.Utility
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

            //查找附件文件
            string[] filess = Directory.GetFiles(pt.filesDir);
            foreach (string f in filess)
            {
                if (f.Contains(MoneySummaryEditor.FileKeyName))
                {
                    uploadA = f;
                }
            }

            //课题负责人信息列表
            List<string[]> subjectMasterInfoList = new List<string[]>();

            //创建word文档
            string fileName = pt.projectObj.Name + "-项目建议书.docx";
            WordUtility wu = new WordUtility();
            wu.createNewDocument(Path.Combine(Path.Combine(pt.RootDir, "Helper"), "newtemplete.docx"));

            try
            {
                Report(progressDialog, 20, "准备数据...", 1000);

                #region 查找需要生成的节点的样式
                Aspose.Words.Lists.List numberList = null;
                ParagraphFormat paragraphFormat = null;
                NodeCollection nodes = wu.Document.WordDoc.GetChildNodes(NodeType.Paragraph, true);
                foreach (Node node in nodes)
                {
                    if (node.Range.Text.Contains("F2-1"))
                    {
                        if (numberList == null)
                        {
                            numberList = ((Paragraph)node).ListFormat.List;
                            paragraphFormat = ((Paragraph)node).ParagraphFormat;
                        }

                        node.Remove();
                    }
                }
                #endregion

                #region 查询项目负责人及单位信息
                Person projectPersonObj = ConnectionManager.Context.table("Person").where("ID in (select PersonID from task where Role='负责人' and Type='项目' and ProjectID = '" + pt.projectObj.ID + "')").select("*").getItem<Person>(new Person());
                if (projectPersonObj == null)
                {
                    return;
                }
                Unit projectUnitObj = ConnectionManager.Context.table("Unit").where("ID = '" + pt.projectObj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                if (projectUnitObj == null)
                {
                    return;
                }
                #endregion

                Report(progressDialog, 30, "写入基本信息...", 1000);

                #region 固定文本替换
                wu.insertValue("项目名称", pt.projectObj.Name);
                wu.insertValue("首页密级", pt.projectObj.SecretLevel);
                wu.insertValue("申报领域", pt.projectObj.Domain);
                wu.insertValue("申报方向", pt.projectObj.Direction);
                wu.insertValue("单位名称", projectUnitObj.UnitName);
                wu.insertValue("单位常用名", projectUnitObj.NormalName);
                wu.insertValue("项目负责人", projectPersonObj.Name);
                wu.insertValue("单位联系人", projectUnitObj.ContactName);
                wu.insertValue("联系电话", projectUnitObj.Telephone, 18, false, false, true);
                wu.insertValue("通信地址", projectUnitObj.Address);
                wu.insertValue("研究周期", pt.projectObj.TotalTime + "");
                wu.insertValue("研究经费", pt.projectObj.TotalMoney + "");
                wu.insertValue("项目关键字", pt.projectObj.Keywords != null ? pt.projectObj.Keywords : string.Empty);

                List<Project> ketiList = ConnectionManager.Context.table("Project").where("ParentID = '" + pt.projectObj.ID + "'").select("*").getList<Project>(new Project());
                wu.insertValue("课题数量", ketiList.Count + "");

                wu.insertValue("研究周期B", pt.projectObj.TotalTime + "");
                wu.insertValue("研究经费B", pt.projectObj.TotalMoney + "");

                List<Step> projectStepList = ConnectionManager.Context.table("Step").where("ProjectID = '" + pt.projectObj.ID + "'").select("*").getList<Step>(new Step());
                wu.insertValue("阶段数量", projectStepList.Count + "");
                StringBuilder stepBuilders = new StringBuilder();
                foreach (Step step in projectStepList)
                {
                    stepBuilders.Append("阶段").Append(step.StepIndex).Append("为").Append(step.StepTime).Append("月").Append(",");
                }
                if (stepBuilders.Length > 1)
                {
                    stepBuilders.Remove(stepBuilders.Length - 1, 1);
                }
                wu.insertValue("阶段时间摘要", stepBuilders.ToString());

                wu.insertValue("项目负责人B", projectPersonObj.Name);
                wu.insertValue("项目负责人性别", projectPersonObj.Sex);
                wu.insertValue("项目负责人生日", (projectPersonObj.Birthday != null ? projectPersonObj.Birthday.Value.ToString("yyyy-MM-dd") : "未知"));
                wu.insertValue("项目负责人职务", projectPersonObj.Job);
                wu.insertValue("项目负责人座机", projectPersonObj.Specialty);
                wu.insertValue("项目负责人手机", projectPersonObj.MobilePhone);

                Unit whiteUnit = ConnectionManager.Context.table("Unit").where("ID in (select UnitID from WhiteList where ProjectID = '" + pt.projectObj.ID + "')").select("*").getItem<Unit>(new Unit());
                wu.insertValue("候选单位名称", whiteUnit.UnitName);
                wu.insertValue("候选单位联系人", whiteUnit.ContactName);
                wu.insertValue("候选单位联系电话", whiteUnit.Telephone);
                wu.insertValue("候选单位通信地址", whiteUnit.Address);
                #endregion

                Report(progressDialog, 40, "写入文档文件...", 1000);

                #region 插入固定RTF文件
                //wu.insertFile("项目摘要", Path.Combine(pt.filesDir, "项目摘要.doc"), true);
                wu.insertTxtFile("项目摘要", Path.Combine(pt.filesDir, "项目摘要.txt"));

                wu.insertFile("基本概念及内涵", Path.Combine(pt.filesDir, "基本概念及内涵.doc"), true);
                wu.insertFile("军事需求分析", Path.Combine(pt.filesDir, "军事需求分析.doc"), true);
                wu.insertFile("研究现状", Path.Combine(pt.filesDir, "研究现状.doc"), true);
                wu.insertFile("研究目标", Path.Combine(pt.filesDir, "研究目标.doc"), false);
                wu.insertFile("基础性问题", Path.Combine(pt.filesDir, "基础性问题.doc"), true);
                wu.insertFile("课题之间的关系", Path.Combine(pt.filesDir, "课题之间的关系.doc"), true);
                wu.insertFile("研究成果及考核指标", Path.Combine(pt.filesDir, "研究成果及考核指标.doc"), true);
                wu.insertFile("评估方案", Path.Combine(pt.filesDir, "评估方案.doc"), true);
                wu.insertFile("预期效益", Path.Combine(pt.filesDir, "预期效益.doc"), true);

                //wu.insertFile("项目负责人C", Path.Combine(pt.filesDir, "项目负责人.doc"), true);
                //wu.insertFile("研究团队", Path.Combine(pt.filesDir, "研究团队.doc"), true);
                wu.insertTxtFile("项目负责人C", Path.Combine(pt.filesDir, "项目负责人.txt"));
                
                wu.insertFile("研究基础与保障条件", Path.Combine(pt.filesDir, "研究基础与保障条件.doc"), true);
                wu.insertFile("组织实施与风险控制", Path.Combine(pt.filesDir, "组织实施与风险控制.doc"), true);
                wu.insertFile("与有关计划关系", Path.Combine(pt.filesDir, "与有关计划关系.doc"), false);

                wu.insertFile("附件1", uploadA, true);

                //插入保密资质
                List<ExtFileList> list = ConnectionManager.Context.table("ExtFileList").where("ProjectID='" + pt.projectObj.ID + "'").select("*").getList<ExtFileList>(new ExtFileList());
                foreach (ExtFileList efl in list)
                {
                    if (efl.IsIgnore == 0)
                    {
                        //图片文件
                        string picFile = Path.Combine(pt.filesDir, efl.RealFileName);

                        //检查图片是否存在，如果存在则插入
                        if (File.Exists(picFile))
                        {
                            wu.insertPicture("附件2", picFile);
                        }
                    }
                }

                //处理诚信承诺书
                string uploadC = Path.Combine(pt.RootDir, Path.Combine("Helper", "chengnuoshu.doc"));
                wu.insertFile("附件3", uploadC, true);
                wu.insertValue("诚信负责人", pt.projectObj.Name);
                #endregion

                #region 插入课题详细标签
                // "课题详细_" + ketiIndex + "_5"
                wu.Document.WordDocBuilder.MoveToBookmark("课题详细标识");

                wu.Document.WordDocBuilder.ListFormat.List = numberList;
                double oldFirstLineIndent = wu.Document.WordDocBuilder.ParagraphFormat.FirstLineIndent;
                wu.Document.WordDocBuilder.ParagraphFormat.FirstLineIndent = paragraphFormat.FirstLineIndent;

                for (int kk = 0; kk < ketiList.Count; kk++)
                {
                    Project proj = ketiList[kk];

                    int ketiIndex = (kk + 1);

                    //负责人
                    string fuzeUnit = string.Empty;
                    string fuzePerson = string.Empty;
                    string fuzeInfo = string.Empty;
                    fuzeUnit = ConnectionManager.Context.table("Unit").where("ID = (select UnitID from Project where ID = (select ProjectID from Task where Role= '负责人' and ProjectID = '" + proj.ID + "'))").select("UnitName").getValue<string>(string.Empty);
                    fuzePerson = ConnectionManager.Context.table("Person").where("ID = (select PersonID from Task where Role= '负责人' and ProjectID = '" + proj.ID + "')").select("Name").getValue<string>(string.Empty);
                    fuzeInfo = ConnectionManager.Context.table("Person").where("ID = (select PersonID from Task where Role= '负责人' and ProjectID = '" + proj.ID + "')").select("AttachInfo").getValue<string>(string.Empty);

                    //wu.InsertValue("课题详细_" + ketiIndex + "_4", "  负责人：" + fuzePerson + "\n  负责单位：" + fuzeUnit, true);

                    //金额
                    string moneyStr = "0";
                    Task ketiTask = ConnectionManager.Context.table("Task").where("ProjectID='" + proj.ID + "'").select("*").getItem<Task>(new Task());
                    if (ketiTask != null)
                    {
                        moneyStr = "  " + ketiTask.TotalMoney + "万";
                    }
                    //wu.InsertValue("课题详细_" + ketiIndex + "_5", moneyStr, true);

                    //保存课题负责人简历
                    subjectMasterInfoList.Add(new string[] { fuzePerson, fuzeInfo });

                    wu.Document.WordDocBuilder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading2;
                    wu.Document.WordDocBuilder.Writeln("F2-" + ketiIndex);
                    wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex);
                    wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex);

                    wu.Document.WordDocBuilder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading3;
                    wu.Document.WordDocBuilder.Writeln("、研究目标");
                    wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex + "_1");
                    wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex + "_1");

                    wu.Document.WordDocBuilder.Writeln("、研究内容");
                    wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex + "_2");
                    wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex + "_2");

                    wu.Document.WordDocBuilder.Writeln("、研究思路");
                    wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex + "_3");
                    wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex + "_3");

                    wu.Document.WordDocBuilder.Writeln("、负责单位及负责人");
                    wu.Document.WordDocBuilder.ParagraphFormat.ClearFormatting();
                    wu.Document.WordDocBuilder.Writeln("    负责人:" + fuzePerson);
                    wu.Document.WordDocBuilder.Writeln("    负责单位:" + fuzeUnit);
                    //wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex + "_4");
                    //wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex + "_4");

                    wu.Document.WordDocBuilder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading3;
                    wu.Document.WordDocBuilder.ParagraphFormat.FirstLineIndent = paragraphFormat.FirstLineIndent;
                    wu.Document.WordDocBuilder.Writeln("、研究经费");
                    wu.Document.WordDocBuilder.ParagraphFormat.ClearFormatting();
                    wu.Document.WordDocBuilder.Writeln("    " + moneyStr);
                    //wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex + "_5");
                    //wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex + "_5");
                }

                wu.Document.WordDocBuilder.ListFormat.RemoveNumbers();
                wu.Document.WordDocBuilder.ParagraphFormat.FirstLineIndent = oldFirstLineIndent;
                #endregion

                List<KeyValuePair<string, Project>> ketiMap = new List<KeyValuePair<string, Project>>();
                #region 插入课题详细RTF

                string[] chsNumbers = new string[] { "", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                try
                {
                    ketiMap.Add(new KeyValuePair<string, Project>("项目", pt.projectObj));

                    //替换课题详细内容
                    int ketiIndex = 1;
                    foreach (Project proj in ketiList)
                    {
                        string ketiCode = "课题" + chsNumbers[ketiIndex];

                        wu.selectBookMark("课题详细_" + ketiIndex);
                        wu.replaceA("F2-" + ketiIndex, ketiCode + ":" + proj.Name);

                        //研究目标，研究内容，技术要求等文档
                        wu.insertFile("课题详细_" + ketiIndex + "_1", Path.Combine(pt.filesDir, "课题详细_" + proj.Name + "_研究目标" + ".doc"), false);
                        wu.insertFile("课题详细_" + ketiIndex + "_2", Path.Combine(pt.filesDir, "课题详细_" + proj.Name + "_研究内容" + ".doc"), false);
                        wu.insertFile("课题详细_" + ketiIndex + "_3", Path.Combine(pt.filesDir, "课题详细_" + proj.Name + "_研究思路" + ".doc"), false);

                        ketiIndex++;

                        if (ketiMap.Count == 1)
                        {
                            ketiMap.Add(new KeyValuePair<string, Project>(ketiCode, proj));
                        }
                        else
                        {
                            ketiMap.Add(new KeyValuePair<string, Project>(ketiCode, proj));
                        }
                    }

                    //插入课题摘要
                    int indexx = 0;
                    StringBuilder ketiStringBuilder = new StringBuilder();
                    foreach (Project proj in ketiList)
                    {
                        indexx++;
                        Task tt = ConnectionManager.Context.table("Task").where("ProjectID = '" + proj.ID + "'").select("*").getItem<Task>(new Task());

                        string shortContent = "无";
                        if (File.Exists(Path.Combine(pt.filesDir, "课题详细_" + proj.Name + "_简介" + ".txt")))
                        {
                            shortContent = File.ReadAllText(Path.Combine(pt.filesDir, "课题详细_" + proj.Name + "_简介" + ".txt"));
                        }

                        //ketiStringBuilder.Append("课题").Append(indexx).Append("(").Append(proj.Type2.Contains("非") ? string.Empty : proj.Type2).Append(proj.Type2.Contains("非") ? string.Empty : ",").Append(proj.SecretLevel).Append("):").Append(proj.Name).Append(",").Append(shortContent).Append("\n");
                        ketiStringBuilder.Append("课题").Append(chsNumbers[indexx]).Append("(").Append(proj.SecretLevel).Append("):").Append(proj.Name).Append(",").Append(shortContent).Append("\n");
                    }
                    if (ketiStringBuilder.Length > 0)
                    {
                        ketiStringBuilder.Remove(ketiStringBuilder.Length - 1, 1);
                    }

                    wu.insertValue("课题摘要", ketiStringBuilder.ToString());
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                #endregion

                #region 写入研究团队
                StringBuilder workerGroupString = new StringBuilder();
                int indexxxx = 1;
                foreach (string[] tt in subjectMasterInfoList)
                {
                    string pName = tt[0];
                    string pInfo = tt[1];

                    if (string.IsNullOrEmpty(pInfo))
                    {
                        //continue;
                    }
                    else
                    {
                        workerGroupString.Append("     ").Append("课题").Append(chsNumbers[indexxxx]).Append("负责人:").Append(pName).Append(",").Append(pInfo).Append("\n");
                    }

                    indexxxx++;
                }
                wu.insertValue("研究团队", workerGroupString.ToString());

                #endregion

                Report(progressDialog, 50, "写入阶段信息...", 1000);

                wu.Document.WordDocBuilder.Font.Size = 12;
                wu.Document.WordDocBuilder.Font.Name = "仿宋_GB2312";

                #region 插入阶段划分和经费安排数据
                try
                {
                    //项目
                    NodeCollection ncc = wu.Document.WordDoc.GetChildNodes(Aspose.Words.NodeType.Table, true);
                    foreach (Aspose.Words.Tables.Table table in ncc)
                    {
                        if (table.Range.Text.Contains("进度要求"))
                        {
                            //填充行和列
                            int rowCount = projectStepList.Count;
                            //int colCount = 3;
                            //table.Select();
                            for (int k = 0; k < rowCount - 1; k++)
                            {
                                Aspose.Words.Tables.Row row = (Aspose.Words.Tables.Row)table.Rows[table.Rows.Count - 1].Clone(true);
                                table.Rows.Add(row);
                            }

                            ////创建列标题
                            //int colIndex = 2;
                            //foreach (Step step in projectStepList)
                            //{
                            //    table.Cell(1, colIndex).Range.Text = "阶段" + step.StepIndex + "(" + step.StepTime + "个月)";
                            //    table.Cell(1, colIndex).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            //    colIndex++;
                            //}

                            //创建数据
                            int rowIndex = 1;
                            foreach (KeyValuePair<string, Project> kvp in ketiMap)
                            {
                                if (kvp.Key == "项目")
                                {
                                    List<Step> curStepList = ConnectionManager.Context.table("Step").where("ProjectID = '" + kvp.Value.ID + "'").select("*").getList<Step>(new Step());
                                    foreach (Step curStep in curStepList)
                                    {
                                        ProjectAndStep curProjectAndStep = ConnectionManager.Context.table("ProjectAndStep").where("StepID = '" + curStep.ID + "'").select("*").getItem<ProjectAndStep>(new ProjectAndStep());

                                        //输出格式
                                        string outputFormat = "完成内容及阶段目标:\n{0}\n阶段成果、考核指标及考核方式:\n{1}\n阶段经费:{2}万";

                                        string resultStr = string.Empty;
                                        //阶段数据
                                        if (kvp.Key == "项目")
                                        {
                                            resultStr = string.Format(outputFormat, curStep.StepDest, curStep.StepResult, curStep.StepMoney);
                                        }
                                        else
                                        {
                                            resultStr = string.Format(outputFormat, curProjectAndStep.StepDest, curProjectAndStep.StepResult, curProjectAndStep.Money);
                                        }

                                        table.Rows[rowIndex].Cells[0].RemoveAllChildren();
                                        table.Rows[rowIndex].Cells[1].RemoveAllChildren();
                                        table.Rows[rowIndex].Cells[2].RemoveAllChildren();
                                        table.Rows[rowIndex].Cells[0].AppendChild(wu.Document.newParagraph(table.Document, curStep.StepIndex + ""));
                                        table.Rows[rowIndex].Cells[1].AppendChild(wu.Document.newParagraph(table.Document, curStep.StepTime + ""));

                                        List<Paragraph> resultList = wu.Document.getParagraphListWithNewLine(table.Document, resultStr);
                                        foreach (Paragraph p in resultList)
                                        {
                                            if (p.HasChildNodes)
                                            {
                                                if (((Run)p.ChildNodes[0]).GetText() != null && ((Run)p.ChildNodes[0]).GetText().Contains("完成内容及阶段目标:"))
                                                {
                                                    ((Run)p.ChildNodes[0]).Font.Bold = true;
                                                }
                                                else if (((Run)p.ChildNodes[0]).GetText() != null && ((Run)p.ChildNodes[0]).GetText().Contains("阶段成果、考核指标及考核方式:"))
                                                {
                                                    ((Run)p.ChildNodes[0]).Font.Bold = true;
                                                }
                                                else if (((Run)p.ChildNodes[0]).GetText() != null && ((Run)p.ChildNodes[0]).GetText().Contains("阶段经费:"))
                                                {
                                                    ((Run)p.ChildNodes[0]).Font.Bold = true;
                                                }
                                            }
                                        }
                                        wu.Document.addRangeToNodeCollection(table.Rows[rowIndex].Cells[2].ChildNodes, resultList);

                                        rowIndex++;
                                    }
                                }
                            }

                            //调整行距
                            foreach (Aspose.Words.Tables.Row r in table.Rows)
                            {
                                foreach (Aspose.Words.Tables.Cell c in r.Cells)
                                {
                                    foreach (Node n in c.ChildNodes)
                                    {
                                        if (n is Paragraph)
                                        {
                                            ((Paragraph)n).ParagraphFormat.LineSpacingRule = LineSpacingRule.Multiple;
                                            ((Paragraph)n).ParagraphFormat.LineSpacing = 12;
                                        }
                                    }
                                }
                            }

                            break;
                        }
                    }

                    //课题
                    foreach (Aspose.Words.Tables.Table table in ncc)
                    {
                        if (table.Range.Text.Contains("第一阶段：X月"))
                        {
                            //填充行和列
                            //int rowCount = ketiList.Count + 1;
                            int rowCount = ketiList.Count;
                            int colCount = projectStepList.Count;
                            //table.Select();

                            Aspose.Words.Tables.Row topRowObj = table.Rows[0];
                            Aspose.Words.Tables.Row rowObj = table.Rows[1];
                            Aspose.Words.Tables.Cell topCellObj = topRowObj.Cells[topRowObj.Cells.Count - 1];
                            Aspose.Words.Tables.Cell cellObj = rowObj.Cells[topRowObj.Cells.Count - 1];
                            for (int f = 0; f < colCount - 1; f++)
                            {
                                topRowObj.Cells.Add((Aspose.Words.Tables.Cell)topCellObj.Clone(true));
                                rowObj.Cells.Add((Aspose.Words.Tables.Cell)cellObj.Clone(true));
                            }
                            for (int t = 0; t < rowCount - 1; t++)
                            {
                                Aspose.Words.Tables.Row row = (Aspose.Words.Tables.Row)table.Rows[table.Rows.Count - 1].Clone(true);
                                table.Rows.Add(row);
                            }

                            //创建列标题
                            int colIndex = 1;
                            foreach (Step step in projectStepList)
                            {
                                table.Rows[0].Cells[colIndex].RemoveAllChildren();
                                table.Rows[0].Cells[colIndex].AppendChild(wu.Document.newParagraph(table.Document, "阶段" + step.StepIndex + "(" + step.StepTime + "个月)"));
                                ((Run)((Paragraph)table.Rows[0].Cells[colIndex].ChildNodes[0]).ChildNodes[0]).Font.Name = "黑体";
                                //table.Cell(1, colIndex).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                colIndex++;
                            }

                            //创建数据
                            int rowIndex = 1;
                            foreach (KeyValuePair<string, Project> kvp in ketiMap)
                            {
                                if (kvp.Key == "项目")
                                {
                                    continue;
                                }

                                int totalMoney = 0;
                                //获取并填冲数据
                                int dataColIndex = 1;
                                List<Step> curStepList = ConnectionManager.Context.table("Step").where("ProjectID = '" + kvp.Value.ID + "'").select("*").getList<Step>(new Step());
                                foreach (Step curStep in curStepList)
                                {
                                    ProjectAndStep curProjectAndStep = ConnectionManager.Context.table("ProjectAndStep").where("StepID = '" + curStep.ID + "'").select("*").getItem<ProjectAndStep>(new ProjectAndStep());

                                    //输出格式
                                    string outputFormat = "完成内容及阶段目标:\n{0}\n阶段成果、考核指标及考核方式:\n{1}\n阶段经费:{2}万";

                                    string resultStr = string.Empty;
                                    //阶段数据
                                    if (kvp.Key == "项目")
                                    {
                                        resultStr = string.Format(outputFormat, curStep.StepDest, curStep.StepResult, curStep.StepMoney);
                                    }
                                    else
                                    {
                                        resultStr = string.Format(outputFormat, curProjectAndStep.StepDest, curProjectAndStep.StepResult, curProjectAndStep.Money);

                                        //计算总金额
                                        totalMoney += (int)curProjectAndStep.Money;
                                    }

                                    table.Rows[rowIndex].Cells[dataColIndex].RemoveAllChildren();

                                    List<Paragraph> resultList = wu.Document.getParagraphListWithNewLine(table.Document, resultStr);
                                    foreach (Paragraph p in resultList)
                                    {
                                        if (p.HasChildNodes)
                                        {
                                            if (((Run)p.ChildNodes[0]).GetText() != null && ((Run)p.ChildNodes[0]).GetText().Contains("完成内容及阶段目标:"))
                                            {
                                                ((Run)p.ChildNodes[0]).Font.Bold = true;
                                            }
                                            else if (((Run)p.ChildNodes[0]).GetText() != null && ((Run)p.ChildNodes[0]).GetText().Contains("阶段成果、考核指标及考核方式:"))
                                            {
                                                ((Run)p.ChildNodes[0]).Font.Bold = true;
                                            }
                                            else if (((Run)p.ChildNodes[0]).GetText() != null && ((Run)p.ChildNodes[0]).GetText().Contains("阶段经费:"))
                                            {
                                                ((Run)p.ChildNodes[0]).Font.Bold = true;
                                            }
                                        }
                                    }
                                    wu.Document.addRangeToNodeCollection(table.Rows[rowIndex].Cells[dataColIndex].ChildNodes, resultList);

                                    dataColIndex++;
                                }

                                //行标题
                                if (kvp.Key != "项目")
                                {
                                    table.Rows[rowIndex].Cells[0].RemoveAllChildren();
                                    table.Rows[rowIndex].Cells[0].AppendChild(wu.Document.newParagraph(table.Document, kvp.Key + "(" + totalMoney + "万)"));
                                }
                                else
                                {
                                    table.Rows[rowIndex].Cells[0].RemoveAllChildren();
                                    table.Rows[rowIndex].Cells[0].AppendChild(wu.Document.newParagraph(table.Document, kvp.Key));
                                }

                                rowIndex++;
                            }

                            //调整行距
                            foreach (Aspose.Words.Tables.Row r in table.Rows)
                            {
                                foreach (Aspose.Words.Tables.Cell c in r.Cells)
                                {
                                    foreach (Node n in c.ChildNodes)
                                    {
                                        if (n is Paragraph)
                                        {
                                            ((Paragraph)n).ParagraphFormat.LineSpacingRule = LineSpacingRule.Multiple;
                                            ((Paragraph)n).ParagraphFormat.LineSpacing = 12;
                                        }
                                    }
                                }
                            }

                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                #endregion

                Report(progressDialog, 60, "写入课题负责人及研究骨干信息...", 1000);

                wu.Document.WordDocBuilder.Font.Size = 12;
                wu.Document.WordDocBuilder.Font.Name = "仿宋_GB2312";

                #region 插入课题负责人及研究骨干情况表
                try
                {
                    NodeCollection ncc = wu.Document.WordDoc.GetChildNodes(Aspose.Words.NodeType.Table, true);
                    foreach (Aspose.Words.Tables.Table table in ncc)
                    {
                        if (table.Range.Text.Contains("年投入"))
                        {
                            //获得课题与研究骨干关系表
                            List<Task> taskList = ConnectionManager.Context.table("Task").where("ProjectID in (select ID from Project where ParentID = '" + pt.projectObj.ID + "') or ProjectID='" + pt.projectObj.ID + "'").orderBy("DisplayOrder").select("*").getList<Task>(new Task());

                            //生成行和列
                            int rowCount = taskList.Count;
                            //table.Select();
                            for (int k = 0; k < rowCount - 1; k++)
                            {
                                table.Rows.Add((Aspose.Words.Tables.Row)table.Rows[table.Rows.Count - 1].Clone(true));
                            }

                            //填冲数据
                            int rowIndex = 1;
                            foreach (Task curTask in taskList)
                            {
                                #region 提取人员信息
                                Project taskKeti = ConnectionManager.Context.table("Project").where("ID='" + curTask.ProjectID + "'").select("*").getItem<Project>(new Project());
                                Person person = ConnectionManager.Context.table("Person").where("ID='" + curTask.PersonID + "'").select("*").getItem<Person>(new Person());
                                Unit unit = ConnectionManager.Context.table("Unit").where("ID='" + person.UnitID + "'").select("*").getItem<Unit>(new Unit());
                                #endregion

                                table.Rows[rowIndex].Cells[0].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[1].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[2].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[3].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[4].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[5].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[6].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[7].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[8].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[9].RemoveAllChildren();

                                table.Rows[rowIndex].Cells[0].AppendChild(wu.Document.newParagraph(table.Document, rowIndex.ToString()));
                                table.Rows[rowIndex].Cells[1].AppendChild(wu.Document.newParagraph(table.Document, person.Name));
                                table.Rows[rowIndex].Cells[2].AppendChild(wu.Document.newParagraph(table.Document, person.Sex));
                                table.Rows[rowIndex].Cells[3].AppendChild(wu.Document.newParagraph(table.Document, person.Job));
                                table.Rows[rowIndex].Cells[4].AppendChild(wu.Document.newParagraph(table.Document, person.Specialty));
                                table.Rows[rowIndex].Cells[5].AppendChild(wu.Document.newParagraph(table.Document, unit.UnitName));
                                table.Rows[rowIndex].Cells[6].AppendChild(wu.Document.newParagraph(table.Document, curTask.TotalTime.ToString()));
                                table.Rows[rowIndex].Cells[7].AppendChild(wu.Document.newParagraph(table.Document, curTask.Content));
                                table.Rows[rowIndex].Cells[8].AppendChild(wu.Document.newParagraph(table.Document, person.IDCard));

                                string KetiInProject = string.Empty;
                                foreach (KeyValuePair<string, Project> kvp in ketiMap)
                                {
                                    if (kvp.Value.ID == curTask.ProjectID)
                                    {
                                        KetiInProject = kvp.Key + curTask.Role;
                                        break;
                                    }
                                }
                                table.Rows[rowIndex].Cells[9].AppendChild(wu.Document.newParagraph(table.Document, KetiInProject));

                                rowIndex++;
                            }

                            //调整行距
                            foreach (Aspose.Words.Tables.Row r in table.Rows)
                            {
                                foreach (Aspose.Words.Tables.Cell c in r.Cells)
                                {
                                    foreach (Node n in c.ChildNodes)
                                    {
                                        if (n is Paragraph)
                                        {
                                            ((Paragraph)n).ParagraphFormat.LineSpacingRule = LineSpacingRule.Exactly;
                                            ((Paragraph)n).ParagraphFormat.LineSpacing = 14;
                                        }
                                    }
                                }
                            }

                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                #endregion

                Report(progressDialog, 70, "写入经费预算...", 1000);

                wu.Document.WordDocBuilder.Font.Size = 12;
                wu.Document.WordDocBuilder.Font.Name = "仿宋_GB2312";

                #region 插入经费预算表
                try
                {
                    ProjectBudgetInfo pbinfo = MoneyTableEditor.GetBudgetInfoObject(pt.projectObj.ID);
                    if (pbinfo != null)
                    {
                        wu.insertValue("本项目申请经费", pbinfo.ProjectRFA + "");
                        wu.insertValue("本项目自筹经费", pbinfo.ProjectZiChouJingFei + "");

                        string bookmark = "ProjectRFAs";
                        object obj4 = pbinfo.ProjectRFA;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA";
                        wu.insertValue(bookmark, obj4 + "万");
                        bookmark = "ProjectRFA1";
                        obj4 = pbinfo.ProjectRFA1;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_1";
                        obj4 = pbinfo.ProjectRFA1_1;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_1_1";
                        obj4 = pbinfo.ProjectRFA1_1_1;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_1_2";
                        obj4 = pbinfo.ProjectRFA1_1_2;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_1_3";
                        obj4 = pbinfo.ProjectRFA1_1_3;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_2";
                        obj4 = pbinfo.ProjectRFA1_2;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_3";
                        obj4 = pbinfo.ProjectRFA1_3;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_3_1";
                        obj4 = pbinfo.ProjectRFA1_3_1;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_3_2";
                        obj4 = pbinfo.ProjectRFA1_3_2;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_4";
                        obj4 = pbinfo.ProjectRFA1_4;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_5";
                        obj4 = pbinfo.ProjectRFA1_5;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_6";
                        obj4 = pbinfo.ProjectRFA1_6;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_7";
                        obj4 = pbinfo.ProjectRFA1_7;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_8";
                        obj4 = pbinfo.ProjectRFA1_8;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_9";
                        obj4 = pbinfo.ProjectRFA1_9;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA2";
                        obj4 = pbinfo.ProjectRFA2;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA2_1";
                        obj4 = pbinfo.ProjectRFA2_1;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectOutlay1";
                        obj4 = pbinfo.Projectoutlay1;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectOutlay2";
                        obj4 = pbinfo.Projectoutlay2;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectOutlay3";
                        obj4 = pbinfo.Projectoutlay3;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectOutlay4";
                        obj4 = pbinfo.Projectoutlay4;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectOutlay5";
                        obj4 = pbinfo.Projectoutlay5;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFARm";
                        obj4 = pbinfo.ProjectRFArm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1Rm";
                        obj4 = pbinfo.ProjectRFA1rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_1Rm";
                        obj4 = pbinfo.ProjectRFA1_1rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_1_1Rm";
                        obj4 = pbinfo.ProjectRFA1_1_1rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_1_2Rm";
                        obj4 = pbinfo.ProjectRFA1_1_2rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_1_3Rm";
                        obj4 = pbinfo.ProjectRFA1_1_3rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_2Rm";
                        obj4 = pbinfo.ProjectRFA1_2rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_3Rm";
                        obj4 = pbinfo.ProjectRFA1_3rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_3_1Rm";
                        obj4 = pbinfo.ProjectRFA1_3_1rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_3_2Rm";
                        obj4 = pbinfo.ProjectRFA1_3_2rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_4Rm";
                        obj4 = pbinfo.ProjectRFA1_4rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_5Rm";
                        obj4 = pbinfo.ProjectRFA1_5rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_6Rm";
                        obj4 = pbinfo.ProjectRFA1_6rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_7Rm";
                        obj4 = pbinfo.ProjectRFA1_7rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_8Rm";
                        obj4 = pbinfo.ProjectRFA1_8rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_9Rm";
                        obj4 = pbinfo.ProjectRFA1_9rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA2Rm";
                        obj4 = pbinfo.ProjectRFA2rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA2_1Rm";
                        obj4 = pbinfo.ProjectRFA2_1rm;
                        wu.insertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                #endregion

                Report(progressDialog, 75, "写入联系方式...", 1000);

                wu.Document.WordDocBuilder.Font.Size = 12;
                wu.Document.WordDocBuilder.Font.Name = "仿宋_GB2312";

                #region 插入联系方式
                try
                {
                    NodeCollection ncc = wu.Document.WordDoc.GetChildNodes(Aspose.Words.NodeType.Table, true);
                    foreach (Aspose.Words.Tables.Table table in ncc)
                    {
                        if (table.Range.Text.Contains("各课题联系方式"))
                        {
                            int titleIndex = table.Rows.Count - 1;
                            int dataIndex = table.Rows.Count - 1;

                            //构造联系方式行
                            int rowCountt = (ketiList.Count * 3) - 1;
                            for (int k = 0; k < rowCountt; k++)
                            {
                                //table.Select();
                                table.Rows.Add((Aspose.Words.Tables.Row)table.Rows[table.Rows.Count - 1].Clone(true));
                            }
                            //合并单元格
                            if (rowCountt >= 2)
                            {
                                for (int k = 0; k < ketiList.Count; k++)
                                {
                                    //计算开始位置
                                    int rowStart = dataIndex + (k * 3);
                                    int rowEnd = rowStart + 2;

                                    #region 写入标签
                                    table.Rows[rowStart].Cells[0].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[0].AppendChild(wu.Document.newParagraph(table.Document, "课题" + chsNumbers[(k + 1)]));
                                    ((Run)((Paragraph)table.Rows[rowStart].Cells[0].ChildNodes[0]).ChildNodes[0]).Font.Name = "黑体";
                                    //table.Rows[rowStart].Cells[1).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[1).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart].Cells[1].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[1].AppendChild(wu.Document.newParagraph(table.Document, "负责人"));
                                    ((Paragraph)table.Rows[rowStart].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                                    ((Run)((Paragraph)table.Rows[rowStart].Cells[1].ChildNodes[0]).ChildNodes[0]).Font.Name = "宋体";
                                    ((Run)((Paragraph)table.Rows[rowStart].Cells[1].ChildNodes[0]).ChildNodes[0]).Font.Size = 10.5;

                                    //table.Rows[rowStart].Cells[2).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart].Cells[3].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[3].AppendChild(wu.Document.newParagraph(table.Document, "性别"));
                                    ((Paragraph)table.Rows[rowStart].Cells[3].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                                    ((Run)((Paragraph)table.Rows[rowStart].Cells[3].ChildNodes[0]).ChildNodes[0]).Font.Name = "宋体";
                                    ((Run)((Paragraph)table.Rows[rowStart].Cells[3].ChildNodes[0]).ChildNodes[0]).Font.Size = 10.5;
                                    //table.Rows[rowStart].Cells[4).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[4).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart].Cells[5].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[5].AppendChild(wu.Document.newParagraph(table.Document, "出生年月"));
                                    ((Paragraph)table.Rows[rowStart].Cells[5].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                                    ((Run)((Paragraph)table.Rows[rowStart].Cells[5].ChildNodes[0]).ChildNodes[0]).Font.Name = "宋体";
                                    ((Run)((Paragraph)table.Rows[rowStart].Cells[5].ChildNodes[0]).ChildNodes[0]).Font.Size = 10.5;
                                    //table.Rows[rowStart].Cells[6).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[6).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart + 1].Cells[1].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[1].AppendChild(wu.Document.newParagraph(table.Document, "职务职称"));
                                    ((Paragraph)table.Rows[rowStart + 1].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                                    ((Run)((Paragraph)table.Rows[rowStart + 1].Cells[1].ChildNodes[0]).ChildNodes[0]).Font.Name = "宋体";
                                    ((Run)((Paragraph)table.Rows[rowStart + 1].Cells[1].ChildNodes[0]).ChildNodes[0]).Font.Size = 10.5;
                                    //table.Rows[rowStart + 1].Cells[2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[2).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart + 1].Cells[3].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[3].AppendChild(wu.Document.newParagraph(table.Document, "技术方向"));
                                    ((Paragraph)table.Rows[rowStart + 1].Cells[3].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                                    ((Run)((Paragraph)table.Rows[rowStart + 1].Cells[3].ChildNodes[0]).ChildNodes[0]).Font.Name = "宋体";
                                    ((Run)((Paragraph)table.Rows[rowStart + 1].Cells[3].ChildNodes[0]).ChildNodes[0]).Font.Size = 10.5;
                                    //table.Rows[rowStart + 1].Cells[4).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[4).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart + 1].Cells[5].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[5].AppendChild(wu.Document.newParagraph(table.Document, "手机"));
                                    ((Paragraph)table.Rows[rowStart + 1].Cells[5].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                                    ((Run)((Paragraph)table.Rows[rowStart + 1].Cells[5].ChildNodes[0]).ChildNodes[0]).Font.Name = "宋体";
                                    ((Run)((Paragraph)table.Rows[rowStart + 1].Cells[5].ChildNodes[0]).ChildNodes[0]).Font.Size = 10.5;
                                    //table.Rows[rowStart + 1].Cells[6).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[6).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart + 2].Cells[1].RemoveAllChildren();
                                    wu.Document.addRangeToNodeCollection(table.Rows[rowStart + 2].Cells[1].ChildNodes, wu.Document.getParagraphListWithNewLine(table.Document, "承担单位\n及通信地址"));
                                    ((Paragraph)table.Rows[rowStart + 2].Cells[1].ChildNodes[0]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                                    ((Paragraph)table.Rows[rowStart + 2].Cells[1].ChildNodes[1]).ParagraphFormat.Alignment = ParagraphAlignment.Center;
                                    ((Run)((Paragraph)table.Rows[rowStart + 2].Cells[1].ChildNodes[0]).ChildNodes[0]).Font.Name = "宋体";
                                    ((Run)((Paragraph)table.Rows[rowStart + 2].Cells[1].ChildNodes[0]).ChildNodes[0]).Font.Size = 10.5;
                                    ((Run)((Paragraph)table.Rows[rowStart + 2].Cells[1].ChildNodes[0]).ChildNodes[0]).Font.Name = "宋体";
                                    ((Run)((Paragraph)table.Rows[rowStart + 2].Cells[1].ChildNodes[0]).ChildNodes[0]).Font.Size = 10.5;
                                    //table.Cell(rowStart + 2, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Cell(rowStart + 2, 2).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    #endregion

                                    #region 写入实际数据
                                    Project proj = ketiList[k];
                                    Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + proj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                                    Task taskObj = ConnectionManager.Context.table("Task").where("ProjectID = '" + proj.ID + "' and Type='课题' and Role='负责人'").select("*").getItem<Task>(new Task());
                                    Person personObj = ConnectionManager.Context.table("Person").where("ID ='" + taskObj.PersonID + "'").select("*").getItem<Person>(new Person());

                                    table.Rows[rowStart].Cells[2].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[2].AppendChild(wu.Document.newParagraph(table.Document, personObj.Name));
                                    //table.Rows[rowStart].Cells[3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[3).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart].Cells[4].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[4].AppendChild(wu.Document.newParagraph(table.Document, personObj.Sex));
                                    //table.Rows[rowStart].Cells[5).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[5).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart].Cells[6].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[6].AppendChild(wu.Document.newParagraph(table.Document, personObj.Birthday != null ? personObj.Birthday.Value.ToString("yyyy-MM-dd") : string.Empty));
                                    //table.Rows[rowStart].Cells[7).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[7).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart + 1].Cells[2].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[2].AppendChild(wu.Document.newParagraph(table.Document, personObj.Job));
                                    //table.Rows[rowStart + 1].Cells[3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[3).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart + 1].Cells[4].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[4].AppendChild(wu.Document.newParagraph(table.Document, personObj.Specialty));
                                    //table.Rows[rowStart + 1].Cells[5).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[5).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart + 1].Cells[6].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[6].AppendChild(wu.Document.newParagraph(table.Document, personObj.MobilePhone));
                                    //table.Rows[rowStart + 1].Cells[7).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[7).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart + 2].Cells[2].RemoveAllChildren();
                                    table.Rows[rowStart + 2].Cells[2].AppendChild(wu.Document.newParagraph(table.Document, unitObj.UnitName + "," + unitObj.Address));
                                    //table.Cell(rowStart + 2, 3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Cell(rowStart + 2, 3).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    #endregion

                                    //合并单元格
                                    wu.Document.mergeCells(table.Rows[rowEnd].Cells[2], table.Rows[rowEnd].Cells[6], table);
                                    wu.Document.mergeCells(table.Rows[rowStart].Cells[0], table.Rows[rowEnd].Cells[0], table);
                                }
                            }
                            else
                            {
                                table.Rows[titleIndex].Remove();
                                table.Rows[dataIndex].Remove();
                            }

                            //调整行距
                            foreach (Aspose.Words.Tables.Row r in table.Rows)
                            {
                                foreach (Aspose.Words.Tables.Cell c in r.Cells)
                                {
                                    foreach (Node n in c.ChildNodes)
                                    {
                                        if (n is Paragraph)
                                        {
                                            ((Paragraph)n).ParagraphFormat.LineSpacingRule = LineSpacingRule.Multiple;
                                            ((Paragraph)n).ParagraphFormat.LineSpacing = 12;
                                        }
                                    }
                                }
                            }

                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
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
                string docFile = Path.Combine(pt.dataDir, "项目申报书.doc");
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