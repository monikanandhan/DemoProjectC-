using System;

namespace HelloWorld
{
    class Person
    {
       public int age;
    }
    class Program
    { 
        static void Square(Person a,Person b)
        {
            a.age = a.age * a.age;
            b.age = b.age * b.age;
            Console.WriteLine(a.age + " " + b.age);

        }
        static void Main(string[] args)
        {
            Person p1 = new Person();
            Person p2 = new Person();
            p1.age = 100;
            p2.age = 200;
            Console.WriteLine(p1.age + " " + p2.age);
            Square(p1,p2);
            Console.WriteLine(p1.age + " " + p2.age);


        }
    }
}
