using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectReporterPlugin.DB;
using ProjectReporterPlugin.DB.Entitys;
using ProjectReporterPlugin.Forms;

namespace ProjectReporterPlugin.Editor
{
    public partial class ProjectWorkerGroupEditor : AbstractEditorPlugin.BaseEditor
    {
        public ProjectWorkerGroupEditor()
        {
            InitializeComponent();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().projectObj != null)
            {
                KeTiList = ConnectionManager.Context.table("Project").where("Type='" + "课题" + "' and ParentID='" + PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().projectObj.ID + "'").select("*").getList<Project>(new Project());

                dgvDetail.Rows.Clear();
                
                foreach (Project ketis in KeTiList)
                {
                    string personInfo = string.Empty;
                    string personName = string.Empty;

                    Person personObj = null;

                    Task ketiTask = ConnectionManager.Context.table("Task").where("ProjectID='" + ketis.ID + "' and Role = '负责人'").select("*").getItem<Task>(new Task());
                    if (ketiTask != null)
                    {
                        personObj = ConnectionManager.Context.table("Person").where("ID='" + ketiTask.PersonID + "'").select("*").getItem<Person>(new Person());
                        if (personObj != null)
                        {
                            personName = personObj.Name;
                            personInfo = personObj.AttachInfo;
                        }
                    }

                    List<object> cells = new List<object>();
                    cells.Add(ketis.Name);
                    cells.Add(personName);
                    cells.Add(personInfo);

                    int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                    dgvDetail.Rows[rowIndex].Tag = personObj;
                }
            }
        }

        public override bool IsInputCompleted()
        {
            return true;
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (dgvDetail.Rows[e.RowIndex].Tag != null)
                {
                    Person obj = ((Person)dgvDetail.Rows[e.RowIndex].Tag);

                    string lastContent = obj.AttachInfo;

                    FrmInputBox box = new FrmInputBox(lastContent);
                    if (box.ShowDialog() == DialogResult.OK)
                    {
                        obj.AttachInfo = box.SelectedText;
                        obj.copyTo(ConnectionManager.Context.table("Person")).where("ID='" + obj.ID + "'").update();

                        RefreshView();
                    }
                }
            }
        }

        public List<Project> KeTiList { get; set; }
    }
}