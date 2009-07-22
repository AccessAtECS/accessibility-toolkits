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
        private bool mini = false;

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
            flipColourButton.TabIndex = 3;
            fontButton.TabIndex = 3;
            defaultFontButton.TabIndex = 4;
            colourButton.TabIndex = 4;
            textColourButton.TabIndex = 5;
            downloadButton.TabIndex = 6;
            exitButton.TabIndex = 7;                  
            appTree.ExpandAll();
            try
            {
                Color bgColour = ColorTranslator.FromHtml(settings.getBgColour());
                Color fgColour = ColorTranslator.FromHtml(settings.getTxtColour());
                changeBackColour(bgColour);
                changeForeColour(fgColour);

                TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
                Font newFont = (Font)toFont.ConvertFromString(settings.getFont());
                this.Font = new Font(newFont.FontFamily, float.Parse(settings.getFontSize()), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
                if (this.Height > Screen.PrimaryScreen.WorkingArea.Height)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else this.Height = panel2.Height + panel1.Height + (3* menuStrip1.Height) ;
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was a problem restoring your settings. The default settings will be used, and a new settings file will be created.", "Error!");
            }
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
            backgroundChange();             
        }

        private void backgroundChange()
        {
            if (colorOptions.ShowDialog() == DialogResult.OK)
            {
                changeBackColour(colorOptions.Color);
            }       
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
            if (colorOptions.ShowDialog() == DialogResult.OK)
            {
                changeForeColour(colorOptions.Color);
            }
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
            else this.Height = panel2.Height + panel1.Height + (2 * menuStrip1.Height); 
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

        private void MenuForm_Load(object sender, EventArgs e)
        {
            
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon! \nThis feature will allow new applications to be downloaded and added to the menu automatically. \nIn the meantime, please visit http://*** to manually download additional applications. \nThis website will be launched when you close this message.", "Download Information");
            //System.Diagnostics.Process.Start("http://access.ecs.soton.ac.uk/blog");
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAndClose();
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
            Hashtable keys = new Hashtable();
            keys.Add("CTRL + F", "Change Font");
            keys.Add("CTRL + B", "Change Background Colour");
            keys.Add("CTRL + T", "Change Text Colour");
            keys.Add("CTRL + R", "Reverse Colours");
            keys.Add("CTRL + O", "Default Font");
            keys.Add("CTRL + D", "Downloads");
            keys.Add("CTRL + [numbers]", "Preset Colour Combinations");
            keys.Add("CTRL + M", "Toggle Mini View");
            String shortcuts = "";
            foreach (String key in keys.Keys)
            {
                shortcuts += key + ":  " + keys[key] + ". \n";
            }
            MessageBox.Show(shortcuts, "Keyboard Shortcuts");
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

        private void fontReset()
        {
            TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont = (Font)toFont.ConvertFromString("Microsoft Sans Serif");
            this.Font = new Font(newFont.FontFamily, float.Parse("12.0"), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            this.WindowState = FormWindowState.Normal;
            this.Refresh();
            if (this.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else this.Height = panel2.Height + panel1.Height + (3 * menuStrip1.Height);
        }


        private void changeForeColour(Color fg)
        {
            appTree.ForeColor = fg;
            launchButton.ForeColor = fg;
            colourButton.ForeColor = fg;
            textColourButton.ForeColor = fg;
            fontButton.ForeColor = fg;
            exitButton.ForeColor = fg;
            downloadButton.ForeColor = fg;
            colourComboBox.ForeColor = fg;
            flipColourButton.ForeColor = fg;
            defaultFontButton.ForeColor = fg;
        }

        private void changeBackColour(Color bg)
        {
            defaultFontButton.BackColor = bg;
            flipColourButton.BackColor = bg;
            colourComboBox.BackColor = bg;
            appTree.BackColor = bg;
            launchButton.BackColor = bg;
            colourButton.BackColor = bg;
            textColourButton.BackColor = bg;
            fontButton.BackColor = bg;
            exitButton.BackColor = bg;
            downloadButton.BackColor = bg;
        }

        private void miniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleMini();
        }

        private void toggleMini()
        {
            if (!mini)
            {
                panel1.Visible = false;
                panel1.Enabled = false;
                this.Height = this.Height - panel1.Height;
                miniToolStripMenuItem.Text = "Full View";
                mini = !mini;
            }
            else
            {
                panel1.Visible = true;
                panel1.Enabled = true;
                this.Height = this.Height + panel1.Height;
                if (this.Height > Screen.PrimaryScreen.WorkingArea.Height)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                miniToolStripMenuItem.Text = "Mini View";
                mini = !mini;
            }
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveAndClose();
        }

        private void saveAndClose()
        {
            try
            {
                //SettingsUpdater updater = new SettingsUpdater(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString());
                mu.saveSettings(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString());

            }
            catch (FileNotFoundException ex)
            {
                mu.createSettingsFile();
                mu.saveSettings(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString());
                //MessageBox.Show("Your settings could not be saved.", "!");
            }
            Application.Exit();
        }
    }
}
