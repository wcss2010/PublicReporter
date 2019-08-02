using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublicReporterLib
{
    public delegate void OutputLogDelegate(object sender,LogEventArgs args);
    public class LogEventArgs : EventArgs
    {
        public Exception ExObj { get; set; }
        public string ExText { get; set; }
    }

    /// <summary>
    /// 填报插件启动类
    /// </summary>
    public abstract class IReportPluginRoot
    {
        /// <summary>
        /// 日志事件
        /// </summary>
        public event OutputLogDelegate Logs;

        /// <summary>
        /// 工作目录
        /// </summary>
        public string WorkDir { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// 判断是否退出
        /// </summary>
        public abstract bool IsEnableClosing();

        /// <summary>
        /// 插件启动
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// 插件停止
        /// </summary>
        public abstract void Stop();
        
        /// <summary>
        /// 插件初始化
        /// </summary>
        /// <param name="topToolStrip">顶部工具条控件</param>
        /// <param name="treeViewObj">左边的树控件</param>
        /// <param name="contentObj">右边的内容面板</param>
        /// <param name="bottomStatusStrip">底部状态栏</param>
        /// <param name="defaultHintLabel">默认的提示标签</param>
        public abstract void Init(ToolStrip topToolStrip, TreeView treeViewObj, Panel contentObj, StatusStrip bottomStatusStrip,ToolStripStatusLabel defaultHintLabel);

        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="exObj"></param>
        /// <param name="exTxt"></param>
        public virtual void PrintLog(Exception exObj, string exTxt)
        {
            if (Logs != null)
            {
                LogEventArgs lea = new LogEventArgs();
                lea.ExObj = exObj;
                lea.ExText = exTxt;
                Logs(this, lea);
            }
        }
    }
}