using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    class User
    {
        string name, location;
       

        public User(string name,string location)
        {
            this.name = name;
            this.location = location;
        }
        public void getUserDetails()
        {
            Console.WriteLine("Name:{0}", name);
            Console.WriteLine("location:{0}", location);
            Console.WriteLine("percentage:{0}", Exams.GetPercentage(this));

        }
        class Exams
        {
            public static double GetPercentage(User u)
            {
                double i = ((double)470 / 600) * 100;
                return (i);
            }
        }
        
    }
}
