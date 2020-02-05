using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicReporterLib.Utility;
using ProjectStrategicLeadershipPlugin.DB;
using ProjectStrategicLeadershipPlugin.DB.Entitys;
using Newtonsoft.Json;
using ProjectStrategicLeadershipPlugin.Forms;
using AbstractEditorPlugin;
using AbstractEditorPlugin.Controls;
using AbstractEditorPlugin.Forms;
using AbstractEditorPlugin.Utility;

namespace ProjectStrategicLeadershipPlugin.Editor
{
    public partial class SubjectStepEditor : BaseEditor
    {
        public SubjectStepEditor()
        {
            InitializeComponent();
            dgvDetail.Paint += dgvDetail_Paint;
        }

        void dgvDetail_Paint(object sender, PaintEventArgs e)
        {
            //字符串显示格式
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //合并列表
            List<KeyValuePair<int, int>> mergeList = new List<KeyValuePair<int, int>>();

            //处理列合并
            #region 1. 首先确定哪些可以合并
            int rowCount = dgvDetail.Rows.Count;
            object lastValue = null;
            int startRowIndex = -1;
            int endRowIndex = -1;
            for (int k = 0; k < rowCount; k++)
            {
                object value = dgvDetail.Rows[k].Cells[0].Value;
                if (k == 0)
                {
                    lastValue = value;
                    startRowIndex = k;
                    endRowIndex = -1;
                }
                else
                {
                    if (value == lastValue)
                    {
                        endRowIndex = k;
                        continue;
                    }
                    else
                    {
                        if (endRowIndex > startRowIndex)
                        {
                            mergeList.Add(new KeyValuePair<int, int>(startRowIndex, endRowIndex));
                        }

                        lastValue = value;
                        startRowIndex = k;
                        endRowIndex = -1;
                    }
                }
            }
            if (endRowIndex > startRowIndex)
            {
                mergeList.Add(new KeyValuePair<int, int>(startRowIndex, endRowIndex));
            }
            #endregion

            #region 2. 重新绘制单元格文本
            foreach (KeyValuePair<int, int> kvps in mergeList)
            {
                if (kvps.Value > kvps.Key)
                {
                    //可显示的文本
                    string rowText = dgvDetail.Rows[kvps.Key].Cells[0].Value != null ? dgvDetail.Rows[kvps.Key].Cells[0].Value.ToString() : string.Empty;

                    //开始的单元格显示范围
                    Rectangle rectStart = dgvDetail.GetCellDisplayRectangle(0, kvps.Key, false);
                    for (int displayIndex = kvps.Key + 1; displayIndex <= kvps.Value; displayIndex++)
                    {
                        Rectangle rectEnd = dgvDetail.GetCellDisplayRectangle(0, displayIndex, false);
                        rectStart.Height += rectEnd.Height;
                    }

                    //覆盖已经输出的文字
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(rectStart.X + 2, rectStart.Y + 2, rectStart.Width - 4, rectStart.Height - 4));

                    //重新绘制文本
                    e.Graphics.DrawString(rowText, new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), new SolidBrush(Color.Black), new RectangleF(rectStart.X + 2, rectStart.Y + 2, rectStart.Width - 4, rectStart.Height - 4), sf);

                    //绘制底部边框线
                    //e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray), 1), new Point(rectStart.Left, rectStart.Bottom), new Point(rectStart.Right, rectStart.Bottom));
                }
            }
            #endregion
        }

        public override void clearView()
        {
            base.clearView();

            dgvDetail.Rows.Clear();
        }

        public override bool isInputCompleted()
        {
            return dgvDetail.Rows.Count >= 1;
        }

        public override void refreshView()
        {
            base.refreshView();

            dgvDetail.Rows.Clear();
            List<Subjects> subList = ConnectionManager.Context.table("Subjects").select("*").getList<Subjects>(new Subjects());
            List<ProjectStep> psList = ConnectionManager.Context.table("ProjectStep").select("*").getList<ProjectStep>(new ProjectStep());
            foreach (Subjects sub in subList)
            {
                int stepIndexx = 0;
                foreach (ProjectStep ps in psList)
                {
                    stepIndexx++;

                    Steps stepObj = ConnectionManager.Context.table("Steps").where("SubjectID = '" + sub.ID + "' and StepID = '" + ps.ID + "'").select("*").getItem<Steps>(new Steps());
                    if (string.IsNullOrEmpty(stepObj.ID))
                    {
                        //没有这个记录
                        stepObj.SubjectID = sub.ID;
                        stepObj.StepID = ps.ID;
                        stepObj.StepTag1 = "空";
                        stepObj.StepTag2 = "空";
                        stepObj.StepTag3 = "空";
                        stepObj.StepTag4 = "空";
                    }

                    List<object> cells = new List<object>();
                    cells.Add(sub.SubjectName);
                    cells.Add(stepIndexx.ToString());
                    cells.Add(stepObj.StepTag1);
                    cells.Add(stepObj.StepTag2);
                    cells.Add(stepObj.StepTag3);
                    
                    int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                    dgvDetail.Rows[rowIndex].Tag = stepObj;
                }   
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1 && dgvDetail.Rows.Count > e.RowIndex && e.RowIndex >= 0)
            {
                Steps task = (Steps)dgvDetail.Rows[e.RowIndex].Tag;
                if (task != null)
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1 && dgvDetail.Rows[e.RowIndex].Cells[0].Value != null && dgvDetail.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        FrmAddOrUpdateSubjectStep form = new FrmAddOrUpdateSubjectStep(task, dgvDetail.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvDetail.Rows[e.RowIndex].Cells[1].Value.ToString());
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            refreshView();
                        }
                    }
                }
            }
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender)[((DataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex].Value = global::ProjectStrategicLeadershipPlugin.Resource.Question_16;
        }
    }
}