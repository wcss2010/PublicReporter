using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PublicReporterLib.ControlAndForms
{
    public partial class AddressControl : UserControl
    {
        public JObject provinceList { get; private set; }

        public string provincedata { get; private set; }

        public ComboBox ProvinceControl { get { return Province; } }

        public ComboBox CityControl { get { return City; } }

        public ComboBox CountyControl { get { return County; } }

        public ComboBox TownControl { get { return Town; } }

        public AddressControl()
        {
            InitializeComponent();             
        }

        private void Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.City.SelectedItem = null;
            this.City.Visible = true;
            this.City.Items.Clear();

            ComboboxItem provincebox = this.Province.SelectedItem as ComboboxItem;

            string folder = @"" + provincebox.Value + ".js";

            var sourceContent = PublicReporterLib.Properties.Resource.ResourceManager.GetString("_" + folder).Trim();

            string[] sArray = sourceContent.Split(';');

            string citylist = null;

            for (int i = 0; i < sArray.Length; i++)
            {
                string pdata = sArray[i] as string;
                if (!string.IsNullOrEmpty(pdata))
                {
                    string[] data = pdata.Split('=');
                    var cityname = "city[" + '"' + provincebox.Value + '"' + "]";
                    if (cityname == data[0].Trim())
                    {
                        citylist = data[1].Trim();
                    }
                    else
                    {
                        provincedata = sourceContent;
                    }

                }
            }

            if (!string.IsNullOrEmpty(citylist))
            {
                List<AreaObject> v = JsonConvert.DeserializeObject<List<AreaObject>>(citylist);

                for (int i = 0; i < v.Count; i++)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Value = v[i].code;
                    item.Text = (string)v[i].name;
                    this.City.Items.Add(item);
                    //this.City.Text = (string)v[0].name;
                }
            }
            else
            {
                this.City.Visible = false;
            }
        }

        private void City_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.County.SelectedItem = null;
            this.County.Visible = true;
            this.County.Items.Clear();


            ComboboxItem citybox = this.City.SelectedItem as ComboboxItem;

            if (this.City.SelectedItem == null)
                return;

            string[] sArray = provincedata.Split(';');

            string countylist = null;

            for (int i = 0; i < sArray.Length; i++)
            {
                string pdata = sArray[i] as string;
                if (!string.IsNullOrEmpty(pdata))
                {
                    string[] data = pdata.Split('=');
                    var countyname = "county[" + '"' + citybox.Value + '"' + "]";
                    if (countyname == data[0].Trim())
                    {
                        countylist = data[1].Trim();
                    }
                }
            }

            if (!string.IsNullOrEmpty(countylist))
            {
                List<AreaObject> v = JsonConvert.DeserializeObject<List<AreaObject>>(countylist);

                for (int i = 0; i < v.Count; i++)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Value = v[i].code;
                    item.Text = (string)v[i].name;
                    this.County.Items.Add(item);
                    //this.County.Text = (string)v[0].name;
                }
            }
            else
            {
                this.County.Visible = false;
            }
        }

        private void County_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Town.SelectedItem = null;
            this.Town.Visible = true;
            this.Town.Items.Clear();
            
            ComboboxItem countybox = this.County.SelectedItem as ComboboxItem;

            if (this.County.SelectedItem == null)
                return;

            string[] sArray = provincedata.Split(';');

            string townlist = null;

            for (int i = 0; i < sArray.Length; i++)
            {
                string pdata = sArray[i] as string;
                if (!string.IsNullOrEmpty(pdata))
                {
                    string[] data = pdata.Split('=');
                    var townname = "area[" + '"' + countybox.Value + '"' + "]";
                    if (townname == data[0].Trim())
                    {
                        townlist = data[1].Trim();
                    }
                }
            }

            if (!string.IsNullOrEmpty(townlist) && townlist != "[]")
            {
                List<AreaObject> v = JsonConvert.DeserializeObject<List<AreaObject>>(townlist);

                for (int i = 0; i < v.Count; i++)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Value = v[i].code;
                    item.Text = (string)v[i].name;
                    this.Town.Items.Add(item);
                    //this.Town.Text = (string)v[0].name;
                }
            }
            else
            {
                this.Town.Visible = false;
            }
        }
        
        /// <summary>
        /// 载入省
        /// </summary>
        public void loadeProvince()
        {
            string folder = @"province.js";

            var sourceContent = PublicReporterLib.Properties.Resource.ResourceManager.GetString("_" + folder).Trim();

            this.provinceList = JObject.Parse(sourceContent);

            int i = 0;
            foreach (KeyValuePair<string, JToken> keyValuePair in this.provinceList)
            {
                ComboboxItem item = new ComboboxItem();
                item.Value = keyValuePair.Key;
                item.Text = (string)keyValuePair.Value;
                this.Province.Items.Add(item);
                if (i == 0)
                {
                    this.Province.Text = (string)keyValuePair.Value;
                }
                i++;
            }
        }

        /// <summary>
        /// 载入地区
        /// </summary>
        /// <param name="areaid"></param>
        public void LoadAreaCode(string areaid)
        {

            string provinceid = areaid.Substring(0, 2) + "0000";
            string cityid = areaid.Substring(0, 4) + "00";
            string countyid = areaid.Substring(0, 6);
            string townid = areaid;
            
            string folder1 = @"province.js";

            var sourceContent1 = PublicReporterLib.Properties.Resource.ResourceManager.GetString("_" + folder1).Trim();

            this.provinceList = JObject.Parse(sourceContent1);

            foreach (KeyValuePair<string, JToken> keyValuePair in this.provinceList)
            {

                ComboboxItem item = new ComboboxItem();
                item.Value = keyValuePair.Key;
                item.Text = (string)keyValuePair.Value;
                this.Province.Items.Add(item);
                if (provinceid == keyValuePair.Key)
                {
                    this.Province.Text = (string)keyValuePair.Value;
                }
            }

            string folder2 = @"" + provinceid + ".js";

            var sourceContent2 = PublicReporterLib.Properties.Resource.ResourceManager.GetString("_" + folder2).Trim();

            string[] sArray = sourceContent2.Split(';');

            string citylist = null;
            string countylist = null;
            string townlist = null;

            for (int i = 0; i < sArray.Length; i++)
            {
                string pdata = sArray[i] as string;
                if (!string.IsNullOrEmpty(pdata))
                {
                    string[] data = pdata.Split('=');

                    var city = provinceid;
                    var cityname = "city[" + '"' + city + '"' + "]";
                    if (cityname == data[0].Trim())
                    {
                        citylist = data[1].Trim();
                    }

                    string county = cityid;
                    var countyname = "county[" + '"' + county + '"' + "]";
                    if (countyname == data[0].Trim())
                    {
                        countylist = data[1].Trim();
                    }

                    string town = countyid;
                    var townname = "area[" + '"' + town + '"' + "]";
                    if (townname == data[0].Trim())
                    {
                        townlist = data[1].Trim();
                    }

                }
            }

            if (!string.IsNullOrEmpty(citylist))
            {
                List<AreaObject> v1 = JsonConvert.DeserializeObject<List<AreaObject>>(citylist);

                for (int i = 0; i < v1.Count; i++)
                {
                    ComboboxItem item1 = new ComboboxItem();
                    string checkcode1 = v1[i].code;

                    if (cityid == checkcode1)
                    {
                        item1.Value = v1[i].code;
                        item1.Text = (string)v1[i].name;
                        this.City.Items.Add(item1);
                        this.City.Text = (string)v1[i].name;
                    }
                }
            }

            if (!string.IsNullOrEmpty(countylist))
            {
                List<AreaObject> v2 = JsonConvert.DeserializeObject<List<AreaObject>>(countylist);

                for (int j = 0; j < v2.Count; j++)
                {
                    ComboboxItem item2 = new ComboboxItem();

                    string checkcode2 = v2[j].code;

                    if (countyid == checkcode2)
                    {
                        item2.Value = v2[j].code;
                        item2.Text = (string)v2[j].name;
                        this.County.Items.Add(item2);
                        this.County.Text = (string)v2[j].name;
                    }

                }
            }

            if (!string.IsNullOrEmpty(townlist))
            {
                List<AreaObject> v3 = JsonConvert.DeserializeObject<List<AreaObject>>(townlist);

                for (int k = 0; k < v3.Count; k++)
                {
                    ComboboxItem item3 = new ComboboxItem();

                    string checkcode3 = v3[k].code;

                    if (townid == checkcode3)
                    {
                        item3.Value = v3[k].code;
                        item3.Text = (string)v3[k].name;
                        this.Town.Items.Add(item3);
                        this.Town.Text = (string)v3[k].name;
                    }
                }
            }
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class AreaObject
    {
        public string code;
        public string name;
    }
}