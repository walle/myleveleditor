using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyLeveleditor
{
    public delegate void LayerChangedEventHandler (object sender, LayerChangedEventArgs e);

    public partial class LayersForm : Form
    {
        private int numLayers = 1;
        public event EventHandler onClose;
        public event EventHandler onNewLayer;
        public event LayerChangedEventHandler onLayerChanged;
        public event LayerChangedEventHandler onLayerRemoved;

        public LayersForm()
        {
            InitializeComponent();
            this.imageListBox.SelectedIndexChanged += new EventHandler(imageListBox_SelectedIndexChanged);
        }

        void imageListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onLayerChanged != null)
            {
                LayerChangedEventArgs ea = new LayerChangedEventArgs(this.imageListBox.SelectedIndex);
                onLayerChanged.Invoke(this, ea);
            }
        }

        public void LoadLayers(MapAPI.MapData data)
        {
            this.numLayers = 1;
            this.imageListBox.Items.Clear();

            foreach (MapAPI.MapLayer l in data.layers)
            {
                this.imageListBox.Items.Add(new ImageListBoxItem("Layer " + numLayers++, Image.FromFile("entity_added.bmp")));
            }
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
                case "RemoveLayer":
                    if (onLayerRemoved != null)
                    {
                        onLayerRemoved.Invoke(this, new LayerChangedEventArgs(this.imageListBox.SelectedIndex));
                        imageListBox.Items.RemoveAt(this.imageListBox.SelectedIndex);
                    }
                    break;
            }
        }


    }
}