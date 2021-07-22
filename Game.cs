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
        public float x;
        public float y;
        public float v;

        public Game(Canvas canvas)
        {
            window = canvas;
            canvas.Paint += Canvas_Paint; // this is listening for when the window is painted
            x = 10;
            y = 10;
            v = 2;
            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();
        }

        private void Canvas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.Black);
            graphics.FillRectangle(new SolidBrush(Color.Green), x, y, 10, 10); //this is our 
            x += v;
            if(x > 250)
            {
                v = -2;
            }
            else if(x < 0)
            {
                v = 2;
            }
        }
        public void GameLoop()
        {
            while (gameLoopThread.IsAlive)
            {
                window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                Thread.Sleep(1);
            }
        }
    }
}
