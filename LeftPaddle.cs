using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace c_sharp_pong
{
    class LeftPaddle
    {
        private float x = 0;
        private float y = 100;
        private float vy = 0;


        public void Render(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.White), x, y, 10, 50);
        }
    }
}
