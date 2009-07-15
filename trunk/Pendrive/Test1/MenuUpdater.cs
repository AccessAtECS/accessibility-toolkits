﻿using System;
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
        Char[] anyOf;

        public MenuUpdater()
        {
            
        }

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
                    Console.WriteLine("Found directory: " + subdirectory);
                }
            }
            Console.WriteLine("Found " + count + " directories");
            if (count > oldCount)
            {
                //then a new app has been downloaded - set up xml entry and add to xml file under "Downloaded category"
                Console.WriteLine("MENU OUT OF DATE - ATTEMPTING TO UPDATE");
                XmlDocument menuDoc = new XmlDocument();
                menuDoc.Load("menu.xml");
                XmlNodeList list = menuDoc.GetElementsByTagName("menu");
                list[0].Attributes[0].Value = count.ToString(); //updates count

                String slash = "\\";
                anyOf = slash.ToCharArray();
                foreach (string subdirectory in directories)
                {
                    Console.WriteLine("substring: " + subdirectory.Substring(3));

                    if (!appMenu.getTable().ContainsKey(subdirectory.Substring(subdirectory.LastIndexOfAny(anyOf) + 1)))
                    {
                        //found new app
                        Console.WriteLine("FOUND APP TO ADD: " + subdirectory);      
                        Console.WriteLine("Got Here 1");
                        XmlElement newNode = menuDoc.CreateElement("app");
                        Console.WriteLine("Got Here 2");
                        XmlElement newName = menuDoc.CreateElement("name");
                        //newName.InnerText = subdirectory.Substring(3);
                        newName.InnerText = subdirectory.Substring(subdirectory.LastIndexOfAny(anyOf)+1);
                        Console.WriteLine("Got Here 3");
                        XmlElement newPath = menuDoc.CreateElement("path");
                        string path = findPath(subdirectory);
                        newPath.InnerText = path;
                        Console.WriteLine("Got Here 4");
                        XmlElement newCategory = menuDoc.CreateElement("category");
                        newCategory.InnerText = checkCategory(path);
                        newNode.AppendChild(newName);
                        newNode.AppendChild(newPath);
                        newNode.AppendChild(newCategory);
                        list[0].AppendChild(newNode);
                        Console.WriteLine("Got Here 5");                
                                                                  
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

        public string findPath(string subdirectory)
        {
            String[] files = Directory.GetFiles(subdirectory);
            String[] directories = Directory.GetDirectories(subdirectory);
            if (files.Length == 1 && directories.Length == 0) //if only one file in directory then set this as the path
                return files[0];
            foreach (string file in files)
            {
                if (file.EndsWith(".exe"))
                {
                    String filename = file.Substring(file.LastIndexOfAny(anyOf) + 1);
                    String pathname = subdirectory.Substring(subdirectory.LastIndexOfAny(anyOf) + 1) + ".exe";
                    if (filename.Equals(pathname) || filename.Equals(pathname.ToLower()))
                        return file;
                }
            }
            return subdirectory;
        }

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

        public void remove(string app)
        {
            XmlDocument menuDoc = new XmlDocument();
            menuDoc.Load("menu.xml");
            XmlNodeList list = menuDoc.GetElementsByTagName("menu");
            list[0].Attributes[0].Value = ((int.Parse(list[0].Attributes[0].Value) - 1).ToString()); //updates count

            list = menuDoc.GetElementsByTagName("app"); //gets all apps
            foreach (XmlElement application in list)
            {
                if (application.FirstChild.InnerText.Equals(app))
                {
                    application.ParentNode.RemoveChild(application);
                    break;
                }
            }
            menuDoc.Save("menu.xml");
        }

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
