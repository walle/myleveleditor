using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using MapAPI;

namespace MyLeveleditor
{
    class ToolboxToolEraser : ToolboxTool
    {
        private string name = "Eraser";

        public ToolboxToolEraser()
        {

        }

        public void Execute(MainForm mainForm, MouseEventArgs e)
        {
            MapForm mapForm = (MapForm)mainForm.ActiveMdiChild;
            MapEntity entity = new MapEntity();

            try
            {
                entity.Filename = mainForm.ActivePaletteImage();
                Image img = new Bitmap(mainForm.ActivePaletteImage());
                entity.Size = img.Size;
                entity.Location = e.Location;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            mapForm.RemoveEntity(entity.Location);
        }

        public string Name
        {
            get { return this.name; }
        }
    }
}
