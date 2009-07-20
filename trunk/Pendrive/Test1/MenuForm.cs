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
            foreach (String cat in categories.Keys)
            {
                TreeNode tempN = new TreeNode(cat); 
                appTree.Nodes.Add(tempN);                    
                foreach (String app in ((ArrayList)categories[cat]))
                {  
                    tempN.Nodes.Add(app);
                }                  
            }
            appTree.Sort();
            appTree.TabIndex = 0;
            launchButton.TabIndex = 1;
            colourComboBox.TabIndex = 2;
            fontButton.TabIndex = 3;
            colourButton.TabIndex = 4;
            textColourButton.TabIndex = 5;
            downloadButton.TabIndex = 6;
            exitButton.TabIndex = 7;                  
            appTree.ExpandAll();
            try
            {
                Color bgColour = ColorTranslator.FromHtml(settings.getBgColour());
                Color fgColour = ColorTranslator.FromHtml(settings.getTxtColour());
                appTree.BackColor = bgColour;
                appTree.ForeColor = fgColour;
                launchButton.BackColor = bgColour;
                launchButton.ForeColor = fgColour;
                colourComboBox.BackColor = bgColour;
                colourComboBox.ForeColor = fgColour;
                colourButton.BackColor = bgColour;
                colourButton.ForeColor = fgColour;
                textColourButton.BackColor = bgColour;
                textColourButton.ForeColor = fgColour;
                fontButton.BackColor = bgColour;
                fontButton.ForeColor = fgColour;
                downloadButton.BackColor = bgColour;
                downloadButton.ForeColor = fgColour;
                exitButton.BackColor = bgColour;
                exitButton.ForeColor = fgColour;

                TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
                Font newFont = (Font)toFont.ConvertFromString(settings.getFont());
                this.Font = new Font(newFont.FontFamily, float.Parse(settings.getFontSize()), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
                if (this.Height > Screen.PrimaryScreen.WorkingArea.Height)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else this.Height = appTree.Height + panel1.Height + ((appTree.Height + panel1.Height) /5);
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was a problem restoring your settings. The default settings will be used.", "Error!");
            }
            colorOptions.AllowFullOpen = false;
        }

        /**
         * Creates a new XMLupdater to store the user's settings.
         */
        private void exitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //SettingsUpdater updater = new SettingsUpdater(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString());
                mu.saveSettings(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString());
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Your settings could not be saved.", "Error!");
            }
            Application.Exit();
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
                    String inputPath = (String)((AppShortcut)menu[selected]).getPath();
                    try
                    {
                        System.Diagnostics.Process.Start(@inputPath);
                    }                    
                    catch (Exception e)
                    {
                        MessageBox.Show("Application not found! \nThis application will not be shown when the menu is next loaded"  , "Error!");
                        mu.remove(selected);
                    }
                }
            }
        }


        /**
         * Manually change the background colour of the menu components.
         */
        private void colourButton_Click(object sender, EventArgs e)
        {    
            if (colorOptions.ShowDialog() == DialogResult.OK)
            {
                appTree.BackColor = colorOptions.Color;
                launchButton.BackColor = colorOptions.Color;
                colourButton.BackColor = colorOptions.Color;
                textColourButton.BackColor = colorOptions.Color;
                fontButton.BackColor = colorOptions.Color;
                exitButton.BackColor = colorOptions.Color;                   
                colourComboBox.BackColor = colorOptions.Color;
                downloadButton.BackColor = colorOptions.Color;
            }                       
        }

        /**
         * Manually change the text colour of the menu components.
         */
        private void textColourButton_Click(object sender, EventArgs e)
        {
            if (colorOptions.ShowDialog() == DialogResult.OK)
            {
                appTree.ForeColor = colorOptions.Color;
                launchButton.ForeColor = colorOptions.Color;
                colourButton.ForeColor = colorOptions.Color;
                textColourButton.ForeColor = colorOptions.Color;
                fontButton.ForeColor = colorOptions.Color;
                exitButton.ForeColor = colorOptions.Color;
                colourComboBox.ForeColor = colorOptions.Color;
                downloadButton.ForeColor = colorOptions.Color;
            }
        }
        
        /**
         * Method to change font family, style and size.
         * Also handles the resizing of the window and components to accomodate the change in font size 
         */
        private void fontButton_Click(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
            if (fontOptions.ShowDialog() == DialogResult.OK)
            {
                this.Font = fontOptions.Font;
            }
            this.WindowState = FormWindowState.Normal;
            this.Refresh();
            if (this.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else this.Height = appTree.Height + panel1.Height + (appTree.Height + panel1.Height)/5;
        }

        /**
         * Automatically change the font/background colour combination using the comboBox
         */
        private void colourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color bg = Color.Black;
            Color fg = Color.Black;

            if (colourComboBox.SelectedIndex == 0)
            {
                fg = Color.Black;
                bg = Color.White;
            }
            if (colourComboBox.SelectedIndex == 1)
            {
                fg = Color.White;
                bg = Color.Black;
            }
            if (colourComboBox.SelectedIndex == 2)
            {
                fg = Color.Yellow;
                bg = Color.Navy;
            }
            if (colourComboBox.SelectedIndex == 3)
            {
                fg = Color.Black;
                bg = Color.Yellow;
            }
            if (colourComboBox.SelectedIndex == 4)
            {
                fg = Color.Black;
                bg = Color.AliceBlue;
            }
            if (colourComboBox.SelectedIndex == 5)
            {
                fg = Color.Black;
                bg = Color.Cornsilk;
            }
            if (colourComboBox.SelectedIndex == 6)
            {
                fg = Color.Black;
                bg = Color.MistyRose;
            }
            appTree.ForeColor = fg;
            launchButton.ForeColor = fg;
            colourButton.ForeColor = fg;
            textColourButton.ForeColor = fg;
            fontButton.ForeColor = fg;
            exitButton.ForeColor = fg;
            downloadButton.ForeColor = fg;
            colourComboBox.ForeColor = fg;
            colourComboBox.BackColor = bg;
            appTree.BackColor = bg;
            launchButton.BackColor = bg;
            colourButton.BackColor = bg;
            textColourButton.BackColor = bg;
            fontButton.BackColor = bg;
            exitButton.BackColor = bg;
            downloadButton.BackColor = bg;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            /*System.Net.WebClient dlClient = new System.Net.WebClient();
            //dlClient.DownloadFile("", "appList.xml");
            Menu dlList = new Menu();
            XMLparser dlParser = new XMLparser(dlList, "appList.xml");
            dlParser.readXmlFile();
            MessageBox.Show("downloaded list parsed");

            foreach (string category in dlList.getCategories().Keys)
            {
                TreeNode tempN = new TreeNode(category);
                //appTree.Nodes.Add(tempN);  not appTree, should be treeView on download form
                foreach (String app in ((ArrayList)categories[category]))
                {
                    tempN.Nodes.Add(app);
                }
            }*/

            MessageBox.Show("Coming Soon! \nThis feature will allow new applications to be downloaded and added to the menu automatically. \nIn the meantime, please visit http://*** to manually download additional applications. \nThis website will be launched when you close this message.", "Download Information");
            //System.Diagnostics.Process.Start("http://access.ecs.soton.ac.uk/blog");
        }

        /**
         * General key commands that are also called whenever the KeyDown occurs on the other Form components
         */ 
        private void MenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F)
                fontButton.PerformClick();
            if (e.KeyData == Keys.B)
                colourButton.PerformClick();
            if (e.KeyData == Keys.T)
                textColourButton.PerformClick();
            if (e.KeyData == Keys.D)
                downloadButton.PerformClick();
            if (e.KeyData == Keys.D1)
                colourComboBox.SelectedIndex = 0;
            if (e.KeyData == Keys.D2)
                colourComboBox.SelectedIndex = 1;
            if (e.KeyData == Keys.D3)
                colourComboBox.SelectedIndex = 2;
            if (e.KeyData == Keys.D4)
                colourComboBox.SelectedIndex = 3;
            if (e.KeyData == Keys.D5)
                colourComboBox.SelectedIndex = 4;
            if (e.KeyData == Keys.D6)
                colourComboBox.SelectedIndex = 5;
            if (e.KeyData == Keys.D7)
                colourComboBox.SelectedIndex = 6;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitButton_Click(sender, e);
        }

        /**
         * Handler for the "About" option in the Menu bar
         */ 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menu \nVersion 0.1 \n\nLearning Societies Lab \nSchool of Electronics and Computer Science \nUniversity of Southampton", "Application Menu");
        }

        /**
         * Handler for the "Keyboard Shortcuts" option in the Menu bar
         */ 
        private void helpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("F:  Change Font. \nB:  Change Background Colour. \nT:  Change Text Colour. \nD:  Downloads. \nNumbers:  Preset Colour Combinations.", "Keyboard Shortcuts ");                
        }

        
    }
}
