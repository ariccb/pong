using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace c_sharp_pong
{
    class LeftPaddle
    {
        public float x = 0;
        public float y = 100;
        public float vy = 0;
        public float vx;
        public float height = 60;
        public float width;
        public float courseH;
        public float courseW;

        public LeftPaddle(float courseWidth, float courseHeight)
        {
            this.courseW = courseWidth;
            this.courseH = courseHeight;
            x = 0;
            y = courseH / 2;
            width = 10;
            vx = 0;
            vy = 0;
        }

        public void Render(Graphics graphics)
        {      
            y += vy;
            graphics.FillRectangle(new SolidBrush(Color.White), x, y, 10, 50);
        }

    }
    class RightPaddle
    {
        public float x = 275;
        public float y = 100;
        public float vy = 0;
        public float vx;
        public float height = 60;
        public float width;
        public float courseH;
        public float courseW;

        public RightPaddle(float courseWidth, float courseHeight)
        {
            this.courseW = courseWidth;
            this.courseH = courseHeight;
            x = courseW - 10;
            y = courseH / 2;
            width = 10;
            vx = 0;
            vy = 0;
        }

        public void Render(Graphics graphics, Ball ball)
        {
            AI(ball);
            /*Collision(ball);*/
            y += vy;
            graphics.FillRectangle(new SolidBrush(Color.White), x, y, 10, 50);
        }

        /*public void Collision(Ball ball)
        {
            if(ball.x > )
        }*/

        public void AI(Ball ball)
        {
            if (ball.y < y && ball.vx > 0)
            {
                vy = -3;
            }
            else if ( ball.y > y - height -1 && ball.vx > 0)
            {
                vy = 3;
            }
            else
            {
                vy = 0;
            }
        }
    }
}
