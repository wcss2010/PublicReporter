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
    public partial class FrmAddOrUpdateTechnologyQuestion : Form
    {
        public FrmAddOrUpdateTechnologyQuestion(JiShuBiao obj)
        {
            InitializeComponent();

            DataObj = obj;
            if (DataObj != null)
            {
                txtYear.Value = DataObj.NianDu;
                txtContent.Text = DataObj.NeiRong;
            }
            else
            {
                DataObj = new JiShuBiao();
            }
        }

        public JiShuBiao DataObj { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtContent.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入内容！");
                return;
            }

            DataObj.NianDu = (int)txtYear.Value;
            DataObj.NeiRong = txtContent.Text;

            if (string.IsNullOrEmpty(DataObj.BianHao))
            {
                DataObj.BianHao = Guid.NewGuid().ToString();
                DataObj.copyTo(ConnectionManager.Context.table("JiShuBiao")).insert();
            }
            else
            {
                DataObj.copyTo(ConnectionManager.Context.table("JiShuBiao")).where("BianHao='" + DataObj.BianHao + "'").update();
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
