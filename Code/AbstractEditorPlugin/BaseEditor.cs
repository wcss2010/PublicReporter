using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AbstractEditorPlugin
{
    public delegate void SaveEventDelegate(object sender, EventArgs args);

    public partial class BaseEditor : PublicReporterLib.ControlAndForms.PluginControl<AbstractPluginRoot>
    {
        public BaseEditor() : base() { }

        /// <summary>
        /// 编辑器名称
        /// </summary>
        public virtual string EditorName { get; set; }

        public event SaveEventDelegate saveEvent;

        public virtual void onSaveEvent(ref bool result)
        {
            if (saveEvent != null)
            {
                saveEvent(this, new EventArgs());
            }
        }

        /// <summary>
        /// 清理视图
        /// </summary>
        public virtual void clearView() { }

        /// <summary>
        /// 刷新视图
        /// </summary>
        public virtual void refreshView() { }

        /// <summary>
        /// 是否输入完成
        /// </summary>
        /// <returns></returns>
        public virtual bool isInputCompleted() { return false; }
    }
}