using MyBooksDemo.Model;
using System.Threading;

namespace MyBooksDemo.Service
{
    public class BookService
    {
        public BooksDbContext Context { get; set; }
        public BookService(BooksDbContext booksDbContext) 
        { 

            Context = booksDbContext;
        }

        public List<Book> GetAllBooks()=>
       
            Context.book.ToList();
       
        

        public void CreateNewBook(Book book) 
        {
            var books = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genere = book.Genere,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now

            };
           Context.book.Add(books);
            Context.SaveChanges();
        }

        public void UpdateAllBooks(int id,Book book)
        {
            var nid=Context.book.FirstOrDefault(n=>n.Id==id);
            if(nid!=null)
            {

                nid.Title = book.Title;
                nid.Description = book.Description;
                nid.IsRead = book.IsRead;
                nid.DateRead = book.IsRead ? book.DateRead.Value : null;
                nid.Rate = book.IsRead ? book.Rate.Value : null;
                nid.Genere = book.Genere;
                nid.CoverUrl = book.CoverUrl;
                nid.DateAdded = DateTime.Now;


                     Context.SaveChanges();


            }

           

        }
    }
}
