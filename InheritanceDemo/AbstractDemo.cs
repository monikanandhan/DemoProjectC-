using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    abstract public class AbstractDemo
    {
        abstract public void GetDetails(String x, String y, int z);
    }
    class Users: AbstractDemo
    {
        public override void GetDetails(String a, String b, int c)
        {
            Console.WriteLine("Name: {0}", a);
            Console.WriteLine("Location: {0}", b);
            Console.WriteLine("Age: {0}", b);
        }
    }
}
