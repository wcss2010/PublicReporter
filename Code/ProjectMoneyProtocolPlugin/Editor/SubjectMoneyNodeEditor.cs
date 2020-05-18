﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectMoneyProtocolPlugin.DB;
using ProjectMoneyProtocolPlugin.DB.Entitys;
using ProjectMoneyProtocolPlugin.Forms;
using PublicReporterLib;

namespace ProjectMoneyProtocolPlugin.Editor
{
    public partial class SubjectMoneyNodeEditor : AbstractEditorPlugin.BaseEditor
    {
        CustomDictionary<string, string> dictMoneys = new CustomDictionary<string, string>();
        private List<BoFuBiao> MSList;
        public SubjectMoneyNodeEditor()
        {
            InitializeComponent();
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    //编辑

                    //显示编辑窗体
                    FrmAddOrUpdateSubjectMoneyNode form = new FrmAddOrUpdateSubjectMoneyNode(((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao);
                    if (form.ShowDialog() == DialogResult.OK)
                        //刷新列表
                        refreshView();
                }
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                //编辑

                //显示编辑窗体
                FrmAddOrUpdateSubjectMoneyNode form = new FrmAddOrUpdateSubjectMoneyNode(((KeTiBiao)dgvDetail.Rows[e.RowIndex].Tag).BianHao);
                form.ShowDialog();

                //刷新列表
                refreshView();
            }
        }

        public override void refreshView()
        {
            base.refreshView();

            dictMoneys = new CustomDictionary<string, string>();
            MSList = ProjectMoneyProtocolPlugin.DB.ConnectionManager.Context.table("BoFuBiao").select("*").getList<BoFuBiao>(new BoFuBiao());
            MSList = MSList.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();
            int index = 0;
            foreach (BoFuBiao data in MSList)
            {
                index++;
                //dictMoneys[data.BianHao] = "节点" + index + "(" + data.BoFuTiaoJian + ")";
                dictMoneys[data.BianHao] = data.BoFuTiaoJian;
            }

            dgvDetail.Rows.Clear();
            List<KeTiBiao> subjectList = ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());
            subjectList = subjectList.OrderBy(t => t.ZhuangTai).ThenBy(p => p.ModifyTime).ToList();

            foreach (KeTiBiao subject in subjectList)
            {
                //生成年度经费字符
                List<KeTiJieDianJingFeiBiao> moneyList = ConnectionManager.Context.table("KeTiJieDianJingFeiBiao").where("KeTiBianHao='" + subject.BianHao + "'").select("*").getList<KeTiJieDianJingFeiBiao>(new KeTiJieDianJingFeiBiao());
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, string> kvpps in dictMoneys)
                {
                    bool isNeedAdd = true;
                    foreach (KeTiJieDianJingFeiBiao money in moneyList)
                    {
                        string nodeStr = string.Empty;
                        if (kvpps.Key == money.BoFuBianHao)
                        {
                            isNeedAdd = false;
                            nodeStr = dictMoneys[money.BoFuBianHao];
                            sb.Append(nodeStr).Append("：").Append(money.JingFei).AppendLine("万元");
                        }
                    }

                    if (isNeedAdd)
                    {
                        sb.Append(kvpps.Value).Append("：").Append(0).AppendLine("万元");
                    }
                }

                List<object> cells = new List<object>();
                cells.Add(subject.KeTiMingCheng);
                cells.Add(sb.ToString());

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = subject;
            }
        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }
    }
}