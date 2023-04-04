using BankDemo.Model;
using BankDemo.Model.ViewModel;
using BankDemo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace BankDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerService CustomerService { get; set; }
        public CustomerController(CustomerService _customerService) 
        { 
            CustomerService = _customerService;
        }

        [HttpPost]
        public IActionResult AddNewCustomer(CustomerVM customers)
        {
           CustomerService.AddCustomerDetails(customers);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllCustomer() 
        {
        var CustomerAll=CustomerService.GetAllCustomerDeatils();
            return Ok(CustomerAll);
        }
    }
}
