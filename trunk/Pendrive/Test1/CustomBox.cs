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
    public partial class CustomBox : Form
    {
        static CustomBox customBox;

        public CustomBox()
        {
            InitializeComponent();
        }

        public static void Show(String message, String title, Font font, Color bg, Color fg)
        {
            customBox = new CustomBox();

            //Set up logo
            Bitmap bmpLogo = new Bitmap("Menu_Data\\logo.png");
            Icon mainIcon = Icon.FromHandle(bmpLogo.GetHicon());
            customBox.Icon = mainIcon;

            if (title.Equals("Access Tools - About"))
            {
                customBox.pictureBox1.Visible = true;
                customBox.pictureBox1.Height = 45;
            }

            Rectangle maxSize = new Rectangle();
            maxSize.Height = 600;
            maxSize.Width = 800;
            customBox.richTextBox1.Text = message;
            customBox.Text = title;
            customBox.richTextBox1.Font = font;
            customBox.BackColor = bg;
            customBox.ForeColor = fg;
            customBox.MaximumSize = maxSize.Size;
            maxSize.Height = maxSize.Height - customBox.pictureBox1.Height;
            customBox.richTextBox1.MaximumSize = maxSize.Size;
            customBox.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            customBox.Dispose();
        }

        private void CustomBox_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
