namespace MyLeveleditor
{
    partial class LayersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayersForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.NewLayer = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageListBox = new MyLeveleditor.ImageListBox();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewLayer,
            this.toolStripDropDownButton1});
            this.statusStrip.Location = new System.Drawing.Point(0, 192);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(192, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
            // 
            // NewLayer
            // 
            this.NewLayer.Image = ((System.Drawing.Image)(resources.GetObject("NewLayer.Image")));
            this.NewLayer.IsLink = true;
            this.NewLayer.Name = "NewLayer";
            this.NewLayer.Size = new System.Drawing.Size(16, 17);
            this.NewLayer.ToolTipText = "Insert a new layer";
            // 
            // imageListBox
            // 
            this.imageListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imageListBox.FormattingEnabled = true;
            this.imageListBox.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListBox.ItemHeight = 42;
            this.imageListBox.Location = new System.Drawing.Point(0, 0);
            this.imageListBox.Name = "imageListBox";
            this.imageListBox.Size = new System.Drawing.Size(192, 214);
            this.imageListBox.TabIndex = 0;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.IsLink = true;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(16, 17);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // LayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 214);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.imageListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayersForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Layers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LayersForm_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageListBox imageListBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel NewLayer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDropDownButton1;
    }
}