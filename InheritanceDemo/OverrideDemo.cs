using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
   class OverrideDemo
    {
        public OverrideDemo()
        {
            Console.WriteLine("Default base Constructor");
        }

       public OverrideDemo(int a,int b)
        {
            Console.WriteLine( a);
            Console.WriteLine( b);
        }
      public virtual void GetInfo()
        {
            Console.WriteLine("Base class");
        }
    }
    class RideSample:OverrideDemo
    {
        public RideSample():base()
        {
            Console.WriteLine("Default derived Constructor");
        }
        public RideSample(int x,int y):base(x,y)
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
        public override void GetInfo()
        {
           
            Console.WriteLine("Derived class");
            base.GetInfo();
        }
    }
}
