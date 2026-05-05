namespace Chess
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.POneNameInput = new System.Windows.Forms.TextBox();
            this.PTwoNameInput = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeInput = new System.Windows.Forms.TextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NTCcheckbox = new System.Windows.Forms.CheckBox();
            this.SSNcheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            this.pictureBox2.BackgroundImage = global::Chess.Properties.Resources.WKing;
            this.pictureBox2.InitialImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox2.Location = new System.Drawing.Point(86, 152);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 111);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.POneNameInput.Location = new System.Drawing.Point(232, 195);
            this.POneNameInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.POneNameInput.Name = "POneNameInput";
            this.POneNameInput.Size = new System.Drawing.Size(148, 26);
            this.POneNameInput.TabIndex = 6;
            this.POneNameInput.Text = "Player 1";
            this.PTwoNameInput.Location = new System.Drawing.Point(662, 195);
            this.PTwoNameInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PTwoNameInput.Name = "PTwoNameInput";
            this.PTwoNameInput.Size = new System.Drawing.Size(148, 26);
            this.PTwoNameInput.TabIndex = 7;
            this.PTwoNameInput.Text = "Player 2";
            this.pictureBox1.BackgroundImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox1.InitialImage = global::Chess.Properties.Resources.BKing;
            this.pictureBox1.Location = new System.Drawing.Point(518, 152);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 111);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Player Names";
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(543, 463);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "TimeControl (s):\r\n";
            this.TimeInput.Location = new System.Drawing.Point(716, 458);
            this.TimeInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TimeInput.Name = "TimeInput";
            this.TimeInput.Size = new System.Drawing.Size(62, 26);
            this.TimeInput.TabIndex = 13;
            this.TimeInput.Text = "120";
            this.ApplyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ApplyButton.Location = new System.Drawing.Point(309, 620);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(284, 85);
            this.ApplyButton.TabIndex = 15;
            this.ApplyButton.Text = "Apply And Close";
            this.ApplyButton.UseVisualStyleBackColor = false;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(316, 340);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Time Control";
            this.NTCcheckbox.AutoSize = true;
            this.NTCcheckbox.Location = new System.Drawing.Point(309, 458);
            this.NTCcheckbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NTCcheckbox.Name = "NTCcheckbox";
            this.NTCcheckbox.Size = new System.Drawing.Size(141, 24);
            this.NTCcheckbox.TabIndex = 19;
            this.NTCcheckbox.Text = "No Time Control";
            this.NTCcheckbox.UseVisualStyleBackColor = true;
            this.SSNcheckbox.AutoSize = true;
            this.SSNcheckbox.Location = new System.Drawing.Point(64, 457);
            this.SSNcheckbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SSNcheckbox.Name = "SSNcheckbox";
            this.SSNcheckbox.Size = new System.Drawing.Size(192, 24);
            this.SSNcheckbox.TabIndex = 20;
            this.SSNcheckbox.Text = "Show Square Numbers\r\n";
            this.SSNcheckbox.UseVisualStyleBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(876, 760);
            this.Controls.Add(this.SSNcheckbox);
            this.Controls.Add(this.NTCcheckbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.TimeInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PTwoNameInput);
            this.Controls.Add(this.POneNameInput);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox POneNameInput;
        private System.Windows.Forms.TextBox PTwoNameInput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TimeInput;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox NTCcheckbox;
        private System.Windows.Forms.CheckBox SSNcheckbox;
    }
}
