﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProjectMoneyProtocolPlugin.DB;
using ProjectMoneyProtocolPlugin.DB.Entitys;
using AbstractEditorPlugin.Forms;
using System.IO;

namespace ProjectMoneyProtocolPlugin.Editor
{
    public partial class MoneyTableEditor : AbstractEditorPlugin.BaseEditor
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

        public override void refreshView()
        {
            base.refreshView();

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

        public override void onSaveEvent(ref bool result)
        {
            base.onSaveEvent(ref result);

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
                onSaveEvent(ref result);
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

        public override bool isInputCompleted()
        {
            return isComplete();
        }

        /// <summary>
        /// 是否允许完成输入
        /// </summary>
        /// <returns></returns>
        private bool isComplete()
        {
            string text = string.Empty;

            #region 读取数值
            //计算分年度经费
            decimal yearTotalMoneys = 0;
            try
            {
                yearTotalMoneys += decimal.Parse(ibEditYear1.Text);
                yearTotalMoneys += decimal.Parse(ibEditYear2.Text);
                yearTotalMoneys += decimal.Parse(ibEditYear3.Text);
                yearTotalMoneys += decimal.Parse(ibEditYear4.Text);
                yearTotalMoneys += decimal.Parse(ibEditYear5.Text);
            }
            catch (Exception ex) { }

            //读取直接经费
            decimal directMoneys = 0;
            try
            {
                directMoneys = decimal.Parse(ibEditMoney2.Text);
            }
            catch (Exception ex) { }

            //读取设备购置费
            decimal deviceBuyMoneys = 0;
            try
            {
                deviceBuyMoneys = decimal.Parse(ibEditMoney3_1.Text);
            }
            catch (Exception ex) { }

            //读取外部协作费
            decimal helpMoneys = 0;
            try
            {
                helpMoneys = decimal.Parse(ibEditMoney5.Text);
            }
            catch (Exception ex) { }

            //读取间接经费
            decimal elseMoneys = 0;
            try
            {
                elseMoneys = decimal.Parse(ibEditMoney13.Text);
            }
            catch (Exception ex) { }

            //读取总经费
            decimal totalMoneys = 0;
            try
            {
                totalMoneys = decimal.Parse(ibEditMoney1.Text);
            }
            catch (Exception ex) { }

            //读取项目总经费
            decimal projectTotalMoneys = ((JiBenXinXiBiao)((JiBenXinXiBiao)PluginRootObj.projectObj)).HeTongJiaKuan;
            #endregion

            if (projectTotalMoneys != yearTotalMoneys)
            {
                text = "请注意，分年度经费预算之和与项目总经费不等。\r\n";
            }
            if (yearTotalMoneys != totalMoneys)
            {
                text = "请注意，分年度经费预算之和与总经费不等。\r\n";
            }
            //if (elseMoneys > (directMoneys - deviceBuyMoneys - helpMoneys) * 0.2m)
            //{
            //    text += "请注意，间接经费不超过直接经费减去设备购置费和外协费的20%。\r\n";
            //}
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

        private void llReadme_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHelpBox helpBox = new FrmHelpBox(Path.Combine(PluginRootObj.RootDir, Path.Combine("Helper", "readonlyE.rtf")));
            helpBox.Text = "查看注意事项";
            helpBox.ShowDialog();
        }
    }
}