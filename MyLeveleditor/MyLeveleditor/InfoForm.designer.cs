namespace MyLeveleditor
{
    partial class InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.surfaceControl = new SdlDotNet.Windows.SurfaceControl();
            this.xPositionLabel = new System.Windows.Forms.Label();
            this.yPositionLabel = new System.Windows.Forms.Label();
            this.xValueLabel = new System.Windows.Forms.Label();
            this.yValueLabel = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.infoGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.surfaceControl)).BeginInit();
            this.panel.SuspendLayout();
            this.infoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // surfaceControl
            // 
            this.surfaceControl.AccessibleDescription = "";
            this.surfaceControl.AccessibleName = "SurfaceControl";
            this.surfaceControl.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.surfaceControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.surfaceControl.ErrorImage = null;
            this.surfaceControl.Image = ((System.Drawing.Image)(resources.GetObject("surfaceControl.Image")));
            this.surfaceControl.InitialImage = null;
            this.surfaceControl.Location = new System.Drawing.Point(0, 0);
            this.surfaceControl.Name = "surfaceControl";
            this.surfaceControl.Size = new System.Drawing.Size(181, 127);
            this.surfaceControl.TabIndex = 0;
            this.surfaceControl.TabStop = false;
            // 
            // xPositionLabel
            // 
            this.xPositionLabel.AutoSize = true;
            this.xPositionLabel.Location = new System.Drawing.Point(7, 13);
            this.xPositionLabel.Name = "xPositionLabel";
            this.xPositionLabel.Size = new System.Drawing.Size(14, 13);
            this.xPositionLabel.TabIndex = 1;
            this.xPositionLabel.Text = "X";
            // 
            // yPositionLabel
            // 
            this.yPositionLabel.AutoSize = true;
            this.yPositionLabel.Location = new System.Drawing.Point(7, 30);
            this.yPositionLabel.Name = "yPositionLabel";
            this.yPositionLabel.Size = new System.Drawing.Size(14, 13);
            this.yPositionLabel.TabIndex = 2;
            this.yPositionLabel.Text = "Y";
            // 
            // xValueLabel
            // 
            this.xValueLabel.AutoSize = true;
            this.xValueLabel.Location = new System.Drawing.Point(27, 13);
            this.xValueLabel.Name = "xValueLabel";
            this.xValueLabel.Size = new System.Drawing.Size(10, 13);
            this.xValueLabel.TabIndex = 3;
            this.xValueLabel.Text = "-";
            // 
            // yValueLabel
            // 
            this.yValueLabel.AutoSize = true;
            this.yValueLabel.Location = new System.Drawing.Point(27, 30);
            this.yValueLabel.Name = "yValueLabel";
            this.yValueLabel.Size = new System.Drawing.Size(10, 13);
            this.yValueLabel.TabIndex = 4;
            this.yValueLabel.Text = "-";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.surfaceControl);
            this.panel.Location = new System.Drawing.Point(5, 5);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(180, 135);
            this.panel.TabIndex = 5;
            // 
            // infoGroupBox
            // 
            this.infoGroupBox.Controls.Add(this.xPositionLabel);
            this.infoGroupBox.Controls.Add(this.yPositionLabel);
            this.infoGroupBox.Controls.Add(this.xValueLabel);
            this.infoGroupBox.Controls.Add(this.yValueLabel);
            this.infoGroupBox.Location = new System.Drawing.Point(12, 144);
            this.infoGroupBox.Name = "infoGroupBox";
            this.infoGroupBox.Size = new System.Drawing.Size(138, 45);
            this.infoGroupBox.TabIndex = 6;
            this.infoGroupBox.TabStop = false;
            this.infoGroupBox.Text = "Info";
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 195);
            this.Controls.Add(this.infoGroupBox);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.surfaceControl)).EndInit();
            this.panel.ResumeLayout(false);
            this.infoGroupBox.ResumeLayout(false);
            this.infoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SdlDotNet.Windows.SurfaceControl surfaceControl;
        private System.Windows.Forms.Label xPositionLabel;
        private System.Windows.Forms.Label yPositionLabel;
        private System.Windows.Forms.Label xValueLabel;
        private System.Windows.Forms.Label yValueLabel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox infoGroupBox;
    }
}