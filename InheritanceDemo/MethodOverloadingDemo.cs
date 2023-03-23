using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
   public class MethodOverloadingDemo
    {
        public void AddDetails(int a,int b)
        {
            Console.WriteLine(a + b);
        }
        public void AddDetails(int a,int b,int c)
        {
            Console.WriteLine(a + b + c);
        }
    }
    
}
