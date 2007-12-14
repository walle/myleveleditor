using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MyLeveleditor
{
    class ToolboxButton : Button
    {
        protected override void OnMouseEnter(EventArgs e)
        {
            this.FlatStyle = FlatStyle.Popup;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.FlatStyle = FlatStyle.Flat;
        }
    }
}
