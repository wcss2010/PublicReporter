using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestReporterPlugin
{
    public class PluginRoot:IReportPluginRoot
    {
        /// <summary>
        /// 程序标题
        /// </summary>
        public override string Title
        {
            get { return "重点基础研究项目建议书填报系统（1.1版）"; }
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
            
        }
    }
}