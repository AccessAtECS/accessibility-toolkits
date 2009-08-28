using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Test1
{
    public partial class MenuForm : Form
    {
        private Menu appMenu;
        private Hashtable menu;
        private Hashtable categories;
        private MenuUpdater mu;
        private ArrayList keys;
        private ArrayList messages;
        private bool tooLarge;
        Rectangle maxSize = new Rectangle();
        Rectangle resetSize;

        /**
         * Create a new MenuForm, and try to load saved settings.
         */
        public MenuForm(Settings settings, Menu appMenu, MenuUpdater updater)
        {
            this.appMenu = appMenu;
            this.menu = appMenu.getTable();
            this.categories = appMenu.getCategories();
            this.mu = updater;
            InitializeComponent();
            
           
            //Set up logo
            Bitmap bmpLogo = new Bitmap("Menu_Data\\logo.png");
            Icon mainIcon = Icon.FromHandle(bmpLogo.GetHicon());
            this.Icon = mainIcon;
            notifyIcon1.Icon = mainIcon;
            
            ImageList imgList = new ImageList();            
            //Set up menu treeview
            Bitmap bmpIcon = new Bitmap("Menu_Data\\icon.png");
            Icon ic = Icon.FromHandle(bmpIcon.GetHicon());
            
            imgList.Images.Add(ic); //adds the Folder icon as a basic icon to be used for categories
            foreach (String cat in categories.Keys)
            {
                appTree.BeginUpdate();
                TreeNode categoryNode = new TreeNode(cat);
                categoryNode.ImageIndex = 0;
                appTree.Nodes.Add(categoryNode); 
                foreach (String app in ((ArrayList)categories[cat])) //gets the ArrayList for each category and iterates through its contained applications
                {
                    try
                    {
                        String path = (String)((AppShortcut)menu[app]).getPath(); //gets the app from the Menu and extracts its path
                        System.Drawing.Icon appIcon = System.Drawing.Icon.ExtractAssociatedIcon(path);
                        imgList.Images.Add(appIcon);                        
                        TreeNode appNode = new TreeNode(app);
                        appTree.ImageList = imgList;
                        appTree.ImageIndex = appTree.ImageList.Images.Count;
                        appNode.ImageIndex = appTree.ImageIndex;
                        appNode.SelectedImageIndex = appNode.ImageIndex;
                        categoryNode.Nodes.Add(appNode);
                        ToolStripMenuItem appTrayItem = new ToolStripMenuItem(app);
                        contextMenuStrip1.Items.Add(appTrayItem);
                    }
                    catch
                    {
                        TreeNode appNode = new TreeNode(app);
                        appNode.ImageIndex = 0;
                        appNode.SelectedImageIndex = 0;
                        categoryNode.Nodes.Add(appNode);
                    }
                }
                categoryNode.SelectedImageIndex = 0;                 
            }
            appTree.Sort();
            appTree.EndUpdate();
            ActiveControl = appTree;

            //set up font menu
            System.Drawing.Text.InstalledFontCollection installedFonts = new System.Drawing.Text.InstalledFontCollection();
            ArrayList fontList = new ArrayList();
            fontList.AddRange(installedFonts.Families);
            foreach (FontFamily f in fontList)
            {
                if (f.IsStyleAvailable(FontStyle.Regular))
                {
                    fontToolStripMenuItem.DropDownItems.Add(f.Name);
                }
            }
            for (int i = 10; i < 72; i += 2)
            {
                sizeToolStripMenuItem.DropDownItems.Add(i.ToString());
            }

            //set up shortcuts
            keys = new ArrayList();
            keys.Add("CTRL + +, Increase Text Size");
            keys.Add("CTRL + -, Decrease Text Size");
            keys.Add("CTRL + F, Change Font");
            keys.Add("CTRL + D, Set Default Font");
            keys.Add("CTRL + T, Change Text Colour");
            keys.Add("CTRL + B, Change Background Colour");
            keys.Add("CTRL + R, Reverse Colours");
            keys.Add("CTRL + [numbers], Change Colour Combinations");
            keys.Add("ESC, Reset Colours and Font");

            messages = new ArrayList();
            Char[] separator = ",".ToCharArray();
            foreach (String shortcut in keys)
            {
                String[] subs = shortcut.Split(separator);
                messages.Add("Press " + subs[0] + " to " + subs[1] + ".");
            }
            


            //Set up colours and fonts from settings file
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            try
            {
                Color bgColour = ColorTranslator.FromHtml(settings.getBgColour());
                Color fgColour = ColorTranslator.FromHtml(settings.getTxtColour());
                changeBackColour(bgColour);
                changeForeColour(fgColour);

                TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
                Font newFont = (Font)toFont.ConvertFromString(settings.getFont());
                this.Font = new Font(newFont.FontFamily, float.Parse(settings.getFontSize()), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
                statusLabel.Font = this.Font;
                menuStrip1.Font = this.Font;

                resetSize = new Rectangle();
                resetSize.Width = 295;
                resetSize.Height = 335;
                menuStrip1.Items.Insert(1, new ToolStripSeparator());
                menuStrip1.Items.Insert(3, new ToolStripSeparator());
                appTree.Focus();
            }
            catch(Exception ex)
            {
                CustomBox.Show("There was a problem restoring your settings. The default settings will be used, and a new settings file will be created.", "Error!", this.Font, appTree.BackColor, appTree.ForeColor);
                mu.createSettingsFile();
                this.BringToFront();
                this.Focus();
            }
            checkScreenSize();
            appTree.ExpandAll();
            colorOptions.AllowFullOpen = false;
        }

        /**
         * Creates a new XMLupdater to store the user's settings.
         */
        private void exitButton_Click(object sender, EventArgs e)
        {
            saveAndClose();
        }
        
        /**
         * Launch the selected application
         */
        private void launchButton_Click(object sender, EventArgs e)
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
                    statusLabel.Text = "Press Enter to launch";
                
                    appTree.SelectedNode.EnsureVisible();
                }
            }
            if (e.KeyData == Keys.Down)
            {
                if (appTree.SelectedNode != (null))
                {
                    statusLabel.Text = "Press Enter to launch";
                   
                    appTree.SelectedNode.EnsureVisible();
                }
            }
            else MenuForm_KeyDown(sender, e);
        }

        private void appTree_Click(object sender, EventArgs e)
        {
            if (appTree.SelectedNode != (null))
            {
                statusLabel.Text = "Double click an app to launch";
            }
        }
               
        /**
         * Executes the selected application
         */
        private void launchApp()
        {
            if (appTree.SelectedNode != (null))
            {
                String selected = appTree.SelectedNode.Text;
                if (!categories.ContainsKey(selected)) //check the selected item is not a category heading
                {
                    statusLabel.Text = "Launching";
                    this.Refresh();
                    String inputPath = (String)((AppShortcut)menu[selected]).getPath();
                    try
                    {
                        System.Diagnostics.Process launched = System.Diagnostics.Process.Start(@inputPath);
                        
                    }
                    catch (Exception e)
                    {
                        CustomBox.Show("Application not found! \nThis application will not be shown when the menu is next loaded", "Error!", this.Font, appTree.BackColor, appTree.ForeColor);
                        mu.remove(selected);
                        this.BringToFront();
                        this.Focus();
                    }
                    statusLabel.Text = "Ready";
                    
                }
            }
        }

        private void changeFontSize(int change)
        {
            int prevSize = this.Size.Height;
            float fontSize = this.Font.Size;
            fontSize = fontSize + change;
            if (fontSize >= 10)
            {
                this.Font = new Font(this.Font.FontFamily, fontSize, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
                statusLabel.Font = this.Font;
                menuStrip1.Font = this.Font;
            }
            if (!tooLarge)
            {
                statusLabel.Text = "Text Size: " + this.Font.Size;
            }
            else
            {
                statusLabel.Text = "Text Size: " + this.Font.Size;
            }
            int newSize = this.Size.Height;
            checkScreenSize();
                
        }

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

        /*private void downloadButton_Click(object sender, EventArgs e)
        {
            CustomBox.Show("Coming Soon! \nThis feature will allow new applications to be downloaded and added to the menu automatically. \nIn the meantime, please visit http://access.ecs.soton.ac.uk to manually download additional applications. \nThis website will be launched when you close this message.", "Download Information", this.Font, appTree.BackColor, appTree.ForeColor);
            System.Diagnostics.Process.Start("http://access.ecs.soton.ac.uk/blog");
            this.BringToFront();
            this.Focus();       
        }*/

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
            if (e.KeyCode == Keys.Oemplus&& e.Control)
                changeFontSize(2);
            if (e.KeyCode == Keys.OemMinus && e.Control)
                changeFontSize(-2);
            if (e.KeyCode == Keys.Escape)
                resetAll();
            if (e.KeyCode == Keys.Alt)
                menuStrip1.Focus();
        }

        /*private void launchButton_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void fontButton_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void colourButton_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void textColourButton_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void downloadButton_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void exitButton_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void flipColourButton_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void defaultFontButton_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void btnMiniLaunch_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void btnMiniOptions_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void colourComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }

        private void menuStrip1_KeyDown(object sender, KeyEventArgs e)
        {
            MenuForm_KeyDown(sender, e);
        }
        */

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAndClose();
        }    

        private void colourSchemeOrderChanged()
        {
            Color tempB = appTree.BackColor;
            Color tempF = appTree.ForeColor;
            appTree.ForeColor = tempB;
            //appTree.BackColor = tempF;
            changeBackColour(tempF);
            changeForeColour(tempB);
        }

        private void appTree_DoubleClick(object sender, EventArgs e)
        {
            launchApp();
        }

        private void resetAll()
        {
            fontReset();
            changeBackColour(Color.White);
            changeForeColour(Color.Black);
            this.Size = resetSize.Size;
            this.MinimumSize = resetSize.Size;
            this.Location = new Point(0, 0);
            statusLabel.Text = "Text Size: " + this.Font.Size;
            checkScreenSize();
            
            
        }

        private void fontReset()
        {
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont = (Font)toFont.ConvertFromString("Microsoft Sans Serif");
            this.Font = new Font(newFont.FontFamily, float.Parse("10.0"), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            
            statusLabel.Font = this.Font;
            menuStrip1.Font = this.Font;
            this.Size = resetSize.Size;
            this.MinimumSize = resetSize.Size;
            checkScreenSize();
            
            this.WindowState = FormWindowState.Normal;
            this.Refresh();
        }


        private void changeForeColour(Color fg)
        {
            appTree.ForeColor = fg;
            menuStrip1.ForeColor = fg;

            settingsBg.ForeColor = fg;
            settingsColourScheme.ForeColor = fg;
            settingsDefaultFont.ForeColor = fg;
            settingsFg.ForeColor = fg;
            settingsFont.ForeColor = fg;
            settingsReverse.ForeColor = fg;
            fileMenuExit.ForeColor = fg;
            aboutToolStripMenuItem1.ForeColor = fg;
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
            foreach (ToolStripMenuItem t in fontToolStripMenuItem.DropDownItems)
            {
                t.ForeColor = fg;
            }
            foreach (ToolStripMenuItem t in sizeToolStripMenuItem.DropDownItems)
            {
                t.ForeColor = fg;
            }
            
        }

        private void changeBackColour(Color bg)
        {
            appTree.BackColor = bg;
            menuStrip1.BackColor = bg;

            settingsBg.BackColor = bg;
            settingsColourScheme.BackColor = bg;
            settingsDefaultFont.BackColor = bg;
            settingsFg.BackColor = bg;
            settingsFont.BackColor = bg;
            settingsReverse.BackColor = bg;
            fileMenuExit.BackColor = bg;
            aboutToolStripMenuItem1.BackColor = bg;
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
            foreach (ToolStripMenuItem t in fontToolStripMenuItem.DropDownItems)
            {
                t.BackColor = bg;
            }
            foreach (ToolStripMenuItem t in sizeToolStripMenuItem.DropDownItems)
            {
                t.BackColor = bg;
            }
        }


        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveAndClose();
        }

        /**
         * Saves the current settings and closes the program
         * If the settings can't be saved, then a new settings file is created and another attempt to save is made
         */ 
        private void saveAndClose()
        {
            try
            {
                mu.saveSettings(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString());
            }
            catch (Exception ex)
            {
                mu.createSettingsFile();
                mu.saveSettings(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString());
            }
            Application.Exit();
        }


        /**
         * Checks if the window has been minimized and if so hides it in the system tray and shows a balloon tip
         */ 
        private void MenuForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.BalloonTipText = "Your application menu is still running and can be accessed through this icon";
                notifyIcon1.ShowBalloonTip(200);
            }
        }

        /**
         * Restores the window if the user doubleclicks on the icon in the system tray
         */ 
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
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
         * Restores the window if the user clicks on the notification balloon that is shown when the window minimizes
         */ 
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            String selected = e.ClickedItem.Text; 
            if (!(selected.Equals("Show Menu") || selected.Equals("Exit Menu")))
            {
                String inputPath = (String)((AppShortcut)menu[selected]).getPath();
                try
                {
                    System.Diagnostics.Process launched = System.Diagnostics.Process.Start(@inputPath);
                }
                catch (Exception ex)
                {
                CustomBox.Show("Application not found! \nThis application will not be shown when the menu is next loaded", "Error!", this.Font, appTree.BackColor, appTree.ForeColor);
                mu.remove(selected);
                this.BringToFront();
                this.Focus();
                }
            }

        }
         

        private void checkScreenSize()
        {
            maxSize.Width = (Screen.PrimaryScreen.WorkingArea.Width - 18);
            maxSize.Height = Screen.PrimaryScreen.WorkingArea.Height - 18;
            this.MaximumSize = maxSize.Size;
            appTree.Height = this.Height - menuStrip1.Height - statusLabel.Height;
            appTree.Scrollable = true;
            if (this.Height == this.MaximumSize.Height || this.Width == this.MaximumSize.Width)
                tooLarge = true;
            else tooLarge = false;
            if (tooLarge)
            {
                notifyIcon1.BalloonTipText = "The menu window is now larger than your screen. Press the Escape key to fix any layout problems.";
                notifyIcon1.ShowBalloonTip(250);
            }
        }
        
        private void appTree_Enter(object sender, EventArgs e)
        {
            appTree.SelectedNode = appTree.Nodes[0];
        }

        private void fileMenuExit_Click(object sender, EventArgs e)
        {
            saveAndClose();
        }

        private void settingsReverse_Click(object sender, EventArgs e)
        {
            colourSchemeOrderChanged();
        }

        private void settingsDefaultFont_Click(object sender, EventArgs e)
        {
            fontReset();
        }

        private void blackOnWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(0);
        }

        private void whiteOnBlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(1);
        }

        private void yellowOnBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(2);
        }

        private void blackOnYellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(3);
        }

        private void blackOnPaleBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(4);
        }

        private void blackOnCreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(5);
        }

        private void blackOnPinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colourComboChanged(6);
        }

        private void keyboardShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            String shortcuts = "";
            Char[] separator = ",".ToCharArray();
            foreach (String shortcut in keys)
            {
                String[] subs = shortcut.Split(separator);
                shortcuts += subs[0] + " : " + subs[1] + ". \n";
            }
            CustomBox.Show(shortcuts, "Keyboard Shortcuts", this.Font, appTree.BackColor, appTree.ForeColor);
            this.BringToFront();
            this.Focus();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomBox.Show("Menu \nVersion 0.2 \n\nCreated By:  \nLearning Societies Lab \nSchool of Electronics and Computer Science \nUniversity of Southampton \nFunded by LATEU", "Application Menu", this.Font, appTree.BackColor, appTree.ForeColor);
            this.BringToFront();
            this.Focus();
        }

        private void fontToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            String selected = e.ClickedItem.Text;
            Font newFont = (Font)toFont.ConvertFromString(selected);
            this.Font = new Font(newFont.FontFamily, this.Font.Size, newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            toolStrip1.Font = this.Font;
            menuStrip1.Font = this.Font;
        }

        private void sizeToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int selected = int.Parse(e.ClickedItem.Text);
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont = (Font)toFont.ConvertFromString(this.Font.FontFamily.ToString());
            this.Font = new Font(newFont.FontFamily, selected, newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            
            statusLabel.Font = this.Font;
            menuStrip1.Font = this.Font;
            statusLabel.Text = "";
            checkScreenSize();
        }

        private void settingsBg_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!e.ClickedItem.Text.Equals("Custom..."))
            {
                Color bg = appTree.BackColor;
                bg = checkClash(e.ClickedItem.BackColor, false, false);
                changeBackColour(bg);
            }
        }

        private void settingsFg_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!e.ClickedItem.Text.Equals("Custom..."))
            {
            Color fg = appTree.ForeColor;
            fg = checkClash(e.ClickedItem.ForeColor, true, false);
            changeForeColour(fg);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void moreBgMenuItem_Click(object sender, EventArgs e)
        {
            Color toReturn = appTree.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                toReturn = checkClash(colorDialog1.Color, false, true);
            }
            changeBackColour(toReturn);
        }

        private void moreFgMenuItem_Click(object sender, EventArgs e)
        {
            Color toReturn = appTree.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                toReturn = checkClash(colorDialog1.Color, true, true);
            }
            changeForeColour(toReturn);
        }

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

        

        

       


    }
}
