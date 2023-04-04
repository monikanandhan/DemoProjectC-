using Microsoft.EntityFrameworkCore;
using MyBooksDemo.Model;

namespace MyBooksDemo
{
    public class BooksDbContext:DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options):base(options)
        { 

        }
        public DbSet<Book> book {  get; set; }
    }
}
