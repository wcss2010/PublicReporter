using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PublicReporterLib;
using System.Diagnostics;
using Aspose.Words;
using ProjectContractPlugin.Controls;
using ProjectContractPlugin.DB;
using ProjectContractPlugin.DB.Entitys;

namespace ProjectContractPlugin.Editor
{
    /// <summary>
    /// 文档编辑控件
    /// </summary>
    public partial class TogetherRuleEditor : BaseEditor
    {
        private const string TRCode1Key = "TRCode1";
        private const string TRCode2Key = "TRCode2";
        private const string TRCode3Key = "TRCode3";
        private const string TRCode4Key = "TRCode4";

        /// <summary>
        /// 编辑器名称
        /// </summary>
        public override string EditorName
        {
            get
            {
                return base.EditorName;
            }
            set
            {
                base.EditorName = value;
            }
        }

        /// <summary>
        /// 编辑器说明文本
        /// </summary>
        public string InfoLabelText
        {
            get
            {
                return lblInfo.Text;
            }
            set
            {
                lblInfo.Text = value;
            }
        }

        /// <summary>
        /// 编辑器说明标签高度
        /// </summary>
        public int InfoLabelHeight
        {
            get
            {
                return lblInfo.Height;
            }
            set
            {
                lblInfo.Height = value;
            }
        }

        /// <summary>
        /// 自动适应说明标签高度
        /// </summary>
        public bool InfoLabelAutoHeight
        {
            get
            {
                return lblInfo.AutoHeight;
            }
            set
            {
                lblInfo.AutoHeight = value;
            }
        }

        public TogetherRuleEditor()
        {
            InitializeComponent();
        }

        public TogetherRuleEditor(string name, string info,string rtfFile)
            : this()
        {
            EditorName = name;
            InfoLabelText = info;
            RTFFile = rtfFile;

            updateTextControl();
        }

        private void updateTextControl()
        {
            if (File.Exists(RTFFile))
            {
                txtContent.LoadFile(RTFFile);

                txtContent.Text = txtContent.Text.Replace("{%Num1%}", ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TRCode1Key + "'").select("ShuJu").getValue<string>("0"));
                txtContent.Text = txtContent.Text.Replace("{%Num2%}", ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TRCode2Key + "'").select("ShuJu").getValue<string>("0"));
                txtContent.Text = txtContent.Text.Replace("{%Num3%}", ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TRCode3Key + "'").select("ShuJu").getValue<string>("0"));
                txtContent.Text = txtContent.Text.Replace("{%Num4%}", ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TRCode4Key + "'").select("ShuJu").getValue<string>("0"));
            }
        }

        public override bool IsInputCompleted()
        {
            return true;
        }

        public string RTFFile { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TRCode1Key + "'").delete();
                ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TRCode2Key + "'").delete();
                ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TRCode3Key + "'").delete();
                ConnectionManager.Context.table("ZiDianBiao").where("MingCheng='" + TRCode4Key + "'").delete();

                ZiDianBiao zd = new ZiDianBiao();
                zd.BianHao = Guid.NewGuid().ToString();
                zd.MingCheng = TRCode1Key;
                zd.ShuJu = ibEdit1.Value.ToString();
                zd.copyTo(ConnectionManager.Context.table("ZiDianBiao")).insert();

                zd = new ZiDianBiao();
                zd.BianHao = Guid.NewGuid().ToString();
                zd.MingCheng = TRCode2Key;
                zd.ShuJu = ibEdit2.Value.ToString();
                zd.copyTo(ConnectionManager.Context.table("ZiDianBiao")).insert();

                zd = new ZiDianBiao();
                zd.BianHao = Guid.NewGuid().ToString();
                zd.MingCheng = TRCode3Key;
                zd.ShuJu = ibEdit3.Value.ToString();
                zd.copyTo(ConnectionManager.Context.table("ZiDianBiao")).insert();

                zd = new ZiDianBiao();
                zd.BianHao = Guid.NewGuid().ToString();
                zd.MingCheng = TRCode4Key;
                zd.ShuJu = ibEdit4.Value.ToString();
                zd.copyTo(ConnectionManager.Context.table("ZiDianBiao")).insert();

                updateTextControl();
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
    }
}