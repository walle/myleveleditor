using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyLeveleditor
{
    public partial class PaletteForm : Form
    {
        public event EventHandler onClose;

        private ImageListBox activeImageListbox = new ImageListBox();
        private string activePath = "";

        public PaletteForm()
        {
            InitializeComponent();

            this.tabControl.Selected += new TabControlEventHandler(tabControl_Selected);
        }

        void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.SelectedTab.Controls.Count > 0)
            {
                activeImageListbox = (ImageListBox)tabControl.SelectedTab.Controls[0];
            }
        }

        /*
        private void PaletteForm_Load(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo("Tiles");
                FileInfo[] rgFiles = di.GetFiles("*.bmp");
                foreach (FileInfo fi in rgFiles)
                {
                    Image img = Image.FromFile(fi.FullName);
                    this.blocksImageListBox.Items.Add(new ImageListBoxItem(fi.Name, img));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.blocksImageListBox.SelectedIndex = 0;
        }
        */
        public string ActiveImage
        {
            get
            {
                ImageListBoxItem sel = (ImageListBoxItem)this.activeImageListbox.SelectedItem;

                return sel.Text;
            }
        }

        public string ActivePath
        {
            get
            {
                return activePath;
            }
        }

        private void AddTab(string path, string types)
        {

        }

        private void PaletteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            if (onClose != null)
            {
                onClose.Invoke(this, new EventArgs());
            }

            this.Hide();
        }

        private void addDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPaletteTabForm addForm = new AddPaletteTabForm();
            if (addForm.ShowDialog() == DialogResult.OK && addForm.Valid)
            {
                this.tabControl.TabPages.Add(addForm.TabName, addForm.TabName);
                this.tabControl.SelectedIndex = (this.tabControl.TabPages.Count - 1);
                ImageListBox l = new ImageListBox();
                l.Dock = DockStyle.Fill;
                this.tabControl.SelectedTab.Controls.Add(l);
                this.activeImageListbox = l;
                if (addForm.Type == "folder")
                {
                    try
                    {
                        activePath = addForm.FolderPath;
                        List<string> types = addForm.FolderSearch;
                        DirectoryInfo di = new DirectoryInfo(addForm.FolderPath);
                        FileInfo[] rgFiles = di.GetFiles();
                        foreach (FileInfo fi in rgFiles)
                        {
                            if (types.Count > 0)
                            {
                                if (types.Contains(fi.Extension))
                                {
                                    this.activeImageListbox.Items.Add(new ImageListBoxItem(fi.Name, Image.FromFile(fi.FullName)));
                                }
                            }
                            else
                            {
                                this.activeImageListbox.Items.Add(new ImageListBoxItem(fi.Name, Image.FromFile(fi.FullName)));
                            }

                            this.activeImageListbox.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if (addForm.Type == "image")
                {

                }
            }
        }

        private void removeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.RemoveAt((tabControl.TabIndex - 1));
        }
    }
}