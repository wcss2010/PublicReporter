using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProjectContractPlugin.DB.Entitys;
using ProjectContractPlugin.DB;

namespace ProjectContractPlugin.Editor
{
    public partial class SubjectMoneyEditor : BaseEditor
    {
        public SubjectMoneyEditor()
        {
            InitializeComponent();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            tcMoneys.TabPages.Clear();
            List<KeTiBiao> subjectList = ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());
            foreach (KeTiBiao subject in subjectList)
            {
                TabPage tp = new TabPage();
                tp.Name = subject.BianHao;
                tp.Text = subject.KeTiMingCheng;
                tp.Tag = subject;

                MoneyTableControl mtc = new MoneyTableControl();
                mtc.Dock = DockStyle.Fill;

                tp.Controls.Add(mtc);

                tcMoneys.TabPages.Add(tp);
            }
        }

        public override bool IsInputCompleted()
        {
            return true;
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();


        }
    }
}