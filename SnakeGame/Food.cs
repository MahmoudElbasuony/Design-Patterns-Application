using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Food : Shape , ICloneable , ISizable
    {
        public float Width { get ; set; }
        public float Height { get; set ; }

        public override void Draw(Drawer drawer)
        {
            drawer.Draw(this);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public object Clone(float x, float y)
        {
            var foodCopy = (Food)MemberwiseClone();
            foodCopy.X = x;
            foodCopy.Y = y;
            return foodCopy;
        }
    }
}
