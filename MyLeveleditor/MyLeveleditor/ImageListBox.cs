using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyLeveleditor
{
    public class ImageListBox : ListBox
    {
        Brush selectedColor;
        Size imageSize;
        StringFormat aligment;

        public ImageListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = 42;
            selectedColor = Brushes.CornflowerBlue;
            imageSize = new Size(32, 32);
            aligment = new StringFormat();
            aligment.Alignment = StringAlignment.Near;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (this.Items.Count > 0)
            {
                ImageListBoxItem item = (ImageListBoxItem)this.Items[e.Index];
                item.DrawItem(e, this.Font, selectedColor, aligment, imageSize);
            }      
        }

        #region // Properties

        public Brush SelectedColor
        {
            get { return this.selectedColor; }
            set { this.selectedColor = value; }
        }

        public Size ImageSize
        {
            get { return this.imageSize; }
            set { this.imageSize = value; this.ItemHeight = value.Height + 10; }
        }

        #endregion
    }

    #region // ImageListBoxItem code

    class ImageListBoxItem
    {
        private string text;
        private Image image;

        public ImageListBoxItem()
        {
            text = "";
            image = null;
        }

        public ImageListBoxItem(string name, Image image)
        {
            this.text = name;
            this.image = image;
        }

        public void DrawItem(DrawItemEventArgs e, Font font, Brush selectedColor, StringFormat aligment, Size imageSize)
        {
            // Show the selcted state
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(selectedColor, e.Bounds);
                //e.Graphics.DrawRectangle(Pens.Black, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            // Draw the image
            e.Graphics.DrawImage(this.image, e.Bounds.X + 10, e.Bounds.Y + 5, imageSize.Width, imageSize.Height);

            // Calculate a rectangle to display the name in
            Rectangle titleBounds = new Rectangle(e.Bounds.X + 10 + imageSize.Width + 10, e.Bounds.Y + 5, e.Bounds.Width - (e.Bounds.X + 10 + imageSize.Width + 10), e.Bounds.Height);

            // Draw the name
            e.Graphics.DrawString(this.text, font, Brushes.Black, titleBounds, aligment);

            e.DrawFocusRectangle();
        }

        #region // Properties

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public Image Image
        {
            get { return this.image; }
            set { this.image = value; }
        }

        #endregion
    }

    #endregion
}
