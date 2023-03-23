using BookList.Model;
using BookList.Model.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.service
{
    public class BookService
    {
        public BookDbContext bookContext;
        public BookService(BookDbContext _bookContext)
        {
            bookContext = _bookContext;
        }

        public void CreateNewBook(BookVM book)
        {
            var _Newbook = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genere = book.Genere,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId

            };
            bookContext.books.Add(_Newbook);
            bookContext.SaveChanges();
            foreach(var item in book.AuthorId)
            {
                var _NewAuthor = new Book_Author()
                {
                    BookId = _Newbook.Id,
                    AuthorId = item
                };
                bookContext.book_author.Add(_NewAuthor);
                bookContext.SaveChanges();
            }

        }

        public List<Book> GetAllBook() => bookContext.books.ToList();
    }
}
