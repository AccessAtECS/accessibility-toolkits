using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Test1
{
    class MainClass
    {
        static void Main(string[] args)
        {
           
            Menu appMenu = new Menu();
            MenuUpdater updater = new MenuUpdater();
            XMLparser x = new XMLparser(appMenu, updater);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm(x.readSettingsFile(), appMenu, updater));
            
        }


        
    }



}
