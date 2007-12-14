using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MapAPI
{
    public class MapEntity
    {
        private int id = 0;
        private Point location = new Point();
        private Size size = new Size();
        private string filename = "undefined";
        private string script = "undefined";

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public Point Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public Size Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public string Filename
        {
            get { return this.filename; }
            set { this.filename = value; }
        }

        public string Script
        {
            get { return this.script; }
            set { this.script = value; }
        }
    }
}
