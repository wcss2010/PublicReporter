using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestReporterPlugin
{
    public class PluginRoot:IReportPluginRoot
    {
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
            Image img = topToolStrip.Items[topToolStrip.Items.Count - 1].Image;
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
            
        }

        private ToolStripButton GetTopButton(Image imgg,string nameg,string textg,Size sizeg)
        {
            ToolStripButton tempButton = new ToolStripButton();
            tempButton.Font = new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tempButton.Image = imgg;
            tempButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            tempButton.Name = nameg;
            tempButton.Size = sizeg;
            tempButton.Text = textg;
            tempButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            return tempButton;
        }

        void treeViewObj_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }
    }
}