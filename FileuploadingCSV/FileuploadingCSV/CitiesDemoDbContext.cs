using FileuploadingCSV.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FileuploadingCSV
{
    public class CitiesDemoDbContext:DbContext
    {
        public CitiesDemoDbContext(DbContextOptions<CitiesDemoDbContext> options) : base(options) { }

        public DbSet<Cities> cities { get; set; }
    }
}
