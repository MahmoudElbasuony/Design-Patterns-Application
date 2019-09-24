using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public interface ISnakeFactory
    {
        Snake CreateSnake(GameMode gameMode, RectangleF moveArea);
    }
}
