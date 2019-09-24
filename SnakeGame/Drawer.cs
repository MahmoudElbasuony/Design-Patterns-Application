using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{

    public abstract class Drawer
    {
        public abstract void Draw(Shape shape);
        protected Graphics _graphics;
        public void RefreshScreen(Color refreshColor)
        {
            _graphics.Clear(refreshColor);
        }
        public void RefreshScreen()
        {
            RefreshScreen(Color.White);
        }
        public Drawer(Graphics graphics)
        {
            _graphics = graphics;
        }
    }


}
