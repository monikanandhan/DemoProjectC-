using BankDemo.Model;
using BankDemo.Model.ViewModel;
using BankDemo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDetailsController : ControllerBase
    {
        public LoanDetailsService loanDetailsService { get; set; }
        public LoanDetailsController(LoanDetailsService _loanDetailsService)
        {
            loanDetailsService = _loanDetailsService;
        }

        [HttpPost]
        public IActionResult NewLoanDetails(LoanDetailsVM loanDetails)
        {
            loanDetailsService.AddLoanDetails(loanDetails);
            return Ok(loanDetails);
        }


        [HttpGet]
        public IActionResult GetLoanDetails()
        {
            var result = loanDetailsService.GetLoanDetailsList();   
            return Ok(result);
        }

        [HttpPut("{id}")]
         public IActionResult UpdateByID(int id, LoanDetailsVM loanDetails)
        {
            var result = loanDetailsService.UpdateLoanDetailsList(id,loanDetails);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var result = loanDetailsService.GetLoanDetailsByID(id);
            return Ok(result);
        }
            
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        { 
            loanDetailsService.DeleteById(id);  
            return Ok();
        }
    }
}
