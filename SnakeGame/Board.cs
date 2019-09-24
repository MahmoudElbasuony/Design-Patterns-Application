using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public abstract class Board : ISizable
    {
        public IList<Shape> Shapes { get; set; }
        protected Drawer _drawer { get; set; }
        public float Width { get ; set  ; }
        public float Height { get  ; set  ; }
        public Board(Drawer drawer, float width , float height)
        {
            _drawer = drawer;
            Width = width;
            Height = height;
        }
        protected abstract void DrawStaticShapes(Drawer drawer, ArrowDirection arrowDirection);
        protected abstract void DrawMovableShapes(Drawer drawer, ArrowDirection arrowDirection);
        public abstract void UpdateBoard(Drawer drawer, ArrowDirection arrowDirection);
        public void AddShape(Shape shape) => Shapes.Add(shape);
        

    }
}
