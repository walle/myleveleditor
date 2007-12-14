using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyLeveleditor
{
    public partial class MapCellSizeForm : Form
    {
        public event ScrollEventHandler cellSizeChange;

        public MapCellSizeForm(int startvalue)
        {
            InitializeComponent();
            cellsizeTrackBar.Value = startvalue;
            cellsizeValueLabel.Text = startvalue.ToString();
        }

        private void cellsizeTrackBar_Scroll(object sender, EventArgs e)
        {
            cellsizeValueLabel.Text = cellsizeTrackBar.Value.ToString();
            if (cellsizeTrackBar.Focused && cellSizeChange != null)
            {
                ScrollEventArgs ea = new ScrollEventArgs(ScrollEventType.EndScroll, cellsizeTrackBar.Value);
                cellSizeChange.Invoke(sender, ea);
            }
        }

        public int CellSize
        {
            get { return cellsizeTrackBar.Value; }
        }
    }
}