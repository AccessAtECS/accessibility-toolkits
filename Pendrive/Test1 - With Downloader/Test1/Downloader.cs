﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using System.Threading;
using System.Globalization;
using System.Resources;

namespace Test1
{
    public partial class Downloader : Form
    {
        private ResourceManager m_ResourceManager = new ResourceManager("Test1.UI_Strings", System.Reflection.Assembly.GetExecutingAssembly());
        private CultureInfo m_EnglishCulture = new CultureInfo("en-US");
        private CultureInfo m_SpanishCulture = new CultureInfo("es-ES");
        private CultureInfo m_TaiwanCulture = new CultureInfo("zh-TW");
        private CultureInfo m_MalayCulture = new CultureInfo("ms-MY");
        private CultureInfo m_ChineseCulture = new CultureInfo("zh-CHS");
        private CultureInfo m_IndianCulture = new CultureInfo("hi-IN");

        DownloadList dList;
        Hashtable dApps;
        String fileName; //the string that holds the target file name of the item to be downloaded
        String address;  //the string that holds the web address of the file to download
        String type;
        DownloadShortcut ds;
		//installation details:
		String currLocation;
		String categoryFolder;
		String downloadFolder;
		

        public delegate void InvokeDelegate();

        /*
         * Creates the Downloader, sets colours, fonts and size
         * Checks the Menu_Data\downloader directory exists, and if not creates it to prepare an old distribution of AccessTools for the Downloader
         * Checks the appList.xml file which contains the available download information, downloads new copy if needed
         * Prepares for xml parsing, then parses appList.xml to extract information about available downloads, creates a button on the gui for each
         */ 
        public Downloader(Font font, Color bg, Color fg, CultureInfo culture)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = culture;
            UpdateStrings();
            this.Font = font;
            statusStrip1.Font = font;
            toolStrip1.Font = font;
            this.BackColor = bg;
            this.ForeColor = fg;
            toolStrip1.BackColor = bg;
            //appPanel.ForeColor = fg;

            Rectangle maxSize = new Rectangle();
            maxSize.Height = (Screen.PrimaryScreen.WorkingArea.Height / 3) * 2;
            maxSize.Width = (Screen.PrimaryScreen.WorkingArea.Width / 2);
            this.Size = maxSize.Size;
            //this.MaximumSize = maxSize.Size;
            //this.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width / 4, 0);
            //this.Left = Screen.PrimaryScreen.WorkingArea.Width / 4;
            //this.Top = 0;

            prepare();

            /*if (!System.IO.Directory.Exists("Menu_Data\\downloader"))
            {
                createDirectory();                
            }
            toolStripStatusLabel1.Text = "Checking for appList update -- Please Wait";
            address = "http://access.ecs.soton.ac.uk/accessTools/appList.xml";
            fileName = "Menu_Data\\downloader\\appList.xml";
            WebClient listDownloader = new WebClient();
            
            if (!(System.IO.File.Exists(fileName)))
            {
                try
                {
                    listDownloader.DownloadFile(address, fileName);
                }
                catch
                {
                    CustomBox.Show("Please ensure you are connected to the Internet", "Access Tools", this.Font, this.BackColor, this.ForeColor);
                    this.Close();
                }
            }
            else
            {
                DateTime lastDownload = new System.IO.DirectoryInfo(fileName).CreationTime.Date;
                DateTime today = DateTime.Today;
                if (!(lastDownload.Equals(today)))
                {
                    listDownloader.DownloadFile(address, fileName);
                }
            }*/

            toolStripStatusLabel1.Text = m_ResourceManager.GetString("StatusReady");
            parseList();
            /*String[] appTags = new String[6];
            appTags[0] = "name";
            appTags[1] = "address";
            appTags[2] = "category";
            appTags[3] = "extra";
            appTags[4] = "foldername"; 
            appTags[5] = "type";
            try
            {
                dList = new DownloadList();
                XMLparser x = new XMLparser();
                dList.populateTable(x.readXmlFile("Menu_Data\\downloader\\appList.xml", appTags));
                dApps = dList.getTable();
                ArrayList accessbilityTools = new ArrayList();
                ArrayList applications = new ArrayList();
                foreach (String dApp in dApps.Keys)
                {
                    Button newButton = new Button();
                    newButton.AutoSize = true;
                    DownloadShortcut temp1 = (DownloadShortcut)dApps[dApp];
                    String extra = temp1.getExtra();
                    String cat = temp1.getCategory();
                   
                    newButton.Text = dApp + ": \n" + extra;
                    newButton.Click += new EventHandler(newButton_Click);
                    if (cat.Equals("Accessibility Tools"))
                    {
                        accessbilityTools.Add(newButton);
                    }
                    else if (cat.Equals("Applications"))
                    {
                        applications.Add(newButton);
                    }
                    else
                    {
                        appContentPanel.Controls.Add(newButton);
                    }                    
                }
                foreach (Button newButton in accessbilityTools)
                {
                    appContentPanel.Controls.Add(newButton);
                }
                foreach (Button newButton in applications)
                {
                    appContentPanel.Controls.Add(newButton);
                }
                WizardBox.Show("Welcome to the Access Tools Downloader. \n\nPlease ensure you read any messages that appear throughout the process of adding new applications, and do not close them until instructed to do so. \n\nThis will ensure that the downloader works effectively, and will provide you with the necessary information to make using Access Tools the best possible experience. \n\nBy using the Access Tools Downloader you accept that Access Tools holds no responsibility for any damages or loss caused during the installation of new applications.", "Access Tools Downloader", this.Font, this.BackColor, this.ForeColor);
            }
            catch
            {
                WizardBox.Show("Could not process application list", "Error", this.Font, this.BackColor, this.ForeColor);
                this.Dispose();
            }*/
        }

        private void UpdateStrings()
        {
            toolStripLabel1.Text = m_ResourceManager.GetString("DownloaderLabel");
            toolStripStatusLabel1.Text = m_ResourceManager.GetString("StatusReady");
        }

        /*
         * Checks downloader directory exists
         * Updates appList.xml file for most recent apps
         */ 
        public void prepare()
        {
            if (!System.IO.Directory.Exists("Menu_Data\\downloader"))
            {
                createDirectory();                
            }
            //toolStripStatusLabel1.Text = "Checking for appList update -- Please Wait";
            address = "http://access.ecs.soton.ac.uk/accessTools/appList.xml";
            fileName = "Menu_Data\\downloader\\appList.xml";
            WebClient listDownloader = new WebClient();
            
            if (!(System.IO.File.Exists(fileName)))
            {
                try
                {
                    listDownloader.DownloadFile(address, fileName);
                }
                catch
                {
                    //CustomBox.Show("Please ensure you are connected to the Internet", "Access Tools", this.Font, this.BackColor, this.ForeColor);
                    CustomBox.Show(m_ResourceManager.GetString("ensureInternet"), "Access Tools", this.Font, this.BackColor, this.ForeColor);
                    this.Close();
                }
            }
            else
            {
                DateTime lastDownload = new System.IO.DirectoryInfo(fileName).CreationTime.Date;
                DateTime today = DateTime.Today;
                if (!(lastDownload.Equals(today)))
                {
                    listDownloader.DownloadFile(address, fileName);
                }
            }
        }

        /*
         * Creates the required directory on the pendrive if this doesn't already exist
         */ 
        public void createDirectory()
        {
            //toolStripStatusLabel1.Text = "Configuring Access Tools Downloader -- Please Wait";
            //WizardBox.Show("Please wait while Access Tools configures the downloader for first time use.", "Access Tools", this.Font, this.BackColor, this.ForeColor);
            //toolStripStatusLabel1.Text = "Creating Access Tools Downloader directory -- Please Wait";
            System.IO.Directory.CreateDirectory("Menu_Data\\downloader");
		}

        /*
         * Parses appList.xml to retrieve details about available apps
         * Adds a button to the form for each app
         */ 
        public void parseList()
        {
            String[] appTags = new String[6];
            appTags[0] = "name";
            appTags[1] = "address";
            appTags[2] = "category";
            appTags[3] = "extra";
            appTags[4] = "foldername";
            appTags[5] = "type";
            try
            {
                dList = new DownloadList();
                XMLparser x = new XMLparser();
                dList.populateTable(x.readXmlFile("Menu_Data\\downloader\\appList.xml", appTags));
                dApps = dList.getTable();
                ArrayList accessbilityTools = new ArrayList();
                ArrayList applications = new ArrayList();
                foreach (String dApp in dApps.Keys)
                {
                    Button newButton = new Button();
                    newButton.TextAlign = ContentAlignment.MiddleLeft;
                    Rectangle size = new Rectangle();
                    size.Height = 6 * Int32.Parse(this.Font.Size.ToString());
                    size.Width = this.Width - 40;
                    newButton.Size = size.Size;
                    //newButton.AutoSize = true;
                    DownloadShortcut temp1 = (DownloadShortcut)dApps[dApp];
                    String extra = temp1.getExtra();
                    String cat = temp1.getCategory();

                    newButton.Text = dApp + ": \n" + extra;
                    newButton.Click += new EventHandler(newButton_Click);
                    if (cat.Equals("Accessibility Tools"))
                    {
                        accessbilityTools.Add(newButton);
                    }
                    else if (cat.Equals("Applications"))
                    {
                        applications.Add(newButton);
                    }
                    else
                    {
                        appContentPanel.Controls.Add(newButton);
                    }
                }
                //bool first = false;
                //Rectangle size = new Rectangle();
                foreach (Button newButton in accessbilityTools)
                {
                    /*if (!first)
                    {
                        first = !first;
                        size.Size = newButton.Size;
                    }
                    newButton.Size = size.Size;*/
                    appContentPanel.Controls.Add(newButton);
                    //listView1.Controls.Add(newButton);
                }
                foreach (Button newButton in applications)
                {
                    appContentPanel.Controls.Add(newButton);                    
                }
                //WizardBox.Show("Welcome to the Access Tools Downloader. \n\nPlease ensure you read any messages that appear throughout the process of adding new applications, and do not close them until instructed to do so. \n\nThis will ensure that the downloader works effectively, and will provide you with the necessary information to make using Access Tools the best possible experience. \n\nBy using the Access Tools Downloader you accept that Access Tools holds no responsibility for any damages or loss caused during the installation of new applications.", "Access Tools Downloader", this.Font, this.BackColor, this.ForeColor);
                WizardBox.Show(m_ResourceManager.GetString("DownloaderWelcome"), "Access Tools Downloader", this.Font, this.BackColor, this.ForeColor);
            }
            catch
            {
                //WizardBox.Show("Could not process application list", "Error", this.Font, this.BackColor, this.ForeColor);
                WizardBox.Show(m_ResourceManager.GetString("errorDownloader"), "Error", this.Font, this.BackColor, this.ForeColor);
                this.Dispose();
            }
        }


        /*
         * Creates a generic event handler for each button created. 
         * Extracts the name of the application selected, and checks whether you already have the associated folder on the pendrive
         * Checks the type field of the selected application, and calls the appropriate method to obtain it
         */ 
        void newButton_Click(object sender, EventArgs e)
        {
            char[] separator = ":".ToCharArray();
            String name = sender.ToString();
            name = name.Substring(name.IndexOfAny(separator) + 2);
            name = name.Split(separator, 2)[0];
            ds = (DownloadShortcut)dApps[name];
            address = ds.getAddress();
            type = ds.getType();
			currLocation = System.IO.Directory.GetCurrentDirectory();
            if (currLocation.Contains("accessTools"))
            {
                currLocation = currLocation + "\\";
            }
			categoryFolder = currLocation + "Categories\\" + ds.getCategory(); 
			downloadFolder = categoryFolder + "\\" + ds.getFolderName();
            if (System.IO.Directory.Exists(downloadFolder))
            {
                //CustomBox.Show("You already have this application!", "Access Tools", this.Font, this.BackColor, this.ForeColor);
                CustomBox.Show(m_ResourceManager.GetString("AppAlreadyInstalled"), "Access Tools", this.Font, this.BackColor, this.ForeColor);
            }
            else
            {
                if (type.Equals("2"))//if target is a zip file
                {
                    fileName = address.Substring(address.LastIndexOfAny("/".ToCharArray()) + 1);
                    prepareDownload(name);
                }
                else if (type.Equals("1")) //if target is from sourceforge
                {
                    fileName = address.Remove(address.LastIndexOf(".exe") + 4);
                    fileName = fileName.Substring(fileName.LastIndexOfAny("/".ToCharArray()) + 1);
                    prepareDownload(name);
                }
                else if (type.Equals("3")) //if target is no specific file but points to a zip file
                {
                    fileName = "";
                    getZip();
                }
                else if (type.Equals("4")) //if target is directly to an exe
                {
                    fileName = address.Substring(address.LastIndexOfAny("/".ToCharArray()) + 1);
                    prepareDownload(name);
                }
                else
                {
                    MessageBox.Show(m_ResourceManager.GetString("DownloadError"));
                }
                
            }
        }

        /*
         * Calculates the correct file name of the file to be downloaded
         * Begins the download thread
         */ 
        public void prepareDownload(String name)
        {
            String category = ds.getCategory();
            fileName = "Categories\\" + category + "\\" + fileName;
            toolStripStatusLabel1.Text = m_ResourceManager.GetString("Downloading") + " " + name;
            this.Refresh();
            this.BeginInvoke(new InvokeDelegate(downloadFile));
        }
        
        /*
         * Creates a WebClient and event handlers
         * Attempts to download from the given web address
         * If a type 1 causes this to throw, call the install() method which will use the browser to ask user to run/save the installer
         */ 
        public void downloadFile()
        {
            WebClient appDownloader = new WebClient();
            appDownloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(appDownloader_DownloadProgressChanged);
            appDownloader.DownloadFileCompleted += new AsyncCompletedEventHandler(appDownloader_DownloadFileCompleted);
            try
            {
                Uri webAddress = new Uri(address);
                //CustomBox.Show("You already have this application!", "Access Tools", this.Font, this.BackColor, this.ForeColor);CustomBox.Show("Beginning Download", "Access Tools Downloader", this.Font, this.BackColor, this.ForeColor);
                //CustomBox.Show(m_ResourceManager.GetString("AppAlreadyInstalled"), "Access Tools", this.Font, this.BackColor, this.ForeColor); CustomBox.Show("Beginning Download", "Access Tools Downloader", this.Font, this.BackColor, this.ForeColor);
                appDownloader.DownloadFileAsync(webAddress, fileName);
            }
            catch
            {
                if (type.Equals("1"))
                {
                    //Show instructions for installation
                    install();
                }
                else
                {
                    //WizardBox.Show("Could not complete the required download. Please ensure that you are connected to the Internet", "Error!", this.Font, this.BackColor, this.ForeColor);
                    WizardBox.Show(m_ResourceManager.GetString("errorDownloading"), "Error!", this.Font, this.BackColor, this.ForeColor);
                }
            }
        }

        /*
         * Event handler for when a download is completed
         * If from sourceforge or a direct link to an exe, call runinstaller() which will then determine whether the browser needs to be used to ask save/run
         * If a zip file, run unzip()
         */ 
        void appDownloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //toolStripStatusLabel1.Text = fileName + " downloaded";
            toolStripStatusLabel1.Text = fileName + " " + m_ResourceManager.GetString("downloaded");
            if (type.Equals("1") || type.Equals("4"))
                runinstaller();
            else if (type.Equals("2"))
                unzip();
            else
                MessageBox.Show("Error!");              
        }

        /*
         * Update progress bar as download progresses
         */
        void appDownloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        /*
         * Rarely called, but if an address contains a PHP variable that directs to a zip file, but does not actually include the filename in that address, this will download it
         * When the method believes a new file has been downloaded - the zip file - it calls the unzip method which handles regular zip downloads
         */ 
        public void getZip()
        {
            //WizardBox.Show("Welcome to the Access Tools Download Wizard. \nPlease follow the instructions provided to ensure your new application is downloaded correctly. Select OK to begin.", "Access Tools Installation Wizard", this.Font, this.BackColor, this.ForeColor);
            WizardBox.Show(m_ResourceManager.GetString("DownloadWizardIntro"), m_ResourceManager.GetString("Download Wizard"), this.Font, this.BackColor, this.ForeColor);
            String folder = categoryFolder;
			fileName = downloadFolder + ".zip";
            int directoryCount = System.IO.Directory.GetFiles(folder).Length; //count the subdirectories
            try
            {
                System.Windows.Forms.Clipboard.Clear();
                System.Windows.Forms.Clipboard.SetText(downloadFolder, TextDataFormat.UnicodeText);
                //copies the unzip path to the clipboard
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            System.Diagnostics.Process.Start(address); //launches page in browser, so download begins
            //WizardBox.Show("IMPORTANT - DO NOT CLOSE THIS BOX \nYour web browser will begin downloading the file. Select 'Save' in the box that appears to begin the download. \n\nThe destination has been automatically copied for you, paste this into the text box that asks for the target file name, and the zip file will then download. \n\nOnly close this message when the download has finished.", "Access Tools Installation Wizard Step 1/1", this.Font, this.BackColor, this.ForeColor);
            WizardBox.Show(m_ResourceManager.GetString("DownloadZipInstructions"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
            if ((directoryCount + 1) == System.IO.Directory.GetFiles(folder).Length)
            {
                unzip();
            }
            else
            {
                //CustomBox.Show("Download Failed", "Error!", this.Font, this.BackColor, this.ForeColor);
                CustomBox.Show(m_ResourceManager.GetString("errorDownloading"), "Error!", this.Font, this.BackColor, this.ForeColor);
            }
        }

        /*
         * Unzips zip files
         * Relys heavily upon the user not closing messages until instructed to do so, otherwise process will fail
         * Loads the folder containing the zip and counts its directories
         * Copies the unzip path to clipbaord, and assumes user unzips the file to this path
         * Checks a new folder has been created, and renames the new one to the correct name
         * Deletes the zip file
         */ 
        public void unzip()
        {
            bool unzipdone = false;
            //WizardBox.Show("Welcome to the Access Tools Installation Wizard. \nPlease follow the instructions provided to ensure your new application is added correctly. Select OK to begin.", "Access Tools Installation Wizard", this.Font, this.BackColor, this.ForeColor);
            WizardBox.Show(m_ResourceManager.GetString("DownloadWizardIntro"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
            String unzipFolder = downloadFolder;
			String folder = categoryFolder;
			if (System.IO.Directory.Exists(unzipFolder) && System.IO.Directory.GetDirectories(unzipFolder).Length == 0)
            {
                System.IO.Directory.Delete(unzipFolder);
            }
            
            System.Diagnostics.Process.Start(folder);   //show the folder containing the zip file
            int directoryCount = System.IO.Directory.GetDirectories(folder).Length; //count the subdirectories
            try
            {
                System.Windows.Forms.Clipboard.Clear();
                System.Windows.Forms.Clipboard.SetText(unzipFolder, TextDataFormat.UnicodeText);
                //copies the unzip path to the clipboard
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            //WizardBox.Show("IMPORTANT - DO NOT CLOSE THIS BOX \nAccessTools could not unzip the downloaded file automatically. \n\nA window should have loaded showing a list of folders. Right-click (or use the alternatve keyboard command) on the downloaded zip file (" + fileName + ") and choose to extract the files. \n\nYou will then be asked to select the Destination Folder - this will have been automatically copied for you, you just need to paste it into text box shown. (In rare cases, the copy may not have worked - copy this path: " + unzipFolder + " into the text box.) \n\nWhen the unzip has completed, close this message. ", "Access Tools Installation Wizard Step 1/2", this.Font, this.BackColor, this.ForeColor);
            WizardBox.Show(m_ResourceManager.GetString("InstallZipInstruction1") + " " + unzipFolder + " " + m_ResourceManager.GetString("InstallZipInstruction2"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
            
            //checks a new folder has been created, and then orders the folders and finds the new folder
            if ((directoryCount + 1) == System.IO.Directory.GetDirectories(folder).Length)
            {
                String[] currentSubdirectories = System.IO.Directory.GetDirectories(folder);
                DateTime[] timeOfCreation = new DateTime[currentSubdirectories.Length];
                for (int i = 0; i < currentSubdirectories.Length; i++)
                {
                    timeOfCreation[i] = new System.IO.DirectoryInfo(currentSubdirectories[i]).CreationTime;
                }
                Array.Sort(timeOfCreation, currentSubdirectories);
                   
                String newestFolder = currentSubdirectories[currentSubdirectories.Length - 1];
                if (System.IO.Directory.GetDirectories(newestFolder).Length == 1)
                {
                    //if only 1 subdirectory - zip was created correctly then need to remove one level of directory from its path
                    String requiredFolder = System.IO.Directory.GetDirectories(newestFolder)[0];
                    System.IO.Directory.Move(requiredFolder, folder + "\\temp");
                    System.IO.Directory.Delete(newestFolder);
                    requiredFolder = folder + "\\temp";
                    //rename the folder to the required new name
                    System.IO.Directory.Move(requiredFolder, newestFolder);
                } 
                unzipdone = true;
            }                
            
            if (unzipdone)
            {
                //WizardBox.Show("Application successfully downloaded and prepared for use. Please restart AccessTools to see it in your menu.", m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
                WizardBox.Show(m_ResourceManager.GetString("WizardInstallComplete"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
                try
                {
                    String fName = ds.getAddress().Substring(ds.getAddress().LastIndexOfAny("/".ToCharArray()) + 1);
                    String otherFolder = currLocation + "\\Menu_Data\\downloader\\" + fName;
                    try
                    {
                        System.IO.File.Delete(fileName);
                    }
                    catch
                    {
                        //MessageBox.Show("Couldn't delete zip file");
                        MessageBox.Show(m_ResourceManager.GetString("errorDeleting"));
                    }                    
                }
                catch
                {
                    WizardBox.Show("Could not move downloaded zip file to safe location", "Error", this.Font, this.BackColor, this.ForeColor);
                }
                informToUpdate();
            }
            else
            {
                WizardBox.Show(m_ResourceManager.GetString("errorInstalling"), "Error!", this.Font, this.BackColor, this.ForeColor);
            }
        }        

        /*
         * Method to execute a downloaded installer
         * If the installer link was not direct to the file (e.g. it needs the browser to download it and ask user to save/run the file), then the size
         * of the file will be 0 bytes, and run the install() method to handle this.
         * Otherwise inform the user to paste in the correct installation path to the installer.
         */ 
        public void runinstaller()
        {
            String folder = categoryFolder;
            String foldername = ds.getFolderName();
			String installFolder = downloadFolder;
            int directoryCount = System.IO.Directory.GetDirectories(folder).Length; //count the subdirectories
            try
            {
                System.Windows.Forms.Clipboard.Clear();
                System.Windows.Forms.Clipboard.SetText(installFolder, TextDataFormat.UnicodeText);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            System.IO.FileInfo installer = new System.IO.FileInfo(fileName);
            if (installer.Length == 0)
            {
                install(); //link to installer requests download via installer, run install method to handle this
            }
            else
            {
                //WizardBox.Show("Welcome to the Access Tools Installation Wizard. \nPlease follow the instructions provided to ensure your new application is added correctly. Select OK to begin.", "Access Tools Installation Wizard", this.Font, this.BackColor, this.ForeColor);
                WizardBox.Show(m_ResourceManager.GetString("DownloadWizardIntro"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
                System.Diagnostics.Process.Start(fileName);
                //WizardBox.Show("The Application Installer should have loaded. Follow the steps in the installer until you reach the 'Choose Install Location' box. \n\nThe installation path will have been copied automatically to your clipboard - Paste this into the Install Location box and then Select Install.", "Access Tools Installation Wizard Step 1/1", this.Font, this.BackColor, this.ForeColor);
                //WizardBox.Show("IMPORTANT \nOnly close this message when the installation process has finished completely!", "Access Tools Installation Wizard", this.Font, this.BackColor, this.ForeColor);
                WizardBox.Show(m_ResourceManager.GetString("Install1"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
                WizardBox.Show(m_ResourceManager.GetString("Install2"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
                if ((directoryCount + 1) == System.IO.Directory.GetDirectories(folder).Length) //if new folder has been created for the new app, delete the installer file
                {
                    try
                    {
                        System.IO.File.Delete(fileName);
                    }
                    catch
                    {
                        MessageBox.Show("Couldn't delete installer");
                    }
                    informToUpdate();
                }
                else
                {
                    MessageBox.Show(m_ResourceManager.GetString("errorInstalling"));
                }
            }
        }

        /*
         * Rather than downloading and installing an installer file, use the user's web browser to Run the installer.
         * Will be used depending on how sourceforge links point to the download
         */ 
        public void install()
        {
            //WizardBox.Show("Welcome to the Access Tools Installation Wizard. \nPlease follow the instructions provided to ensure your new application is added correctly. Select OK to begin.", "Access Tools Installation Wizard", this.Font, this.BackColor, this.ForeColor);
            WizardBox.Show(m_ResourceManager.GetString("DownloadWizardIntro"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
            String catFolder = categoryFolder;
            String foldername = ds.getFolderName();
            String installFolder = downloadFolder;
			try
            {
                System.Windows.Forms.Clipboard.Clear();
                System.Windows.Forms.Clipboard.SetText(installFolder, TextDataFormat.UnicodeText);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            System.Diagnostics.Process.Start(address);
            //WizardBox.Show("Your web browser will begin downloading the file. Select 'Run' in the box that appears to begin the download.", "Access Tools Installation Wizard Step 1/3", this.Font, this.BackColor, this.ForeColor);
            //WizardBox.Show("IMPORTANT - DO NOT CLOSE THIS BOX \n\nWhen the download has completed you may receive a security warning. Allow the file to install.\n\n Close this message when the installer begins.", "Access Tools Installation Wizard Step 2/3", this.Font, this.BackColor, this.ForeColor);
            //WizardBox.Show("Follow the steps in the installer until you reach the 'Choose Install Location' box. \n\nThe installation path will have been copied automatically to your clipboard - Paste this into the Install Location box and then Select Install.", "Access Tools Installation Wizard Step 3/3", this.Font, this.BackColor, this.ForeColor);
            WizardBox.Show(m_ResourceManager.GetString("DownloadInstallerInstruction1"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
            WizardBox.Show(m_ResourceManager.GetString("DownloadInstallerInstruction2"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
            WizardBox.Show(m_ResourceManager.GetString("Install1"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
            informToUpdate();
        }

        public void informToUpdate()
        {
            //WizardBox.Show("Access Tools recommends that you check for the latest updates for new software. \nThis can usually be done by selecting the 'Help' menu and choosing an option such as 'Check for Updates'. \nRegular updates will ensure that your software receives any required security and bug fixes.", "Access Tools Installation Wizard", this.Font, this.BackColor, this.ForeColor);
            WizardBox.Show(m_ResourceManager.GetString("InformToUpdate"), m_ResourceManager.GetString("DownloadWizard"), this.Font, this.BackColor, this.ForeColor);
        }
    }
}
