using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyLeveleditor
{
    public partial class HistoryForm : Form
    {
        public event EventHandler onClose;
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            if (onClose != null)
            {
                onClose.Invoke(this, new EventArgs());
            }

            this.Hide();
        }

        public void Add(string str)
        {
            ImageListBoxItem item = null;

            if (str == "Add")
            {
                item = new ImageListBoxItem("Entity added", new Bitmap("entity_added.bmp"));
            }
            else if (str == "Remove")
            {
                item = new ImageListBoxItem("Entity removed", new Bitmap("entity_removed.bmp"));
            }

            if (item != null)
            {
                imageListBox.Items.Add(item);
            }
        }

        public void Remove()
        {
            int index = imageListBox.Items.Count - 1;
            imageListBox.Items.RemoveAt(index);
        }
    }
}