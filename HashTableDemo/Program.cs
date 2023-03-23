using System;
using System.Collections;

namespace HashTableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hd1 = new Hashtable();
            hd1.Add(0, "kalai");
            hd1.Add(1, "100");
            hd1.Add(2, "100");
            hd1.Add("name", "monica");
            hd1.Remove(0);
            Hashtable hd2 = new Hashtable();

           hd2=(Hashtable)hd1.Clone();


            //Console.WriteLine(hd1.GetHashCode());
            //bool demo = hd1.ContainsValue("monica");
            //Console.WriteLine(hd1["name"]);
            foreach (DictionaryEntry i in hd2)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }
            //foreach (var i in hd1.Keys)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(demo);
        }
    }
}
