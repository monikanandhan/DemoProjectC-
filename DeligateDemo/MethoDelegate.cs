using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeligateDemo
{
    public delegate void SampleReturn(int a, int b);

    class Users
    {
        public static void SampleDemos(SampleReturn dl,int a,int b)
        {
            dl(a, b);
        }
        public void Addition(int x, int y)
        {
            Console.WriteLine(x + y);
        }
        public void Subtraction(int x, int y)
        {
            Console.WriteLine(x - y);
        }
        public void Multiply(int x, int y)
        {
            Console.WriteLine(x * y);
        }
    }
    class MethoDelegate
    {
        //public static void Main(string[] args)
        //{
        //    Users u = new Users();
        //    Users.SampleDemos(u.Addition, 30, 40);
        //    Users.SampleDemos(u.Subtraction, 40, 30);
        //    Users.SampleDemos(u.Multiply, 10, 10);
        //}
    }
}
