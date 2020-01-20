using PublicReporterLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AbstractEditorPlugin
{
    /// <summary>
    /// 根据已经有ProjectMilitaryTechnologPlanPlugin插件抽象出来的一个模板
    /// </summary>
    public abstract class AbstractPluginRoot<ProjectObject> : IReportPluginRoot
    {
        /// <summary>
        /// 工程对象
        /// </summary>
        public ProjectObject ProjectObj { get; set; }

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
        public string ConfigFile { get; private set; }

        public override void start()
        {
            //载入配置
            ConfigFile = System.IO.Path.Combine(RootDir, "config.cfg");
            JsonConfig.loadConfig(ConfigFile);

            //添加点击事件
            Parent_LeftTreeView.AfterSelect += Parent_LeftTreeView_AfterSelect;

            //设置分割器位置
            foreach (Control c in Parent_Form.Controls)
            {
                if (c.Name == "scContent")
                {
                    ((SplitContainer)c).SplitterDistance = 200;
                    break;
                }
            }

            //初始化树结构
            initTrees();

            //初始化目录
            initDirs();

            //打开数据库
            openDB();

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
            if (ProjectObj != null)
            {
                foreach (BaseEditor be in editorMap.Values)
                {
                    be.RefreshView();
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
            JsonConfig.saveConfig(ConfigFile);
        }

        void Parent_LeftTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

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
    }
}