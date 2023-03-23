using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeligateDemo
{
    class EventDemo
    {
        public delegate void SampleDelegate();
        public event SampleDelegate SampleEvent;
        public void add(int a,int b)
        {
            if(SampleEvent!=null)
            {
                SampleEvent();
                Console.WriteLine( a + b);
            }
            else
            {
                Console.WriteLine("Not Subscribed to Event");
            }
        }
        public void sub(int a,int b)
        {
            if(SampleEvent!=null)
            {
                SampleEvent();
                Console.WriteLine(a - b);
            }
            else
            {
                Console.WriteLine("Not Subscribed to Event");
            }
        }
        public void Multiply(int a,int b)
        {
            if (SampleEvent != null)
            {
                SampleEvent();
                Console.WriteLine(a * b);
            }
            else
            {
                Console.WriteLine("Not Subscribed to Event");
            }
        }
    }
    
    class Operations
    {
        EventDemo ed;
         public int a { get; set; }
        public int b { get; set; }
        public Operations(int x, int y)
        {
             ed = new EventDemo();
          
            ed.SampleEvent += SampleEventHandler;
            a= x;
            b = y;
        }
        public void SampleEventHandler()
        {
            Console.WriteLine("SampleEvent Handler: Calling Method");
        }
        public void AddOper()
        {
            ed.add(a, b);
        }
        public void SubOper()
        {
            ed.sub(a, b);
        }
    }
    class Programs
    {
        public static void Main(String[] args)
        {
            Operations op = new Operations(10,20);
            op.AddOper();
            op.SubOper();
            EventDemo ed = new EventDemo();
            ed.Multiply(10, 10);

        }
    }
}
