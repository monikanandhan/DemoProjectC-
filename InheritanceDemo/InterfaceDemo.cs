using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    interface InterfaceDemo
    {
        void GetDetails(String x);
    }
    interface IAge
    {
        void GetAge(int x);
    }
    interface IGetLocation
    {
        void GetLocation(String x);
    }
    public class UserA:InterfaceDemo,IAge,IGetLocation
    {
        public void GetDetails(String a)
        {

            Console.WriteLine(a);
        }
        public void GetAge(int a)
        {

            Console.WriteLine(a);
        }
        public void GetLocation(String a)
        {

            Console.WriteLine(a);
        }

    }
    //class UserB:InterfaceDemo
    //{
    //    public void GetDetails(String c)
    //    {
    //        Console.WriteLine("UserB method"+c);
           
    //    }
    //}
}
