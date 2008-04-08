namespace MyLeveleditor
{
    partial class MapForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.surfaceControl = new SdlDotNet.Windows.SurfaceControl();
            this.mapContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setGridSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGridColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surfacePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.surfaceControl)).BeginInit();
            this.mapContextMenuStrip.SuspendLayout();
            this.surfacePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // surfaceControl
            // 
            this.surfaceControl.AccessibleDescription = "";
            this.surfaceControl.AccessibleName = "";
            this.surfaceControl.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.surfaceControl.BackColor = System.Drawing.SystemColors.Control;
            this.surfaceControl.ContextMenuStrip = this.mapContextMenuStrip;
            this.surfaceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surfaceControl.ErrorImage = null;
            this.surfaceControl.Image = ((System.Drawing.Image)(resources.GetObject("surfaceControl.Image")));
            this.surfaceControl.InitialImage = null;
            this.surfaceControl.Location = new System.Drawing.Point(0, 0);
            this.surfaceControl.Name = "surfaceControl";
            this.surfaceControl.Size = new System.Drawing.Size(209, 145);
            this.surfaceControl.TabIndex = 0;
            this.surfaceControl.TabStop = false;
            this.surfaceControl.MouseLeave += new System.EventHandler(this.surfaceControl_MouseLeave);
            this.surfaceControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.surfaceControl_MouseMove);
            this.surfaceControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.surfaceControl_MouseClick);
            // 
            // mapContextMenuStrip
            // 
            this.mapContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showGridToolStripMenuItem,
            this.toolStripSeparator1,
            this.setGridSizeToolStripMenuItem,
            this.setGridColorToolStripMenuItem});
            this.mapContextMenuStrip.Name = "mapContextMenuStrip";
            this.mapContextMenuStrip.Size = new System.Drawing.Size(152, 76);
            // 
            // showGridToolStripMenuItem
            // 
            this.showGridToolStripMenuItem.CheckOnClick = true;
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.showGridToolStripMenuItem.Text = "Show Grid";
            this.showGridToolStripMenuItem.Click += new System.EventHandler(this.showGridToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // setGridSizeToolStripMenuItem
            // 
            this.setGridSizeToolStripMenuItem.Name = "setGridSizeToolStripMenuItem";
            this.setGridSizeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.setGridSizeToolStripMenuItem.Text = "Set Cell Size";
            this.setGridSizeToolStripMenuItem.Click += new System.EventHandler(this.setGridSizeToolStripMenuItem_Click);
            // 
            // setGridColorToolStripMenuItem
            // 
            this.setGridColorToolStripMenuItem.Name = "setGridColorToolStripMenuItem";
            this.setGridColorToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.setGridColorToolStripMenuItem.Text = "Set Grid Color";
            this.setGridColorToolStripMenuItem.Click += new System.EventHandler(this.setGridColorToolStripMenuItem_Click);
            // 
            // surfacePanel
            // 
            this.surfacePanel.AutoScroll = true;
            this.surfacePanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.surfacePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.surfacePanel.Controls.Add(this.surfaceControl);
            this.surfacePanel.Location = new System.Drawing.Point(65, 45);
            this.surfacePanel.Name = "surfacePanel";
            this.surfacePanel.Size = new System.Drawing.Size(211, 147);
            this.surfacePanel.TabIndex = 1;
            // 
            // MapForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(372, 273);
            this.Controls.Add(this.surfacePanel);
            this.MinimumSize = new System.Drawing.Size(30, 80);
            this.Name = "MapForm";
            this.ShowInTaskbar = false;
            this.Text = "MapWindow";
            this.Load += new System.EventHandler(this.MapForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MapForm_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.surfaceControl)).EndInit();
            this.mapContextMenuStrip.ResumeLayout(false);
            this.surfacePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SdlDotNet.Windows.SurfaceControl surfaceControl;
        private System.Windows.Forms.Panel surfacePanel;
        private System.Windows.Forms.ContextMenuStrip mapContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGridSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGridColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

    }
}