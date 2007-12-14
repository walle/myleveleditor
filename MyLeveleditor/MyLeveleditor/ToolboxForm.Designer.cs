namespace MyLeveleditor
{
    partial class ToolboxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolboxForm));
            this.penButton = new System.Windows.Forms.Button();
            this.handButton = new System.Windows.Forms.Button();
            this.eraserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // penButton
            // 
            this.penButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.penButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.penButton.ForeColor = System.Drawing.SystemColors.Control;
            this.penButton.Image = ((System.Drawing.Image)(resources.GetObject("penButton.Image")));
            this.penButton.Location = new System.Drawing.Point(2, 2);
            this.penButton.Name = "penButton";
            this.penButton.Size = new System.Drawing.Size(25, 25);
            this.penButton.TabIndex = 0;
            this.penButton.TabStop = false;
            this.penButton.UseVisualStyleBackColor = false;
            this.penButton.Click += new System.EventHandler(this.penButton_Click);
            // 
            // handButton
            // 
            this.handButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.handButton.ForeColor = System.Drawing.SystemColors.Control;
            this.handButton.Location = new System.Drawing.Point(28, 2);
            this.handButton.Name = "handButton";
            this.handButton.Size = new System.Drawing.Size(25, 25);
            this.handButton.TabIndex = 1;
            this.handButton.TabStop = false;
            this.handButton.Text = "h";
            this.handButton.UseVisualStyleBackColor = true;
            this.handButton.Click += new System.EventHandler(this.handButton_Click);
            // 
            // eraserButton
            // 
            this.eraserButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eraserButton.ForeColor = System.Drawing.SystemColors.Control;
            this.eraserButton.Location = new System.Drawing.Point(2, 29);
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(25, 25);
            this.eraserButton.TabIndex = 2;
            this.eraserButton.TabStop = false;
            this.eraserButton.Text = "e";
            this.eraserButton.UseVisualStyleBackColor = true;
            this.eraserButton.Click += new System.EventHandler(this.eraserButton_Click);
            // 
            // ToolboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(54, 196);
            this.Controls.Add(this.eraserButton);
            this.Controls.Add(this.handButton);
            this.Controls.Add(this.penButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolboxForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button penButton;
        private System.Windows.Forms.Button handButton;
        private System.Windows.Forms.Button eraserButton;


    }
}