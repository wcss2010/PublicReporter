using ProjectContractPlugin.DB;
using ProjectContractPlugin.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectContractPlugin.Forms
{
    public partial class FrmAddOrUpdateWorkProgress : PublicReporterLib.SuperForm
    {
        public FrmAddOrUpdateWorkProgress(JinDuBiao obj, double count = -1)
        {
            InitializeComponent();

            DataObj = obj;
            Count = count;
            if (DataObj != null)
            {
                dateTimePicker1.Value = DataObj.ShiJian;
                txtContent.Text = DataObj.JieDuanMuBiao;
                textBox3.Text = DataObj.JieDuanChengGuo;
            }
            else
            {
                DataObj = new JinDuBiao();
            }
        }

        public JinDuBiao DataObj { get; set; }
        public double Count { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dateTimePicker1.Text)
                || String.IsNullOrEmpty(textBox3.Text)
                ||String.IsNullOrEmpty(txtContent.Text))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }

            DataObj.ShiJian = dateTimePicker1.Value;
            DataObj.JieDuanMuBiao = txtContent.Text;
            DataObj.JieDuanChengGuo = textBox3.Text;

            if (string.IsNullOrEmpty(DataObj.BianHao))
            {
                DataObj.BianHao = Guid.NewGuid().ToString();
                if (Count >= 0)
                    DataObj.ZhuangTai = Count;
                DataObj.copyTo(ConnectionManager.Context.table("JinDuBiao")).insert();
            }
            else
            {
                DataObj.copyTo(ConnectionManager.Context.table("JinDuBiao")).where("BianHao='" + DataObj.BianHao + "'").update();
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
