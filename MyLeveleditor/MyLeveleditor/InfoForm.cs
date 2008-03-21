using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;

namespace MyLeveleditor
{
    partial class InfoForm : Form
    {
        Surface surface;
        Surface mapSurface;
        Box mapViewport;
        double scaleFactor = 0;

        bool initialized = false;

        public event EventHandler onClose;
        public event ViewportEventHandler onViewChanged;

        public InfoForm()
        {
            InitializeComponent();

            surface = new Surface(surfaceControl.Width, surfaceControl.Height);
            surface.Fill(this.BackColor);
            surfaceControl.Blit(surface);

            this.surfaceControl.MouseMove += new MouseEventHandler(surfaceControl_MouseMove);
            this.surfaceControl.MouseClick += new MouseEventHandler(surfaceControl_MouseMove);
            this.surfaceControl.MouseEnter += new EventHandler(surfaceControl_MouseEnter);
            this.surfaceControl.MouseLeave += new EventHandler(surfaceControl_MouseLeave);
        }

        void surfaceControl_MouseEnter(object sender, EventArgs e)
        {
            if (initialized)
            {
                this.Cursor = Cursors.Hand;
            }
        }

        void surfaceControl_MouseLeave(object sender, EventArgs e)
        {
            if (initialized)
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        void surfaceControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (initialized)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (mapViewport.Width + 1 < surface.Width || mapViewport.Height + 1 < surface.Height)
                    {
                        if (onViewChanged != null)
                        {
                            // Copy the data so we can check the bounds
                            Point pos = e.Location;
                            // Check bounds
                            if (pos.X < 0) { pos.X = 0; }
                            if (pos.Y < 0) { pos.Y = 0; }
                            if (pos.X + mapViewport.Width > panel.Width) { pos.X = panel.Width - mapViewport.Width - 1; }
                            if (pos.Y + mapViewport.Height > panel.Height) { pos.Y = panel.Height - mapViewport.Height - 1; }

                            // Set the location of the red box
                            mapViewport.Location = pos;

                            // Draw the box
                            surface = mapSurface.CreateScaledSurface(scaleFactor, true);
                            surface.Draw(mapViewport, Color.Red);
                            this.surfaceControl.Blit(surface);

                            if (onViewChanged != null)
                            {
                                // Invoke the event
                                ViewportEventArgs ea = new ViewportEventArgs(new Rectangle(Convert.ToInt32(e.X / scaleFactor), Convert.ToInt32(e.Y / scaleFactor), Convert.ToInt32(mapViewport.Width / scaleFactor), Convert.ToInt32(mapViewport.Height / scaleFactor)));
                                onViewChanged.Invoke(this, ea);
                            }
                        }
                    }
                }
            }
        }

        public void MapMouseMove(object sender, MouseEventArgs e)
        {
            this.xValueLabel.Text = e.X.ToString();
            this.yValueLabel.Text = e.Y.ToString();
        }

        public void MapMouseLeave(object sender, EventArgs e)
        {
            this.xValueLabel.Text = "-";
            this.yValueLabel.Text = "-";
        }

        public void MapViewportChange(object sender, ViewportEventArgs e)
        {
            ViewportChanged(e.Rectangle, e.Surface);
        }

        public void MapOpen(object sender, ViewportEventArgs e)
        {
            Initialize(e.Surface.Rectangle, e.Rectangle, e.Surface);
        }

        public void MapClose(object sender, EventArgs e)
        {
            initialized = false;
            mapSurface.Fill(SystemColors.Control);
            surface.Fill(SystemColors.Control);
            surfaceControl.Blit(surface);
        }

        public void Initialize(Rectangle mapRectangle, Rectangle showRectangle, Surface map)
        {
            double xScaleFactor = Convert.ToDouble(panel.Width) / Convert.ToDouble(mapRectangle.Width);
            double yScaleFactor = Convert.ToDouble(panel.Height) / Convert.ToDouble(mapRectangle.Height);

            if (xScaleFactor < yScaleFactor) { scaleFactor = xScaleFactor; }
            else { scaleFactor = yScaleFactor; }

            short mapX = (short)(mapRectangle.X * scaleFactor);
            short mapY = (short)(mapRectangle.Y * scaleFactor);
            short mapW = (short)(mapRectangle.Width * scaleFactor);
            short mapH = (short)(mapRectangle.Height * scaleFactor);

            short x = (short)(showRectangle.X * scaleFactor);
            short y = (short)(showRectangle.Y * scaleFactor);
            short w = (short)(showRectangle.Width * scaleFactor);
            short h = (short)(showRectangle.Height * scaleFactor);

            if (mapW > surfaceControl.Width) { mapW = (short)panel.Width; }
            if (mapH > surfaceControl.Height) { mapH = (short)panel.Height; }

            mapViewport = new Box(new Point(x, y), new Point(x + w - 1, y + h - 1));

            mapSurface = map;

            surface = new Surface(mapW, mapH);
            surface = map.CreateScaledSurface(scaleFactor, true);
            surface.Draw(mapViewport, Color.Red);
            Point pos = new Point((panel.Width / 2) - (mapW / 2), (panel.Height / 2) - (mapH / 2));
            surfaceControl.Width = mapW;
            surfaceControl.Height = mapH;
            surfaceControl.Location = pos;
            this.surfaceControl.Blit(surface);

            this.initialized = true;
        }

        public void ViewportChanged(Rectangle newViewport, Surface map)
        {
            if (initialized)
            {
                short x = (short)(newViewport.X * scaleFactor);
                short y = (short)(newViewport.Y * scaleFactor);
                short w = (short)(newViewport.Width * scaleFactor);
                short h = (short)(newViewport.Height * scaleFactor);

                if (w > surfaceControl.Width) { w = (short)surface.Width; }
                if (h > surfaceControl.Height) { h = (short)surface.Height; }

                mapViewport = new Box(new Point(x, y), new Point(x + w - 1, y + h - 1));

                mapSurface = map;

                if (map != null) { surface = map.CreateScaledSurface(scaleFactor, true); }
                surface.Draw(mapViewport, Color.Red);
                this.surfaceControl.Blit(surface);
            }
        }

        private void InfoForm_FormClosing(object sender, FormClosingEventArgs e)
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