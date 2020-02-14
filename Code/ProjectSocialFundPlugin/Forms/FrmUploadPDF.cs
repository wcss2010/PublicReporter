using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectSocialFundPlugin.Forms
{
    public partial class FrmUploadPDF : AbstractEditorPlugin.BaseForm
    {
        private string constPdf;
        public FrmUploadPDF()
        {
            InitializeComponent();

            constPdf = Path.Combine(PluginRootObj.dataDir, "申请书.pdf");
            if (File.Exists(constPdf))
            {
                txtImgFile.Text = Path.GetFileName(constPdf);
                txtImgFile.Tag = constPdf;
            }
        }

        private void txtImgFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtImgFile.Tag != null)
            {
                if (File.Exists(txtImgFile.Tag.ToString()))
                {
                    try
                    {
                        Process.Start(txtImgFile.Tag.ToString());
                    }
                    catch (Exception ex) { }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtImgFile.Tag == "" || txtImgFile.Tag == null)
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }
            else
            {
                //检查是否需要传文件
                if (txtImgFile.Tag != null)
                {
                    if (txtImgFile.Tag.ToString().StartsWith(PluginRootObj.dataDir))
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
                                //上传
                                File.Copy(txtImgFile.Tag.ToString(), constPdf);
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
                DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void llTemplete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sourcePath = Path.Combine(PluginRootObj.RootDir, Path.Combine("Helper", "template.doc"));

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.doc|*.doc";
            sfd.FileName = "文档模板.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(sourcePath, sfd.FileName, true);
                    Process.Start(sfd.FileName);

                    MessageBox.Show("下载完成！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("下载失败！Ex:" + ex.ToString());
                }
            }
        }
    }
}