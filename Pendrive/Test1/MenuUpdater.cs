using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Test1
{
    public class MenuUpdater
    {
        Menu appMenu;
        int oldCount;
        Char[] lastSlash;

        public MenuUpdater()
        {
            
        }
        
        /**
         * Takes in the old count of how many apps there were, and compares this with the number of directories local to the menu
         * If there are now more, then the menu is updated to include these new folders.
         * Methods are called to attempt to locate the true path of an app, rather than just its folder, as well as attempting 
         * to determine the application's category.
         * Returns a bool, telling the XMLparser whether or not it needs to re-parse the menu.xml file.
         */ 
        public bool update(int oldCount, Menu appMenu)
        {
            this.appMenu = appMenu;
            this.oldCount = oldCount;
            int count = 0;
            String[] directories = Directory.GetDirectories(Directory.GetCurrentDirectory()); 
            foreach (string subdirectory in directories)
            {
                if (Directory.Exists(subdirectory))
                {
                    count++;
                }
            }
            if (count > oldCount)
            {
                //then a new app has been downloaded - set up xml entry and add to xml file under "Downloaded category"
                XmlDocument menuDoc = new XmlDocument();
                menuDoc.Load("menu.xml");
                XmlNodeList list = menuDoc.GetElementsByTagName("menu");
                list[0].Attributes[0].Value = count.ToString(); //updates count
                String slash = "\\";
                lastSlash = slash.ToCharArray();
                foreach (string subdirectory in directories)
                {
                    if (!appMenu.getTable().ContainsKey(subdirectory.Substring(subdirectory.LastIndexOfAny(lastSlash) + 1)))
                    {
                        //found new app
                        XmlElement newNode = menuDoc.CreateElement("app");
                        XmlElement newName = menuDoc.CreateElement("name");
                        newName.InnerText = subdirectory.Substring(subdirectory.LastIndexOfAny(lastSlash)+1);
                        XmlElement newPath = menuDoc.CreateElement("path");
                        string path = findPath(subdirectory);
                        newPath.InnerText = path;
                        XmlElement newCategory = menuDoc.CreateElement("category");
                        newCategory.InnerText = checkCategory(path);
                        newNode.AppendChild(newName);
                        newNode.AppendChild(newPath);
                        newNode.AppendChild(newCategory);
                        list[0].AppendChild(newNode);                              
                    }
                }
                try
                {
                    menuDoc.Save("menu.xml");
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.ToString());
                    return false;
                }
            }
            return false;
        }

        /**
         * Takes in a path to a directory and attempts to locate the actual path wanted.
         * If there is only one file, and no other folder in the directory, then that file can be set as the path.
         * Otherwise, find the .exe files and check if there is one with the same name as the application.
         * If neither of these, return the path to the directory so that the menu opens that folder.
         */ 
        public string findPath(string subdirectory)
        {
            String[] files = Directory.GetFiles(subdirectory);
            String[] directories = Directory.GetDirectories(subdirectory);
            if (files.Length == 1 && directories.Length == 0) //if only one file in directory then set this as the path
                return files[0].Substring(2);
            foreach (string file in files)
            {
                if (file.EndsWith(".exe"))
                {
                    String filename = file.Substring(file.LastIndexOfAny(lastSlash) + 1);
                    String pathname = subdirectory.Substring(subdirectory.LastIndexOfAny(lastSlash) + 1) + ".exe";
                    if (filename.Equals(pathname) || filename.Equals(pathname.ToLower()))
                        return file.Substring(2);
                }
            }
            return subdirectory.Substring(2);
        }

        /**
         * Takes in a path and attempts to determine the category of the application.
         * If it is a .doc file, then it is a guide.
         * If it is a .exe file, it could either be an application, or an accessibility tool.
         * Categorises folders.
         */ 
        public string checkCategory(string directory)
        {
            if (File.Exists(directory)) //if a path to the actual file/exe was found, rather than the folder
            {
                if (directory.EndsWith(".doc"))
                    return ("Guides");
                if (directory.EndsWith(".exe"))
                    return ("Applications"); //could be an application e.g. firefox, or an accessibility tool e.g. a screenreader, need to distinguish   
            }
            else if (Directory.Exists(directory))
                    return ("Folders");
            return ("Downloads");
        }

        /**
         * Removes the given application from the xml file, so that it is not displayed in the menu again.
         * Updates the count in the xml file so that the menu can update correctly.
         */ 
        public void remove(string app)
        {
            XmlDocument menuDoc = new XmlDocument();
            menuDoc.Load("menu.xml");
            XmlNodeList list = menuDoc.GetElementsByTagName("app"); //gets all apps
            foreach (XmlElement application in list)
            {
                if (application.FirstChild.InnerText.Equals(app))
                {
                    application.ParentNode.RemoveChild(application);
                    list = menuDoc.GetElementsByTagName("menu");
                    list[0].Attributes[0].Value = ((int.Parse(list[0].Attributes[0].Value) - 1).ToString()); //updates count
                    break;
                }
            }
            menuDoc.Save("menu.xml");
        }

        /**
         * Saves the users settings in an xml file so that they can be restored when the user next loads the menu.
         */ 
        public void saveSettings(String bgcolour, String txtcolour, String font, String fontsize)
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
