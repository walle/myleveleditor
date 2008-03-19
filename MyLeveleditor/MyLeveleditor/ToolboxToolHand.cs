using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using MapAPI;

namespace MyLeveleditor
{
    class ToolboxToolHand : ToolboxTool
    {
        private string name = "Hand";
        private Point startPoint = new Point();

        public ToolboxToolHand()
        {

        }

        public void Execute(MainForm mainForm, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MapForm mapForm = (MapForm)mainForm.ActiveMdiChild;
                int dx = (startPoint.X - e.Location.X);
                int dy = (startPoint.Y - e.Location.Y);
                mapForm.AutoScrollPosition = new Point(mapForm.HorizontalScroll.Value + dx, mapForm.VerticalScroll.Value + dy);
            }
        }

        public string Name
        {
            get { return this.name; }
        }
    }
}