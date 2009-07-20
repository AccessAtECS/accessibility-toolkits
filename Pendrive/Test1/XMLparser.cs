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

        public XMLparser()
        {
        }

        public Hashtable readXmlFile(String file, String[] tags)
        {
            Hashtable values = new Hashtable(); //to return
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
                                values.Add(valuesKey, items.Clone());
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

        public int getOldCount()
        {
            return oldAppCount;
        }
    }
}
