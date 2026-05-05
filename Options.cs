using System;
using System.Windows.Forms;

namespace Chess
{
    // Simple settings window for names, time control, and optional board labels.
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        public void ApplyButton_Click(object sender, EventArgs e)
        {
            // Save the chosen settings so the next game window can use them.
            string Player1Name = POneNameInput.Text;
            string Player2Name = PTwoNameInput.Text;

            int TimeControl = 120;

            if (NTCcheckbox.Checked)
            {
                TimeControl = -1;
            } 
            else
            {
                try
                {
                    TimeControl = Convert.ToInt32(TimeInput.Text);
                }
                catch
                {
                    TimeControl = 120;
                }
            }

            if (SSNcheckbox.Checked)
            {
                GameWindow.ShowBoardSquareNumbers = true;
            }

            GameWindow.TimeControl = TimeControl;
            GameWindow.Player1Name = Player1Name;
            GameWindow.Player2Name = Player2Name;

            this.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {

        }
    }
}

