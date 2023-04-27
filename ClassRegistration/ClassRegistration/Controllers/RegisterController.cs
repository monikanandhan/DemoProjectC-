using ClassRegistration.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public RegisterDbContext Context { get; set; }
        public RegisterController(RegisterDbContext _context)
        {
            Context = _context;
        }

       

        [HttpPost]
        public IActionResult AddRegistrationDetails(Register register)
        {
            var NewRegister = new Register()
            {
                Id = register.Id,
                Name = register.Name,
                Age = register.Age
            };
            Context.register.Add(NewRegister);
            Context.SaveChanges();
            return Ok(NewRegister);
        }

        [HttpGet]
        public IActionResult GetRegistrationDetails()
        {
            var result = Context.register.ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistrationById(int id)
        {
             var result=Context.register.Where(x =>x.Id==id).Select(c => new Register()
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age
            }).FirstOrDefault();
            Context.SaveChanges();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Register register)
        {
            var result = Context.register.First(x => x.Id == id);
            if (result != null)
            {
                result.Id = register.Id;
                result.Name = register.Name;
                result.Age = register.Age;
            }
            Context.SaveChanges();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var result = Context.register.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                Context.register.Remove(result);
                Context.SaveChanges();
            }
            return Ok(result);
        }
    } 
}
