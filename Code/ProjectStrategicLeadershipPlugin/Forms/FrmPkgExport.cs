﻿using SuperCodeFactoryUILib.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjectStrategicLeadershipPlugin.Forms
{
    public partial class FrmPkgExport : AbstractEditorPlugin.BaseForm
    {
        public FrmPkgExport()
        {
            InitializeComponent();

            llMainDocument.Text = "使用word打开'" + WordPrinter.outputDocFileName + "'";
            txtReadme.LoadFile(Path.Combine(PluginRootObj.RootDir, Path.Combine("Helper", "exportReadme.rtf")));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            btnCancel.Enabled = false;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "ZIP申报包|*.zip";
            sfd.FileName = ((PluginRoot)PluginRootObj).getNewExportZipName();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //检查前先关闭数据库
                PluginRootObj.closeDB();

                if (AbstractEditorPlugin.Utility.GlobalTool.isDirUsingWithAll(PluginRootObj.dataDir))
                {
                    //检查后打开数据库
                    PluginRootObj.openDB();

                    MessageBox.Show("对不起，导出失败，可能是您打开了某些文件或目录没有关闭！");
                    Close();
                }
                else
                {
                    //检查后打开数据库
                    PluginRootObj.openDB();

                    CircleProgressBarDialog dialoga = new CircleProgressBarDialog();
                    dialoga.TransparencyKey = dialoga.BackColor;
                    dialoga.ProgressBar.ForeColor = Color.Red;
                    dialoga.MessageLabel.ForeColor = Color.Blue;
                    dialoga.FormBorderStyle = FormBorderStyle.None;
                    dialoga.Start(new EventHandler<CircleProgressBarEventArgs>(delegate(object thisObject, CircleProgressBarEventArgs argss)
                    {
                        CircleProgressBarDialog senderForm = (CircleProgressBarDialog)thisObject;

                        try
                        {
                            AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 40, "准备导出...", 600);

                            //检查目标文件是否存在，如果存在先删除
                            if (File.Exists(sfd.FileName))
                            {
                                File.Delete(sfd.FileName);
                            }

                            AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 65, "正在导出...", 600);

                            //导出数据包
                            PluginRootObj.exportTo(sfd.FileName);

                            AbstractEditorPlugin.AbstractPluginRoot.report(senderForm, 98, "导出完毕.", 600);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("对不起，请检查您是否打开了某个word文件或目录没有关闭，然后重试！");
                            Close();
                        }
                        finally
                        {
                            if (IsHandleCreated)
                            {
                                Invoke(new MethodInvoker(delegate()
                                    {
                                        try
                                        {
                                            Close();
                                        }
                                        catch (Exception ex) { }
                                    }));
                            }
                        }
                    }));
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void llMainDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string docFile = Path.Combine(PluginRootObj.dataDir, WordPrinter.outputDocFileName);
            if (File.Exists(docFile))
            {
                try
                {
                    Process.Start(docFile);
                }
                catch (Exception ex) { }
            }
        }
    }
}