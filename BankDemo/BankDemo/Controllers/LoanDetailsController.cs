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
            var result=loanDetailsService.GetAllLoanDetails();
            return Ok(result);
        }
    }
}
