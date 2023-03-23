using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoClass
{
    public struct StructsDemo
    {
        public string name;
        public string location;
        public int age;

        public StructsDemo(string a, string b, int c)
        {
            name = a;
            location = b;
            age = c;
            Console.WriteLine(name + "" + location + "" + age);

        }

    }
}
