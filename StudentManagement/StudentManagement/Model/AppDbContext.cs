using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Model
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }   

        public DbSet<Student> Students { get; set; }
        public DbSet<Mark_Details> Marks { get; set; }  
        public DbSet<Term> Term { get; set; }
    }
}
