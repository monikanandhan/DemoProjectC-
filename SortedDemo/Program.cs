using System;
using System.Collections.Generic;
using System.Linq;

namespace SortedDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 1, 2, 3, 4, 5 };
            Console.WriteLine(num.Count());

           IEnumerable<int> result =from numbers in num
            where numbers > 3
            select numbers;

            IEnumerable<int> results = num.Where(n => n > 4).ToList();
            //foreach (var item in results)
            //{
            //    Console.WriteLine(item);
            //}

            IEnumerable<int> Demo = num.Where(n => n % 2 == 0);
            //foreach (var item in Demo)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
