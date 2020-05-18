using ProjectMoneyProtocolPlugin.DB;
using ProjectMoneyProtocolPlugin.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectMoneyProtocolPlugin.Forms
{
    public partial class FrmAddOrUpdateUnitMoneyNode : AbstractEditorPlugin.BaseForm
    {
        private string lastUnit;
        private List<BoFuBiao> MSList;
        private List<KeyValuePair<string, string>> dictMoneys = new List<KeyValuePair<string, string>>();
        private double displayIndexBase;

        public FrmAddOrUpdateUnitMoneyNode(string unitName, double baseNum)
        {
            InitializeComponent();

            MSList = ProjectContractPlugin.DB.ConnectionManager.Context.table("BoFuBiao").select("*").getList<BoFuBiao>(new BoFuBiao());
            MSList = MSList.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            int index = 0;
            foreach (BoFuBiao data in MSList)
            {
                index++;
                //dictMoneys.Add(new KeyValuePair<string, string>(data.BianHao, "节点" + index + "(" + data.BoFuTiaoJian + ")"));
                dictMoneys.Add(new KeyValuePair<string, string>(data.BianHao, data.BoFuTiaoJian));
            }

            lastUnit = unitName;
            txtUnitName.Text = unitName;
            displayIndexBase = baseNum;

            List<DanWeiJieDianJingFeiBiao> list = ConnectionManager.Context.table("DanWeiJieDianJingFeiBiao").where("DanWeiMingCheng = '" + unitName + "'").select("*").getList<DanWeiJieDianJingFeiBiao>(new DanWeiJieDianJingFeiBiao());
            if (list != null)
            {
                foreach (KeyValuePair<string, string> kvpp in dictMoneys)
                {
                    DanWeiJieDianJingFeiBiao destObj = null;

                    List<object> cells = new List<object>();
                    cells.Add(kvpp.Value);

                    foreach (DanWeiJieDianJingFeiBiao obj in list)
                    {
                        if (kvpp.Key == obj.BoFuBianHao)
                        {
                            destObj = obj;
                            break;
                        }
                    }

                    if (destObj != null)
                    {
                        cells.Add(destObj.JingFei);
                    }
                    else
                    {
                        cells.Add("0");
                    }

                    int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                    dgvDetail.Rows[rowIndex].Tag = kvpp.Key;

                    if (destObj != null)
                    {
                        dgvDetail.Rows[rowIndex].Cells[0].Tag = destObj.ZhuangTai;
                    }
                    else
                    {
                        dgvDetail.Rows[rowIndex].Cells[0].Tag = (displayIndexBase + 0.1);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }

            //删除当前课题的所有年度经费
            ConnectionManager.Context.table("DanWeiJieDianJingFeiBiao").where("DanWeiMingCheng = '" + lastUnit + "'").delete();
            ConnectionManager.Context.table("DanWeiJieDianJingFeiBiao").where("DanWeiMingCheng = '" + txtUnitName.Text + "'").delete();

            //填写数据            
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                if (dgvRow.Cells[0].Value == null)
                {
                    continue;
                }
                if (dgvRow.Cells[1].Value == null)
                {
                    continue;
                }
                if (dgvRow.Tag == null)
                {
                    continue;
                }
                string nodeName = dgvRow.Cells[0].Value.ToString();
                string nodeID = dgvRow.Tag.ToString();
                decimal jingfei = 0;
                //if (int.TryParse(dgvRow.Cells[0].Value.ToString(), out niandu) == false)
                //{
                //    continue;
                //}
                if (decimal.TryParse(dgvRow.Cells[1].Value.ToString(), out jingfei) == false)
                {
                    continue;
                }

                DanWeiJieDianJingFeiBiao obj = new DanWeiJieDianJingFeiBiao();
                obj.DanWeiMingCheng = txtUnitName.Text;
                obj.BoFuBianHao = nodeID;
                obj.JingFei = dgvRow.Cells[1].Value != null ? decimal.Parse(dgvRow.Cells[1].Value.ToString()) : 0;

                double statusNum = 0;
                try
                {
                    statusNum = double.Parse(dgvRow.Cells[0].Tag.ToString());
                }
                catch (Exception ex) { }

                obj.ZhuangTai = statusNum;
                obj.ModifyTime = DateTime.Now;
                obj.copyTo(ConnectionManager.Context.table("DanWeiJieDianJingFeiBiao")).insert();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}