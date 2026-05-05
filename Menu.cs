using System;
using System.Windows.Forms;

namespace Chess
{
    // Home screen for choosing single-player or two-player and selecting difficulty.
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            DifficultyInput.SelectedIndex = 1;
        }
        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void TwoPlayer_Click(object sender, EventArgs e)
        {
            var TwoPlayer = new GameWindow(false);
            TwoPlayer.Show();
            Hide();
        }

        private void SinglePlayer_Click(object sender, EventArgs e)
        {
            // Save the selected difficulty before opening the single-player game.
            Computer.Difficulty = (BotDifficulty)DifficultyInput.SelectedIndex;
            var SinglePlayer = new GameWindow(true);
            SinglePlayer.Show();
            Hide();
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            var OptionsWindow = new Options();
            OptionsWindow.Show();
        }
    }
}

