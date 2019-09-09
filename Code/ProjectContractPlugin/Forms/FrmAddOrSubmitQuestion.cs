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
    public partial class FrmAddOrSubmitQuestion : Form
    {
        public FrmAddOrSubmitQuestion(TiJiaoYaoQiuBiao obj,int count=-1)
        {
            InitializeComponent();

            DataObj = obj;
            Count = count;
            if (DataObj != null)
            {
                textBox1.Text = DataObj.MingCheng;
                txtContent.Text = DataObj.YaoQiu;
            }
            else
            {
                DataObj = new TiJiaoYaoQiuBiao();
            }
        }

        public TiJiaoYaoQiuBiao DataObj { get; set; }
        public int  Count { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text)
                ||String.IsNullOrEmpty(txtContent.Text))
            {
                MessageBox.Show("对不起，请完善内容！");
  
            }

            DataObj.MingCheng = textBox1.Text;
            DataObj.YaoQiu = txtContent.Text;

            if (string.IsNullOrEmpty(DataObj.BianHao))
            {
                DataObj.BianHao = Guid.NewGuid().ToString();
                if (Count >= 0)
                    DataObj.ZhuangTai = Count.ToString("D3");
                DataObj.copyTo(ConnectionManager.Context.table("TiJiaoYaoQiuBiao")).insert();
            }
            else
            {
                DataObj.copyTo(ConnectionManager.Context.table("TiJiaoYaoQiuBiao")).where("BianHao='" + DataObj.BianHao + "'").update();
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
