using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Model
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options):base(options)
        {

        }

        public DbSet<Book> books { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<Publisher> publisher { get; set; }

        public List<Book_Author> book_author { get; set; }
    }
}
