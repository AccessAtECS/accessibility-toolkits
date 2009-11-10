using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    class DownloadShortcut
    {
        String name;
        String address;
        String category;
        String extra;
        String detail;
        String foldername;
        String type;

        public DownloadShortcut(String name, String address, String cat, String extra, String detail, String foldername, String type)
        {
            this.name = name;
            this.address = address;
            this.category = cat;
            this.extra = extra;
            this.detail = detail;
            this.foldername = foldername;
            this.type = type;
        }

        public String getName()
        {
            return name;
        }

        public String getAddress()
        {
            return address;
        }

        public String getCategory()
        {
            return category;
        }

        public String getExtra()
        {
            return extra;
        }

        public String getDetail()
        {
            return detail;
        }

        public String getFolderName()
        {
            return foldername;
        }

        public String getType()
        {
            return type;
        }
    }
}
