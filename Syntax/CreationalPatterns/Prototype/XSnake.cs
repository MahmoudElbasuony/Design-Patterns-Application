using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Prototype
{
    public class XSnake : Snake
    {
        public XSnake(int startPositionX, int startPositionY, int width, string startDirection, string color)
             : base(startPositionX, startPositionY, width, startDirection, color)
        {
            Length = 1;
            X = startPositionX;
            Y = startPositionY;
            Width = width;
            Color = color;
            Direction = startDirection;
        }

        public override Snake Clone()
        {
            return (Snake)MemberwiseClone();
        }

        public override Snake Clone(string Status, string ContainerId)
        {
            var clone = (Snake)MemberwiseClone();
            clone.Status = Status;
            clone.ContainerId = ContainerId;
            return clone;
        }
    }
}
