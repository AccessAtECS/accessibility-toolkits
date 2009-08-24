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
        private bool mini;
        private bool horizontal;
        private bool notified;
        private int correctMainHeight;
        private int correctOptionsHeight;
        private int correctWidth;
        private int hWidth;
        private int defaultWidth;
        private int defaultTreeHeight;
        Rectangle maxSize = new Rectangle();

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
            pictureBox1.Image = bmpLogo;
            ImageList imgList = new ImageList();
            
            //Set up menu treeview
            Bitmap bmpIcon = new Bitmap("Menu_Data\\icon.png");
            Icon ic = Icon.FromHandle(bmpIcon.GetHicon());
            notifyIcon1.Icon = ic;
            imgList.Images.Add(ic); //adds the Folder icon as a basic icon to be used for categories
            foreach (String cat in categories.Keys)
            {
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
            ActiveControl = btnMiniLaunch;
            //Set up colours and fonts from settings file
            try
            {
                Color bgColour = ColorTranslator.FromHtml(settings.getBgColour());
                Color fgColour = ColorTranslator.FromHtml(settings.getTxtColour());
                changeBackColour(bgColour);
                changeForeColour(fgColour);

                TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
                Font newFont = (Font)toFont.ConvertFromString(settings.getFont());
                this.Font = new Font(newFont.FontFamily, float.Parse(settings.getFontSize()), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
             
                mini = settings.getMini();
                defaultTreeHeight = 280;
                defaultWidth = 442;
                correctMainHeight = (pictureBox1.Height + menuStrip1.Height + panelMain.Height + panelMiniOptions.Height);
                correctOptionsHeight = groupBox1.Height;
                correctWidth = groupBox1.Width + 23;
                this.Width = correctWidth;
                this.Height = correctOptionsHeight + correctMainHeight;
                
                if (mini)
                {
                    groupBox1.Visible = false;
                    groupBox1.Enabled = false;
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Height = correctMainHeight;
                    }
                    miniToolStripMenuItem.Text = "Full View";
                    miniToolStripMenuItem.ToolTipText = "Show the buttons and display the whole menu";
                    btnMiniOptions.Text = "Show Options";
                }
                appTree.Focus();
            }
            catch(Exception ex)
            {
                CustomBox.Show("There was a problem restoring your settings. The default settings will be used, and a new settings file will be created.", "Error!", this.Font, appTree.BackColor, appTree.ForeColor);
                mu.createSettingsFile();
                mini = false;
                this.BringToFront();
                this.Focus();
            }
            
            checkScreenSize();
            notified = false;
            horizontal = false;
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
                if (appTree.SelectedNode != null)
                {
                    appTree.SelectedNode.EnsureVisible();
                }
            }
            if (e.KeyData == Keys.Down)
            {
                if (appTree.SelectedNode != null)
                {
                    appTree.SelectedNode.EnsureVisible();
                }
            }
            else MenuForm_KeyDown(sender, e);
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
                    btnMiniLaunch.Text = "Launching " + selected + "...";
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
                    btnMiniLaunch.Text = "Launch Selected Application";
                }
            }
        }


        /**
         * Manually change the background colour of the menu components.
         */
        private void colourButton_Click(object sender, EventArgs e)
        {
            backgroundChange();             
        }

        private void backgroundChange()
        {
            changeBackColour(CustomColourBox.show(appTree.BackColor, appTree.ForeColor, appTree.BackColor, this.Font));
            this.BringToFront();
            this.Focus();
            colourComboBox.Text = "Quick Colour Change";
        }

        /**
         * Manually change the text colour of the menu components.
         */
        private void textColourButton_Click(object sender, EventArgs e)
        {
            foregroundChange();           
        }

        private void foregroundChange()
        {
            changeForeColour(CustomColourBox.show(appTree.ForeColor, appTree.ForeColor, appTree.BackColor, this.Font));
            this.BringToFront();
            this.Focus();
            colourComboBox.Text = "Quick Colour Change";
        }
        
        /**
         * Method to change font family, style and size.
         * Also handles the resizing of the window and components to accomodate the change in font size 
         */
        private void fontButton_Click(object sender, EventArgs e)
        {
            fontChange();
        }    

        private void fontChange()
        {
            double oldFontSize = this.Font.Size;
            this.ResizeRedraw = true;
            this.Font = CustomFontBox.show(this.Font, appTree.BackColor, appTree.ForeColor);
            this.WindowState = FormWindowState.Normal;
            correctMainHeight = (pictureBox1.Height + menuStrip1.Height + panelMain.Height + panelMiniOptions.Height);
            correctOptionsHeight = groupBox1.Height;
            correctWidth = groupBox1.Width +23;
            if (oldFontSize < this.Font.Size)
                checkScreenSize();
            this.BringToFront();
            this.Focus();
        }

        private void changeFontSize(int change)
        {
            int prevSize = this.Size.Height;
            float fontSize = this.Font.Size;
            fontSize = fontSize + change;
            if (fontSize >= 10)
            {
                this.Font = new Font(this.Font.FontFamily, fontSize, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
            }
            correctMainHeight = (pictureBox1.Height + menuStrip1.Height + panelMain.Height + panelMiniOptions.Height);
            correctOptionsHeight = groupBox1.Height;
            correctWidth = groupBox1.Width + 23;
            int newSize = this.Size.Height;
            if (change > 0)
                checkScreenSize();
        }

        /**
         * Automatically change the font/background colour combination using the comboBox
         */
        private void colourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            colourComboChanged(colourComboBox.SelectedIndex);
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

        private void downloadButton_Click(object sender, EventArgs e)
        {
            CustomBox.Show("Coming Soon! \nThis feature will allow new applications to be downloaded and added to the menu automatically. \nIn the meantime, please visit http://access.ecs.soton.ac.uk to manually download additional applications. \nThis website will be launched when you close this message.", "Download Information", this.Font, appTree.BackColor, appTree.ForeColor);
            System.Diagnostics.Process.Start("http://access.ecs.soton.ac.uk/blog");
            this.BringToFront();
            this.Focus();       
        }

        /**
         * General key commands that are also called whenever the KeyDown occurs on the other Form components
         */ 
        private void MenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
                fontChange();
            if (e.KeyCode == Keys.B && e.Control)
                backgroundChange();
            if (e.KeyCode == Keys.T && e.Control)
                foregroundChange();
            if (e.KeyCode == Keys.D && e.Control)
                downloadButton.PerformClick();
            if (e.KeyCode == Keys.R && e.Control)
                colourSchemeOrderChanged();
            if (e.KeyCode == Keys.O && e.Control)
                fontReset();
            if (e.KeyCode == Keys.M && e.Control)
                toggleMini();
            if (e.KeyCode == Keys.H && e.Control)
                toggleHorizontal();
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
        }

        private void launchButton_KeyDown(object sender, KeyEventArgs e)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAndClose();
        }     

        /**
         * Handler for the "About" option in the Menu bar
         */ 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomBox.Show("Menu \nVersion 0.1.2 \n\nCreated By:  \nLearning Societies Lab \nSchool of Electronics and Computer Science \nUniversity of Southampton \nFunded by LATEU", "Application Menu", this.Font, appTree.BackColor, appTree.ForeColor);
            this.BringToFront();
            this.Focus();
        }

        /**
         * Handler for the "Keyboard Shortcuts" option in the Menu bar
         */ 
        private void helpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ArrayList keys = new ArrayList();
            keys.Add("CTRL + +, Increase Text Size");
            keys.Add("CTRL + -, Decrease Text Size");
            keys.Add("CTRL + F, Change Font");
            keys.Add("CTRL + O, Default Font");
            keys.Add("CTRL + T, Change Text Colour");
            keys.Add("CTRL + B, Change Background Colour");
            keys.Add("CTRL + R, Reverse Colours");
            keys.Add("CTRL + D, Downloads");
            keys.Add("CTRL + M, Toggle Mini View");
            keys.Add("CTRL + [numbers], Preset Colour Combinations");
            keys.Add("ESC, Reset Colours and Font");
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

        private void flipColourButton_Click(object sender, EventArgs e)
        {
            colourSchemeOrderChanged();
        }

        private void colourSchemeOrderChanged()
        {
            Color tempB = appTree.BackColor;
            Color tempF = appTree.ForeColor;
            changeBackColour(tempF);
            changeForeColour(tempB);
        }

        private void appTree_DoubleClick(object sender, EventArgs e)
        {
            launchApp();
        }

        private void defaultFontButton_Click(object sender, EventArgs e)
        {
            fontReset();
        }


        private void resetAll()
        {
            fontReset();
            changeBackColour(Color.White);
            changeForeColour(Color.Black);
            colourComboBox.Text = "Quick Colour Change";
            if (horizontal)
            {
                this.Width = correctWidth;
                panelMain.Dock = DockStyle.Top;
                groupBox1.Dock = DockStyle.Top;
                horizontalDisplayToolStripMenuItem.Text = "Horizontal Display";
                horizontal = !horizontal;
            }
            if (mini)
                this.Height = correctMainHeight;
            else
                this.Height = correctMainHeight + correctOptionsHeight;
            //correctWidth = groupBox1.Width + 23;
            //if (correctWidth < defaultWidth)
                correctWidth = defaultWidth;
            this.Width = correctWidth;
            
            
        }

        private void fontReset()
        {
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont = (Font)toFont.ConvertFromString("Microsoft Sans Serif");
            this.Font = new Font(newFont.FontFamily, float.Parse("12.0"), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            checkScreenSize();
            appTree.Height = defaultTreeHeight;
            panelMain.Height = appTree.Height + panelMiniOptions.Height;
            correctMainHeight = (pictureBox1.Height + menuStrip1.Height + panelMain.Height + panelMiniOptions.Height);
            correctOptionsHeight = groupBox1.Height;
            correctWidth = groupBox1.Width + 23;
            this.WindowState = FormWindowState.Normal;
            this.Refresh();
        }


        private void changeForeColour(Color fg)
        {
            appTree.ForeColor = fg;
            colourButton.ForeColor = fg;
            textColourButton.ForeColor = fg;
            fontButton.ForeColor = fg;
            exitButton.ForeColor = fg;
            downloadButton.ForeColor = fg;
            colourComboBox.ForeColor = fg;
            flipColourButton.ForeColor = fg;
            defaultFontButton.ForeColor = fg;
            btnMiniLaunch.ForeColor = fg;
            btnMiniOptions.ForeColor = fg;
        }

        private void changeBackColour(Color bg)
        {
            defaultFontButton.BackColor = bg;
            flipColourButton.BackColor = bg;
            colourComboBox.BackColor = bg;
            appTree.BackColor = bg;
            colourButton.BackColor = bg;
            textColourButton.BackColor = bg;
            fontButton.BackColor = bg;
            exitButton.BackColor = bg;
            downloadButton.BackColor = bg;
            btnMiniLaunch.BackColor = bg;
            btnMiniOptions.BackColor = bg;
        }

        private void miniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleMini();
        }

        private void toggleMini()
        {
           
                if (!mini)
                {
                    groupBox1.Visible = false;
                    groupBox1.Enabled = false;

                    this.Height = correctMainHeight;
                    this.Width = correctWidth;

                    miniToolStripMenuItem.Text = "Full View";
                    miniToolStripMenuItem.ToolTipText = "Show the buttons and display the whole menu";
                    btnMiniOptions.Text = "Show Options";
                    mini = !mini;
                }
                else
                {
                    groupBox1.Visible = true;
                    groupBox1.Enabled = true;

                    if (horizontal)
                    {
                        hWidth = 2 * correctWidth;
                        this.Width = hWidth;
                        this.Height = correctMainHeight;
                    }
                    else
                    {
                        this.Height = correctMainHeight + correctOptionsHeight;
                        this.Width = correctWidth;
                    }

                    miniToolStripMenuItem.Text = "Mini View";
                    miniToolStripMenuItem.ToolTipText = "Hide the buttons and display only the Menu List";
                    btnMiniOptions.Text = "Hide Options";
                    mini = !mini;
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
                mu.saveSettings(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString(), this.mini.ToString());
            }
            catch (Exception ex)
            {
                mu.createSettingsFile();
                mu.saveSettings(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString(), this.mini.ToString());
            }
            Application.Exit();
        }

        private void btnMiniLaunch_Click(object sender, EventArgs e)
        {
            launchApp();
        }

        private void btnMiniOptions_Click(object sender, EventArgs e)
        {
            toggleMini();
        }

        /**
         * Checks if the window has been minimized and if so hides it in the system tray and shows a balloon tip
         */ 
        private void MenuForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.ShowBalloonTip(200);
            }

            if (this.Size.Width > Screen.PrimaryScreen.WorkingArea.Width || this.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                if (!notified)
                {
                    String orientation = "";
                    if (this.Size.Width > Screen.PrimaryScreen.WorkingArea.Width)
                        orientation = "wider";
                    if (this.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
                        orientation = "taller";
                    CustomBox.Show("The menu window is now " + orientation + " than your screen which may cause some viewing problems. \nYou may continue to increase the text size, but if the menu becomes unusable, press the Escape key to reset the settings, or select 'Fix Size/Layout' from the File Menu.", "Warning", this.Font, appTree.BackColor, appTree.ForeColor);
                    notified = true;
                }
            }
            if (this.Size.Width < Screen.PrimaryScreen.WorkingArea.Width && this.Size.Height < Screen.PrimaryScreen.WorkingArea.Height)
            {
                notified = false;
                fixSizeLayoutToolStripMenuItem.Enabled = false;
                fixSizeLayoutToolStripMenuItem.Visible = false;
            }

            if (notified)
            {
                fixSizeLayoutToolStripMenuItem.Enabled = true;
                fixSizeLayoutToolStripMenuItem.Visible = true;
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

        private void horizontalDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleHorizontal();
        }

        private void toggleHorizontal()
        {
            if (horizontal)
            {
                if (!mini)
                {
                    this.Height = correctMainHeight + correctOptionsHeight;
                }
                this.Width = correctWidth;
                panelMain.Dock = DockStyle.Top;
                groupBox1.Dock = DockStyle.Top;
                horizontalDisplayToolStripMenuItem.Text = "Horizontal Display";
            }
            else
            {
                this.Height = correctMainHeight;
                if (!mini)
                {
                    hWidth = 2 * correctWidth;
                    this.Width = hWidth;
                }
                panelMain.Dock = DockStyle.Fill;
                groupBox1.Dock = DockStyle.Right;
                horizontalDisplayToolStripMenuItem.Text = "Vertical Display";
            }
            horizontal = !horizontal;
        }

        private void fixSizeLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void checkScreenSize()
        {
            maxSize.Width = (Screen.PrimaryScreen.WorkingArea.Width - 18);
            maxSize.Height = (Screen.PrimaryScreen.WorkingArea.Height - pictureBox1.Height);
            appTree.MaximumSize = maxSize.Size;
        }

        private void appTree_Enter(object sender, EventArgs e)
        {
            appTree.SelectedNode = appTree.Nodes[0];
        }


    }
}
