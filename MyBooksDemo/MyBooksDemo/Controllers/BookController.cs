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

        [HttpGet]
        public IActionResult GetBooks()
        { 
        var result=bookService.GetAllBooks();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateNewBook(Book book)
        {

            bookService.CreateNewBook(book);
            return Ok();    
        }

        [HttpPut("{id}")]
        public IActionResult EditBook(int id,Book book) 
        {
            bookService.UpdateAllBooks(id,book);
            return Ok();
                }

    }
}
