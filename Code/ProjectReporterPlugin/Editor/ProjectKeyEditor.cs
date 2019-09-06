using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectReporterPlugin.Editor
{
    public partial class ProjectKeyEditor : UserControl
    {
        public ProjectKeyEditor()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(txtWord1.Text))
                {
                    sb.Append(txtWord1.Text).Append(";");
                }

                if (!string.IsNullOrEmpty(txtWord2.Text))
                {
                    sb.Append(txtWord2.Text).Append(";");
                }

                if (!string.IsNullOrEmpty(txtWord3.Text))
                {
                    sb.Append(txtWord3.Text).Append(";");
                }

                if (!string.IsNullOrEmpty(txtWord4.Text))
                {
                    sb.Append(txtWord4.Text).Append(";");
                }

                if (!string.IsNullOrEmpty(txtWord5.Text))
                {
                    sb.Append(txtWord5.Text).Append(";");
                }

                if (sb.Length >= 1)
                {
                    sb.Remove(sb.Length - 1, 1);
                }

                if (string.IsNullOrEmpty(txtWord1.Text) || string.IsNullOrEmpty(txtWord2.Text) || string.IsNullOrEmpty(txtWord3.Text))
                {
                    return string.Empty;
                }
                else
                {
                    return sb.ToString();
                }
            }

            set
            {
                if (value != null)
                {
                    string[] ttt = value.Split(new string[] { ";" }, StringSplitOptions.None);
                    int indexx = 0;
                    foreach(string val in ttt)
                    {
                        indexx++;
                        Control[] cons = Controls.Find("txtWord" + indexx, true);
                        if (cons != null)
                        {
                            foreach (Control c in cons)
                            {
                                c.Text = val;
                            }
                        }
                    }
                }
            }
        }
    }
}