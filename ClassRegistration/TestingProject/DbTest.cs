using ClassRegistration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    public class DbTest:TestRegistration
    {
        public DbTest()
             : base(
                 new DbContextOptionsBuilder<RegisterDbContext>()
                     .UseMySQL("server=localhost;port=3306;database=test;user=root;password=")
                     .Options)
        {
        }
    }
}
