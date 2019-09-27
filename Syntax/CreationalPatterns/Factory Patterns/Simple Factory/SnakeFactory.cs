using DesignPatterns.Factory_Patterns;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory_Pattern.Simple_Factory
{
    public class SnakeFactory
    {
        public static ISnake CreateSnake(SnakeType snakeType)
        {
            switch (snakeType)
            {
                case SnakeType.Normal:
                    return new Snake();
                case SnakeType.Medium:
                    return new MediumSnake();
                case SnakeType.Hard:
                    return new HardSnake();
                default:
                    return new Snake();
            }
        }
    }
}
