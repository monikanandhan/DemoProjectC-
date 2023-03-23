using System;

namespace ArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] a = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5,6} };

            //foreach (int i in a)
            //{
            //    Console.WriteLine(i);
            //}
            //Array.Sort(a);

            //foreach (int i in a)
            //{
            //    Console.WriteLine(i);
            //}
            //Array.Reverse(a);

            //foreach (int i in a)
            //{
            //    Console.WriteLine(i);
            //}

            //int[] i = new int[5];
            //Console.WriteLine(Array.IndexOf(a, 4));
            // Array.Copy(a, i, a.Length);


            //foreach (int m in i)
            //{
            //    Console.WriteLine(m);
            //}

            //for(int i=0;i<3;i++)
            //{
            //    for(int j=0;j<2;j++)
            //    {
            //        Console.WriteLine("a[{0},{1}] = {2}", i, j, a[i, j]); 
            //    }
            //}

            int[][,] a = new int[2][,];
            a[0] = new int[2, 2] { { 1, 2 }, {4,5} };
            a[1] = new int[,] { { 10, 20 }, { 30, 40 } };
          
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("a[{0}]:", i);

                for(int j=0;j<a[i].GetLength(0);j++)
                {
                    Console.Write("{");
                    for(int k=0;k<a[i].GetLength(1);k++)
                    {
                        Console.WriteLine("{0}{1}", a[i][j, k], k == (a[i].GetLength(1) - 1) ? "" : " ");
                    }
                }
            }
        }
    }
}
