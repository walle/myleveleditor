using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyLeveleditor
{
    public partial class NewMapForm : Form
    {
        public NewMapForm(int openMaps)
        {
            InitializeComponent();
            nameTextBox.Text = "Untitled-" + openMaps;
        }

        private void presetSizesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] arr = presetSizesComboBox.Text.Split(" x ".ToCharArray(), 2);
                widthTextbox.Text = arr[0];
                heightTextbox.Text = arr[1].Substring(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void NewMapForm_Load(object sender, EventArgs e)
        {
            presetSizesComboBox.SelectedIndex = 0;
        }

        #region // Properties

        public int MapWidth
        {
            get { return Convert.ToInt32(widthTextbox.Text); }
        }

        public int MapHeight
        {
            get { return Convert.ToInt32(heightTextbox.Text); }
        }

        public string MapName
        {
            get { return nameTextBox.Text; }
        }

        #endregion
    }
}