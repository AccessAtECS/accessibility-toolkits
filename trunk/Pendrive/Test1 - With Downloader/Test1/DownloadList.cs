using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Test1
{
    class DownloadList
    {
        private Hashtable shortcutTable;

        public DownloadList()
        {
            shortcutTable = new Hashtable();
        }

        public void populateTable(ArrayList values)
        {
            foreach (String[] items in values)
            {
                String name = items[0];
                String address = items[1];
                String category = items[2];
                String extra = items[3];
                String foldername = items[4];
                String type = items[5];
                addItem(new DownloadShortcut(name, address, category, extra, foldername, type));
            }
        }

        public void addItem(DownloadShortcut dshortcut)
        {
            shortcutTable.Add(dshortcut.getName(), dshortcut);
        }

        public Hashtable getTable()
        {
            return shortcutTable;
        }
    }
}
