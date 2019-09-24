using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class SnakePart : Shape, ICloneable, ISizable
    {
        public SnakePart(Snake Snake)
        {
            this.Snake = Snake;
        }
        public Snake Snake { get; }
        public float Width { get; set; }
        public float Height { get; set; }
        public bool IsHead { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override void Draw(Drawer drawer)
        {
            drawer.Draw(this);
        }
    }
}
