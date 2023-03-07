using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace BallDodgeTemplate
{
    internal class Ball
    {
        public int x, y, xSpeed, ySpeed;
        public int size = 20;

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }

        public void Move(int w, int h)
        {
            x += xSpeed;
            y += ySpeed;
            if (x < 0 - size)
            {
                x = w;
            }
            else if (x > w)
            {
                x = 0;
            }
            if (y < 0 - size)
            {
                y = h;
            }
            else if(y > h)
            {
                y = 0;
            }
        }

        public bool Collision(Ball b)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle ball2Rec = new Rectangle(b.x, b.y, b.size, b.size);

            if (ballRec.IntersectsWith(ball2Rec))
            {
                return true;
            }
            return false;
        }

        public bool Collision(Player p)  
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(playerRec))
            {
                return true;

            }
            return false;
        }
    }
}
