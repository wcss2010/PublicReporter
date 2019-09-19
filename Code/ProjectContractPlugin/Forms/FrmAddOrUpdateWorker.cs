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
    public partial class FrmAddOrUpdateWorker : PublicReporterLib.SuperForm
    {
        List<KeTiBiao> List = new List<KeTiBiao>();
        public FrmAddOrUpdateWorker(RenYuanBiao obj, List<KeTiBiao> list, double count = -1)
        {
            InitializeComponent();

            DataObj = obj;
            Count = count;
            List = list;

        }


        private void FrmAddOrUpdateWorker_Load(object sender, EventArgs e)
        {
            comboBox2.DisplayMember = "KeTiMingCheng";
            comboBox2.ValueMember = "BianHao";
            comboBox2.DataSource = List;

            if (DataObj != null)
            {
                textBox1.Text = DataObj.XingMing;
                textBox2.Text = DataObj.ZhiCheng;
                textBox4.Text = DataObj.ZhuanYe;
                textBox5.Text = DataObj.GongZuoDanWei;
                textBox6.Text = DataObj.ShenFenZhengHao;
                textBox7.Text = DataObj.RenWuFenGong;
                comboBox1.SelectedItem = DataObj.XingBie;
                comboBox2.SelectedValue = DataObj.KeTiBiaoHao;
                comboBox3.SelectedItem = DataObj.ZhiWu;
                numericUpDown1.Value = DataObj.MeiNianTouRuShiJian;

                if (DataObj.ShiXiangMuFuZeRen == rbIsOnlyProject.Name)
                {
                    rbIsOnlyProject.Checked = true;
                }
                else if (DataObj.ShiXiangMuFuZeRen == rbIsOnlySubject.Name)
                {
                    rbIsOnlySubject.Checked = true;
                }
                else if (DataObj.ShiXiangMuFuZeRen == rbIsProjectAndSubject.Name)
                {
                    rbIsProjectAndSubject.Checked = true;
                }
            }
            else
            {
                DataObj = new RenYuanBiao();
                DataObj.ShiXiangMuFuZeRen = "rbIsOnlySubject";
            }
        }

        public RenYuanBiao DataObj { get; set; }
        public double Count { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text)
                || String.IsNullOrEmpty(textBox2.Text)
                || String.IsNullOrEmpty(textBox4.Text)
                || String.IsNullOrEmpty(textBox5.Text)
                || String.IsNullOrEmpty(textBox6.Text)
                || String.IsNullOrEmpty(textBox7.Text)
                || (comboBox1.SelectedItem == null && rbIsOnlyProject.Checked == false)
                || (comboBox3.SelectedItem == null && rbIsOnlyProject.Checked == false)
                || String.IsNullOrEmpty(numericUpDown1.Value.ToString())

                )
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }
            else
            {

                DataObj.XingMing = textBox1.Text;
                DataObj.ZhiCheng = textBox2.Text;
                DataObj.ZhuanYe = textBox4.Text;
                DataObj.GongZuoDanWei = textBox5.Text;
                DataObj.ShenFenZhengHao = textBox6.Text;
                DataObj.RenWuFenGong = textBox7.Text;
                DataObj.XingBie = comboBox1.SelectedItem.ToString();
                DataObj.KeTiBiaoHao = comboBox2.SelectedValue.ToString();
                DataObj.ZhiWu = comboBox3.SelectedItem != null ? comboBox3.SelectedItem.ToString() : "负责人";
                DataObj.MeiNianTouRuShiJian = Convert.ToInt32(numericUpDown1.Value);

                if (string.IsNullOrEmpty(DataObj.BianHao))
                {
                    DataObj.BianHao = Guid.NewGuid().ToString();
                    if (Count >= 0)
                        DataObj.ZhuangTai = Count;
                    DataObj.copyTo(ConnectionManager.Context.table("RenYuanBiao")).insert();
                }
                else
                {
                    DataObj.copyTo(ConnectionManager.Context.table("RenYuanBiao")).where("BianHao='" + DataObj.BianHao + "'").update();
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void rbIsOnlySubjectMaster_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                DataObj.ShiXiangMuFuZeRen = ((RadioButton)sender).Name;

                if (((RadioButton)sender).Name == "rbIsOnlyProject")
                {
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                }
                else
                {
                    comboBox2.Enabled = true;
                    comboBox3.Enabled = true;
                }
            }
        }
    }
}