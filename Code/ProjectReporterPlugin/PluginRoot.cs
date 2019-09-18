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

namespace ProjectReporterPlugin
{
    public class PluginRoot : IReportPluginRoot
    {
        /// <summary>
        /// 当前项目
        /// </summary>
        public Project projectObj = null;

        /// <summary>
        /// 编辑器字典
        /// </summary>
        public CustomDictionary<string, BaseEditor> editorMap = new CustomDictionary<string, BaseEditor>();

        /// <summary>
        /// 基础目录
        /// </summary>
        public string baseDir = string.Empty;

        /// <summary>
        /// 数据目录
        /// </summary>
        public string dataDir = string.Empty;

        /// <summary>
        /// 文件目录
        /// </summary>
        public string filesDir = string.Empty;

        /// <summary>
        /// 是否显示关闭提示
        /// </summary>
        public bool enabledShowExitHint = true;

        /// <summary>
        /// 程序标题
        /// </summary>
        public override string DefaultTitle
        {
            get { return "重点基础研究项目建议书填报系统（1.3版）"; }
        }

        /// <summary>
        /// 是否允许关闭
        /// </summary>
        /// <returns></returns>
        public override bool isAcceptClose()
        {
            return true;
        }

        /// <summary>
        /// 失败
        /// </summary>
        public override void stop(FormClosingEventArgs e)
        {
            if (e != null && enabledShowExitHint)
            {
                if (MessageBox.Show("真的要退出吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    #region 清理所有增加的内容
                    if (Parent_RightContentPanel.IsHandleCreated)
                    {
                        Parent_RightContentPanel.Invoke(new MethodInvoker(delegate()
                            {
                                Parent_LeftTreeViewImageList.Images.Clear();
                                Parent_LeftTreeView.Nodes.Clear();
                                Parent_RightContentPanel.Controls.Clear();
                                Parent_BottomDefaultHintLabel.Text = string.Empty;

                                List<ToolStripItem> list = new List<ToolStripItem>();
                                foreach (ToolStripItem tsi in Parent_TopToolStrip.Items)
                                {
                                    if (tsi.Tag == "Dynamic")
                                    {
                                        list.Add(tsi);
                                    }
                                }
                                foreach (ToolStripItem tssi in list)
                                {
                                    Parent_TopToolStrip.Items.Remove(tssi);
                                }
                            }));
                    }
                    #endregion
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                #region 清理所有增加的内容
                if (Parent_RightContentPanel.IsHandleCreated)
                {
                    Parent_RightContentPanel.Invoke(new MethodInvoker(delegate()
                    {
                        Parent_LeftTreeViewImageList.Images.Clear();
                        Parent_LeftTreeView.Nodes.Clear();
                        Parent_RightContentPanel.Controls.Clear();
                        Parent_BottomDefaultHintLabel.Text = string.Empty;

                        List<ToolStripItem> list = new List<ToolStripItem>();
                        foreach (ToolStripItem tsi in Parent_TopToolStrip.Items)
                        {
                            if (tsi.Tag == "Dynamic")
                            {
                                list.Add(tsi);
                            }
                        }
                        foreach (ToolStripItem tssi in list)
                        {
                            Parent_TopToolStrip.Items.Remove(tssi);
                        }
                    }));
                }
                #endregion
            }
        }

        /// <summary>
        /// 插件初始化
        /// </summary>
        /// <param name="mainFormObj">主窗体</param>
        /// <param name="topToolStripObj">顶部工具条控件</param>
        /// <param name="Parent_LeftTreeViewImageList">左边的树控件图标列表</param>
        /// <param name="Parent_LeftTreeView">左边的树控件</param>
        /// <param name="treeViewControlObj">左边的树控件下面的控制面板</param>
        /// <param name="Parent_RightContentPanel">右边的内容面板</param>
        /// <param name="bottomStatusStripObj">底部状态栏</param>
        /// <param name="defaultHintLabelObj">默认的提示标签</param>
        public override void start()
        {
            //添加点击事件
            this.Parent_LeftTreeView.AfterSelect += treeViewObj_AfterSelect;

            #region 构建树结构
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
            #endregion

            #region 创建基础目录
            baseDir = Path.Combine(RootDir, "Data");
            try
            {
                Directory.CreateDirectory(baseDir);
            }
            catch (Exception ex) { }
            #endregion

            #region 创建数据目录
            dataDir = Path.Combine(baseDir, "Current");
            try
            {
                Directory.CreateDirectory(dataDir);
            }
            catch (Exception ex) { }
            #endregion

            #region 创建文件目录
            filesDir = Path.Combine(dataDir, "Files");
            try
            {
                Directory.CreateDirectory(filesDir);
            }
            catch (Exception ex) { }
            #endregion

            //初始化DB
            initDB();

            //初始化按钮
            initButtons(Parent_TopToolStrip);

            //初始化编辑控件
            initEditors();

            //加载工程对象
            try
            {
                //加载项目信息
                projectObj = ConnectionManager.Context.table("Project").where("Type='" + "项目" + "'").select("*").getItem<Project>(new Project());

                if (string.IsNullOrEmpty(projectObj.ID))
                {
                    //项目数据清空
                    projectObj = null;

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
        /// 初始化ID
        /// </summary>
        private void initDB()
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
                FileOp.CopyDirectory(Path.Combine(RootDir, Path.Combine("DataTemplete", "Current")), Path.Combine(RootDir, Path.Combine("Data", "Current")), true);

                //打开数据库连接
                ConnectionManager.Open(dbFile);
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
        /// 初始化编辑器列表
        /// </summary>
        private void initEditors()
        {
            #region 初始化文档编辑器
            editorMap.Add("项目摘要", new TextContentEditor("项目摘要", "一般以文字形式表述，不配图、不列公式，要求内容精炼，限1500字以内"));
            editorMap.Add("基本概念及内涵", new DocumentPasteEditor("基本概念及内涵", "简要介绍相关研究对象的基本概念及内涵等"));
            editorMap.Add("军事需求分析", new DocumentPasteEditor("军事需求分析", "分析本项目有关军事需求背景，提出面临的困难和瓶颈问题等"));
            editorMap.Add("研究现状", new DocumentPasteEditor("研究现状", "全面客观地论述国内与国外研究现状，重点聚焦与本项目核心问题相关的技术研究情况其中包括研究水平、差距与不足等，注重定量描述，避免泛泛而谈"));
            editorMap.Add("研究目标", new DocumentPasteEditor("研究目标", "凝练提出项目研究目标，表述需明确、具体、准确，避免过于笼统。"));
            editorMap.Add("基础性问题", new DocumentPasteEditor("基础性问题", "围绕项目研究目标，突出国防基础研究的任务特点，梳理提出本项目需要重点研究解决的基础性问题(简要描述每个问题，200字以内)"));
            editorMap.Add("课题之间的关系", new DocumentPasteEditor("课题之间的关系", "基础性问题与课题之间的关系、各课题之间的关系（简要叙述，建议1000字之内，可用图表示）"));
            editorMap.Add("研究成果及考核指标", new DocumentPasteEditor("研究成果及考核指标", "分类逐项列出研究成果及考核指标。研究成果形式包括研究报告、试验（测试）方案、试验（测试）结果分析报告、样品、样机、试验（验证）系统、数据库、软件、工程工艺、标准（规范）等。指标体系应系统完整。"));
            editorMap.Add("评估方案", new DocumentPasteEditor("评估方案", "围绕课题的研究成果及考核指标，提出具体的评估方案。可考虑通过国标、检测机构、企业标准测量、实验等多种方法，具体落实各项指标的评测。对可能影响指标评测结果的各种边界因素条件，均应明确说明，避免理解歧义。"));
            editorMap.Add("预期效益", new DocumentPasteEditor("预期效益", "简要描述该项目研究成果得到应用后，对解决国防科技现实瓶颈问题和支撑未来技术发展方面的预期支撑作用。"));
            editorMap.Add("项目负责人", new TextContentEditor("项目负责人", "介绍项目负责人的职务职称、受教育情况、履历，代表性论文、专著、专利、奖励、人才计划资助情况，以及近五年主持的相关国家科技计划项目情况，限800字以内。要求实事求是填报，有关信息纳入科研诚信评价体系。"));            
            editorMap.Add("研究基础与保障条件", new DocumentPasteEditor("研究基础与保障条件", "已有研究基础和软硬件保障条件，包括国家研究中心、国家重点实验室、国家工程（技术）中心等，以及自筹经费情况，800字以内"));
            editorMap.Add("组织实施与风险控制", new DocumentPasteEditor("组织实施与风险控制", "对本项目可能存在的技术和管理风险进行分析，提出思路举措，500字以内"));
            editorMap.Add("与有关计划关系", new DocumentPasteEditor("与有关计划关系", "介绍与本项目研究内容相关的国家和军队各类科技计划安排情况，对本项目与有关计划安排的界面关系进行说明。"));
            #endregion

            #region 初始化其它的编辑器
            editorMap.Add("申报书", new ProjectEditor());
            editorMap.Add("课题列表", new SubjectTableEditor());
            editorMap.Add("项目阶段划分和经费安排", new ProjectStepMoneyEditor());
            editorMap.Add("课题阶段划分和经费安排", new SubjectStepMoneyEditor());
            editorMap.Add("研究团队", new ProjectWorkerGroupEditor());
            editorMap.Add("各课题负责人及研究骨干情况表", new ProjectWorkerInfoEditor());
            editorMap.Add("经费预算表", new MoneyTableEditor());
            editorMap.Add("附件1-经费概算", new MoneySummaryEditor());
            editorMap.Add("附件2-保密资质", new ConfidentialQualificationEditor());
            #endregion

            //检查哪个Editor没有设置Name
            foreach (KeyValuePair<string, BaseEditor> kvp in editorMap)
            {
                if (string.IsNullOrEmpty(kvp.Value.EditorName))
                {
                    kvp.Value.EditorName = kvp.Key;
                }
            }
        }

        /// <summary>
        /// 初始化按钮
        /// </summary>
        /// <param name="Parent_TopToolStrip"></param>
        private void initButtons(ToolStrip Parent_TopToolStrip)
        {
            ToolStripButton tempButton = null;

            tempButton = getTopButton(Resource.help, "btnHelp", "帮助", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            Parent_TopToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(Resource.export, "btnExport", "导出", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            Parent_TopToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(Resource.word, "btnWordView", "预览", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            Parent_TopToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(Resource.import, "btnLoad", "导入", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            Parent_TopToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(Resource.w5, "btnNew", "新建", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            Parent_TopToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(Resource._new, "btnSaveAll", "保存所有", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            Parent_TopToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(Resource.manager, "btnManager", "项目管理", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            Parent_TopToolStrip.Items.Insert(0, tempButton);
        }

        /// <summary>
        /// 按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tempButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = ((ToolStripButton)sender);
            switch (button.Text)
            {
                case "保存所有":
                    if (projectObj == null)
                    {
                        MessageBox.Show("对不起，请先填写项目信息，然后再继续！");
                        return;
                    }

                    saveAllWithNoResult();
                    break;
                case "帮助":
                    FrmHelpBox helpForm = new FrmHelpBox();
                    helpForm.ShowDialog();
                    break;
                case "导出":
                    if (projectObj == null)
                    {
                        MessageBox.Show("对不起，请先填写项目信息，然后再继续！");
                        return;
                    }

                    if (isSaveAllSucess() == false)
                    {
                        MessageBox.Show("对不起，保存失败，请检查！");
                        return;
                    }

                    if (File.Exists(Path.Combine(dataDir, "项目申报书.doc")) == false)
                    {
                        MessageBox.Show("对不起，请先点击预览按钮生成项目申报书！");
                        return;
                    }

                    string errorPage = string.Empty;
                    if (!isInputCompleted(ref errorPage))
                    {
                        MessageBox.Show("对不起，内容未填写完不能上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show("请将页签[" + errorPage + "]填写完整再点击上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (!isRightMoneyOrTime())
                    {
                        return;
                    }

                    string unitName = ConnectionManager.Context.table("Unit").where("ID = (select UnitID from Project where ID = '" + projectObj.ID + "')").select("UnitName").getValue<string>(string.Empty);
                    string personName = ConnectionManager.Context.table("Person").where("ID=(select PersonID from Task where Role = '负责人' and  ProjectID = '" + projectObj.ID + "')").select("Name").getValue<string>(string.Empty);
                    string zipName = string.Empty;
                    if (projectObj.DirectionCode == 0)
                    {
                        //方向代码为0,忽略此项,然后生成压缩包名
                        zipName = projectObj.Domain + "-" + projectObj.Name + "-" + unitName + "-" + personName;
                    }
                    else
                    {
                        //生成完整的压缩包名
                        string directionCode = projectObj.DirectionCode.ToString();
                        if (projectObj.DirectionCode < 10)
                        {
                            directionCode = "0" + directionCode;
                        }
                        zipName = projectObj.Domain + "-" + directionCode + "-" + projectObj.Name + "-" + unitName + "-" + personName;
                    }

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "ZIP申报包|*.zip";
                    sfd.FileName = zipName;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (MessageBox.Show("真的要导出吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CircleProgressBarDialog dialoga = new CircleProgressBarDialog();
                            dialoga.TransparencyKey = dialoga.BackColor;
                            dialoga.ProgressBar.ForeColor = Color.Red;
                            dialoga.MessageLabel.ForeColor = Color.Blue;
                            dialoga.FormBorderStyle = FormBorderStyle.None;
                            dialoga.Start(new EventHandler<CircleProgressBarEventArgs>(delegate(object thisObject, CircleProgressBarEventArgs argss)
                            {
                                ((CircleProgressBarDialog)thisObject).ReportProgress(10, 100);
                                ((CircleProgressBarDialog)thisObject).ReportInfo("准备导出...");
                                try { System.Threading.Thread.Sleep(1000); }
                                catch (Exception ex) { }

                                //关闭连接
                                DB.ConnectionManager.Close();

                                //当前项目目录
                                string currentPath = System.IO.Path.Combine(System.IO.Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().RootDir, "Data"), "Current");

                                ((CircleProgressBarDialog)thisObject).ReportProgress(20, 100);
                                ((CircleProgressBarDialog)thisObject).ReportInfo("正在导出...");
                                try { System.Threading.Thread.Sleep(1000); }
                                catch (Exception ex) { }

                                //压缩
                                PublicReporterLib.Utility.ZipUtil zu = new PublicReporterLib.Utility.ZipUtil();
                                zu.ZipFileDirectory(currentPath, sfd.FileName);

                                ((CircleProgressBarDialog)thisObject).ReportProgress(90, 100);
                                ((CircleProgressBarDialog)thisObject).ReportInfo("导出完成，准备重启...");
                                try { System.Threading.Thread.Sleep(1000); }
                                catch (Exception ex) { }

                                //重启软件
                                PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().enabledShowExitHint = false;
                                DB.ConnectionManager.Close();
                                System.Diagnostics.Process.Start(Application.ExecutablePath);
                                PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().projectObj = null;
                                Application.Exit();
                            }));
                        }
                    }
                    break;
                case "预览":
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
                    }
            ));
                    break;
                case "导入":
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "ZIP申报包|*.zip";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (MessageBox.Show("真的要导入吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CircleProgressBarDialog dialogb = new CircleProgressBarDialog();
                            dialogb.TransparencyKey = dialogb.BackColor;
                            dialogb.ProgressBar.ForeColor = Color.Red;
                            dialogb.MessageLabel.ForeColor = Color.Blue;
                            dialogb.FormBorderStyle = FormBorderStyle.None;
                            dialogb.Start(new EventHandler<CircleProgressBarEventArgs>(delegate(object thisObject, CircleProgressBarEventArgs argss)
                                {
                                    ((CircleProgressBarDialog)thisObject).ReportProgress(10, 100);
                                    ((CircleProgressBarDialog)thisObject).ReportInfo("准备导入...");
                                    try { System.Threading.Thread.Sleep(1000); }
                                    catch (Exception ex) { }

                                    string uuid = projectObj != null ? projectObj.ID : string.Empty;

                                    //关闭连接
                                    DB.ConnectionManager.Close();

                                    //当前项目目录
                                    string currentPath = System.IO.Path.Combine(System.IO.Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().RootDir, "Data"), "Current");

                                    //backup
                                    string backupPath = System.IO.Path.Combine(System.IO.Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().RootDir, "Data"), uuid);

                                    ((CircleProgressBarDialog)thisObject).ReportProgress(20, 100);
                                    ((CircleProgressBarDialog)thisObject).ReportInfo("清空当前目录...");
                                    try { System.Threading.Thread.Sleep(1000); }
                                    catch (Exception ex) { }

                                    //检查是否需要备份
                                    if (uuid != null && uuid.Length >= 2)
                                    {
                                        //移动backupDir
                                        if (System.IO.Directory.Exists(backupPath))
                                        {
                                            System.IO.Directory.Delete(backupPath, true);
                                        }
                                        //备份当前
                                        System.IO.Directory.Move(currentPath, backupPath);
                                    }
                                    else
                                    {
                                        //直接删除Current
                                        if (System.IO.Directory.Exists(currentPath))
                                        {
                                            System.IO.Directory.Delete(currentPath, true);
                                        }
                                    }

                                    ((CircleProgressBarDialog)thisObject).ReportProgress(30, 100);
                                    ((CircleProgressBarDialog)thisObject).ReportInfo("创建导入目录...");
                                    try { System.Threading.Thread.Sleep(1000); }
                                    catch (Exception ex) { }

                                    //创建当前目录
                                    try
                                    {
                                        Directory.CreateDirectory(currentPath);
                                    }
                                    catch (Exception ex) { }

                                    ((CircleProgressBarDialog)thisObject).ReportProgress(40, 100);
                                    ((CircleProgressBarDialog)thisObject).ReportInfo("正在导入...");
                                    try { System.Threading.Thread.Sleep(1000); }
                                    catch (Exception ex) { }

                                    //解压
                                    PublicReporterLib.Utility.ZipUtil zu = new PublicReporterLib.Utility.ZipUtil();
                                    zu.UnZipFile(ofd.FileName, currentPath, string.Empty, true);

                                    ((CircleProgressBarDialog)thisObject).ReportProgress(90, 100);
                                    ((CircleProgressBarDialog)thisObject).ReportInfo("导入完成，准备重启...");
                                    try { System.Threading.Thread.Sleep(1000); }
                                    catch (Exception ex) { }

                                    //重启软件
                                    PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().enabledShowExitHint = false;
                                    DB.ConnectionManager.Close();
                                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                                    PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().projectObj = null;
                                    Application.Exit();

                                }));
                        }
                    }
                    break;
                case "新建":
                    if (MessageBox.Show("真的要新建吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //关闭连接
                        DB.ConnectionManager.Close();

                        //当前项目目录
                        string currentPath = System.IO.Path.Combine(System.IO.Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().RootDir, "Data"), "Current");

                        //移动当前目录
                        if (System.IO.Directory.Exists(currentPath))
                        {
                            System.IO.Directory.Delete(currentPath, true);
                        }

                        PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().enabledShowExitHint = false;
                        DB.ConnectionManager.Close();
                        System.Diagnostics.Process.Start(Application.ExecutablePath);
                        PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().projectObj = null;
                        Application.Exit();
                    }
                    break;
                case "项目管理":
                    FrmProjectManager manager = new FrmProjectManager();
                    manager.ShowDialog();
                    break;
            }
        }

        /// <summary>
        /// 检查时间与金额一致性
        /// </summary>
        /// <returns></returns>
        private bool isRightMoneyOrTime()
        {
            //项目总时间
            int totalTime = ConnectionManager.Context.table("Project").where("Type = '项目'").select("TotalTime").getValue<int>(0);

            //项目总金额
            decimal totalMoney = ConnectionManager.Context.table("Project").where("Type = '项目'").select("TotalMoney").getValue<decimal>(0);

            //经费表总额
            string projectMoneyStr = ConnectionManager.Context.table("MoneyAndYear").where("Name = 'ProjectRFA'").select("Value").getValue<string>("0");
            decimal projectMoney = 0;
            try
            {
                projectMoney = decimal.Parse(projectMoneyStr);
            }
            catch (Exception ex) { }

            //阶段总额
            long totalStepMoney = ConnectionManager.Context.table("Step").where("ProjectID = '" + projectObj.ID + "'").select("sum(StepMoney)").getValue<long>(0);

            //阶段总时间
            long totalStepTime = (long)Math.Round(ConnectionManager.Context.table("Step").where("ProjectID = '" + projectObj.ID + "'").select("sum(StepTime)").getValue<long>(0) / 12d);

            //课题阶段经费总额
            long totalKetiStepMoney = ConnectionManager.Context.table("ProjectAndStep").where("StepID in (select ID from Step where ProjectID in (select ID from Project where Type = '课题'))").select("sum(Money)").getValue<long>(0);

            //阶段经费表
            Noear.Weed.DataList dlStepList = ConnectionManager.Context.table("Step").where("ProjectID = '" + projectObj.ID + "'").select("StepIndex,StepMoney").getDataList();

            //课题阶段经费表
            int totalRightStepCount = 0;
            int totalStepCount = 0;
            if (dlStepList != null && dlStepList.getRowCount() >= 1)
            {
                //阶段数量
                totalStepCount = dlStepList.getRowCount();

                //检查课题阶段金额
                foreach (Noear.Weed.DataItem di in dlStepList.getRows())
                {
                    try
                    {
                        int stepIndex = di.getInt("StepIndex");
                        long stepMoney = long.Parse(di.get("StepMoney").ToString());
                        long subjectStepMoney = ConnectionManager.Context.table("ProjectAndStep").where("StepID in (select ID from Step where ProjectID in (select ID from Project where Type = '课题') and StepIndex = " + stepIndex + ")").select("sum(Money)").getValue<long>(0);

                        //判断阶段经费是不是相等
                        if (stepMoney == subjectStepMoney)
                        {
                            totalRightStepCount++;
                        }
                    }
                    catch (Exception ex) { }
                }
            }

            if (totalMoney != projectMoney)
            {
                MessageBox.Show("对不起，项目总金额与经费表总金额不同，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (totalMoney != totalStepMoney)
            {
                MessageBox.Show("对不起，项目总金额与阶段总金额不同，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (totalMoney != totalKetiStepMoney)
            {
                MessageBox.Show("对不起，项目总金额与课题阶段总金额不同，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (totalTime != totalStepTime)
            {
                MessageBox.Show("对不起，项目总时间与阶段总时间不同，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (totalRightStepCount != totalStepCount)
            {
                MessageBox.Show("对不起，阶段金额与课题阶段金额不同，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //判断条件是否符合
            return totalMoney == projectMoney && totalMoney == totalStepMoney && totalMoney == totalKetiStepMoney && totalTime == totalStepTime && totalRightStepCount == totalStepCount;
        }

        /// <summary>
        /// 保存所有编辑器
        /// </summary>
        private void saveAllWithNoResult()
        {
            if (projectObj != null)
            {
                CircleProgressBarDialog dialoga = new CircleProgressBarDialog();
                dialoga.TransparencyKey = dialoga.BackColor;
                dialoga.ProgressBar.ForeColor = Color.Red;
                dialoga.MessageLabel.ForeColor = Color.Blue;
                dialoga.FormBorderStyle = FormBorderStyle.None;
                dialoga.MessageLabel.Text = "正在保存,请等待...";
                dialoga.Start(new EventHandler<CircleProgressBarEventArgs>(delegate(object thisObject, CircleProgressBarEventArgs argss)
                {
                    //创建一个倒叙列表用于解决因为保存顺序问题导致的某些列表项保存失败的BUG
                    List<BaseEditor> tempLists = new List<BaseEditor>();
                    tempLists.AddRange(editorMap.Values);
                    tempLists.Reverse();
                    
                    if (((CircleProgressBarDialog)thisObject).IsHandleCreated)
                    {
                        ((CircleProgressBarDialog)thisObject).Invoke(new MethodInvoker(delegate()
                        {
                            //循环所有控件，一个一个保存
                            int currentIndex = 0;
                            foreach (BaseEditor be in tempLists)
                            {
                                currentIndex++;

                                //保存
                                try
                                {
                                    be.OnSaveEvent();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("对不起，页签(" + be.EditorName + ")保存失败！Ex:" + ex.ToString());
                                }

                                //进度条移动
                                ((CircleProgressBarDialog)thisObject).ReportProgress((int)(((double)currentIndex / (double)tempLists.Count) * 100), 100);

                                //立即执行消息
                                Application.DoEvents();
                            }
                        }));
                    }
                    
                    //刷新
                    if (((CircleProgressBarDialog)thisObject).IsHandleCreated)
                    {
                        ((CircleProgressBarDialog)thisObject).Invoke(new MethodInvoker(delegate()
                        {
                            refreshEditors();
                        }));
                    }
                }));
            }
        }

        /// <summary>
        /// 保存所有(返回是否成功)
        /// </summary>
        public bool isSaveAllSucess()
        {
            if (projectObj != null)
            {
                bool isSucesss = true;

                Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
                upf.LabalText = "正在保存,请等待...";
                upf.ShowProgressWithOnlyUI();
                upf.PlayProgressWithOnlyUI(80);

                try
                {
                    //创建一个倒叙列表用于解决因为保存顺序问题导致的某些列表项保存失败的BUG
                    List<BaseEditor> tempLists = new List<BaseEditor>();
                    tempLists.AddRange(editorMap.Values);
                    tempLists.Reverse();

                    //循环所有控件，一个一个保存
                    foreach (BaseEditor be in tempLists)
                    {
                        //保存
                        try
                        {
                            be.OnSaveEvent();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("对不起，页签(" + be.EditorName + ")保存失败！Ex:" + ex.ToString());
                            isSucesss = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败！Ex:" + ex.ToString());
                }
                finally
                {
                    upf.CloseProgressWithOnlyUI();
                }

                return isSucesss;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否输入完成
        /// </summary>
        /// <returns></returns>
        public bool isInputCompleted(ref string errorPageName)
        {
            foreach (BaseEditor be in editorMap.Values)
            {
                if (be.IsInputCompleted())
                {
                    continue;
                }
                else
                {
                    errorPageName = be.EditorName;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 生成按钮对象
        /// </summary>
        /// <param name="imgg"></param>
        /// <param name="nameg"></param>
        /// <param name="textg"></param>
        /// <param name="sizeg"></param>
        /// <returns></returns>
        protected ToolStripButton getTopButton(Image imgg, string nameg, string textg, Size sizeg)
        {
            ToolStripButton tempButton = new ToolStripButton();
            tempButton.Font = new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tempButton.Image = imgg;
            tempButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            tempButton.Name = nameg;
            tempButton.Size = sizeg;
            tempButton.Text = textg;
            tempButton.Tag = "Dynamic";
            tempButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            return tempButton;
        }

        void treeViewObj_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (projectObj == null || string.IsNullOrEmpty(projectObj.ID))
            {
                //因为项目信息为空，所以锁定在项目信息页
                Parent_LeftTreeView.SelectedNode = Parent_LeftTreeView.Nodes[Parent_LeftTreeView.Nodes.Count - 1];
                showEditor(Parent_LeftTreeView.SelectedNode.Text);
                Parent_BottomDefaultHintLabel.Text = "请填写完整项目信息......";
            }
            else
            {
                showEditor(e.Node.Text);
                Parent_BottomDefaultHintLabel.Text = "";
            }
        }

        /// <summary>
        /// 显示编辑器
        /// </summary>
        /// <param name="nodeTexts"></param>
        private void showEditor(string nodeTexts)
        {
            if (editorMap.ContainsKey(nodeTexts))
            {
                Parent_RightContentPanel.Controls.Clear();
                editorMap[nodeTexts].Dock = DockStyle.Fill;
                Parent_RightContentPanel.Controls.Add(editorMap[nodeTexts]);
            }
        }

        /// <summary>
        /// 刷新编辑器
        /// </summary>
        public void refreshEditors()
        {
            if (projectObj != null)
            {
                foreach (BaseEditor be in editorMap.Values)
                {
                    be.RefreshView();
                }
            }
        }
    }
}