using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Test1
{
    public partial class WizardBox : Form
    {
        protected static WizardBox wizardBox;
        protected static string toReturn;

        public WizardBox()
        {
            InitializeComponent();
            toReturn = "";
        }

        public static string Show(String message, String title, Font font, Color bg, Color fg)
        {
            wizardBox = new WizardBox();
            //Set up logo
            try
            {
                Icon mainIcon = new Icon("Menu_Data\\logo.ico");
                wizardBox.Icon = mainIcon;
            }
            catch
            {
            }
            Rectangle maxSize = new Rectangle();
            /*
             *For horizontal bar messages
            maxSize.Height = Screen.PrimaryScreen.WorkingArea.Height / 4;
            maxSize.Width = Screen.PrimaryScreen.WorkingArea.Width;
            */
            maxSize.Height = Screen.PrimaryScreen.WorkingArea.Height;
            maxSize.Width = Screen.PrimaryScreen.WorkingArea.Width / 4;
            wizardBox.richTextBox1.Text = message;
            wizardBox.Text = title;
            wizardBox.richTextBox1.Font = font;
            wizardBox.BackColor = bg;
            wizardBox.ForeColor = fg;
            wizardBox.MaximumSize = maxSize.Size;
            wizardBox.richTextBox1.MaximumSize = maxSize.Size;
            wizardBox.Size = maxSize.Size;
            //wizardBox.MaximumSize = new Size(1024, 600);
            //wizardBox.richTextBox1.MaximumSize = new Size(1024, 600);
            
            wizardBox.ShowDialog();
            return toReturn;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            wizardBox.Dispose();
        }

        private void wizardBox_Load(object sender, EventArgs e)
        {
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toReturn = wizardBox.richTextBox1.Text;
        }

        private void wizardBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus && e.Control)
            {
                wizardBox.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height);
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            wizardBox_KeyDown(sender, e);
        }

        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
            wizardBox_KeyDown(sender, e);
        }
    }
}
