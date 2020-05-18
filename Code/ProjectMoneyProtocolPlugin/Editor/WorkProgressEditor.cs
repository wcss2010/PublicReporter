﻿using System;
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
    public partial class WorkProgressEditor : AbstractEditorPlugin.BaseEditor
    {
        List<JinDuBiao> list = new List<JinDuBiao>();
        public WorkProgressEditor()
        {
            InitializeComponent();
        }

        public override void refreshView()
        {
            base.refreshView();

            dgvDetail.Rows.Clear();
            list = ProjectMoneyProtocolPlugin.DB.ConnectionManager.Context.table("JinDuBiao").select("*").getList<JinDuBiao>(new JinDuBiao());
            list = list.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            int index = 0;
            foreach (JinDuBiao data in list)
            {
                index++;
                List<object> cells = new List<object>();
                cells.Add(index.ToString());
                cells.Add(data.ShiJian.ToString("yyyy年MM月dd日"));
                cells.Add(data.JieDuanMuBiao);
                cells.Add(data.JieDuanChengGuo);
                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = data;
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            //显示编辑窗体
            FrmAddOrUpdateWorkProgress form = new FrmAddOrUpdateWorkProgress(null, list.Count);
            if (form.ShowDialog() == DialogResult.OK)
                //刷新列表
                refreshView();
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
                        ConnectionManager.Context.table("JinDuBiao").where("BianHao='" + ((JinDuBiao)dgvRow.Tag).BianHao + "'").delete();
                    }

                    //刷新
                    refreshView();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double statusNum = 0;
            if (dgvDetail.SelectedRows.Count == 1)
            {
                try
                {
                    if (dgvDetail.SelectedRows[0].Index + 1 == dgvDetail.Rows.Count)
                    {
                        statusNum = ((JinDuBiao)dgvDetail.SelectedRows[0].Tag).ZhuangTai + 1;
                    }
                    else
                    {
                        double a = ((JinDuBiao)dgvDetail.SelectedRows[0].Tag).ZhuangTai;
                        double b = ((JinDuBiao)dgvDetail.Rows[dgvDetail.SelectedRows[0].Index + 1].Tag).ZhuangTai;

                        statusNum = (a + b) / 2;
                    }
                }
                catch (Exception ex) { }
            }

            //显示编辑窗体
            FrmAddOrUpdateWorkProgress form = new FrmAddOrUpdateWorkProgress(null, statusNum);
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
                    //编辑

                    //显示编辑窗体
                    FrmAddOrUpdateWorkProgress form = new FrmAddOrUpdateWorkProgress((JinDuBiao)dgvDetail.Rows[e.RowIndex].Tag);
                    form.ShowDialog();

                    //刷新列表
                    refreshView();
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    //删除
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //删除数据
                        ConnectionManager.Context.table("JinDuBiao").where("BianHao='" + ((JinDuBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao + "'").delete();

                        //刷新
                        refreshView();
                    }
                }
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                //编辑

                //显示编辑窗体
                FrmAddOrUpdateWorkProgress form = new FrmAddOrUpdateWorkProgress((JinDuBiao)dgvDetail.Rows[e.RowIndex].Tag);
                form.ShowDialog();

                //刷新列表
                refreshView();
            }
        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }
    }
}