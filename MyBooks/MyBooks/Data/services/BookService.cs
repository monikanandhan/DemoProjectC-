using MyBooks.Data.Model;
using MyBooks.Data.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data.services
{
    public class BookService
    {

        private BookDbContext _context;
        public BookService(BookDbContext context)
        {
            _context = context;

        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genere = book.Genere,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now

            };
            _context.bookDemo.Add(_book);
            _context.SaveChanges();
        }
        public List<Book> GetAllBooks() => _context.bookDemo.ToList();

        public Book GetBookbyId(int id) => _context.bookDemo.First(x => x.Id==id);
       
    }
    
    
}
