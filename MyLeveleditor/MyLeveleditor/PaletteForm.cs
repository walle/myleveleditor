using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using SdlDotNet.Graphics;

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
                if (this.activeImageListbox.SelectedItem != null)
                {
                    ImageListBoxItem sel = (ImageListBoxItem)this.activeImageListbox.SelectedItem;

                    return sel.Text;
                }

                return "";
            }
        }

        public string ActivePath
        {
            get
            {
                return activePath;
            }
        }

        private void AddTab(string path, List<string> types)
        {
            try
            {
                activePath = path;
                DirectoryInfo di = new DirectoryInfo(path);
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
                    this.AddTab(addForm.FolderPath, addForm.FolderSearch);
                }
                else if (addForm.Type == "image")
                {
                    string path = Application.StartupPath + "/" + addForm.TabName + "_images";

                    try
                    {
                        // Create a folder for the images
                        //string path = Application.StartupPath + "/" + addForm.TabName + "_images";

                        if (Directory.Exists(path))
                        {
                            Directory.Move(path, path + "_old");
                        }

                        Directory.CreateDirectory(path);

                        // Create a surface to copy the smaller images from
                        //Surface img = new Surface(addForm.ImagePath);
                        Image src = Image.FromFile(addForm.ImagePath);
                        Bitmap img = new Bitmap(src);

                        //img.SaveBmp(path + "/original." + addForm.ImagePath.Substring(addForm.ImagePath.Length - 3));

                        int horizontal = img.Width / addForm.TileSize;
                        int vertical = img.Height / addForm.TileSize;

                        for (int i = 0; i <= horizontal; i++)
                        {
                            for (int j = 0; j <= vertical; j++)
                            {
                                try
                                {
                                    //Surface surface = new Surface(new Size(addForm.TileSize, addForm.TileSize));
                                    //surface.Blit(img, new Rectangle((i*addForm.TileSize), (j*addForm.TileSize), addForm.TileSize, addForm.TileSize));
                                    img.Clone(new Rectangle((i * addForm.TileSize), (j * addForm.TileSize), addForm.TileSize, addForm.TileSize), System.Drawing.Imaging.PixelFormat.DontCare).Save(path + "/" + i + j + "_img" +  ".bmp");
                                    //surface.SaveBmp(path + "/img_" + i + "_" + j + ".bmp");
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.Message);
                                }
                            }
                        }

                        img.Dispose();

                        this.AddTab(path, new List<string>());
                    }
                    catch (Exception ex)
                    {
                        this.AddTab(path, new List<string>());
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void removeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.RemoveAt((tabControl.TabIndex - 1));
        }
    }
}