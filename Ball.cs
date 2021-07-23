using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace c_sharp_pong
{
    class Ball
    {
        private float x = 10;
        private float y = 90;
        private float vx = 2;
        private float vy = 2;

        public void Render(Graphics graphics)
        { 
            graphics.FillRectangle(new SolidBrush(Color.White), x, y, 10, 10);

            x += vx;
            y += vy;
            if (x > 250)
            {
                vx = -2;
            }
            else if (x < 0)
            {
                vx = 2;
            }
            if( y > 250)
            {
                vy = -2;
            }
            else if( y < 0)
            {
                vy = 2;
            }
        }
    }
}
