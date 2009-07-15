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

        public Menu()
        {
            shortcutTable = new Hashtable();    //Hashtable of app name to AppShortcut
            categories = new Hashtable();   //Hashtable of category name to ArrayList of apps in that category
        }

        public void addCategory(String cat)
        {
            if (!categories.ContainsKey(cat))
            categories.Add(cat, new ArrayList());
        }

        public void sortCategories()
        {
            foreach (string key in shortcutTable.Keys)
            {
                String tempCat = ((AppShortcut)shortcutTable[key]).getCategory();
                ((ArrayList)categories[tempCat]).Add(key);
               
            }
        }

        public void addItem(AppShortcut newShortcut)
        {
            shortcutTable.Add(newShortcut.getName(), newShortcut);
        }

        /*public void displayMenuItems()  //only for command line
        {
            Console.WriteLine("Creating menu...");
            foreach (String app in shortcutTable.Keys)
            {
                Console.WriteLine("App: " + app + " at " + ((AppShortcut)shortcutTable[app]).getPath() + " CATEGORY IS " + ((AppShortcut)shortcutTable[app]).getCategory());
            }
            //launch();
        }*/

        /*public void launch()   //only for command line
        {
            Console.WriteLine("Enter an app to launch");
            string input = Console.ReadLine();
            string inputPath = (String)shortcutTable[input];
            try
            {
                System.Diagnostics.Process.Start(@inputPath);
                launch();
            }
            catch (System.SystemException e)
            {
                Console.WriteLine("Application not found!");
                launch();
            }
        }*/

        public Hashtable getCategories()
        {
            return categories;
        }


        public Hashtable getTable()
        {
            return shortcutTable;
        }
    }
}
