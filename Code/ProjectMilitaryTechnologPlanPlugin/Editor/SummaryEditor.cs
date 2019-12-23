﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicReporterLib;
using ProjectMilitaryTechnologPlanPlugin.DB.Entitys;
using ProjectMilitaryTechnologPlanPlugin.DB;
using ProjectMilitaryTechnologPlanPlugin.Forms;

namespace ProjectMilitaryTechnologPlanPlugin.Editor
{
    public partial class SummaryEditor : BaseEditor
    {
        List<string> dutyUnitToProfessonLinks = new List<string>();
        private List<TreeNode> treenodeList;
        public SummaryEditor()
        {
            InitializeComponent();

            //加载选项
            loadComboboxItems();
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

        public override void RefreshView()
        {
            base.RefreshView();

            //加载数据
            if (PluginRootObj.projectObj != null)
            {   
                ibEdit1.Text = PluginRootObj.projectObj.XiangMuMingCheng;
                ibEdit2.Text = PluginRootObj.projectObj.YanJiuMuBiao;

                ibEdit3.Rows.Clear();
                if (PluginRootObj.projectObj.YanJiuNeiRong != null && PluginRootObj.projectObj.YanJiuNeiRong.Contains(UIControlConfig.rowFlag))
                {   
                    string[] tttt = PluginRootObj.projectObj.YanJiuNeiRong.Split(new string[] { UIControlConfig.rowFlag }, StringSplitOptions.None);
                    if (tttt != null)
                    {
                        foreach (string s in tttt)
                        {
                            if (string.IsNullOrEmpty(s)) { continue; }

                            ibEdit3.Rows.Add(new object[] { s });
                        }
                    }
                }

                ibEdit4.Rows.Clear();
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

                                ibEdit4.Rows.Add(vvvv);
                            }
                        }
                    }
                }
                
                foreach (ComboBoxObject<int> obj in ibEdit5.Items)
                {
                    if (obj.Tag == PluginRootObj.projectObj.YanJiuZhouQi)
                    {
                        ibEdit5.SelectedItem = obj;
                        break;
                    }
                }

                ibEdit6.Text = PluginRootObj.projectObj.JingFeiYuSuan + string.Empty;
                ibEdit7.Text = PluginRootObj.projectObj.XiangMuLeiBie;
                //ibEdit19.Text = PluginRootObj.projectObj.ZhuanYeLeiBie;
                ibEdit8.Text = PluginRootObj.projectObj.ZeRenDanWei;
                ibEdit9.Text = PluginRootObj.projectObj.XiaJiDanWei;

                if (PluginRootObj.projectObj.BeiZhu != null)
                {
                    string[] wwww = PluginRootObj.projectObj.BeiZhu.Split(new string[] { UIControlConfig.rowFlag }, StringSplitOptions.None);
                    if (wwww != null && wwww.Length >= 2)
                    {
                        ibEdit10.Text = wwww[0];
                        foreach (TreeNode tn in treenodeList)
                        {
                            if (tn.Text == ibEdit10.Text)
                            {
                                ibEdit10.Tag = tn;
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(wwww[1]))
                        {
                            ibEdit10.Text += "::" + wwww[1];
                        }
                    }
                    else
                    {
                        ibEdit10.Text = PluginRootObj.projectObj.BeiZhu;
                        foreach (TreeNode tn in treenodeList)
                        {
                            if (tn.Text == ibEdit10.Text)
                            {
                                ibEdit10.Tag = tn;
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 动态加载各种选项
        /// </summary>
        private void loadComboboxItems()
        {
            //加载责任单位与专业类型映射选项
            if (UIControlConfig.ConfigObj.Params.ContainsKey("责任单位与专业类别映射"))
            {
                try
                {
                    dutyUnitToProfessonLinks = new List<string>();
                    Newtonsoft.Json.Linq.JArray teams = (Newtonsoft.Json.Linq.JArray)UIControlConfig.ConfigObj.Params["责任单位与专业类别映射"];
                    foreach (string s in teams)
                    {
                        dutyUnitToProfessonLinks.Add(s);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
            //加载预期成果选项
            if (UIControlConfig.ConfigObj.Params.ContainsKey("预期成果项目"))
            {
                try
                {
                    ((DataGridViewComboBoxColumn)ibEdit4.Columns[0]).Items.Clear();
                    Newtonsoft.Json.Linq.JArray teams = (Newtonsoft.Json.Linq.JArray)UIControlConfig.ConfigObj.Params["预期成果项目"];
                    foreach (string s in teams)
                    {
                        ((DataGridViewComboBoxColumn)ibEdit4.Columns[0]).Items.Add(s);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
            //加载研究周期选项
            if (UIControlConfig.ConfigObj.Params.ContainsKey("研究周期"))
            {
                try
                {
                    ibEdit5.Items.Clear();
                    Newtonsoft.Json.Linq.JArray teams = (Newtonsoft.Json.Linq.JArray)UIControlConfig.ConfigObj.Params["研究周期"];
                    foreach (string ssss in teams)
                    {
                        string[] ttt = ssss.Split(new string[] { UIControlConfig.rowFlag }, StringSplitOptions.None);
                        if (ttt != null && ttt.Length >= 2)
                        {
                            ComboBoxObject<int> comboboxObject = new ComboBoxObject<int>();
                            comboboxObject.Text = ttt[0];
                            comboboxObject.Tag = int.Parse(ttt[1]);
                            ibEdit5.Items.Add(comboboxObject);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
            //加载项目类别选项
            if (UIControlConfig.ConfigObj.Params.ContainsKey("项目类别"))
            {
                try
                {
                    ibEdit7.Items.Clear();
                    Newtonsoft.Json.Linq.JArray teams = (Newtonsoft.Json.Linq.JArray)UIControlConfig.ConfigObj.Params["项目类别"];
                    foreach (string sss in teams)
                    {
                        string[] ttt = sss.Split(new string[] { UIControlConfig.rowFlag }, StringSplitOptions.None);
                        if (ttt != null && ttt.Length >= 4)
                        {
                            ProjectSortObject pso = new ProjectSortObject();
                            pso.Text = ttt[0];

                            string[] vvv = ttt[1].Replace("[", string.Empty).Replace("]", string.Empty).Split(new string[] { "," }, StringSplitOptions.None);
                            if (vvv != null && vvv.Length >= 2)
                            {
                                pso.InfoMin = int.Parse(vvv[0]);
                                pso.InfoMax = int.Parse(vvv[1]);
                            }

                            vvv = ttt[2].Replace("[", string.Empty).Replace("]", string.Empty).Split(new string[] { "," }, StringSplitOptions.None);
                            if (vvv != null && vvv.Length >= 2)
                            {
                                pso.TableMin = int.Parse(vvv[0]);
                                pso.TableMax = int.Parse(vvv[1]);
                            }

                            pso.Money = decimal.Parse(ttt[3]);

                            ibEdit7.Items.Add(pso);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
            //加载责任单位选项
            if (UIControlConfig.ConfigObj.Params.ContainsKey("责任单位"))
            {
                try
                {
                    ibEdit8.Items.Clear();
                    Newtonsoft.Json.Linq.JArray teams = (Newtonsoft.Json.Linq.JArray)UIControlConfig.ConfigObj.Params["责任单位"];
                    foreach (string s in teams)
                    {
                        ibEdit8.Items.Add(s);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
            ////加载专业类别选项
            //if (UIControlConfig.ConfigObj.Params.ContainsKey("专业类别"))
            //{
            //    try
            //    {
            //        ibEdit19.Items.Clear();
            //        Newtonsoft.Json.Linq.JArray teams = (Newtonsoft.Json.Linq.JArray)UIControlConfig.ConfigObj.Params["专业类别"];
            //        foreach (string s in teams)
            //        {
            //            ibEdit19.Items.Add(s);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Console.WriteLine(ex.ToString());
            //    }
            //}
            //加载备注选项
            treenodeList = new List<TreeNode>();
            if (UIControlConfig.ConfigObj.Params.ContainsKey("备注"))
            {
                try
                {
                    Newtonsoft.Json.Linq.JArray teams = (Newtonsoft.Json.Linq.JArray)UIControlConfig.ConfigObj.Params["备注"];
                    foreach (string s in teams)
                    {
                        treenodeList.Add(new TreeNode(s));
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }

        public override void OnSaveEvent(ref bool result)
        {
            base.OnSaveEvent(ref result);

            if (ibEdit1.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目名称!");
                result = false;
                return;
            }
            if (ibEdit7.SelectedItem == null)
            {
                MessageBox.Show("对不起，请选择项目类别!");
                result = false;
                return;
            }
            ProjectSortObject psoo = (ProjectSortObject)ibEdit7.SelectedItem;
            if (ibEdit2.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入研究目标!");
                result = false;
                return;
            }
            if (!(ibEdit2.Text.Length >= psoo.InfoMin && ibEdit2.Text.Length <= psoo.InfoMax))
            {
                MessageBox.Show("对不起，请输入研究目标(" + psoo.InfoMin + "," + psoo.InfoMax + ")!");
                result = false;
                return;
            }
            if (!(ibEdit3.Rows.Count - 1 >= psoo.TableMin && ibEdit3.Rows.Count - 1 <= psoo.TableMax))
            {
                MessageBox.Show("对不起，请输入研究内容(" + psoo.TableMin + "," + psoo.TableMax + ")!");
                result = false;
                return;
            }
            if (ibEdit4.Rows.Count == 0 || ibEdit4.Rows.Count > 5)
            {
                MessageBox.Show("对不起，请输入预期成果(不超过4条)!");
                result = false;
                return;
            }
            if (ibEdit5.SelectedItem == null)
            {
                MessageBox.Show("对不起，请输入研究周期!");
                result = false;
                return;
            }
            Single dd6;
            if (Single.TryParse(ibEdit6.Text, out dd6) == false)
            {
                MessageBox.Show("对不起，请输入经费预算!");
                result = false;
                return;
            }
            if ((decimal)dd6 > psoo.Money)
            {
                MessageBox.Show("对不起，经费预算的金额太大(" + psoo.Money + "万之内)!");
                result = false;
                return;
            }
            if (ibEdit8.SelectedItem == null)
            {
                MessageBox.Show("对不起，请输入责任单位!");
                result = false;
                return;
            }
            if (ibEdit9.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入下级单位!");
                result = false;
                return;
            }
            if (ibEdit10.Tag == null)
            {
                MessageBox.Show("对不起，请输入备注!");
                result = false;
                return;
            }
            //if (dutyUnitToProfessonLinks.Contains(ibEdit8.SelectedItem.ToString()) && ibEdit19.SelectedItem == null)
            //{
            //    MessageBox.Show("对不起，请输入专业类别!");
            //    result = false;
            //    return;
            //}

            if (PluginRootObj.projectObj == null)
            {
                PluginRootObj.projectObj = new JiBenXinXiBiao();
            }

            PluginRootObj.projectObj.XiangMuMingCheng = ibEdit1.Text;

            //if (dutyUnitToProfessonLinks.Contains(ibEdit8.SelectedItem.ToString()))
            //{
            //    PluginRootObj.projectObj.ZhuanYeLeiBie = ibEdit19.SelectedItem.ToString();
            //}

            PluginRootObj.projectObj.YanJiuMuBiao = ibEdit2.Text;

            StringBuilder sb33 = new StringBuilder();
            StringBuilder sb44 = new StringBuilder();
            foreach (DataGridViewRow dgvRow in ibEdit3.Rows)
            {
                if (dgvRow.Cells[0].Value == null)
                {
                    continue;
                }

                sb33.Append(dgvRow.Cells[0].Value != null ? dgvRow.Cells[0].Value.ToString() : string.Empty).Append(UIControlConfig.rowFlag);
            }
            foreach (DataGridViewRow dgvRow in ibEdit4.Rows)
            {
                if (dgvRow.Cells[0].Value == null)
                {
                    continue;
                }

                sb44.Append(dgvRow.Cells[0].Value != null ? dgvRow.Cells[0].Value.ToString() : string.Empty).Append(UIControlConfig.cellFlag).Append(dgvRow.Cells[1].Value != null ? dgvRow.Cells[1].Value.ToString() : string.Empty).Append(UIControlConfig.rowFlag);
            }
            PluginRootObj.projectObj.YanJiuNeiRong = sb33.ToString();
            PluginRootObj.projectObj.YuQiChengGuo = sb44.ToString();

            PluginRootObj.projectObj.YanJiuZhouQi = ((ComboBoxObject<int>)ibEdit5.SelectedItem).Tag;

            PluginRootObj.projectObj.JingFeiYuSuan = decimal.Parse(ibEdit6.Text);
            PluginRootObj.projectObj.XiangMuLeiBie = ibEdit7.Text;
            PluginRootObj.projectObj.ZeRenDanWei = ibEdit8.Text;
            PluginRootObj.projectObj.XiaJiDanWei = ibEdit9.Text;
            PluginRootObj.projectObj.BeiZhu = ibEdit10.Text.Replace("::", UIControlConfig.rowFlag);

            if (string.IsNullOrEmpty(PluginRootObj.projectObj.BianHao))
            {
                PluginRootObj.projectObj.BianHao = Guid.NewGuid().ToString();
                PluginRootObj.projectObj.copyTo(ConnectionManager.Context.table("JiBenXinXiBiao")).insert();
            }
            else
            {
                PluginRootObj.projectObj.copyTo(ConnectionManager.Context.table("JiBenXinXiBiao")).where("BianHao='" + PluginRootObj.projectObj.BianHao + "'").update();
            }
        }

        private void ibEdit10_Click(object sender, EventArgs e)
        {
            FrmComboBoxBox comboboxForm = new FrmComboBoxBox();
            comboboxForm.initComboboxList(treenodeList.ToArray());
            if (ibEdit10.Tag != null)
            {
                comboboxForm.SelectedNode = (TreeNode)ibEdit10.Tag;
            }
            if (ibEdit10.Text.Contains("::"))
            {
                string[] tttt = ibEdit10.Text.Split(new string[] { "::" }, StringSplitOptions.None);
                if (tttt != null && tttt.Length >= 2)
                {
                    comboboxForm.ElseText = tttt[1];
                }
            }
            if (comboboxForm.ShowDialog() == DialogResult.OK)
            {
                ibEdit10.Text = comboboxForm.SelectedNode.Text + (!string.IsNullOrEmpty(comboboxForm.ElseText) ? "::" + comboboxForm.ElseText : string.Empty);
                ibEdit10.Tag = comboboxForm.SelectedNode;
            }
        }

        private void ibEdit3_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            }
        }

        private void ibEdit4_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            }
        }

        private void ibEdit3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
        }

        private void ibEdit4_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
        }

        private void ibEdit3_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
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
        }

        private void ibEdit4_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
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

    /// <summary>
    /// 项目类别
    /// </summary>
    public class ProjectSortObject
    {
        public ProjectSortObject()
        {
            Text = string.Empty;
            InfoMin = 80;
            InfoMax = 150;
            TableMin = 5;
            TableMax = 10;
            Money = 100;
        }

        public string Text { get; set; }

        public int InfoMin { get; set; }

        public int InfoMax { get; set; }

        public int TableMin { get; set; }

        public int TableMax { get; set; }

        public decimal Money { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    /// <summary>
    /// ComboBoxObject
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ComboBoxObject<T>
    {
        public string Text { get; set; }

        public T Tag { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}