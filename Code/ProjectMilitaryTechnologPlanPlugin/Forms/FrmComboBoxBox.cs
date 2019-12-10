using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectMilitaryTechnologPlanPlugin.Forms
{
    public partial class FrmComboBoxBox : PublicReporterLib.SuperForm
    {
        /// <summary>
        /// 已选中项
        /// </summary>
        public TreeNode SelectedNode { get { return tvNodes.SelectedNode; } }

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
                tvNodes.Nodes.AddRange(nodes);
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
    }
}