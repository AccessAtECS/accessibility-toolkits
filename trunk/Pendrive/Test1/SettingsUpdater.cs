using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    public class SettingsUpdater
    {
        public SettingsUpdater(String bgcolour, String txtcolour, String font, String fontsize)
        {
            XmlDocument settingsDoc = new XmlDocument();
            settingsDoc.Load("settings.xml");
            XmlNodeList settings = settingsDoc.GetElementsByTagName("bgcolour");
            settings[0].InnerText = bgcolour;
            settings = settingsDoc.GetElementsByTagName("textcolour");
            settings[0].InnerText = txtcolour;
            settings = settingsDoc.GetElementsByTagName("font");
            settings[0].InnerText = font;
            settings = settingsDoc.GetElementsByTagName("fontsize");
            settings[0].InnerText = fontsize;
            settingsDoc.Save("settings.xml");            
        }        
    }
}
