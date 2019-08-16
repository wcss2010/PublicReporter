using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestReporterPlugin.Forms;

namespace TestReporterPlugin
{
    public class PluginRoot : IReportPluginRoot
    {
        /// <summary>
        /// 数据目录
        /// </summary>
        private string DataDir = string.Empty;

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
            if (e != null)
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
        /// <param name="mainForm">顶部工具条控件</param>
        /// <param name="topToolStrip">顶部工具条控件</param>
        /// <param name="treeViewImageListObj">顶部工具条控件</param>
        /// <param name="treeViewObj">左边的树控件</param>
        /// <param name="contentObj">右边的内容面板</param>
        /// <param name="bottomStatusStrip">底部状态栏</param>
        /// <param name="defaultHintLabel">默认的提示标签</param>
        public override void init(Form mainForm, ToolStrip topToolStrip, ImageList treeViewImageListObj, TreeView treeViewObj, Panel contentObj, StatusStrip bottomStatusStrip, ToolStripStatusLabel defaultHintLabel)
        {
            this.topToolStrip = topToolStrip;
            this.treeViewObj = treeViewObj;
            this.contentObj = contentObj;
            this.treeViewImageListObj = treeViewImageListObj;
            this.defaultHintLabel = defaultHintLabel;

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

            subItemObj = new TreeNode();
            subItemObj.Text = "课题详细";
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

            //初始化按钮
            initButtons(topToolStrip);

            //初始化编辑控件
            initEditors();

            //defaultHintLabel.Text = "大大大大大大大大大大大大大大," + WorkDir;
        }

        private void initEditors()
        {

        }

        private void initButtons(ToolStrip topToolStrip)
        {
            Image img = Resource.w5;
            ToolStripButton tempButton = null;

            tempButton = GetTopButton(img, "btnHelp", "帮助", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;            
            topToolStrip.Items.Insert(0, tempButton);

            tempButton = GetTopButton(img, "btnExport", "导出", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            topToolStrip.Items.Insert(0, tempButton);

            tempButton = GetTopButton(img, "btnWordView", "预览", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            topToolStrip.Items.Insert(0, tempButton);

            tempButton = GetTopButton(img, "btnLoad", "导入", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            topToolStrip.Items.Insert(0, tempButton);

            tempButton = GetTopButton(img, "btnNew", "新建", new System.Drawing.Size(53, 56));
            tempButton.Click += tempButton_Click;
            topToolStrip.Items.Insert(0, tempButton);
        }

        void tempButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = ((ToolStripButton)sender);
            switch (button.Text)
            {
                case "帮助":
                    frmHelp helpForm = new frmHelp();
                    helpForm.ShowDialog();
                    break;
            }
        }

        protected ToolStripButton GetTopButton(Image imgg, string nameg, string textg, Size sizeg)
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

        }
    }
}