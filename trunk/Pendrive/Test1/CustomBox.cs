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
            customBox.lblMessage.Text = message;
            customBox.Text = title;
            customBox.Font = font;
            customBox.BackColor = bg;
            customBox.ForeColor = fg;
            customBox.btnOk.BackColor = bg;
            customBox.btnOk.ForeColor = fg;
            
            customBox.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            customBox.Dispose();
        }
    }
}
