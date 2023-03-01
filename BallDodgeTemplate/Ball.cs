using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDodgeTemplate
{
    internal class Ball
    {
        public int x, y, xSpeed, ySpeed;
        public int size = 15;

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
            if (x < 0 || x > w - size)
            {
                xSpeed *= -1;
            }
            if (y < 0 || y > h - size)
            {
                ySpeed *= -1;
            }
        }
    }
}
