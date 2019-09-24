using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class XSnake : Snake
    {
        public override bool IsColided
        {
            get
            {
                if (SnakeHead.X < Area.Left || SnakeHead.X > Area.Right ||
                SnakeHead.Y < Area.Top || SnakeHead.Y > Area.Bottom ||
                TailParts.Any(t => (SnakeHead.X > t.X && SnakeHead.X < t.X + t.Width) &&
                                   (SnakeHead.Y > t.Y && SnakeHead.Y < t.Y + t.Height)))
                    return true;
                else
                    return false;

            }
        }
        public override IList<Food> SmellAndEat(IList<Food> foods)
        {
            IList<Food> eatenFoods = new List<Food>();
            foreach (var food in foods)
            {
                var snakeHeadLeft = SnakeHead.X;
                var snakeHeadRight = SnakeHead.X + SnakeHead.Width;
                var foodLeft = food.X;
                var foodRight = food.X + food.Width;

                var snakeHeadTop = SnakeHead.Y;
                var snakeHeadBottom = SnakeHead.Y + SnakeHead.Height;
                var foodTop = food.Y;
                var foodBottom = food.Y + food.Height;

                if (((snakeHeadLeft >= foodLeft && snakeHeadLeft <= foodRight) ||
                    (snakeHeadRight <= foodRight && snakeHeadRight >= foodLeft)) &&
                    ((snakeHeadBottom >= foodTop && snakeHeadBottom <= foodBottom) ||
                    (snakeHeadTop <= foodBottom && snakeHeadTop >= foodTop)))
                {
                    // eat food
                    eatenFoods.Add(food);
                    EatFood();
                }

            }
            return eatenFoods;
        }
        public void EatFood()
        {
            var lastTail = Parts.LastOrDefault();
            var newPart = (SnakePart)lastTail.Clone();
            newPart.Color = Color;
            AddSnakePart(newPart);
        }
        public XSnake(RectangleF movingArea)
        {
            SnakeHead = CreateHeadPart();
            Parts = new List<SnakePart> { SnakeHead };
            Area = movingArea;
        }

        private SnakePart CreateHeadPart()
        {
            var snakeHead = new SnakePart(this);
            snakeHead.IsHead = true;
            return snakeHead;
        }
        public override void Draw(Drawer drawer)
        {
            foreach (var part in Parts)
            {
                part.Color = part.IsHead ? Color.Green : part.Color;
                part.Draw(drawer);
            }
        }

        public override void Move(ArrowDirection arrowDirection, Drawer drawer)
        {

            if (Parts.Count > 1 && (Parts.Select(x => x.Y).Distinct().Count() == 1 || Parts.Select(p => p.Y).Distinct().Count() == 1))
                ReverseSnakeDirection();


            // update snake parts locations
            var oldSnakeHeadPart = (SnakePart)SnakeHead.Clone();

            // update head part location 
            switch (arrowDirection)
            {
                case ArrowDirection.Up:
                    SnakeHead.Y -= oldSnakeHeadPart.Height;
                    break;
                case ArrowDirection.Down:
                    SnakeHead.Y += oldSnakeHeadPart.Height;
                    break;
                case ArrowDirection.Right:
                    SnakeHead.X += oldSnakeHeadPart.Width;
                    break;
                case ArrowDirection.Left:
                    SnakeHead.X -= oldSnakeHeadPart.Width;
                    break;
            }

            // update tail parts locations
            moveTailParts(oldSnakeHeadPart);

            // graphically draw snake parts 
            Draw(drawer);

            if (IsColided)
            {
                FireOnSnakeColided();
                return;
            }
        }


        public void moveTailParts(SnakePart snakeHead)
        {
            var previousPart = snakeHead;
            foreach (var tailPart in TailParts)
            {
                var tempPart = tailPart.Clone();
                tailPart.X = previousPart.X;
                tailPart.Y = previousPart.Y;
                previousPart = (SnakePart)tempPart;
            }
        }

        protected override void ReverseSnakeDirection()
        {
            Parts.Reverse();
            var newHeadPart = Parts.FirstOrDefault();
            var newLastTail = Parts.LastOrDefault();
            SnakeHead = newHeadPart;
            newHeadPart.IsHead = true;
            newLastTail.IsHead = false;
        }
    }
}
