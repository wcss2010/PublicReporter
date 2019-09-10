using ProjectContractPlugin.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectContractPlugin.Forms
{
    public partial class FrmProjectManager : PublicReporterLib.SuperForm
    {
        public FrmProjectManager()
        {
            InitializeComponent();

            updateProjects();
        }

        private void updateProjects()
        {
            tvProject.Nodes.Clear();
            string[] dirs = System.IO.Directory.GetDirectories(System.IO.Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).RootDir, "Data"));
            foreach (string s in dirs)
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(s);
                JiBenXinXiBiao proj = getProjectObject(s);
                if (proj != null && proj.HeTongMingCheng != null && proj.HeTongMingCheng.Length >= 1)
                {
                    if (di.Name == "Current")
                    {
                        Text = "项目管理(当前:" + proj.HeTongMingCheng + ")";
                    }
                    else
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = di.Name + "(" + proj.HeTongMingCheng + ")";
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
        public JiBenXinXiBiao getProjectObject(string projectDir)
        {
            JiBenXinXiBiao proj = null;
            string dbFile = System.IO.Path.Combine(projectDir, "static.db");

            if (System.IO.File.Exists(dbFile))
            {
                System.Data.SQLite.SQLiteFactory factory = new System.Data.SQLite.SQLiteFactory();
                Noear.Weed.DbContext context = new Noear.Weed.DbContext("main", "Data Source=" + dbFile, factory);
                context.IsSupportInsertAfterSelectIdentity = false;
                context.IsSupportGCAfterDispose = true;
                try
                {
                    proj = context.table("JiBenXinXiBiao").select("*").getItem<JiBenXinXiBiao>(new JiBenXinXiBiao());
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
            if (tvProject.SelectedNode != null && System.IO.Directory.Exists(System.IO.Path.Combine(System.IO.Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).RootDir, "Data"), tvProject.SelectedNode.Name)))
            {
                if (MessageBox.Show("真的要切换吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    string uuid = ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj != null ? ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj.BianHao : Guid.NewGuid().ToString();

                    //关闭连接
                    DB.ConnectionManager.Close();

                    //当前项目目录
                    string currentPath = System.IO.Path.Combine(System.IO.Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).RootDir, "Data"), "Current");

                    //目标目录
                    string destPath = System.IO.Path.Combine(System.IO.Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).RootDir, "Data"), uuid);

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
                    System.IO.Directory.Move(System.IO.Path.Combine(System.IO.Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).RootDir, "Data"), tvProject.SelectedNode.Name), currentPath);

                    ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).enabledShowExitHint = false;
                    DB.ConnectionManager.Close();
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    ((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).projectObj = null;
                    Application.Exit();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (ofdSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //新项目目录
                string newProjectDir = System.IO.Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).RootDir, System.IO.Path.Combine("Data", Guid.NewGuid().ToString()));

                SuperCodeFactoryUILib.Forms.CircleProgressBarDialog dialog = new SuperCodeFactoryUILib.Forms.CircleProgressBarDialog();
                dialog.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                dialog.TransparencyKey = dialog.BackColor;
                dialog.ProgressBar.ForeColor = Color.Red;
                dialog.MessageLabel.ForeColor = Color.Blue;
                dialog.Start(new EventHandler<SuperCodeFactoryUILib.Forms.CircleProgressBarEventArgs>(delegate(object thisObj, SuperCodeFactoryUILib.Forms.CircleProgressBarEventArgs args)
                {
                    try
                    {
                        dialog.ReportProgress(20, 100);
                        dialog.ReportInfo("创建导入目录");
                        try
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                        catch (Exception ex) { }

                        //创建目录
                        try
                        {
                            System.IO.Directory.CreateDirectory(newProjectDir);
                        }
                        catch (Exception ex) { }

                        dialog.ReportProgress(40, 100);
                        dialog.ReportInfo("准备解包");

                        //解压需要导入的包                        
                        new PublicReporterLib.Utility.ZipUtil().UnZipFile(ofdSelect.FileName, newProjectDir, string.Empty, true);
                    }
                    catch (Exception ex)
                    {
                        dialog.ReportProgress(90, 100);
                        dialog.ReportInfo("解包出错，正在删除导入目录");
                        try
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                        catch (Exception exx) { }

                        if (System.IO.Directory.Exists(newProjectDir))
                        {
                            System.IO.Directory.Delete(newProjectDir);
                        }
                    }

                    dialog.ReportProgress(98, 100);
                    dialog.ReportInfo("刷新列表");
                    try
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception ex) { }

                    //更新列表
                    Invoke(new MethodInvoker(delegate()
                        {
                            updateProjects();
                        }));                    
                }));
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
                        System.IO.Directory.Delete(System.IO.Path.Combine(System.IO.Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).RootDir, "Data"), tvProject.SelectedNode.Name), true);
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