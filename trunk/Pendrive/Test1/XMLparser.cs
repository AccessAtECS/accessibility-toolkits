using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Test1
{
    class XMLparser
    {
        XmlTextReader reader;
        Menu appMenu;
        Settings settings;
        MenuUpdater mu;

        public XMLparser(Menu appMenu, MenuUpdater updater)
        {
            this.appMenu = appMenu;
            this.mu = updater;
            reader = new XmlTextReader("menu.xml");
            try
            {
                if (readXmlFile())
                {
                    appMenu.getCategories().Clear();
                    appMenu.getTable().Clear();
                    reader = new XmlTextReader("menu.xml");
                    readXmlFile();
                }
                
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not create menu - menu.xml not found!");
            }

        }

        /*public void readXmlFile()
        {
            bool newApp = false;
            bool newPath = false;
            String appName = "";
            String appPath = "";
            String category = "";

            Console.WriteLine("Parsing xml file...");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name.Equals("category"))
                        {
                            reader.MoveToFirstAttribute();
                            Console.WriteLine("FOUND CATEGORY: " + reader.Name + "..." + reader.Value);
                            category = reader.Value;
                            appMenu.addCategory(category);
                        }
                        if (reader.Name.Equals("name"))
                        {
                            newApp = true;  //could change this to how settings file is read below
                        }
                        if (reader.Name.Equals("path"))
                            newPath = true;
                        break;
                    case XmlNodeType.Text:
                        if (newApp)
                        {
                            appName = reader.Value.ToString();
                            Console.WriteLine("App Object Name = " + appName);
                            newApp = false;
                        }
                        if (newPath)
                        {
                            appPath = reader.Value.ToString();
                            Console.WriteLine("App Object Path = " + appPath);
                            appMenu.addItem(new AppShortcut(appName, appPath, category));
                            appName = "";
                            appPath = "";
                            newPath = false;
                        }
                        break;
                }
            }
            appMenu.sortCategories();
            appMenu.displayMenuItems(); //only for console
        }
        */

        public bool readXmlFile()
        {
            int oldcount = 0;
            String current = "";
            String category = "";
            String tempAppName = "";
            String tempAppPath = "";
            Console.WriteLine("Parsing xml file...");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name.Equals("menu"))
                        {
                            reader.MoveToFirstAttribute();
                            Console.WriteLine("Found Menu: Apps = " + reader.Value);
                            oldcount = int.Parse(reader.Value);
                        }
                        /*if (reader.Name.Equals("category"))
                        {
                            reader.MoveToFirstAttribute();
                            Console.WriteLine("FOUND CATEGORY: " + reader.Name + "..." + reader.Value);
                            category = reader.Value;
                            appMenu.addCategory(category);
                        }*/
                        else
                        {
                            current = reader.Name;
                        }
                        break;
                    case XmlNodeType.Text:
                        {
                            if (current.Equals("name"))
                                tempAppName = reader.Value.ToString();
                            if (current.Equals("path"))
                            {
                                tempAppPath = reader.Value.ToString();
                                //appMenu.addItem(new AppShortcut(tempAppName, reader.Value.ToString(), category));
                                //count++;
                            }
                            if (current.Equals("category"))
                            {
                                category = reader.Value.ToString();
                                appMenu.addCategory(category);
                                appMenu.addItem(new AppShortcut(tempAppName, tempAppPath, category));
                            }
                        }
                        break;
                }
            }
            appMenu.sortCategories();
            reader.Close();
            //MenuUpdater mu = new MenuUpdater(oldcount, appMenu);
            if (mu.update(oldcount, appMenu) == true)
                return true;
            else return false;
            
        }

        public Settings readSettingsFile()
        {
            String bgcolour = "";
            String textcolour = "";
            String font = "";
            String fontsize = "";
            String current = "";

            try
            {
                reader = new XmlTextReader("settings.xml");
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                current = reader.Name;
                            }
                            break;
                        case XmlNodeType.Text:
                            {
                                
                                if (current.Equals("bgcolour"))
                                    bgcolour = reader.Value;
                                if (current.Equals("textcolour"))
                                    textcolour = reader.Value;
                                if (current.Equals("font"))
                                    font = reader.Value;
                                if (current.Equals("fontsize"))
                                    fontsize = reader.Value;
                            }
                            break;
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not locate settings file (settings.xml)");
            }
            
            Console.WriteLine("bgcolor: " + bgcolour + " textcolour: " + textcolour + " font: " + font + " fontsize: " + fontsize);
            settings = new Settings(bgcolour, textcolour, font, fontsize);
            reader.Close();
            return settings;
        }              
    }
}
