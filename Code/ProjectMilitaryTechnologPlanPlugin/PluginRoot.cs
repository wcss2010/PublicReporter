using PublicReporterLib;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ProjectMilitaryTechnologPlanPlugin.Controls;
using ProjectMilitaryTechnologPlanPlugin.DB;
using ProjectMilitaryTechnologPlanPlugin.DB.Entitys;
using ProjectMilitaryTechnologPlanPlugin.Editor;
using ProjectMilitaryTechnologPlanPlugin.Forms;
using ProjectMilitaryTechnologPlanPlugin.Utility;

namespace ProjectMilitaryTechnologPlanPlugin
{
    public class PluginRoot : IReportPluginRoot
    {
        /// <summary>
        /// 当前项目
        /// </summary>
        public JiBenXinXiBiao projectObj = null;

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
            get { return "全军军事理论科研计划项目论证报告系统（1.0版）"; }
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
                            clearAllControls();
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
                        clearAllControls();
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
        /// <param name="Parent_LeftTreeViewBottomButtonPanel">左边的树控件下面的控制面板</param>
        /// <param name="Parent_RightContentPanel">右边的内容面板</param>
        /// <param name="bottomStatusStripObj">底部状态栏</param>
        /// <param name="defaultHintLabelObj">默认的提示标签</param>
        public override void start()
        {
            //载入配置
            UIControlConfig.configFile = Path.Combine(RootDir, "config.cfg");
            UIControlConfig.loadConfig();

            //添加点击事件
            Parent_LeftTreeView.AfterSelect += treeViewObj_AfterSelect;

            //设置分割器位置
            foreach (Control c in Parent_Form.Controls)
            {
                if (c.Name == "scContent") 
                {
                    ((SplitContainer)c).SplitterDistance = 200;
                    break;
                }
            }

            #region 构建树结构
            TreeNode firstNode = new TreeNode();
            firstNode.Name = "root";
            firstNode.Text = "概述";

            TreeNode itemObj = new TreeNode();
            itemObj.Text = "基本信息";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "项目设计论证";
            firstNode.Nodes.Add(itemObj);

            TreeNode subItemObj = new TreeNode();
            subItemObj.Text = "研究状况及选题价值";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "总体框架和预期目标";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "研究思路和研究方法";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "重点难点和创新之处";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "研究进度和任务分工";
            itemObj.Nodes.Add(subItemObj);

            itemObj = new TreeNode();
            itemObj.Text = "研究经费";
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
            initButtons();

            //初始化编辑控件
            initEditors();

            //加载工程对象
            initProjects();
        }

        private void initProjects()
        {
            try
            {
                //加载项目信息
                projectObj = ConnectionManager.Context.table("JiBenXinXiBiao").select("*").getItem<JiBenXinXiBiao>(new JiBenXinXiBiao());

                if (string.IsNullOrEmpty(projectObj.BianHao))
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
            editorMap.Add("研究状况及选题价值", new DocumentPasteEditor("Docs_A", "1.国内外相关研究的学术史梳理或综述，特别是真实研究现状。\n2.对已有相关代表性成果及观点做出科学、客观、切实的分析评价，说明进一步探讨、发展或突破的空间，详细说明本选题相对于已有研究的独到价值和意义。"));
            editorMap.Add("总体框架和预期目标", new DocumentPasteEditor("Docs_B", "1.本项目研究的主要问题和内容，总体研究框架，框架各部分之间的内在逻辑关系。\n2.本项目研究在理论创新、实践应用、服务决策等方面的预期目标。"));
            editorMap.Add("研究思路和研究方法", new DocumentPasteEditor("Docs_C", "1.本项目的总体思路、研究视角和研究路径，具体阐明研究思路的科学性和可行性。\n2.针对本项目研究问题拟采用的具体研究方法、研究手段和技术路线，说明其适用性和可操作性。"));
            editorMap.Add("重点难点和创新之处", new DocumentPasteEditor("Docs_D", "1.本项目拟解决的关键性问题和重点难点问题，分别阐述提炼这些问题的理由和依据。\n2.本项目研究在问题选择、学术观点、研究方法、分析工具、文献资料等方面的突破、创新或推进之处。"));
            editorMap.Add("研究进度和任务分工", new DocumentPasteEditor("Docs_E", "1.本项目研究的实地调研（或实验）方案、资料文献搜集整理方案、总体进度安排和年度进展计划。\n2.牵头单位和参与单位具体任务分工和每年投入时间（月）。\n3.主要阶段性成果（各单位成果）和最终成果的名称、形式、字数等，成果出版或报送的方式和计划。"));

            ((DocumentPasteEditor)editorMap["研究状况及选题价值"]).InfoLabelAutoHeight = false;
            ((DocumentPasteEditor)editorMap["研究状况及选题价值"]).InfoLabelHeight += 12;

            ((DocumentPasteEditor)editorMap["总体框架和预期目标"]).InfoLabelAutoHeight = false;
            ((DocumentPasteEditor)editorMap["总体框架和预期目标"]).InfoLabelHeight += 10;

            ((DocumentPasteEditor)editorMap["研究思路和研究方法"]).InfoLabelAutoHeight = false;
            ((DocumentPasteEditor)editorMap["研究思路和研究方法"]).InfoLabelHeight += 10;

            ((DocumentPasteEditor)editorMap["重点难点和创新之处"]).InfoLabelAutoHeight = false;
            ((DocumentPasteEditor)editorMap["重点难点和创新之处"]).InfoLabelHeight += 10;

            ((DocumentPasteEditor)editorMap["研究进度和任务分工"]).InfoLabelAutoHeight = false;
            ((DocumentPasteEditor)editorMap["研究进度和任务分工"]).InfoLabelHeight += 30;
            #endregion

            #region 初始化其它的编辑器
            editorMap.Add("概述", new SummaryEditor());
            editorMap.Add("基本信息", new InfoEditor());
            editorMap.Add("研究经费", new MoneyTableEditor());
            #endregion

            #region 检查哪个Editor没有设置Name
            foreach (KeyValuePair<string, BaseEditor> kvp in editorMap)
            {
                if (string.IsNullOrEmpty(kvp.Value.EditorName))
                {
                    kvp.Value.EditorName = kvp.Key;
                }
            }
            #endregion
        }

        /// <summary>
        /// 初始化按钮
        /// </summary>
        /// <param name="Parent_TopToolStrip"></param>
        private void initButtons()
        {
            ToolStripButton tempButton = null;

            tempButton = getTopButton(Resource.manager, "btnManager", "项目管理", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            addToTopToolStrip(tempButton);

            tempButton = getTopButton(Resource._new, "btnSaveAll", "保存所有", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            addToTopToolStrip(tempButton);

            tempButton = getTopButton(Resource.w5, "btnNew", "新建", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            addToTopToolStrip(tempButton);

            tempButton = getTopButton(Resource.import, "btnLoad", "导入", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            addToTopToolStrip(tempButton);

            tempButton = getTopButton(Resource.word, "btnWordView", "生成报告", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            addToTopToolStrip(tempButton);

            //tempButton = getTopButton(Resource.upload_pdf, "btnUploadPDF", "上传盖章PDF", new System.Drawing.Size(53, 56));
            //tempButton.Click += tempButton_Click;
            //addToTopToolStrip(tempButton);

            tempButton = getTopButton(Resource.export, "btnExport", "导出", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            addToTopToolStrip(tempButton);
            
            tempButton = getTopButton(Resource.help, "btnHelp", "帮助", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            addToTopToolStrip(tempButton);
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
                case "上传盖章PDF":
                    //if (projectObj == null)
                    //{
                    //    MessageBox.Show("对不起，请先填写项目信息，然后再继续！");
                    //    return;
                    //}

                    //FrmUploadPDF form = new FrmUploadPDF();
                    //form.ShowDialog();
                    break;
                case "保存所有":
                    if (projectObj == null)
                    {
                        MessageBox.Show("对不起，请先填写项目信息，然后再继续！");
                        return;
                    }

                    //更新保存日期
                    updateSaveDate();

                    //保存所有
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

                    //if (string.IsNullOrEmpty(FrmUploadPDF.getPDFFile()))
                    //{
                    //    MessageBox.Show("对不起，请上传PDF!");
                    //    return;
                    //}

                    //if (isRenamePDF(FrmUploadPDF.getPDFFile()) == false)
                    //{
                    //    MessageBox.Show("对不起，请先关闭PDF阅读软件然后再试!");
                    //    return;
                    //}

                    //最后更新日期
                    DateTime dtLastUpdateDate = getLastUpdateDate();

                    if (isSaveAllSucess() == false)
                    {
                        MessageBox.Show("对不起，保存失败，请检查！");
                        return;
                    }

                    string docFile = Path.Combine(dataDir, "论证报告.doc");
                    if (File.Exists(docFile) == false)
                    {
                        MessageBox.Show("对不起，请先点击\"生成报告\"按钮生成论证报告书！");
                        return;
                    }

                    DateTime dtDoc = File.GetLastWriteTime(docFile);
                    if (dtLastUpdateDate > dtDoc)
                    {
                        MessageBox.Show("对不起，当前的论证报告不是最新的，请点击\"生成报告\"按钮重新生成论证报告书！");
                        return;
                    }

                    string errorPage = string.Empty;
                    if (!isInputCompleted(ref errorPage))
                    {
                        MessageBox.Show("对不起，内容未填写完不能上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show("请将页签[" + errorPage + "]填写完整再点击上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "ZIP申报包|*.zip";
                    sfd.FileName = getExportName();
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
                                //PublicReporterLib.Utility.ZipUtil zu = new PublicReporterLib.Utility.ZipUtil(Path.Combine(dataDir, "协议书.doc"));
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
                case "生成报告":
                    if (projectObj == null)
                    {
                        MessageBox.Show("对不起，请先填写项目信息，然后再继续！");
                        return;
                    }

                    if (!File.Exists(Path.Combine(dataDir, Path.Combine("Files", "Docs_A.doc"))))
                    {
                        MessageBox.Show("对不起，“研究状况及选题价值”不能为空！");
                        return;
                    }
                    if (!File.Exists(Path.Combine(dataDir, Path.Combine("Files", "Docs_B.doc"))))
                    {
                        MessageBox.Show("对不起，“总体框架和预期目标”不能为空！");
                        return;
                    }
                    if (!File.Exists(Path.Combine(dataDir, Path.Combine("Files", "Docs_C.doc"))))
                    {
                        MessageBox.Show("对不起，“研究思路和研究方法”不能为空！");
                        return;
                    }
                    if (!File.Exists(Path.Combine(dataDir, Path.Combine("Files", "Docs_D.doc"))))
                    {
                        MessageBox.Show("对不起，“重点难点和创新之处”不能为空！");
                        return;
                    }
                    if (!File.Exists(Path.Combine(dataDir, Path.Combine("Files", "Docs_E.doc"))))
                    {
                        MessageBox.Show("对不起，“研究进度和任务分工”不能为空！");
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

                                    string uuid = projectObj != null ? projectObj.BianHao : string.Empty;

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

        private bool isRenamePDF(string pdfFile)
        {
            try
            {
                //重命名
                File.Move(FrmUploadPDF.getPDFFile(), Path.Combine(getDataCurrentDir(), projectObj.XiangMuMingCheng + ".pdf"));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获得数据目录
        /// </summary>
        /// <returns></returns>
        public string getDataCurrentDir()
        {
            return Path.Combine(RootDir, Path.Combine("Data", "Current"));
        }

        private string getExportName()
        {
            return projectObj.XiangMuMingCheng + "-" + projectObj.ZeRenDanWei + "-" + projectObj.QianTouRen + ".zip";
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
                                    bool isSuccess = true;
                                    be.OnSaveEvent(ref isSuccess);
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
                            be.OnSaveEvent(ref isSucesss);
                            if (isSucesss == false)
                            {
                                throw new Exception("内容未填写完");
                            }
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
            return getTopButton(imgg, nameg, textg, sizeg, new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
        }

        void treeViewObj_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (projectObj == null || string.IsNullOrEmpty(projectObj.BianHao))
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

        /// <summary>
        /// 获得最后更新日期
        /// </summary>
        /// <returns></returns>
        public DateTime getLastUpdateDate()
        {
            DateTime dtResults = DateTime.MinValue;

            if (UIControlConfig.ConfigObj.Params.ContainsKey("保存日期"))
            {
                try
                {
                    dtResults = (DateTime)UIControlConfig.ConfigObj.Params["保存日期"];
                }
                catch (Exception ex)
                {
                    dtResults = DateTime.MinValue;
                }
            }
            else
            {
                dtResults = DateTime.MinValue;
            }

            return dtResults;
        }

        /// <summary>
        /// 更新保存日期
        /// </summary>
        public void updateSaveDate()
        {
            UIControlConfig.ConfigObj.Params["保存日期"] = DateTime.Now;
            UIControlConfig.saveConfig();
        }
    }
}