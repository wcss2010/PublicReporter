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
        /// <param name="mainFormObj">主窗体</param>
        /// <param name="topToolStripObj">顶部工具条控件</param>
        /// <param name="treeViewImageListObj">左边的树控件图标列表</param>
        /// <param name="treeViewObj">左边的树控件</param>
        /// <param name="treeViewControlObj">左边的树控件下面的控制面板</param>
        /// <param name="contentObj">右边的内容面板</param>
        /// <param name="bottomStatusStripObj">底部状态栏</param>
        /// <param name="defaultHintLabelObj">默认的提示标签</param>
        public virtual void init(Form mainFormObj, ToolStrip topToolStripObj, ImageList treeViewImageListObj, TreeView treeViewObj, Panel treeViewControlObj, Panel contentObj, StatusStrip bottomStatusStripObj, ToolStripStatusLabel defaultHintLabelObj)
        {
            Parent_Form = mainFormObj;
            Parent_TopToolStrip = topToolStripObj;
            Parent_LeftTreeViewImageList = treeViewImageListObj;
            Parent_LeftTreeView = treeViewObj;
            Parent_LeftTreeViewBottomButtonPanel = treeViewControlObj;
            Parent_RightContentPanel = contentObj;
            Parent_BottomStatusStrip = bottomStatusStripObj;
            Parent_BottomDefaultHintLabel = defaultHintLabelObj;
        }

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

        /// <summary>
        /// 生成顶部工具条按钮对象
        /// </summary>
        /// <param name="imggg"></param>
        /// <param name="namegg"></param>
        /// <param name="textgg"></param>
        /// <param name="sizegg"></param>
        /// <param name="fontgg"></param>
        /// <returns></returns>
        protected virtual ToolStripButton getTopButton(Image imggg, string namegg, string textgg, Size sizegg, Font fontgg)
        {
            ToolStripButton tempButton = new ToolStripButton();
            tempButton.Font = fontgg;
            tempButton.Image = imggg;
            tempButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            tempButton.Name = namegg;
            tempButton.Size = sizegg;
            tempButton.Text = textgg;
            tempButton.Tag = "Dynamic";
            tempButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            return tempButton;
        }

        /// <summary>
        /// 生成分隔符对象
        /// </summary>
        /// <returns></returns>
        protected virtual ToolStripSeparator getTopSeparator()
        {
            ToolStripSeparator obj = new ToolStripSeparator();
            obj.Size = new System.Drawing.Size(6, 59);
            return obj;
        }

        /// <summary>
        /// 隐藏系统分割符
        /// </summary>
        protected virtual void hideSysSeparator()
        {
            foreach (ToolStripItem tsi in Parent_TopToolStrip.Items)
            {
                if (tsi is ToolStripSeparator && ((ToolStripSeparator)tsi).Tag == "DefaultDisplayControl")
                {
                    ToolStripSeparator tssr = ((ToolStripSeparator)tsi);
                    tssr.Visible = false;
                    break;
                }
            }
        }

        /// <summary>
        /// 清除所有添加的内容
        /// </summary>
        protected virtual void clearAllControls()
        {
            //删除新添加的内容
            Parent_LeftTreeViewImageList.Images.Clear();
            Parent_LeftTreeView.Nodes.Clear();
            Parent_RightContentPanel.Controls.Clear();
            Parent_BottomDefaultHintLabel.Text = string.Empty;

            //删除新添加的按钮
            List<ToolStripItem> list = new List<ToolStripItem>();
            foreach (ToolStripItem tsi in Parent_TopToolStrip.Items)
            {
                if (tsi.Tag == "DefaultDisplayControl")
                {
                    continue;
                }
                else
                {
                    list.Add(tsi);
                }
            }
            foreach (ToolStripItem tssi in list)
            {
                Parent_TopToolStrip.Items.Remove(tssi);
            }

            //删除新添加的底部标签
            list.Clear();
            foreach (ToolStripItem tsi in Parent_BottomStatusStrip.Items)
            {
                if (tsi.Tag == "DefaultDisplayControl")
                {
                    continue;
                }
                else
                {
                    list.Add(tsi);
                }
            }
            foreach (ToolStripItem tssi in list)
            {
                Parent_BottomStatusStrip.Items.Remove(tssi);
            }
        }

        /// <summary>
        /// 向顶部工具条增加元素
        /// </summary>
        /// <param name="tsb"></param>
        protected virtual void addToTopToolStrip(ToolStripItem tsb)
        {
            int defaultIndex = 0;
            foreach (ToolStripItem tsi in Parent_TopToolStrip.Items)
            {
                if (tsi is ToolStripSeparator && ((ToolStripSeparator)tsi).Tag == "DefaultDisplayControl")
                {
                    break;
                }
                else
                {
                    defaultIndex++;
                }
            }
            Parent_TopToolStrip.Items.Insert(defaultIndex, tsb);
        }

        /// <summary>
        /// 主窗体的引用
        /// </summary>
        public Form Parent_Form { get; set; }

        /// <summary>
        /// 主窗体中顶部工具条控件的引用
        /// </summary>
        public ToolStrip Parent_TopToolStrip { get; set; }

        /// <summary>
        /// 主窗体中左边的树控件图标列表的引用
        /// </summary>
        public ImageList Parent_LeftTreeViewImageList { get; set; }

        /// <summary>
        /// 主窗体中左边的树控件的引用
        /// </summary>
        public TreeView Parent_LeftTreeView { get; set; }

        /// <summary>
        /// 主窗体中左边的树控件下面的控制面板的引用
        /// </summary>
        public Panel Parent_LeftTreeViewBottomButtonPanel { get; set; }

        /// <summary>
        /// 主窗体中右边的内容面板的引用
        /// </summary>
        public Panel Parent_RightContentPanel { get; set; }

        /// <summary>
        /// 主窗体中底部状态栏的引用
        /// </summary>
        public StatusStrip Parent_BottomStatusStrip { get; set; }

        /// <summary>
        /// 主窗体中默认的提示标签的引用
        /// </summary>
        public ToolStripStatusLabel Parent_BottomDefaultHintLabel { get; set; }
    }
}