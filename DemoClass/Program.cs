using System;

namespace DemoClass
{
     class Program
    {
        public readonly int id;
        public readonly int marks;
        public readonly string name;
        const string college = "KGISL";
      Program()
        {
            id = 10;
            marks = 100;
            name = "monioca";
            Console.WriteLine(id + "" + marks + "" + name );
        }

       static void getDetails(int id,int marks,string name,string college)
        {

            Console.WriteLine(id + "" + marks + "" + name+""+college);

        }
      class Person {
            //static void Main(string[] args)

            //{
                //Program p = new Program();
                //StructsDemo s = new StructsDemo("monica", "chennai", 10);
                //StructsDemo s1;
                //s1.age = 20;
                //s1.location = "cbwe";
                //s1.name = "kalai";
                //s.name = "kalai";
                //s.age = 10;
                //s.location = "cbe";
                //Console.WriteLine(s1.name + "" + s1.age + "" + s1.location);

            }

        }
    }
