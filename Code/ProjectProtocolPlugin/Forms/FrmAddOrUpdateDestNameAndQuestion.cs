using ProjectProtocolPlugin.DB;
using ProjectProtocolPlugin.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectProtocolPlugin.Forms
{
    public partial class FrmAddOrUpdateDestNameAndQuestion : PublicReporterLib.SuperForm
    {
        public FrmAddOrUpdateDestNameAndQuestion(ZhiBiaoBiao obj, double count = -1)
        {
            InitializeComponent();

            DataObj = obj;
            Count = count;
            if (DataObj != null)
            {
                textBox1.Text = DataObj.ZhiBiaoMingCheng;
                txtContent.Text = DataObj.ZhiBiaoYaoQiu;
                //textBox2.Text = DataObj.KaoHeFangShi;
               
            }
            else
            {
                DataObj = new ZhiBiaoBiao();
            }
        }

        public ZhiBiaoBiao DataObj { get; set; }
        public double Count { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text)
                //|| String.IsNullOrEmpty(textBox2.Text)
                ||String.IsNullOrEmpty(txtContent.Text))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }

            DataObj.ZhiBiaoMingCheng = textBox1.Text;
            DataObj.ZhiBiaoYaoQiu = txtContent.Text;
            DataObj.KaoHeFangShi = textBox2.Text;

            if (string.IsNullOrEmpty(DataObj.BianHao))
            {
                DataObj.BianHao = Guid.NewGuid().ToString();
                if (Count >= 0)
                    DataObj.ZhuangTai = Count;
                DataObj.copyTo(ConnectionManager.Context.table("ZhiBiaoBiao")).insert();
            }
            else
            {
                DataObj.copyTo(ConnectionManager.Context.table("ZhiBiaoBiao")).where("BianHao='" + DataObj.BianHao + "'").update();
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}