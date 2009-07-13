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
        private Hashtable menu;
        private Hashtable categories;  

        /**
         * Create a new MenuForm, and try to load saved settings.
         */
        public MenuForm(Hashtable menu, Hashtable categories, Settings settings)
        {
            this.menu = menu;
            this.categories = categories;
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
            appTree.TabIndex = 0;
            launchButton.TabIndex = 1;
            colourComboBox.TabIndex = 2;
            colourButton.TabIndex = 3;
            textColourButton.TabIndex = 4;
            fontButton.TabIndex = 5;
            exitButton.TabIndex = 6;                  
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
                exitButton.BackColor = bgColour;
                exitButton.ForeColor = fgColour;


                TypeConverter toFont = TypeDescriptor.GetConverter(typeof(Font));
                Font newFont = (Font)toFont.ConvertFromString(settings.getFont());
                this.Font = new Font(newFont.FontFamily, float.Parse(settings.getFontSize()), newFont.Style, newFont.Unit, newFont.GdiCharSet, newFont.GdiVerticalFont);
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was a problem restoring your settings. The default settings will be used.", "Error!");
            }
            colorOptions.AllowFullOpen = true;
            
        }

        /**
         * Creates a new XMLupdater to store the user's settings.
         */
        private void exitButton_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsUpdater updater = new SettingsUpdater(ColorTranslator.ToHtml(appTree.BackColor), ColorTranslator.ToHtml(appTree.ForeColor), this.Font.FontFamily.Name.ToString(), this.Font.Size.ToString());
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
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show("Application not found!", "Error!");
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
            else this.Height = appTree.Height + panel1.Height;
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

            colourComboBox.ForeColor = fg;
            colourComboBox.BackColor = bg;
           
            appTree.BackColor = bg;
            launchButton.BackColor = bg;
            colourButton.BackColor = bg;
            textColourButton.BackColor = bg;
            fontButton.BackColor = bg;
            exitButton.BackColor = bg;

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
