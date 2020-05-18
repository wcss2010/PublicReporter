using PublicReporterLib;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ProjectMoneyProtocolPlugin.Controls;
using ProjectMoneyProtocolPlugin.DB;
using ProjectMoneyProtocolPlugin.DB.Entitys;
using ProjectMoneyProtocolPlugin.Editor;
using ProjectMoneyProtocolPlugin.Forms;
using ProjectMoneyProtocolPlugin.Utility;
using AbstractEditorPlugin.Editor;
using AbstractEditorPlugin;
using AbstractEditorPlugin.Utility;
using AbstractEditorPlugin.Forms;

namespace ProjectMoneyProtocolPlugin
{
    public class NewPluginRoot : AbstractEditorPlugin.AbstractPluginRoot
    {
        /// <summary>
        /// 不支持的数据库版本
        /// </summary>
        public static List<string> noSupportDBVersionList = new List<string>(new string[] { "v1.0" });

        public const string button1_Name = "新建项目";
        public const string button2_Name = "生成报告";
        public const string button3_Name = "导出数据包";
        public const string button4_Name = "数据包管理";
        public const string button5_Name = "上传PDF";
        public const string button6_Name = "帮助";

        private string importZipFile;
        private NewProjectType importProjectType;

        public NewPluginRoot()
            : base()
        {
            defaultSplitterDistance = 235;
        }

        public override string DefaultTitle
        {
            get { return "基础加强计划技术领域基金项目协议书（1.1版）"; }
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

            //检查初始化类型
            checkInitType();

            //检查是否存在错误数据(主要用于判断部门中的船舶工业和船舶重工二个公司)
            checkErrorData();
        }

        /// <summary>
        /// 检查数据库初始化类型
        /// </summary>
        private void checkInitType()
        {
            if (File.Exists(importZipFile))
            {
                switch (importProjectType)
                {
                    case NewProjectType.UseReporterPKG:
                        ReporterDBImporter.import(importZipFile, ConnectionManager.Context, this);
                        break;
                    case NewProjectType.UseOldContactPKG:
                        OldContactDBImporter.import(importZipFile, ConnectionManager.Context, this);
                        break;
                }                
                importZipFile = string.Empty;
            }
        }

        /// <summary>
        /// 的openDB完成后执行，用于检查部门中的船舶工业和船舶重工二个司
        /// </summary>
        private void checkErrorData()
        {
            List<string> containsList = new List<string>(new string[] { "陆军", "海军", "空军", "火箭军", "战略支援部队", "联勤保障部队", "军委机关直属单位", "军事科学院", "国防大学", "国防科技大学", "武警部队", "教育部", "工信部", "中国科学院", "中国兵器工业集团公司", "中国兵器装备集团公司", "中国船舶集团有限公司", "中国电子科技集团公司", "中国电子信息产业集团公司", "中国航空发动机集团公司", "中国航空工业集团公司", "中国航天科工集团公司", "中国航天科技集团公司", "中国核工业集团公司", "中国工程物理研究院", "其它" });

            #region 处理基本信息中的部门
            try
            {
                JiBenXinXiBiao projs = ConnectionManager.Context.table("JiBenXinXiBiao").select("*").getItem<JiBenXinXiBiao>(new JiBenXinXiBiao());
                if (!string.IsNullOrEmpty(projs.BianHao))
                {
                    if (projs.HeTongSuoShuBuMen == "中国船舶工业集团公司" || projs.HeTongSuoShuBuMen == "中国船舶重工集团公司")
                    {
                        projs.HeTongSuoShuBuMen = "中国船舶集团有限公司";
                        projs.copyTo(ConnectionManager.Context.table("JiBenXinXiBiao")).where("BianHao='" + projs.BianHao + "'").update();
                    }
                    else if (!containsList.Contains(projs.HeTongSuoShuBuMen))
                    {
                        projs.HeTongSuoShuBuMen = "其它";
                        projs.copyTo(ConnectionManager.Context.table("JiBenXinXiBiao")).where("BianHao='" + projs.BianHao + "'").update();
                    }
                }
            }
            catch (Exception ex) { }
            #endregion

            #region 处理课题信息中的部门
            try
            {
                List<KeTiBiao> ketiList = ProjectMoneyProtocolPlugin.DB.ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());
                foreach (KeTiBiao keti in ketiList)
                {
                    if (!string.IsNullOrEmpty(keti.BianHao))
                    {
                        if (keti.KeTiSuoShuBuMen == "中国船舶工业集团公司" || keti.KeTiSuoShuBuMen == "中国船舶重工集团公司")
                        {
                            keti.KeTiSuoShuBuMen = "中国船舶集团有限公司";
                            keti.copyTo(ConnectionManager.Context.table("KeTiBiao")).where("BianHao='" + keti.BianHao + "'").update();
                        }
                        else if (!containsList.Contains(keti.KeTiSuoShuBuMen))
                        {
                            keti.KeTiSuoShuBuMen = "其它";
                            keti.copyTo(ConnectionManager.Context.table("KeTiBiao")).where("BianHao='" + keti.BianHao + "'").update();
                        }
                    }
                }
            }
            catch (Exception ex) { }
            #endregion
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
            firstNode.Text = "基本信息";

            TreeNode itemObj = new TreeNode();
            itemObj.Text = "研究目标";
            firstNode.Nodes.Add(itemObj);

            itemObj = new TreeNode();
            itemObj.Text = "主要研究内容";
            firstNode.Nodes.Add(itemObj);

            TreeNode subItemObj = new TreeNode();
            subItemObj.Text = "批复内容";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "课题设置";
            itemObj.Nodes.Add(subItemObj);

            itemObj = new TreeNode();
            itemObj.Text = "主要指标及有关要求";
            firstNode.Nodes.Add(itemObj);

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

            //subItemObj = new TreeNode();
            //subItemObj.Text = "课题经费年度分配表";
            //itemObj.Nodes.Add(subItemObj);

            //subItemObj = new TreeNode();
            //subItemObj.Text = "课题经费预算表";
            //itemObj.Nodes.Add(subItemObj);

            //subItemObj = new TreeNode();
            //subItemObj.Text = "单位经费年度分配表";
            //itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "课题经费分配表";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "单位经费分配表";
            itemObj.Nodes.Add(subItemObj);

            subItemObj = new TreeNode();
            subItemObj.Text = "项目经费预算编制说明";
            itemObj.Nodes.Add(subItemObj);

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
            editorMap.Add("研究目标", new TextContentEditor("研究目标", "填写批复目标", 999999999));
            editorMap.Add("批复内容", new DocumentPasteEditor("批复内容", "填写批复的研究内容", Path.Combine(RootDir, Path.Combine("Helper", "emptyPaste.doc")), getDocumentPasteReadmeFile()));
            editorMap.Add("双方认为需要说明的经费使用事项", new TextContentEditor("双方认为需要说明的经费使用事项", "（应明确承研单位，不包括外协单位） 如：××××××单位承担××××××××××研究任务，经费×××万元。", 999999999));
            editorMap.Add("经费管理要求", new TextReadOnlyEditor("经费管理要求", "", Path.Combine(RootDir, Path.Combine("Helper", "readonlyA.rtf"))));
            editorMap.Add("附加条款", new TextReadOnlyEditor("附加条款", "", Path.Combine(RootDir, Path.Combine("Helper", "readonlyC.rtf"))));
            editorMap.Add("基本信息", new ProjectEditor());
            editorMap.Add("课题设置", new SubjectEditor());
            //editorMap.Add("技术要求", new TechnologyQuestionEditor());
            editorMap.Add("主要指标及有关要求", new DestNameAndQuestionEditor());
            editorMap.Add("研究进度安排", new WorkProgressEditor());
            editorMap.Add("经费预算表", new MoneyTableEditor());
            editorMap.Add("经费拨付约定", new MoneySendRuleEditor());
            editorMap.Add("提交要求", new SubmitQuestionEditor());
            editorMap.Add("主要研究人员", new WorkerEditor());
            editorMap.Add("共同条款", new TogetherRuleEditor("共同条款", "", Path.Combine(RootDir, Path.Combine("Helper", "readonlyB.rtf"))));

            //editorMap.Add("课题经费年度分配表", new SubjectMoneyYearEditor());
            //editorMap.Add("课题经费预算表", new SubjectMoneyEditor());
            //editorMap.Add("单位经费年度分配表", new UnitMoneyYearEditor());

            editorMap.Add("课题经费分配表", new SubjectMoneyNodeEditor());
            editorMap.Add("单位经费分配表", new UnitMoneyNodeEditor());

            editorMap.Add("项目经费预算编制说明", new ExtFile2Editor());
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
                                FrmNewProject fnp = new FrmNewProject();
                                if (fnp.ShowDialog() == DialogResult.OK)
                                {
                                    OpenFileDialog ofd = new OpenFileDialog();
                                    importProjectType = fnp.ProjectType;

                                    switch (importProjectType)
                                    {
                                        case NewProjectType.UseReporterPKG:
                                            ofd = new OpenFileDialog();
                                            ofd.Filter = "Zip压缩文件(*.zip)|*.zip";
                                            ofd.Title = "请选择建议书数据包！";
                                            if (ofd.ShowDialog() == DialogResult.OK)
                                            {
                                                importZipFile = ofd.FileName;

                                                //新建项目
                                                rebuildProject("");
                                            }
                                            break;
                                        case NewProjectType.UseOldContactPKG:
                                            ofd = new OpenFileDialog();
                                            ofd.Filter = "Zip压缩文件(*.zip)|*.zip";
                                            ofd.Title = "请选择旧的协议书数据包！";
                                            if (ofd.ShowDialog() == DialogResult.OK)
                                            {
                                                importZipFile = ofd.FileName;

                                                //新建项目
                                                rebuildProject("");
                                            }
                                            break;
                                        case NewProjectType.UseNewContactPKG:
                                            //新建项目
                                            rebuildProject("");
                                            break;
                                    }
                                }
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

                    string pdfFile = FrmUploadUserPDF.getPDFFile();
                    if (!File.Exists(pdfFile))
                    {
                        MessageBox.Show("对不起，当前没有上传PDF,请点击'上传PDF'按钮！");
                        return;
                    }

                    string errorPage = string.Empty;
                    if (!isInputCompleted(ref errorPage))
                    {
                        MessageBox.Show("对不起，内容未填写完不能上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show("请将页签[" + errorPage + "]填写完整再点击上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
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
                    #region 上传PDF
                    FrmUploadUserPDF pdfForm = new FrmUploadUserPDF("请上传单位盖章后的协议书(最终生效版)扫描版PDF", "协议书");
                    pdfForm.ShowDialog();
                    #endregion
                    break;
                case button6_Name:
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
            return ((JiBenXinXiBiao)projectObj).HeTongBianHao + "-" + ((JiBenXinXiBiao)projectObj).HeTongFuZeDanWei + "-" + ((JiBenXinXiBiao)projectObj).HeTongFuZeRen + ".zip";
        }

        /// <summary>
        /// 新建工程
        /// </summary>
        public override bool rebuildProject(string projName)
        {
            string ddDir = Path.Combine(RootDir, "Data");
            DirectoryInfo destProjectDir = new DirectoryInfo(Path.Combine(ddDir, Guid.NewGuid().ToString() + "_" + DateTime.Now.Ticks));

            if (projectObj != null && !string.IsNullOrEmpty(((JiBenXinXiBiao)projectObj).BianHao))
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
                string projId = projectObj != null ? ((JiBenXinXiBiao)projectObj).BianHao : Guid.NewGuid().ToString();

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

            //上传PDF
            addTopButton(Resource.Q1, Guid.NewGuid().ToString(), button5_Name, new System.Drawing.Size(53, 56));

            //导出数据包
            addTopButton(Resource._new, Guid.NewGuid().ToString(), button3_Name, new System.Drawing.Size(53, 56));

            //添加分割符
            addToTopToolStrip(getTopSeparator());

            //数据包管理
            addTopButton(Resource.manager, Guid.NewGuid().ToString(), button4_Name, new System.Drawing.Size(53, 56));

            //添加分割符
            addToTopToolStrip(getTopSeparator());

            //帮助
            addTopButton(Resource.help, Guid.NewGuid().ToString(), button6_Name, new System.Drawing.Size(53, 56));

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
                projectObj = ConnectionManager.Context.table("JiBenXinXiBiao").select("*").getItem<JiBenXinXiBiao>(new JiBenXinXiBiao());

                if (string.IsNullOrEmpty(getProjectObject<JiBenXinXiBiao>().BianHao))
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
            if (projectObj == null || string.IsNullOrEmpty(getProjectObject<JiBenXinXiBiao>().BianHao))
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