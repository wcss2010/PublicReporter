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
    public partial class FrmAddOrUpdateTechnologyQuestion : PublicReporterLib.SuperForm
    {
        public FrmAddOrUpdateTechnologyQuestion(JiShuBiao obj, double count = -1)
        {
            InitializeComponent();

            DataObj = obj;
            Count = count;
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

        public double Count { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtContent.Text == string.Empty)
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }

            DataObj.NianDu = (int)txtYear.Value;
            DataObj.NeiRong = txtContent.Text;

            if (string.IsNullOrEmpty(DataObj.BianHao))
            {
                DataObj.BianHao = Guid.NewGuid().ToString();
                if (Count >= 0)
                    DataObj.ZhuangTai = Count;
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
