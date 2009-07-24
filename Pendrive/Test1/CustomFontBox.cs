using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Collections;

namespace Test1
{
    public partial class CustomFontBox : Form
    {
        static CustomFontBox customFontBox;
        static Font toReturn;

        public CustomFontBox()
        {
            InitializeComponent();
        }

        public static Font show(Font font, Color bg, Color fg)
        {
            customFontBox = new CustomFontBox();
            customFontBox.Font = font;
            customFontBox.BackColor = bg;
            customFontBox.ForeColor = fg;
            customFontBox.comboBox1.BackColor = bg;
            customFontBox.comboBox1.ForeColor = fg;
            customFontBox.numericUpDown1.BackColor = bg;
            customFontBox.numericUpDown1.ForeColor = fg;
           
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            ArrayList fontList = new ArrayList();
            fontList.AddRange(installedFonts.Families);
            foreach (FontFamily f in fontList)
            {
                customFontBox.comboBox1.Items.Add(f.Name);
            }
            customFontBox.comboBox1.SelectedItem = font.FontFamily.ToString();
            customFontBox.numericUpDown1.Value = (decimal)float.Parse(font.Size.ToString());
            customFontBox.ShowDialog();
            return toReturn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customFontBox.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont = (Font)toFont.ConvertFromString(comboBox1.SelectedItem.ToString());
            toReturn = new Font(newFont.FontFamily, float.Parse((numericUpDown1.Value).ToString()), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            this.Font = toReturn;
            label1.Font = toReturn;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            String font = "Microsoft Sans Serif";
            if (comboBox1.SelectedItem != null)
            {
                font = comboBox1.SelectedItem.ToString();
            }
            Font newFont = (Font)toFont.ConvertFromString(font);
            toReturn = new Font(newFont.FontFamily, float.Parse((numericUpDown1.Value).ToString()), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            this.Font = toReturn;
            label1.Font = toReturn;
        }
    }
}
