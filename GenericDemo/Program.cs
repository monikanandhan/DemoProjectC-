using System;

namespace GenericDemo
{
    class Program<T>
    {
        public T msg;
        public T location;

        public void GenericMethod<t>(T msg, T location)
        {
            Console.Write(msg);
            Console.Write(location);

        }
    } 
    class User { 
        static void Main(string[] args)
        {
            //Program<String> m = new Program<String>();
            //m.GenericMethod<string>("hi", "Welcome");
          
            GenericDelegate gd = new GenericDelegate();
            SampleDelegate<int> sd = gd.Add;
            Console.WriteLine(sd(20, 30));
            sd += gd.Subtract;
            Console.WriteLine(sd(40, 30));
            




        }
    }
}
