using BookList.Model.ModelView;
using BookList.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookService bookService;
        public BookController(BookService _bookService)
        {
            bookService = _bookService;
        }

        [HttpPost]
        public IActionResult CreateNewBook(BookVM book)
        {
            bookService.CreateNewBook(book);
            return Ok();
        }


        [HttpGet]
        public IActionResult GetAllBooks()
        {
           var result= bookService.GetAllBook();
            return Ok(result);
        }
    }
}
