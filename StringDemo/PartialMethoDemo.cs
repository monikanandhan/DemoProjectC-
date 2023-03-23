using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDemo
{
    public partial class PartialMethoDemo
    {
        string name;
        string location;

       public partial void getUserDetails(string a, string b);
       
    }

    public partial class PartialMethoDemo
    {
       public partial void getUserDetails(string a, string b)
        {
            name = a;
            location = b;
        }
    }
}
