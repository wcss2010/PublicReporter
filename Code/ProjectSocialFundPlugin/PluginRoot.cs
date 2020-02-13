using AbstractEditorPlugin;
using AbstractEditorPlugin.Editor;
using AbstractEditorPlugin.Forms;
using AbstractEditorPlugin.Utility;
using ProjectSocialFundPlugin.DB;
using ProjectSocialFundPlugin.DB.Entitys;
using ProjectSocialFundPlugin.Forms;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjectSocialFundPlugin
{
    public class PluginRoot : AbstractEditorPlugin.AbstractPluginRoot
    {
        public const string button1_Name = "项目管理";
        public const string button2_Name = "新建项目";
        public const string button3_Name = "导入数据包";
        public const string button4_Name = "保存所有";
        public const string button5_Name = "上传文档";
        public const string button6_Name = "导出数据包";
        public const string button7_Name = "帮助";

        public const string tnode_0_Name = "基本信息";
        public const string tnode_1_Name = "项目组成员";

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
                FileOp.CopyDirectory(Path.Combine(RootDir, Path.Combine("DataTemplete", "Current")), Path.Combine(RootDir, Path.Combine("Data", "Current")), true);

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

            Parent_LeftTreeView.Nodes.Add(rootNode);
            rootNode.ExpandAll();
        }

        /// <summary>
        /// 初始化编辑器
        /// </summary>
        public override void initEditorMaps()
        {
            #region 初始化编辑器Map
            ////基本信息(需要一个自定义输入界面)
            //editorMap[tnode_0_Name] = new Editor.SummaryEditor();
            ////项目摘要(TextContentEditor)
            //editorMap[tnode_1_Name] = new TextContentEditor("项目摘要", "简要介绍研究问题提出的国防科技发展背景或需求来源，简述项目研究目标与研究内容，拟采取的研究思路与研究方法、拟使用的主要数据资源，以及主要预期成果（名称、形式、数量、指标等）、成果服务方式等。本项目由XXX单位牵头，XXX等单位参研，研究周期X年，申请经费XX万元。项目负责人为XXX（院士/研究员/教授）。（800字以内）", 800);
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
                    //项目管理
                    FrmProjectManager manager = new FrmProjectManager();
                    manager.ShowDialog();
                    break;
                case button2_Name:
                    //新建项目
                    if (MessageBox.Show("真的要新建吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //新建项目
                        rebuildProject();
                    }
                    break;
                case button3_Name:
                    //导入数据包
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
                                    CircleProgressBarDialog senderForm = (CircleProgressBarDialog)thisObject;

                                    AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 10, "准备导入...", 600);

                                    string uuid = projectObj != null ? ((Projects)projectObj).ID : string.Empty;

                                    //关闭连接
                                    closeDB();

                                    //当前项目目录
                                    string currentPath = System.IO.Path.Combine(System.IO.Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().RootDir, "Data"), "Current");

                                    //backup
                                    string backupPath = System.IO.Path.Combine(System.IO.Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().RootDir, "Data"), uuid);

                                    AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 20, "清空当前目录...", 600);

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

                                    AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 30, "创建导入目录...", 600);

                                    //创建当前目录
                                    try
                                    {
                                        Directory.CreateDirectory(currentPath);
                                    }
                                    catch (Exception ex) { }

                                    AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 40, "正在导入...", 600);

                                    //解压
                                    new PublicReporterLib.Utility.ZipUtil().UnZipFile(ofd.FileName, currentPath, string.Empty, true);

                                    AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 90, "导入完成，正在刷新...", 600);

                                    //重新载入工程
                                    reloadProject(senderForm);                                    
                                }));
                        }
                    }
                    break;
                case button4_Name:
                    //保存所有
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
                case button5_Name:
                    //生成报告
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
                    break;
                case button6_Name:
                    //导出数据包
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
                        MessageBox.Show("对不起，内容未填写完不能上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show("请将页签[" + errorPage + "]填写完整再点击上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "ZIP申报包|*.zip";
                    sfd.FileName = getNewExportZipName();
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
                                CircleProgressBarDialog senderForm = (CircleProgressBarDialog)thisObject;

                                AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 10, "准备导出...", 600);

                                //关闭连接
                                closeDB();

                                //当前项目目录
                                string currentPath = System.IO.Path.Combine(System.IO.Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().RootDir, "Data"), "Current");

                                AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 20, "正在导出...", 600);

                                //压缩
                                new PublicReporterLib.Utility.ZipUtil().ZipFileDirectory(currentPath, sfd.FileName);

                                AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 90, "导出完成...", 600);

                                //打开数据库
                                openDB();
                            }));
                        }
                    }
                    break;
                case button7_Name:
                    //帮助
                    FrmHelpBox helpBox = new FrmHelpBox(Path.Combine(RootDir, Path.Combine("Helper", "help.rtf")));
                    helpBox.ShowDialog();
                    break;
            }
        }

        /// <summary>
        /// 获得新的导出包名字
        /// </summary>
        /// <returns></returns>
        protected string getNewExportZipName()
        {
            Projects projObj = (Projects)projectObj;
            return projObj.ProjectName + "-" + projObj.UnitName + "-" + projObj.UnitContact + ".zip";
        }

        /// <summary>
        /// 新建工程
        /// </summary>
        public void rebuildProject()
        {
            //关闭连接
            closeDB();

            //当前项目目录
            string currentPath = System.IO.Path.Combine(System.IO.Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().RootDir, "Data"), "Current");

            //移动当前目录
            if (System.IO.Directory.Exists(currentPath))
            {
                System.IO.Directory.Delete(currentPath, true);
            }

            //重新载入工程
            reloadProject();
        }

        /// <summary>
        /// 初始化顶部工具按钮
        /// </summary>
        public override void initTopToolBar()
        {
            //隐藏默认的分隔符
            hideSysSeparator();

            //添加项目管理按钮
            addTopButton(Resource.manager, Guid.NewGuid().ToString(), button1_Name, new System.Drawing.Size(53, 56));

            //添加新建项目
            addTopButton(Resource.w5, Guid.NewGuid().ToString(), button2_Name, new System.Drawing.Size(53, 56));

            //添加导入项目按钮
            addTopButton(Resource.import, Guid.NewGuid().ToString(), button3_Name, new System.Drawing.Size(53, 56));

            //添加分割符
            addToTopToolStrip(getTopSeparator());

            //添加保存所有按钮
            addTopButton(Resource._new, Guid.NewGuid().ToString(), button4_Name, new System.Drawing.Size(53, 56));

            //添加生成报告按钮
            addTopButton(Resource.word, Guid.NewGuid().ToString(), button5_Name, new System.Drawing.Size(53, 56));

            //添加导出项目按钮
            addTopButton(Resource.export, Guid.NewGuid().ToString(), button6_Name, new System.Drawing.Size(53, 56));

            //添加分割符
            addToTopToolStrip(getTopSeparator());

            //添加帮助按钮
            addTopButton(Resource.help, Guid.NewGuid().ToString(), button7_Name, new System.Drawing.Size(53, 56));
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
    }
}