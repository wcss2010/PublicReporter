using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectMilitaryTechnologPlanPlugin.Controls
{
    /// <summary>
    /// 自适应高度标签
    /// </summary>
    public class AutoHeightLabel : Label
    {
        private bool autoHeight = false;
        /// <summary>
        /// 是否需要自适应高度
        /// </summary>
        public bool AutoHeight
        {
            get { return autoHeight; }
            set { autoHeight = value; }
        }

        /// <summary>
        /// 当前文本
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                //设置文本
                base.Text = value;

                //处理标签框高度
                processLabelHeight(base.Text);
            }
        }

        /// <summary>
        /// 处理标签框高度
        /// </summary>
        /// <param name="value">文本</param>
        private void processLabelHeight(string value)
        {
            //判断是否需要处适应高度
            if (AutoHeight)
            {
                try
                {
                    //文本大小
                    System.Drawing.SizeF totalSize = TextRenderer.MeasureText(value, Font);

                    //单字大小
                    System.Drawing.SizeF wordSize = TextRenderer.MeasureText("王", Font);

                    //单字高度
                    int wordHeight = (int)wordSize.Height;
                    //单字宽度
                    int wordWidth = (int)wordSize.Width;

                    //文本行数
                    int widthRowCount = 0;

                    if (Width > 2)
                    {
                        //判断是否一行能显示完
                        if (Width > totalSize.Width)
                        {
                            //可以显示在一行
                            widthRowCount = 1;
                        }
                        else
                        {
                            //不能显示在一行
                            widthRowCount = (int)totalSize.Width / Width;
                            int widthElse = (int)totalSize.Width % Width;
                            if (widthElse > wordWidth)
                            {
                                widthRowCount++;
                            }
                        }

                        //判断是否我多行文本
                        if (widthRowCount > 1)
                        {
                            Height = (widthRowCount * wordHeight) + 30;
                        }
                        else
                        {
                            Height = wordHeight + 30;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }                
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //处理标签框高度
            countLabelHeight();
        }

        /// <summary>
        /// 统计标签高度
        /// </summary>
        public void countLabelHeight()
        {
            //计算标签高度
            processLabelHeight(Text);

                try
                {
                    //设置TableLayout布局,用于解决在某些状态下由于自动计算高度导致的遮蔽了下面的控件的BUG
                    //查找TableLayoutPanel
                    TableLayoutPanel panel = GetLayoutPanel();

                    if (panel != null)
                    {
                        //本控件在TableLayoutPanel中是第几行
                        int tableLayoutRow = -1;

                        if (panel != this.Parent)
                        {
                            //Label上面还有一级
                            tableLayoutRow = panel.GetRow(this.Parent);
                        }
                        else
                        {
                            //Label上面直接就是TableLayoutPanel
                            tableLayoutRow = panel.GetRow(this);
                        }

                        if (tableLayoutRow >= 0)
                        {
                            if (AutoHeight)
                            {
                                panel.SuspendLayout();
                                panel.RowStyles[tableLayoutRow].SizeType = SizeType.Absolute;
                                if (Height > panel.RowStyles[tableLayoutRow].Height)
                                {
                                    panel.RowStyles[tableLayoutRow].Height = Height;
                                }
                                panel.ResumeLayout(false);
                            }
                            else
                            {
                                panel.RowStyles[tableLayoutRow].SizeType = SizeType.AutoSize;
                            }
                        }
                    }
                }
                catch (Exception ex) { }
            
        }

        private TableLayoutPanel GetLayoutPanel()
        {
            TableLayoutPanel result = null;

            Control ctsl = this;
            while (true)
            {
                if (ctsl.Parent == null)
                {
                    break;
                }
                else if (ctsl.Parent is TableLayoutPanel)
                {
                    result = (TableLayoutPanel)ctsl.Parent;
                    break;
                }
                else
                {
                    ctsl = ctsl.Parent;
                }
            }

            return result;
        }
    }
}