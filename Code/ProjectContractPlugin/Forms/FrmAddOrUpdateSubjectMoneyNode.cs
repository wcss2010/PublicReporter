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
    public partial class FrmAddOrUpdateSubjectMoneyNode : AbstractEditorPlugin.BaseForm
    {
        private List<BoFuBiao> MSList;
        private List<KeyValuePair<string, string>> dictMoneys = new List<KeyValuePair<string, string>>();

        public FrmAddOrUpdateSubjectMoneyNode(string subjectId)
        {
            InitializeComponent();

            MSList = ProjectContractPlugin.DB.ConnectionManager.Context.table("BoFuBiao").select("*").getList<BoFuBiao>(new BoFuBiao());
            MSList = MSList.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            int index = 0;
            foreach (BoFuBiao data in MSList)
            {
                index++;
                dictMoneys.Add(new KeyValuePair<string, string>(data.BianHao, "节点" + index + "(" + data.BoFuTiaoJian + ")"));
            }

            cbxSubjectList.DataSource = ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());
            cbxSubjectList.DisplayMember = "KeTiMingCheng";
            cbxSubjectList.ValueMember = "BianHao";

            cbxSubjectList.SelectedValue = subjectId;
            cbxSubjectList.Enabled = false;

            List<KeTiJieDianJingFeiBiao> list = ConnectionManager.Context.table("KeTiJieDianJingFeiBiao").where("KeTiBianHao = '" + subjectId + "'").select("*").getList<KeTiJieDianJingFeiBiao>(new KeTiJieDianJingFeiBiao());
            if (list != null)
            {
                foreach (KeyValuePair<string, string> kvpp in dictMoneys)
                {
                    KeTiJieDianJingFeiBiao destObj = null;

                    List<object> cells = new List<object>();
                    cells.Add(kvpp.Value);

                    foreach (KeTiJieDianJingFeiBiao obj in list)
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
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxSubjectList.SelectedValue == null)
            {
                MessageBox.Show("对不起，请完善内容！", "错误");
                return;
            }

            //删除当前课题的所有年度经费
            ConnectionManager.Context.table("KeTiJieDianJingFeiBiao").where("KeTiBianHao = '" + cbxSubjectList.SelectedValue + "'").delete();

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

                KeTiJieDianJingFeiBiao obj = new KeTiJieDianJingFeiBiao();
                obj.KeTiBianHao = cbxSubjectList.SelectedValue.ToString();
                obj.BoFuBianHao = nodeID;
                obj.JingFei = dgvRow.Cells[1].Value != null ? decimal.Parse(dgvRow.Cells[1].Value.ToString()) : 0;
                obj.ZhuangTai = 0;
                obj.ModifyTime = DateTime.Now;
                obj.copyTo(ConnectionManager.Context.table("KeTiJieDianJingFeiBiao")).insert();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}