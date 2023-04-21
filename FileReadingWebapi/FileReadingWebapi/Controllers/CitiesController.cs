using FileReadingWebapi.Model;
using FileReadingWebapi.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileReadingWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public getCities service { get; set; }
        public CitiesController(getCities _service) 
        { 
            service = _service;
        }

        [HttpPost]
        public IActionResult InsertAllcities(Cities cities)
        {
        service.GetAllcitiesAsList(cities);
            return Ok(cities);
        }
    }
}
