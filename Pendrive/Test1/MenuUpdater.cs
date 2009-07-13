using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Test1
{
    class MenuUpdater
    {
        Menu appMenu;
        int oldCount;

        public MenuUpdater(int oldCount, Menu appMenu)
        {
            this.appMenu = appMenu;
            this.oldCount = oldCount;
        }

        public bool update()
        {
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

                bool cont = true;
                String slash = "\\";
                Char[] anyOf = slash.ToCharArray();
                foreach (string subdirectory in directories)
                {
                    Console.WriteLine("substring: " + subdirectory.Substring(3));
                    
                    if (appMenu.getTable().ContainsKey(subdirectory.Substring(3)))
                        ;//do nothing
                    else
                    {
                        //found new app
                        Console.WriteLine("FOUND APP TO ADD: " + subdirectory);
                        if (cont)
                        {
                            list = menuDoc.GetElementsByTagName("category");
                            foreach (XmlNode category in list)
                            {
                                if (category.Attributes[0].Value.Equals("Downloads"))
                                {
                                    Console.WriteLine("Got Here 1");
                                    XmlElement newNode = menuDoc.CreateElement("app");
                                    Console.WriteLine("Got Here 2");
                                    XmlElement newName = menuDoc.CreateElement("name");
                                    //newName.InnerText = subdirectory.Substring(3);
                                    newName.InnerText = subdirectory.Substring(subdirectory.LastIndexOfAny(anyOf)+1);
                                    Console.WriteLine("Got Here 3");
                                    XmlElement newPath = menuDoc.CreateElement("path");
                                    newPath.InnerText = findPath(subdirectory);
                                    Console.WriteLine("Got Here 4");
                                    newNode.AppendChild(newName);
                                    newNode.AppendChild(newPath);
                                    category.AppendChild(newNode);

                                    Console.WriteLine("Got Here 5");
                                    //cont = false;
                                }
                            }
                        }
                    }
                }
                try
                {
                    menuDoc.Save("menu.xml");
                    //System.Windows.Forms.Application.Restart();
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
            if (files.Length == 1) //if only one file in directory then set this as the path
                return files[0];
            foreach (string file in files)
            {
                Console.WriteLine("Found file: " + file);
                
            }
            return subdirectory;
        }

    }

}
