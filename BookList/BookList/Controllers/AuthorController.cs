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
    public class AuthorController : ControllerBase
    {
        public AuthorService authorservice;
        public AuthorController(AuthorService _Authorservice)
        {
            authorservice = _Authorservice;
        }

        [HttpPost]
        public IActionResult PostNewAuthor(AuthorVM author)
        {
            authorservice.AddAuthor(author);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var demo=authorservice.GetAuthorById(id);
            return Ok(demo);
        }
    }
}
