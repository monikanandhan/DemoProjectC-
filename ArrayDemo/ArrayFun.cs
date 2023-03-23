using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDemo
{
    class ArrayFun
    {
        public static  void add(string[] a)
        {
            for(int i=0;i<a.Length;i++)
            {
                Console.WriteLine("a[{0}]:{1}",i, a[i]);
            }
        }
    }
}
