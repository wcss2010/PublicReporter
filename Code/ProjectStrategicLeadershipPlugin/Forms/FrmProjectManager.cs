﻿using ProjectStrategicLeadershipPlugin.DB.Entitys;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                        TreeNode tn = new TreeNode();
                        tn.Text = proj.ProjectName + "," + proj.UnitName + "," + proj.ProjectMasterName + "(正在使用)";
                        tn.Name = di.Name;
                        tn.Tag = proj;
                        tvProject.Nodes.Add(tn);
                    }
                    else
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = proj.ProjectName + "," + proj.UnitName + "," + proj.ProjectMasterName;
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
            if (tvProject.SelectedNode != null)
            {
                if (tvProject.SelectedNode.Text.EndsWith("(正在使用)"))
                {
                    return;
                }
                else
                {
                    if (System.IO.Directory.Exists(getPkgDir(tvProject.SelectedNode.Name)))
                    {
                        if (MessageBox.Show("真的要编辑该数据包吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                switchToCurrent(tvProject.SelectedNode.Name);

                                MessageBox.Show("项目加载完成！");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("对不起，项目加载失败！Ex:" + ex.ToString());
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获得包路径
        /// </summary>
        /// <param name="pkgDirName"></param>
        /// <returns></returns>
        private string getPkgDir(string pkgDirName)
        {
            return System.IO.Path.Combine(System.IO.Path.Combine(PluginRootObj.RootDir, "Data"), pkgDirName);
        }

        /// <summary>
        /// 切换到编辑状态
        /// </summary>
        /// <param name="pkgDirName"></param>
        private void switchToCurrent(string pkgDirName)
        {
            string ddDir = System.IO.Path.Combine(PluginRootObj.RootDir, "Data");

            //项目ID
            string projId = PluginRootObj.projectObj != null ? ((Projects)PluginRootObj.projectObj).ID : Guid.NewGuid().ToString();

            //临时目录名
            string tempDirName = projId + "_" + DateTime.Now.Ticks;

            //关闭连接
            PluginRootObj.closeDB();

            //当前项目目录
            string currentPath = System.IO.Path.Combine(ddDir, "Current");

            //目标目录
            string destPath = System.IO.Path.Combine(ddDir, tempDirName);

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
            System.IO.Directory.Move(System.IO.Path.Combine(ddDir, pkgDirName), currentPath);

            //重新载入工程
            PluginRootObj.reloadProject();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tvProject.SelectedNode != null)
            {
                if (tvProject.SelectedNode.Text.EndsWith("(正在使用)"))
                {
                    return;
                }
                else
                {
                    if (System.IO.Directory.Exists(getPkgDir(tvProject.SelectedNode.Name)))
                    {
                        if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                System.IO.Directory.Delete(getPkgDir(tvProject.SelectedNode.Name), true);
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

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ZIP申报包|*.zip";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("真的要导入吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CircleProgressBarDialog dialogb = new CircleProgressBarDialog();
                    dialogb.TransparencyKey = dialogb.BackColor;
                    dialogb.ProgressBar.ForeColor = Color.Red;
                    dialogb.MessageLabel.ForeColor = Color.Blue;
                    dialogb.FormBorderStyle = FormBorderStyle.None;
                    dialogb.Start(new EventHandler<CircleProgressBarEventArgs>(delegate(object thisObject, CircleProgressBarEventArgs argss)
                    {
                        CircleProgressBarDialog senderForm = (CircleProgressBarDialog)thisObject;

                        AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 10, "准备导入...", 600);

                        //解压目录
                        string destDecompressDir = getPkgDir(Guid.NewGuid().ToString() + "_" + DateTime.Now.Ticks);

                        AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 30, "创建导入目录...", 600);

                        //创建当前目录
                        try
                        {
                            Directory.CreateDirectory(destDecompressDir);
                        }
                        catch (Exception ex) { }

                        AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 40, "正在导入...", 600);

                        //解压
                        new PublicReporterLib.Utility.ZipUtil().UnZipFile(ofd.FileName, destDecompressDir, string.Empty, true);

                        AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 90, "导入完成，正在刷新...", 600);

                        //刷新列表
                        if (IsHandleCreated)
                        {
                            Invoke(new MethodInvoker(delegate()
                                {
                                    updateProjects();
                                }));
                        }                        
                    }));
                }
            }
        }
    }
}