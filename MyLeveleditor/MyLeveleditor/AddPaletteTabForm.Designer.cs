namespace MyLeveleditor
{
    partial class AddPaletteTabForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPaletteTabForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileTextbox = new System.Windows.Forms.TextBox();
            this.folderBrowseButton = new System.Windows.Forms.Button();
            this.folderRadioButton = new System.Windows.Forms.RadioButton();
            this.imageRadioButton = new System.Windows.Forms.RadioButton();
            this.folderPanel = new System.Windows.Forms.Panel();
            this.folderDescriptionLabel = new System.Windows.Forms.Label();
            this.folderDescription = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.imageDescriptionLabel = new System.Windows.Forms.Label();
            this.imageDescription = new System.Windows.Forms.TextBox();
            this.imageLabel = new System.Windows.Forms.Label();
            this.imageTextbox = new System.Windows.Forms.TextBox();
            this.imageSizeTextbox = new System.Windows.Forms.TextBox();
            this.imageBrowseButton = new System.Windows.Forms.Button();
            this.tileLabel = new System.Windows.Forms.Label();
            this.folderPanel.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.imagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(531, 86);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(531, 116);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(15, 126);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(328, 20);
            this.pathTextBox.TabIndex = 2;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(15, 110);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(82, 13);
            this.pathLabel.TabIndex = 3;
            this.pathLabel.Text = "Directory to add";
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(15, 150);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(60, 13);
            this.fileLabel.TabIndex = 5;
            this.fileLabel.Text = "File formats";
            // 
            // fileTextbox
            // 
            this.fileTextbox.Location = new System.Drawing.Point(15, 166);
            this.fileTextbox.Name = "fileTextbox";
            this.fileTextbox.Size = new System.Drawing.Size(328, 20);
            this.fileTextbox.TabIndex = 4;
            // 
            // folderBrowseButton
            // 
            this.folderBrowseButton.Location = new System.Drawing.Point(365, 125);
            this.folderBrowseButton.Name = "folderBrowseButton";
            this.folderBrowseButton.Size = new System.Drawing.Size(65, 20);
            this.folderBrowseButton.TabIndex = 6;
            this.folderBrowseButton.Text = "Browse";
            this.folderBrowseButton.UseVisualStyleBackColor = true;
            this.folderBrowseButton.Click += new System.EventHandler(this.folderBrowseButton_Click);
            // 
            // folderRadioButton
            // 
            this.folderRadioButton.AutoSize = true;
            this.folderRadioButton.Checked = true;
            this.folderRadioButton.Location = new System.Drawing.Point(21, 23);
            this.folderRadioButton.Name = "folderRadioButton";
            this.folderRadioButton.Size = new System.Drawing.Size(54, 17);
            this.folderRadioButton.TabIndex = 7;
            this.folderRadioButton.TabStop = true;
            this.folderRadioButton.Text = "Folder";
            this.folderRadioButton.UseVisualStyleBackColor = true;
            this.folderRadioButton.CheckedChanged += new System.EventHandler(this.folderRadioButton_CheckedChanged);
            // 
            // imageRadioButton
            // 
            this.imageRadioButton.AutoSize = true;
            this.imageRadioButton.Location = new System.Drawing.Point(81, 23);
            this.imageRadioButton.Name = "imageRadioButton";
            this.imageRadioButton.Size = new System.Drawing.Size(54, 17);
            this.imageRadioButton.TabIndex = 8;
            this.imageRadioButton.Text = "Image";
            this.imageRadioButton.UseVisualStyleBackColor = true;
            this.imageRadioButton.CheckedChanged += new System.EventHandler(this.imageRadioButton_CheckedChanged);
            // 
            // folderPanel
            // 
            this.folderPanel.Controls.Add(this.folderDescriptionLabel);
            this.folderPanel.Controls.Add(this.folderDescription);
            this.folderPanel.Controls.Add(this.pathLabel);
            this.folderPanel.Controls.Add(this.pathTextBox);
            this.folderPanel.Controls.Add(this.fileTextbox);
            this.folderPanel.Controls.Add(this.folderBrowseButton);
            this.folderPanel.Controls.Add(this.fileLabel);
            this.folderPanel.Location = new System.Drawing.Point(12, 0);
            this.folderPanel.Name = "folderPanel";
            this.folderPanel.Size = new System.Drawing.Size(470, 230);
            this.folderPanel.TabIndex = 9;
            // 
            // folderDescriptionLabel
            // 
            this.folderDescriptionLabel.AutoSize = true;
            this.folderDescriptionLabel.Location = new System.Drawing.Point(15, 13);
            this.folderDescriptionLabel.Name = "folderDescriptionLabel";
            this.folderDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.folderDescriptionLabel.TabIndex = 14;
            this.folderDescriptionLabel.Text = "Description ";
            // 
            // folderDescription
            // 
            this.folderDescription.BackColor = System.Drawing.SystemColors.Control;
            this.folderDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.folderDescription.Location = new System.Drawing.Point(15, 35);
            this.folderDescription.Multiline = true;
            this.folderDescription.Name = "folderDescription";
            this.folderDescription.ReadOnly = true;
            this.folderDescription.Size = new System.Drawing.Size(325, 75);
            this.folderDescription.TabIndex = 13;
            this.folderDescription.Text = resources.GetString("folderDescription.Text");
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.folderRadioButton);
            this.groupBox.Controls.Add(this.imageRadioButton);
            this.groupBox.Location = new System.Drawing.Point(496, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(149, 55);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Type";
            // 
            // imagePanel
            // 
            this.imagePanel.Controls.Add(this.imageDescriptionLabel);
            this.imagePanel.Controls.Add(this.imageDescription);
            this.imagePanel.Controls.Add(this.imageLabel);
            this.imagePanel.Controls.Add(this.imageTextbox);
            this.imagePanel.Controls.Add(this.imageSizeTextbox);
            this.imagePanel.Controls.Add(this.imageBrowseButton);
            this.imagePanel.Controls.Add(this.tileLabel);
            this.imagePanel.Location = new System.Drawing.Point(12, 0);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(470, 230);
            this.imagePanel.TabIndex = 11;
            this.imagePanel.Visible = false;
            // 
            // imageDescriptionLabel
            // 
            this.imageDescriptionLabel.AutoSize = true;
            this.imageDescriptionLabel.Location = new System.Drawing.Point(15, 13);
            this.imageDescriptionLabel.Name = "imageDescriptionLabel";
            this.imageDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.imageDescriptionLabel.TabIndex = 12;
            this.imageDescriptionLabel.Text = "Description ";
            // 
            // imageDescription
            // 
            this.imageDescription.BackColor = System.Drawing.SystemColors.Control;
            this.imageDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imageDescription.Location = new System.Drawing.Point(15, 35);
            this.imageDescription.Multiline = true;
            this.imageDescription.Name = "imageDescription";
            this.imageDescription.ReadOnly = true;
            this.imageDescription.Size = new System.Drawing.Size(325, 53);
            this.imageDescription.TabIndex = 12;
            this.imageDescription.Text = resources.GetString("imageDescription.Text");
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Location = new System.Drawing.Point(15, 110);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(69, 13);
            this.imageLabel.TabIndex = 8;
            this.imageLabel.Text = "Image to add";
            // 
            // imageTextbox
            // 
            this.imageTextbox.Location = new System.Drawing.Point(15, 126);
            this.imageTextbox.Name = "imageTextbox";
            this.imageTextbox.Size = new System.Drawing.Size(328, 20);
            this.imageTextbox.TabIndex = 7;
            // 
            // imageSizeTextbox
            // 
            this.imageSizeTextbox.Location = new System.Drawing.Point(15, 166);
            this.imageSizeTextbox.Name = "imageSizeTextbox";
            this.imageSizeTextbox.Size = new System.Drawing.Size(328, 20);
            this.imageSizeTextbox.TabIndex = 9;
            // 
            // imageBrowseButton
            // 
            this.imageBrowseButton.Location = new System.Drawing.Point(365, 125);
            this.imageBrowseButton.Name = "imageBrowseButton";
            this.imageBrowseButton.Size = new System.Drawing.Size(65, 20);
            this.imageBrowseButton.TabIndex = 11;
            this.imageBrowseButton.Text = "Browse";
            this.imageBrowseButton.UseVisualStyleBackColor = true;
            this.imageBrowseButton.Click += new System.EventHandler(this.imageBrowseButton_Click);
            // 
            // tileLabel
            // 
            this.tileLabel.AutoSize = true;
            this.tileLabel.Location = new System.Drawing.Point(15, 150);
            this.tileLabel.Name = "tileLabel";
            this.tileLabel.Size = new System.Drawing.Size(45, 13);
            this.tileLabel.TabIndex = 10;
            this.tileLabel.Text = "Tile size";
            // 
            // AddPaletteTabForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(660, 210);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.folderPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPaletteTabForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPaletteTabForm";
            this.folderPanel.ResumeLayout(false);
            this.folderPanel.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.imagePanel.ResumeLayout(false);
            this.imagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileTextbox;
        private System.Windows.Forms.Button folderBrowseButton;
        private System.Windows.Forms.RadioButton folderRadioButton;
        private System.Windows.Forms.RadioButton imageRadioButton;
        private System.Windows.Forms.Panel folderPanel;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.TextBox imageTextbox;
        private System.Windows.Forms.TextBox imageSizeTextbox;
        private System.Windows.Forms.Button imageBrowseButton;
        private System.Windows.Forms.Label tileLabel;
        private System.Windows.Forms.TextBox imageDescription;
        private System.Windows.Forms.Label imageDescriptionLabel;
        private System.Windows.Forms.Label folderDescriptionLabel;
        private System.Windows.Forms.TextBox folderDescription;
    }
}