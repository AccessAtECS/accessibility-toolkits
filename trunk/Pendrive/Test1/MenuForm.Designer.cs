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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsColourScheme = new System.Windows.Forms.ToolStripMenuItem();
            this.blackOnWhiteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteOnBlackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowOnBlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackOnYellowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.blaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackOnCreamToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.blackOnPinkToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsReverse = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsBg = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paleBlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreBgMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsFg = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.paleBlueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.creamToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pinkToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moreFgMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsFont = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.settingsDefaultFont = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.appTree = new System.Windows.Forms.TreeView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.appTreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.launchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.appTreeContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "Your application menu is still running and can be accessed through this icon";
            this.trayIcon.BalloonTipTitle = "Access Tools";
            this.trayIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Access Tools";
            this.trayIcon.Visible = true;
            this.trayIcon.BalloonTipClicked += new System.EventHandler(this.trayIcon_BalloonTipClicked);
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleName = "Menu Bar";
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.settingsMenu,
            this.helpMenu});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(279, 23);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.AccessibleName = "File Menu";
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadMenuItem,
            this.fileMenuExit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.fileMenu.ShortcutKeyDisplayString = "Alt-F";
            this.fileMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileMenu.Size = new System.Drawing.Size(37, 19);
            this.fileMenu.Text = "File";
            // 
            // downloadMenuItem
            // 
            this.downloadMenuItem.Name = "downloadMenuItem";
            this.downloadMenuItem.Size = new System.Drawing.Size(224, 22);
            this.downloadMenuItem.Text = "Download New Applications";
            this.downloadMenuItem.Click += new System.EventHandler(this.downloadMenuItem_Click);
            // 
            // fileMenuExit
            // 
            this.fileMenuExit.Name = "fileMenuExit";
            this.fileMenuExit.Size = new System.Drawing.Size(224, 22);
            this.fileMenuExit.Text = "Exit";
            this.fileMenuExit.Click += new System.EventHandler(this.fileMenuExit_Click);
            // 
            // settingsMenu
            // 
            this.settingsMenu.AccessibleName = "Settings Menu";
            this.settingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsColourScheme,
            this.settingsReverse,
            this.settingsBg,
            this.settingsFg,
            this.settingsFont,
            this.settingsDefaultFont});
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.settingsMenu.Size = new System.Drawing.Size(61, 19);
            this.settingsMenu.Text = "Settings";
            // 
            // settingsColourScheme
            // 
            this.settingsColourScheme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackOnWhiteToolStripMenuItem1,
            this.whiteOnBlackToolStripMenuItem1,
            this.yellowOnBlueToolStripMenuItem,
            this.blackOnYellowToolStripMenuItem1,
            this.blaToolStripMenuItem,
            this.blackOnCreamToolStripMenuItem1,
            this.blackOnPinkToolStripMenuItem1});
            this.settingsColourScheme.Name = "settingsColourScheme";
            this.settingsColourScheme.Size = new System.Drawing.Size(223, 22);
            this.settingsColourScheme.Text = "Colour Scheme";
            this.settingsColourScheme.ToolTipText = "Change the colour scheme of the menu";
            // 
            // blackOnWhiteToolStripMenuItem1
            // 
            this.blackOnWhiteToolStripMenuItem1.Name = "blackOnWhiteToolStripMenuItem1";
            this.blackOnWhiteToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.blackOnWhiteToolStripMenuItem1.Text = "Black on White";
            this.blackOnWhiteToolStripMenuItem1.Click += new System.EventHandler(this.blackOnWhiteToolStripMenuItem_Click);
            // 
            // whiteOnBlackToolStripMenuItem1
            // 
            this.whiteOnBlackToolStripMenuItem1.BackColor = System.Drawing.Color.Black;
            this.whiteOnBlackToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.whiteOnBlackToolStripMenuItem1.Name = "whiteOnBlackToolStripMenuItem1";
            this.whiteOnBlackToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.whiteOnBlackToolStripMenuItem1.Text = "White on Black";
            this.whiteOnBlackToolStripMenuItem1.Click += new System.EventHandler(this.whiteOnBlackToolStripMenuItem_Click);
            // 
            // yellowOnBlueToolStripMenuItem
            // 
            this.yellowOnBlueToolStripMenuItem.BackColor = System.Drawing.Color.Navy;
            this.yellowOnBlueToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.yellowOnBlueToolStripMenuItem.Name = "yellowOnBlueToolStripMenuItem";
            this.yellowOnBlueToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.yellowOnBlueToolStripMenuItem.Text = "Yellow on Blue";
            this.yellowOnBlueToolStripMenuItem.Click += new System.EventHandler(this.yellowOnBlueToolStripMenuItem_Click);
            // 
            // blackOnYellowToolStripMenuItem1
            // 
            this.blackOnYellowToolStripMenuItem1.BackColor = System.Drawing.Color.Yellow;
            this.blackOnYellowToolStripMenuItem1.Name = "blackOnYellowToolStripMenuItem1";
            this.blackOnYellowToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.blackOnYellowToolStripMenuItem1.Text = "Black on Yellow";
            this.blackOnYellowToolStripMenuItem1.Click += new System.EventHandler(this.blackOnYellowToolStripMenuItem_Click);
            // 
            // blaToolStripMenuItem
            // 
            this.blaToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.blaToolStripMenuItem.Name = "blaToolStripMenuItem";
            this.blaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.blaToolStripMenuItem.Text = "Black on Pale Blue";
            this.blaToolStripMenuItem.Click += new System.EventHandler(this.blackOnPaleBlueToolStripMenuItem_Click);
            // 
            // blackOnCreamToolStripMenuItem1
            // 
            this.blackOnCreamToolStripMenuItem1.BackColor = System.Drawing.Color.Cornsilk;
            this.blackOnCreamToolStripMenuItem1.Name = "blackOnCreamToolStripMenuItem1";
            this.blackOnCreamToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.blackOnCreamToolStripMenuItem1.Text = "Black on Cream";
            this.blackOnCreamToolStripMenuItem1.Click += new System.EventHandler(this.blackOnCreamToolStripMenuItem_Click);
            // 
            // blackOnPinkToolStripMenuItem1
            // 
            this.blackOnPinkToolStripMenuItem1.BackColor = System.Drawing.Color.MistyRose;
            this.blackOnPinkToolStripMenuItem1.Name = "blackOnPinkToolStripMenuItem1";
            this.blackOnPinkToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.blackOnPinkToolStripMenuItem1.Text = "Black on Pink";
            this.blackOnPinkToolStripMenuItem1.Click += new System.EventHandler(this.blackOnPinkToolStripMenuItem_Click);
            // 
            // settingsReverse
            // 
            this.settingsReverse.Name = "settingsReverse";
            this.settingsReverse.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.settingsReverse.Size = new System.Drawing.Size(223, 22);
            this.settingsReverse.Text = "Reverse Colours";
            this.settingsReverse.ToolTipText = "Reverse the foreground and background colours";
            this.settingsReverse.Click += new System.EventHandler(this.settingsReverse_Click);
            // 
            // settingsBg
            // 
            this.settingsBg.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem,
            this.whiteToolStripMenuItem,
            this.yellowToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.paleBlueToolStripMenuItem,
            this.creamToolStripMenuItem,
            this.pinkToolStripMenuItem,
            this.moreBgMenuItem});
            this.settingsBg.Name = "settingsBg";
            this.settingsBg.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.settingsBg.Size = new System.Drawing.Size(223, 22);
            this.settingsBg.Text = "Change Background";
            this.settingsBg.ToolTipText = "Change the background colour";
            this.settingsBg.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.settingsBg_DropDownItemClicked);
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.blackToolStripMenuItem.Text = "Black";
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.whiteToolStripMenuItem.Text = "White";
            // 
            // yellowToolStripMenuItem
            // 
            this.yellowToolStripMenuItem.BackColor = System.Drawing.Color.Yellow;
            this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            this.yellowToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.yellowToolStripMenuItem.Text = "Yellow";
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.BackColor = System.Drawing.Color.Navy;
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.blueToolStripMenuItem.Text = "Blue";
            // 
            // paleBlueToolStripMenuItem
            // 
            this.paleBlueToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.paleBlueToolStripMenuItem.Name = "paleBlueToolStripMenuItem";
            this.paleBlueToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.paleBlueToolStripMenuItem.Text = "Pale Blue";
            // 
            // creamToolStripMenuItem
            // 
            this.creamToolStripMenuItem.BackColor = System.Drawing.Color.Cornsilk;
            this.creamToolStripMenuItem.Name = "creamToolStripMenuItem";
            this.creamToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.creamToolStripMenuItem.Text = "Cream";
            // 
            // pinkToolStripMenuItem
            // 
            this.pinkToolStripMenuItem.BackColor = System.Drawing.Color.MistyRose;
            this.pinkToolStripMenuItem.Name = "pinkToolStripMenuItem";
            this.pinkToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.pinkToolStripMenuItem.Text = "Pink";
            // 
            // moreBgMenuItem
            // 
            this.moreBgMenuItem.Name = "moreBgMenuItem";
            this.moreBgMenuItem.Size = new System.Drawing.Size(125, 22);
            this.moreBgMenuItem.Text = "Custom...";
            this.moreBgMenuItem.Click += new System.EventHandler(this.moreBgMenuItem_Click);
            // 
            // settingsFg
            // 
            this.settingsFg.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem1,
            this.whiteToolStripMenuItem1,
            this.yellowToolStripMenuItem1,
            this.blueToolStripMenuItem1,
            this.paleBlueToolStripMenuItem1,
            this.creamToolStripMenuItem1,
            this.pinkToolStripMenuItem1,
            this.moreFgMenuItem});
            this.settingsFg.Name = "settingsFg";
            this.settingsFg.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.settingsFg.Size = new System.Drawing.Size(223, 22);
            this.settingsFg.Text = "Change Text Colour";
            this.settingsFg.ToolTipText = "Change the text colour";
            this.settingsFg.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.settingsFg_DropDownItemClicked);
            // 
            // blackToolStripMenuItem1
            // 
            this.blackToolStripMenuItem1.Name = "blackToolStripMenuItem1";
            this.blackToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.blackToolStripMenuItem1.Text = "Black";
            // 
            // whiteToolStripMenuItem1
            // 
            this.whiteToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.whiteToolStripMenuItem1.Name = "whiteToolStripMenuItem1";
            this.whiteToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.whiteToolStripMenuItem1.Text = "White";
            // 
            // yellowToolStripMenuItem1
            // 
            this.yellowToolStripMenuItem1.ForeColor = System.Drawing.Color.Yellow;
            this.yellowToolStripMenuItem1.Name = "yellowToolStripMenuItem1";
            this.yellowToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.yellowToolStripMenuItem1.Text = "Yellow";
            // 
            // blueToolStripMenuItem1
            // 
            this.blueToolStripMenuItem1.ForeColor = System.Drawing.Color.Navy;
            this.blueToolStripMenuItem1.Name = "blueToolStripMenuItem1";
            this.blueToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.blueToolStripMenuItem1.Text = "Blue";
            // 
            // paleBlueToolStripMenuItem1
            // 
            this.paleBlueToolStripMenuItem1.ForeColor = System.Drawing.Color.AliceBlue;
            this.paleBlueToolStripMenuItem1.Name = "paleBlueToolStripMenuItem1";
            this.paleBlueToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.paleBlueToolStripMenuItem1.Text = "Pale Blue";
            // 
            // creamToolStripMenuItem1
            // 
            this.creamToolStripMenuItem1.ForeColor = System.Drawing.Color.Cornsilk;
            this.creamToolStripMenuItem1.Name = "creamToolStripMenuItem1";
            this.creamToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.creamToolStripMenuItem1.Text = "Cream";
            // 
            // pinkToolStripMenuItem1
            // 
            this.pinkToolStripMenuItem1.ForeColor = System.Drawing.Color.MistyRose;
            this.pinkToolStripMenuItem1.Name = "pinkToolStripMenuItem1";
            this.pinkToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.pinkToolStripMenuItem1.Text = "Pink";
            // 
            // moreFgMenuItem
            // 
            this.moreFgMenuItem.Name = "moreFgMenuItem";
            this.moreFgMenuItem.Size = new System.Drawing.Size(125, 22);
            this.moreFgMenuItem.Text = "Custom...";
            this.moreFgMenuItem.Click += new System.EventHandler(this.moreFgMenuItem_Click);
            // 
            // settingsFont
            // 
            this.settingsFont.AccessibleName = "Size Combo Box";
            this.settingsFont.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.sizeToolStripMenuItem});
            this.settingsFont.Name = "settingsFont";
            this.settingsFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.settingsFont.Size = new System.Drawing.Size(223, 22);
            this.settingsFont.Text = "Change Font";
            this.settingsFont.ToolTipText = "Change the menu font";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.AccessibleName = "Font Combo Box";
            this.fontToolStripMenuItem.DropDownWidth = 352;
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(152, 23);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.SelectedIndexChanged += new System.EventHandler(this.fontToolStripMenuItem_SelectedIndexChanged);
            this.fontToolStripMenuItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fontToolStripMenuItem_KeyDown);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(152, 23);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.SelectedIndexChanged += new System.EventHandler(this.sizeToolStripMenuItem_SelectedIndexChanged);
            this.sizeToolStripMenuItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sizeToolStripMenuItem_KeyDown);
            // 
            // settingsDefaultFont
            // 
            this.settingsDefaultFont.Name = "settingsDefaultFont";
            this.settingsDefaultFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.settingsDefaultFont.Size = new System.Drawing.Size(223, 22);
            this.settingsDefaultFont.Text = "Default Font";
            this.settingsDefaultFont.ToolTipText = "Reset to the default font";
            this.settingsDefaultFont.Click += new System.EventHandler(this.settingsDefaultFont_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.AccessibleName = "Help Menu";
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyboardShortcutsToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.helpMenu.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpMenu.Size = new System.Drawing.Size(44, 19);
            this.helpMenu.Text = "Help";
            // 
            // keyboardShortcutsToolStripMenuItem
            // 
            this.keyboardShortcutsToolStripMenuItem.Name = "keyboardShortcutsToolStripMenuItem";
            this.keyboardShortcutsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.keyboardShortcutsToolStripMenuItem.Text = "Keyboard Shortcuts";
            this.keyboardShortcutsToolStripMenuItem.ToolTipText = "View a list of all keyboard shortcuts";
            this.keyboardShortcutsToolStripMenuItem.Click += new System.EventHandler(this.keyboardShortcutsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            this.toolStripContainer1.BottomToolStripPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripContainer1.BottomToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(279, 252);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(279, 299);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(279, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel1
            // 
            this.statusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(46, 19);
            this.statusLabel1.Text = "Ready";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.appTree);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 252);
            this.panel1.TabIndex = 1;
            // 
            // appTree
            // 
            this.appTree.AccessibleDescription = "The list of available applications, grouped by category.";
            this.appTree.AccessibleName = "Application List";
            this.appTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.appTree.Location = new System.Drawing.Point(0, 0);
            this.appTree.Margin = new System.Windows.Forms.Padding(3, 3, 1, 30);
            this.appTree.Name = "appTree";
            this.appTree.Size = new System.Drawing.Size(279, 251);
            this.appTree.TabIndex = 0;
            this.appTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.appTree_NodeMouseDoubleClick);
            this.appTree.Enter += new System.EventHandler(this.appTree_Enter);
            this.appTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.appTree_NodeMouseClick);
            this.appTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.appTree_KeyDown);
            this.appTree.Click += new System.EventHandler(this.appTree_Click);
            // 
            // appTreeContextMenu
            // 
            this.appTreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchToolStripMenuItem,
            this.descriptionToolStripMenuItem,
            this.hToolStripMenuItem});
            this.appTreeContextMenu.Name = "appTreeContextMenu";
            this.appTreeContextMenu.ShowImageMargin = false;
            this.appTreeContextMenu.Size = new System.Drawing.Size(142, 70);
            // 
            // launchToolStripMenuItem
            // 
            this.launchToolStripMenuItem.AccessibleName = "Launch Application";
            this.launchToolStripMenuItem.Name = "launchToolStripMenuItem";
            this.launchToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.launchToolStripMenuItem.Text = "Launch";
            this.launchToolStripMenuItem.ToolTipText = "Launch this application";
            this.launchToolStripMenuItem.Click += new System.EventHandler(this.launchToolStripMenuItem_Click);
            // 
            // descriptionToolStripMenuItem
            // 
            this.descriptionToolStripMenuItem.AccessibleName = "Edit Description...";
            this.descriptionToolStripMenuItem.Name = "descriptionToolStripMenuItem";
            this.descriptionToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.descriptionToolStripMenuItem.Text = "Edit Description...";
            this.descriptionToolStripMenuItem.ToolTipText = "Change the description that appears in brackets for this application";
            this.descriptionToolStripMenuItem.Click += new System.EventHandler(this.descriptionToolStripMenuItem_Click);
            // 
            // hToolStripMenuItem
            // 
            this.hToolStripMenuItem.AccessibleName = "Hide Application";
            this.hToolStripMenuItem.Name = "hToolStripMenuItem";
            this.hToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.hToolStripMenuItem.Text = "Hide Application";
            this.hToolStripMenuItem.ToolTipText = "Hide this application until the menu is re-launched";
            this.hToolStripMenuItem.Click += new System.EventHandler(this.hToolStripMenuItem_Click);
            // 
            // MenuForm
            // 
            this.AccessibleDescription = "Application Menu";
            this.AccessibleName = "Application Menu";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(279, 299);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(295, 335);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Access Tools";
            this.Shown += new System.EventHandler(this.MenuForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.Resize += new System.EventHandler(this.MenuForm_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.appTreeContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuExit;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsColourScheme;
        private System.Windows.Forms.ToolStripMenuItem blackOnWhiteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem whiteOnBlackToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yellowOnBlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackOnYellowToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsReverse;
        private System.Windows.Forms.ToolStripMenuItem settingsFont;
        private System.Windows.Forms.ToolStripMenuItem settingsDefaultFont;
        private System.Windows.Forms.ToolStripMenuItem settingsBg;
        private System.Windows.Forms.ToolStripMenuItem settingsFg;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem keyboardShortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem blaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackOnCreamToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem blackOnPinkToolStripMenuItem1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paleBlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem paleBlueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem creamToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pinkToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView appTree;
        private System.Windows.Forms.ToolStripMenuItem moreBgMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem moreFgMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.ContextMenuStrip appTreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem launchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolStripComboBox fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox sizeToolStripMenuItem;
    }
}