using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TestReporterPlugin
{
    public class PluginRoot:IReportPluginRoot
    {
        private ImageList TreeViewImageList;

        /// <summary>
        /// 程序标题
        /// </summary>
        public override string Title
        {
            get { return "重点基础研究项目建议书填报系统（1.2版）"; }
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
        public override void stop()
        {
            
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="topToolStrip">顶部工具条控件</param>
        /// <param name="treeViewObj">左边的树控件</param>
        /// <param name="contentObj">右边的内容面板</param>
        /// <param name="bottomStatusStrip">底部状态栏</param>
        /// <param name="defaultHintLabel">默认的提示标签</param>
        public override void init(System.Windows.Forms.ToolStrip topToolStrip, System.Windows.Forms.TreeView treeViewObj, System.Windows.Forms.Panel contentObj, System.Windows.Forms.StatusStrip bottomStatusStrip, System.Windows.Forms.ToolStripStatusLabel defaultHintLabel)
        {
            TreeViewImageList = new ImageList();
            treeViewObj.ImageList = TreeViewImageList;
            treeViewObj.AfterSelect += treeViewObj_AfterSelect;

            TreeNode firstNode = new TreeNode();
            firstNode.Name = "root";
            firstNode.Text = "申报书";

            TreeNode item01 = new TreeNode();
            firstNode.Nodes.Add(item01);

            TreeNode item02 = new TreeNode();
            firstNode.Nodes.Add(item02);

            TreeNode item03 = new TreeNode();
            firstNode.Nodes.Add(item03);

            TreeNode item04 = new TreeNode();
            firstNode.Nodes.Add(item04);

            TreeNode item05 = new TreeNode();
            firstNode.Nodes.Add(item05);

            TreeNode item06 = new TreeNode();
            firstNode.Nodes.Add(item06);

            TreeNode item07 = new TreeNode();
            firstNode.Nodes.Add(item07);

            TreeNode item08 = new TreeNode();
            firstNode.Nodes.Add(item08);

            TreeNode item09 = new TreeNode();
            firstNode.Nodes.Add(item09);

            TreeNode item10 = new TreeNode();
            firstNode.Nodes.Add(item10);

            TreeNode item11 = new TreeNode();
            firstNode.Nodes.Add(item11);

            TreeNode item12 = new TreeNode();
            firstNode.Nodes.Add(item12);

            TreeNode item13 = new TreeNode();
            firstNode.Nodes.Add(item13);

            TreeNode item14 = new TreeNode();
            firstNode.Nodes.Add(item14);

            treeViewObj.Nodes.Add(firstNode);

            defaultHintLabel.Text = "大大大大大大大大大大大大大大";
        }

        void treeViewObj_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }
    }
}