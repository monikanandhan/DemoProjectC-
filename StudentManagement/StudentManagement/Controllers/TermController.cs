using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.IService;
using StudentManagement.Model;
using StudentManagement.Service;
using StudentManagement.ViewModel;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {

        public ITermInterface service { get; set; }
        
        private readonly ILogger _logger;

        public TermController(ITermInterface _service,ILogger<TermController> logger)
        {
            service = _service;
            _logger = logger;
            
        }

        [HttpPost]
        public IActionResult AddNewTerm(Term term)
        {
            _logger.LogInformation("Add-New-Term:{@controller}",  GetType().Name);
            
            var NewTerm= service.AddTermDetails(term);
            _logger.LogInformation($"Term-Details {JsonConvert.SerializeObject(NewTerm)}");
            return Ok(NewTerm);
        }

    }
}
