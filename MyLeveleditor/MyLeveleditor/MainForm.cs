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
    public partial class MainForm : Form
    {
        private int childFormNumber = 1;

        private InfoForm infoForm;
        private PaletteForm paletteForm;
        private PropertiesForm propertiesForm;
        private HistoryForm historyForm;
        private LayersForm layersForm;
        private ToolboxForm toolboxForm;

        public MainForm()
        {
            InitializeComponent();

            InitializePlugins();

            this.MdiChildActivate += new EventHandler(MainForm_MdiChildActivate);

            // Show the info form
            infoForm = new InfoForm();
            infoForm.Location = Properties.Settings.Default.infoFormPos;
            infoForm.onClose += new EventHandler(infoForm_onClose);
            infoForm.onViewChanged += new ViewportEventHandler(infoForm_onViewChanged);
            infoForm.Show();
            infoWindowToolStripMenuItem.Checked = true;
            infoForm.Owner = this;

            // Show the palette form
            paletteForm = new PaletteForm();
            paletteForm.Location = Properties.Settings.Default.paletteFormPos;
            paletteForm.onClose += new EventHandler(paletteForm_onClose);
            paletteForm.Show();
            paletteToolStripMenuItem.Checked = true;
            paletteForm.Owner = this;

            // Show properties
            propertiesForm = new PropertiesForm();
            propertiesForm.Location = Properties.Settings.Default.propertiesFormPos;
            propertiesForm.onClose += new EventHandler(propertiesForm_onClose);
            propertiesForm.Show();
            propertiesToolStripMenuItem.Checked = true;
            propertiesForm.Owner = this;

            // Show the history form
            historyForm = new HistoryForm();
            historyForm.Location = Properties.Settings.Default.historyFormPos;
            historyForm.onClose += new EventHandler(historyForm_onClose);
            historyForm.Show();
            historyToolStripMenuItem.Checked = true;
            historyForm.Owner = this;

            // Show the layers form
            layersForm = new LayersForm();
            layersForm.Location = Properties.Settings.Default.layersFormPos;
            layersForm.onClose += new EventHandler(layersForm_onClose);
            layersForm.onNewLayer += new EventHandler(layersForm_onNewLayer);
            layersForm.onLayerChanged += new LayerChangedEventHandler(layersForm_onLayerChanged);
            layersForm.onLayerRemoved += new LayerChangedEventHandler(layersForm_onLayerRemoved);
            layersForm.Show();
            layersToolStripMenuItem.Checked = true;
            layersForm.Owner = this;

            // Show the toolbox form
            toolboxForm = new ToolboxForm();
            toolboxForm.Location = Properties.Settings.Default.toolboxFormPos;
            toolboxForm.Show();
            toolboxForm.Owner = this;
        }

        void layersForm_onLayerRemoved(object sender, LayerChangedEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                MapForm m = (MapForm)this.ActiveMdiChild;
                m.RemoveLayer(e.LayerIndex);
            }
        }

        void layersForm_onLayerChanged(object sender, LayerChangedEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                MapForm m = (MapForm)this.ActiveMdiChild;
                m.ActiveLayer = e.LayerIndex;
            }
        }

        void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                MapForm m = (MapForm)this.ActiveMdiChild;
                infoForm.MapOpen(m, m.Viewport);
                layersForm.LoadLayers(m.MapData);
                propertiesForm.LoadData(m.MapData);
            }
        }

        void layersForm_onNewLayer(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                MapForm m = (MapForm)this.ActiveMdiChild;
                m.AddLayer();
            }
        }

        void layersForm_onClose(object sender, EventArgs e)
        {
            layersToolStripMenuItem.Checked = false;
        }

        void historyForm_onClose(object sender, EventArgs e)
        {
            historyToolStripMenuItem.Checked = false;
        }

        void propertiesForm_onClose(object sender, EventArgs e)
        {
            propertiesToolStripMenuItem.Checked = false;
        }

        void paletteForm_onClose(object sender, EventArgs e)
        {
            paletteToolStripMenuItem.Checked = false;
        }

        void infoForm_onClose(object sender, EventArgs e)
        {
            infoWindowToolStripMenuItem.Checked = false;
        }

        public string ActivePaletteImage()
        {
            string file = this.paletteForm.ActivePath + "\\" + this.paletteForm.ActiveImage;
            if (File.Exists(file))
            {
                return file;
            }

            return "";
        }

        public void AddHistory(string str)
        {
            historyForm.Add(str);
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // Show the new map form
            NewMapForm newMapForm = new NewMapForm(childFormNumber++);
            newMapForm.Text = "New map";

            // Create a new instance of the child form.
            if (newMapForm.ShowDialog() == DialogResult.OK)
            {
                MapForm child = new MapForm();
                child.MdiParent = this;
                child.Text = newMapForm.MapName;
                child.MapData.Name = newMapForm.MapName;
                child.mapMouseMove += new MouseEventHandler(infoForm.MapMouseMove);
                child.mapMouseLeave += new EventHandler(infoForm.MapMouseLeave);
                child.mapViewportChange += new ViewportEventHandler(infoForm.MapViewportChange);
                child.mapMouseClick += new MouseEventHandler(toolboxForm.ExecuteClick);
                child.mapMouseMove += new MouseEventHandler(toolboxForm.ExecuteMove);
                child.onOpen += new ViewportEventHandler(infoForm.MapOpen);
                child.onFocus += new ViewportEventHandler(infoForm.MapOpen);
                child.onClose += new EventHandler(infoForm.MapClose);
                child.SetMapSize(newMapForm.MapWidth, newMapForm.MapHeight);
                child.Show();
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = FileTranslatorManager.BuildFileFilter();
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                // TODO: Add code here to open the file.
                if (FileName != "")
                {
                    MapForm child = new MapForm();
                    child.MdiParent = this;
                    child.mapMouseMove += new MouseEventHandler(infoForm.MapMouseMove);
                    child.mapMouseLeave += new EventHandler(infoForm.MapMouseLeave);
                    child.mapViewportChange += new ViewportEventHandler(infoForm.MapViewportChange);
                    child.mapMouseClick += new MouseEventHandler(toolboxForm.ExecuteClick);
                    child.mapMouseMove += new MouseEventHandler(toolboxForm.ExecuteMove);
                    child.onOpen += new ViewportEventHandler(infoForm.MapOpen);
                    child.onFocus += new ViewportEventHandler(infoForm.MapOpen);
                    child.onClose += new EventHandler(infoForm.MapClose);
    
                    FileTranslatorManager.Import(FileName, child.MapData, false);

                    child.Text = FileName.Substring(FileName.LastIndexOf("\\") + 1);
                    child.SetMapSize(Convert.ToInt32(child.MapData.Width), Convert.ToInt32(child.MapData.Height));
                    child.Show();
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.Filter = FileTranslatorManager.BuildFileFilter();
            saveFileDialog.FileName = this.ActiveMdiChild.Text;
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                // TODO: Add code here to save the current contents of the form to a file.
                if (FileName != "")
                {
                    MapForm m = (MapForm)this.ActiveMdiChild;
                    m.Text = FileName.Substring(FileName.LastIndexOf("\\")+1);
                    FileTranslatorManager.Export(FileName, m.MapData, false);
                    FileInfo info = new FileInfo(FileName);
                    string newDir = info.DirectoryName + "\\" + m.MapData.Name + "_files";
                    Directory.CreateDirectory(newDir);
                    foreach (MapAPI.MapLayer layer in m.MapData.layers)
                    {
                        foreach (MapAPI.MapEntity entity in layer.entites)
                        {
                            string newFile = newDir + "\\" + entity.Filename.Substring(entity.Filename.LastIndexOf("\\") + 1);
                            try
                            {
                                File.Copy(entity.Filename, newFile);
                            }
                            catch (Exception ex)
                            {
                                
                            }
                            entity.Filename = newFile;
                        }
                    }
                }
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simple leveleditor", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void infoWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (infoForm.Visible)
            {
                infoForm.Hide();
            }
            else
            {
                infoForm.Show();
            }
        }

        private void paletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paletteForm.Visible)
            {
                paletteForm.Hide();
            }
            else
            {
                paletteForm.Show();
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (propertiesForm.Visible)
            {
                propertiesForm.Hide();
            }
            else
            {
                propertiesForm.Show();
            }
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyForm.Visible)
            {
                historyForm.Hide();
            }
            else
            {
                historyForm.Show();
            }
        }

        private void layersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (layersForm.Visible)
            {
                layersForm.Hide();
            }
            else
            {
                layersForm.Show();
            }
        }

        private void infoForm_onViewChanged(object sender, ViewportEventArgs e)
        {
            ActiveMdiChild.AutoScrollPosition = e.Rectangle.Location;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (MapForm f in this.MdiChildren)
            {
                if (f.Saved == false)
                {
                    string str = "Save changes to the map \"" + f.Text + "\" before closing?";
                    
                    DialogResult res = MessageBox.Show(str, this.Text, MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes)
                    {
                        if (f.Format == "")
                        {
                            this.SaveAsToolStripMenuItem_Click(f, new EventArgs());
                        }
                        else
                        {
                            FileTranslatorManager.Export(f.MapData.Name, f.MapData, false);
                        }
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            // Allow the forms to close now
            foreach (Form f in this.OwnedForms)
            {
                f.Owner = null;
            }

            this.Dispose();
        }

        private void InitializePlugins()
        {
            if (Directory.Exists("plugins"))
            {
                string[] fileEntries = Directory.GetFiles("plugins", "*.dll");
                foreach (string fileName in fileEntries)
                {
                    PluginManager.LoadPlugin(fileName);
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapForm m = (MapForm)this.ActiveMdiChild;
            m.Undo();
            this.historyForm.Remove();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapForm m = (MapForm)this.ActiveMdiChild;
            string str = m.Redo();
            this.historyForm.Add(str);
        }
    }
}
