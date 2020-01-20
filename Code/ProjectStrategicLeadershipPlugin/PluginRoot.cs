using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

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

        /// <summary>
        /// 生成一个工具条按钮
        /// </summary>
        /// <param name="imgg"></param>
        /// <param name="nameg"></param>
        /// <param name="textg"></param>
        /// <param name="sizeg"></param>
        /// <returns></returns>
        protected ToolStripButton getTopButton(Image imgg, string nameg, string textg, Size sizeg)
        {
            return getTopButton(imgg, nameg, textg, sizeg, new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
        }

        /// <summary>
        /// 添加顶部工具条按钮
        /// </summary>
        /// <param name="imgg"></param>
        /// <param name="nameg"></param>
        /// <param name="textg"></param>
        /// <param name="sizeg"></param>
        protected void addTopButton(Image imgg, string nameg, string textg, Size sizeg)
        {
            ToolStripButton tempButton = getTopButton(imgg, nameg, textg, sizeg);
            tempButton.Click += tempButton_Click;
            addToTopToolStrip(tempButton);
        }

        void tempButton_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = PublicReporterLib.Utility.ExcelBuilder.excelToDataTable(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "数据库结构-ss.xlsx"), "Sheet1", true);
            string lastTable = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                if (dr[0] != null)
                {
                    if (lastTable == dr[0].ToString())
                    {
                        //增加
                        sb.Append(" [").Append(dr[3].ToString()).Append("] [").Append(dr[4].ToString()).Append("],");
                    }
                    else
                    {
                        //输出
                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append(");");
                        System.Console.WriteLine();
                        System.Console.WriteLine(sb.ToString());
                        sb = new StringBuilder();
                        sb.Append("CREATE TABLE [").Append(dr[0].ToString()).Append("](");
                        lastTable = dr[0].ToString();
                    }
                }
            }
        }

        public override void initTopToolBar()
        {
            addTopButton(new Bitmap(20, 20), Guid.NewGuid().ToString(), "测试", new System.Drawing.Size(53, 56));
        }

        public override void initData()
        {

        }

        protected override void switchCurrentEditor(System.Windows.Forms.TreeNode treeNode)
        {
            
        }
    }
}