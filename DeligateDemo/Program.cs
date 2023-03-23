using System;

namespace DeligateDemo
{
    public delegate void SampleDemo(int a,int b);
    class User
    {
        public void Addition(int x,int y)
        {
            Console.WriteLine(x + y);
        }
        public void Subtraction(int x,int y)
        {
            Console.WriteLine(x - y);
        }
        public void Multiply(int x,int y)
        {
            Console.WriteLine(x * y);
        }
    }
    class Program
    {
        //static void Main(string[] args)
    //    {
    //        User u = new User();
    //        SampleDemo sd = u.Addition;
    //        sd += u.Subtraction;
    //        sd += u.Multiply;

    //    }
    }
}
