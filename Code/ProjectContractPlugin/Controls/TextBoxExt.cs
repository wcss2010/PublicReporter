using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectContractPlugin.Controls
{
    public class TextBoxExt : TextBox
    {
        public void SaveFile(string file)
        {
            File.WriteAllText(file, Text);
        }

        public void LoadFile(string file)
        {
            if (File.Exists(file))
            {
                Text = File.ReadAllText(file);
            }
        }
    }
}