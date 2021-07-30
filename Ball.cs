using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace c_sharp_pong
{
    public class GoalEventArgs : EventArgs // colon makes GoalEventArgs inherit from the EventArgs class
    {
        public string scorer;
    }
    class Ball
    {
        public double x = 10;
        public double y = 300;
        public double vx = -3;
        public double vy = 0;
        public float courseW;
        public float courseH;
        public event EventHandler<GoalEventArgs> Goal; 

       
        public void Render(Graphics graphics, RightPaddle rightPaddle, LeftPaddle leftPaddle)
        { 
            graphics.FillRectangle(new SolidBrush(Color.White), (int)x, (int)y, 10, 10);

            x += vx;
            y += vy;
         
            if (x > courseW)
            {
                vy = 0;
                x = courseW / 2;
                vx = 3;   // the direction and velocity the ball resets to after a goal on computer
                y = rightPaddle.y;
                GoalEventArgs args = new GoalEventArgs();
                args.scorer = "Left";
                onGoal(args);
                
            }
            else if (x < 0)
            {
                vy = 0;
                vx = -3;    // the direction and velocity the ball resets to after a goal on player
                x = courseW / 2;
                y = leftPaddle.y;
                GoalEventArgs args = new GoalEventArgs();
                args.scorer = "Right";
                onGoal(args);
            }
            if( y > courseH - 10)
            {
                vy = -vy;
            }
            else if( y < 0)
            {
                vy = -vy;
            }
        }
        protected virtual void onGoal(GoalEventArgs e) // an event is something that is THROWN
        {
            EventHandler<GoalEventArgs> handler = Goal; // the handler is listening to the event
            handler?.Invoke(this, e); // the ? is there because there might not be a handler when the event gets called
        }

        public Ball(float courseWidth, float courseHeight)
        {
            courseW = courseWidth;
            courseH = courseHeight;
        }
    }
}
