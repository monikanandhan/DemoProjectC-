using BookList.Model;
using BookList.Model.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.service
{
    public class AuthorService
    {
        public BookDbContext bookContext;
        public AuthorService(BookDbContext _bookContext)
        {
            bookContext = _bookContext;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                AuthorName = author.AuthorName
            };
            bookContext.author.Add(_author);
            bookContext.SaveChanges();
        }

        public AuthorWithBook GetAuthorById(int id)
        {
            var _author = bookContext.author.Where(x => x.Id == id).Select(n => new AuthorWithBook()
            {
                AuthorName = n.AuthorName,
                BookName = n.book_author.Select(n => n.book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}
