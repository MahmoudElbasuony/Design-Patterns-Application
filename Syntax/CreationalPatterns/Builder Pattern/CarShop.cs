using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder_Pattern
{
   public  class CarShop
    {
        public Car Construct(CarBuilder carBuilder)
        {
            carBuilder.BuildBreak();
            carBuilder.BuildEngine();
            carBuilder.BuildTires();
            return carBuilder.Car;
        }
    }
}
