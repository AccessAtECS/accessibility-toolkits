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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMiniOptions = new System.Windows.Forms.Button();
            this.btnMiniLaunch = new System.Windows.Forms.Button();
            this.colourComboBox = new System.Windows.Forms.ComboBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMiniOptions = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixSizeLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelMiniOptions.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.AccessibleName = "Exit";
            this.exitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exitButton.Location = new System.Drawing.Point(205, 153);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(196, 48);
            this.exitButton.TabIndex = 9;
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
            this.appTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.appTree.Dock = System.Windows.Forms.DockStyle.Top;
            this.appTree.HideSelection = false;
            this.appTree.Indent = 10;
            this.appTree.Location = new System.Drawing.Point(1, 0);
            this.appTree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 50);
            this.appTree.Name = "appTree";
            this.appTree.Size = new System.Drawing.Size(401, 280);
            this.appTree.TabIndex = 0;
            this.appTree.DoubleClick += new System.EventHandler(this.appTree_DoubleClick);
            this.appTree.Enter += new System.EventHandler(this.appTree_Enter);
            this.appTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.appTree_KeyDown);
            // 
            // colourButton
            // 
            this.colourButton.AccessibleDescription = "Open a dialog box to select a new colour for the menu background";
            this.colourButton.AccessibleName = "Change Background Colour";
            this.colourButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colourButton.Location = new System.Drawing.Point(0, 97);
            this.colourButton.Name = "colourButton";
            this.colourButton.Size = new System.Drawing.Size(192, 48);
            this.colourButton.TabIndex = 6;
            this.colourButton.Text = "Change Background Colour";
            this.colourButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolTip1.SetToolTip(this.colourButton, "Change the background colour of the menu list and buttons");
            this.colourButton.UseVisualStyleBackColor = true;
            this.colourButton.Click += new System.EventHandler(this.colourButton_Click);
            this.colourButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.colourButton_KeyDown);
            // 
            // fontButton
            // 
            this.fontButton.AccessibleDescription = "Open a dialog box to choose the font used on the menu";
            this.fontButton.AccessibleName = "Change Font";
            this.fontButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fontButton.Location = new System.Drawing.Point(0, 59);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(192, 32);
            this.fontButton.TabIndex = 4;
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
            this.textColourButton.AccessibleDescription = "Open a dialog box to select a new colour for the menu text";
            this.textColourButton.AccessibleName = "Change Text Colour";
            this.textColourButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.textColourButton.Location = new System.Drawing.Point(205, 97);
            this.textColourButton.Name = "textColourButton";
            this.textColourButton.Size = new System.Drawing.Size(196, 48);
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
            this.downloadButton.AccessibleDescription = "Download new applications to your pendrive";
            this.downloadButton.AccessibleName = "Download New Applications";
            this.downloadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.downloadButton.Location = new System.Drawing.Point(0, 153);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(192, 48);
            this.downloadButton.TabIndex = 8;
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
            this.flipColourButton.AccessibleDescription = "Reverse the colour scheme";
            this.flipColourButton.AccessibleName = "Flip colours";
            this.flipColourButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flipColourButton.Location = new System.Drawing.Point(205, 25);
            this.flipColourButton.Name = "flipColourButton";
            this.flipColourButton.Size = new System.Drawing.Size(196, 28);
            this.flipColourButton.TabIndex = 3;
            this.flipColourButton.Text = "Reverse Colours";
            this.flipColourButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.flipColourButton, "Reverse the current colour scheme");
            this.flipColourButton.UseVisualStyleBackColor = true;
            this.flipColourButton.Click += new System.EventHandler(this.flipColourButton_Click);
            this.flipColourButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flipColourButton_KeyDown);
            // 
            // defaultFontButton
            // 
            this.defaultFontButton.AccessibleDescription = "Revert to the default font";
            this.defaultFontButton.AccessibleName = "Default Font";
            this.defaultFontButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.defaultFontButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.defaultFontButton.Location = new System.Drawing.Point(205, 59);
            this.defaultFontButton.Name = "defaultFontButton";
            this.defaultFontButton.Size = new System.Drawing.Size(196, 32);
            this.defaultFontButton.TabIndex = 5;
            this.defaultFontButton.Text = "Default Font";
            this.defaultFontButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.defaultFontButton, "Revert back to the original font style and size");
            this.defaultFontButton.UseVisualStyleBackColor = true;
            this.defaultFontButton.Click += new System.EventHandler(this.defaultFontButton_Click);
            this.defaultFontButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.defaultFontButton_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleName = "University of Southampton Logo";
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(5, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 44);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "University of Southampton");
            // 
            // btnMiniOptions
            // 
            this.btnMiniOptions.AccessibleDescription = "Switch view to toggle whether the accessibility options are displayed";
            this.btnMiniOptions.AccessibleName = "Hide Options";
            this.btnMiniOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMiniOptions.Location = new System.Drawing.Point(205, 3);
            this.btnMiniOptions.Name = "btnMiniOptions";
            this.btnMiniOptions.Size = new System.Drawing.Size(195, 32);
            this.btnMiniOptions.TabIndex = 1;
            this.btnMiniOptions.Text = "Hide Options...";
            this.btnMiniOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnMiniOptions, "Toggle whether the accessibility options are shown or not");
            this.btnMiniOptions.UseVisualStyleBackColor = true;
            this.btnMiniOptions.Click += new System.EventHandler(this.btnMiniOptions_Click);
            this.btnMiniOptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnMiniOptions_KeyDown);
            // 
            // btnMiniLaunch
            // 
            this.btnMiniLaunch.AccessibleDescription = "Launch the selected application";
            this.btnMiniLaunch.AccessibleName = "Launch Application";
            this.btnMiniLaunch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMiniLaunch.Location = new System.Drawing.Point(0, 3);
            this.btnMiniLaunch.Name = "btnMiniLaunch";
            this.btnMiniLaunch.Size = new System.Drawing.Size(192, 32);
            this.btnMiniLaunch.TabIndex = 1;
            this.btnMiniLaunch.Text = "Launch Application";
            this.btnMiniLaunch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnMiniLaunch, "Launch the selected application");
            this.btnMiniLaunch.UseVisualStyleBackColor = true;
            this.btnMiniLaunch.Click += new System.EventHandler(this.btnMiniLaunch_Click);
            this.btnMiniLaunch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnMiniLaunch_KeyDown);
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
            "Black on White",
            "White on Black",
            "Yellow on Blue ",
            "Black on Yellow",
            "Black on Pale Blue ",
            "Black on Cream ",
            "Black on Pink "});
            this.colourComboBox.Location = new System.Drawing.Point(0, 25);
            this.colourComboBox.Name = "colourComboBox";
            this.colourComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colourComboBox.Size = new System.Drawing.Size(192, 28);
            this.colourComboBox.TabIndex = 2;
            this.colourComboBox.Text = "Quick Colour Change";
            this.colourComboBox.SelectedIndexChanged += new System.EventHandler(this.colourComboBox_SelectedIndexChanged);
            this.colourComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.colourComboBox_KeyDown);
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Controls.Add(this.panelMiniOptions);
            this.panelMain.Controls.Add(this.appTree);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(1, 0, 5, 0);
            this.panelMain.Size = new System.Drawing.Size(407, 318);
            this.panelMain.TabIndex = 10;
            // 
            // panelMiniOptions
            // 
            this.panelMiniOptions.AutoSize = true;
            this.panelMiniOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMiniOptions.Controls.Add(this.btnMiniLaunch);
            this.panelMiniOptions.Controls.Add(this.btnMiniOptions);
            this.panelMiniOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMiniOptions.Location = new System.Drawing.Point(1, 280);
            this.panelMiniOptions.Name = "panelMiniOptions";
            this.panelMiniOptions.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.panelMiniOptions.Size = new System.Drawing.Size(401, 38);
            this.panelMiniOptions.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(5, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(407, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AccessibleName = "File Menu";
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fixSizeLayoutToolStripMenuItem,
            this.miniToolStripMenuItem,
            this.horizontalDisplayToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fixSizeLayoutToolStripMenuItem
            // 
            this.fixSizeLayoutToolStripMenuItem.Enabled = false;
            this.fixSizeLayoutToolStripMenuItem.Name = "fixSizeLayoutToolStripMenuItem";
            this.fixSizeLayoutToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.fixSizeLayoutToolStripMenuItem.Text = "Fix Size/Layout";
            this.fixSizeLayoutToolStripMenuItem.Visible = false;
            this.fixSizeLayoutToolStripMenuItem.Click += new System.EventHandler(this.fixSizeLayoutToolStripMenuItem_Click);
            // 
            // miniToolStripMenuItem
            // 
            this.miniToolStripMenuItem.AccessibleName = "Mini View";
            this.miniToolStripMenuItem.Name = "miniToolStripMenuItem";
            this.miniToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.miniToolStripMenuItem.Text = "Mini View";
            this.miniToolStripMenuItem.ToolTipText = "Hide the buttons and display only the Menu List";
            this.miniToolStripMenuItem.Click += new System.EventHandler(this.miniToolStripMenuItem_Click);
            // 
            // horizontalDisplayToolStripMenuItem
            // 
            this.horizontalDisplayToolStripMenuItem.Name = "horizontalDisplayToolStripMenuItem";
            this.horizontalDisplayToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.horizontalDisplayToolStripMenuItem.Text = "Horizontal Display";
            this.horizontalDisplayToolStripMenuItem.Click += new System.EventHandler(this.horizontalDisplayToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.AccessibleName = "Exit";
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.AccessibleName = "Help Menu";
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
            this.helpToolStripMenuItem2.AccessibleName = "Keyboard Shortcuts";
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
            this.aboutToolStripMenuItem.AccessibleName = "About";
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.flipColourButton);
            this.groupBox1.Controls.Add(this.downloadButton);
            this.groupBox1.Controls.Add(this.defaultFontButton);
            this.groupBox1.Controls.Add(this.exitButton);
            this.groupBox1.Controls.Add(this.colourComboBox);
            this.groupBox1.Controls.Add(this.colourButton);
            this.groupBox1.Controls.Add(this.fontButton);
            this.groupBox1.Controls.Add(this.textColourButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 318);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.groupBox1.Size = new System.Drawing.Size(407, 225);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.AutoSize = true;
            this.panelContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContainer.Controls.Add(this.groupBox1);
            this.panelContainer.Controls.Add(this.panelMain);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(5, 68);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(407, 550);
            this.panelContainer.TabIndex = 11;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Your application menu is still running and can be accessed through this icon";
            this.notifyIcon1.BalloonTipTitle = "Application Menu";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "Application Menu";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemShow,
            this.itemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // itemShow
            // 
            this.itemShow.Name = "itemShow";
            this.itemShow.Size = new System.Drawing.Size(137, 22);
            this.itemShow.Text = "Show Menu";
            this.itemShow.Click += new System.EventHandler(this.itemShow_Click);
            // 
            // itemExit
            // 
            this.itemExit.Name = "itemExit";
            this.itemExit.Size = new System.Drawing.Size(137, 22);
            this.itemExit.Text = "Exit Menu";
            this.itemExit.Click += new System.EventHandler(this.itemExit_Click);
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
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(417, 618);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Application Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.Resize += new System.EventHandler(this.MenuForm_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelMiniOptions.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TreeView appTree;
        private System.Windows.Forms.Button colourButton;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.ColorDialog colorOptions;
        private System.Windows.Forms.FontDialog fontOptions;
        private System.Windows.Forms.Button textColourButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox colourComboBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Panel panelMain;
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMiniOptions;
        private System.Windows.Forms.Panel panelMiniOptions;
        private System.Windows.Forms.Button btnMiniLaunch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemShow;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
        private System.Windows.Forms.ToolStripMenuItem horizontalDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixSizeLayoutToolStripMenuItem;
    }
}