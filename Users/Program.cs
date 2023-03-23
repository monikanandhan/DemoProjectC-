using System;

namespace Users
{
    class Program
    {
       
    
        static void Main(string[] args)
        {
            {
                Multiplication(1, 2, 3, 4, 5);
            }
            static void Multiplication(params int[] a)
            {
              
                for(int i=0;i<a.Length;i++)
                {
                    Console.Write(a[i]+(i<a.Length-1?",":""));
                }
            }

        }
    }
}
