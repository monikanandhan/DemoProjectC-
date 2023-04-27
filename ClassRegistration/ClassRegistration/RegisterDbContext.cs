using ClassRegistration.Model;
using Microsoft.EntityFrameworkCore;

namespace ClassRegistration
{
    public class RegisterDbContext:DbContext
    {

        public RegisterDbContext(DbContextOptions<RegisterDbContext> options):base(options) 
        {
        
        }

        public DbSet<Register> register { get; set; }

    }
}
