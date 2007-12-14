using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;

namespace MyLeveleditor
{
    class ViewportEventArgs : EventArgs
    {
        Rectangle rect;
        Surface surf;

        public ViewportEventArgs()
        {
            rect = new Rectangle();
            surf = new Surface(0, 0);
        }

        public ViewportEventArgs(Rectangle r)
        {
            rect = r;
            surf = new Surface(0, 0);
        }

        public ViewportEventArgs(Surface s)
        {
            rect = new Rectangle();
            surf = s;
        }

        public ViewportEventArgs(Rectangle r, Surface s)
        {
            rect = r;
            surf = s;
        }

        #region //Properties

        public Rectangle Rectangle
        {
            get { return rect; }
        }

        public Surface Surface
        {
            get { return surf; }
        }

        #endregion
    }
}
