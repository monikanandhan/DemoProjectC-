using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Service;
using StudentManagement.ViewModel;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentService service { get; set; }
        public StudentController(StudentService _service)
        {
            service = _service;
        }

        [HttpPost]
        public IActionResult AddNewStudent(StudentVM student)
        {
            var NewStudent=service.AddStudentDetails(student); 
            return Ok(NewStudent);
        }


        [HttpGet]
        public IActionResult GetStudent()
        {
            var getStudent = service.GetStudents(); 
            return Ok(getStudent);
        }
    }
}
