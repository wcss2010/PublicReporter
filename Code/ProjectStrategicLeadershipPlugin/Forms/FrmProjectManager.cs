using ProjectStrategicLeadershipPlugin.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectStrategicLeadershipPlugin.Forms
{
    public partial class FrmProjectManager : AbstractEditorPlugin.BaseForm
    {
        public FrmProjectManager()
        {
            InitializeComponent();

            updateProjects();
        }

        private void updateProjects()
        {
            tvProject.Nodes.Clear();
            string[] dirs = System.IO.Directory.GetDirectories(System.IO.Path.Combine(PluginRootObj.RootDir, "Data"));
            foreach (string s in dirs)
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(s);
                Projects proj = getProjectObject(s);
                if (proj != null && proj.ProjectName != null && proj.ProjectName.Length >= 1)
                {
                    if (di.Name == "Current")
                    {
                        Text = "项目管理(当前:" + proj.ProjectName + ")";
                    }
                    else
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = di.Name + "(" + proj.ProjectName + ")";
                        tn.Name = di.Name;
                        tn.Tag = proj;
                        tvProject.Nodes.Add(tn);
                    }
                }
            }
        }

        /// <summary>
        /// 获得项目信息
        /// </summary>
        /// <param name="projectDir"></param>
        /// <returns></returns>
        public Projects getProjectObject(string projectDir)
        {
            Projects proj = null;
            string dbFile = System.IO.Path.Combine(projectDir, "static.db");

            if (System.IO.File.Exists(dbFile))
            {
                System.Data.SQLite.SQLiteFactory factory = new System.Data.SQLite.SQLiteFactory();
                Noear.Weed.DbContext context = new Noear.Weed.DbContext("main", "Data Source=" + dbFile, factory);
                context.IsSupportSelectIdentityAfterInsert = false;
                context.IsSupportGCAfterDispose = true;
                try
                {
                    proj = context.table("Projects").select("*").getItem<Projects>(new Projects());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    try
                    {
                        factory.Dispose();
                    }
                    catch (Exception ex) { }
                    factory = null;

                    try
                    {
                        context.Dispose();
                    }
                    catch (Exception ex) { }
                    context = null;
                }
            }

            return proj;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (tvProject.SelectedNode != null && System.IO.Directory.Exists(System.IO.Path.Combine(System.IO.Path.Combine(PluginRootObj.RootDir, "Data"), tvProject.SelectedNode.Name)))
            {
                if (MessageBox.Show("真的要切换吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    string uuid = PluginRootObj.projectObj != null ? ((Projects)PluginRootObj.projectObj).ID : Guid.NewGuid().ToString();

                    //关闭连接
                    PluginRootObj.closeDB();

                    //当前项目目录
                    string currentPath = System.IO.Path.Combine(System.IO.Path.Combine(PluginRootObj.RootDir, "Data"), "Current");

                    //目标目录
                    string destPath = System.IO.Path.Combine(System.IO.Path.Combine(PluginRootObj.RootDir, "Data"), uuid);

                    //移动当前目录
                    if (System.IO.Directory.Exists(currentPath))
                    {
                        if (System.IO.Directory.Exists(destPath))
                        {
                            System.IO.Directory.Delete(destPath, true);
                        }

                        System.IO.Directory.Move(currentPath, destPath);
                    }

                    //将这个目录切换为当前目录
                    System.IO.Directory.Move(System.IO.Path.Combine(System.IO.Path.Combine(PluginRootObj.RootDir, "Data"), tvProject.SelectedNode.Name), currentPath);

                    //打开数据库
                    PluginRootObj.openDB();

                    //初始化数据
                    PluginRootObj.initData();

                    //刷新编辑器
                    PluginRootObj.refreshEditors();
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tvProject.SelectedNode != null)
            {
                if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        System.IO.Directory.Delete(System.IO.Path.Combine(System.IO.Path.Combine(PluginRootObj.RootDir, "Data"), tvProject.SelectedNode.Name), true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除错误！Ex:" + ex.ToString());
                    }

                    updateProjects();
                }
            }
        }
    }
}