using System;

namespace ClassDemo
{
    class Program
    {


        //private Program()
        //{
        //    Console.WriteLine("default constructor");
        //}

        //public static int id=10;
        //public static int age=20;
        //public Program(int id, int age)
        //{
        //    id = id;
        //    age = age;
        //    Console.WriteLine(id + "" + age);
        //}
        //public Program(string a):this()
        //{
        //    Console.WriteLine(a);
        //}
        //public Program(string a,string b):this("welcome")
        //{
        //    Console.WriteLine(a+" "+b);
        //}
        //public Program(Program p)
        //{
        //    id = p.id;
        //   age = p.age;
        //}


        static void Main(string[] args)
        {
            //Program p = new Program();
            //Program p1 = new Program(10,20);
            //Console.WriteLine(Program.id + "" + Program.age);
            //Program p1 = new Program(p);
            //p1.id = 20;
            //p1.age = 40;
            //Console.WriteLine(p1.id + "" + p1.age);
            User m = new User("chennai","india");
            m.getUserDetails();

        }
    }
}

