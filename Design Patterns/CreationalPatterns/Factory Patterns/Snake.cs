using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory_Patterns
{
    public enum SnakeType
    {
        Normal,
        Medium,
        Hard
    }

    public class Snake : ISnake
    {
        public void Move()
        {
            Console.WriteLine("Normal Snake");
        }
    }
    public class MediumSnake : ISnake
    {
        public void Move()
        {
            Console.WriteLine("Medium Snake");
        }
    }
    public class HardSnake : ISnake
    {
        public void Move()
        {
            Console.WriteLine("Hard Snake");
        }
    }

    public interface ISnake
    {
        void Move();
    }
}
