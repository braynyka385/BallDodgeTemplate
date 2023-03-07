using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallDodgeTemplate
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            gameOverLabel.Text = "Game over! You got " + GameScreen.score + " points!";
            if(GameScreen.score == -1)
            {
                gameOverLabel.Text = "YOU WON!!!!";
            }
        }
    }
}
