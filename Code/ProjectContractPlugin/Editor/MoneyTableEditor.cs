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

        public override bool IsInputCompleted()
        {
            return isComplete();
        }

        /// <summary>
        /// 是否允许完成输入
        /// </summary>
        /// <returns></returns>
        private bool isComplete()
        {
            decimal d = 0m;
            decimal d2 = 0m;
            decimal num = 0m;
            decimal.TryParse(this.ibEditMoney1.Text, out d);
            decimal.TryParse(this.ibEditYear1.Text, out d2);
            num += d2;
            decimal.TryParse(this.ibEditYear2.Text, out d2);
            num += d2;
            decimal.TryParse(this.ibEditYear3.Text, out d2);
            num += d2;
            decimal.TryParse(this.ibEditYear4.Text, out d2);
            num += d2;
            decimal.TryParse(this.ibEditYear5.Text, out d2);
            num += d2;
            string text = "";
            if (d != num)
            {
                text = "请注意，分年度经费预算之和与项目总经费不等，正确无误后方能保存。\r\n";
            }
            //else if (d > 500m)
            //{
            //    text += "请注意，经费总额超过500万,需要重新制定，正确无误后方能保存。\r\n";
            //}
            decimal d3 = 0m;
            decimal d4 = 0m;            
            decimal d6 = 0m;
            decimal.TryParse(this.ibEditMoney12.Text, out d3);
            decimal.TryParse(this.ibEditMoney2.Text, out d4);            
            decimal.TryParse(this.ibEditMoney5.Text, out d6);
            if (d3 > (d4 - d6) * 0.2m)
            {
                text += "请注意，间接经费不超过直接经费减去设备购置费和外协费的20%，正确无误后方能保存。\r\n";
            }
            if (text != string.Empty)
            {
                MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}