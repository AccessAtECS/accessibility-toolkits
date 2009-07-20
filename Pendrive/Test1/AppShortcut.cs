using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    /**
     * Class to store all details about the link to particular app
     */ 
    public class AppShortcut
    {
        private String appName;
        private String appPath;
        private String category;

        public AppShortcut(String appName, String appPath, String category)
        {
            this.appName = appName;
            this.appPath = appPath;
            this.category = category;
        }

        public String getName()
        {
            return appName;
        }

        public String getPath()
        {
            return appPath;
        }

        public String getCategory()
        {
            return category;
        }
    }
}
