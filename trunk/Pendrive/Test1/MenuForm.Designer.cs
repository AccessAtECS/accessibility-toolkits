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
            this.colourComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // launchButton
            // 
            this.launchButton.AccessibleDescription = "Launch the selected application";
            this.launchButton.AccessibleName = "Launch";
            this.launchButton.Location = new System.Drawing.Point(33, 13);
            this.launchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(290, 31);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "Launch";
            this.launchButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.launchButton, "Launch the selected application");
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.AccessibleName = "Exit";
            this.exitButton.Location = new System.Drawing.Point(33, 208);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(290, 33);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.exitButton, "Exit the menu");
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // appTree
            // 
            this.appTree.AccessibleDescription = "A list of available applications, displayed as a tree format";
            this.appTree.AccessibleName = "Application Tree";
            this.appTree.Dock = System.Windows.Forms.DockStyle.Top;
            this.appTree.Location = new System.Drawing.Point(0, 0);
            this.appTree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.appTree.Name = "appTree";
            this.appTree.Size = new System.Drawing.Size(359, 259);
            this.appTree.TabIndex = 4;
            this.appTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.appTree_KeyDown);
            // 
            // colourButton
            // 
            this.colourButton.AccessibleDescription = "Button to open a dialog box to select a new colour for the menu background";
            this.colourButton.AccessibleName = "Change Background Colour";
            this.colourButton.Location = new System.Drawing.Point(33, 89);
            this.colourButton.Name = "colourButton";
            this.colourButton.Size = new System.Drawing.Size(290, 33);
            this.colourButton.TabIndex = 5;
            this.colourButton.Text = "Change Background Colour";
            this.colourButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.colourButton, "Change the background colour of the menu list and buttons");
            this.colourButton.UseVisualStyleBackColor = true;
            this.colourButton.Click += new System.EventHandler(this.colourButton_Click);
            // 
            // fontButton
            // 
            this.fontButton.AccessibleDescription = "Button to open a dialog box to choose the font used on the menu";
            this.fontButton.AccessibleName = "Change Font";
            this.fontButton.Location = new System.Drawing.Point(33, 167);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(290, 33);
            this.fontButton.TabIndex = 6;
            this.fontButton.Text = "Change Font";
            this.fontButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.fontButton, "Change the font used");
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // textColourButton
            // 
            this.textColourButton.AccessibleDescription = "Button to open a dialog box to select a new colour for the menu text";
            this.textColourButton.AccessibleName = "Change Text Colour";
            this.textColourButton.Location = new System.Drawing.Point(33, 128);
            this.textColourButton.Name = "textColourButton";
            this.textColourButton.Size = new System.Drawing.Size(290, 33);
            this.textColourButton.TabIndex = 7;
            this.textColourButton.Text = "Change Text Colour";
            this.textColourButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.textColourButton, "Change the text colour of the menu list and buttons");
            this.textColourButton.UseVisualStyleBackColor = true;
            this.textColourButton.Click += new System.EventHandler(this.textColourButton_Click);
            // 
            // colourComboBox
            // 
            this.colourComboBox.AccessibleDescription = "Select a combination of colours";
            this.colourComboBox.AccessibleName = "Colour Change";
            this.colourComboBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.colourComboBox.FormattingEnabled = true;
            this.colourComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colourComboBox.Items.AddRange(new object[] {
            "Black Text, White Background",
            "White Text, Black Background",
            "Yellow Text, Blue Background",
            "Black Text, Yellow Background",
            "Black Text, Pale Blue Background",
            "Black Text, Cream Background",
            "Black Text, Pink Background"});
            this.colourComboBox.Location = new System.Drawing.Point(33, 52);
            this.colourComboBox.Name = "colourComboBox";
            this.colourComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colourComboBox.Size = new System.Drawing.Size(290, 28);
            this.colourComboBox.TabIndex = 8;
            this.colourComboBox.Text = "Quick Colour Change";
            this.colourComboBox.SelectedIndexChanged += new System.EventHandler(this.colourComboBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.launchButton);
            this.panel1.Controls.Add(this.colourComboBox);
            this.panel1.Controls.Add(this.fontButton);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.colourButton);
            this.panel1.Controls.Add(this.textColourButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 244);
            this.panel1.TabIndex = 9;
            // 
            // MenuForm
            // 
            this.AccessibleDescription = "Application Menu";
            this.AccessibleName = "Application Menu";
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(359, 515);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.appTree);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Menu";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}