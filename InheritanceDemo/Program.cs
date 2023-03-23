using System;

namespace InheritanceDemo
{
   public class Program
    {
        public String name;
        private int age;
       

        public Program()
        {
            Console.WriteLine("Base Class Constructor");
        }
        public void GetUserDetails(int a)
        {
            age = a;
            Console.WriteLine(name);
            Console.WriteLine(age);
        }
    }
    public class Demo : Program
    {
        public int marks;
        public Demo()
        {
            Console.WriteLine("Child Class Constructor");
        }
        public void getMarks()
        {
            Console.WriteLine(marks);
        }
    }
    class User
    {

        static void Main(string[] args)
        {
            //Demo d = new Demo();
            //d.name = "kalai";
            //d.GetUserDetails(10);
            //d.marks = 100;
            //d.getMarks();
            //SampleMenu m = new SampleMenu();
            //DemoSample s = new DemoSample();
            //m.name = "monica";
            //m.location = "cbe";
            //s.location = "cbe";
            //m.age = 26;
            //m.GetName();
            //m.GetLocation();
            //s.GetLocation();
            //m.GetAge();
            //MethodOverloadingDemo k=new MethodOverloadingDemo();
            //k.AddDetails(10, 20);
            //k.AddDetails(10, 20, 30);

            //RideSample r = new RideSample();
            //RideSample r1 = new RideSample(10,20);
            //r.GetInfo();

            ////OverrideDemo r1 = new OverrideDemo();
            ////r1.GetInfo();

            //Users u = new Users();
            //u.GetDetails("kalai", "erode", 20);

            InterfaceDemo sd = new UserA();
            sd.GetDetails("kalai");
            sd.GetAge(20);
            //InterfaceDemo sd1 = new UserB();
            //sd1.GetDetails("erode");





        }
    }
}
