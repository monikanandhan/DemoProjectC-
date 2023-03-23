using BookList.Model;
using BookList.Model.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.service
{
    public class PublisherService
    {
        public BookDbContext bookContext;
        public PublisherService(BookDbContext _bookContext)
        {
            bookContext = _bookContext;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                PublisherName = publisher.PublisherName
            };
            bookContext.publisher.Add(_publisher);
            bookContext.SaveChanges();
        }

        public PublisherWithBook GetPublisherByID(int id)
        {
            var _publisher = bookContext.publisher.Where(n => n.Id == id).Select(n => new PublisherWithBook()
            {
                PublisherName = n.PublisherName,
                bookWithAuthors = n.booksDemo.Select(n => new BookWithAuthor()
                {
                    BookName = n.Title,
                    AuthorName = n.book_author.Select(n => n.author.AuthorName).ToList()
                }).ToList()
            }).FirstOrDefault();
            return _publisher;
        }

        public void DeletePublisherById(int id)
        {
            var DemoId = bookContext.publisher.FirstOrDefault(x => x.Id == id);
            bookContext.publisher.Remove(DemoId);
            bookContext.SaveChanges();
        }
    }
}
