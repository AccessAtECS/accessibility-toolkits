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
        private String extra;

        public AppShortcut(String appName, String appPath, String category, String extra)
        {
            this.appName = appName;
            this.appPath = appPath;
            this.category = category;
            this.extra = extra;
            
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

        public String getExtra()
        {
            return extra;
        }

        public void setExtra(String extra)
        {
            this.extra = extra;
        }
    }
}
