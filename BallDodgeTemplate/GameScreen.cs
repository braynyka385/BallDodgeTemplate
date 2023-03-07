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
        public static int score = 0;
        public static int lives = 5;
        public static int difficulty;

        Ball chaseBall;
        List<Ball> balls = new List<Ball>();

        Player hero;
        bool leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Random randGen = new Random();
        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            int x = randGen.Next(10, this.Width-30);
            int y = randGen.Next(10, this.Height-30);
            chaseBall = new Ball(x, y, 10, 10);

            for(int i = 0; i < difficulty; i++)
            {
                NewBall();
            }

            hero = new Player(50, 100);
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            //hero.x += (leftArrowDown ? 0 : hero.speed) - (rightArrowDown ? 0 : hero.speed);
            //hero.y += (upArrowDown ? 0 : hero.speed) - (downArrowDown ? 0 : hero.speed);
            if (upArrowDown && hero.y > 0)
            {
                hero.Move("up");
            }
            if (downArrowDown && hero.y < this.Height - hero.height)
            {
                hero.Move("down");
            }
            if (leftArrowDown && hero.x > 0)
            {
                hero.Move("left");
            }
            if (rightArrowDown && hero.x < this.Width - hero.width)
            {
                hero.Move("right");
            }
            chaseBall.Move(this.Width, this.Height);
            foreach (Ball b in balls)
	        {
                b.Move(this.Width, this.Height);
	        }

            foreach (Ball b in balls)
	        {
                chaseBall.Collision(b);
                
	        }
            foreach (Ball b in balls)
	        {
                if (b.Collision(hero))
                {
                    NewBall();
                    lives--;
                    break;
                }
	        }

            if(lives == 0)
            {
                Form1.ChangeScreen(this, new GameOverScreen());
                gameEngine.Stop();
            }
            
            if (chaseBall.Collision(hero))
            {
                lives++;
                score++;
                balls.RemoveAt(balls.Count - 1);
            }
            if (balls.Count == 0)
            {
                score = -1;
                Form1.ChangeScreen(this, new GameOverScreen());
                gameEngine.Stop();
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, hero.x, hero.y, hero.width, hero.height);
            e.Graphics.FillEllipse(greenBrush, chaseBall.x, chaseBall.y, chaseBall.size, chaseBall.size);

            foreach (Ball b in balls)
	        {
                e.Graphics.FillEllipse(redBrush, b.x, b.y, b.size, b.size);

	        }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode) 
            {
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        public void NewBall()
        {
                int x = randGen.Next(10, this.Width-30);
                int y = randGen.Next(10, this.Height-30);
                Ball ball = new Ball(x, y, 10, 10);
                balls.Add(ball);
        }
    }
}
