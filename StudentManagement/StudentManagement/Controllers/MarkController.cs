using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.IService;
using StudentManagement.Model;
using StudentManagement.Service;
using StudentManagement.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        public IMarkInterface service { get; set; }
        public readonly ILogger _logger;
       
        public MarkController(IMarkInterface _service,ILogger<MarkController> logger)
        { 
            service = _service;
            _logger = logger;
            
         

        }

        [HttpPost]
        public IActionResult AddNewMark(MarkVM Mark)
        {
            _logger.LogInformation("Add-New-Mark-Details:{@controller}", GetType().Name);
            try
            {
                if (service.ToCheckTermId(Mark.TermId, Mark.studentId) < 1)
                {
                    var result= service.AddMarkDetails(Mark);
                _logger.LogInformation($"New-Mark-Details {JsonConvert.SerializeObject(result)}");
                return Ok(result);
                }
                else
                {
                    return NotFound("TermID should always be less than 6");
                }
            }
            catch (Exception ex) 
            {
                _logger.LogInformation($"Exception: {JsonConvert.SerializeObject(ex.Message)}");
                return BadRequest(ex.Message);
                
            }
           
        }                          
         

        [HttpGet("Get-Term-Wise-percentage")]
        public IActionResult GetTermWiseMark(int academic_year)
        {
            _logger.LogInformation("Get-Term-wise-student-Mark-Details-greater-than-eighty:{@controller}", GetType().Name);
            try
            {
                if (academic_year == 2023)
                {
                    Dictionary<string, Dictionary<string, double>> result = service.GetTermWiseStudentMark(academic_year);
                    _logger.LogInformation($"Term-Wise-percentage-greater-than-eighty {JsonConvert.SerializeObject(result)}");
                    return Ok(result);
                }
                else
                {
                    _logger.LogWarning("Academic Year should be 2023:input",academic_year);
                    return NotFound("Academic Year should be 2023");
                }
            }
            catch (Exception ex) 
            {
                _logger.LogInformation($"Exception: {JsonConvert.SerializeObject(ex.Message)}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-overall-Term-Percentage")]
        public IActionResult GetoverallTermPercentage(int academic_year,int fpercentage)
        {
            _logger.LogInformation("Get-Term-wise-student-overall-percentage-greater-than-eighty:{@controller}", GetType().Name);
            try
            {
                if (academic_year == 2023)
                {
                    Dictionary<string, double> result = service.GetoverallTermPercentage(academic_year, fpercentage);
                    _logger.LogInformation($"student-wise-Term-overall-percentage {JsonConvert.SerializeObject(result)}");
                    return Ok(result);
                }
                else
                {
                    _logger.LogWarning("Academic Year should be 2023:input",academic_year);
                    return NotFound("Academic Year should be 2023");
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Exception: {JsonConvert.SerializeObject(ex.Message)}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-subject-wise-Term-Percentage")]
        public IActionResult GetSubjectWiseTermPercentage(int academicYear, string subject)
        {
            _logger.LogInformation("Get-subject-wise-student--percentage-greater-than-eighty:{@controller}", GetType().Name);
            try
            {
                if (academicYear == 2023)
                {
                    Dictionary<string, Dictionary<string, double>> result = service.GetSubjectWiseTotal(academicYear, subject);
                    _logger.LogInformation($"student-wise-subject-percentage {JsonConvert.SerializeObject(result)}");

                    return Ok(result);
                }
                else
                {
                    _logger.LogWarning("Academic Year should be 2023:input",academicYear);
                    return NotFound("Academic Year should be 2023");
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Exception: {JsonConvert.SerializeObject(ex.Message)}");
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Get-overall-subject-wise-Term-Percentage")]
        public IActionResult GetStudentSubjectWiseoverallPercentage(int academicYear, string subject, int fpercentage)
        {
            _logger.LogInformation("Get-subject-wise-student-overall-percentage-greater-than-eighty:{@controller}",  GetType().Name);
            try
            {
                if (academicYear == 2023)
                {
                    Dictionary<string, double> result = service.GetStudentSubjectWiseTotal(academicYear, subject, fpercentage);
                    _logger.LogInformation($"student-wise-subject-overall-percentage {JsonConvert.SerializeObject(result)}");

                    return Ok(result);
                }
                else
                {
                    _logger.LogWarning("Academic Year should be 2023: input",academicYear);
                    return NotFound("Academic Year should be 2023");
                }
            }
            catch (Exception ex) 
            {
                _logger.LogInformation($"Exception: {JsonConvert.SerializeObject(ex.Message)}");
                return BadRequest(ex.Message) ; 
            }
        }
    }
}
