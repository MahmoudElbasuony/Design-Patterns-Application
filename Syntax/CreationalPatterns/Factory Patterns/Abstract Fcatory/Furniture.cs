using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory_Pattern.Abstract_Fcatory
{
    public abstract class Chair { }
    public class AChair : Chair { }
    public class BChair : Chair { }
    public class CChair : Chair { }



    public abstract class CoffeeTable { }
    public class ACoffeeTable : CoffeeTable { }
    public class BCoffeeTable : CoffeeTable { }
    public class CCoffeeTable : CoffeeTable { }



    public abstract class Sofa { }
    public class ASofa : Sofa { }
    public class BSofa : Sofa { }
    public class CSofa : Sofa { }
}
