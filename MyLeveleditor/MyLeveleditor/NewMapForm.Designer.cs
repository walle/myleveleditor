namespace MyLeveleditor
{
    partial class NewMapForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.presetSizesComboBox = new System.Windows.Forms.ComboBox();
            this.presetSizesLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.heightTextbox = new System.Windows.Forms.TextBox();
            this.widthLabel = new System.Windows.Forms.Label();
            this.widthTextbox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.AcceptsReturn = true;
            this.nameTextBox.AcceptsTab = true;
            this.nameTextBox.Location = new System.Drawing.Point(11, 22);
            this.nameTextBox.MaxLength = 255;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(199, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.WordWrap = false;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.presetSizesComboBox);
            this.groupBox.Controls.Add(this.presetSizesLabel);
            this.groupBox.Controls.Add(this.heightLabel);
            this.groupBox.Controls.Add(this.heightTextbox);
            this.groupBox.Controls.Add(this.widthLabel);
            this.groupBox.Controls.Add(this.widthTextbox);
            this.groupBox.Location = new System.Drawing.Point(10, 48);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(200, 100);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Map size";
            // 
            // presetSizesComboBox
            // 
            this.presetSizesComboBox.FormattingEnabled = true;
            this.presetSizesComboBox.Items.AddRange(new object[] {
            "300 x 150",
            "800 x 600",
            "1024 x 768",
            "1280 x 1024",
            "1600 x 1200",
            "1680 x 1050"});
            this.presetSizesComboBox.Location = new System.Drawing.Point(83, 18);
            this.presetSizesComboBox.MaxDropDownItems = 10;
            this.presetSizesComboBox.Name = "presetSizesComboBox";
            this.presetSizesComboBox.Size = new System.Drawing.Size(105, 21);
            this.presetSizesComboBox.TabIndex = 5;
            this.presetSizesComboBox.SelectedIndexChanged += new System.EventHandler(this.presetSizesComboBox_SelectedIndexChanged);
            // 
            // presetSizesLabel
            // 
            this.presetSizesLabel.AutoSize = true;
            this.presetSizesLabel.Location = new System.Drawing.Point(12, 22);
            this.presetSizesLabel.Name = "presetSizesLabel";
            this.presetSizesLabel.Size = new System.Drawing.Size(63, 13);
            this.presetSizesLabel.TabIndex = 4;
            this.presetSizesLabel.Text = "Preset sizes";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(10, 75);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 3;
            this.heightLabel.Text = "Height";
            // 
            // heightTextbox
            // 
            this.heightTextbox.AcceptsReturn = true;
            this.heightTextbox.AcceptsTab = true;
            this.heightTextbox.Location = new System.Drawing.Point(49, 72);
            this.heightTextbox.MaxLength = 255;
            this.heightTextbox.Name = "heightTextbox";
            this.heightTextbox.Size = new System.Drawing.Size(140, 20);
            this.heightTextbox.TabIndex = 2;
            this.heightTextbox.WordWrap = false;
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(8, 48);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 1;
            this.widthLabel.Text = "Width";
            // 
            // widthTextbox
            // 
            this.widthTextbox.AcceptsReturn = true;
            this.widthTextbox.AcceptsTab = true;
            this.widthTextbox.Location = new System.Drawing.Point(49, 45);
            this.widthTextbox.MaxLength = 255;
            this.widthTextbox.Name = "widthTextbox";
            this.widthTextbox.Size = new System.Drawing.Size(140, 20);
            this.widthTextbox.TabIndex = 0;
            this.widthTextbox.WordWrap = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(10, 6);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(227, 19);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(227, 50);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // NewMapForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(311, 152);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewMapForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewMapForm";
            this.Load += new System.EventHandler(this.NewMapForm_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox widthTextbox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.TextBox heightTextbox;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label presetSizesLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox presetSizesComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}