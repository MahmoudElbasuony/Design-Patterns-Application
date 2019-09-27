using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory_Pattern.Abstract_Fcatory
{
    public interface IFurnitureFactory
    {
        Chair CreateChair();
        Sofa CreateSofa();
        CoffeeTable CreateCoffeTable();
    }
    public class AFurnitureFactory : IFurnitureFactory
    {
        public Chair CreateChair()
        {
            // notice we can use another class here e.g : new BChair() but that would 
            // lead to inconsistency in logic and also in bussiness 
            return new AChair();
        }

        public CoffeeTable CreateCoffeTable()
        {
            return new ACoffeeTable();
        }

        public Sofa CreateSofa()
        {
            return new ASofa();
        }
    }

    public class BFurnitureFactory : IFurnitureFactory
    {
        public Chair CreateChair()
        {
            return new BChair();
        }

        public CoffeeTable CreateCoffeTable()
        {
            return new BCoffeeTable();
        }

        public Sofa CreateSofa()
        {
            return new BSofa();
        }
    }
}
