using ProjectReporterPlugin.DB.Entitys;
using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjectReporterPlugin.Forms
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
                Project proj = getProjectObject(s);
                if (proj != null && proj.Name != null && proj.Name.Length >= 1)
                {
                    if (di.Name == "Current")
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = proj.Name + "(正在使用)";
                        tn.Name = di.Name;
                        tn.Tag = proj;
                        tvProject.Nodes.Add(tn);
                    }
                    else
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = proj.Name;
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
        public Project getProjectObject(string projectDir)
        {
            Project proj = null;
            string dbFile = System.IO.Path.Combine(projectDir, "static.db");

            if (System.IO.File.Exists(dbFile))
            {
                System.Data.SQLite.SQLiteFactory factory = new System.Data.SQLite.SQLiteFactory();
                Noear.Weed.DbContext context = new Noear.Weed.DbContext("main", "Data Source=" + dbFile, factory);
                context.IsSupportSelectIdentityAfterInsert = false;
                context.IsSupportGCAfterDispose = true;
                try
                {
                    proj = context.table("Project").where("Type='" + "项目" + "'").select("*").getItem<Project>(new Project());

                    Person projectPersonObj = context.table("Person").where("ID in (select PersonID from task where Role='负责人' and Type='项目' and ProjectID = '" + proj.ID + "')").select("*").getItem<Person>(new Person());
                    if (projectPersonObj == null)
                    {
                        throw new Exception("项目负责人为空！");
                    }
                    Unit projectUnitObj = context.table("Unit").where("ID = '" + proj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                    if (projectUnitObj == null)
                    {
                        throw new Exception("项目负责单位为空");
                    }

                    proj.Name += "," + projectUnitObj.UnitName + "," + projectPersonObj.Name;
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
                    MessageBox.Show("对不起，当前项目正在编辑，不能进行此操作！");
                    return;
                }
                else
                {
                    if (System.IO.Directory.Exists(getPkgDir(tvProject.SelectedNode.Name)))
                    {
                        if (MessageBox.Show("真的要编辑该数据包吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (PluginRootObj.isUsingDir(getPkgDir(tvProject.SelectedNode.Name), false) || PluginRootObj.isUsingDir(PluginRootObj.dataDir, true))
                            {
                                MessageBox.Show("对不起，编辑该数据包失败，因为您可能打开了某些文件或目录没有关闭！");
                            }
                            else
                            {
                                try
                                {
                                    PluginRootObj.switchProject(tvProject.SelectedNode.Name);
                                    Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("对不起，请检查您是否打开了某个word文件或目录没有关闭，然后重试！");
                                }
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tvProject.SelectedNode != null)
            {
                if (tvProject.SelectedNode.Text.EndsWith("(正在使用)"))
                {
                    MessageBox.Show("对不起，当前项目正在编辑，不能进行此操作！");
                    return;
                }
                else
                {
                    if (System.IO.Directory.Exists(getPkgDir(tvProject.SelectedNode.Name)))
                    {
                        if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string projDir = getPkgDir(tvProject.SelectedNode.Name);

                            if (PluginRootObj.isUsingDir(projDir, false))
                            {
                                MessageBox.Show("对不起，删除失败，因为您可能打开了某些文件或目录没有关闭！");
                            }
                            else
                            {
                                try
                                {
                                    System.IO.Directory.Delete(projDir, true);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("对不起，请检查您是否打开了某个word文件或目录没有关闭，然后重试！");
                                }

                                updateProjects();
                            }
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

                        //解压到临时目录先
                        string decompressTemp = getPkgDir(Guid.NewGuid().ToString() + "_" + DateTime.Now.Ticks + "_Temp");
                        try
                        {
                            Directory.CreateDirectory(decompressTemp);
                        }
                        catch (Exception ex) { }
                        new PublicReporterLib.Utility.ZipUtil().UnZipFile(ofd.FileName, decompressTemp, string.Empty, true);
                        
                        AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 30, "创建导入目录...", 600);

                        //读取数据对象
                        Project projObj = getProjectObject(decompressTemp);
                        //解压目录
                        string destDecompressDir = getPkgDir((projObj != null && !string.IsNullOrEmpty(projObj.ID) ? projObj.ID : Guid.NewGuid().ToString()) + "_" + DateTime.Now.Ticks);
                        //创建当前目录
                        try
                        {
                            if (Directory.Exists(destDecompressDir))
                            {
                                Directory.Delete(destDecompressDir, true);
                            }
                        }
                        catch (Exception ex) { }

                        AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 40, "正在导入...", 600);

                        //移到临时目录到目标地址
                        Directory.Move(decompressTemp, destDecompressDir);

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