using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicReporterLib.ControlAndForms;

namespace ProjectProtocolPlugin.Editor
{
    public partial class ProjectAddressEditor : AddressControl
    {
        public ProjectAddressEditor()
        {
            InitializeComponent();

            try
            {
                loadProvince();
            }
            catch (Exception ex) { }

            AreaLabel.AutoSize = false;
            AreaLabel.Width = 0;
            TownControl.Width = 0;
            CountyControl.Width = 0;
            
            ProvinceControl.Text = "北京";
            CityControl.Text = "北京";
            CountyControl.Text = "海淀区";
        }

        /// <summary>
        /// 拼装地址
        /// </summary>
        /// <returns></returns>
        public string getAddress()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ProvinceControl.SelectedItem != null ? ProvinceControl.SelectedItem.ToString() : "北京").Append("%|||%");
            sb.Append(CityControl.SelectedItem != null ? CityControl.SelectedItem.ToString() : "北京").Append("%|||%");
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
                string[] lines = address.Split(new string[] { "%|||%" }, StringSplitOptions.None);
                if (lines != null && lines.Length >= 3)
                {
                    ProvinceControl.Text = lines[0];
                    CityControl.Text = lines[1];
                    txtDetailAddress.Text = lines[2];
                }
            }
        }
    }
}