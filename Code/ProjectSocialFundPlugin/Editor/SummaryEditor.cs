using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicReporterLib.Utility;
using ProjectSocialFundPlugin.DB;
using ProjectSocialFundPlugin.DB.Entitys;
using Newtonsoft.Json;
using ProjectSocialFundPlugin.Forms;
using AbstractEditorPlugin;
using AbstractEditorPlugin.Controls;
using AbstractEditorPlugin.Forms;
using AbstractEditorPlugin.Utility;

namespace ProjectSocialFundPlugin.Editor
{
    public partial class SummaryEditor : BaseEditor
    {
        public SummaryEditor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FrmWorkProcess upf = new FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                bool result = true;
                onSaveEvent(ref result);
                PluginRootObj.refreshEditors();

                //更新保存日期
                PluginRootObj.updateSaveDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！Ex:" + ex.ToString());
            }
            finally
            {
                upf.CloseProgressWithOnlyUI();
            }
        }

        public override void onSaveEvent(ref bool result)
        {
            base.onSaveEvent(ref result);

            

            //检查是否需要创建项目对象
            if (PluginRootObj.projectObj == null)
            {
                PluginRootObj.projectObj = new Projects();
            }

            //获得项目对象
            Projects proj = PluginRootObj.getProjectObject<Projects>();
                        
            //更新数据库
            if (string.IsNullOrEmpty(proj.ID))
            {
                proj.ID = Guid.NewGuid().ToString();
                proj.copyTo(ConnectionManager.Context.table("Projects")).insert();
            }
            else
            {
                proj.copyTo(ConnectionManager.Context.table("Projects")).where("ID='" + proj.ID + "'").update();
            }
        }

        public override void refreshView()
        {
            base.refreshView();

            //加载数据
            if (PluginRootObj.projectObj != null)
            {
                Projects proj = PluginRootObj.getProjectObject<Projects>();

            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (flowLayoutPanel1 != null)
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    c.Width = flowLayoutPanel1.Width - 20;
                    c.Margin = new Padding(0, 30, 0, 0);
                }
            }
        }

        public override bool isInputCompleted()
        {
            return true;
        }

        public override void clearView()
        {
            base.clearView();

            
        }
    }
}