using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NunitWebApi.Model;
using NunitWebApi.Service;

namespace NunitWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerService service { get; set; }
        public CustomerController(CustomerService _service) 
        { 
            service = _service;
        
        }

      
        [HttpPost]
        public IActionResult AddNewCustomer(Customer customer) 
        {
           var result=service.AddNewCustomer(customer); 
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCustomer()
        { 
            var result=service.GetAllCustomer();    
            return Ok(result);
        
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        { 
            var result=service.GetCustomerById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id,Customer customer) 
        { 
          var result=service.UpdateCustomerById(id,customer);
            return Ok(result);  
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        { 
        var result=service.DeleteCustomerById(id);
            return Ok(result);
        }
    }
}
