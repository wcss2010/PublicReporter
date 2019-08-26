﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TestReporterPlugin.Editor
{
    public partial class SubjectDetailEditor : BaseEditor
    {
        public string RTFFileFirstName { get; set; }

        public string TitleLabelText { get { return TitleLabelControl.Text; } set { TitleLabelControl.Text = value; } }

        public Label TitleLabelControl
        {
            get { return lblTitle; }
        }

        public TabControl DetailTabs
        {
            get { return knKetiDetailTabs; }
        }

        public SubjectDetailEditor()
        {
            InitializeComponent();

            RTFFileFirstName = "课题详细_";
        }

        public override void ClearView()
        {
            base.ClearView();

            txtInfo.Clear();
            //txtDest.Clear();
            //txtContent.Clear();
            //txtNeed.Clear();
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            txtInfo.SaveFile(GetInfoFilePath());
            //txtDest.SaveDoc(GetDestFilePath());
            //txtContent.SaveDoc(GetContentFilePath());
            //txtNeed.SaveDoc(GetNeedFilePath());
        }

        public string GetNeedFilePath()
        {
            return Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).filesDir, RTFFileFirstName + Name + "_研究思路" + ".doc");
        }

        public string GetContentFilePath()
        {
            return Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).filesDir, RTFFileFirstName + Name + "_研究内容" + ".doc");
        }

        public string GetDestFilePath()
        {
            return Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).filesDir, RTFFileFirstName + Name + "_研究目标" + ".doc");
        }

        public string GetInfoFilePath()
        {
            return Path.Combine(((PluginRoot)PublicReporterLib.PluginLoader.CurrentPlugin).filesDir, RTFFileFirstName + Name + "_简介" + ".txt");
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (File.Exists(GetInfoFilePath()))
            {
                txtInfo.LoadFile(GetInfoFilePath());
            }

            if (File.Exists(GetDestFilePath()))
            {
                //txtDest.LoadDoc(GetDestFilePath());
            }

            if (File.Exists(GetContentFilePath()))
            {
                //txtContent.LoadDoc(GetContentFilePath());
            }

            if (File.Exists(GetNeedFilePath()))
            {
                //txtNeed.LoadDoc(GetNeedFilePath());
            }
        }

        public override bool IsInputCompleted()
        {
            return File.Exists(GetInfoFilePath()) && File.Exists(GetDestFilePath()) && File.Exists(GetContentFilePath()) && File.Exists(GetNeedFilePath());
        }

        private void btnEditDest_Click(object sender, EventArgs e)
        {
            if (File.Exists(GetDestFilePath()))
            {
                System.Diagnostics.Process.Start(GetDestFilePath());
            }
            else
            {
                Aspose.Words.WordDocument wd = new Aspose.Words.WordDocument();
                wd.WordDoc.Save(GetDestFilePath());
                System.Diagnostics.Process.Start(GetDestFilePath());
            }
        }

        private void btnEditContent_Click(object sender, EventArgs e)
        {
            if (File.Exists(GetContentFilePath()))
            {
                System.Diagnostics.Process.Start(GetContentFilePath());
            }
            else
            {
                Aspose.Words.WordDocument wd = new Aspose.Words.WordDocument();
                wd.WordDoc.Save(GetContentFilePath());
                System.Diagnostics.Process.Start(GetContentFilePath());
            }
        }

        private void btnEditNeed_Click(object sender, EventArgs e)
        {
            if (File.Exists(GetNeedFilePath()))
            {
                System.Diagnostics.Process.Start(GetNeedFilePath());
            }
            else
            {
                Aspose.Words.WordDocument wd = new Aspose.Words.WordDocument();
                wd.WordDoc.Save(GetNeedFilePath());
                System.Diagnostics.Process.Start(GetNeedFilePath());
            }
        }
    }
}