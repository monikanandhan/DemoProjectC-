using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Model;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        [HttpPost("{Symbol}")]
        public IActionResult Calc(Calc c,string Symbol)
        {
            if(Symbol=="+")
            {
                c.total = c.num1 + c.num2;
               
            }else 
            if (Symbol == "-")
            {
                c.total = c.num1 - c.num2;

            }
            else
            if (Symbol == "*")
            {
                c.total = c.num1 * c.num2;

            }
            else
            if (Symbol == "/")
            {
                c.total = c.num1 / c.num2;

            }
            return Ok(c.total);
        }
    }
}
