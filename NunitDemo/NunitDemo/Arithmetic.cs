using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemo
{
    public static class Arithmetic
    {
        public static Func<int, int, int> add = (a, b) => a + b;
        public static Func<int, int, int> mul = (a, b) => a * b;
        public static Func<int, int, int> sub = (a, b) => a - b;
        public static Func<int, int, int> div = (a, b) => a / b;
    }
}
