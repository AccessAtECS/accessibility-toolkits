using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;

namespace Test1
{
    public partial class MenuForm : Form
    {
        private Menu appMenu;
        Rectangle maxSize = new Rectangle();
        Rectangle resetSize;

        public delegate void InvokeDelegate();
        /**
         * Create a new MenuForm, and try to load saved settings.
         */
        public MenuForm()
        {
            appMenu = new Menu();
            InitializeComponent();
            trayIcon.BalloonTipText = "Access Tools is loading. Please Wait...";
            trayIcon.ShowBalloonTip(150);

            String[] settingsTags = new String[4];
            settingsTags[0] = "bgcolour";
            settingsTags[1] = "textcolour";
            settingsTags[2] = "font";
            settingsTags[3] = "fontsize";
            Settings settings;
            try
            {
                XMLparser x = new XMLparser();
                settings = new Settings(x.readXmlFile("Menu_Data\\settings.xml", settingsTags));
            }
            catch (FileNotFoundException e)
            {
                CustomBox.Show("There was a problem restoring your settings. The default settings will be used, and a new settings file will be created.", "Error!", DefaultFont, System.Drawing.Color.White, System.Drawing.Color.Black);
                MenuUpdater updater = new MenuUpdater();
                updater.createSettingsFile();
                XMLparser x = new XMLparser();
                settings = new Settings(x.readXmlFile("Menu_Data\\settings.xml", settingsTags));
            }
            //Set up colours and fonts from settings file
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            try
            {
                changeBackColour(ColorTranslator.FromHtml(settings.getBgColour()));
                changeForeColour(ColorTranslator.FromHtml(settings.getTxtColour()));
                TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
                Font newFont = (Font)toFont.ConvertFromString(settings.getFont());
                this.Font = new Font(newFont.FontFamily, float.Parse(settings.getFontSize()), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
                //statusLabel1.Font = this.Font;
                menuStrip1.Font = this.Font;
                appTreeContextMenu.Font = this.Font;
                fontToolStripMenuItem.Font = this.Font;
                sizeToolStripMenuItem.Font = this.Font;
                newFont = (Font)toFont.ConvertFromString("Microsoft Sans Serif");
                statusLabel1.Font = new Font(newFont.FontFamily, float.Parse(settings.getFontSize()), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
                resetSize = new Rectangle();
                resetSize.Width = 295;
                resetSize.Height = 335;
                menuStrip1.Items.Insert(1, new ToolStripSeparator());
                menuStrip1.Items.Insert(3, new ToolStripSeparator());
                menuStrip1.Items.Insert(5, new ToolStripSeparator());
                appTree.Focus();
            }
            catch
            {
                this.BringToFront();
                this.Focus();
            }
            //Set up logo
            try
            {
                Icon mainIcon = new Icon("Menu_Data\\logo.ico");
                this.Icon = mainIcon;
                trayIcon.Icon = mainIcon;
            }
            catch
            {
                CustomBox.Show("logo.ico could not be located. The default icon will be used", "Error!", this.Font, this.BackColor, this.ForeColor);
            }
            checkScreenSize();
            this.BringToFront();
            this.Focus();
        }

        /**
         * Set up font menu
         * Read menu.xml to obtain app list
         * Display app list in appTree
         */ 
        private void MenuForm_Shown(object sender, EventArgs e)
        {
            trayIcon.BalloonTipText = "Access Tools is populating your menu. Please Wait...";
            trayIcon.ShowBalloonTip(50);
            menuStrip1.BeginInvoke(new InvokeDelegate(createFontMenus)); //make font menu in separate thread
            
            //read xml file
            String[] menuTags = new String[4];
            menuTags[0] = "name";
            menuTags[1] = "path";
            menuTags[2] = "category";
            menuTags[3] = "extra";
            MenuUpdater updater = new MenuUpdater();
            try
            {
                XMLparser x = new XMLparser();
                updater.update(x.readFirstElement("Menu_Data\\menu.xml")); //gets the old count of apps and compares this with a folder count. Updates xml if needed
                appMenu.getCategories().Clear();
                appMenu.getTable().Clear();
                appMenu.populateMenu(x.readXmlFile("Menu_Data\\menu.xml", menuTags)); //extracts information from the xml
            }
            catch (FileNotFoundException ex)
            {
                CustomBox.Show("Could not create menu - menu.xml not found! \nTry restarting the menu to resolve this problem.", "Error!", DefaultFont, System.Drawing.Color.White, System.Drawing.Color.Black);
                updater.createMenuFile();
            }
            
            //Set up menu treeview
            Hashtable menu = appMenu.getTable();
            Hashtable categories = appMenu.getCategories();
            ImageList imgList = new ImageList();
            Bitmap bmpFolderIcon = new Bitmap("Menu_Data\\folderIcon.png"); //icon to represent categories and user folders
            Icon ic = Icon.FromHandle(bmpFolderIcon.GetHicon());
            bool wordIcon = false;
            int wordIndex = 0;
            imgList.Images.Add(ic); //adds the Folder icon as a basic icon to be used for categories
            System.Drawing.Icon appIcon;
            foreach (String cat in categories.Keys)
            {
                appTree.BeginUpdate();
                TreeNode categoryNode = new TreeNode(cat);
                categoryNode.ImageIndex = 0;
                appTree.Nodes.Add(categoryNode);
                foreach (String app in ((ArrayList)categories[cat])) //gets the ArrayList for each category and iterates through its contained applications
                {
                    try //try to find the icon for the app, and add it to both the appTree and contextMenu
                    {
                        String path = (String)((AppShortcut)menu[app]).getPath(); //gets the app from the Menu and extracts its path
                        String extra = (String)((AppShortcut)menu[app]).getExtra(); //gets extra information
                        String appTitle = app;
                        if (!extra.Equals("."))
                        {
                            appTitle = app + " (" + extra + ")"; //inserts the extra information to display
                        }
                        TreeNode appNode = new TreeNode(appTitle);
                        ToolStripMenuItem appTrayItem = new ToolStripMenuItem(app);
                        if (path.EndsWith(".doc") && wordIcon == true) //only load the icon for .doc once
                        {
                            setImageIndex(appNode, appTrayItem, wordIndex);
                        }
                        else
                        {
                            String iconName = "Menu_Data\\appIcons\\" + app + ".ico"; 
                            if (File.Exists(iconName)) //if an icon for this app has previously been extracted
                            {
                                appIcon = System.Drawing.Icon.ExtractAssociatedIcon(iconName); 
                            }
                            else //otherwise store the icon from the exe for quicker launching next time
                            {
                                appIcon = System.Drawing.Icon.ExtractAssociatedIcon(path); //extracts the associated icon for that app
                                System.IO.FileStream saveStream = new FileStream(iconName, FileMode.Create);
                                appIcon.Save(saveStream); //saves new icon for future use
                            }
                            imgList.Images.Add(appIcon);
                            appTree.ImageList = imgList;
                            contextMenuStrip1.ImageList = imgList;
                            appTree.ImageIndex = appTree.ImageList.Images.Count;
                            setImageIndex(appNode, appTrayItem, appTree.ImageIndex);
                            if (path.EndsWith(".doc") && wordIcon == false) //then set the icon for .doc
                            {
                                wordIcon = true;
                                wordIndex = appTree.ImageIndex;
                            }
                        }
                        appNode.ContextMenuStrip = appTreeContextMenu;
                        categoryNode.Nodes.Add(appNode);
                        contextMenuStrip1.Items.Add(appTrayItem);
                    }
                    catch //if no icon can be found, then add the app to to the AppTree without it, but don't add to contextMenu
                    {
                        TreeNode appNode = new TreeNode(app);
                        appNode.ImageIndex = 0;
                        appNode.SelectedImageIndex = 0;
                        categoryNode.Nodes.Add(appNode);
                    }
                }
                categoryNode.SelectedImageIndex = 0;
            }
            ToolStripMenuItem appTrayShow = new ToolStripMenuItem("Show Menu");
            ToolStripMenuItem appTrayExit = new ToolStripMenuItem("Exit Menu");
            contextMenuStrip1.Items.Add(appTrayShow);
            contextMenuStrip1.Items.Add(appTrayExit);
            appTree.Sort();
            appTree.EndUpdate();
            ActiveControl = appTree;
        }

        /**
         * Finds all installed fonts on the computer, and adds an option for each to the menu.
         * Adds font size options for size 10-70.
         */ 
        public void createFontMenus()
        {
            System.Drawing.Text.InstalledFontCollection installedFonts = new System.Drawing.Text.InstalledFontCollection();
            ArrayList fontList = new ArrayList();
            fontList.AddRange(installedFonts.Families);
            foreach (FontFamily f in fontList)
            {
                if (f.IsStyleAvailable(FontStyle.Regular))
                {
                    
                    //fontToolStripMenuItem.DropDownItems.Add(f.Name); //Adds a menu item for each available font
                    fontToolStripMenuItem.Items.Add(f.Name);
                }
            }
            for (int i = 10; i <= 70; i += 2)
            {
                //sizeToolStripMenuItem.DropDownItems.Add(i.ToString()); //Adds a menu item for each font size 10-70
                sizeToolStripMenuItem.Items.Add(i.ToString());
            }  
        }

        /**
         * Sets image index for each application
         */ 
        private void setImageIndex(TreeNode appNode, ToolStripMenuItem appTrayItem, int index)
        {
            appNode.ImageIndex = index;
            appNode.SelectedImageIndex = index;
            appTrayItem.Image = appTree.ImageList.Images[index]; //add the image to the system tray menu             
        }

        /**
         * Saves the current settings and closes the program
         * If the settings can't be saved, then a new settings file is created and another attempt to save is made
         */
        private void saveAndClose()
        {
            MenuUpdater mu = new MenuUpdater();
            try
            {
                mu.saveSettings(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString());
            }
            catch (Exception ex) //if the settings file could not be found
            {
                mu.createSettingsFile(); //create a new settings file
                mu.saveSettings(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString());
            }
            Application.Exit();
        }

        /**
         * Executes the selected application
         */
        private void launchApp()
        {
            if (appTree.SelectedNode != (null))
            {
                char[] extraSplit = "(".ToCharArray();
                String selected = appTree.SelectedNode.Text;
                try
                {
                    selected = selected.Substring(0, selected.LastIndexOfAny(extraSplit) - 1); //removes the extra information to leave just the app name
                }
                catch
                {
                }
                if (!appMenu.getCategories().ContainsKey(selected)) //check the selected item is not a category heading
                {
                    statusLabel1.Text = "Launching"; 
                    this.Refresh();
                    try
                    {
                        String inputPath = (String)((AppShortcut)appMenu.getTable()[selected]).getPath(); //find the selected app in the menu table, and get it's path
                        System.Diagnostics.Process launched = System.Diagnostics.Process.Start(@inputPath); //start a new process using the exe path
                    }
                    catch (Exception e)
                    {
                        CustomBox.Show("Application not found! \nThis application will no longer be shown in the menu.", "Error!", this.Font, appTree.BackColor, appTree.ForeColor);
                        MenuUpdater mu = new MenuUpdater();
                        mu.remove(selected); //removes the app from the xml file
                        appTree.Nodes.Remove(appTree.SelectedNode); //removes the app from the menu
                        this.BringToFront();
                        this.Focus();
                    }
                    statusLabel1.Text = "Ready";
                }
            }
        }

        /**
         * Increases or decreases the font size depending on the given parameter.
         * Shows the new font size in the status label.
         */ 
        private void changeFontSize(int change)
        {
            float fontSize = this.Font.Size;
            fontSize = fontSize + change;
            if (fontSize >= 10)
            {
                this.Font = new Font(this.Font.FontFamily, fontSize, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
                statusLabel1.Font = this.Font;
                menuStrip1.Font = this.Font;
                appTreeContextMenu.Font = this.Font;
                fontToolStripMenuItem.Font = this.Font;
                sizeToolStripMenuItem.Font = this.Font;
                TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
                Font newFont = (Font)toFont.ConvertFromString("Microsoft Sans Serif");
                statusLabel1.Font = new Font(newFont.FontFamily, fontSize, newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            }
            statusLabel1.Text = "Text Size: " + this.Font.Size;
            //defaultMenu.Size = helpMenu.Size;
            checkScreenSize();
        }

        /**
         * Changes the colour scheme depending on the int received
         */ 
        private void colourComboChanged(int i)
        {
            Color bg = Color.Black;
            Color fg = Color.Black;
            if (i == 0)
            {
                fg = Color.Black;
                bg = Color.White;
            }
            if (i == 1)
            {
                fg = Color.White;
                bg = Color.Black;
            }
            if (i == 2)
            {
                fg = Color.Yellow;
                bg = Color.Navy;
            }
            if (i == 3)
            {
                fg = Color.Black;
                bg = Color.Yellow;
            }
            if (i == 4)
            {
                fg = Color.Black;
                bg = Color.AliceBlue;
            }
            if (i == 5)
            {
                fg = Color.Black;
                bg = Color.Cornsilk;
            }
            if (i == 6)
            {
                fg = Color.Black;
                bg = Color.MistyRose;
            }
            changeForeColour(fg);
            changeBackColour(bg);
        }

        /**
         * Reverses the colour scheme
         */ 
        private void colourSchemeOrderChanged()
        {
            Color tempB = appTree.BackColor;
            Color tempF = appTree.ForeColor;
            appTree.ForeColor = tempB;
            changeBackColour(tempF);
            changeForeColour(tempB);
        }

        /** 
         * Changes the foreground colour of all components
         */
        private void changeForeColour(Color fg)
        {
            appTree.ForeColor = fg;
            menuStrip1.ForeColor = fg;
            downloadMenuItem.ForeColor = fg;
            settingsBg.ForeColor = fg;
            settingsColourScheme.ForeColor = fg;
            settingsDefaultFont.ForeColor = fg;
            settingsFg.ForeColor = fg;
            settingsFont.ForeColor = fg;
            settingsReverse.ForeColor = fg;
            fileMenuExit.ForeColor = fg;
            aboutToolStripMenuItem1.ForeColor = fg;
            helpToolStripMenuItem.ForeColor = fg;
            keyboardShortcutsToolStripMenuItem.ForeColor = fg;
            fontToolStripMenuItem.ForeColor = fg;
            sizeToolStripMenuItem.ForeColor = fg;
            moreBgMenuItem.ForeColor = fg;
            moreFgMenuItem.ForeColor = fg;
            foreach (ToolStripMenuItem t in settingsBg.DropDownItems)
            {
                if (!t.Text.Equals("Custom..."))
                {
                    t.ForeColor = fg;
                    Color temp = checkClash(t.BackColor, false, false);
                    if (temp != t.BackColor)
                    {
                        t.Enabled = false;
                        t.Visible = false;
                    }
                    else
                    {
                        t.Enabled = true;
                        t.Visible = true;
                    }
                }
            }
            /*foreach (ToolStripMenuItem t in fontToolStripMenuItem.DropDownItems)
            {
                t.ForeColor = fg;
            }*/
            fontToolStripMenuItem.ForeColor = fg;
            /*foreach (ToolStripMenuItem t in sizeToolStripMenuItem.DropDownItems)
            {
                t.ForeColor = fg;
            }*/
            sizeToolStripMenuItem.ForeColor = fg;
        }

        /**
         * Changes the background colour of all components
         */
        private void changeBackColour(Color bg)
        {
            appTree.BackColor = bg;
            panel1.BackColor = bg;
            menuStrip1.BackColor = bg;
            downloadMenuItem.BackColor = bg;
            settingsBg.BackColor = bg;
            settingsColourScheme.BackColor = bg;
            settingsDefaultFont.BackColor = bg;
            settingsFg.BackColor = bg;
            settingsFont.BackColor = bg;
            settingsReverse.BackColor = bg;
            fileMenuExit.BackColor = bg;
            aboutToolStripMenuItem1.BackColor = bg;
            helpToolStripMenuItem.BackColor = bg;
            keyboardShortcutsToolStripMenuItem.BackColor = bg;
            fontToolStripMenuItem.BackColor = bg;
            sizeToolStripMenuItem.BackColor = bg;
            moreFgMenuItem.BackColor = bg;
            moreBgMenuItem.BackColor = bg;
            foreach (ToolStripMenuItem t in settingsFg.DropDownItems)
            {
                if (!t.Text.Equals("Custom..."))
                {
                    t.BackColor = bg;
                    Color temp = checkClash(t.ForeColor, true, false);
                    if (temp != t.ForeColor)
                    {
                        t.Enabled = false;
                        t.Visible = false;
                    }
                    else
                    {
                        t.Enabled = true;
                        t.Visible = true;
                    }
                }
            }
            /*foreach (ToolStripMenuItem t in fontToolStripMenuItem.DropDownItems)
            {
                t.BackColor = bg;
            }*/
            fontToolStripMenuItem.BackColor = bg;
            /*foreach (ToolStripMenuItem t in sizeToolStripMenuItem.DropDownItems)
            {
                t.BackColor = bg;
            }*/
            sizeToolStripMenuItem.BackColor = bg;
        }

        /**
         * Calculates contrast ratio between colours to ensure that the text will be readable
         */ 
        public Color checkClash(Color newColor, bool text, bool userCaused)
        {
            if (text) //if it is the text colour that is being changed
            {
                if (newColor.Equals(appTree.BackColor))
                {
                    if (userCaused)
                        CustomBox.Show("You have attempted to change the colour so that the background would be the same as the text. \nThis has been cancelled to avoid problems.", "Warning!", this.Font, this.BackColor, this.ForeColor);
                    return appTree.ForeColor;
                }
                else
                {
                    if (checkRatio(appTree.BackColor, newColor) == true)
                        return newColor;
                    else
                    {
                        if (userCaused)
                            CustomBox.Show("Changing to this colour would give a poor luminosity ratio and would therefore be difficult to read. \nThis has been cancelled to avoid problems.", "Warning!", this.Font, this.BackColor, this.ForeColor);
                        return appTree.ForeColor;
                    }
                }
            }
            else
            {
                if (newColor.Equals(appTree.ForeColor))
                {
                    if (userCaused)
                        CustomBox.Show("You have attempted to change the colour so that the background would be the same as the text. \nThis has been cancelled to avoid problems.", "Warning!", this.Font, this.BackColor, this.ForeColor);
                    return appTree.BackColor;
                }
                else
                {
                    if (checkRatio(newColor, appTree.ForeColor) == true)
                        return newColor;
                    else
                    {
                        if (userCaused)
                            CustomBox.Show("Changing to this colour would give a poor luminosity ratio and would therefore be difficult to read. \nThis has been cancelled to avoid problems.", "Warning!", this.Font, this.BackColor, this.ForeColor);
                        return appTree.BackColor;
                    }
                }
            }
        }

        /**
         * Contrast ratio calculation using WCAG 2.0 guidelines
         */ 
        public bool checkRatio(Color back, Color fore)
        {
            decimal backR = Decimal.Divide(back.R, 255);
            decimal backG = Decimal.Divide(back.G, 255);
            decimal backB = Decimal.Divide(back.B, 255);
            backR = relLuminance(backR);
            backG = relLuminance(backG);
            backB = relLuminance(backB);

            decimal backVal = (((decimal)0.2126 * backR) + ((decimal)0.7152 * backG) + ((decimal)0.0722 * backB));

            decimal foreR = Decimal.Divide(fore.R, 255);
            decimal foreG = Decimal.Divide(fore.G, 255);
            decimal foreB = Decimal.Divide(fore.B, 255);
            foreR = relLuminance(foreR);
            foreG = relLuminance(foreG);
            foreB = relLuminance(foreB);

            decimal foreVal = (((decimal)0.2126 * foreR) + ((decimal)0.7152 * foreG) + ((decimal)0.0722 * foreB));

            decimal result;
            if (foreVal > backVal)
                result = ((foreVal + (decimal)0.05) / (backVal + (decimal)0.05));
            else result = ((backVal + (decimal)0.05) / (foreVal + (decimal)0.05));

            if (result >= (decimal)4.5)
                return true;
            else return false;

        }

        /**
         * Calculates the relative luminance, used in the contrast ratio calculation
         */ 
        public decimal relLuminance(decimal num)
        {
            decimal num2;
            if (num <= (decimal)0.03928)
            {
                num2 = (num / (decimal)12.92);
            }
            else num2 = (decimal)(Math.Pow((double)((num + (decimal)0.055) / (decimal)1.055), 2.4));
            return num2;
        }

        /*
         * Called when CTRL + Z is pressed, to fix any layout issues, or to revert back to default settings
         * Calls fontReset to restore the default font.
         * Changes the colour scheme to black on white.
         * Resets the window size and location.
         */ 
        private void resetAll()
        {
            fontReset();
            changeBackColour(Color.White);
            changeForeColour(Color.Black);
            this.Size = resetSize.Size;
            this.MinimumSize = resetSize.Size;
            this.Location = new Point(0, 0);
            statusLabel1.Text = "Text Size: " + this.Font.Size;
            checkScreenSize();
        }

        /**
         * Resets the font and updates minimum size.
         */ 
        private void fontReset()
        {
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont = (Font)toFont.ConvertFromString("Microsoft Sans Serif");
            this.Font = new Font(newFont.FontFamily, float.Parse("10.0"), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            statusLabel1.Font = this.Font;
            menuStrip1.Font = this.Font;
            appTreeContextMenu.Font = this.Font;
            fontToolStripMenuItem.Font = this.Font;
            sizeToolStripMenuItem.Font = this.Font;

            this.Size = resetSize.Size;
            this.MinimumSize = resetSize.Size;
            checkScreenSize();
            this.WindowState = FormWindowState.Normal;
            this.Refresh();
        }

        /**
         * Checks the screen size to ensure that the window can not become too big.
         */ 
        private void checkScreenSize()
        {
            maxSize.Width = (Screen.PrimaryScreen.WorkingArea.Width);
            maxSize.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = maxSize.Size;
            appTree.Height = this.Height - menuStrip1.Height - (2 * statusStrip1.Height);
            appTree.Scrollable = true;
            if (this.Height == this.MaximumSize.Height || this.Width == this.MaximumSize.Width)
            {
                trayIcon.BalloonTipText = "The menu window is now larger than your screen. Press the CTRL + Z to fix any layout problems.";
                trayIcon.ShowBalloonTip(250);
            }
        }

        /**
         * General key commands that are also called whenever the KeyDown occurs on the other Form components
         */
        private void MenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
                settingsFont.ShowDropDown();
            if (e.KeyCode == Keys.B && e.Control)
                settingsBg.ShowDropDown();
            if (e.KeyCode == Keys.T && e.Control)
                settingsFg.ShowDropDown();
            if (e.KeyCode == Keys.D && e.Control)
                fontReset();
            if (e.KeyCode == Keys.R && e.Control)
                colourSchemeOrderChanged();
            if (e.KeyCode == Keys.D1 && e.Control)
                colourComboChanged(0);
            if (e.KeyCode == Keys.D2 && e.Control)
                colourComboChanged(1);
            if (e.KeyCode == Keys.D3 && e.Control)
                colourComboChanged(2);
            if (e.KeyCode == Keys.D4 && e.Control)
                colourComboChanged(3);
            if (e.KeyCode == Keys.D5 && e.Control)
                colourComboChanged(4);
            if (e.KeyCode == Keys.D6 && e.Control)
                colourComboChanged(5);
            if (e.KeyCode == Keys.D7 && e.Control)
                colourComboChanged(6);
            if (e.KeyCode == Keys.Oemplus && e.Control)
                changeFontSize(2);
            if (e.KeyCode == Keys.OemMinus && e.Control)
                changeFontSize(-2);
            if (e.KeyCode == Keys.Escape)
                saveAndClose();
            if (e.KeyCode == Keys.Z && e.Control)
                resetAll();
            if (e.KeyCode == Keys.Alt)
                menuStrip1.Focus();
            if (e.KeyCode == Keys.F1)
                System.Diagnostics.Process.Start("Access_Tools_Instructions.pdf");
        }

        /**
         * Saves settings and closes
         */ 
        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveAndClose();
        }

        /**
         * Checks if the window has been minimized and if so hides it in the system tray and shows a balloon tip
         */
        private void MenuForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                trayIcon.BalloonTipText = "Access Tools is still running and can be accessed through this icon";
                trayIcon.ShowBalloonTip(200);
            }
        }

        /**
         * Selects the top node when tabbing into the appTree
         */ 
        private void appTree_Enter(object sender, EventArgs e)
        {
            try
            {
                appTree.SelectedNode = appTree.Nodes[0];
            }
            catch
            {
                //if there is nothing in the list
            }
        }

        /**
        * Displays information message when a single click is made on the appTree
        */
        private void appTree_Click(object sender, EventArgs e)
        {
            if (appTree.SelectedNode != (null))
            {
                statusLabel1.Text = "Double click an app to launch";
            }
        }         

        /**
         * Launch the application that is double-clicked
         */
        private void appTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            launchApp();
        }

        /**
         * Keyboard listener for when the appTree is in focus.
         * If Enter key is pressed, then call the launchApp method
         */
        private void appTree_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                launchApp();
            }
            if (e.KeyData == Keys.Up)
            {
                if (appTree.SelectedNode != (null))
                {
                    statusLabel1.Text = "Press Enter to launch";
                    appTree.SelectedNode.EnsureVisible();
                }
            }
            if (e.KeyData == Keys.Down)
            {
                if (appTree.SelectedNode != (null))
                {
                    statusLabel1.Text = "Press Enter to launch";
                    appTree.SelectedNode.EnsureVisible();
                }
            }
            else MenuForm_KeyDown(sender, e);
        }         

        /**
         * Save settings and close
         */ 
        private void fileMenuExit_Click(object sender, EventArgs e)
        {
            saveAndClose();
        }

        /**
         * Provides information on downloading additional applications
         */ 
        private void downloadMenuItem_Click(object sender, EventArgs e)
        {
            bool notReady = true;
            notReady = false;
            if (notReady)
            {
                CustomBox.Show("Coming Soon! \nThis feature will allow new applications to be downloaded and added to the menu automatically. \nPlease visit http://access.ecs.soton.ac.uk to view progress on this feature. \nIn the meantime, links to new applications are available at http://access.ecs.soton.ac.uk/penapps \nThis website will be launched when you close this message.", "Download Information", this.Font, appTree.BackColor, appTree.ForeColor);
                System.Diagnostics.Process.Start("http://access.ecs.soton.ac.uk/penapps");
                this.BringToFront();
                this.Focus();
            }
            else
            {
                this.BeginInvoke(new InvokeDelegate(startDownloader));
            }
        }

        public void startDownloader()
        {
            Downloader dl = new Downloader(this.Font, appTree.BackColor, appTree.ForeColor);
            dl.Show();
        }

        /**
         * Changes to selected colour scheme
         */ 
        private void blackOnWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(0);
        }

        /**
         * Changes to selected colour scheme
         */ 
        private void whiteOnBlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(1);
        }

        /**
         * Changes to selected colour scheme
         */ 
        private void yellowOnBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(2);
        }

        /**
         * Changes to selected colour scheme
         */ 
        private void blackOnYellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(3);
        }

        /**
         * Changes to selected colour scheme
         */ 
        private void blackOnPaleBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(4);
        }

        /**
         * Changes to selected colour scheme
         */ 
        private void blackOnCreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(5);
        }

        /**
         * Changes to selected colour scheme
         */ 
        private void blackOnPinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(6);
        }

        /**
         * Reverses colour scheme
         */ 
        private void settingsReverse_Click(object sender, EventArgs e)
        {
            colourSchemeOrderChanged();
        }

        /**
         * Changes background colour to the selected colour
         */ 
        private void settingsBg_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!e.ClickedItem.Text.Equals("Custom..."))
            {
                Color bg = appTree.BackColor;
                bg = checkClash(e.ClickedItem.BackColor, false, false);
                changeBackColour(bg);
            }
        }

        /**
         * Changes foreground colour to the selected colour
         */
        private void settingsFg_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!e.ClickedItem.Text.Equals("Custom..."))
            {
                Color fg = appTree.ForeColor;
                fg = checkClash(e.ClickedItem.ForeColor, true, false);
                changeForeColour(fg);
            }
        }

        /**
         * Changes background colour to a custom colour
         */ 
        private void moreBgMenuItem_Click(object sender, EventArgs e)
        {
            Color toReturn = appTree.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                toReturn = checkClash(colorDialog1.Color, false, true);
            }
            changeBackColour(toReturn);
        }

        /**
         * Changes foreground colour to a custom colour
         */ 
        private void moreFgMenuItem_Click(object sender, EventArgs e)
        {
            Color toReturn = appTree.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                toReturn = checkClash(colorDialog1.Color, true, true);
            }
            changeForeColour(toReturn);
        }

        /**
         * Changes font type to the selected font
         */ 
        /*private void fontToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            String selected = e.ClickedItem.Text;
            Font newFont = (Font)toFont.ConvertFromString(selected);
            this.Font = new Font(newFont.FontFamily, this.Font.Size, newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            statusStrip1.Font = this.Font;
            menuStrip1.Font = this.Font;
            fontToolStripMenuItem.Font = this.Font;
            sizeToolStripMenuItem.Font = this.Font;
        }*/

        private void fontToolStripMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            String selected = fontToolStripMenuItem.SelectedItem.ToString();
            Font newFont = (Font)toFont.ConvertFromString(selected);
            this.Font = new Font(newFont.FontFamily, this.Font.Size, newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            //statusStrip1.Font = this.Font;
            menuStrip1.Font = this.Font;
            newFont = (Font)toFont.ConvertFromString("Microsoft Sans Serif");
            statusLabel1.Font = new Font(newFont.FontFamily, appTree.Font.Size, newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            statusLabel1.Text = "Press CTRL + Z to reset settings";
            fontToolStripMenuItem.Font = this.Font;
            sizeToolStripMenuItem.Font = this.Font;
            fontToolStripMenuItem.Text = "Font";
            checkScreenSize();
            this.MinimumSize = resetSize.Size;
            fontToolStripMenuItem.Focus();
        }

        /**
         * Changes font size to the selected size
         */
        /*private void sizeToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int selected = int.Parse(e.ClickedItem.Text);
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font)); 
            Font newFont = appTree.Font;
            this.Font = new Font(newFont.FontFamily, selected, newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            statusLabel1.Font = this.Font;
            menuStrip1.Font = this.Font;
            appTreeContextMenu.Font = this.Font;
            fontToolStripMenuItem.Font = this.Font;
            sizeToolStripMenuItem.Font = this.Font;
            statusLabel1.Text = "";
            checkScreenSize();
        }*/

        private void sizeToolStripMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = int.Parse(sizeToolStripMenuItem.SelectedItem.ToString());
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont = appTree.Font;
            this.Font = new Font(newFont.FontFamily, selected, newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            //statusLabel1.Font = this.Font;
            menuStrip1.Font = this.Font;
            appTreeContextMenu.Font = this.Font;
            fontToolStripMenuItem.Font = this.Font;
            sizeToolStripMenuItem.Font = this.Font;
            newFont = (Font)toFont.ConvertFromString("Microsoft Sans Serif");
            statusLabel1.Font = new Font(newFont.FontFamily, selected, newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            statusLabel1.Text = "";
            checkScreenSize();
            sizeToolStripMenuItem.Text = "Size";
            sizeToolStripMenuItem.Focus();
        }

        /**
         * Resets the font
         */ 
        private void settingsDefaultFont_Click(object sender, EventArgs e)
        {
            fontReset();
        }

        /**
         * Shows the keyboard shortcuts in a popup window.
         */ 
        private void keyboardShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set up shortcut keys
            ArrayList shortcutKeys = new ArrayList();
            shortcutKeys.Add("CTRL + +, Increase Text Size");
            shortcutKeys.Add("CTRL + -, Decrease Text Size");
            shortcutKeys.Add("CTRL + F, Change Font");
            shortcutKeys.Add("CTRL + D, Set Default Font");
            shortcutKeys.Add("CTRL + T, Change Text Colour");
            shortcutKeys.Add("CTRL + B, Change Background Colour");
            shortcutKeys.Add("CTRL + R, Reverse Colours");
            shortcutKeys.Add("CTRL + [numbers], Change Colour Combinations");
            shortcutKeys.Add("CTRL + Z, Reset Colours and Font");
            shortcutKeys.Add("ESC, Close AccessTools");
            shortcutKeys.Add("F1, Launch Help File");

            String shortcuts = "";
            Char[] separator = ",".ToCharArray();
            foreach (String shortcut in shortcutKeys)
            {
                String[] subs = shortcut.Split(separator);
                shortcuts += subs[0] + " : " + subs[1] + ". \n";
            }
            CustomBox.Show(shortcuts, "Keyboard Shortcuts", this.Font, appTree.BackColor, appTree.ForeColor);
            this.BringToFront();
            this.Focus();
        }

        /**
         * Shows the about window
         * For new versions, change the versionCreatedBy and versionContactAddress to show in the about box.
         */ 
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            double version = 1.4;
            String versionCreatedBy = "Chris Phethean";
            String versionContactAddress = "http://users.ecs.soton.ac.uk/cjp106";
            CustomBox.Show("DOWNLOADER BETA VERSION \nMenu \nVersion " + version + "\nVersion created by: " + versionCreatedBy + "\n" + versionContactAddress + " \n\nhttp://access.ecs.soton.ac.uk/#0 \nECS Accessibility Projects, \nLearning Societies Lab, \nSchool of Electronics and Computer Science, \nUniversity of Southampton. \nFunded by LATEU. \nContact: Dr Mike Wald: http://www.ecs.soton.ac.uk/people/mw ", "Access Tools - About", this.Font, appTree.BackColor, appTree.ForeColor);
            this.BringToFront();
            this.Focus();
        }     

        /**
         * Restores the window if the user doubleclicks on the icon in the system tray
         */ 
        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        /** 
         * Restores the window if the user clicks on the notification balloon that is shown when the window minimizes
         */
        private void trayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        /**
         * Restores the window if the user Right-clicks on the system tray icon and selects Show
         */ 
        private void itemShow_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        /**
         * Exits the menu completely if the user Right-clicks on the system tray icon and selects Exit
         */ 
        private void itemExit_Click(object sender, EventArgs e)
        {
            saveAndClose();
        }

        /**
         * Gets the path of the selected application and launches it
         */ 
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            String selected = e.ClickedItem.Text;
            if (selected.Equals("Show Menu"))
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            }
            else if (selected.Equals("Exit Menu"))
            {
                saveAndClose();
            }
            else
            //if (!(selected.Equals("Show Menu") || selected.Equals("Exit Menu")))
            {
                String inputPath = (String)((AppShortcut)appMenu.getTable()[selected]).getPath();
                try
                {
                    System.Diagnostics.Process launched = System.Diagnostics.Process.Start(@inputPath);
                }
                catch (Exception ex)
                {
                CustomBox.Show("Application not found! \nThis application will not be shown when the menu is next loaded", "Error!", this.Font, appTree.BackColor, appTree.ForeColor);
                MenuUpdater mu = new MenuUpdater();
                mu.remove(selected);
                this.BringToFront();
                this.Focus();
                }
            }

        }

        private void appTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                appTree.SelectedNode = e.Node;
            }
        }

        private void launchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launchApp();
        }

        private void descriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (appTree.SelectedNode != (null))
            {
                String selected = appTree.SelectedNode.Text;
                char[] extraSplit = "(".ToCharArray();
                try
                {
                    selected = selected.Substring(0, selected.LastIndexOfAny(extraSplit) - 1);
                }
                catch
                {
                }
                String current = appTree.SelectedNode.Text.Substring(appTree.SelectedNode.Text.LastIndexOfAny(extraSplit) + 1);
                if (current.Equals(selected))
                {
                    current = "";
                }
                else
                {
                    current = current.Substring(0, current.Length - 1);
                }
                String description = CustomBox.Show(current, "Edit Description - " + selected, this.Font, this.BackColor, this.ForeColor);
                MenuUpdater mu = new MenuUpdater();
                try
                {
                    if (description.Equals(""))
                    {
                        mu.editExtra(selected, ".");
                    }
                    else
                        mu.editExtra(selected, description);
                    ((AppShortcut)appMenu.getTable()[selected]).setExtra(description);
                    String extra = (String)((AppShortcut)appMenu.getTable()[selected]).getExtra();
                    TreeNode toChange = appTree.SelectedNode;
                    appTree.BeginUpdate();
                    if (extra.Equals(""))
                    {
                        toChange.Text = selected;
                    }
                    else
                    {
                        toChange.Text = selected + " (" + extra + ")";
                    }
                    appTree.EndUpdate();
                    appTree.Refresh();                    
                }
                catch
                {
                    CustomBox.Show("Could not update description", "Error", this.Font, this.BackColor, this.ForeColor);
                }
            }
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomBox.Show("This applicaiton will not be shown on the menu until it is reloaded. \n(This application has not been removed from your pendrive.)", "Access Tools", this.Font, appTree.BackColor, appTree.ForeColor);
            appTree.Nodes.Remove(appTree.SelectedNode);
        }

        private void fontToolStripMenuItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                settingsFont.HideDropDown();
            if (e.KeyCode == Keys.Z && e.Control)
            {
                settingsFont.HideDropDown();
                resetAll();
            }
        }

        private void sizeToolStripMenuItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                settingsFont.HideDropDown();
        }

        private void defaultMenu_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void defaultMenu_MouseEnter(object sender, EventArgs e)
        {
            statusLabel1.Text = "Reset all settings";
        }

        private void defaultMenu_MouseLeave(object sender, EventArgs e)
        {
            statusLabel1.Text = " ";
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void settingsFont_DropDownOpening(object sender, EventArgs e)
        {
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont = (Font)toFont.ConvertFromString("Microsoft Sans Serif");
            defaultFontToolStripMenuItem.Font = new Font(newFont.FontFamily, this.Font.Size, newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont); 
        }

        private void defaultFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontReset();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Access_Tools_Instructions.pdf");
            }
            catch
            {
                CustomBox.Show("Could not locate help file", "Error!", this.Font, appTree.BackColor, appTree.ForeColor);
            }
        }
    }
}
