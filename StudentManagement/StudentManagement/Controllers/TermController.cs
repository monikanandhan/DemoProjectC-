using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Model;
using StudentManagement.Service;
using StudentManagement.ViewModel;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {

        public TermService service { get; set; }
        public TermController(TermService _service)
        {
            service = _service;
        }

        [HttpPost]
        public IActionResult AddNewTerm(Term term)
        {
            var NewTerm= service.AddTermDetails(term); 
            return Ok(NewTerm);
        }

    }
}
