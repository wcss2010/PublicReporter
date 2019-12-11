using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ProjectMilitaryTechnologPlanPlugin.Editor
{
    public partial class InfoEditor : BaseEditor
    {
        public InfoEditor()
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
                bool result = true;
                OnSaveEvent(ref result);
                PublicReporterLib.PluginLoader.getLocalPluginRoot<ProjectMilitaryTechnologPlanPlugin.PluginRoot>().refreshEditors();
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

        public override void OnSaveEvent(ref bool result)
        {
            base.OnSaveEvent(ref result);

        }

        public override void RefreshView()
        {
            base.RefreshView();

            //加载数据
            if (PluginRootObj.projectObj != null)
            {
                ibEdit1.Text = PluginRootObj.projectObj.XiangMuMingCheng;
                ibEdit11.Text = PluginRootObj.projectObj.QianTouRen;
                ibEdit13.Text = PluginRootObj.projectObj.QianTouRenXingBie;
                ibEdit14.Text = PluginRootObj.projectObj.QianTouRenMinZu;
                ibEdit15.Value = PluginRootObj.projectObj.QianTouRenShengRi;
                ibEdit18.Text = PluginRootObj.projectObj.BuZhiBie;
                ibEdit19.Text = PluginRootObj.projectObj.LianHeYanJiuDanWei;
                ibEdit20.Text = PluginRootObj.projectObj.ShenQingJingFei + "";
                ibEdit21.Value = PluginRootObj.projectObj.JiHuaWanChengShiJian;

                StringBuilder sb = new StringBuilder();
                if (PluginRootObj.projectObj.YuQiChengGuo != null && PluginRootObj.projectObj.YuQiChengGuo.Contains(UIControlConfig.rowFlag))
                {
                    string[] tttt = PluginRootObj.projectObj.YuQiChengGuo.Split(new string[] { UIControlConfig.rowFlag }, StringSplitOptions.None);
                    if (tttt != null)
                    {
                        foreach (string ss in tttt)
                        {
                            string[] vvvv = ss.Split(new string[] { UIControlConfig.cellFlag }, StringSplitOptions.None);
                            if (vvvv != null && vvvv.Length >= 2)
                            {
                                if (string.IsNullOrEmpty(vvvv[0])) { continue; }

                                sb.Append(vvvv[0]).Append(":").Append(vvvv[1]).AppendLine();
                            }
                        }
                    }
                }
                txtWantResult.Text = sb.ToString();
            }
        }

        private void dgvWorkers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dgvWorkers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}