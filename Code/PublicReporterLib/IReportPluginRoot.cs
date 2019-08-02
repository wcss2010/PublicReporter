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
        /// 工具条按钮
        /// </summary>
        public abstract ToolButtonNode[] TopBarButtons { get; }

        /// <summary>
        /// 工作目录
        /// </summary>
        public string WorkDir { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// 判断退出时是否需要提示
        /// </summary>
        public abstract bool IsEnabledMsgBoxWithClosing { get; }

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
        public abstract void Init(TreeView treeViewObj,Panel contentObj);

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

    /// <summary>
    /// 工具条按钮
    /// </summary>
    public class ToolButtonNode
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="id"></param>
        /// <param name="txt"></param>
        /// <param name="ico"></param>
        public ToolButtonNode(string id, string txt, Image ico)
        {
            this.ID = id;
            this.Text = txt;
            this.Icon = ico;
        }

        /// <summary>
        /// 按钮ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 按钮标题
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 按钮图标
        /// </summary>
        public Image Icon { get; set; }
    }
}