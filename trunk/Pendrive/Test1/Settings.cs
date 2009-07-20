using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Test1
{
    public class Settings
    {
        private String bgcolour;
        private String textcolour;
        private String font;
        private String fontsize;

        public Settings(Hashtable values)
        {
            foreach (int key in values.Keys)
            {
                String[] items = (String[])values[key];
                bgcolour = items[0];
                textcolour = items[1];
                font = items[2];
                fontsize = items[3];
            }
        }

        public String getBgColour()
        {
            return bgcolour;
        }

        public String getTxtColour()
        {
            return textcolour;
        }

        public String getFont()
        {
            return font;
        }

        public String getFontSize()
        {
            return fontsize;
        }
    }
}
