using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace Test1
{
    public class XMLparser
    {
        XmlTextReader reader;
        int oldAppCount;

        /**
         * Creates a new XMLparser and sets the oldAppCount to 0
         * oldAppCount is only used when reading the menu.xml file, and is set to the very first attribute's value as a 
         * record of how many apps where in the menu previously. This can be compared with a count of the local directories
         * to determine whether a new app has been added.
         */
        public XMLparser()
        {
            oldAppCount = 0;
        }

        /**
         * Reads the given xml file, storing information based on the array of tags that is passed.
         * The values of these tags are arranged into String arrays, and collectively stored in a hashmap, which is returned
         */ 
        public ArrayList readXmlFile(String file, String[] tags)
        {
            //Hashtable values = new Hashtable(); //to return
            ArrayList values = new ArrayList();
            try
            {
                int tagsSize = tags.Length; //number of tags
                String[] items = new String[tagsSize]; //for each "app" in the xml file
                String current = "";
                int valuesKey = 0;
                int i = 0;
                reader = new XmlTextReader(file);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name.Equals("menu"))
                            {
                                reader.MoveToFirstAttribute();
                                oldAppCount = int.Parse(reader.Value);
                            }
                            else
                            {
                                current = reader.Name;
                            }
                            break;
                        case XmlNodeType.Text:
                            foreach (String tag in tags)
                            {
                                if (current.Equals(tag))
                                {
                                    tagsSize--;
                                    items[i] = reader.Value.ToString();
                                    i++;
                                }
                                if (tagsSize == 0)
                                {
                                    values.Add(items.Clone());
                                    valuesKey++;
                                    i = 0;
                                    tagsSize = tags.Length;
                                }
                            }
                            break;
                    }
                }
                reader.Close();
                return values;
            }
            catch (FileNotFoundException e)
            {
                System.Windows.Forms.MessageBox.Show("Could not create menu - menu.xml not found!", "Error!");
                return values;
            }
        }

        /**
         * Returns the previous count of applications that is stored as the first attribute in the menu.xml file.
         * This is used to compare with the number of directories local to the menu, to determine whether a new
         * application has been added to the pendrive.
         */ 
        public int getOldCount()
        {
            return oldAppCount;
        }
    }
}
