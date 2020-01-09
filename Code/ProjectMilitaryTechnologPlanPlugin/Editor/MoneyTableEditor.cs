using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProjectMilitaryTechnologPlanPlugin.DB;
using ProjectMilitaryTechnologPlanPlugin.DB.Entitys;

namespace ProjectMilitaryTechnologPlanPlugin.Editor
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
            //总费用
            decimal total = 0;

            //计算总费用
            for (int k = 1; k <= 11; k++)
            {
                string cnt = boxDict["ibEditMoney" + k].Text;
                try
                {
                    total += decimal.Parse(cnt);
                }
                catch (Exception ex) { }
            }

            txtTotal.Text = total + "";
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

        public override void OnSaveEvent(ref bool result)
        {
            base.OnSaveEvent(ref result);

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
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                if (!this.isComplete())
                {
                    return;
                }

                bool result = true;
                OnSaveEvent(ref result);

                //更新保存日期
                PluginRootObj.updateSaveDate();
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
            decimal total = 0m;
            decimal d2 = 0m;
            decimal num = 0m;
            decimal.TryParse(this.txtTotal.Text, out total);
            decimal.TryParse(this.ibEditYear1.Text, out d2);
            num += d2;
            decimal.TryParse(this.ibEditYear2.Text, out d2);
            num += d2;
            decimal.TryParse(this.ibEditYear3.Text, out d2);
            num += d2;
            
            string text = "";
            if (total != num)
            {
                text = "请注意，分年度经费预算之和与合计经费不等，正确无误后方能保存。\r\n";
            }
            if (total != PluginRootObj.projectObj.JingFeiYuSuan)
            {
                text = "请注意，分年度经费预算之和与概述的经费概算不等，正确无误后方能保存。\r\n";
            }

            //总费用
            decimal totalDirect = 0;
            decimal totalNotDirect = 0;

            //计算总费用
            for (int k = 1; k <= 9; k++)
            {
                if (k == 1)
                {
                    continue;
                }

                string cnt = boxDict["ibEditMoney" + k].Text;
                try
                {
                    totalDirect += decimal.Parse(cnt);
                }
                catch (Exception ex) { }
            }
            for (int k = 10; k <= 11; k++)
            {
                string cnt = boxDict["ibEditMoney" + k].Text;
                try
                {
                    totalNotDirect += decimal.Parse(cnt);
                }
                catch (Exception ex) { }
            }

            if (totalNotDirect > totalDirect * 0.2m)
            {
                text += "请注意，间接经费不超过直接经费减去设备费的20%，正确无误后方能保存。\r\n";
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