using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyLeveleditor
{
    public partial class LayersForm : Form
    {
        private int numLayers = 1;
        public event EventHandler onClose;
        public event EventHandler onNewLayer;

        public LayersForm()
        {
            InitializeComponent();
        }

        private void LayersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            if (onClose != null)
            {
                onClose.Invoke(this, new EventArgs());
            }

            this.Hide();
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "NewLayer":
                    if (onNewLayer != null)
                    {
                        imageListBox.Items.Add(new ImageListBoxItem("Layer " + numLayers++, Image.FromFile("entity_added.bmp")));
                        onNewLayer.Invoke(this, new EventArgs());
                    }
                    break;
            }
        }


    }
}