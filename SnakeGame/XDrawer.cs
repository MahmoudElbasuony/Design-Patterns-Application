using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class XDrawer : Drawer
    {
        public XDrawer(Graphics graphics) : base(graphics)
        {

        }
        public override void Draw(Shape shape)
        {
            if (shape is Food)
            {
                var food = (Food)shape;
                _graphics.DrawRectangle(new Pen(food.Color, 2), food.X, food.Y, food.Width, food.Height);
            }
            else if(shape is SnakePart)
            {
                var snakePart = (SnakePart)shape;
                _graphics.DrawRectangle(new Pen(snakePart.Color, 2), snakePart.X, snakePart.Y, snakePart.Width, snakePart.Height);
            }
        }
    }
}
