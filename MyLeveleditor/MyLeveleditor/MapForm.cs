using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using SdlDotNet.Graphics;
using SdlDotNet.Input;
using SdlDotNet.Graphics.Primitives;

using MapAPI;

namespace MyLeveleditor
{
    public delegate void ViewportEventHandler(object sender, ViewportEventArgs e);

    public partial class MapForm : Form
    {
        Surface mapSurface;
        Surface wholeSurface;
        Surface clearImg;

        private MapData mapData;
        private int activeLayer = 0;
        private int entity_id = 1;

        private bool showGrid = true;
        private int gridSize = 32;
        private Color gridColor = Color.Black;

        private bool saved = true;
        private DateTime lastSave = DateTime.Now;
        private string format = "";
        private string filename = "";

        private UndoRedoHistory urManager;

        public event MouseEventHandler mapMouseClick;
        public event MouseEventHandler mapMouseMove;
        public event EventHandler mapMouseLeave;
        public event ViewportEventHandler mapViewportChange;
        public event ViewportEventHandler onOpen;
        public event ViewportEventHandler onFocus;
        public event EventHandler onClose;

        public MapForm()
        {
            InitializeComponent();

            mapData = new MapData();
            mapData.layers.Add(new MapLayer());

            try
            {
                clearImg = new Surface("clear.bmp");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            mapSurface = new Surface(surfacePanel.Width, surfacePanel.Height);
            wholeSurface = new Surface(surfacePanel.Width, surfacePanel.Height);

            showGridToolStripMenuItem.Checked = true;

            urManager = new UndoRedoHistory(this);

            Clear();
        }

        public void SetMapSize(int x, int y)
        {
            surfacePanel.Width = x;
            surfacePanel.Height = y;
            surfacePanel.Location = new Point(0, 0);

            mapSurface = new Surface(x, y);
            wholeSurface = new Surface(x, y);

            this.mapData.Width = x.ToString();
            this.mapData.Height = y.ToString();

            //Clear();
            Draw();
            CenterMap();

            InvokeViewChange();
        }

        protected override void OnResize(EventArgs e)
        {
            CenterMap();

            InvokeViewChange();

            base.OnResize(e);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            InvokeViewChange();

            base.OnScroll(se);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (onFocus != null)
            {
                InvokeViewChange();
            }

            base.OnGotFocus(e);
        }

        public void Draw()
        {
            Clear();

            foreach (MapLayer l in mapData.layers)
            {
                foreach (MapEntity e in l.entites)
                {
                    Surface s = new Surface(e.Filename);
                    mapSurface.Blit(s, e.Location);
                }
            }

            wholeSurface.Blit(mapSurface);
            
            if (showGrid)
            {
                DrawGrid();
            }

            surfaceControl.Blit(wholeSurface);
            
            InvokeViewChange();
        }

        public void Open(string filename)
        {
            
        }

        public void OpenXml(string filename)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                XmlNode name = doc.GetElementsByTagName("name")[0];
                XmlNode version = doc.GetElementsByTagName("version")[0];
                XmlNode author = doc.GetElementsByTagName("author")[0];
                XmlNode backgroundImage = doc.GetElementsByTagName("backgroundImage")[0];
                XmlNode backgroundMusic = doc.GetElementsByTagName("backgroundMusic")[0];
                XmlNode width = doc.GetElementsByTagName("width")[0];
                XmlNode height = doc.GetElementsByTagName("height")[0];

                mapData.Name = name.InnerText;
                mapData.Version = version.InnerText;
                mapData.Author = author.InnerText;
                mapData.BackgroundImage = backgroundImage.InnerText;
                mapData.BackgroundMusic = backgroundMusic.InnerText;
                mapData.Width = width.InnerText;
                mapData.Height = height.InnerText;

                XmlNodeList layers = doc.GetElementsByTagName("layer");

                foreach (XmlNode layer in layers)
                {
                    XmlNodeList entities = layer.ChildNodes;

                    mapData.layers.Add(new MapLayer());

                    foreach (XmlNode entity in entities)
                    {
                        MapEntity en = new MapEntity();
                        en.Id = Convert.ToInt32(entity["id"].InnerText);
                        en.Filename = entity["filename"].InnerText;
                        en.Location = new Point(Convert.ToInt32(entity["location"]["x"].InnerText), Convert.ToInt32(entity["location"]["y"].InnerText));
                        en.Size = new Size(Convert.ToInt32(entity["size"]["width"].InnerText), Convert.ToInt32(entity["size"]["height"].InnerText));
                        en.Script = entity["script"].InnerText;

                        mapData[activeLayer].entites.Add(en);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            this.Draw();
        }

        public void Save()
        {

        }

        public void Save(string filename)
        {
            
        }

        public void SaveXml(string filename)
        {
            StreamWriter swrite = new StreamWriter(filename);
            swrite.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            swrite.WriteLine("<map>");
            swrite.WriteLine("<name>" + mapData.Name + "</name>");
            swrite.WriteLine("<version>" + mapData.Version + "</version>");
            swrite.WriteLine("<author>" + mapData.Author + "</author>");
            swrite.WriteLine("<backgroundImage>" + mapData.BackgroundImage + "</backgroundImage>");
            swrite.WriteLine("<backgroundMusic>" + mapData.BackgroundMusic + "</backgroundMusic>");

            foreach (MapLayer l in mapData.layers)
            {
                swrite.WriteLine("<layer>");
                foreach (MapEntity e in l.entites)
                {
                    swrite.WriteLine("<entity>");
                    swrite.WriteLine("<id>" + e.Id + "</id>");
                    swrite.WriteLine("<filename>" + e.Filename + "</filename>");
                    swrite.WriteLine("<location><x>" + e.Location.X + "</x><y>" + e.Location.Y + "</y></location>");
                    swrite.WriteLine("<size><width>" + e.Size.Width + "</width><height>" + e.Size.Height + "</height></size>");
                    swrite.WriteLine("<script>" + e.Script + "</script>");
                    swrite.WriteLine("</entity>");
                }
                swrite.WriteLine("</layer>");
            }
            swrite.WriteLine("</map>");
            swrite.Flush();

            if (filename.Contains("\\"))
            {
                this.Text = filename.Substring((filename.LastIndexOf("\\")+1));
            }

            this.lastSave = DateTime.Now;
            this.saved = true;
            this.format = "xml";
            this.filename = filename;
        }

        protected void OnRedraw(EventArgs e)
        {
            
        }

        public string Undo()
        {
            return urManager.Undo();
        }

        public string Redo()
        {
            return urManager.Redo();
        }

        public void AddEntity(MapEntity entity)
        {
            if (this.showGrid)
            {
                int x = entity.Location.X / this.gridSize;
                int y = entity.Location.Y / this.gridSize;
                entity.Location = new Point(x * gridSize, y * gridSize);
            }
            entity.Id = entity_id++;
            mapData[activeLayer].entites.Add(entity);
            Draw();
            this.saved = false;
            urManager.Do(new EntityAddedAction(activeLayer, entity));
            MainForm m = (MainForm)this.MdiParent;
            m.AddHistory("Add");
            /*Surface s = new Surface("Tiles/" + entity.Filename);
            mapSurface.Blit(s, entity.Location);
            wholeSurface.Blit(s, entity.Location);
            surfaceControl.Blit(wholeSurface);
            InvokeViewChange();*/
        }

        public void AddEntity(int layer, MapEntity entity)
        {
            if (this.showGrid)
            {
                int x = entity.Location.X / this.gridSize;
                int y = entity.Location.Y / this.gridSize;
                entity.Location = new Point(x * gridSize, y * gridSize);
            }
            entity.Id = entity_id++;
            mapData[layer].entites.Add(entity);
            Draw();
            this.saved = false;
            urManager.Do(new EntityAddedAction(layer, entity));
            MainForm m = (MainForm)this.MdiParent;
            m.AddHistory("Add");
            /*Surface s = new Surface("Tiles/" + entity.Filename);
            mapSurface.Blit(s, entity.Location);
            wholeSurface.Blit(s, entity.Location);
            surfaceControl.Blit(wholeSurface);
            InvokeViewChange();*/
        }

        public void RemoveEntity(MapEntity entity)
        {
            mapData[activeLayer].entites.Remove(entity);
            Draw();
            this.saved = false;
            urManager.Do(new EntityRemovedAction(activeLayer, entity));
            MainForm m = (MainForm)this.MdiParent;
            m.AddHistory("Remove");
            /*
            int clearWidth = clearImg.Width;
            int clearHeight = clearImg.Height;

            // How many rows and columns we have to clear 
            int hor = entity.Size.Width / clearWidth;
            int ver = entity.Size.Height / clearHeight;

            for (int i = 0; i <= hor; i++)
            {
                for (int j = 0; j <= ver; j++)
                {
                    mapSurface.Blit(clearImg, new Point(i * clearWidth, j * clearHeight));
                }
            }

            wholeSurface.Blit(clearImg, entity.Location);
            surfaceControl.Blit(wholeSurface);
            InvokeViewChange();*/
        }

        public void RemoveEntity(int layer, MapEntity entity)
        {
            mapData[layer].entites.Remove(entity);
            Draw();
            this.saved = false;
            urManager.Do(new EntityRemovedAction(layer, entity));
            MainForm m = (MainForm)this.MdiParent;
            m.AddHistory("Remove");
            /*
            int clearWidth = clearImg.Width;
            int clearHeight = clearImg.Height;

            // How many rows and columns we have to clear 
            int hor = entity.Size.Width / clearWidth;
            int ver = entity.Size.Height / clearHeight;

            for (int i = 0; i <= hor; i++)
            {
                for (int j = 0; j <= ver; j++)
                {
                    mapSurface.Blit(clearImg, new Point(i * clearWidth, j * clearHeight));
                }
            }

            wholeSurface.Blit(clearImg, entity.Location);
            surfaceControl.Blit(wholeSurface);
            InvokeViewChange();*/
        }

        public void RemoveEntity(Point location)
        {
            MapEntity entity = mapData[activeLayer].entites.Find(delegate(MapEntity e) { return (location.X > e.Location.X && location.X < e.Location.X + e.Size.Width && location.Y > e.Location.Y && location.Y < e.Location.Y + e.Size.Height); });

            if (entity != null)
            {
                this.RemoveEntity(entity);
            }
        }

        // May not keep this one
        public void RemoveEntity(int id)
        {
            mapData[activeLayer].entites.RemoveAll(delegate(MapEntity e) { return e.Id == id; });
        }

        public void AddLayer()
        {
            mapData.layers.Add(new MapLayer());
            this.activeLayer++;
        }

        private void Clear()
        {
            int clearWidth = clearImg.Width;
            int clearHeight = clearImg.Height;

            // How many rows and columns we have to clear 
            int hor = surfacePanel.Width / clearWidth;
            int ver = surfacePanel.Height / clearHeight;

            for (int i = 0; i <= hor; i++)
            {
                for (int j = 0; j <= ver; j++)
                {
                    mapSurface.Blit(clearImg, new Point((i * clearWidth), (j * clearHeight)));
                }
            }

            wholeSurface.Blit(mapSurface);
            surfaceControl.Blit(wholeSurface);
        }

        private void surfaceControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Focused && mapMouseMove != null)
            {
                mapMouseMove.Invoke(this.surfaceControl, e);
            }
        }

        private void surfaceControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Focused && mapMouseClick != null)
            {
                mapMouseClick.Invoke(this.surfaceControl, e);
            }
        }

        private void surfaceControl_MouseLeave(object sender, EventArgs e)
        {
            if (this.Focused && mapMouseLeave != null)
            {
                mapMouseLeave.Invoke(this.surfaceControl, e);
            }
        }

        private void setGridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapCellSizeForm dialog = new MapCellSizeForm(gridSize);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                gridSize = dialog.CellSize;
                Draw();
            }
        }

        private void CenterMap()
        {
            // Center the control
            if (surfacePanel.Width < this.Width)
            {
                surfacePanel.Left = this.Width / 2 - surfacePanel.Width / 2;
            }
            if (surfacePanel.Height < this.Height)
            {
                surfacePanel.Top = this.Height / 2 - surfacePanel.Height / 2;
            }
        }

        private void DrawGrid()
        {
            int hor = surfacePanel.Width / gridSize;
            int ver = surfacePanel.Height / gridSize;

            for (int i = 1; i <= hor; i++)
            {
                wholeSurface.Draw(new Line(new Point(i * gridSize, 0), new Point(i * gridSize, surfacePanel.Height)), gridColor, true, false);
            }
            for (int j = 1; j <= ver; j++)
            {
                wholeSurface.Draw(new Line(new Point(0, j * gridSize), new Point(surfacePanel.Width, j * gridSize)), gridColor, true, false);
            }
        }

        public void InvokeViewChange()
        {
            if (mapViewportChange != null)
            {
                ViewportEventArgs ea = new ViewportEventArgs(new Rectangle(-this.DisplayRectangle.X, -this.DisplayRectangle.Y, this.Width, this.Height), this.mapSurface);
                mapViewportChange.Invoke(this, ea);
            }
        }

        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showGrid = !showGrid;
            Draw();
        }

        private void setGridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = gridColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                gridColor = dialog.Color;
                Draw();
            }
        }

        private void MapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (onClose != null)
            {
                onClose.Invoke(this, new EventArgs());
            }
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            if (onOpen != null)
            {
                ViewportEventArgs ea = new ViewportEventArgs(this.mapSurface.Rectangle, this.mapSurface);
                onOpen.Invoke(this, ea);
            }
        }

        #region // Properties

        public Size MapSize
        {
            get { return surfacePanel.Size; }
            set { surfacePanel.Size = value; }
        }

        public int GridSize
        {
            get { return gridSize; }
            set { gridSize = value; }
        }

        public bool ShowGrid
        {
            get { return showGrid; }
            set { showGrid = value; }
        }

        public Color GridColor
        {
            get { return gridColor; }
            set { gridColor = value; }
        }

        public bool Saved
        {
            get { return this.saved; }
            set { this.saved = value; }
        }

        public string Format
        {
            get { return this.format; }
            set { this.format = value; }
        }

        public MapData MapData
        {
            get { return this.mapData; }
        }

        public ViewportEventArgs Viewport
        {
            get { return new ViewportEventArgs(new Rectangle(-this.DisplayRectangle.X, -this.DisplayRectangle.Y, this.Width, this.Height), this.mapSurface); }
        }

        #endregion
    }
}