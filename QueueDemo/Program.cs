using System;
using System.Collections;

namespace QueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();
            q.Enqueue("monica");
            q.Enqueue(100);
            q.Enqueue(10.5);
            q.Enqueue(100.2555565);
            q.Enqueue("demo");
            Queue q1 = new Queue();
            foreach(var i in q)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(q.Peek());
                 Console.WriteLine(q.Peek());
            Console.WriteLine(q.Contains(100));
           q1 = (Queue)q.Clone();
            foreach (var i in q1)
            {
                Console.WriteLine(i);
            }

        }
    }
}
