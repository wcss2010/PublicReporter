using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProjectMilitaryTechnologPlanPlugin.DB.Entitys;
using ProjectMilitaryTechnologPlanPlugin.DB;
using ProjectMilitaryTechnologPlanPlugin.Forms;

namespace ProjectMilitaryTechnologPlanPlugin.Editor
{
    public partial class InfoEditor : BaseEditor
    {
        public InfoEditor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                bool result = true;
                OnSaveEvent(ref result);
                PublicReporterLib.PluginLoader.getLocalPluginRoot<ProjectMilitaryTechnologPlanPlugin.PluginRoot>().refreshEditors();
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

        public override void OnSaveEvent(ref bool result)
        {
            base.OnSaveEvent(ref result);

            if (ibEdit11.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入牵头人!");
                result = false;
                return;
            }
            if (ibEdit13.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入牵头人性别!");
                result = false;
                return;
            }
            if (ibEdit14.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入民族!");
                result = false;
                return;
            }
            if (ibEdit15.Value == null)
            {
                MessageBox.Show("对不起，请输入出生日期!");
                result = false;
                return;
            }
            if (ibEdit18.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入部职别!");
                result = false;
                return;
            }
            if (ibEdit19.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入联合研究单位!");
                result = false;
                return;
            }
            Single dd20;
            if (Single.TryParse(ibEdit20.Text, out dd20) == false)
            {
                MessageBox.Show("对不起，请输入审请经费!");
                result = false;
                return;
            }
            if (ibEdit21.Value == null)
            {
                MessageBox.Show("对不起，请输入计划完成时间!");
                result = false;
                return;
            }

            PluginRootObj.projectObj.QianTouRen = ibEdit11.Text;
            PluginRootObj.projectObj.QianTouRenXingBie = ibEdit13.Text;
            PluginRootObj.projectObj.QianTouRenMinZu = ibEdit14.Text;
            PluginRootObj.projectObj.QianTouRenShengRi = ibEdit15.Value;
            PluginRootObj.projectObj.BuZhiBie = ibEdit18.Text;
            PluginRootObj.projectObj.LianHeYanJiuDanWei = ibEdit19.Text;
            PluginRootObj.projectObj.ShenQingJingFei = decimal.Parse(ibEdit20.Text);
            PluginRootObj.projectObj.JiHuaWanChengShiJian = ibEdit21.Value;
            PluginRootObj.projectObj.copyTo(ConnectionManager.Context.table("JiBenXinXiBiao")).where("BianHao='" + PluginRootObj.projectObj.BianHao + "'").update();

            //保存核心人员信息
            ConnectionManager.Context.table("RenYuanBiao").delete();
            foreach (DataGridViewRow dgvRow in dgvWorkers.Rows)
            {
                if (dgvRow.Cells[0].Value == null || dgvRow.Cells[1].Value == null || dgvRow.Cells[2].Value == null || dgvRow.Cells[3].Value == null || dgvRow.Cells[4].Value == null || dgvRow.Cells[5].Value == null)
                {
                    continue;
                }

                RenYuanBiao worker = new RenYuanBiao();
                worker.BianHao = Guid.NewGuid().ToString();
                worker.XingMing = dgvRow.Cells[0].Value.ToString();
                worker.XingBie = dgvRow.Cells[1].Value.ToString();
                worker.ShengRi = DateTime.Parse(dgvRow.Cells[2].Value.ToString());
                worker.ZhuanYeZhiWu = dgvRow.Cells[3].Value.ToString();
                worker.YanJiuZhuanChang = dgvRow.Cells[4].Value.ToString();
                worker.GongZuoDanWei = dgvRow.Cells[5].Value.ToString();
                worker.copyTo(ConnectionManager.Context.table("RenYuanBiao")).insert();
            }
        }

        public override void RefreshView()
        {
            base.RefreshView();

            //加载数据
            if (PluginRootObj.projectObj != null)
            {
                ibEdit1.Text = PluginRootObj.projectObj.XiangMuMingCheng;
                ibEdit11.Text = PluginRootObj.projectObj.QianTouRen;
                ibEdit13.Text = PluginRootObj.projectObj.QianTouRenXingBie;
                ibEdit14.Text = PluginRootObj.projectObj.QianTouRenMinZu;
                try
                {
                    ibEdit15.Value = PluginRootObj.projectObj.QianTouRenShengRi;
                }
                catch (Exception ex) { }
                ibEdit18.Text = PluginRootObj.projectObj.BuZhiBie;
                ibEdit19.Text = PluginRootObj.projectObj.LianHeYanJiuDanWei;
                ibEdit20.Text = PluginRootObj.projectObj.ShenQingJingFei + "";
                try
                {
                    ibEdit21.Value = PluginRootObj.projectObj.JiHuaWanChengShiJian;
                }
                catch (Exception ex)
                {
                    ibEdit21.Value = DateTime.Now;
                }

                StringBuilder sb = new StringBuilder();
                if (PluginRootObj.projectObj.YuQiChengGuo != null && PluginRootObj.projectObj.YuQiChengGuo.Contains(UIControlConfig.rowFlag))
                {
                    string[] tttt = PluginRootObj.projectObj.YuQiChengGuo.Split(new string[] { UIControlConfig.rowFlag }, StringSplitOptions.None);
                    if (tttt != null)
                    {
                        foreach (string ss in tttt)
                        {
                            string[] vvvv = ss.Split(new string[] { UIControlConfig.cellFlag }, StringSplitOptions.None);
                            if (vvvv != null && vvvv.Length >= 2)
                            {
                                if (string.IsNullOrEmpty(vvvv[0])) { continue; }

                                sb.Append(vvvv[0].Insert(vvvv[0].IndexOf("("), vvvv[1]).Replace("(", string.Empty).Replace(")", string.Empty)).AppendLine();
                            }
                        }
                    }
                }
                txtWantResult.Text = sb.ToString();

                dgvWorkers.Rows.Clear();
                List<RenYuanBiao> workerList = ConnectionManager.Context.table("RenYuanBiao").select("*").getList<RenYuanBiao>(new RenYuanBiao());
                foreach (RenYuanBiao worker in workerList)
                {
                    List<object> cells = new List<object>();
                    cells.Add(worker.XingMing);
                    cells.Add(worker.XingBie);
                    cells.Add(worker.ShengRi != null ? worker.ShengRi.ToShortDateString() : DateTime.Now.ToShortDateString());
                    cells.Add(worker.ZhuanYeZhiWu);
                    cells.Add(worker.YanJiuZhuanChang);
                    cells.Add(worker.GongZuoDanWei);

                    int rowIndex = dgvWorkers.Rows.Add(cells.ToArray());
                    dgvWorkers.Rows[rowIndex].Tag = worker;
                }
            }
        }

        private void dgvWorkers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgvView = ((DataGridView)sender);
            for (int i = 0; i < e.RowCount; i++)
            {
                if (e.RowIndex == dgvView.Rows.Count - 1)
                {
                    continue;
                }

                dgvView.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
            }

            if (dgvView.Rows[e.RowCount - 1].Cells[2].Value == null)
            {
                dgvView.Rows[e.RowCount - 1].Cells[2].Value = "请选择！";
            }
        }

        private void dgvWorkers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).Rows.Count > e.RowIndex)
            {
                if (e.ColumnIndex == ((DataGridView)sender).Columns.Count - 1)
                {
                    if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            ((DataGridView)sender).Rows.RemoveAt(e.RowIndex);
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (e.ColumnIndex == 2)
                {
                    FrmDateTimePickerBox form = new FrmDateTimePickerBox();
                    try
                    {
                        form.Value = DateTime.Parse(dgvWorkers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    catch (Exception ex) { }

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        dgvWorkers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = form.Value.ToShortDateString();
                    }
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (flowLayoutPanel1 != null)
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    c.Width = flowLayoutPanel1.Width - 40;
                }
            }
        }

        public override bool IsInputCompleted()
        {
            return true;
        }
    }
}