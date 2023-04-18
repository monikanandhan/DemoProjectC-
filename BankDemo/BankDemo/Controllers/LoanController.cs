using BankDemo.Model;
using BankDemo.Model.ViewModel;
using BankDemo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        public LoanService loanService { get; set; }
        public LoanController(LoanService LoanService)
        { 
            loanService = LoanService;
        }

        [HttpPost]
        public IActionResult NewBookDetails(LoanVM loan)
        {
            loanService.AddLoanDetails(loan);
            return Ok();

        }

        [HttpGet]
        public IActionResult GetLoanDetails()
        {
            loanService.GetLoanDetails();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetLoanBYID(int id)
        {
            var result=loanService.GetLoanById(id);    
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult PutLoanDetails(int id,LoanVM loan) 
        {
            loanService.UpdateById(id,loan);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoan(int id) 
        { 
            loanService.DeleteByID(id);
            return Ok();    
        }
    }
}
