using FileuploadingCSV.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileuploadingCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public CityService service { get; set; }
        public CitiesController(CityService _service) 
        { 
            service = _service;
            
        }

        [HttpPost]
        public IActionResult AddNewDetails(IFormFileCollection file)
        {
           var demo= service.AddAllDetails(file[0].OpenReadStream());
            return Ok(demo);
        }
    }
}
