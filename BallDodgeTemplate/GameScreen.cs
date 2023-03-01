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
    public partial class GameScreen : UserControl
    {
        Ball chaseBall = new Ball(100, 100, 10, 10);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        public GameScreen()
        {
            InitializeComponent();
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            chaseBall.Move(this.Width, this.Height);

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(greenBrush, chaseBall.x, chaseBall.y, chaseBall.size, chaseBall.size);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
