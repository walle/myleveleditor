using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using MapAPI;

namespace MyLeveleditor
{
    interface ToolboxTool
    {
        void Execute(MainForm mainForm, MouseEventArgs e);
        string Name { get; }
    }
}
