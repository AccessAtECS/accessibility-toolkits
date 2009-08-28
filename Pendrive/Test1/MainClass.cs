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
            Menu appMenu = new Menu();
            MenuUpdater updater = new MenuUpdater();
            //XMLparser x = new XMLparser(appMenu, updater);
            XMLparser x = new XMLparser();
            String[] menuTags = new String[3];
            menuTags[0] = "name";
            menuTags[1] = "path";
            menuTags[2] = "category";
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
                System.Windows.Forms.MessageBox.Show("Could not create menu - menu.xml not found! \nTry restarting the menu to resolve this problem.", "Error!");
                updater.createMenuFile();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            String[] settingsTags = new String[4];
            settingsTags[0] = "bgcolour";
            settingsTags[1] = "textcolour";
            settingsTags[2] = "font";
            settingsTags[3] = "fontsize";
            Settings s = new Settings(x.readXmlFile("settings.xml", settingsTags));
            //Application.Run(new formMenu(s, appMenu, updater));
            Application.Run(new MenuForm(s, appMenu, updater));            
        }
    }
}
