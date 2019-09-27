using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Prototype
{

    public abstract class Snake
    {
        public int Length { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public string Color { get; set; }
        public string Direction { get; set; }
        public Snake(int startPositionX, int startPositionY, int width, string startDirection, string color)
        {
            Length = 1;
            X = startPositionX;
            Y = startPositionY;
            Width = width;
            Color = color;
            Direction = startDirection;
        }
        public string ContainerId { get; set; }
        public string Status { get; set; }
        public abstract Snake Clone();
        public abstract Snake Clone(string Status, string ContainerId);
    }

 
}
