using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Win32;
using System.Collections;

namespace Test1
{
    public class MenuUpdater
    {
        //Menu appMenu;
        int oldCount;
        Char[] lastSlash;
        XmlDocument menuDoc;
        XmlNodeList list;
        Hashtable descriptions;

        public MenuUpdater()
        {
            descriptions = new Hashtable();
        }
            
        /**
        * Takes in the old count of how many apps there were, and compares this with the number of directories local to the menu
        * If there are now more, then the menu is updated to include these new folders.
        * Methods are called to attempt to locate the true path of an app, rather than just its folder, as well as attempting 
        * to determine the application's category.
        * Returns a bool, telling the XMLparser whether or not it needs to re-parse the menu.xml file.
        */
        public void update(int oldCount)
        {
            this.oldCount = oldCount;
            int count = 0;
            String slash = "\\";
            lastSlash = slash.ToCharArray();
            String[] directories = Directory.GetDirectories(Directory.GetCurrentDirectory());
            System.Collections.ArrayList cats = new System.Collections.ArrayList();
            foreach (string subdirectory in directories) //counts the directories
            {
                if (subdirectory.StartsWith("."))
                {
                    //ignore
                }
                else if (Directory.Exists(subdirectory))
                {
                    count++;
                    String subdir = subdirectory.Substring(subdirectory.LastIndexOfAny(lastSlash) + 1);
                    if (subdir.Equals("Categories"))
                    {
                        String[] catFolders = Directory.GetDirectories(subdirectory);
                        foreach (string catFolder in catFolders)
                        {
                            cats.Add(catFolder);
                            count++;
                            String[] futherSubs = Directory.GetDirectories(catFolder);
                            foreach (string furtherSub in futherSubs)
                            {
                                if (Directory.Exists(furtherSub))
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
            if (!count.Equals(oldCount)) //if an app has been added or removed, clear the xml file and rebuild it
            {
                menuDoc = new XmlDocument();
                try
                {
                    menuDoc.Load("menu.xml");
                    menuDoc.RemoveAll();
                    XmlElement newRoot = menuDoc.CreateElement("menu");
                    menuDoc.AppendChild(newRoot);
                    list = menuDoc.GetElementsByTagName("menu");
                    XmlAttribute countAtt = menuDoc.CreateAttribute("count");

                    //Set the count value
                    countAtt.Value = count.ToString();
                    list[0].Attributes.Append(countAtt);
                    menuDoc.Save("menu.xml");

                    String[] descriptionTags = new String[2];
                    descriptionTags[0] = "appName";
                    descriptionTags[1] = "description";
                    try
                    {
                        XMLparser x = new XMLparser();
                        Descriptions d = new Descriptions(x.readXmlFile("Menu_Data\\descriptions.xml", descriptionTags));
                        descriptions = d.getDescriptions();
                    }
                    catch
                    {//
                    }
                    
                    foreach (string catFolder in cats)
                    {
                        directories = Directory.GetDirectories(catFolder);
                        addNodes(directories, true, catFolder.Substring(catFolder.LastIndexOfAny(lastSlash) + 1));
                    }
                    directories = Directory.GetDirectories(Directory.GetCurrentDirectory());
                    addNodes(directories, false, "");
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("AccessTools has encountered a problem. \nCause: menu.xml has become corrupted", "Error!");
                }
                try
                {
                    menuDoc.Save("menu.xml");
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Could not save menu.xml", "Error!");
                }
            }
        }

        /**
         * Creates new xml nodes for each application
         */
        public void addNodes(String[] directories, bool catFolder, String cat)
        {
           foreach (string subdirectory in directories)
            {
                if (!subdirectory.StartsWith("."))
                {
                    char[] extraSplit = "(".ToCharArray();
                    if (isNotCat(subdirectory.Substring(subdirectory.LastIndexOfAny(lastSlash) + 1)))
                    {
                        //found new app
                        XmlElement newNode = menuDoc.CreateElement("app");
                        XmlElement newName = menuDoc.CreateElement("name");
                        newName.InnerText = subdirectory.Substring(subdirectory.LastIndexOfAny(lastSlash) + 1);
                        XmlElement newPath = menuDoc.CreateElement("path");
                        string path = findPath(subdirectory, catFolder);
                        if (path.Contains("Access Tools")) //This allows paths to be created if Access Tools is running within a folder on a hard drive rather than a USB pendrive.
                        {
                            String drive = Directory.GetDirectoryRoot(subdirectory);
                            path = drive + path;
                        }
                        newPath.InnerText = path;
                        XmlElement newCategory = menuDoc.CreateElement("category");
                        if (catFolder)
                        {
                            newCategory.InnerText = cat;
                        }
                        else
                        {
                            newCategory.InnerText = checkCategory(path); //attempt to guess the category
                        }
                        XmlElement newExtra = menuDoc.CreateElement("extra");
                        newExtra.InnerText = ".";
                        try
                        {
                            newExtra.InnerText = (String)descriptions[subdirectory.Substring(subdirectory.LastIndexOfAny(lastSlash) + 1)];
                            if (newExtra.InnerText.Equals(""))
                                newExtra.InnerText = ".";
                        }
                        catch
                        {
                            newExtra.InnerText = ".";
                        }
                        if (!(newCategory.InnerText.Equals("User's Folders") && newName.InnerText.Equals("Menu_Data")))
                        {
                            newNode.AppendChild(newName);
                            newNode.AppendChild(newPath);
                            newNode.AppendChild(newCategory);
                            newNode.AppendChild(newExtra);
                            list[0].AppendChild(newNode);
                        }
                    }
                }
            }
        }

        /*
         * Checks that a Directory is not the Category parent folder
         */ 
        public bool isNotCat(String title)
        {
            if (!title.Equals("Categories"))
                return true;
            else return false;
        }
  
        /**
         * Takes in a path to a directory and attempts to locate the actual path wanted.
         * If there is only one file, and no other folder in the directory, then that file can be set as the path.
         * Otherwise, find the .exe files and check if there is one with the same name as the application.
         * If neither of these, return the path to the directory so that the menu opens that folder.
         */ 
        public string findPath(string subdirectory, bool cat)
        {
            int sub;
            if (cat)
                sub = 3;
            else sub = 2;
            String[] files = Directory.GetFiles(subdirectory);
            String[] directories = Directory.GetDirectories(subdirectory);
            if (directories.Length == 1 && files.Length == 0) //if only one subdirectory then search through this
            {
                subdirectory = directories[0];
                return findPath(subdirectory, cat);
            }
            if (files.Length == 1 && directories.Length == 0) //if only one file in directory then set this as the path
                return files[0].Substring(sub);
            foreach (string file in files)
            {
                if (file.EndsWith(".exe"))
                {
                    String filename = file.Substring(file.LastIndexOfAny(lastSlash) + 1);
                    String pathname = subdirectory.Substring(subdirectory.LastIndexOfAny(lastSlash) + 1) + ".exe";
                    if (filename.Equals(pathname) || filename.Equals(pathname.ToLower()))
                        return file.Substring(sub);
                }
                if (file.EndsWith(".EXE"))
                {
                    String filename = file.Substring(file.LastIndexOfAny(lastSlash) + 1);
                    String pathname = subdirectory.Substring(subdirectory.LastIndexOfAny(lastSlash) + 1) + ".EXE";
                    if (filename.Equals(pathname) || filename.Equals(pathname.ToLower()))
                        return file.Substring(sub);
                }
            }
            return subdirectory.Substring(sub);
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
                    return ("Accessibility Guides");
                if (directory.EndsWith(".exe"))
                    return ("Applications"); //could be an application e.g. firefox, or an accessibility tool e.g. a screenreader, need to distinguish   
            }
            else if (Directory.Exists(directory))
                    return ("User's Folders");
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

        public void editExtra(string app, string newExtra)
        {
            XmlDocument menuDoc = new XmlDocument();
            menuDoc.Load("menu.xml");
            XmlNodeList list = menuDoc.GetElementsByTagName("app");
            foreach (XmlElement application in list)
            {
                if (application.FirstChild.InnerText.Equals(app))
                {
                    application.ChildNodes[3].InnerText = newExtra;
                    break;
                }
            }
            menuDoc.Save("menu.xml");
            XmlDocument descriptionDoc = new XmlDocument();
            descriptionDoc.Load("Menu_Data\\descriptions.xml");
            XmlNodeList descriptions = descriptionDoc.GetElementsByTagName("appDescriptions"); //gets all descriptions
            foreach (XmlElement application in descriptions[0])
            {
                if (application.FirstChild.InnerText.Equals(app))
                {
                    application.ParentNode.RemoveChild(application);
                }
            }
            XmlElement appName = descriptionDoc.CreateElement("appName");
            appName.InnerText = app;
            XmlElement appDescr = descriptionDoc.CreateElement("description");
            appDescr.InnerText = newExtra;
            XmlElement appNode = descriptionDoc.CreateElement("app");
            appNode.AppendChild(appName);
            appNode.AppendChild(appDescr);
            descriptions[0].AppendChild(appNode);
            descriptionDoc.Save("Menu_Data\\descriptions.xml");
        }

        /**
         * Saves the users settings in an xml file so that they can be restored when the user next loads the menu.
         */ 
        public void saveSettings(String bgcolour, String txtcolour, String font, String fontsize)
        {
            try
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
            catch (IOException e)
            {
            }
        }

        /**
         * Creates menu.xml if the file is not in the local directory when the menu is run
         */ 
        public void createMenuFile()
        {
            XmlDocument newMenu = new XmlDocument();
            XmlTextWriter newMenuWriter = new XmlTextWriter("menu.xml", System.Text.Encoding.UTF8);
            newMenuWriter.Formatting = Formatting.Indented;
            
            //Create Starting Element
            newMenuWriter.WriteStartElement("menu");
            newMenuWriter.WriteEndElement();
            newMenuWriter.Close();
            
            //Load the newly created file and insert count attribute
            newMenu.Load("menu.xml");
            XmlNodeList list = newMenu.GetElementsByTagName("menu");
            XmlAttribute count = newMenu.CreateAttribute("count");
            
            //Set the initial count value to 0
            count.Value = "0";
            list[0].Attributes.Append(count);
            newMenu.Save("menu.xml");
        }

        /**
         * Creates settings.xml if the file is not in the local directory when the menu closes
         */ 
        public void createSettingsFile()
        {
            XmlDocument newSettings = new XmlDocument();
            XmlTextWriter newSettingsWriter = new XmlTextWriter("settings.xml", System.Text.Encoding.UTF8);
            newSettingsWriter.Formatting = Formatting.Indented;

            //Create Starting Element
            newSettingsWriter.WriteStartElement("settings");
            newSettingsWriter.WriteEndElement();
            newSettingsWriter.Close();

            //Load file and insert elements
            newSettings.Load("settings.xml");
            XmlNodeList list = newSettings.GetElementsByTagName("settings");
            XmlElement settingsBgColour = newSettings.CreateElement("bgcolour");
            list[0].AppendChild(settingsBgColour);
            XmlElement settingsTextColour = newSettings.CreateElement("textcolour");
            list[0].AppendChild(settingsTextColour);
            XmlElement settingsFont = newSettings.CreateElement("font");
            list[0].AppendChild(settingsFont);
            XmlElement settingsFontSize = newSettings.CreateElement("fontsize");
            list[0].AppendChild(settingsFontSize);
            
            newSettings.Save("settings.xml");
        }          
    }

}
