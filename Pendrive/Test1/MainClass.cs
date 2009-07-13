using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Test1
{
    class MainClass
    {
        static void Main(string[] args)
        {
           
            Menu appMenu = new Menu();
            XMLparser x = new XMLparser(appMenu);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm(appMenu.getTable(), appMenu.getCategories(), x.readSettingsFile()));
        }
    }
}
