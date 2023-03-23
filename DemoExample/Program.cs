using System;

namespace DemoExample
{
    class Program
    {
       private string brand;
      private string model;
      
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
       
        public void LapTopDetails()
        {
            Console.WriteLine(brand);
            Console.WriteLine(model);

        }
        public void LaptopKeyboard()
        {
            Console.WriteLine("Type using Keyword");
        }
        public void LaptopMotherBoard()
        {
            Console.WriteLine("MotheBoard Information");
        }
        public void InternalProcessor()
        {

            Console.WriteLine("Processor Information");
        }
    } 
    class User
    { 
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Brand = "hp";
            p.Model = "z10";
            p.LapTopDetails();
            p.LaptopKeyboard();
            p.LaptopMotherBoard();
            p.InternalProcessor();
            

          
        }
    }
}
