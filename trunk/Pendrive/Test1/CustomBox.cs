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

            Rectangle maxSize = new Rectangle();
            maxSize.Height = 150;
            maxSize.Width = 360;
            customBox.richTextBox1.Text = message;
            customBox.Text = title;
            customBox.richTextBox1.Font = font;
            customBox.BackColor = bg;
            customBox.ForeColor = fg;
            customBox.MaximumSize = maxSize.Size;
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
    }
}
