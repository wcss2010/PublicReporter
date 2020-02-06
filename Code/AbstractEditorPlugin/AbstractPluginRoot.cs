using PublicReporterLib;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AbstractEditorPlugin
{
    /// <summary>
    /// 根据已经有AbstractEditorPlugin插件抽象出来的一个模板
    /// </summary>
    public abstract class AbstractPluginRoot : IReportPluginRoot
    {
        /// <summary>
        /// 工程对象
        /// </summary>
        public object projectObj = null;

        /// <summary>
        /// 编辑器字典
        /// </summary>
        public CustomDictionary<string, BaseEditor> editorMap = new CustomDictionary<string, BaseEditor>();

        /// <summary>
        /// 是否允许关闭
        /// </summary>
        /// <returns></returns>
        public override bool isAcceptClose()
        {
            return true;
        }

        /// <summary>
        /// 是否显示关闭提示
        /// </summary>
        public bool enabledShowExitHint = true;

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public string configFile = string.Empty;

        /// <summary>
        /// 基础目录
        /// </summary>
        public string baseDir = string.Empty;

        /// <summary>
        /// 数据目录
        /// </summary>
        public string dataDir = string.Empty;

        /// <summary>
        /// 文件目录
        /// </summary>
        public string filesDir = string.Empty;

        /// <summary>
        /// 初始的分割器宽度
        /// </summary>
        public int defaultSplitterDistance = 200;

        public override void start()
        {
            //载入配置
            configFile = System.IO.Path.Combine(RootDir, "config.cfg");
            JsonConfig.loadConfig(configFile);

            //添加点击事件
            Parent_LeftTreeView.AfterSelect += Parent_LeftTreeView_AfterSelect;

            //设置分割器位置
            foreach (Control c in Parent_Form.Controls)
            {
                if (c.Name == "scContent")
                {
                    ((SplitContainer)c).SplitterDistance = defaultSplitterDistance;
                    break;
                }
            }

            //初始化目录
            initDirs();

            //打开数据库
            openDB();

            //初始化树结构
            initTrees();

            //初始化顶部工具条
            initTopToolBar();

            //初始化编辑器字典
            initEditorMaps();

            //初始化数据
            initData();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public abstract void initData();

        /// <summary>
        /// 初始化编辑器字典
        /// </summary>
        public abstract void initEditorMaps();

        /// <summary>
        /// 初始化顶部工具条
        /// </summary>
        public abstract void initTopToolBar();

        /// <summary>
        /// 打开数据库
        /// </summary>
        public abstract void openDB();

        /// <summary>
        /// 初始化目录结构
        /// </summary>
        public abstract void initDirs();

        /// <summary>
        /// 初始化树结构
        /// </summary>
        public abstract void initTrees();

        /// <summary>
        /// 显示编辑器
        /// </summary>
        /// <param name="nodeTexts"></param>
        public virtual void showEditor(string nodeTexts)
        {
            if (editorMap.ContainsKey(nodeTexts))
            {
                Parent_RightContentPanel.Controls.Clear();
                editorMap[nodeTexts].Dock = DockStyle.Fill;
                Parent_RightContentPanel.Controls.Add(editorMap[nodeTexts]);
            }
        }

        /// <summary>
        /// 刷新编辑器
        /// </summary>
        public virtual void refreshEditors()
        {
            if (projectObj != null)
            {
                foreach (BaseEditor be in editorMap.Values)
                {
                    be.refreshView();
                }
            }
        }

        /// <summary>
        /// 获得最后更新日期
        /// </summary>
        /// <returns></returns>
        public virtual DateTime getLastUpdateDate()
        {
            DateTime dtResults = DateTime.MinValue;

            if (JsonConfig.Config.ObjectDict.ContainsKey("保存日期"))
            {
                try
                {
                    dtResults = (DateTime)JsonConfig.Config.ObjectDict["保存日期"];
                }
                catch (Exception ex)
                {
                    dtResults = DateTime.MinValue;
                }
            }
            else
            {
                dtResults = DateTime.MinValue;
            }

            return dtResults;
        }

        /// <summary>
        /// 更新保存日期
        /// </summary>
        public virtual void updateSaveDate()
        {
            JsonConfig.Config.ObjectDict["保存日期"] = DateTime.Now;
            JsonConfig.saveConfig(configFile);
        }

        /// <summary>
        /// 保存所有编辑器
        /// </summary>
        public virtual void saveAllWithNoResult()
        {
            if (projectObj != null)
            {
                CircleProgressBarDialog dialoga = new CircleProgressBarDialog();
                dialoga.TransparencyKey = dialoga.BackColor;
                dialoga.ProgressBar.ForeColor = Color.Red;
                dialoga.MessageLabel.ForeColor = Color.Blue;
                dialoga.FormBorderStyle = FormBorderStyle.None;
                dialoga.MessageLabel.Text = "正在保存,请等待...";
                dialoga.Start(new EventHandler<CircleProgressBarEventArgs>(delegate(object thisObject, CircleProgressBarEventArgs argss)
                {
                    //创建一个倒叙列表用于解决因为保存顺序问题导致的某些列表项保存失败的BUG
                    List<BaseEditor> tempLists = new List<BaseEditor>();
                    tempLists.AddRange(editorMap.Values);
                    tempLists.Reverse();

                    if (((CircleProgressBarDialog)thisObject).IsHandleCreated)
                    {
                        ((CircleProgressBarDialog)thisObject).Invoke(new MethodInvoker(delegate()
                        {
                            //循环所有控件，一个一个保存
                            int currentIndex = 0;
                            foreach (BaseEditor be in tempLists)
                            {
                                currentIndex++;

                                //保存
                                try
                                {
                                    bool isSuccess = true;
                                    be.onSaveEvent(ref isSuccess);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("对不起，页签(" + be.EditorName + ")保存失败！Ex:" + ex.ToString());
                                }

                                //进度条移动
                                ((CircleProgressBarDialog)thisObject).ReportProgress((int)(((double)currentIndex / (double)tempLists.Count) * 100), 100);

                                //立即执行消息
                                Application.DoEvents();
                            }
                        }));
                    }

                    //刷新
                    if (((CircleProgressBarDialog)thisObject).IsHandleCreated)
                    {
                        ((CircleProgressBarDialog)thisObject).Invoke(new MethodInvoker(delegate()
                        {
                            refreshEditors();
                        }));
                    }
                }));
            }
        }

        /// <summary>
        /// 保存所有(返回是否成功)
        /// </summary>
        public virtual bool isSaveAllSucess()
        {
            if (projectObj != null)
            {
                bool isSucesss = true;

                Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
                upf.LabalText = "正在保存,请等待...";
                upf.ShowProgressWithOnlyUI();
                upf.PlayProgressWithOnlyUI(80);

                try
                {
                    //创建一个倒叙列表用于解决因为保存顺序问题导致的某些列表项保存失败的BUG
                    List<BaseEditor> tempLists = new List<BaseEditor>();
                    tempLists.AddRange(editorMap.Values);
                    tempLists.Reverse();

                    //循环所有控件，一个一个保存
                    foreach (BaseEditor be in tempLists)
                    {
                        //保存
                        try
                        {
                            be.onSaveEvent(ref isSucesss);
                            if (isSucesss == false)
                            {
                                throw new Exception("内容未填写完");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("对不起，页签(" + be.EditorName + ")保存失败！Ex:" + ex.ToString());
                            isSucesss = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败！Ex:" + ex.ToString());
                }
                finally
                {
                    upf.CloseProgressWithOnlyUI();
                }

                return isSucesss;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否输入完成
        /// </summary>
        /// <returns></returns>
        public virtual bool isInputCompleted(ref string errorPageName)
        {
            foreach (BaseEditor be in editorMap.Values)
            {
                if (be.isInputCompleted())
                {
                    continue;
                }
                else
                {
                    errorPageName = be.EditorName;
                    return false;
                }
            }

            return true;
        }

        protected virtual void Parent_LeftTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switchCurrentEditor(e.Node);
        }

        /// <summary>
        /// 切换当前编辑器
        /// </summary>
        /// <param name="treeNode"></param>
        protected abstract void switchCurrentEditor(TreeNode treeNode);

        /// <summary>
        /// 失败
        /// </summary>
        public override void stop(FormClosingEventArgs e)
        {
            if (e != null && enabledShowExitHint)
            {
                if (MessageBox.Show("真的要退出吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //关闭数据库
                    closeDB();

                    #region 清理所有增加的内容
                    if (Parent_RightContentPanel.IsHandleCreated)
                    {
                        Parent_RightContentPanel.Invoke(new MethodInvoker(delegate()
                        {
                            clearAllControls();
                        }));
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
                //关闭数据库
                closeDB();

                #region 清理所有增加的内容
                if (Parent_RightContentPanel.IsHandleCreated)
                {
                    Parent_RightContentPanel.Invoke(new MethodInvoker(delegate()
                    {
                        clearAllControls();
                    }));
                }
                #endregion
            }
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        public abstract void closeDB();

        /// <summary>
        /// 获得项目对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T getProjectObject<T>()
        {
            return (T)projectObj;
        }

        /// <summary>
        /// 重新加载工程
        /// </summary>
        public virtual void reloadProject()
        {
            CircleProgressBarDialog dialogb = new CircleProgressBarDialog();
            dialogb.TransparencyKey = dialogb.BackColor;
            dialogb.ProgressBar.ForeColor = Color.Red;
            dialogb.MessageLabel.ForeColor = Color.Blue;
            dialogb.FormBorderStyle = FormBorderStyle.None;
            dialogb.Start(new EventHandler<CircleProgressBarEventArgs>(delegate(object thisObject, CircleProgressBarEventArgs argss)
                {
                    CircleProgressBarDialog senderForm = (CircleProgressBarDialog)thisObject;

                    //重新加载工程
                    reloadProject(senderForm);
                }));
        }

        /// <summary>
        /// 重新加载工程
        /// </summary>
        /// <param name="senderForm"></param>
        public virtual void reloadProject(CircleProgressBarDialog senderForm)
        {
            report(senderForm, 20, "正在准备...", 500);
            if (senderForm.IsHandleCreated)
            {
                senderForm.Invoke(new MethodInvoker(delegate()
                {
                    //清空视图中的内容
                    for (int kkk = 0; kkk < editorMap.Count; kkk++)
                    {
                        editorMap[kkk].Value.clearView();
                    }
                    //关闭连接
                    closeDB();
                }));
            }

            report(senderForm, 40, "正在检查目录及数据库结构...", 500);
            if (senderForm.IsHandleCreated)
            {
                senderForm.Invoke(new MethodInvoker(delegate()
                {
                    //初始化目录结构
                    initDirs();
                }));
            }

            report(senderForm, 60, "正在恢复数据库...", 500);
            if (senderForm.IsHandleCreated)
            {
                senderForm.Invoke(new MethodInvoker(delegate()
                {
                    //恢复并打开数据库
                    openDB();
                }));
            }

            report(senderForm, 80, "正在载入数据...", 500);
            if (senderForm.IsHandleCreated)
            {
                senderForm.Invoke(new MethodInvoker(delegate()
                {
                    //初始化数据
                    initData();
                }));
            }

            report(senderForm, 100, "正在刷新编辑器...", 500);
            if (senderForm.IsHandleCreated)
            {
                senderForm.Invoke(new MethodInvoker(delegate()
                {
                    //刷新编辑器页
                    refreshEditors();
                }));
            }
        }

        /// <summary>
        /// 显示进度
        /// </summary>
        /// <param name="progressDialog"></param>
        /// <param name="progress"></param>
        /// <param name="txt"></param>
        /// <param name="sleepTime"></param>
        public static void report(CircleProgressBarDialog progressDialog, int progress, string txt, int sleepTime)
        {
            progressDialog.ReportProgress(progress, 100);
            progressDialog.ReportInfo(txt);
            try
            {
                Thread.Sleep(sleepTime);
            }
            catch (Exception ex) { }
        }
    }
}