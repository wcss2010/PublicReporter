using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublicReporterLib
{
    /// <summary>
    /// 日志委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OutputLogDelegate(object sender,LogEventArgs args);
    /// <summary>
    /// 日志事件对象
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        /// <summary>
        /// 错误对象
        /// </summary>
        public Exception ErrorObj { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMsg { get; set; }
    }

    /// <summary>
    /// 填报插件启动类
    /// </summary>
    public abstract class IReportPluginRoot
    {
        /// <summary>
        /// 日志事件
        /// </summary>
        public event OutputLogDelegate Log;

        /// <summary>
        /// 根目录
        /// </summary>
        public string RootDir { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public abstract string DefaultTitle { get; }

        /// <summary>
        /// 判断是否允许关闭
        /// </summary>
        public abstract bool isAcceptClose();

        /// <summary>
        /// 插件启动
        /// </summary>
        public abstract void start();

        /// <summary>
        /// 插件停止
        /// </summary>
        /// <param name="e">主窗体关闭事件</param>
        public abstract void stop(FormClosingEventArgs e);
        
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
        public abstract void init(Form mainFormObj, ToolStrip topToolStripObj, ImageList treeViewImageListObj, TreeView treeViewObj, Panel contentObj, StatusStrip bottomStatusStripObj, ToolStripStatusLabel defaultHintLabelObj);

        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="exObj"></param>
        /// <param name="exTxt"></param>
        public virtual void onLog(Exception exObj, string exTxt)
        {
            if (Log != null)
            {
                LogEventArgs lea = new LogEventArgs();
                lea.ErrorObj = exObj;
                lea.ErrorMsg = exTxt;
                Log(this, lea);
            }
        }
    }
}