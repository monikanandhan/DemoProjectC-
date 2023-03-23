using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Model
{
    public class CalcDbContext:DbContext
    {
        public CalcDbContext(DbContextOptions<CalcDbContext> options):base(options)
        {

        }
        public DbSet<Calc> calc { get; set; }
    }
}
