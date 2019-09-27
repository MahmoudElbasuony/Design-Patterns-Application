using DesignPatterns.Factory_Patterns;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory_Pattern.Factory_Method
{
    public interface ISnakeFactory
    {
        ISnake CreateSnake();
    }

    public class NormalSnakeFcatory : ISnakeFactory
    {
        public ISnake CreateSnake()
        {
            return new Snake();
        }
    }
    public class HardSnakeFcatory : ISnakeFactory
    {
        public ISnake CreateSnake()
        {
            return new HardSnake();
        }
    }
    public class MediumSnakeFcatory : ISnakeFactory
    {
        public ISnake  CreateSnake()
        {
            return new MediumSnake();
        }
    }
}
