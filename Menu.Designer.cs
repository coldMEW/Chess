namespace Chess
{
    partial class Menu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.SinglePlayer = new System.Windows.Forms.Button();
            this.TwoPlayer = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.DifficultyInput = new System.Windows.Forms.ComboBox();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            this.SinglePlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SinglePlayer.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SinglePlayer.Location = new System.Drawing.Point(167, 235);
            this.SinglePlayer.Name = "SinglePlayer";
            this.SinglePlayer.Size = new System.Drawing.Size(187, 51);
            this.SinglePlayer.TabIndex = 0;
            this.SinglePlayer.Text = "Single Player";
            this.SinglePlayer.UseVisualStyleBackColor = true;
            this.SinglePlayer.Click += new System.EventHandler(this.SinglePlayer_Click);
            this.TwoPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TwoPlayer.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwoPlayer.Location = new System.Drawing.Point(167, 310);
            this.TwoPlayer.Name = "TwoPlayer";
            this.TwoPlayer.Size = new System.Drawing.Size(187, 50);
            this.TwoPlayer.TabIndex = 1;
            this.TwoPlayer.Text = "Two Player";
            this.TwoPlayer.UseVisualStyleBackColor = true;
            this.TwoPlayer.Click += new System.EventHandler(this.TwoPlayer_Click);
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Franklin Gothic Heavy", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Title.Location = new System.Drawing.Point(228, 38);
            this.Title.Name = "Title";
            this.Title.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Title.Size = new System.Drawing.Size(77, 26);
            this.Title.TabIndex = 2;
            this.Title.Text = "CHESS";
            this.pictureBox3.BackgroundImage = global::Chess.Properties.Resources.WKing;
            this.pictureBox3.InitialImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox3.Location = new System.Drawing.Point(233, 67);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(67, 72);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            this.pictureBox2.BackgroundImage = global::Chess.Properties.Resources.WKing;
            this.pictureBox2.InitialImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox2.Location = new System.Drawing.Point(167, 383);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 72);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox1.BackgroundImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox1.InitialImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox1.Location = new System.Drawing.Point(288, 383);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 72);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.OptionsButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsButton.Location = new System.Drawing.Point(167, 497);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(187, 50);
            this.OptionsButton.TabIndex = 12;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            this.DifficultyInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DifficultyInput.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyInput.FormattingEnabled = true;
            this.DifficultyInput.Items.AddRange(new object[] {
            "Basic",
            "Mid",
            "High"});
            this.DifficultyInput.Location = new System.Drawing.Point(167, 175);
            this.DifficultyInput.Name = "DifficultyInput";
            this.DifficultyInput.Size = new System.Drawing.Size(187, 24);
            this.DifficultyInput.TabIndex = 13;
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyLabel.Location = new System.Drawing.Point(225, 142);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(75, 16);
            this.DifficultyLabel.TabIndex = 14;
            this.DifficultyLabel.Text = "Difficulty";
            this.pictureBox4.BackgroundImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox4.InitialImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox4.Location = new System.Drawing.Point(378, 165);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(137, 140);
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            this.pictureBox5.BackgroundImage = global::Chess.Properties.Resources.WKing;
            this.pictureBox5.InitialImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox5.Location = new System.Drawing.Point(12, 165);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(138, 140);
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            this.pictureBox6.BackgroundImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox6.InitialImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox6.Location = new System.Drawing.Point(233, 67);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(36, 72);
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(536, 559);
            this.Controls.Add(this.DifficultyLabel);
            this.Controls.Add(this.DifficultyInput);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.TwoPlayer);
            this.Controls.Add(this.SinglePlayer);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button SinglePlayer;
        private System.Windows.Forms.Button TwoPlayer;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.ComboBox DifficultyInput;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}

