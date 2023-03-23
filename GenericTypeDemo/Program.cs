using System;
using System.Collections.Generic;

namespace GenericTypeDemo
{
  public  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<String> al = new List<String>();

            List<String> al1 = new List<string>() { "monica", "20", "30" };
            al.Add("kalai");
            al.Add("monisha");
            al.Add("monica");
            al.Add("sandhiya");
            al.InsertRange(0, al1);
            //al.AddRange(al1);
            //foreach (var i in al)
            //{
            //    Console.WriteLine(i);
            //}

            //List<Student> m = new List<Student>();
            //m[0] = new Student(1, "kalai", 25);
            //m[1] = new Student(2, "monica", 26);


            List<Student> m1= new List<Student>()
            {
                new Student(){ Id = 3, Name = "monisha", Age = 24 },
                new Student(){ Id = 4, Name = "sandhiya", Age = 25 }
            };
            m1.Add(new Student() { Id = 1, Name = "moni", Age = 23 });

          

            //foreach (Student i in m1)
            //{
            //    Console.WriteLine(i.Id+" "+i.Name+" "+i.Age);
            //}

            List<Student> m2= new List<Student>();
            m2.AddRange(m1);
            m1.Insert(2, new Student() { Id = 5, Name = "Aarthi", Age = 26 });

            foreach (Student i in m1)
            {
                Console.WriteLine(i.Id + " " + i.Name + " " + i.Age);
            }

          

        }
    }
}
