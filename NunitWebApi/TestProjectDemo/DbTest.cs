using Microsoft.EntityFrameworkCore;
using NunitWebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectDemo
{
    public class DbTest:CustomerTest
    {
        public DbTest()
            : base(
                new DbContextOptionsBuilder<CustomerDbContext>()
                    .UseMySQL("server=localhost;port=3306;database=test;user=root;password=")
                    .Options)
        {
        }
    }
}
