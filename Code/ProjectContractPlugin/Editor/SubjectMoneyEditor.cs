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

                //载入数据
                mtc.loadMoneys(ConnectionManager.Context.table("KeTiYuSuanBiao").where("KeTiBianHao='" + subject.BianHao + "'").select("*").getList<KeTiYuSuanBiao>(new KeTiYuSuanBiao()));

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

            //保存数据
            foreach (TabPage tp in tcMoneys.TabPages)
            {
                if (tp.Controls.Count >= 1 && tp.Controls[0] is MoneyTableControl)
                {
                    List<KeTiYuSuanBiao> list = ((MoneyTableControl)tp.Controls[0]).getMoneys();
                    
                    //删除旧的数据
                    ConnectionManager.Context.table("KeTiYuSuanBiao").where("KeTiBianHao='" + tp.Name + "'").delete();

                    //添加数据
                    foreach (KeTiYuSuanBiao table in list)
                    {
                        table.KeTiBianHao = tp.Name;
                        table.ZhuangTai = 0;
                        table.ModifyTime = DateTime.Now;
                        table.copyTo(ConnectionManager.Context.table("KeTiYuSuanBiao")).insert();
                    }
                }
            }

            //刷新数据
            RefreshView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                OnSaveEvent();
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
    }
}