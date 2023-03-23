using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data.Model
{
    public class BookDbContext:DbContext
    {
       
        public BookDbContext(DbContextOptions<BookDbContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("ConnectionStrings:DefaultConnection");
            }
        }
        public DbSet<Book> bookDemo { get; set; }

    }
}
