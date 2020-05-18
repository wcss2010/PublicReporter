using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectContractPlugin.DB.Entitys;

namespace ProjectContractPlugin.Editor
{
    public partial class MoneyTableControl : UserControl
    {
        Dictionary<string, TextBox> boxDict = new Dictionary<string, TextBox>();

        public MoneyTableControl()
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

        /// <summary>
        /// 统计总金额
        /// </summary>
        private void Calc()
        {
            //设置间接费用
            boxDict["ibEditMoney12"].Text = boxDict["ibEditMoney13"].Text;

            decimal secondMoney = 0;
            try
            {
                secondMoney = decimal.Parse(boxDict["ibEditMoney12"].Text);
            }
            catch (Exception ex) { }

            decimal money3_1 = 0;
            decimal money3_2 = 0;
            decimal money3_3 = 0;
            decimal money5_1 = 0;
            decimal money5_2 = 0;
            try
            {
                money3_1 = decimal.Parse(boxDict["ibEditMoney3_1"].Text);
            }
            catch (Exception ex) { }
            try
            {
                money3_2 = decimal.Parse(boxDict["ibEditMoney3_2"].Text);
            }
            catch (Exception ex) { }
            try
            {
                money3_3 = decimal.Parse(boxDict["ibEditMoney3_3"].Text);
            }
            catch (Exception ex) { }
            try
            {
                money5_1 = decimal.Parse(boxDict["ibEditMoney5_1"].Text);
            }
            catch (Exception ex) { }
            try
            {
                money5_2 = decimal.Parse(boxDict["ibEditMoney5_2"].Text);
            }
            catch (Exception ex) { }

            boxDict["ibEditMoney3"].Text = (money3_1 + money3_2 + money3_3).ToString();
            boxDict["ibEditMoney5"].Text = (money5_1 + money5_2).ToString();

            //总费用
            decimal total = 0;

            //计算总费用
            for (int k = 3; k <= 11; k++)
            {
                string cnt = boxDict["ibEditMoney" + k].Text;
                try
                {
                    total += decimal.Parse(cnt);
                }
                catch (Exception ex) { }
            }

            boxDict["ibEditMoney2"].Text = total.ToString();
            boxDict["ibEditMoney1"].Text = (total + secondMoney).ToString();
        }

        /// <summary>
        /// 载入经费数据
        /// </summary>
        /// <param name="moneys"></param>
        public void loadMoneys(List<KeTiYuSuanBiao> moneys)
        {
            foreach (KeTiYuSuanBiao ysb in moneys)
            {
                string ctrlName = "ibEdit" + ysb.MingCheng;
                if (boxDict.ContainsKey(ctrlName))
                {
                    boxDict[ctrlName].Text = ysb.ShuJu;
                }
            }
        }

        /// <summary>
        /// 获得经费数据
        /// </summary>
        /// <returns></returns>
        public List<KeTiYuSuanBiao> getMoneys()
        {
            List<KeTiYuSuanBiao> results = new List<KeTiYuSuanBiao>();

            foreach (KeyValuePair<string, TextBox> kvp in boxDict)
            {
                KeTiYuSuanBiao ysb = new KeTiYuSuanBiao();
                ysb.BianHao = Guid.NewGuid().ToString();
                ysb.MingCheng = kvp.Key.Replace("ibEdit", string.Empty);
                ysb.ShuJu = kvp.Value.Text.Trim();
                results.Add(ysb);
            }

            return results;
        }

        /// <summary>
        /// 获得当前控件中有多少文本框有输入
        /// </summary>
        /// <returns></returns>
        public int getInputCount()
        {
            List<KeTiYuSuanBiao> list = getMoneys();
            int inputCount = 0;
            foreach (KeTiYuSuanBiao biao in list)
            {
                if (string.IsNullOrEmpty(biao.ShuJu))
                {
                    continue;
                }
                else
                {
                    inputCount++;
                }
            }
            return inputCount;
        }
    }
}