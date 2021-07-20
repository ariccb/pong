using pong;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace pong
{
    class Game
    {
        public Canvas window;

        public Game(Canvas canvas)
        {
            window = canvas;
            canvas.Paint += Canvas_Paint; // this is listening for when the window is painted
        }

        private void Canvas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
        }
    }
}
