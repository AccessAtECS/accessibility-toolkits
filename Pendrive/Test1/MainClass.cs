using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Test1
{
    class MainClass : System.Windows.Forms.Form
    {
        static void Main()
        {
            //Menu appMenu = new Menu();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*String[] menuTags = new String[4];
            menuTags[0] = "name";
            menuTags[1] = "path";
            menuTags[2] = "category";
            menuTags[3] = "extra";
            try
            {
                appMenu.populateMenu(x.readXmlFile("menu.xml", menuTags));
                if (updater.update(x.getOldCount(), appMenu) == true)
                {
                    appMenu.getCategories().Clear();
                    appMenu.getTable().Clear();
                    appMenu.populateMenu(x.readXmlFile("menu.xml", menuTags));
                }
            }
            catch (FileNotFoundException e)
            {
                CustomBox.Show("Could not create menu - menu.xml not found! \nTry restarting the menu to resolve this problem.", "Error!", DefaultFont, System.Drawing.Color.White, System.Drawing.Color.Black);
                updater.createMenuFile();
            }*/
            String[] settingsTags = new String[4];
            settingsTags[0] = "bgcolour";
            settingsTags[1] = "textcolour";
            settingsTags[2] = "font";
            settingsTags[3] = "fontsize";
            Settings s;
            try
            {
                XMLparser x = new XMLparser();
                s = new Settings(x.readXmlFile("settings.xml", settingsTags));
            }
            catch (FileNotFoundException e)
            {
                CustomBox.Show("There was a problem restoring your settings. The default settings will be used, and a new settings file will be created.", "Error!", DefaultFont, System.Drawing.Color.White, System.Drawing.Color.Black);
                MenuUpdater updater = new MenuUpdater();
                updater.createSettingsFile();
                XMLparser x = new XMLparser();
                s = new Settings(x.readXmlFile("settings.xml", settingsTags));
            }
           
            Application.Run(new MenuForm(s));            
        }
    }
}
