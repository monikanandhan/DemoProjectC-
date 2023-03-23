using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Model.ViewModel;
using MyBooks.Data.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookService _bookservice;
        public BookController(BookService bookService)
        {
            _bookservice = bookService;

        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookservice.AddBook(book);
            return Ok();
        }

        [HttpGet("get-all-books")]

        public IActionResult GetAllBooks()
        {
            var getall=_bookservice.GetAllBooks();
            return Ok(getall);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetAllBooks(int id)
        {
          var getId=  _bookservice.GetBookbyId(id);
            return Ok(getId);
        }

    }
}
