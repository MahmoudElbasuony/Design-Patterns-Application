using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public abstract class LevelInitializer
    {
        public abstract void InitializeLevel(Board board, GameMode gameMode);
        protected abstract Snake InitializeHeroSnake(Board board, GameMode gameMode);
        protected ISnakeFactory _snakeFactory { get; set; }
        public LevelInitializer(ISnakeFactory snakeFactory)
        {
            _snakeFactory = snakeFactory;
        }
        public event Action SnakeColided;
        protected void FireSnakeColided() => SnakeColided?.Invoke();
    }
}
