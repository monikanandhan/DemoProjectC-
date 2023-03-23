using System;
using System.Collections;

namespace ArrayListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArrayList al = new ArrayList();
            al.Add("kalai");
            al.Add(20);
            al.Add(10.5);
            al.Add("hello");
            al.Add(100.285000);
            al.Add("welcome");
            al.Insert(5, "Demo");
            ArrayList al1 = new ArrayList() { 10, "hi", "welcome" } ;
            

                            //bool
                            //al1.Clear();
                            //al.AddRange(al1);
                            //Console.WriteLine(al.Capacity);
                            //al.Remove(20);
                            //al.RemoveAt(2);
                            //            result = al.Contains("Demo");
                            //Console.WriteLine(result);

                            //al.InsertRange(2, al1);
                            //foreach(var items in al)
                            //{
                            //    Console.WriteLine(items);
                            //}
                            //al1 =(ArrayList) al.Clone();

                            //ArrayList  demo = al.GetRange(0, 2);
                        
                al.Sort();
            foreach (var i in al)
            {
                Console.WriteLine(i);
            }
         
        }
    }
}
