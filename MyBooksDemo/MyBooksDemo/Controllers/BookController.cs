using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooksDemo.Model;
using MyBooksDemo.Service;

namespace MyBooksDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookService bookService { get; set; }
        public BookController(BookService booksService) 
        {
          bookService = booksService;
        }

        [HttpPost]
        public IActionResult CreateNewBook(Book book)
        {

            bookService.CreateNewBook(book);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetBooks()
        { 
        var result=bookService.GetAllBooks();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookBYId(int id)
        {
            bookService.GetBookByID(id);
            return Ok();
        }

       

        [HttpPut("{id}")]
        public IActionResult EditBook(int id,Book book) 
        {
            bookService.UpdateAllBooks(id,book);
            return Ok();
         }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id) 
        { 
            bookService.DeleteByID(id); 
            return Ok();    
        }
        

    }
}
