using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsDemo
{
    class RefDemo
    {
        public void Add(params object[] a)
        {
         for(int i=0;i<a.Length;i++)
            {
                Console.Write(a[i] + (i < a.Length - 1 ? "," : ""));
            }
        }
    }
}
