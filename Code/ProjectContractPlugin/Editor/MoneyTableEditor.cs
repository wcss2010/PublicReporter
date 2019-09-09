using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProjectContractPlugin.DB;
using ProjectContractPlugin.DB.Entitys;

namespace ProjectContractPlugin.Editor
{
    public partial class MoneyTableEditor : BaseEditor
    {
        Dictionary<string, TextBox> boxDict = new Dictionary<string, TextBox>();

        public MoneyTableEditor()
        {
            InitializeComponent();

            //查找所有的TextBox
            GetAllTextBoxObject(this);
        }

        /// <summary>
        /// 遍历所有的TextBox
        /// </summary>
        /// <param name="parent"></param>
        private void GetAllTextBoxObject(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    boxDict[c.Name] = (TextBox)c;
                }
                else
                {
                    GetAllTextBoxObject(c);
                }
            }
        }

        private void ibEditMoney1_TextChanged(object sender, EventArgs e)
        {
            Calc();
        }

        private void Calc()
        {
            //设置间接费用
            boxDict["ibEditMoney12"].Text = boxDict["ibEditMoney13"].Text;

            //总费用
            decimal total = 0;

            //计算总费用
            for (int k = 2; k <= 12; k++)
            {
                string cnt = boxDict["ibEditMoney" + k].Text;
                try
                {
                    total += decimal.Parse(cnt);
                }
                catch (Exception ex) { }
            }

            boxDict["ibEditMoney1"].Text = total.ToString();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            List<YuSuanBiao> list = ConnectionManager.Context.table("YuSuanBiao").select("*").getList<YuSuanBiao>(new YuSuanBiao());
            foreach (YuSuanBiao ysb in list)
            {
                string ctrlName = "ibEdit" + ysb.MingCheng;
                if (boxDict.ContainsKey(ctrlName))
                {
                    boxDict[ctrlName].Text = ysb.ShuJu;
                }
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            ConnectionManager.Context.table("YuSuanBiao").delete();
            foreach (KeyValuePair<string, TextBox> kvp in boxDict)
            {
                YuSuanBiao ysb = new YuSuanBiao();
                ysb.BianHao = Guid.NewGuid().ToString();
                ysb.MingCheng = kvp.Key.Replace("ibEdit", string.Empty);
                ysb.ShuJu = kvp.Value.Text.Trim();
                ysb.copyTo(ConnectionManager.Context.table("YuSuanBiao")).insert();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveEvent();
        }
    }
}