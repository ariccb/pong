using c_sharp_pong;
using spaceinvaders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace spaceinvaders
{
    class Game
    {
        public Canvas window;
        private Thread gameLoopThread;
        public bool canvasClosed = false;
        private Ball ball;
        private LeftPaddle leftPaddle;
        private RightPaddle rightPaddle;
        public float courseWidth;
        public float courseHeight;
        public int leftScore = 0;
        public int rightScore = 0;

        public Game(Canvas canvas)
        {
            courseWidth = 700;
            courseHeight = 700;
            window = canvas;
            canvas.Paint += Canvas_Paint; // this is listening for when the window is painted
            ball = new Ball(courseWidth, courseHeight);
            leftPaddle = new LeftPaddle(courseWidth, courseHeight);
            rightPaddle = new RightPaddle(courseWidth, courseHeight);
            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.IsBackground = true; //attempt to solve thread running after window closes
            gameLoopThread.Start();
            canvas.KeyDown += Canvas_KeyPress;
            canvas.KeyUp += Canvas_KeyRelease;
            ball.Goal += Score; // this is declaring a listener (ball.Goal) after += is the function that is called when the listener is activated.
            }

        private void Canvas_KeyRelease(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                rightPaddle.vy = 0;
            }
            else if(e.KeyCode == Keys.Down)
            {
                rightPaddle.vy = 0;
            }
            if(e.KeyCode ==Keys.W || leftPaddle.y < 0)
            {
                leftPaddle.vy = 0;
            }
            else if(e.KeyCode == Keys.S ||leftPaddle.y > courseHeight - leftPaddle.paddleHeight)
            {
                leftPaddle.vy = 0;
            }
        }

        private void Canvas_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                rightPaddle.vy = -2;
            }
            else if (e.KeyCode == Keys.Down)
            {
                rightPaddle.vy = 2;
            }
            if (e.KeyCode == Keys.W && leftPaddle.y > 0)
            {
                leftPaddle.vy = -2;
            }
            else if (e.KeyCode == Keys.S)
            {
                leftPaddle.vy = 2;
            }
            
        }
    
        

        private void Canvas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font scoreFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font bigscoreFont = new System.Drawing.Font("Consolas", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            graphics.Clear(Color.Black);
            ball.Render(graphics, rightPaddle, leftPaddle);
            rightPaddle.Render(graphics, ball, leftPaddle);
            leftPaddle.Render(graphics, ball);
            graphics.DrawString("Score", scoreFont, new SolidBrush(Color.White), new PointF(courseWidth/2, courseHeight + 20));
            graphics.DrawString(leftScore.ToString(), scoreFont, new SolidBrush(Color.White), new PointF((courseWidth / 2) - 50, courseHeight + 40));
            graphics.DrawString(rightScore.ToString(), scoreFont, new SolidBrush(Color.White), new PointF((courseWidth / 2) + 75, courseHeight + 40));
            graphics.FillRectangle(new SolidBrush(Color.White), 0, courseHeight, courseWidth, 10);
            if (leftScore >= 5)
            {
                ball.vx = 0;
                ball.vy = 0;
                graphics.DrawString("Player Wins!", bigscoreFont, new SolidBrush(Color.White), new PointF(((courseWidth / 2) - 200), (courseHeight / 2)));
            }
            else if (rightScore >= 5)
            {
                ball.vx = 0;
                ball.vy = 0;
                graphics.DrawString("Computer Wins!", bigscoreFont, new SolidBrush(Color.White), new PointF(((courseWidth / 2) - 200), (courseHeight / 2)));
            }

        }

        public void Score(object sender, GoalEventArgs e)
        {
            if (e.scorer == "Left")
            {
                leftScore++; //same as saying leftScore + 1;
            }
            else if(e.scorer == "Right")
            {
                rightScore++;
            }
            
        }


        public void GameLoop()
        {
            while (gameLoopThread.IsAlive&&!canvasClosed) // the && checks for a logical condition  - if canvasClosed is NOT closed
            {
                window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                Thread.Sleep(1);
            }
        }

    }
}
