using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TestReporterPlugin.Controls;
using TestReporterPlugin.DB;
using TestReporterPlugin.DB.Entitys;
using TestReporterPlugin.Editor;
using TestReporterPlugin.Forms;

namespace TestReporterPlugin
{
    public class PluginRoot : IReportPluginRoot
    {
        /// <summary>
        /// 当前项目
        /// </summary>
        public Project ProjectObj { get; set; }

        /// <summary>
        /// 编辑器字典
        /// </summary>
        public SortedList<string, BaseEditor> editorMap = new SortedList<string, BaseEditor>();

        /// <summary>
        /// 数据目录
        /// </summary>
        public string DataDir { get; set; }

        /// <summary>
        /// 文件目录
        /// </summary>
        public string FilesDir { get; set; }

        /// <summary>
        /// 顶部工具栏
        /// </summary>
        private ToolStrip topToolStrip;

        /// <summary>
        /// 左侧树控件的图片列表
        /// </summary>
        private ImageList treeViewImageListObj;

        /// <summary>
        /// 左侧树控件
        /// </summary>
        private TreeView treeViewObj;

        /// <summary>
        /// 内容控件
        /// </summary>
        private Panel contentObj;
        
        /// <summary>
        /// 默认提示标签
        /// </summary>
        private ToolStripStatusLabel defaultHintLabel;

        /// <summary>
        /// 是否显示关闭提示
        /// </summary>
        public bool enabledShowExitHint = true;

        /// <summary>
        /// 程序标题
        /// </summary>
        public override string Title
        {
            get { return "重点基础研究项目建议书填报系统（1.3版）"; }
        }

        /// <summary>
        /// 是否允许关闭
        /// </summary>
        /// <returns></returns>
        public override bool isEnableClosing()
        {
            return true;
        }

        /// <summary>
        /// 启动
        /// </summary>
        public override void start()
        {

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
                    treeViewImageListObj.Images.Clear();
                    treeViewObj.Nodes.Clear();
                    contentObj.Controls.Clear();
                    defaultHintLabel.Text = string.Empty;

                    List<ToolStripItem> list = new List<ToolStripItem>();
                    foreach (ToolStripItem tsi in topToolStrip.Items)
                    {
                        if (tsi.Tag == "Dynamic")
                        {
                            list.Add(tsi);
                        }
                    }
                    foreach (ToolStripItem tssi in list)
                    {
                        topToolStrip.Items.Remove(tssi);
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
                treeViewImageListObj.Images.Clear();
                treeViewObj.Nodes.Clear();
                contentObj.Controls.Clear();
                defaultHintLabel.Text = string.Empty;

                List<ToolStripItem> list = new List<ToolStripItem>();
                foreach (ToolStripItem tsi in topToolStrip.Items)
                {
                    if (tsi.Tag == "Dynamic")
                    {
                        list.Add(tsi);
                    }
                }
                foreach (ToolStripItem tssi in list)
                {
                    topToolStrip.Items.Remove(tssi);
                }
                #endregion
            }
        }

        /// <summary>
        /// 插件初始化
        /// </summary>
        /// <param name="mainFormObj">顶部工具条控件</param>
        /// <param name="topToolStripObj">顶部工具条控件</param>
        /// <param name="treeViewImageListObj">顶部工具条控件</param>
        /// <param name="treeViewObj">左边的树控件</param>
        /// <param name="contentObj">右边的内容面板</param>
        /// <param name="bottomStatusStripObj">底部状态栏</param>
        /// <param name="defaultHintLabelObj">默认的提示标签</param>
        public override void init(Form mainFormObj, ToolStrip topToolStripObj, ImageList treeViewImageListObj, TreeView treeViewObj, Panel contentObj, StatusStrip bottomStatusStripObj, ToolStripStatusLabel defaultHintLabelObj)
        {
            this.topToolStrip = topToolStripObj;
            this.treeViewObj = treeViewObj;
            this.contentObj = contentObj;
            this.treeViewImageListObj = treeViewImageListObj;
            this.defaultHintLabel = defaultHintLabelObj;

            //添加点击事件
            treeViewObj.AfterSelect += treeViewObj_AfterSelect;

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

            treeViewObj.Nodes.Add(firstNode);

            firstNode.ExpandAll();
            #endregion
            
            #region 创建数据目录
            DataDir = Path.Combine(WorkDir, Path.Combine("Data", "Current"));
            try
            {
                Directory.CreateDirectory(DataDir);
            }
            catch (Exception ex) { }
            #endregion

            #region 创建文件目录
            FilesDir = Path.Combine(DataDir, "Files");
            try
            {
                Directory.CreateDirectory(FilesDir);
            }
            catch (Exception ex) { }
            #endregion

            //初始化DB
            initDB();

            //初始化按钮
            initButtons(topToolStripObj);

            //初始化编辑控件
            initEditors();

            //加载工程对象
            try
            {
                //加载项目信息
                ProjectObj = ConnectionManager.Context.table("Project").where("Type='" + "项目" + "'").select("*").getItem<Project>(new Project());

                if (string.IsNullOrEmpty(ProjectObj.ID))
                {
                    //项目数据清空
                    ProjectObj = null;

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
            string dbFile = Path.Combine(DataDir, "static.db");
            
            //判断是否可以打开数据库
            if (File.Exists(dbFile))
            {
                //打开数据库连接
                ConnectionManager.Open(dbFile);
            }
            else
            {
                //复制数据库文件
                File.Copy(Path.Combine(WorkDir, "static.db"), dbFile, true);

                //打开数据库连接
                ConnectionManager.Open(dbFile);
            }
        }

        /// <summary>
        /// 切换到内容页
        /// </summary>
        private void switchToProjectContentEditor()
        {
            treeViewObj.SelectedNode = treeViewObj.Nodes[treeViewObj.Nodes.Count - 1].Nodes[0].Nodes[0];
            refreshEditors();
        }

        /// <summary>
        /// 切换到项目编辑页
        /// </summary>
        private void switchToProjectEditor()
        {
            treeViewObj.SelectedNode = treeViewObj.Nodes[treeViewObj.Nodes.Count - 1];
        }

        /// <summary>
        /// 初始化编辑器列表
        /// </summary>
        private void initEditors()
        {
            #region 初始化文档编辑器
            editorMap.Add("项目摘要", new DocumentPasteEditor("项目摘要", "简述背景及必要性，介绍问题提出的军事应用背景或需求，重点阐述其现实“瓶颈”属性或引领未来重大技术发展方向属性，分析国内外研究现状和差距。介绍项目研究目标，概述拟突破的主要基础问题或关键技术、主要成果形式和预期技术指标，分析对解决国防科技现实瓶颈问题和支撑未来技术发展方面的预期支撑作用。围绕项目研究目标，突出国防基础研究的任务特点，从增强原始创新能力和支撑未来发展的角度出发，概述本项目需要重点研究解决的基础性问题。项目由XXX牵头，XXX等单位参研，研究周期X年，申请经费XXXX万元。项目负责人为XXX(院士/研究员/教授)(1000字以内)"));
            editorMap.Add("基本概念及内涵", new DocumentPasteEditor("基本概念及内涵", "简要介绍相关研究对象的基本概念及内涵等"));
            editorMap.Add("军事需求分析", new DocumentPasteEditor("军事需求分析", "分析本项目有关军事需求背景，提出面临的困难和瓶颈问题等"));
            editorMap.Add("研究现状", new DocumentPasteEditor("研究现状", "全面客观地论述国内与国外研究现状，重点聚焦与本项目核心问题相关的技术研究情况其中包括研究水平、差距与不足等，注重定量描述，避免泛泛而谈"));
            editorMap.Add("研究目标", new DocumentPasteEditor("研究目标", "凝练提出项目研究目标，表述需明确、具体、准确，避免过于笼统。"));
            editorMap.Add("基础性问题", new DocumentPasteEditor("基础性问题", "围绕项目研究目标，突出国防基础研究的任务特点，梳理提出本项目需要重点研究解决的基础性问题(简要描述每个问题，200字以内)"));
            editorMap.Add("课题之间的关系", new DocumentPasteEditor("课题之间的关系", "基础性问题与课题之间的关系、各课题之间的关系（简要叙述，建议1000字之内，可用图表示）"));
            editorMap.Add("研究成果及考核指标", new DocumentPasteEditor("研究成果及考核指标", "分类逐项列出研究成果及考核指标。研究成果形式包括研究报告、试验（测试）方案、试验（测试）结果分析报告、样品、样机、试验（验证）系统、数据库、软件、工程工艺、标准（规范）等。指标体系应系统完整。"));
            editorMap.Add("评估方案", new DocumentPasteEditor("评估方案", "围绕课题的研究成果及考核指标，提出具体的评估方案。可考虑通过国标、检测机构、企业标准测量、实验等多种方法，具体落实各项指标的评测。对可能影响指标评测结果的各种边界因素条件，均应明确说明，避免理解歧义。"));
            editorMap.Add("预期效益", new DocumentPasteEditor("预期效益", "简要描述该项目研究成果得到应用后，对解决国防科技现实瓶颈问题和支撑未来技术发展方面的预期支撑作用。"));
            editorMap.Add("项目负责人", new DocumentPasteEditor("项目负责人", "介绍项目负责人的职务职称、受教育情况、履历，代表性论文、专著、专利、奖励、人才计划资助情况，以及近五年主持的相关国家科技计划项目情况，限800字以内。要求实事求是填报，有关信息纳入科研诚信评价体系。"));
            editorMap.Add("研究团队", new DocumentPasteEditor("研究团队", "简要介绍本项目除项目负责人外的课题负责人的职务职称、受教育情况、履历，代表性论文、专著、专利、奖励、人才计划资助情况，以及近五年主持的相关国家科技计划项目情况，限1000字以内。要求实事求是填报，有关信息纳入科研诚信评价体系。"));
            editorMap.Add("研究基础与保障条件", new DocumentPasteEditor("研究基础与保障条件", "已有研究基础和软硬件保障条件，包括国家研究中心、国家重点实验室、国家工程（技术）中心等，以及自筹经费情况，800字以内"));
            editorMap.Add("组织实施与风险控制", new DocumentPasteEditor("组织实施与风险控制", "对本项目可能存在的技术和管理风险进行分析，提出思路举措，500字以内"));
            editorMap.Add("与有关计划关系", new DocumentPasteEditor("与有关计划关系", "介绍与本项目研究内容相关的国家和军队各类科技计划安排情况，对本项目与有关计划安排的界面关系进行说明。"));
            #endregion

            #region 初始化其它的编辑器
            editorMap.Add("申报书", new ProjectEditor());
            editorMap.Add("课题列表", new SubjectTableEditor());
            editorMap.Add("各课题负责人及研究骨干情况表", new ProjectWorkerInfoEditor());
            editorMap.Add("经费预算表", new MoneyTableEditor());
            editorMap.Add("项目阶段划分和经费安排", new ProjectStepMoneyEditor());
            editorMap.Add("课题阶段划分和经费安排", new SubjectStepMoneyEditor());
            editorMap.Add("附件1-经费概算", new MoneySummaryEditor());
            editorMap.Add("附件2-保密资质", new ConfidentialQualificationEditor());
            #endregion
        }

        /// <summary>
        /// 初始化按钮
        /// </summary>
        /// <param name="topToolStrip"></param>
        private void initButtons(ToolStrip topToolStrip)
        {
            Image img = Resource.w5;
            ToolStripButton tempButton = null;

            tempButton = getTopButton(img, "btnHelp", "帮助", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;            
            topToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(img, "btnExport", "导出", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            topToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(img, "btnWordView", "预览", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            topToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(img, "btnLoad", "导入", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            topToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(img, "btnNew", "新建", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            topToolStrip.Items.Insert(0, tempButton);

            tempButton = getTopButton(img, "btnManager", "项目管理", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            topToolStrip.Items.Insert(0, tempButton);
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
                case "帮助":
                    FrmHelpBox helpForm = new FrmHelpBox();
                    helpForm.ShowDialog();
                    break;
                case "导出":
                    
                    break;
                case "预览":
                    
                    break;
                case "导入":
                    
                    break;
                case "新建":
                    
                    break;
                case "项目管理":
                    FrmProjectManager manager = new FrmProjectManager();
                    manager.ShowDialog();
                    break;
            }
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
            if (ProjectObj == null || string.IsNullOrEmpty(ProjectObj.ID))
            {
                //因为项目信息为空，所以锁定在项目信息页
                treeViewObj.SelectedNode = treeViewObj.Nodes[treeViewObj.Nodes.Count - 1];
                showEditor(treeViewObj.SelectedNode.Text);
                defaultHintLabel.Text = "请填写完整项目信息......";
            }
            else
            {
                showEditor(e.Node.Text);
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
                contentObj.Controls.Clear();
                editorMap[nodeTexts].Dock = DockStyle.Fill;
                contentObj.Controls.Add(editorMap[nodeTexts]);
            }
        }

        /// <summary>
        /// 刷新编辑器
        /// </summary>
        public void refreshEditors()
        {
            if (ProjectObj != null)
            {
                foreach (BaseEditor be in editorMap.Values)
                {
                    be.RefreshView();
                }
            }
        }
    }
}