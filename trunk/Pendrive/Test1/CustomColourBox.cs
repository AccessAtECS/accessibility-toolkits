using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test1
{
    public partial class CustomColourBox : Form
    {
        static CustomColourBox customColorBox;
        static Color toReturn;

        public CustomColourBox()
        {
            InitializeComponent();
        }

        public static Color show(Color current, Color fg, Color bg, Font font)
        {
            customColorBox = new CustomColourBox();
            customColorBox.Font = font;
            //customColorBox.BackColor = bg;
            //customColorBox.ForeColor = fg;
            customColorBox.btnOk.BackColor = bg;
            customColorBox.btnOk.ForeColor = fg;
            customColorBox.btnMore.BackColor = bg;
            customColorBox.btnMore.ForeColor = fg;
            toReturn = current;
            customColorBox.ShowDialog();
            return toReturn;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            toReturn = Color.White;
            this.Dispose();
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            toReturn = Color.Black;
            this.Dispose();
        }

        private void btnCream_Click(object sender, EventArgs e)
        {
            toReturn = Color.Cornsilk;
            this.Dispose();
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            toReturn = Color.Yellow;
            this.Dispose();
        }

        private void btnNavy_Click(object sender, EventArgs e)
        {
            toReturn = Color.Navy;
            this.Dispose();
        }

        private void btnPaleBlue_Click(object sender, EventArgs e)
        {
            toReturn = Color.AliceBlue;
            this.Dispose();
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            toReturn = Color.MistyRose;
            this.Dispose();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                toReturn = colorDialog1.Color;
            }
            this.Dispose();
        }

    }
}
