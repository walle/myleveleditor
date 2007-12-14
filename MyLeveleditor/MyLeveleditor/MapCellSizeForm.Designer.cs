namespace MyLeveleditor
{
    partial class MapCellSizeForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cellSizelabel = new System.Windows.Forms.Label();
            this.cellsizeTrackBar = new System.Windows.Forms.TrackBar();
            this.cellsizeValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cellsizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(218, 43);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(218, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cellSizelabel
            // 
            this.cellSizelabel.AutoSize = true;
            this.cellSizelabel.Location = new System.Drawing.Point(22, 18);
            this.cellSizelabel.Name = "cellSizelabel";
            this.cellSizelabel.Size = new System.Drawing.Size(45, 13);
            this.cellSizelabel.TabIndex = 7;
            this.cellSizelabel.Text = "Cellsize:";
            // 
            // cellsizeTrackBar
            // 
            this.cellsizeTrackBar.Location = new System.Drawing.Point(2, 45);
            this.cellsizeTrackBar.Maximum = 256;
            this.cellsizeTrackBar.Minimum = 2;
            this.cellsizeTrackBar.Name = "cellsizeTrackBar";
            this.cellsizeTrackBar.Size = new System.Drawing.Size(188, 45);
            this.cellsizeTrackBar.TabIndex = 8;
            this.cellsizeTrackBar.TickFrequency = 10;
            this.cellsizeTrackBar.Value = 32;
            this.cellsizeTrackBar.Scroll += new System.EventHandler(this.cellsizeTrackBar_Scroll);
            // 
            // cellsizeValueLabel
            // 
            this.cellsizeValueLabel.AutoSize = true;
            this.cellsizeValueLabel.Location = new System.Drawing.Point(73, 18);
            this.cellsizeValueLabel.Name = "cellsizeValueLabel";
            this.cellsizeValueLabel.Size = new System.Drawing.Size(19, 13);
            this.cellsizeValueLabel.TabIndex = 9;
            this.cellsizeValueLabel.Text = "32";
            // 
            // MapCellSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 94);
            this.Controls.Add(this.cellsizeValueLabel);
            this.Controls.Add(this.cellsizeTrackBar);
            this.Controls.Add(this.cellSizelabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MapCellSizeForm";
            this.ShowInTaskbar = false;
            this.Text = "MapCellSizeForm";
            ((System.ComponentModel.ISupportInitialize)(this.cellsizeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label cellSizelabel;
        private System.Windows.Forms.TrackBar cellsizeTrackBar;
        private System.Windows.Forms.Label cellsizeValueLabel;
    }
}