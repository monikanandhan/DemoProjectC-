using BankDemo.Model;
using BankDemo.Model.ViewModel;
using Microsoft.VisualBasic;
using System.Security.Authentication;

namespace BankDemo.Service
{
    public class CustomerService
    {
        public BankDbContext Context { get; set; }  
        public CustomerService(BankDbContext _Context)
        { 
            Context = _Context;
        }

        public void AddCustomerDetails(CustomerVM customer)
        {
            var NewDetails = new Customer()
            {
               
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                DateOfBirth = customer.DateOfBirth,
                age = (((DateTime.Now).Subtract(customer.DateOfBirth)).Days)/360,
                Contact1 = customer.Contact1,
                Email = customer.Email,
                Aadhar = customer.Aadhar,
                Address1 = customer.Address1,
                Address2 = customer.Address2,
                City = customer.City,
                ZipCode = customer.ZipCode,
                Country = customer.Country
              
            };

            Context.customer.Add(NewDetails);
            Context.SaveChanges();
            foreach (var item in customer.loanDId)
            {
                var NewDemoDetails = new Customer_Loan()
                {
                    CustomerId = NewDetails.id,
                    loanDetID = item
                };
                Context.customer_loan.Add(NewDemoDetails);
                Context.SaveChanges();
            }

        }


        public List<Customer> GetAllCustomerDeatils()=> Context.customer.ToList();  
     
           
        
    }
}
