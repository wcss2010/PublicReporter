using AbstractEditorPlugin.Utility;
using ProjectStrategicLeadershipPlugin.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjectStrategicLeadershipPlugin
{
    public class PluginRoot : AbstractEditorPlugin.AbstractPluginRoot
    {
        public const string button1_Name = "项目管理";
        public const string button2_Name = "新建项目";
        public const string button3_Name = "导入数据包";
        public const string button4_Name = "保存所有";
        public const string button5_Name = "生成报告";
        public const string button6_Name = "导出数据包";
        public const string button7_Name = "帮助";

        public const string tnode_0_Name = "基本信息";
        public const string tnode_1_Name = "项目摘要";        
        public const string tnode_2_Name = "概述";
        public const string tnode_2_0_Name = "需求分析";
        public const string tnode_2_1_Name = "研究现状";
        public const string tnode_3_Name = "研究目标";        
        public const string tnode_4_Name = "研究内容";
        public const string tnode_4_0_Name = "研究内容列表";
        public const string tnode_4_1_Name = "各项研究内容之间的关系";
        public const string tnode_5_Name = "研究成果";
        public const string tnode_5_0_Name = "研究成果及考核指标";
        public const string tnode_5_1_Name = "成果服务方式";
        public const string tnode_6_Name = "研究周期与进度安排 ";
        public const string tnode_6_0_Name = "项目阶段列表";
        public const string tnode_6_1_Name = "研究内容阶段列表";
        public const string tnode_7_Name = "研究基础与保障条件";        
        public const string tnode_8_Name = "项目负责人和研究团队";
        public const string tnode_8_0_Name = "项目负责人";
        public const string tnode_8_1_Name = "研究团队";
        public const string tnode_8_2_Name = "主要成员情况表";
        public const string tnode_9_Name = "经费预算表";
        public const string tnode_10_Name = "附件1-项目经费预算说明";
        public const string tnode_11_Name = "附件2-保密资质复印件";

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
            rootNode.Nodes.Add(new TreeNode(tnode_2_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_2_0_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_2_1_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_3_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_4_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_4_0_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_4_1_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_5_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_5_0_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_5_1_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_6_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_6_0_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_6_1_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_7_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_8_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_8_0_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_8_1_Name));
            rootNode.Nodes[rootNode.Nodes.Count - 1].Nodes.Add(new TreeNode(tnode_8_2_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_9_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_10_Name));
            rootNode.Nodes.Add(new TreeNode(tnode_11_Name));

            Parent_LeftTreeView.Nodes.Add(rootNode);
            rootNode.ExpandAll();
        }

        /// <summary>
        /// 初始化编辑器
        /// </summary>
        public override void initEditorMaps()
        {

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

        }

        /// <summary>
        /// 响应树切换
        /// </summary>
        /// <param name="treeNode"></param>
        protected override void switchCurrentEditor(System.Windows.Forms.TreeNode treeNode)
        {
            
        }
    }
}