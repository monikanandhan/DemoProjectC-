using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StringDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //String str1 = "monica to kalai to sandhiya";
            //String str2 = "  kalai";
            //String str3 =   "  monisha";
            //string str4 = "@@** Suresh Dasari **@";

            //Console.WriteLine("after trim:{0} {1} {2}", str2.Trim(), str3.Trim(), str4.Trim());
            //char[] trimChars = { '*', '@', ' ' };
            //Console.WriteLine(str4.Trim(trimChars));
            StringBuilder sb = new StringBuilder("welcome");
            sb.Append(", to");
            sb.Append(", Tutlane");
            Console.WriteLine(sb);

            sb.Insert(8, "to");
            Console.WriteLine(sb);

            sb.Remove(8, 2);
            Console.WriteLine(sb);

            sb.Replace("welcome", "hi");
            Console.WriteLine(sb.ToString());




            //StringComparison str = StringComparison.OrdinalIgnoreCase;
            //bool msg = str2.Equals(str3, str);

            //string msg = (string)str2.Clone();
            //Console.WriteLine(msg);
            //Console.WriteLine(Object.ReferenceEquals(msg,str2));
            //string msg = String.Copy(str2);
            //Console.WriteLine(msg);
            //Console.WriteLine(Object.ReferenceEquals(msg, str2));
            //string str9 = str1.Substring(2,8);
            //string str9 = str1.Remove(2, 8);
            //Console.WriteLine(str9);

            //Console.WriteLine(string.Compare(str3, str4));
            //Console.WriteLine(string.Compare(str2,str3));
            //Console.WriteLine(string.Compare(str4, str4));
            //string[] str3 = str1.Split(new char[] { ',', '-', '%' }, StringSplitOptions.RemoveEmptyEntries);
            //IList<string> str2=new List<string>(str3);
            //for(int i=0;i<str2.Count;i++)
            //{
            //    Console.WriteLine(str2[i]);
            //}
            //string str4 = String.Replace(",", "-").Replace("%","-");
            //String str4 = String.Concat(String.Concat(str1, str2), str3);
            //Console.WriteLine(str4);

            //str9 = str1.Contains("Kalai");

            //StringComparison str = StringComparison.OrdinalIgnoreCase;
            //bool str9 = str1.IndexOf("Kalai", str) > 0 ? true : false;


        }
    }
}
