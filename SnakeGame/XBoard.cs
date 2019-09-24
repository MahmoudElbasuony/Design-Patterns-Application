using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class XBoard : Board, ISizable
    {
        public XBoard(Drawer drawer, float width, float height) : base(drawer, width, height)
        {
            Shapes = new List<Shape>();
        }
        protected override void DrawStaticShapes(Drawer drawer, ArrowDirection arrowDirection)
        {
            var staticShapes = Shapes.Where(s => s.IsStatic);
            // draw static shapes 
            foreach (var staticShape in staticShapes)
                staticShape.Draw(drawer);
        }
        protected override void DrawMovableShapes(Drawer drawer, ArrowDirection arrowDirection)
        {
            var movableShapes = Shapes.Where(s => !s.IsStatic);
            var foods = Shapes.OfType<Food>().ToList();
            // draw movable shapes .
            var toDeleteShapes = new List<Shape>();
            foreach (var movableShape in movableShapes)
            {
                if (movableShape is Snake)
                {
                    var snake = (Snake)movableShape;
                    snake.Move(arrowDirection, drawer);
                    var eatenFood = snake.SmellAndEat(foods);
                    foreach (var food in eatenFood)
                        toDeleteShapes.Add(food);
                }
            }
            for (int i = 0; i < toDeleteShapes.Count; i++)
                Shapes.Remove(toDeleteShapes[i]);
        }
        public override void UpdateBoard(Drawer drawer, ArrowDirection arrowDirection)
        {
            drawer.RefreshScreen();
            DrawStaticShapes(drawer, arrowDirection);
            DrawMovableShapes(drawer, arrowDirection);
        }

    }
}
