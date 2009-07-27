namespace Test1
{
    partial class CustomColourBox
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
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMore = new System.Windows.Forms.Button();
            this.btnPink = new System.Windows.Forms.Button();
            this.btnPaleBlue = new System.Windows.Forms.Button();
            this.btnNavy = new System.Windows.Forms.Button();
            this.btnYellow = new System.Windows.Forms.Button();
            this.btnCream = new System.Windows.Forms.Button();
            this.btnBlack = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.AccessibleName = "Ok";
            this.btnOk.Location = new System.Drawing.Point(149, 113);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMore);
            this.panel1.Controls.Add(this.btnPink);
            this.panel1.Controls.Add(this.btnPaleBlue);
            this.panel1.Controls.Add(this.btnNavy);
            this.panel1.Controls.Add(this.btnYellow);
            this.panel1.Controls.Add(this.btnCream);
            this.panel1.Controls.Add(this.btnBlack);
            this.panel1.Controls.Add(this.btnWhite);
            this.panel1.Location = new System.Drawing.Point(37, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 100);
            this.panel1.TabIndex = 1;
            // 
            // btnMore
            // 
            this.btnMore.AccessibleName = "More Colours";
            this.btnMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.Location = new System.Drawing.Point(228, 52);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(70, 48);
            this.btnMore.TabIndex = 7;
            this.btnMore.Text = "More";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnPink
            // 
            this.btnPink.AccessibleName = "Pink";
            this.btnPink.BackColor = System.Drawing.Color.MistyRose;
            this.btnPink.Location = new System.Drawing.Point(152, 52);
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(70, 48);
            this.btnPink.TabIndex = 6;
            this.btnPink.UseVisualStyleBackColor = false;
            this.btnPink.Click += new System.EventHandler(this.btnPink_Click);
            // 
            // btnPaleBlue
            // 
            this.btnPaleBlue.AccessibleName = "Pale Blue";
            this.btnPaleBlue.BackColor = System.Drawing.Color.AliceBlue;
            this.btnPaleBlue.Location = new System.Drawing.Point(76, 52);
            this.btnPaleBlue.Name = "btnPaleBlue";
            this.btnPaleBlue.Size = new System.Drawing.Size(70, 48);
            this.btnPaleBlue.TabIndex = 5;
            this.btnPaleBlue.UseVisualStyleBackColor = false;
            this.btnPaleBlue.Click += new System.EventHandler(this.btnPaleBlue_Click);
            // 
            // btnNavy
            // 
            this.btnNavy.AccessibleName = "Navy Blue";
            this.btnNavy.BackColor = System.Drawing.Color.Navy;
            this.btnNavy.Location = new System.Drawing.Point(0, 52);
            this.btnNavy.Name = "btnNavy";
            this.btnNavy.Size = new System.Drawing.Size(70, 48);
            this.btnNavy.TabIndex = 4;
            this.btnNavy.UseVisualStyleBackColor = false;
            this.btnNavy.Click += new System.EventHandler(this.btnNavy_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.AccessibleName = "Yellow";
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.Location = new System.Drawing.Point(228, 0);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(70, 53);
            this.btnYellow.TabIndex = 3;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnCream
            // 
            this.btnCream.AccessibleName = "Cream";
            this.btnCream.BackColor = System.Drawing.Color.Cornsilk;
            this.btnCream.Location = new System.Drawing.Point(152, 0);
            this.btnCream.Name = "btnCream";
            this.btnCream.Size = new System.Drawing.Size(70, 53);
            this.btnCream.TabIndex = 2;
            this.btnCream.UseVisualStyleBackColor = false;
            this.btnCream.Click += new System.EventHandler(this.btnCream_Click);
            // 
            // btnBlack
            // 
            this.btnBlack.AccessibleName = "Black";
            this.btnBlack.BackColor = System.Drawing.Color.Black;
            this.btnBlack.Location = new System.Drawing.Point(76, 0);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(70, 53);
            this.btnBlack.TabIndex = 1;
            this.btnBlack.UseVisualStyleBackColor = false;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // btnWhite
            // 
            this.btnWhite.AccessibleName = "White";
            this.btnWhite.BackColor = System.Drawing.Color.White;
            this.btnWhite.Location = new System.Drawing.Point(0, 0);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(70, 53);
            this.btnWhite.TabIndex = 0;
            this.btnWhite.UseVisualStyleBackColor = false;
            this.btnWhite.Click += new System.EventHandler(this.btnWhite_Click);
            // 
            // CustomColourBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 139);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOk);
            this.Name = "CustomColourBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Colour";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPink;
        private System.Windows.Forms.Button btnPaleBlue;
        private System.Windows.Forms.Button btnNavy;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button btnCream;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}