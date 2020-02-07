using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicReporterLib.ControlAndForms;

namespace ProjectStrategicLeadershipPlugin.Controls
{
    public partial class ProjectAddressControl : AddressControl
    {
        public ProjectAddressControl()
        {
            InitializeComponent();

            try
            {
                loadProvince();
            }
            catch (Exception ex) { }

            AreaLabel.AutoSize = false;
            AreaLabel.Visible = false;
            AreaLabel.Width = 0;
            TownControl.Visible = false;
            TownControl.Width = 0;
            CountyControl.Visible = false;
            CountyControl.Width = 0;

            ProvinceControl.Text = "北京";
            CityControl.Text = "北京市";
            CountyControl.Text = "海淀区";
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void clear()
        {
            ProvinceControl.Text = "北京";
            CityControl.Text = "北京市";
            CountyControl.Text = "海淀区";
            txtDetailAddress.Text = "";
        }

        /// <summary>
        /// 是否允许编辑详细地址
        /// </summary>
        public bool EnabledEditAddressDetail
        {
            get
            {
                return txtDetailAddress.Visible;
            }
            set
            {
                txtDetailAddress.Visible = value;
            }
        }

        /// <summary>
        /// 拼装地址
        /// </summary>
        /// <returns></returns>
        public string getAddress()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ProvinceControl.SelectedItem != null ? ProvinceControl.SelectedItem.ToString() : "北京").Append(PublicReporterLib.JsonConfigObject.cellFlag);
            sb.Append(CityControl.SelectedItem != null ? CityControl.SelectedItem.ToString() : "北京").Append(PublicReporterLib.JsonConfigObject.cellFlag);
            sb.Append(txtDetailAddress.Text.Trim());
            return sb.ToString();
        }

        /// <summary>
        /// 设置地址
        /// </summary>
        /// <param name="address"></param>
        public void setAddress(string address)
        {
            if (address != null)
            {
                string[] lines = address.Split(new string[] { PublicReporterLib.JsonConfigObject.cellFlag }, StringSplitOptions.None);
                if (lines != null && lines.Length >= 3)
                {
                    ProvinceControl.Text = lines[0];
                    CityControl.Text = lines[1];
                    txtDetailAddress.Text = lines[2];
                }
            }
        }

        private new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
}