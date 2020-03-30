using PublicReporterLib;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ProjectReporterPlugin.Controls;
using ProjectReporterPlugin.DB;
using ProjectReporterPlugin.DB.Entitys;
using ProjectReporterPlugin.Editor;
using ProjectReporterPlugin.Forms;
using ProjectReporterPlugin.Utility;
using AbstractEditorPlugin.Editor;

namespace ProjectReporterPlugin
{
    public class NewPluginRoot : AbstractEditorPlugin.AbstractPluginRoot
    {
        public const string button1_Name = "新建项目";
        public const string button2_Name = "生成报告";
        public const string button3_Name = "导出数据包";
        public const string button4_Name = "数据包管理";
        public const string button5_Name = "帮助";

        public NewPluginRoot()
            : base()
        {
            defaultSplitterDistance = 235;
        }

        public override string DefaultTitle
        {
            get { return "重点基础研究项目建议书信息填报系统（1.4.2版）"; }
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
            TreeNode firstNode = new TreeNode();
            firstNode.Name = "root";
            firstNode.Text = "申报书";

            TreeNode itemObj = new TreeNode();
            itemObj.Text = "概述";
            firstNode.Nodes.Add(itemObj);

            TreeNode subItemObj = new TreeNode();
            subItemObj.Text = "项目摘要";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "基本概念及内涵";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "军事需求分析";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "研究现状";
            itemObj.Nodes.Add(subItemObj);

            itemObj = new TreeNode();
            itemObj.Text = "研究目标";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "基础性问题";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "项目分解";
            firstNode.Nodes.Add(itemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "课题列表";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "课题之间的关系";
            itemObj.Nodes.Add(subItemObj);

            itemObj = new TreeNode();
            itemObj.Text = "研究成果";
            firstNode.Nodes.Add(itemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "研究成果及考核指标";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "评估方案";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "预期效益";
            itemObj.Nodes.Add(subItemObj);

            itemObj = new TreeNode();
            itemObj.Text = "研究周期、阶段划分和经费安排";
            firstNode.Nodes.Add(itemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "项目阶段划分和经费安排";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "课题阶段划分和经费安排";
            itemObj.Nodes.Add(subItemObj);

            itemObj = new TreeNode();
            itemObj.Text = "项目负责人和研究团队";
            firstNode.Nodes.Add(itemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "项目负责人";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "研究团队";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "各课题负责人及研究骨干情况表";
            itemObj.Nodes.Add(subItemObj);

            itemObj = new TreeNode();
            itemObj.Text = "研究基础与保障条件";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "组织实施与风险控制";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "与有关计划关系";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "经费预算表";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "附件1-经费概算";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "附件2-保密资质";
            firstNode.Nodes.Add(itemObj);

            Parent_LeftTreeView.Nodes.Add(firstNode);

            firstNode.ExpandAll();
        }

        /// <summary>
        /// 初始化编辑器
        /// </summary>
        public override void initEditorMaps()
        {
            #region 初始化编辑器Map
            editorMap.Add("项目摘要", new TextContentEditor("项目摘要", "一般以文字形式表述，不配图、不列公式，要求内容精炼，限1500字以内", 999999999));
            editorMap.Add("基本概念及内涵", new DocumentPasteEditor("基本概念及内涵", "简要介绍相关研究对象的基本概念及内涵等", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("军事需求分析", new DocumentPasteEditor("军事需求分析", "分析本项目有关军事需求背景，提出面临的困难和瓶颈问题等", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("研究现状", new DocumentPasteEditor("研究现状", "全面客观地论述国内与国外研究现状，重点聚焦与本项目核心问题相关的技术研究情况其中包括研究水平、差距与不足等，注重定量描述，避免泛泛而谈", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("研究目标", new DocumentPasteEditor("研究目标", "凝练提出项目研究目标，表述需明确、具体、准确，避免过于笼统。", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("基础性问题", new DocumentPasteEditor("基础性问题", "围绕项目研究目标，突出国防基础研究的任务特点，梳理提出本项目需要重点研究解决的基础性问题(简要描述每个问题，200字以内)", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("课题之间的关系", new DocumentPasteEditor("课题之间的关系", "基础性问题与课题之间的关系、各课题之间的关系（简要叙述，建议1000字之内，可用图表示）", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("研究成果及考核指标", new DocumentPasteEditor("研究成果及考核指标", "分类逐项列出研究成果及考核指标。研究成果形式包括演示试验/验证系统 、样机、样品/样件、理论、标准/规范、数据库/软件、工程工艺等。指标体系应系统完整。", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("评估方案", new DocumentPasteEditor("评估方案", "围绕课题的研究成果及考核指标，提出具体的评估方案。可考虑通过国标、检测机构、企业标准测量、实验等多种方法，具体落实各项指标的评测。对可能影响指标评测结果的各种边界因素条件，均应明确说明，避免理解歧义。", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("预期效益", new DocumentPasteEditor("预期效益", "简要描述该项目研究成果得到应用后，对解决国防科技现实瓶颈问题和支撑未来技术发展方面的预期支撑作用。", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("项目负责人", new TextContentEditor("项目负责人", "介绍项目负责人的职务职称、受教育情况、履历，代表性论文、专著、专利、奖励、人才计划资助情况，以及近五年主持的相关国家科技计划项目情况，限800字以内。要求实事求是填报，有关信息纳入科研诚信评价体系。", 999999999));
            editorMap.Add("研究基础与保障条件", new DocumentPasteEditor("研究基础与保障条件", "已有研究基础和软硬件保障条件，包括国家研究中心、国家重点实验室、国家工程（技术）中心等，以及自筹经费情况，800字以内", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("组织实施与风险控制", new DocumentPasteEditor("组织实施与风险控制", "对本项目可能存在的技术和管理风险进行分析，提出思路举措，500字以内", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("与有关计划关系", new DocumentPasteEditor("与有关计划关系", "介绍与本项目研究内容相关的国家和军队各类科技计划安排情况，对本项目与有关计划安排的界面关系进行说明。", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("课题列表", new SubjectTableEditor());
            editorMap.Add("申报书", new ProjectEditor());
            editorMap.Add("项目阶段划分和经费安排", new ProjectStepMoneyEditor());
            editorMap.Add("课题阶段划分和经费安排", new SubjectStepMoneyEditor());
            editorMap.Add("研究团队", new ProjectWorkerGroupEditor());
            editorMap.Add("各课题负责人及研究骨干情况表", new ProjectWorkerInfoEditor());
            editorMap.Add("经费预算表", new MoneyTableEditor());
            editorMap.Add("附件1-经费概算", new MoneySummaryEditor());
            editorMap.Add("附件2-保密资质", new ConfidentialQualificationEditor());
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
                        if (isUsingDir(dataDir, true))
                        {
                            MessageBox.Show("对不起，新建失败，可能是您打开了某些文件或目录没有关闭！");
                        }
                        else
                        {
                            try
                            {
                                //新建项目
                                rebuildProject("");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("对不起，请检查您是否打开了某个word文件或目录没有关闭，然后重试！");
                            }
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

                    if (isUsingDir(dataDir, true))
                    {
                        MessageBox.Show("对不起，生成报告失败，可能是您打开了某些文件或目录没有关闭！");
                    }
                    else
                    {
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
                    }
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
            Project proj = (Project)projectObj;
            string unitName = ConnectionManager.Context.table("Unit").where("ID = (select UnitID from Project where ID = '" + projectObj.ID + "')").select("UnitName").getValue<string>(string.Empty);
            string personName = ConnectionManager.Context.table("Person").where("ID=(select PersonID from Task where Role = '负责人' and  ProjectID = '" + projectObj.ID + "')").select("Name").getValue<string>(string.Empty);

            if (proj.DirectionCode == 0)
            {
                //方向代码为0,忽略此项,然后生成压缩包名
                return proj.Domain + "-" + proj.Name + "-" + unitName + "-" + personName;
            }
            else
            {
                //生成完整的压缩包名
                string directionCode = proj.DirectionCode.ToString();
                if (proj.DirectionCode < 10)
                {
                    directionCode = "0" + directionCode;
                }
                return proj.Domain + "-" + directionCode + "-" + proj.Name + "-" + unitName + "-" + personName;
            }
        }

        /// <summary>
        /// 新建工程
        /// </summary>
        public override bool rebuildProject(string projName)
        {
            string ddDir = Path.Combine(RootDir, "Data");
            DirectoryInfo destProjectDir = new DirectoryInfo(Path.Combine(ddDir, Guid.NewGuid().ToString() + "_" + DateTime.Now.Ticks));

            if (projectObj != null && !string.IsNullOrEmpty(((Project)projectObj).ID))
            {
                //创建一个空目录
                try
                {
                    destProjectDir.Create();
                }
                catch (Exception ex) { }

                try
                {
                    //切换到这个目录，并备份当前目录
                    switchProject(destProjectDir.Name);
                }
                catch (Exception ex)
                {
                    Directory.Delete(destProjectDir.FullName, true);

                    throw ex;
                }
            }
            else
            {
                //检查前先关闭数据库
                closeDB();

                //检查后打开数据库
                openDB();
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
                string projId = projectObj != null ? ((Project)projectObj).ID : Guid.NewGuid().ToString();

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

                    if (projectObj != null)
                    {
                        System.IO.Directory.Move(currentPath, destPath);
                    }
                    else
                    {
                        System.IO.Directory.Delete(currentPath, true);
                    }
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
                projectObj = ConnectionManager.Context.table("Project").where("Type='" + "项目" + "'").select("*").getItem<Project>(new Project());

                if (string.IsNullOrEmpty(getProjectObject<Project>().ID))
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

        /// <summary>
        /// 判断一个目录是否正在使用
        /// </summary>
        /// <param name="pkgPath"></param>
        /// <param name="isExcludeDB"></param>
        /// <returns></returns>
        public override bool isUsingDir(string pkgPath, bool isExcludeDB)
        {
            List<string> excludeList = new List<string>();
            if (isExcludeDB)
            {
                excludeList.Add(Path.Combine(pkgPath, "static.db"));
            }

            return GlobalTool.isDirUsingWithAll(pkgPath, excludeList);
        }
    }
}