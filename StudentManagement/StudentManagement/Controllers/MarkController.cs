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
            try {
                var NewMark = service.AddMarkDetails(Mark);
                return Ok(NewMark);
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
            }




        [HttpGet("Get-Term-Wise-percentage")]
        public IActionResult GetTermWiseMark(int? academic_year)
        {
            try
            {
                var result = service.GetTermWiseStudentMark(academic_year);

                return Ok(JsonConvert.SerializeObject(result));
            }
            catch(Exception ex)
                {
                    return NotFound(ex.Message);    
                }
           
        }

        [HttpGet("Get-overall-Term-Percentage")]
        public IActionResult GetoverallTermPercentage(int academic_year)
        {
            try
            {
                var result = service.GetoverallTermPercentage(academic_year);
                if (result == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(JsonConvert.SerializeObject(result));
                }
            }
            catch(Exception ex) 
            { 
            return NotFound(ex.Message);
            }
        }

        [HttpGet("Get-subject-wise-Term-Percentage")]
        public IActionResult GetSubjectWiseTermPercentage(int academicYear, string subject)
        {
            try
            {
                var result = service.GetSubjectWiseTotal(academicYear, subject);
                if (result == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result);
                }
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            }


        [HttpGet("Get-overall-subject-wise-Term-Percentage")]
        public IActionResult GetStudentSubjectWiseoverallPercentage(int academicYear, string subject)
        {
            try
            {
                var result = service.GetStudentSubjectWiseTotal(academicYear, subject);
                if (result == null)
                {
                    return NoContent();
                } else
                {
                    return Ok(JsonConvert.SerializeObject(result));
                }
            }catch(Exception ex)
            {
                return NotFound(ex.Message) ;   
            }
        }
    }
}
