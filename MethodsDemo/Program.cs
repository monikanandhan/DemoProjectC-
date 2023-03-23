using System;

namespace MethodsDemo
{
    class Program
    {

        public void getUserDetails()
        {
            Console.WriteLine("Hello Welcome");
        }
        public void InsertUserDetails(int id, string name)
        {
           /// string info = string.Format(id,name);
            //return info;
            
           Console.WriteLine(id + "" + name);
        }
    }
    class Person
    {
        static void Main(string[] args)
        {
            //Program p = new Program();
            //p.getUserDetails();
            //p.InsertUserDetails(10, "kalai");
            //Class1.Details();

           
           
            RefDemo d = new RefDemo();
            d.Add(1,2,"monica","kalai",4);
           

        }

       
    }
}
