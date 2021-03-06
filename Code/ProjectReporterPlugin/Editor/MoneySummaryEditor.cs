﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ProjectReporterPlugin.Editor
{
    public partial class MoneySummaryEditor : BaseEditor
    {
        public string FilePath { get; set; }

        /// <summary>
        /// 经费概算附件标识
        /// </summary>
        public static string FileKeyName = "--经费概算附件";

        public MoneySummaryEditor()
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
        
        public override void ClearView()
        {
            base.ClearView();

            lbcomattpath.Text = string.Empty;
            FilePath = string.Empty;
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (Directory.Exists(PublicReporterLib.PluginLoader.getLocalPluginRoot<ProjectReporterPlugin.PluginRoot>().filesDir))
            {
                string[] files = Directory.GetFiles(PublicReporterLib.PluginLoader.getLocalPluginRoot<ProjectReporterPlugin.PluginRoot>().filesDir);
                if (files != null)
                {
                    foreach (string f in files)
                    {
                        FileInfo fi = new FileInfo(f);
                        if (fi.Name.StartsWith(FileKeyName))
                        {
                            FilePath = f;
                            lbcomattpath.Text = fi.Name.Replace(FileKeyName + "_", string.Empty);
                            break;
                        }
                    }
                }
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            try
            {
                if (File.Exists(ofdUpload.FileName))
                {
                    if (File.Exists(FilePath))
                    {
                        File.Delete(FilePath);
                    }

                    File.Copy(ofdUpload.FileName, Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<ProjectReporterPlugin.PluginRoot>().filesDir, FileKeyName + "_" + new FileInfo(ofdUpload.FileName).Name));
                    RefreshView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败!Ex:" + ex.ToString());
            }
        }

        private void btnComsel_Click(object sender, EventArgs e)
        {
            if (ofdUpload.ShowDialog() == DialogResult.OK)
            {
                lbcomattpath.Text = new FileInfo(ofdUpload.FileName).Name;
            }
        }

        public override bool IsInputCompleted()
        {
            return File.Exists(FilePath);
        }

        private void lklDownloadFuJian_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string sourcePath = Path.Combine(PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().RootDir, Path.Combine("Helper", "JingFeiFuJian.doc"));
            string destPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "项目经费概算说明.doc");
            File.Copy(sourcePath, destPath, true);
            MessageBox.Show("已下载到桌面！");
            Process.Start(destPath);
        }

        private void lbcomattpath_LinkClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                return;
            }
            else
            {
                Process.Start(FilePath);
            }
        }
    }
}