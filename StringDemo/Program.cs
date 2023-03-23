using System;

namespace StringDemo
{
    public partial class Program
    {
        private string name;
        private string location;
        public Program(String a, String b)
        {
            name = a;
            location = b;
        }
    }
    public partial class Program
    {
        public void GetDetails()
        {
            Console.WriteLine(name + "" + location);
        }
    }
    class Person
    { 
        static void Main(string[] args)

        {
            //Program p = new Program("Monica","erode");
            //p.GetDetails();
            PartialMethoDemo p = new PartialMethoDemo();
            p.getUserDetails("kalai", "erode");
        }
    }
}

