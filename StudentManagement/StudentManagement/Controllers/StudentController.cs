using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.IService;
using StudentManagement.Service;
using StudentManagement.ViewModel;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IStudentInterface service { get; set; }
        private readonly ILogger logger;
       
        public StudentController(IStudentInterface _service,ILogger<StudentController> _logger)
        {
            service = _service;
            logger = _logger;
          
        }

        [HttpPost]
        public IActionResult AddNewStudent(StudentVM student)
        {
            logger.LogInformation("Add-New-Student:{@controller}", GetType().Name);  
            var NewStudent=service.AddStudentDetails(student);
            logger.LogInformation($"New-student-Details {JsonConvert.SerializeObject(NewStudent)}");
            return Ok(NewStudent);
        }


        [HttpGet]
        public IActionResult GetStudent()
        {
            logger.LogInformation("Get-all-Student:{@controller}", GetType().Name);
            var getStudent = service.GetStudents();
            logger.LogInformation($"all-Student-Details {JsonConvert.SerializeObject(getStudent)}");
            return Ok(getStudent);
        }
    }
}
