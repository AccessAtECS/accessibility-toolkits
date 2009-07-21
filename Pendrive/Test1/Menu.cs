using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Test1
{
    public class Menu
    {
        private Hashtable shortcutTable;
        private Hashtable categories;
        private int oldCount;

        /**
         * Creates a new menu object and initialises two Hashtables
         */ 
        public Menu()
        {
            shortcutTable = new Hashtable();    //Hashtable of app name to AppShortcut
            categories = new Hashtable();   //Hashtable of category name to ArrayList of apps in that category
        }

        /**
         * Ensures that the category has not previously been added to the categories table, and then adds it as the key,
         * with an empty ArrayList as the value.
         */ 
        public void addCategory(String cat)
        {
            if (!categories.ContainsKey(cat))
            categories.Add(cat, new ArrayList());
        }

        /**
         * Traverses through the shortcutTable and extracts the category from the AppShortcut items.
         * Adds the AppShortcut to the category table in the relevant ArrayList.
         */ 
        public void sortCategories()
        {
            foreach (string key in shortcutTable.Keys)
            {
                String tempCat = ((AppShortcut)shortcutTable[key]).getCategory();
                ((ArrayList)categories[tempCat]).Add(key);
            }
        }

        /**
         * Adds the given AppShortcut to the shortcut hashtable, with it's name as the key, and the AppShortcut object as the value.
         */ 
        public void addItem(AppShortcut newShortcut)
        {
            shortcutTable.Add(newShortcut.getName(), newShortcut);
        }

        /**
         * Returns the category hashtable
         */ 
        public Hashtable getCategories()
        {
            return categories;
        }

        /**
         * Returns the AppShortcut table
         */ 
        public Hashtable getTable()
        {
            return shortcutTable;
        }

        /**
         * Receives an ArrayList containing arrays of the app link details.
         * Calls addCategory to attempt to add the category if it is new.
         * Adds the new app to the the table.
         * Sorts the application table so that they will be displayed in categories.
         */ 
        public void populateMenu(ArrayList values)
        {
            foreach (String[] items in values)
            {
                String name = items[0];
                String path = items[1];
                String category = items[2];
                addCategory(category);
                addItem(new AppShortcut(name, path, category));
            }
            sortCategories();
        }

        /**
         * Sets the previous count of applications in the menu
         */ 
        public void setOldCount(int oc)
        {
            this.oldCount = oc;
        }

        /**
         * Returns the previous count of applications that is stored as the first attribute in the menu.xml file.
         * This is used to compare with the number of directories local to the menu, to determine whether a new
         * application has been added to the pendrive.
         */ 
        public int getCount()
        {
            return oldCount;
        }
    }
}
