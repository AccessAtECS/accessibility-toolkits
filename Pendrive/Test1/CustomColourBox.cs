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
            if (text) //if it is the text colour that is being changed
            {
                if (newColor.Equals(customColorBox.btnOk.BackColor))
                {
                    CustomBox.Show("You have attempted to change the colour so that the background would be the same as the text. \nThis has been cancelled to avoid problems.", "Warning!", this.Font, customColorBox.btnOk.BackColor, customColorBox.btnOk.ForeColor);
                    return toReturn;
                }
                else
                {
                    if (checkRatio(customColorBox.btnOk.BackColor, newColor) == true)
                        return newColor;
                    else
                    {
                        CustomBox.Show("Changing to this colour would give a poor luminosity ratio and would therefore be difficult to read. \nThis has been cancelled to avoid problems.", "Warning!", this.Font, customColorBox.btnOk.BackColor, customColorBox.btnOk.ForeColor);
                        return toReturn;
                    }
                }
            }
            else
            {
                if (newColor.Equals(customColorBox.btnOk.ForeColor))
                {
                    CustomBox.Show("You have attempted to change the colour so that the background would be the same as the text. \nThis has been cancelled to avoid problems.", "Warning!", this.Font, customColorBox.btnOk.BackColor, customColorBox.btnOk.ForeColor);
                    return toReturn;
                }
                {
                    if (checkRatio(newColor, customColorBox.btnOk.ForeColor) == true)
                        return newColor;
                    else
                    {
                        CustomBox.Show("Changing to this colour would give a poor luminosity ratio and would therefore be difficult to read. \nThis has been cancelled to avoid problems.", "Warning!", this.Font, customColorBox.btnOk.BackColor, customColorBox.btnOk.ForeColor);
                        return toReturn;
                    }
                }
            }
        }

        public bool checkRatio(Color back, Color fore)
        {
            decimal backR = Decimal.Divide(back.R, 255);
            decimal backG = Decimal.Divide(back.G, 255);
            decimal backB = Decimal.Divide(back.B, 255);
            backR = relLuminance(backR);
            backG = relLuminance(backG);
            backB = relLuminance(backB);

            decimal backVal = (((decimal)0.2126 * backR) + ((decimal)0.7152 * backG) + ((decimal)0.0722 * backB));
            
            decimal foreR = Decimal.Divide(fore.R, 255);
            decimal foreG = Decimal.Divide(fore.G, 255);
            decimal foreB = Decimal.Divide(fore.B, 255);
            foreR = relLuminance(foreR);
            foreG = relLuminance(foreG);
            foreB = relLuminance(foreB);

            decimal foreVal = (((decimal)0.2126 * foreR) + ((decimal)0.7152 * foreG) + ((decimal)0.0722 * foreB));

            decimal result;
            if (foreVal > backVal)
                result = ((foreVal + (decimal)0.05) / (backVal + (decimal)0.05));
            else result = ((backVal + (decimal)0.05) / (foreVal + (decimal)0.05));

            if (result >= (decimal)4.5)
                return true;
            else return false;

        }

        public decimal relLuminance(decimal num)
        {
            decimal num2;
            if (num <= (decimal)0.03928)
            {
                num2 = (num / (decimal)12.92);
            }
            else num2 = (decimal)(Math.Pow((double)((num + (decimal)0.055) / (decimal)1.055), 2.4));
            return num2;
        }
    }
}
