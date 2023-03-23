using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public delegate T SampleDelegate<T>(T a, T b);
    class GenericDelegate
    {
        public int Add(int x,int y)
        {
           return x + y;
           
        }
        public int Subtract(int x,int y)
        {
            return x - y;
           

        }
    }
}
