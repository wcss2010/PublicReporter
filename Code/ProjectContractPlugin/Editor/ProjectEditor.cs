using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ProjectContractPlugin.Editor
{
    public partial class ProjectEditor : BaseEditor
    {
        public ProjectEditor()
        {
            InitializeComponent();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                OnSaveEvent();
                ((ProjectContractPlugin.PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).refreshEditors();
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

        public override void RefreshView()
        {
            base.RefreshView();
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();
        }

        public override bool IsInputCompleted()
        {
            return true;
        }
    }
}