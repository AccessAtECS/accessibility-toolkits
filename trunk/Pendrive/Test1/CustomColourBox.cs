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
        static bool text = false;

        public CustomColourBox()
        {
            InitializeComponent();
        }

        public static Color show(Color current, Color fg, Color bg, Font font)
        {
            customColorBox = new CustomColourBox();
            customColorBox.Font = font;
            customColorBox.btnOk.BackColor = bg;
            customColorBox.btnOk.ForeColor = fg;
            customColorBox.btnMore.BackColor = bg;
            customColorBox.btnMore.ForeColor = fg;
            if (current.Equals(fg))
                text = true;
            if (current.Equals(bg))
                text = false;
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
            //toReturn = Color.White;
            toReturn = checkClash(Color.White);
            this.Dispose();
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            toReturn = checkClash(Color.Black);
            this.Dispose();
        }

        private void btnCream_Click(object sender, EventArgs e)
        {
            toReturn = checkClash(Color.Cornsilk);
            this.Dispose();
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            toReturn = checkClash(Color.Yellow);
            this.Dispose();
        }

        private void btnNavy_Click(object sender, EventArgs e)
        {
            toReturn = checkClash(Color.Navy);
            this.Dispose();
        }

        private void btnPaleBlue_Click(object sender, EventArgs e)
        {
            toReturn = checkClash(Color.AliceBlue);
            this.Dispose();
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            toReturn = checkClash(Color.MistyRose);
            this.Dispose();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                toReturn = checkClash(colorDialog1.Color);
            }
            this.Dispose();
        }

        public Color checkClash(Color newColor)
        {
            if (text)
            {
                if (newColor.Equals(customColorBox.btnOk.BackColor))
                {
                    CustomBox.Show("You have attempted to change the colour so that the background would be the same as the text. \nThis has been cancelled to avoid problems.", "Warning!", this.Font, customColorBox.btnOk.BackColor, customColorBox.btnOk.ForeColor);
                    return toReturn;
                }
                else return newColor;
            }
            else
            {
                if (newColor.Equals(customColorBox.btnOk.ForeColor))
                {
                    CustomBox.Show("You have attempted to change the colour so that the background would be the same as the text. \nThis has been cancelled to avoid problems.", "Warning!", this.Font, customColorBox.btnOk.BackColor, customColorBox.btnOk.ForeColor);
                    return toReturn;
                }
                else return newColor;
            }
        }

    }
}
