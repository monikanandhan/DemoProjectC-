using FileReadingWebapi.Model;
using Microsoft.EntityFrameworkCore;

namespace FileReadingWebapi
{
    public class CitiesDbContext:DbContext
    {
        public CitiesDbContext(DbContextOptions<CitiesDbContext> options) : base(options) { }

        public DbSet<Cities> cities { get; set; }
    }
}
