using c_sharp_pong;
using pong;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace pong
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
            if(e.KeyCode ==Keys.W)
            {
                leftPaddle.vy = 0;
            }
            else if(e.KeyCode == Keys.S)
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
            if (e.KeyCode == Keys.W)
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
            graphics.Clear(Color.Black);
            ball.Render(graphics);
            rightPaddle.Render(graphics, ball);
            leftPaddle.Render(graphics, ball);


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
