using System;

namespace OperatorsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 30, y = 20;
            string Result = (x > y) ? "x is higher" :(x<y)? "y is higher" :"both are same";
            Console.WriteLine(Result);
        }
    }
}
