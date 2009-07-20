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
         * Receives a hashtable 
         */ 
        public void populateMenu(ArrayList values)
        {
            foreach (String[] items in values)
            {
                //String[] items = (String[])values[key];
                String name = items[0];
                String path = items[1];
                String category = items[2];
                addCategory(category);
                addItem(new AppShortcut(name, path, category));
                
            }
            sortCategories();
        }
    }
}
