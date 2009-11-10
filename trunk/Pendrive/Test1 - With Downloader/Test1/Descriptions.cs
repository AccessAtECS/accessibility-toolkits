using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Test1
{
    class Descriptions
    {
        private Hashtable descriptions;

        public Descriptions(ArrayList values)
        {
            descriptions = new Hashtable();
            foreach (String[] items in values)
            {
                descriptions.Add(items[0], items[1]);
            }
        }

        public Hashtable getDescriptions()
        {
            return descriptions;
        }
    }
}
