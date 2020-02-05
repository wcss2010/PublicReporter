using ProjectStrategicLeadershipPlugin.DB.Entitys;
using ProjectStrategicLeadershipPlugin.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProjectStrategicLeadershipPlugin.Forms
{
    public partial class FrmAddOrUpdateConfidentialQualification : AbstractEditorPlugin.BaseForm
    {
        public FrmAddOrUpdateConfidentialQualification(ExtFiles obj)
        {
            InitializeComponent();

            DataObj = obj;
        }
        
        private void FrmAddOrUpdateWorker_Load(object sender, EventArgs e)
        {
            if (DataObj != null)
            {
                txtUnitName.Text = DataObj.ExtName;

                if (DataObj.IsIgnore == 0)
                {
                    rbNormalUnit.Checked = true;

                    txtImgFile.Text = DataObj.SourceFileName;
                    txtImgFile.Tag = Path.Combine(PluginRootObj.filesDir, DataObj.RealFileName);
                }
                else
                {
                    rbArmyUnit.Checked = true;
                }
            }
            else
            {
                DataObj = new ExtFiles();
            }
        }

        public ExtFiles DataObj { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUnitName.Text)
                || (rbNormalUnit.Checked == true && (txtImgFile.Tag == null || txtImgFile.Tag == "")))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }
            else
            {
                DataObj.ExtName = txtUnitName.Text;
                DataObj.SourceFileName = txtImgFile.Text;
                DataObj.IsIgnore = rbNormalUnit.Checked ? 0 : 1;
                
                //检查是否需要传文件
                if (txtImgFile.Tag != null)
                {
                    if (txtImgFile.Tag.ToString().StartsWith(PluginRootObj.filesDir))
                    {
                        //不需要传文件
                    }
                    else
                    {
                        if (File.Exists(txtImgFile.Tag.ToString()))
                        {
                            //传文件
                            try
                            {
                                //生成新的文件名
                                DataObj.RealFileName = DateTime.Now.Ticks + "_" + DataObj.SourceFileName;

                                //上传
                                File.Copy(txtImgFile.Tag.ToString(), Path.Combine(PluginRootObj.filesDir, DataObj.RealFileName));
                            }
                            catch (Exception ex)
                            {
                                //弹出错提示
                                MessageBox.Show("对不起，文件(" + txtImgFile.Tag.ToString() + ")上传失败！Ex:" + ex.ToString());
                                return;
                            }
                        }
                        else
                        {
                            //弹出错提示
                            MessageBox.Show("对不起，文件(" + txtImgFile.Tag.ToString() + ")不存在！");
                            return;
                        }
                    }
                }
                else
                {
                    DataObj.RealFileName = null;
                }
                
                if (string.IsNullOrEmpty(DataObj.ID))
                {
                    DataObj.ID = Guid.NewGuid().ToString();
                    DataObj.copyTo(ConnectionManager.Context.table("ExtFiles")).insert();
                }
                else
                {
                    DataObj.copyTo(ConnectionManager.Context.table("ExtFiles")).where("ID='" + DataObj.ID + "'").update();
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void txtImgFile_Click(object sender, EventArgs e)
        {
            if (txtImgFile.Tag != null && File.Exists(txtImgFile.Tag.ToString()))
            {
                try
                {
                    System.Diagnostics.Process.Start(txtImgFile.Tag.ToString());
                }
                catch (Exception ex) { }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (ofdUpload.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtImgFile.Text = Path.GetFileName(ofdUpload.FileName);
                txtImgFile.Tag = ofdUpload.FileName;
            }
        }

        private void rbNormalUnit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNormalUnit.Checked)
            {
                btnSelect.Enabled = true;   
            }
        }

        private void rbArmyUnit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArmyUnit.Checked)
            {
                btnSelect.Enabled = false;
                txtImgFile.Text = string.Empty;
                txtImgFile.Tag = null;
            }
        }
    }
}