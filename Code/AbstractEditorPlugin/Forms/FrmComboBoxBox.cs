using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AbstractEditorPlugin.Forms
{
    public partial class FrmComboBoxBox : BaseForm
    {
        /// <summary>
        /// 已选中项
        /// </summary>
        public TreeNode SelectedNode
        {
            get
            {
                return tvNodes.SelectedNode;
            }
            set
            {
                foreach (TreeNode tn in tvNodes.Nodes)
                {
                    if (tn.Text == value.Text)
                    {
                        tvNodes.SelectedNode = tn;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 其它内容
        /// </summary>
        public string ElseText
        {
            get
            {
                return txtElseText.Text;
            }
            set
            {
                txtElseText.Text = value;
            }
        }

        public FrmComboBoxBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化下拉框列表
        /// </summary>
        /// <param name="nodes"></param>
        public void initComboboxList(TreeNode[] nodes)
        {
            if (nodes != null)
            {
                tvNodes.Nodes.Clear();
                foreach (TreeNode tn in nodes)
                {
                    tvNodes.Nodes.Add((TreeNode)tn.Clone());
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void tvNodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "其它" || e.Node.Text == "其他")
            {
                txtElseText.Enabled = true;
            }
            else
            {
                txtElseText.Text = string.Empty;
                txtElseText.Enabled = false;
            }
        }
    }
}