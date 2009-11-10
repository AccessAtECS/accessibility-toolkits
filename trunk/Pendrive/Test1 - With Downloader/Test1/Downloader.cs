using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using System.Threading;

namespace Test1
{
    public partial class Downloader : Form
    {
        DownloadList dList;
        Hashtable dApps;
        String name;
        String fileName;
        String address;
        DownloadShortcut ds;

        public delegate void InvokeDelegate();

        public Downloader(Font font, Color bg, Color fg)
        {
            InitializeComponent();
            this.Font = font;
            this.BackColor = bg;
            this.ForeColor = fg;

            
            if (!System.IO.Directory.Exists("Menu_Data\\downloader"))
            {
                //Show message saying the downloader is being set up for first time use
                System.IO.Directory.CreateDirectory("Menu_Data\\downloader");
                ArrayList fileAddresses = new ArrayList();
                //add each file that needs to be downloaded to set up downloader
                fileAddresses.Add("http://access.ecs.soton.ac.uk/portableappshelp.pdf");
                WebClient setupDownloader = new WebClient();
                foreach (Object requiredAddress in fileAddresses)
                {
                    String temp = (String)requiredAddress;
                    String tempName = temp.Substring(temp.LastIndexOfAny("/".ToCharArray()) + 1);
                    setupDownloader.DownloadFile(temp, tempName);
                }
            }



            address = "http://access.ecs.soton.ac.uk/appList.xml";
            fileName = "Menu_Data\\downloader\\appList.xml";
            //downloadFile();
            //WebClient fileDownload = new WebClient();
            //fileDownload.DownloadFile("http://access.ecs.soton.ac.uk/appList.xml", "Menu_Data\\appList.xml");

            String[] appTags = new String[7];
            appTags[0] = "name";
            appTags[1] = "address";
            appTags[2] = "category";
            appTags[3] = "extra";
            appTags[4] = "detail";
            appTags[5] = "foldername"; 
            appTags[6] = "type";
            try
            {
                dList = new DownloadList();
                XMLparser x = new XMLparser();
                dList.populateTable(x.readXmlFile("Menu_Data\\downloader\\appList.xml", appTags));
                dApps = dList.getTable();
                foreach (String dApp in dApps.Keys)
                {
                    Button newButton = new Button();
                    newButton.AutoSize = true;
                    DownloadShortcut temp1 = (DownloadShortcut)dApps[dApp];
                    String extra = temp1.getExtra();
                    String cat = temp1.getCategory();
                    String detail = temp1.getDetail();
                    if (detail.Equals("."))
                        detail = "";
                    newButton.Text = dApp + ": \n" + extra + "\n" + detail + "\n" + cat;
                    newButton.Click += new EventHandler(newButton_Click);
                    appContentPanel.Controls.Add(newButton);
                }
            }
            catch
            {
                CustomBox.Show("Could not process application list", "Error", this.Font, this.BackColor, this.ForeColor);
                this.Dispose();
            }
        }

        void newButton_Click(object sender, EventArgs e)
        {
            char[] separator = ":".ToCharArray();
            String name = sender.ToString();
            name = name.Substring(name.IndexOfAny(separator) + 2);
            name = name.Split(separator, 2)[0];
            ds = (DownloadShortcut)dApps[name];
            address = ds.getAddress();
            //String fileName;
            if (address.EndsWith(".zip"))
            {
                fileName = address.Substring(address.LastIndexOfAny("/".ToCharArray()) + 1);
            }
            else if (address.Contains("portableapps.com")) //replace these if statements to check for xml type field.
            {
                fileName = "";
                CustomBox.Show("This application requires a manual installation. When you close this message, both the download webpage and a help document will launch to guide you through the required steps.", "AccessTools", this.Font, this.BackColor, this.ForeColor);
                System.Diagnostics.Process.Start(address);
                System.Diagnostics.Process.Start("Menu_Data\\downloader\\portableappshelp.pdf");
                //fileName = address.Remove(address.LastIndexOf("/"));
                //fileName = fileName.Substring(fileName.LastIndexOfAny("/".ToCharArray()) + 1);
                //fileName = fileName.Substring(fileName.LastIndexOfAny("/".ToCharArray()) + 1);
                //MessageBox.Show(fileName);
            }
            else
            {
                fileName = "";
            }
            if (fileName != "")
            {
                String category = ds.getCategory();
                fileName = "Categories\\" + category + "\\" + fileName;
                //MessageBox.Show("Downloading " + fileName + " from " + address);
                toolStripStatusLabel1.Text = "Downloading " + name;
                this.Refresh();
                //WebClient appDownloader = new WebClient();
                
                //do this in separate thread
                this.BeginInvoke(new InvokeDelegate(downloadFile));
                //appDownloader.DownloadFile(address, fileName);
                //
            }
        }

        public void downloadFile()
        {
            WebClient appDownloader = new WebClient();
            try
            {
                //appDownloader.DownloadFile(address, fileName);
                toolStripStatusLabel1.Text = fileName + " downloaded";
            }
            catch
            {
                CustomBox.Show("Could not complete the required download. Please ensure that you are connected to the Internet", "Error!", this.Font, this.BackColor, this.ForeColor);
            }
            if (fileName.EndsWith(".zip"))
            {
                //Unzip files and check correct folder/file name
                unzip(fileName);
            }
        }

        public void unzip(String fileName)
        {
            try
            {
                String currLocation = System.IO.Directory.GetCurrentDirectory();
                fileName = currLocation + "\\" + fileName;
                Shell32.ShellClass shell = new Shell32.ShellClass();
                Shell32.Folder zipped = shell.NameSpace(@fileName);
                String unzipFolder = currLocation + "\\Categories\\" + ds.getCategory() + "\\" + ds.getFolderName();
                if (System.IO.Directory.Exists(@unzipFolder))
                //if (!System.IO.Directory.Exists(@unzipFolder))
                {
                    CustomBox.Show("You already have this application. This process will be stopped", "Access Tools", this.Font, this.BackColor, this.ForeColor);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(@unzipFolder);
                    Shell32.Folder unzipped = shell.NameSpace(@unzipFolder);
                    Shell32.FolderItems zippedItems = zipped.Items();
                    unzipped.CopyHere(zippedItems, "");

                        String[] directories = System.IO.Directory.GetDirectories(@unzipFolder);
                        if (directories.Length.Equals(1))
                        {
                            //MessageBox.Show("Success, only one subdirectory");
                            String dest = currLocation + "\\Categories\\" + ds.getCategory() + "\\" + directories[0].Substring(directories[0].LastIndexOfAny("\\".ToCharArray()));
                            //MessageBox.Show("Will move " + directories[0] + " to " + dest);
                            System.IO.Directory.Move(directories[0], dest);
                            System.IO.Directory.Delete(@unzipFolder);
                            System.IO.Directory.Move(dest, unzipFolder);
                            System.IO.Directory.Delete(@fileName); //removes zip file
                        }
                    
                }
            }
            catch
            {
                String currLocation = System.IO.Directory.GetCurrentDirectory();
                String unzipFolder = currLocation + "\\Categories\\" + ds.getCategory() + "\\" + ds.getFolderName();
                MessageBox.Show(unzipFolder);
                System.Windows.Forms.Clipboard.SetText(unzipFolder, TextDataFormat.UnicodeText);
                //System.Diagnostics.Process.Start("\\Categories\\" + ds.getCategory());
                String folder = ("\\Categories\\" + ds.getCategory());
                MessageBox.Show(folder);
                CustomBox.Show("Could not unzip the downloaded file automatically. \n\nRight-click the downloaded zip file (" + fileName + ") and extract the files. \n\nYou will then be asked to select the Destination Folder - Right-Click in the text box and select 'Paste' to add the correct path", "Access Tools", this.Font, this.BackColor, this.ForeColor);
            }

        }
    }
}
