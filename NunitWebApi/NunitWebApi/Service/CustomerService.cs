using NunitWebApi.Model;

namespace NunitWebApi.Service
{
    public class CustomerService
    {
        public CustomerDbContext context { get; set; }  
        public CustomerService(CustomerDbContext _context) 
        { 
            context = _context;
        }

        public Customer AddNewCustomer(Customer customer) 
        {
            var NewCustomer = new Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                phone = customer.phone
            };
            context.customer.Add(NewCustomer);
            context.SaveChanges();
            return NewCustomer;
        }

        public List<Customer> GetAllCustomer() =>context.customer.ToList();

        public Customer GetCustomerById(int id) 
        {
            var GetCustomer = context.customer.Where(x => x.Id == id).Select(c => new Customer()
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                phone = c.phone
            }).FirstOrDefault();
            context.SaveChanges();
            return GetCustomer;
        }

        public Customer UpdateCustomerById(int id,Customer customer)
        {
            var UpdateCustomer=context.customer.FirstOrDefault(x => x.Id == id);    
            if(UpdateCustomer!=null)
            {
                UpdateCustomer.Id = customer.Id;
                UpdateCustomer.Name = customer.Name;
                UpdateCustomer.Age = customer.Age;
                 UpdateCustomer.phone= customer.phone;

            }
            context.SaveChanges();
            return UpdateCustomer;
        }

        public Customer DeleteCustomerById(int id)
        {
            var DeleteCustomer=context.customer.FirstOrDefault( x => x.Id == id);
            if(DeleteCustomer!=null)
            {
                context.customer.Remove(DeleteCustomer);
                context.SaveChanges();
                
            }
            return DeleteCustomer;
        }
        
    }
}
