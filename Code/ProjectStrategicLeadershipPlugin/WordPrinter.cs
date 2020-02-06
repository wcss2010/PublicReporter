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

                //课题附件头
                string subjectFileHeadString = ProjectStrategicLeadershipPlugin.Editor.SubjectDetailEditor.SubjectFileFlag + "_";

                #region 生成----(研究内容_概述列表)
                StringBuilder sb = new StringBuilder();
                int subIndex = 0;
                foreach (Subjects sub in subjectList)
                {
                    subIndex++;
                    string subFlag = "内容" + GlobalTool.NumberToChinese(subIndex.ToString());
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
                #endregion

                #region 生成----(*人员表)
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