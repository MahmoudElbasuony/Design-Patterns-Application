using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder_Pattern
{
    public abstract class Car
    {
        public string Engine { get; set; }
        public string Break { get; set; }
        public string[] Tires  { get; set; }
    }

    public class XCar : Car
    {

    }

    public class YCar : Car
    {

    }
}
