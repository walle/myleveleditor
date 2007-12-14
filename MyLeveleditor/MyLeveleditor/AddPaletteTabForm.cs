using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyLeveleditor
{
    public partial class AddPaletteTabForm : Form
    {
        public AddPaletteTabForm()
        {
            InitializeComponent();
        }

        private void imageBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Jpeg file (*.jpg)|*.jpg|Bmp file (*.bmp)|*.bmp|Png file (*.png)|*.png|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                imageTextbox.Text = openFileDialog.FileName;
            }
        }

        private void folderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please select a folder";
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = fbd.SelectedPath;
            }
        }

        private void folderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (folderRadioButton.Checked)
            {
                imagePanel.Visible = false;
                folderPanel.Visible = true;
            }
        }

        private void imageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (imageRadioButton.Checked)
            {
                folderPanel.Visible = false;
                imagePanel.Visible = true; 
            }
        }

        #region // Properties

        public bool Valid
        {
            get
            {
                if (this.Type == "folder")
                {
                    if (this.FolderPath.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (this.Type == "image")
                {
                    if (this.ImagePath.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
        }

        public string Type
        {
            get
            {
                if (folderRadioButton.Checked)
                {
                    return "folder";
                }
                else if (imageRadioButton.Checked)
                {
                    return "image";
                }

                return "";
            }
        }

        public string TabName
        {
            get
            {
                return this.pathTextBox.Text.Substring((pathTextBox.Text.LastIndexOf("\\") + 1));
            }
        }

        public string ImagePath
        {
            get { return imageTextbox.Text; }
        }

        public int TileSize
        {
            get
            {
                if (imageSizeTextbox.Text.Length > 0)
                {
                    return Convert.ToInt32(imageSizeTextbox.Text);
                }

                return 0;
            }
        }

        public string FolderPath
        {
            get { return pathTextBox.Text; }
        }

        public List<String> FolderSearch
        {
            get
            {
                if (fileTextbox.Text.Length > 0)
                {
                    string[] strings = fileTextbox.Text.Split(',');
                    if (strings.Length > 0)
                    {
                        List<string> extensions = new List<string>();
                        foreach (string s in strings)
                        {
                            extensions.Add(s);
                        }

                        return extensions;
                    }

                    return new List<string>();
                }

                return new List<string>();
            }
        }

        #endregion
    }
}