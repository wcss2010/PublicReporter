using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ProjectMilitaryTechnologPlanPlugin.Editor
{
    public delegate void SaveEventDelegate(object sender, EventArgs args);

    public partial class BaseEditor : PublicReporterLib.SuperControl
    {
        public BaseEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 编辑器名称
        /// </summary>
        public virtual string EditorName { get; set; }

        public event SaveEventDelegate SaveEvent;

        public virtual void OnSaveEvent(ref bool result)
        {
            if (SaveEvent != null)
            {
                SaveEvent(this, new EventArgs());
            }
        }

        /// <summary>
        /// 清理视图
        /// </summary>
        public virtual void ClearView() { }

        /// <summary>
        /// 刷新视图
        /// </summary>
        public virtual void RefreshView() { }

        /// <summary>
        /// 是否输入完成
        /// </summary>
        /// <returns></returns>
        public virtual bool IsInputCompleted() { return false; }
    }
}