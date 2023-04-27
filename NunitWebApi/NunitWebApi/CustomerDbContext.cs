using Microsoft.EntityFrameworkCore;
using NunitWebApi.Model;

namespace NunitWebApi
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options) { }

        
        public DbSet<Customer> customer { get; set; }
    }
}
