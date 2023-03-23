using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    public class MutlilevelInheritance
    {
        public string name;
        public void GetName()
        {
            Console.WriteLine(name);
        }
    }
    public class DemoSample : MutlilevelInheritance
    {
        public string location;
        public void GetLocation()
        {
            Console.WriteLine(location);
        }

    }
    public class SampleMenu: MutlilevelInheritance
    {
        public int age;
        public void GetAge()
        {
            Console.WriteLine(age);
        }
    }
}
