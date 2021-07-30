using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace c_sharp_pong
{
    class LeftPaddle
    {
        public double x = 0;
        public double y = 100;
        public double vy = 0;
        public double vx;
        public float paddleHeight = 60;
        public float paddleWidth;
        public float courseH;
        public float courseW;

        public LeftPaddle(float courseWidth, float courseHeight)
        {
            this.courseW = courseWidth;
            this.courseH = courseHeight;
            x = 0;
            y = courseH / 2;
            paddleWidth = 10;
            vx = 0;
            vy = 0;
        }
        public void Collision(Ball ball)
        {
            if (ball.x < 10)
            {
                if (ball.y > y - 10 && ball.y < y + paddleHeight)
                {
                    ball.vx = 4;
                    double diff = (ball.y + 10) - y;
                    int hitLoc = (int)Math.Floor((diff) / 10);
                    switch (hitLoc) // if hit location == case value
                    {
                        case 0:
                            ball.vy = -4;
                            break;
                        case 1:
                            ball.vy = -2;
                            break;
                        case 2:
                            ball.vy = -2;
                            break;
                        case 3:
                            ball.vy = 0;
                            break;
                        case 4:
                            ball.vy = 2;
                            break;
                        case 5:
                            ball.vy = 2;
                            break;
                        case 6:
                            ball.vy = 4;
                            break;
                    }
                }
            }
            
        }

        public void Render(Graphics graphics, Ball ball)
        {      
            if (y > courseH - paddleHeight && vy > 0)
            {
                vy = 0;
            }
            if (y < 0 && vy < 0)
            {
                vy = 0;
            }
            y += vy;
            Collision(ball);
            graphics.FillRectangle(new SolidBrush(Color.White), (int)x, (int)y, 10, paddleHeight);
        }

    }
    class RightPaddle
    {
        public double x = 275;
        public double y = 100;
        public double vy = 0;
        public double vx;
        public float paddleHeight = 60;
        public float paddleWidth;
        public float courseH;
        public float courseW;
        

        public RightPaddle(float courseWidth, float courseHeight)
        {
            this.courseW = courseWidth;
            this.courseH = courseHeight;
            x = courseW - 10;
            y = courseH / 2;
            paddleWidth = 10;
            vx = 0;
            vy = 0;
        }
        public void Collision(Ball ball)
        {
            if (ball.x > courseW - paddleWidth)
            {
                if (ball.y > y - 10 && ball.y < y + paddleHeight)
                {
                    ball.vx = -4;
                    double diff = (ball.y + 10) - y;
                    int hitLoc = (int)Math.Floor((diff) / 10);
                    switch (hitLoc) // if hit location == case value
                    {
                        case 0:
                            ball.vy = -4;
                            break;
                        case 1:
                            ball.vy = -3;
                            break;
                        case 2:
                            ball.vy = -2;
                            break;
                        case 3:
                            ball.vy = 0;
                            break;
                        case 4:
                            ball.vy = 2;
                            break;
                        case 5:
                            ball.vy = 3;
                            break;
                        case 6:
                            ball.vy = 4;
                            break;
                    }
                }
            }

        }

        public void Render(Graphics graphics, Ball ball, LeftPaddle leftPaddle)
        {
            AIHard(ball, leftPaddle);
            Collision(ball);
            y += vy;
            graphics.FillRectangle(new SolidBrush(Color.White), (int)x, (int)y, 10, paddleHeight);
        }


        public void AIMedium(Ball ball)
        {
            if (ball.y < y && ball.vx > 0 && y > 0)
            {
                vy = -2;
            }
            else if (ball.y > y - paddleHeight - 1 && ball.vx > 0 && y < courseH - paddleHeight)
            {
                vy = 2;
            }
            else if (ball.y < y && ball.vx < 0 && y > 0)
            {
                vy = -2;
            }
            else if (ball.y > y - paddleHeight - 1 && ball.vx < 0 && y < courseH - paddleHeight)
            {
                vy = 2;
            }
            else
            {
                vy = 0;
            }
        }
        public void AIHard(Ball ball, LeftPaddle leftPaddle)
        {
            if (ball.x < courseW / 3 && ball.y < courseH / 3 && ball.vx > 0 && ball.vy < -3 && ball.y < y && y > 0)
            {
                vy = ;
            }
            else if (ball.x < courseW / 3 && ball.y > courseH - (courseH / 3) && ball.vx > 0 && ball.vy > 3 && ball.y > y && y > 0)
            {
                vy = -3;
            }
            else if (ball.y < y && ball.vx > 0 && y > 0)
            {
                vy = -3;
            }
            else if (ball.y > y - paddleHeight - 1 && ball.vx > 0 && y < courseH - paddleHeight)
            {
                vy = 3;
            }
            else if (ball.y < y && ball.vx < 0 && y > 0)
            {
                vy = -3;
            }
            else if (ball.y > y - paddleHeight - 1 && ball.vx < 0 && y < courseH - paddleHeight)
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
