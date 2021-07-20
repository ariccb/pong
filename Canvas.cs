using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace pong
{
    class Canvas:Form
    {
        public Game game;
        public Canvas()
        {
            this.DoubleBuffered = true;
            this.Shown += Canvas_Shown; //Shown is the event, Canvas_Shown is the listener
        }

        private void Canvas_Shown(object sender, EventArgs e) // this is waiting for the window to be shown before creating the game
        {
            game = new Game(this);

        }
        //we need to clear the screen, because we want a different background

    }
}
