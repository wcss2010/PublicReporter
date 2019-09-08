using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectContractPlugin.DB.Entitys;

namespace ProjectContractPlugin.Editor
{
    public partial class TechnologyQuestionEditor : BaseEditor
    {
        public TechnologyQuestionEditor()
        {
            InitializeComponent();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            List<JiShuBiao> list = ProjectContractPlugin.DB.ConnectionManager.Context.table("JiShuBiao").select("*").getList<JiShuBiao>(new JiShuBiao());
            int index = 0;
            foreach (JiShuBiao data in list)
            {
                index++;

                List<object> cells = new List<object>();
                cells.Add(index.ToString());
                cells.Add(data.NianDu);
                cells.Add(data.NeiRong);

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = data;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}