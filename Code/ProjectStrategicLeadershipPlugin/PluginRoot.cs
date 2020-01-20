using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectStrategicLeadershipPlugin
{
    public class PluginRoot : AbstractEditorPlugin.AbstractPluginRoot
    {
        public override string DefaultTitle
        {
            get { return "国防科技战略先导计划项目建议书填报系统(V1.0)"; }
        }

        /// <summary>
        /// 初始化目录
        /// </summary>
        public override void initDirs()
        {
            baseDir = Path.Combine(RootDir, "Data");
            try
            {
                Directory.CreateDirectory(baseDir);
            }
            catch (Exception ex) { }
            dataDir = Path.Combine(baseDir, "Current");
            try
            {
                Directory.CreateDirectory(dataDir);
            }
            catch (Exception ex) { }
            filesDir = Path.Combine(dataDir, "Files");
            try
            {
                Directory.CreateDirectory(filesDir);
            }
            catch (Exception ex) { }
        }

        public override void openDB()
        {

        }

        public override void closeDB()
        {

        }

        public override void initTrees()
        {

        }

        public override void initEditorMaps()
        {
            
        }

        public override void initTopToolBar()
        {
            
        }

        public override void initData()
        {

        }

        protected override void switchCurrentEditor(System.Windows.Forms.TreeNode treeNode)
        {
            
        }
    }
}