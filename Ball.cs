using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace c_sharp_pong
{
    class Ball
    {
        public float x = 10;
        public float y = 90;
        public float vx = 2;
        public float vy = 2;
        public float courseW;
        public float courseH;

        public void Render(Graphics graphics)
        { 
            graphics.FillRectangle(new SolidBrush(Color.White), x, y, 10, 10);

            x += vx;
            y += vy;
         
            if (x > courseW)
            {
                vx = -2;
            }
            else if (x < 0)
            {
                vx = 2;
            }
            if( y > courseH)
            {
                vy = -2;
            }
            else if( y < 0)
            {
                vy = 2;
            }
        }

        public Ball(float courseWidth, float courseHeight)
        {
            courseW = courseWidth;
            courseH = courseHeight;
        }
    }
}
