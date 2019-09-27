using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder_Pattern
{
    public abstract class CarBuilder
    {
        public Car Car;
        public abstract void BuildEngine();
        public abstract void BuildBreak();
        public abstract void BuildTires();

    }
    public class XCarBuilder : CarBuilder
    {
        public XCarBuilder()
        {
            Car = new XCar();
        }

        public override void BuildBreak()
        {
            Car.Break = "Break Structure 1";
        }

        public override void BuildEngine()
        {
            Car.Engine = "Engine Structure";
        }

        public override void BuildTires()
        {
            Car.Tires = new string[] { "Tires Structure 1" };
        }
    }
    public class YCarBuilder : CarBuilder
    {
        public YCarBuilder()
        {
            Car = new XCar();
        }

        public override void BuildBreak()
        {
            Car.Break = "Break Structure 2";
        }

        public override void BuildEngine()
        {
            Car.Engine = "Engine Structure 2";
        }

        public override void BuildTires()
        {
            Car.Tires = new string[] { "Tires Structure 2" };
        }
    }



}
