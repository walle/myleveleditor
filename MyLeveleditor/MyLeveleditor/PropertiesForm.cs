using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyLeveleditor
{
    public partial class PropertiesForm : Form
    {
        public event EventHandler onClose;

        public PropertiesForm()
        {
            InitializeComponent();
        }

        public void LoadData(MapAPI.MapData data)
        {
            this.propertyGrid.SelectedObject = data;
        }

        private void PropertiesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            if (onClose != null)
            {
                onClose.Invoke(this, new EventArgs());
            }

            this.Hide();
        }
    }
}