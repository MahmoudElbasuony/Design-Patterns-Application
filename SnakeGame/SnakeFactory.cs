using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class SnakeFactory : ISnakeFactory
    {
        public Snake CreateSnake(GameMode gameMode, RectangleF moveArea)
        {
            switch (gameMode)
            {
                case GameMode.Easy:
                case GameMode.Medium:
                case GameMode.Hard:
                default:
                    return new XSnake(moveArea);
            }
        }
    }
}
