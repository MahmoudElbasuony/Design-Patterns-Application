using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public abstract class Snake : Shape
    {
        public IList<SnakePart> Parts { get; set; }
        public IList<SnakePart> TailParts
        {
            get
            {
                return Parts.Where(p => !p.IsHead).ToList();
            }
        }
        protected SnakePart SnakeHead { get; set; }
        public abstract bool IsColided { get; }
        public int Length => Parts?.Count ?? 0;
        public abstract void Move(ArrowDirection arrowDirection, Drawer drawer);
        public void AddSnakePart(SnakePart snakePart) => Parts.Add(snakePart);
        public abstract IList<Food> SmellAndEat(IList<Food> foods);

        public event Action OnSnakeColided;
        protected RectangleF Area { get; set; }
        protected void FireOnSnakeColided() => OnSnakeColided?.Invoke();
        protected abstract void ReverseSnakeDirection();
    }
}
