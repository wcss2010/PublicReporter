using AbstractEditorPlugin;
using AbstractEditorPlugin.Editor;
using AbstractEditorPlugin.Forms;
using AbstractEditorPlugin.Utility;
using ProjectStrategicLeadershipPlugin.DB;
using ProjectStrategicLeadershipPlugin.DB.Entitys;
using ProjectStrategicLeadershipPlugin.Forms;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjectStrategicLeadershipPlugin
{
    public class PluginRoot : AbstractEditorPlugin.AbstractPluginRoot
    {
        public const string button1_Name = "新建项目";
        public const string button2_Name = "生成报告";
        public const string button3_Name = "导出数据包";
        public const string button4_Name = "数据包管理";
        public const string button5_Name = "帮助";

        public const string tnode_0_Name = "基本信息";
        public const string tnode_1_Name = "项目摘要";
        public const string tnode_2_Name = "概述";
        public const string tnode_2_0_Name = "需求分析";
        public const string tnode_2_1_Name = "研究现状";
        public const string tnode_3_Name = "研究目标";
        public const string tnode_4_Name = "研究内容";
        public const string tnode_5_Name = "研究成果";
        public const string tnode_5_0_Name = "成果内容";
        public const string tnode_5_1_Name = "成果服务方式";
        public const string tnode_6_Name = "研究周期与进度安排 ";
        public const string tnode_7_Name = "研究基础与保障条件";
        public const string tnode_8_Name = "项目负责人和研究团队";
        public const string tnode_8_0_Name = "项目负责人";
        public const string tnode_8_1_Name = "研究团队";
        public const string tnode_8_2_Name = "主要成员情况表";
        public const string tnode_9_Name = "经费预算表";
        public const string tnode_10_Name = "附件1-项目经费预算说明";
        public const string tnode_11_Name = "附件2-保密资质复印件";
        public const string tnode_12_Name = "联系方式";

        public PluginRoot()
            : base()
        {
            defaultSplitterDistance = 235;
        }

        public override string DefaultTitle
        {
            get { return "国防科技战略先导计划项目建议书填报系统(V1.0)"; }
        }

        /// <summary>
        /// 初始化目录
        /// </summary>
        public override void initDirs()
        {
            baseDir = Path.Combine(RootDir, "Data");
            try
            {
                Directory.CreateDirectory(baseDir);
            }
            catch (Exception ex) { }
            dataDir = Path.Combine(baseDir, "Current");
            try
            {
                Directory.CreateDirectory(dataDir);
            }
            catch (Exception ex) { }
            filesDir = Path.Combine(dataDir, "Files");
            try
            {
                Directory.CreateDirectory(filesDir);
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 打开数据库
        /// </summary>
        public override void openDB()
        {
            //数据库文件
            string dbFile = Path.Combine(dataDir, "static.db");

            //判断是否可以打开数据库
            if (File.Exists(dbFile))
            {
                //打开数据库连接
                ConnectionManager.Open(dbFile);
            }
            else
            {
                //复制DataTemplete中的Current到Data中
                FileOp.copyDirectory(Path.Combine(RootDir, Path.Combine("DataTemplete", "Current")), Path.Combine(RootDir, Path.Combine("Data", "Current")), true);

                //打开数据库连接
                ConnectionManager.Open(dbFile);
            }
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        public override void closeDB()
        {
            ConnectionManager.Close();
        }

        /// <summary>
        /// 初始化树节点
        /// </summary>
        public override void initTrees()
        {
            TreeNode rootNode = new TreeNode(tnode_0_Name);
            rootNode.Nodes.Add(new TreeNode(tnode_1_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_2_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_2_0_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_2_1_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_3_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_4_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_5_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_5_0_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_5_1_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_6_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_7_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_8_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_8_0_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_8_1_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_8_2_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_9_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_12_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_10_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_11_Name));

            Parent_LeftTreeView.Nodes.Add(rootNode);
            rootNode.ExpandAll();
        }

        /// <summary>
        /// 初始化编辑器
        /// </summary>
        public override void initEditorMaps()
        {
            #region 初始化编辑器Map
            //基本信息(需要一个自定义输入界面)
            editorMap[tnode_0_Name] = new Editor.SummaryEditor();
            //项目摘要(TextContentEditor)
            editorMap[tnode_1_Name] = new DocumentPasteEditor("项目摘要", "简要介绍研究问题提出的国防科技发展背景或需求来源，简述项目研究目标与研究内容，拟采取的研究思路与研究方法，拟使用的主要数据资源，以及主要预期成果（名称、形式、数量、指标等）、成果服务方式等。（限1000字以内）", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile());
            //一、概述(不需要显示内容)
            //editorMap[tnode_2_Name] = null;
            //（一）需求分析(DocumentPasteEditor)
            editorMap[tnode_2_0_Name] = new DocumentPasteEditor("需求分析", "（简要介绍本项目的国防科技发展背景或需求来源，分析提出研究问题。） ", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile());
            //（二）研究现状(DocumentPasteEditor)
            editorMap[tnode_2_1_Name] = new DocumentPasteEditor("研究现状", "（客观简述国内外研究现状，重点聚焦与本项目核心问题相关的研究情况，注重定量描述，避免泛泛而谈） ", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile());
            //二、研究目标(DocumentPasteEditor)
            editorMap[tnode_3_Name] = new DocumentPasteEditor("研究目标", "（凝练提出项目研究目标，表述需明确、具体、准确，避免过于笼统。） ", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile());
            //三、研究内容(不需要显示内容)
            editorMap[tnode_4_Name] = new Editor.SubjectEditor();
            //四、研究成果(不需要显示内容)
            //editorMap[tnode_5_Name] = null;
            //（一）研究成果(DocumentPasteEditor)
            editorMap[tnode_5_0_Name] = new DocumentPasteEditor("研究成果", "分类逐项列出研究成果。研究成果形式包括但不限于研究报告、专报、刊物、模拟试验（仿真）结果、数据库、软件、标准（规范）等。", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile());
            //（二）成果服务方式(DocumentPasteEditor)
            editorMap[tnode_5_1_Name] = new DocumentPasteEditor("成果服务方式", "（简要描述该项目研究成果以何种方式、面向何种对象提供服务，预期可发挥何种支撑作用。） ", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile());
            //五、研究周期与进度安排(不需要显示内容)
            editorMap[tnode_6_Name] = new Editor.ProjectStepEditor();
            //六、研究基础与保障条件(DocumentPasteEditor)
            editorMap[tnode_7_Name] = new DocumentPasteEditor("研究基础与保障条件", "（介绍与本项目相关的，已开展过的工作、已有的研究基础和软硬件保障条件等，限800字以内。特别是属常态化、持续性研究项目，应重点说明与已立项战略先导计划项目之间的关系。） ", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile());
            //七、项目负责人和研究团队(不需要显示内容)
            //editorMap[tnode_8_Name] = null;
            //（一）、项目负责人(DocumentPasteEditor)
            editorMap[tnode_8_0_Name] = new DocumentPasteEditor("项目负责人", "（介绍项目负责人的职务职称、教育工作履历，主要学术成就、人才计划资助情况，以及近五年主持的相关国家科技计划项目情况，限800字以内。要求实事求是填报，有关信息纳入科研诚信评价体系。） ", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile());
            //（二）、研究团队(自定义列表)
            editorMap[tnode_8_1_Name] = new DocumentPasteEditor("研究团队", "简要介绍本项目除项目负责人外的各项研究内容负责人情况，包括职务职称、教育工作履历、主要学术成就、人才计划资助情况等，限500字以内。要求实事求是填报，有关信息纳入科研诚信评价体系。 ", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile());
            //（三）、主要成员情况表(自定义列表)
            editorMap[tnode_8_2_Name] = new Editor.WorkerEditor();
            //八、经费预算表(自定义列表)
            editorMap[tnode_9_Name] = new Editor.MoneyTableEditor();
            //九、联系方式
            editorMap[tnode_12_Name] = new Editor.MasterListEditor();
            //附件1-项目经费预算说明(DocumentPasteEditor-带特定模板)
            editorMap[tnode_10_Name] = new DocumentPasteEditor("项目经费预算说明", "（介绍本项目预算依据、内容构成、具体安排，应能够支撑对项目经费预算合理性进行审核评估） ", Path.Combine(RootDir, Path.Combine("Helper", "moneyPaste.doc")), getDocumentPasteReadmeFile());
            //附件2-保密资质复印件(DocumentPasteEditor-带特定模板)
            editorMap[tnode_11_Name] = new DocumentPasteEditor("保密资质复印件", "若该项目内容涉密，请申报单位提供与项目内容密级相应的保密资质复印件", Path.Combine(RootDir, Path.Combine("Helper", "secretPaste.doc")), getDocumentPasteReadmeFile2());
            #endregion

            #region 检查哪个Editor没有设置Name
            foreach (KeyValuePair<string, BaseEditor> kvp in editorMap)
            {
                //if (string.IsNullOrEmpty(kvp.Value.EditorName))
                //{
                kvp.Value.EditorName = kvp.Key;
                //}
            }
            #endregion
        }

        /// <summary>
        /// 生成一个工具条按钮
        /// </summary>
        /// <param name="imgg"></param>
        /// <param name="nameg"></param>
        /// <param name="textg"></param>
        /// <param name="sizeg"></param>
        /// <returns></returns>
        protected ToolStripButton getTopButton(Image imgg, string nameg, string textg, Size sizeg)
        {
            return getTopButton(imgg, nameg, textg, sizeg, new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
        }

        /// <summary>
        /// 添加顶部工具条按钮
        /// </summary>
        /// <param name="imgg"></param>
        /// <param name="nameg"></param>
        /// <param name="textg"></param>
        /// <param name="sizeg"></param>
        protected void addTopButton(Image imgg, string nameg, string textg, Size sizeg)
        {
            ToolStripButton tempButton = getTopButton(imgg, nameg, textg, sizeg);
            tempButton.Click += topButton_Click;
            addToTopToolStrip(tempButton);
        }

        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void topButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = ((ToolStripButton)sender);

            switch (button.Text)
            {
                case button1_Name:
                    #region 新建项目
                    if (MessageBox.Show("真的要新建吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //检查前先关闭数据库
                        closeDB();
                        if (AbstractEditorPlugin.Utility.GlobalTool.isDirUsingWithAll(dataDir))
                        {
                            //检查后打开数据库
                            openDB();

                            MessageBox.Show("对不起，新建失败，可能是您打开了某些文件或目录没有关闭！");
                        }
                        else
                        {
                            //新建项目
                            rebuildProject("");
                        }
                    }
                    #endregion
                    break;
                case button2_Name:
                    #region 生成报告
                    if (projectObj == null)
                    {
                        MessageBox.Show("对不起，请先填写项目信息，然后再继续！");
                        return;
                    }

                    CircleProgressBarDialog dialogc = new CircleProgressBarDialog();
                    dialogc.TransparencyKey = dialogc.BackColor;
                    dialogc.ProgressBar.ForeColor = Color.Red;
                    dialogc.MessageLabel.ForeColor = Color.Blue;
                    dialogc.FormBorderStyle = FormBorderStyle.None;
                    dialogc.Start(new EventHandler<CircleProgressBarEventArgs>(delegate(object thisObject, CircleProgressBarEventArgs argss)
                    {
                        //word预览
                        WordPrinter.wordOutput(((CircleProgressBarDialog)thisObject));
                    }));
                    #endregion
                    break;
                case button3_Name:
                    #region 导出数据包
                    if (projectObj == null)
                    {
                        MessageBox.Show("对不起，请先填写项目信息，然后再继续！");
                        return;
                    }

                    //最后更新日期
                    DateTime dtLastUpdateDate = getLastUpdateDate();

                    if (isSaveAllSucess() == false)
                    {
                        MessageBox.Show("对不起，保存失败，请检查！");
                        return;
                    }

                    string docFile = Path.Combine(dataDir, WordPrinter.outputDocFileName);
                    if (File.Exists(docFile) == false)
                    {
                        MessageBox.Show("对不起，请先点击\"生成报告\"按钮生成\"" + WordPrinter.outputDocFileName + "\"！");
                        return;
                    }

                    DateTime dtDoc = File.GetLastWriteTime(docFile);
                    if (dtLastUpdateDate > dtDoc)
                    {
                        MessageBox.Show("对不起，当前的\"" + WordPrinter.outputDocFileName + "\"不是最新的，请点击\"生成报告\"按钮重新生成\"" + WordPrinter.outputDocFileName + "\"！");
                        return;
                    }

                    string errorPage = string.Empty;
                    if (!isInputCompleted(ref errorPage))
                    {
                        if (errorPage != tnode_11_Name)
                        {
                            MessageBox.Show("对不起，内容未填写完不能上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show("请将页签[" + errorPage + "]填写完整再点击上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    new FrmPkgExport().ShowDialog();
                    #endregion
                    break;
                case button4_Name:
                    #region 数据包管理
                    FrmProjectManager manager = new FrmProjectManager();
                    manager.ShowDialog();
                    #endregion
                    break;
                case button5_Name:
                    #region 帮助
                    FrmHelpBox helpBox = new FrmHelpBox(Path.Combine(RootDir, Path.Combine("Helper", "help.rtf")));
                    helpBox.ShowDialog();
                    #endregion
                    break;
            }
        }

        /// <summary>
        /// 获得新的导出包名字
        /// </summary>
        /// <returns></returns>
        public string getNewExportZipName()
        {
            Projects projObj = (Projects)projectObj;
            return projObj.ProjectName + "-" + projObj.UnitName + "-" + projObj.UnitContact + ".zip";
        }

        /// <summary>
        /// 新建工程
        /// </summary>
        public override bool rebuildProject(string projName)
        {
            string ddDir = Path.Combine(RootDir, "Data");
            DirectoryInfo destProjectDir = new DirectoryInfo(Path.Combine(ddDir, Guid.NewGuid().ToString() + "_" + DateTime.Now.Ticks));

            if (projectObj != null && !string.IsNullOrEmpty(((Projects)projectObj).ID))
            {
                //创建一个空目录
                try
                {
                    destProjectDir.Create();
                }
                catch (Exception ex) { }

                //切换到这个目录，并备份当前目录
                switchProject(destProjectDir.Name);
            }

            return true;
        }

        /// <summary>
        /// 切换工程
        /// </summary>
        /// <param name="projName"></param>
        /// <returns></returns>
        public override bool switchProject(string projName)
        {
            try
            {
                string ddDir = System.IO.Path.Combine(RootDir, "Data");

                //项目ID
                string projId = projectObj != null ? ((Projects)projectObj).ID : Guid.NewGuid().ToString();

                //临时目录名
                string tempDirName = projId + "_" + DateTime.Now.Ticks;

                //关闭连接
                closeDB();

                //当前项目目录
                string currentPath = System.IO.Path.Combine(ddDir, "Current");

                //目标目录
                string destPath = System.IO.Path.Combine(ddDir, tempDirName);

                //移动当前目录
                if (System.IO.Directory.Exists(currentPath))
                {
                    if (System.IO.Directory.Exists(destPath))
                    {
                        System.IO.Directory.Delete(destPath, true);
                    }

                    System.IO.Directory.Move(currentPath, destPath);
                }

                //将这个目录切换为当前目录
                System.IO.Directory.Move(System.IO.Path.Combine(ddDir, projName), currentPath);

                //重新载入工程
                reloadProject();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 导出数据包
        /// </summary>
        /// <param name="destPkgFile"></param>
        /// <returns></returns>
        public override bool exportTo(string destPkgFile)
        {
            try
            {
                //关闭连接
                closeDB();

                //当前项目目录
                string currentPath = Path.Combine(Path.Combine(RootDir, "Data"), "Current");

                //压缩
                new PublicReporterLib.Utility.ZipUtil().ZipFileDirectory(currentPath, destPkgFile);

                //打开数据库
                openDB();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 初始化顶部工具按钮
        /// </summary>
        public override void initTopToolBar()
        {
            //隐藏默认的分隔符
            hideSysSeparator();

            //新建项目
            addTopButton(Resource.w5, Guid.NewGuid().ToString(), button1_Name, new System.Drawing.Size(53, 56));

            //生成报告
            addTopButton(Resource.word, Guid.NewGuid().ToString(), button2_Name, new System.Drawing.Size(53, 56));

            //导出数据包
            addTopButton(Resource._new, Guid.NewGuid().ToString(), button3_Name, new System.Drawing.Size(53, 56));

            //添加分割符
            addToTopToolStrip(getTopSeparator());

            //数据包管理
            addTopButton(Resource.manager, Guid.NewGuid().ToString(), button4_Name, new System.Drawing.Size(53, 56));

            //添加分割符
            addToTopToolStrip(getTopSeparator());

            //帮助
            addTopButton(Resource.help, Guid.NewGuid().ToString(), button5_Name, new System.Drawing.Size(53, 56));

            //添加分割符
            addToTopToolStrip(getTopSeparator());
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public override void initData()
        {
            try
            {
                //加载项目信息
                projectObj = ConnectionManager.Context.table("Projects").select("*").getItem<Projects>(new Projects());

                if (string.IsNullOrEmpty(getProjectObject<Projects>().ID))
                {
                    //项目数据清空
                    projectObj = null;

                    //清空视图。。
                    for (int kkk = 0; kkk < editorMap.Count; kkk++)
                    {
                        editorMap[kkk].Value.clearView();
                    }

                    //切换到工程信息编辑器
                    switchToProjectEditor();
                }
                else
                {
                    //切换到内容页
                    switchToProjectContentEditor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("对不起，数据库加载失败！Ex:" + ex.ToString());
            }
        }

        /// <summary>
        /// 切换到内容页
        /// </summary>
        private void switchToProjectContentEditor()
        {
            Parent_LeftTreeView.SelectedNode = Parent_LeftTreeView.Nodes[Parent_LeftTreeView.Nodes.Count - 1];
            refreshEditors();
        }

        /// <summary>
        /// 切换到项目编辑页
        /// </summary>
        private void switchToProjectEditor()
        {
            Parent_LeftTreeView.SelectedNode = Parent_LeftTreeView.Nodes[Parent_LeftTreeView.Nodes.Count - 1];
        }

        /// <summary>
        /// 响应树切换
        /// </summary>
        /// <param name="treeNode"></param>
        protected override void switchCurrentEditor(System.Windows.Forms.TreeNode treeNode)
        {
            if (projectObj == null || string.IsNullOrEmpty(getProjectObject<Projects>().ID))
            {
                //因为项目信息为空，所以锁定在项目信息页
                Parent_LeftTreeView.SelectedNode = Parent_LeftTreeView.Nodes[Parent_LeftTreeView.Nodes.Count - 1];
                showEditor(Parent_LeftTreeView.SelectedNode.Text);
                Parent_BottomDefaultHintLabel.Text = "请填写完整项目信息......";
            }
            else
            {
                if (editorMap.ContainsKey(treeNode.Text))
                {
                    showEditor(treeNode.Text);
                    Parent_BottomDefaultHintLabel.Text = "";
                }
                else if (treeNode.Nodes.Count >= 1)
                {
                    Parent_LeftTreeView.SelectedNode = treeNode.Nodes[0];
                    showEditor(treeNode.Nodes[0].Text);
                    Parent_BottomDefaultHintLabel.Text = "";
                }
            }
        }

        /// <summary>
        /// 获得文档填报说明
        /// </summary>
        /// <returns></returns>
        public string getDocumentPasteReadmeFile()
        {
            return Path.Combine(RootDir, Path.Combine("Helper", "documentPasteReadme.rtf"));
        }

        /// <summary>
        /// 获得文档填报说明2
        /// </summary>
        /// <returns></returns>
        public string getDocumentPasteReadmeFile2()
        {
            return Path.Combine(RootDir, Path.Combine("Helper", "documentPasteReadme2.rtf"));
        }
    }
}