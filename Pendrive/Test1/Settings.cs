using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    public class Settings
    {
        private String bgcolour;
        private String textcolour;
        private String font;
        private String fontsize;

        public Settings(String bg, String txt, String font, String size)
        {
            bgcolour = bg;
            textcolour = txt;
            this.font = font;
            fontsize = size;
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
