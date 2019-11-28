using PublicReporterLib;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ProjectContractPlugin.Controls;
using ProjectContractPlugin.DB;
using ProjectContractPlugin.DB.Entitys;
using ProjectContractPlugin.Editor;
using ProjectContractPlugin.Forms;
using ProjectContractPlugin.Utility;

namespace ProjectContractPlugin
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
            get { return "重点基础研究项目合同书填报系统（1.4版）"; }
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
            //添加点击事件
            Parent_LeftTreeView.AfterSelect += treeViewObj_AfterSelect;

            #region 构建树结构
            TreeNode firstNode = new TreeNode();
            firstNode.Name = "root";
            firstNode.Text = "基本信息";

            TreeNode itemObj = new TreeNode();
            itemObj.Text = "研究目标";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "主要研究内容";
            firstNode.Nodes.Add(itemObj);

            TreeNode subItemObj = new TreeNode();
            subItemObj.Text = "项目分解情况";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "课题情况";
            itemObj.Nodes.Add(subItemObj);

            itemObj = new TreeNode();
            itemObj.Text = "技术要求及指标";
            firstNode.Nodes.Add(itemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "技术要求";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "主要指标名称、要求及考核方式";
            itemObj.Nodes.Add(subItemObj);

            itemObj = new TreeNode();
            itemObj.Text = "研究进度安排";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "经费预算";
            firstNode.Nodes.Add(itemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "经费预算表";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "双方认为需要说明的经费使用事项";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "经费拨付约定";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "经费管理要求";
            itemObj.Nodes.Add(subItemObj);

            itemObj = new TreeNode();
            itemObj.Text = "提交要求";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "主要研究人员";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "共同条款";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "附加条款";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "附件";

            subItemObj = new TreeNode();
            subItemObj.Text = "课题经费年度分配表";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "课题经费预算表";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "单位经费年度分配表";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "项目经费预算编制说明";
            itemObj.Nodes.Add(subItemObj);

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
            editorMap.Add("研究目标", new TextContentEditor("研究目标", "填写批复目标"));
            editorMap.Add("项目分解情况", new DocumentPasteEditor("项目分解情况", "根据项目目标要求，围绕项目拟解决的基础科学问题，将项目分解为若干课题，并简要说明基础性问题与课题之间的对应关系及各课题相互之间的逻辑关系。"));
            editorMap.Add("双方认为需要说明的经费使用事项", new TextContentEditor("双方认为需要说明的经费使用事项", "（应明确承研单位，不包括外协单位） 如：××××××单位承担××××××××××研究任务，经费×××万元。"));
            editorMap.Add("经费管理要求", new TextReadOnlyEditor("经费管理要求", "", Path.Combine(RootDir, Path.Combine("Helper", "readonlyA.rtf"))));            
            editorMap.Add("附加条款", new TextReadOnlyEditor("附加条款", "", Path.Combine(RootDir, Path.Combine("Helper", "readonlyC.rtf"))));
            #endregion

            #region 初始化其它的编辑器
            editorMap.Add("基本信息", new ProjectEditor());
            editorMap.Add("课题情况", new SubjectEditor());
            editorMap.Add("技术要求", new TechnologyQuestionEditor());
            editorMap.Add("主要指标名称、要求及考核方式", new DestNameAndQuestionEditor());
            editorMap.Add("研究进度安排", new WorkProgressEditor());
            editorMap.Add("经费预算表", new MoneyTableEditor());
            editorMap.Add("经费拨付约定", new MoneySendRuleEditor());
            editorMap.Add("提交要求", new SubmitQuestionEditor());
            editorMap.Add("主要研究人员", new WorkerEditor());
            editorMap.Add("共同条款", new TogetherRuleEditor("共同条款", "", Path.Combine(RootDir, Path.Combine("Helper", "readonlyB.rtf"))));
            editorMap.Add("课题经费年度分配表", new SubjectMoneyYearEditor());
            editorMap.Add("课题经费预算表", new SubjectMoneyEditor());
            editorMap.Add("单位经费年度分配表", new UnitMoneyYearEditor());
            editorMap.Add("项目经费预算编制说明", new ExtFile2Editor());
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

            tempButton = getTopButton(Resource.word, "btnWordView", "预览", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            addToTopToolStrip(tempButton);

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

                    //if (File.Exists(Path.Combine(dataDir, "合同书.doc")) == false)
                    //{
                    //    MessageBox.Show("对不起，请先点击预览按钮生成项目申报书！");
                    //    return;
                    //}

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
                                PublicReporterLib.Utility.ZipUtil zu = new PublicReporterLib.Utility.ZipUtil(Path.Combine(dataDir, "合同书.doc"));
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

        private string getExportName()
        {
            return projectObj.HeTongBianHao + "-" + projectObj.HeTongFuZeDanWei + "-" + projectObj.HeTongFuZeRen + ".zip";
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
    }
}