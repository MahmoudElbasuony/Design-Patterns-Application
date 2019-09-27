using DesignPatterns.Builder_Pattern;
using DesignPatterns.Factory_Pattern.Abstract_Fcatory;
using DesignPatterns.Factory_Pattern.Factory_Method;
using DesignPatterns.Factory_Pattern.Simple_Factory;
using DesignPatterns.Factory_Patterns;
using DesignPatterns.Prototype;
using DesignPatterns.Singleton;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creational Pattern

            #region Singleton
            //var cacheManager = CacheManager.Instance;
            //cacheManager["a"] = "a";
            //Console.WriteLine(cacheManager["a"].ToString());
            //cacheManager = CacheManager.Instance;
            //cacheManager["a"] = "b";
            //Console.WriteLine(cacheManager["a"].ToString()); 
            #endregion

            #region Prototype

            //XSnake xsnake = new XSnake(10, 20, 100, "right", "red");
            //xsnake.ContainerId = "container1Id";
            //xsnake.Status = "snoozed";
            //// we need another snake object with the same configuration but with different container & status.
            //// instread of creating another one and giving it the same configuration we need some method to clone this 
            //// object , say welcome to Protoype pattern which comes to the scene 
            //XSnake snake2 = (XSnake)xsnake.Clone("container1Id2", "ready");
            //Console.WriteLine(snake2);

            #endregion

            #region Simple Factory Pattern [ Traditional ]

            //// this class is tightly coupled with SnakeFactory 
            //// SnakeFactory violates Open/Closed Principle 
            //ISnake snake = SnakeFactory.CreateSnake(SnakeType.Normal);
            //snake.Move();

            #endregion

            #region Factory Method
            //// so we need to let current class depend on abstract factory 
            //// and let children to extend and decide which class to create 
            //ISnakeFactory snakeFactory = new NormalSnakeFcatory();
            //snake = snakeFactory.CreateSnake();
            //snake.Move();


            //snakeFactory = new MediumSnakeFcatory();
            //snake = snakeFactory.CreateSnake();
            //snake.Move();

            //snakeFactory = new HardSnakeFcatory();
            //snake = snakeFactory.CreateSnake();
            //snake.Move();

            // now we resolved OCP principle and loosly coupling current class from concerete factory 
            // so you can inject different child factories  
            #endregion

            #region Abstract Fcatory

            //// application will choose which factory to use 
            //IFurnitureFactory furnitureFactory = new AFurnitureFactory();
            //                  furnitureFactory = new BFurnitureFactory();

            //// but this code won't be affected by which factory is already in use [ no break ]
            //Chair chair = furnitureFactory.CreateChair();
            //Sofa sofa = furnitureFactory.CreateSofa();
            //CoffeeTable coffeeTable = furnitureFactory.CreateCoffeTable(); 
            #endregion

            #region Builder Pattern
            CarBuilder carBuilder = new XCarBuilder();
            CarShop carShop = new CarShop();
            var car = carShop.Construct(carBuilder);
            Console.WriteLine(car.Engine);
            #endregion

            #endregion




        }


    }

   


}
