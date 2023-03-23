using System;
using System.Collections;

namespace StackDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            s.Push("welcome");
            s.Push(100);
            s.Push(10.25);
            s.Push(100.2555656);
            //foreach(var i in s)
            //{
            //    Console.WriteLine(i);
            //}
            //while(s.Count>0)
            //    {
            //    Console.WriteLine(s.Pop());
            //}

            Console.WriteLine(s.Peek());
            Console.WriteLine(s.Peek());
            Console.WriteLine(s.Contains(100));
            Stack s1 = new Stack();

                 s1 =(Stack) s.Clone();
            foreach (var i in s1)
            {
                Console.WriteLine(i);
            }
            s1.Clear();
        }
    }
}
