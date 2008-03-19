using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MapAPI;

namespace MyLeveleditor
{
    partial class ToolboxForm : Form
    {
        private ToolboxTool tool = null;

        public ToolboxForm()
        {
            InitializeComponent();
            this.Tool = new ToolboxToolPen();
        }

        private void penButton_Click(object sender, EventArgs e)
        {
            this.tool = new ToolboxToolPen();
            penButton.BackColor = SystemColors.ButtonHighlight;

            handButton.BackColor = SystemColors.Control;
            eraserButton.BackColor = SystemColors.Control;
        }

        private void handButton_Click(object sender, EventArgs e)
        {
            this.tool = new ToolboxToolHand();
            handButton.BackColor = SystemColors.ButtonHighlight;

            penButton.BackColor = SystemColors.Control;
            eraserButton.BackColor = SystemColors.Control;
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {
            this.tool = new ToolboxToolEraser();
            eraserButton.BackColor = SystemColors.ButtonHighlight;

            penButton.BackColor = SystemColors.Control;
            handButton.BackColor = SystemColors.Control;
        }

        public void ExecuteClick(object sender, MouseEventArgs e)
        {
            MainForm mainForm = (MainForm)this.Owner;
            this.tool.Execute(mainForm, e);
        }

        public void ExecuteMove(object sender, MouseEventArgs e)
        {
            if (this.tool.Name == "Hand")
            {
                MainForm mainForm = (MainForm)this.Owner;
                this.tool.Execute(mainForm, e);
            }
        }

        public ToolboxTool Tool
        {
            get { return this.tool; }
            set { this.tool = value; }
        }
    }
}