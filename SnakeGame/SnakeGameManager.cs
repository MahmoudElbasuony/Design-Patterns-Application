using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public class SnakeGameManager
    {
        private Graphics _graphics;
        private Board _board;
        private Drawer _drawer;
        private ISnakeFactory _snakeFactory;
        private SizeF _screenSize;
        private LevelInitializer _levelInitializer;
        public event Action SnakeColided;
        private static SnakeGameManager _snakeGameManager;
        private static object _lock = new object();

        private SnakeGameManager(Graphics graphics, SizeF screenSize)
        {
            _graphics = graphics;
            _screenSize = screenSize;
            _drawer = new XDrawer(_graphics);

            // Initialize Board
            _board = new XBoard(_drawer, _screenSize.Width, _screenSize.Height);

            // Level Initialization
            _snakeFactory = new SnakeFactory();
            _levelInitializer = new XLevelInitializer(_snakeFactory);
            _levelInitializer.InitializeLevel(_board, GameMode.Easy);
            _levelInitializer.SnakeColided += () => { SnakeColided?.Invoke(); };
        }

        public static SnakeGameManager Instance(Graphics graphics, SizeF screenSize)
        {
            if (_snakeGameManager == null)
            {
                lock (_lock)
                {
                    if (_snakeGameManager == null)
                    {
                        _snakeGameManager = new SnakeGameManager(graphics, screenSize);
                    }
                }
            }
            return _snakeGameManager;
        }



        public void UpdateBoard(ArrowDirection arrowDirection)
        {
            _board.UpdateBoard(_drawer, arrowDirection);
        }



    }
}
