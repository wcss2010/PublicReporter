using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AbstractEditorPlugin;

namespace ProjectStrategicLeadershipPlugin.Editor
{
    public partial class MasterListEditor : BaseEditor
    {
        public MasterListEditor()
        {
            InitializeComponent();
        }

        public override void clearView()
        {
            base.clearView();

        }

        public override void refreshView()
        {
            base.refreshView();

        }

        public override bool isInputCompleted()
        {
            return true;
        }
    }
}