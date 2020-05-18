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
    public partial class SubjectMoneyEditor : AbstractEditorPlugin.BaseEditor
    {
        public SubjectMoneyEditor()
        {
            InitializeComponent();
        }

        public override void refreshView()
        {
            base.refreshView();

            //获得课题列表
            List<KeTiBiao> subjectList = ConnectionManager.Context.table("KeTiBiao").select("*").getList<KeTiBiao>(new KeTiBiao());

            //检查是否需要创建或移除TabPage
            if (tcMoneys.TabPages.Count > subjectList.Count)
            {
                //标签页多了需要减少
                int removeCount = tcMoneys.TabPages.Count - subjectList.Count;
                for (int kk = 0; kk < removeCount; kk++)
                {
                    tcMoneys.TabPages.RemoveAt(0);
                }
            }
            else if (subjectList.Count > tcMoneys.TabPages.Count)
            {
                //增加了新课题，需要增加标签页
                int addCount = subjectList.Count - tcMoneys.TabPages.Count;
                for (int kk = 0; kk < addCount; kk++)
                {
                    TabPage tp = new TabPage();
                    MoneyTableControl mtc = new MoneyTableControl();
                    mtc.Dock = DockStyle.None;
                    mtc.Left = 0;
                    mtc.Top = 0;
                    tp.AutoScroll = true;
                    tp.Controls.Add(mtc);
                    tcMoneys.TabPages.Add(tp);
                }
            }
            
            //填充数据
            int tabIndex = 0;
            foreach (KeTiBiao subject in subjectList)
            {
                //取标签页
                TabPage tp = tcMoneys.TabPages[tabIndex];
                tp.Name = subject.BianHao;
                tp.Text = subject.KeTiMingCheng;
                tp.Tag = subject;

                //取显示控件
                MoneyTableControl mtc = (MoneyTableControl)tp.Controls[0];

                //载入数据
                mtc.loadMoneys(ConnectionManager.Context.table("KeTiYuSuanBiao").where("KeTiBianHao='" + subject.BianHao + "'").select("*").getList<KeTiYuSuanBiao>(new KeTiYuSuanBiao()));

                tabIndex++;
            }
        }

        public override bool isInputCompleted()
        {
            bool result = true;
            foreach (TabPage tp in tcMoneys.TabPages)
            {
                if (tp.Controls.Count >= 1)
                {
                    if (tp.Controls[0] is MoneyTableControl)
                    {
                        MoneyTableControl mtc = (MoneyTableControl)tp.Controls[0];
                        if (mtc.getInputCount() >= 3)
                        {
                            continue;
                        }
                        else 
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public override void onSaveEvent(ref bool result)
        {
            base.onSaveEvent(ref result);

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
            refreshView();
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
                onSaveEvent(ref result);
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