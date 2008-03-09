using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MapAPI;

namespace MyLeveleditor
{
    partial class ToolboxForm : Form
    {
        private ToolboxTool tool = null;

        public ToolboxForm()
        {
            InitializeComponent();
            this.Tool = new ToolboxToolPen();
        }

        private void penButton_Click(object sender, EventArgs e)
        {
            this.tool = new ToolboxToolPen();
            penButton.BackColor = SystemColors.ButtonHighlight;

            handButton.BackColor = SystemColors.Control;
            eraserButton.BackColor = SystemColors.Control;
        }

        private void handButton_Click(object sender, EventArgs e)
        {
            this.tool = new ToolboxToolHand();
            handButton.BackColor = SystemColors.ButtonHighlight;

            penButton.BackColor = SystemColors.Control;
            eraserButton.BackColor = SystemColors.Control;
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {
            this.tool = new ToolboxToolEraser();
            eraserButton.BackColor = SystemColors.ButtonHighlight;

            penButton.BackColor = SystemColors.Control;
            handButton.BackColor = SystemColors.Control;
        }

        public void ExecuteClick(object sender, MouseEventArgs e)
        {
            MainForm m = (MainForm)this.Owner;
            MapEntity entity = new MapEntity();

            try
            {
                entity.Filename = m.ActivePaletteImage();
                Image img = new Bitmap(m.ActivePaletteImage());
                entity.Size = img.Size;
                entity.Location = e.Location;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.tool.Execute((MapForm)m.ActiveMdiChild, entity);
        }

        public ToolboxTool Tool
        {
            get { return this.tool; }
            set { this.tool = value; }
        }
    }
}