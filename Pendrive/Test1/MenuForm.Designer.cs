namespace Test1
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.launchButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.appTree = new System.Windows.Forms.TreeView();
            this.colourButton = new System.Windows.Forms.Button();
            this.fontButton = new System.Windows.Forms.Button();
            this.colorOptions = new System.Windows.Forms.ColorDialog();
            this.fontOptions = new System.Windows.Forms.FontDialog();
            this.textColourButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.downloadButton = new System.Windows.Forms.Button();
            this.flipColourButton = new System.Windows.Forms.Button();
            this.defaultFontButton = new System.Windows.Forms.Button();
            this.colourComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // launchButton
            // 
            this.launchButton.AccessibleDescription = "Launch the selected application";
            this.launchButton.AccessibleName = "Launch";
            this.launchButton.Location = new System.Drawing.Point(1, 6);
            this.launchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(386, 31);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "Launch Selected Application";
            this.launchButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.launchButton, "Launch the selected application");
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            this.launchButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.launchButton_KeyDown);
            // 
            // exitButton
            // 
            this.exitButton.AccessibleName = "Exit";
            this.exitButton.Location = new System.Drawing.Point(1, 207);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(386, 29);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.exitButton, "Exit the menu");
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.exitButton_KeyDown);
            // 
            // appTree
            // 
            this.appTree.AccessibleDescription = "A list of available applications, displayed as a tree format";
            this.appTree.AccessibleName = "Application Tree";
            this.appTree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.appTree.Location = new System.Drawing.Point(0, 41);
            this.appTree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.appTree.Name = "appTree";
            this.appTree.Size = new System.Drawing.Size(387, 239);
            this.appTree.TabIndex = 4;
            this.appTree.DoubleClick += new System.EventHandler(this.appTree_DoubleClick);
            this.appTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.appTree_KeyDown);
            // 
            // colourButton
            // 
            this.colourButton.AccessibleDescription = "Button to open a dialog box to select a new colour for the menu background";
            this.colourButton.AccessibleName = "Change Background Colour";
            this.colourButton.Location = new System.Drawing.Point(0, 114);
            this.colourButton.Name = "colourButton";
            this.colourButton.Size = new System.Drawing.Size(186, 50);
            this.colourButton.TabIndex = 5;
            this.colourButton.Text = "Change Background Colour";
            this.colourButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.colourButton, "Change the background colour of the menu list and buttons");
            this.colourButton.UseVisualStyleBackColor = true;
            this.colourButton.Click += new System.EventHandler(this.colourButton_Click);
            this.colourButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.colourButton_KeyDown);
            // 
            // fontButton
            // 
            this.fontButton.AccessibleDescription = "Button to open a dialog box to choose the font used on the menu";
            this.fontButton.AccessibleName = "Change Font";
            this.fontButton.Location = new System.Drawing.Point(1, 79);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(286, 29);
            this.fontButton.TabIndex = 6;
            this.fontButton.Text = "Change Font";
            this.fontButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.fontButton, "Change the font used");
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            this.fontButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fontButton_KeyDown);
            // 
            // fontOptions
            // 
            this.fontOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontOptions.MinSize = 10;
            // 
            // textColourButton
            // 
            this.textColourButton.AccessibleDescription = "Button to open a dialog box to select a new colour for the menu text";
            this.textColourButton.AccessibleName = "Change Text Colour";
            this.textColourButton.Location = new System.Drawing.Point(201, 114);
            this.textColourButton.Name = "textColourButton";
            this.textColourButton.Size = new System.Drawing.Size(186, 50);
            this.textColourButton.TabIndex = 7;
            this.textColourButton.Text = "Change Text Colour";
            this.textColourButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.textColourButton, "Change the text colour of the menu list and buttons");
            this.textColourButton.UseVisualStyleBackColor = true;
            this.textColourButton.Click += new System.EventHandler(this.textColourButton_Click);
            this.textColourButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textColourButton_KeyDown);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(1, 170);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(386, 29);
            this.downloadButton.TabIndex = 9;
            this.downloadButton.Text = "Download New Applications";
            this.downloadButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.downloadButton, "Download new applications for use on your pendrive, and access them through this " +
                    "menu");
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            this.downloadButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.downloadButton_KeyDown);
            // 
            // flipColourButton
            // 
            this.flipColourButton.AccessibleDescription = "Button to reverse the colour scheme";
            this.flipColourButton.AccessibleName = "Flip colours";
            this.flipColourButton.Location = new System.Drawing.Point(293, 45);
            this.flipColourButton.Name = "flipColourButton";
            this.flipColourButton.Size = new System.Drawing.Size(94, 28);
            this.flipColourButton.TabIndex = 10;
            this.flipColourButton.Text = "Reverse";
            this.flipColourButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.flipColourButton, "Reverse the current colour scheme");
            this.flipColourButton.UseVisualStyleBackColor = true;
            this.flipColourButton.Click += new System.EventHandler(this.flipColourButton_Click);
            this.flipColourButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flipColourButton_KeyDown);
            // 
            // defaultFontButton
            // 
            this.defaultFontButton.AccessibleDescription = "Button to revert to the default font";
            this.defaultFontButton.AccessibleName = "Default Font";
            this.defaultFontButton.Location = new System.Drawing.Point(293, 79);
            this.defaultFontButton.Name = "defaultFontButton";
            this.defaultFontButton.Size = new System.Drawing.Size(94, 29);
            this.defaultFontButton.TabIndex = 11;
            this.defaultFontButton.Text = "Default";
            this.defaultFontButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.defaultFontButton, "Revert back to the original font style and size");
            this.defaultFontButton.UseVisualStyleBackColor = true;
            this.defaultFontButton.Click += new System.EventHandler(this.defaultFontButton_Click);
            this.defaultFontButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.defaultFontButton_KeyDown);
            // 
            // colourComboBox
            // 
            this.colourComboBox.AccessibleDescription = "Select a combination of colours";
            this.colourComboBox.AccessibleName = "Colour Change";
            this.colourComboBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.colourComboBox.FormattingEnabled = true;
            this.colourComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colourComboBox.ItemHeight = 20;
            this.colourComboBox.Items.AddRange(new object[] {
            "Black Text, White Background",
            "White Text, Black Background",
            "Yellow Text, Blue Background",
            "Black Text, Yellow Background",
            "Black Text, Pale Blue Background",
            "Black Text, Cream Background",
            "Black Text, Pink Background"});
            this.colourComboBox.Location = new System.Drawing.Point(1, 45);
            this.colourComboBox.Name = "colourComboBox";
            this.colourComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colourComboBox.Size = new System.Drawing.Size(286, 28);
            this.colourComboBox.TabIndex = 8;
            this.colourComboBox.Text = "Quick Colour Change";
            this.colourComboBox.SelectedIndexChanged += new System.EventHandler(this.colourComboBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.defaultFontButton);
            this.panel1.Controls.Add(this.flipColourButton);
            this.panel1.Controls.Add(this.downloadButton);
            this.panel1.Controls.Add(this.launchButton);
            this.panel1.Controls.Add(this.colourComboBox);
            this.panel1.Controls.Add(this.fontButton);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.colourButton);
            this.panel1.Controls.Add(this.textColourButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 253);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.appTree);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(387, 280);
            this.panel2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Logo and Name";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(387, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miniToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // miniToolStripMenuItem
            // 
            this.miniToolStripMenuItem.Name = "miniToolStripMenuItem";
            this.miniToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.miniToolStripMenuItem.Text = "Mini View";
            this.miniToolStripMenuItem.Click += new System.EventHandler(this.miniToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem2,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // helpToolStripMenuItem2
            // 
            this.helpToolStripMenuItem2.Name = "helpToolStripMenuItem2";
            this.helpToolStripMenuItem2.Size = new System.Drawing.Size(193, 22);
            this.helpToolStripMenuItem2.Text = "Keyboard Shortcuts";
            this.helpToolStripMenuItem2.Click += new System.EventHandler(this.helpToolStripMenuItem2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MenuForm
            // 
            this.AccessibleDescription = "Application Menu";
            this.AccessibleName = "Application Menu";
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(387, 563);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Menu";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TreeView appTree;
        private System.Windows.Forms.Button colourButton;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.ColorDialog colorOptions;
        private System.Windows.Forms.FontDialog fontOptions;
        private System.Windows.Forms.Button textColourButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox colourComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button flipColourButton;
        private System.Windows.Forms.Button defaultFontButton;
        private System.Windows.Forms.ToolStripMenuItem miniToolStripMenuItem;
    }
}