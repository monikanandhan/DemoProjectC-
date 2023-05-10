using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Service;
using StudentManagement.ViewModel;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        public MarkService service { get; set; }
        public MarkController(MarkService _service)
        {
            service = _service;
        }

        [HttpPost]
        public IActionResult AddNewMark(MarkVM Mark)
        {
            var NewMark = service.AddMarkDetails(Mark);  
            return Ok(NewMark);
        }



        [HttpGet("Get-Term-Wise-percentage")]
        public IActionResult GetTermWiseMark(int academic_year)
        {
            var result = service.GetTermWiseStudentMark(academic_year);
            return Ok(JsonConvert.SerializeObject(result));

        }

        [HttpGet("Get-overall-Term-Percentage")]
        public IActionResult GetoverallTermPercentage(int academic_year)
        {
            var result = service.GetoverallTermPercentage(academic_year);
            return Ok(JsonConvert.SerializeObject(result));

        }

        [HttpGet("Get-subject-wise-Term-Percentage")]
        public IActionResult GetSubjectWiseTermPercentage(int academicYear,string subject)
        {
            var result = service.GetSubjectWiseTotal(academicYear,subject);
            return Ok(result);
        }


        [HttpGet("Get-overall-subject-wise-Term-Percentage")]
        public IActionResult GetStudentSubjectWiseoverallPercentage(int academicYear, string subject)
        {
            var result = service.GetStudentSubjectWiseTotal(academicYear, subject);
            return Ok(JsonConvert.SerializeObject(result));
        }
    }
}
