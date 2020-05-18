using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectMoneyProtocolPlugin.DB.Entitys;
using ProjectMoneyProtocolPlugin.Forms;
using ProjectMoneyProtocolPlugin.DB;
using PublicReporterLib;
using System.IO;

namespace ProjectMoneyProtocolPlugin.Editor
{
    public partial class WorkerEditor : AbstractEditorPlugin.BaseEditor
    {
        List<RenYuanBiao> personList = new List<RenYuanBiao>();
        List<KeTiBiao> ktList = new List<KeTiBiao>();
        public WorkerEditor()
        {
            InitializeComponent();
        }

        public override void refreshView()
        {
            base.refreshView();

            //查询课题列表
            ktList = ProjectMoneyProtocolPlugin.DB.ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());
            ktList = ktList.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            
            //生成课题X字典
            int kindex = 0;
            Dictionary<string, string> ktDict = new Dictionary<string, string>();
            foreach (KeTiBiao ktb in ktList)
            {
                kindex++;
                ktDict[ktb.BianHao] = "课题" + kindex;
            }

            //查询人员列表
            personList = ProjectMoneyProtocolPlugin.DB.ConnectionManager.Context.table("RenYuanBiao").select("*").getList<RenYuanBiao>(new RenYuanBiao());
            //list = list.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            personList = personList.OrderBy(t => t.ZhuangTai).ToList();

            dgvDetail.Rows.Clear();
            int index = 0;
            foreach (RenYuanBiao data in personList)
            {
                index++;
                List<object> cells = new List<object>();
                cells.Add(index.ToString());
                cells.Add(data.XingMing);
                cells.Add(data.XingBie);
                cells.Add(data.ZhiCheng);
                cells.Add(data.ZhuanYe);
                cells.Add(data.GongZuoDanWei);
                cells.Add(data.MeiNianTouRuShiJian);
                cells.Add(data.RenWuFenGong);
                cells.Add(data.ShenFenZhengHao);

                if (data.ShiXiangMuFuZeRen == "rbIsOnlyProject")
                {
                    cells.Add("项目负责人");
                }
                else
                {
                    cells.Add((data.ShiXiangMuFuZeRen == "rbIsProjectAndSubject" ? "项目负责人兼" : "") + ((ktDict.ContainsKey(data.KeTiBiaoHao) ? ktDict[data.KeTiBiaoHao] : string.Empty) + data.ZhiWu));
                }

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = data;
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //显示编辑窗体
            FrmAddOrUpdateWorker form = new FrmAddOrUpdateWorker(null, ktList, getMaxDisplayOrder());
            if (form.ShowDialog() == DialogResult.OK)
            {
                //刷新列表
                refreshView();
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    #region 编辑
                    FrmAddOrUpdateWorker form = new FrmAddOrUpdateWorker((RenYuanBiao)dgvDetail.Rows[e.RowIndex].Tag, ktList);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //刷新列表
                        refreshView();
                    }
                    #endregion
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    #region 删除
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //删除数据
                        ConnectionManager.Context.table("RenYuanBiao").where("BianHao='" + ((RenYuanBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao + "'").delete();

                        //刷新
                        refreshView();
                    }
                    #endregion
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 3)
                {
                    RenYuanBiao personObj = (RenYuanBiao)dgvDetail.Rows[e.RowIndex].Tag;

                    #region 编辑序号
                    FrmEditOrder feo = new FrmEditOrder();
                    try
                    {
                        feo.OrderNum = (decimal)personObj.ZhuangTai;
                    }
                    catch (Exception ex) { }
                    if (feo.ShowDialog() == DialogResult.OK)
                    {
                        //对后面的记录重新排序
                        reorderPersonList(personObj, (int)feo.OrderNum);

                        //刷新列表
                        PluginRootObj.refreshEditors();
                    }
                    #endregion
                }
            }
        }

        private void reorderPersonList(RenYuanBiao pObj, int newPersonIndex)
        {
            if (pObj.ZhuangTai != newPersonIndex)
            {
                int pIndex = newPersonIndex - 1;

                if (pIndex >= personList.Count - 1)
                {
                    personList.Remove(pObj);
                    personList.Add(pObj);
                }
                else if (pIndex <= 0)
                {
                    personList.Remove(pObj);
                    personList.Insert(0, pObj);
                }
                else
                {
                    personList.Remove(pObj);
                    personList.Insert(pIndex, pObj);
                }

                int rindexx = 0;
                foreach (RenYuanBiao pp in personList)
                {
                    rindexx++;
                    pp.ZhuangTai = rindexx;
                    pp.copyTo(ConnectionManager.Context.table("RenYuanBiao")).where("BianHao='" + pp.BianHao + "'").update();
                }
            }
        }

        /// <summary>
        /// 将指定项目插入到当前选项下方
        /// </summary>
        /// <param name="task"></param>
        public void moveToCurrentDown(RenYuanBiao task)
        {
            if (dgvDetail.SelectedRows.Count == 1)
            {
                if (personList != null)
                {
                    int taskIndex = dgvDetail.SelectedRows[0].Index;
                    if (taskIndex <= personList.Count - 2)
                    {
                        personList.Insert(taskIndex + 1, task);

                        int ri = 0;
                        foreach (RenYuanBiao t in personList)
                        {
                            t.ZhuangTai = ri;
                            ri++;

                            t.copyTo(ConnectionManager.Context.table("RenYuanBiao")).where("BianHao='" + t.BianHao + "'").update();
                        }

                        refreshView();

                        dgvDetail.ClearSelection();

                        if (taskIndex < dgvDetail.Rows.Count - 1)
                        {
                            dgvDetail.Rows[taskIndex + 1].Selected = true;
                        }
                        else
                        {
                            dgvDetail.Rows[dgvDetail.Rows.Count - 1].Selected = true;
                        }
                    }
                }
            }
        }

        public static int getMaxDisplayOrder()
        {
            try
            {
                return (int)ConnectionManager.Context.table("RenYuanBiao").select("max(ZhuangTai)").getValue<double>(0d);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                //编辑

                //显示编辑窗体
                FrmAddOrUpdateWorker form = new FrmAddOrUpdateWorker((RenYuanBiao)dgvDetail.Rows[e.RowIndex].Tag, ktList);
                if (form.ShowDialog() == DialogResult.OK)
                    //刷新列表
                    refreshView();
            }

        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count == 1)
            {
                //double statusNum = 0;
                //try
                //{
                //    if (dgvDetail.SelectedRows[0].Index + 1 == dgvDetail.Rows.Count)
                //    {
                //        statusNum = ((RenYuanBiao)dgvDetail.SelectedRows[0].Tag).ZhuangTai + 1;
                //    }
                //    else
                //    {
                //        double a = ((RenYuanBiao)dgvDetail.SelectedRows[0].Tag).ZhuangTai;
                //        double b = ((RenYuanBiao)dgvDetail.Rows[dgvDetail.SelectedRows[0].Index + 1].Tag).ZhuangTai;

                //        statusNum = (a + b) / 2;
                //    }
                //}
                //catch (Exception ex) { }

                //显示编辑窗体
                FrmAddOrUpdateWorker form = new FrmAddOrUpdateWorker(null, ktList,getMaxDisplayOrder());
                if (form.ShowDialog() == DialogResult.OK)
                {
                    moveToCurrentDown(form.DataObj);
                    //刷新列表
                    refreshView();
                }

            }
            else
            {
                MessageBox.Show("请选中需要一条数据，新数据将在其后插入");
                return;
            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count >= 1)
            {
                if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //删除数据
                    foreach (DataGridViewRow dgvRow in dgvDetail.SelectedRows)
                    {
                        ConnectionManager.Context.table("RenYuanBiao").where("BianHao='" + ((RenYuanBiao)dgvRow.Tag).BianHao + "'").delete();
                    }

                    //刷新
                    refreshView();
                }
            }
        }

        private void btnImporter_Click(object sender, EventArgs e)
        {
            FrmWorkerImporter fei = new FrmWorkerImporter();
            if (fei.ShowDialog() == DialogResult.OK)
            {
                refreshView();
            }
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectMoneyProtocolPlugin.Resource.Question_162;
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 2, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectMoneyProtocolPlugin.Resource.DELETE_28;
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 3, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectMoneyProtocolPlugin.Resource.orderEdit;
        }
    }
}