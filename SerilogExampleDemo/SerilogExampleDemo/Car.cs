using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogExampleDemo
{
    class Car
    {
        public string Model { get; set; }
        public int YearReleased { get; set; }
        public Person Owner { get; set; }

        public Car(string model, int relesed, Person name)
        {
            Model = model;
            YearReleased = relesed;
            Owner = name;

            Log.Debug("created  a car {@person} at {now}", this, DateTime.Now);

        }
    }
}
