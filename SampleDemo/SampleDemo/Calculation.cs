using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemo
{
    public class Calculation
    {
        public Char[] Symbol { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        public Calculation(char[] symbol, int num1, int num2)
        {
            Symbol = symbol;
            Num1 = num1;
            Num2 = num2;
        }
    }
}
