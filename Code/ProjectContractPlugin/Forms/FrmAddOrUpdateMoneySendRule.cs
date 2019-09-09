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
    public partial class FrmAddOrUpdateMoneySendRule : Form
    {
        public FrmAddOrUpdateMoneySendRule(BoFuBiao obj,int count=-1)
        {
            InitializeComponent();

            DataObj = obj;
            Count = count;
            if (DataObj != null)
            {
                dateTimePicker1.Value = DataObj.YuJiShiJian;
                txtContent.Text = DataObj.BoFuTiaoJian;
                numericUpDown1.Value = DataObj.JingFeiJinQian;
            }
            else
            {
                DataObj = new BoFuBiao();
            }
        }

        public BoFuBiao DataObj { get; set; }
        public int  Count { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dateTimePicker1.Text)
                || String.IsNullOrEmpty(numericUpDown1.Text)
                ||String.IsNullOrEmpty(txtContent.Text))
            {
                MessageBox.Show("对不起，请完善内容！");
         
            }

            DataObj.YuJiShiJian = dateTimePicker1.Value;
            DataObj.BoFuTiaoJian = txtContent.Text;
            DataObj.JingFeiJinQian = numericUpDown1.Value;

            if (string.IsNullOrEmpty(DataObj.BianHao))
            {
                DataObj.BianHao = Guid.NewGuid().ToString();
                if (Count >= 0)
                    DataObj.ZhuangTai = Count.ToString("D3");
                DataObj.copyTo(ConnectionManager.Context.table("BoFuBiao")).insert();
            }
            else
            {
                DataObj.copyTo(ConnectionManager.Context.table("BoFuBiao")).where("BianHao='" + DataObj.BianHao + "'").update();
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
