using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogExampleDemo
{
    class Person
    {

        public string name { get; set; }
        public string lastName { get; set; }

        public Person(string names,string lname)
        {
            name = names;
            lastName = lname;
            Log.Debug("create a Person {@person} at { now}", this, DateTime.Now);
        }
    }
}
