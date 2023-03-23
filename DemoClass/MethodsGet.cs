using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoClass
{
    class MethodsGet
    {
        private string name;
        private string city;
        private int age;

        public MethodsGet()
        {
        }

        public MethodsGet(string a,string b,int c)
        {
            name = a;
            city = b;
            age = c;
        }
        public string Name
        {
            //get { return name; }
            set { name = value; }

        }
        public string City
        {
            //get { return city; }
            set { city = value; }
        }
        public int Age
        {
            //get { return age; }
            set { age = value; }
        }
        public void GetDetails()
        {
            Console.WriteLine( name);
            Console.WriteLine( city);
        }

    }
    class Demo1
    {
        static void Main(string[] args)
        {
            MethodsGet g = new MethodsGet();
            //MethodsGet s = new MethodsGet("kalai", "cbe", 20);
            g.Age = 10;
            g.City = "cbe";
            g.Name = "kalai";
            g.GetDetails();
            //Console.WriteLine(s.Age);
            //Console.WriteLine(s.City);
            //Console.WriteLine(s.Name);



        }
    }
}
