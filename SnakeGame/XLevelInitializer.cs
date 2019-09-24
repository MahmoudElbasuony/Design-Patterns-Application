using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class XLevelInitializer : LevelInitializer
    {

        public XLevelInitializer(ISnakeFactory _snakeFactory) : base(_snakeFactory)
        {

        }

        public override void InitializeLevel(Board board, GameMode gameMode)
        {

            var color = Color.Red;

            var random = new Random();

            // add main snake shape
            var heroSnake = InitializeHeroSnake(board, gameMode);
            heroSnake.OnSnakeColided += FireSnakeColided;
            board.AddShape(heroSnake);


            var food = new Food
            {
                IsStatic = true,
                Color = color,
                Height = 10,
                Width = 10,
                X = random.Next(10, (int)board.Width),
                Y = random.Next(10, (int)board.Height)
            };
            board.AddShape(food);

            for (int i = 0; i < 40; i++)
            {
                food = (Food)food.Clone(random.Next(10, (int)board.Width), random.Next(10, (int)board.Height));
                board.AddShape(food);
            }

        }


        protected override Snake InitializeHeroSnake(Board board, GameMode gameMode)
        {
            var heroSnake = _snakeFactory.CreateSnake(gameMode, new RectangleF(0, 0, board.Width, board.Height));
            heroSnake.HasFocus = true;
            heroSnake.IsStatic = false;
            heroSnake.HasFocus = true;
            heroSnake.Color = Color.Black;
            var snakeHead = heroSnake.Parts[0];
            snakeHead.Color = heroSnake.Color;
            snakeHead.X = heroSnake.X = board.Width / 2;
            snakeHead.Y = heroSnake.Y = board.Height / 2;
            snakeHead.Width = 10;
            snakeHead.Height = 10;
            return heroSnake;
        }
    }
}
