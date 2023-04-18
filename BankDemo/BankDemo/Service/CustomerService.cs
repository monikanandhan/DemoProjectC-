using BankDemo.Model;
using BankDemo.Model.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
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
     
        public CustomerwithDetailsVM GetCustomerById(int id)
        {
                var CustomerDetails = Context.customer.Where(n => n.id == id).Select(customer => new CustomerwithDetailsVM()
            {
                id=customer.id,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                DateOfBirth = customer.DateOfBirth,
                age = (((DateTime.Now).Subtract(customer.DateOfBirth)).Days) / 360,
                Contact1 = customer.Contact1,
                Email = customer.Email,
                Aadhar = customer.Aadhar,
                Address1 = customer.Address1,
                Address2 = customer.Address2,
                City = customer.City,
                ZipCode = customer.ZipCode,
                Country = customer.Country,
                LoanDetails = customer.customer_Loans.Where(n => n.CustomerId == id).Select(s => s.loandetails).ToList()



            }).FirstOrDefault(); 
         return CustomerDetails;
        }

        public Customer UpdateCustomerById(int id, CustomerVM customer)
        {
            var nid = Context.customer.FirstOrDefault(customer => customer.id == id);
            if (nid != null)
            {
                nid.Firstname = customer.Firstname;
                nid.Lastname = customer.Lastname;
                nid.DateOfBirth = customer.DateOfBirth;
                nid.age = (((DateTime.Now).Subtract(customer.DateOfBirth)).Days) / 360;
                nid.Contact1 = customer.Contact1;
                nid.Email = customer.Email;
                nid.Aadhar = customer.Aadhar;
                nid.Address1 = customer.Address1;
                nid.Address2 = customer.Address2;
                nid.City = customer.City;
                nid.ZipCode = customer.ZipCode;
                nid.Country = customer.Country;
                
                Context.SaveChanges();
            }
            return nid;

        }

        public void DeleteByID(int id)
        {
            var nid = Context.customer.FirstOrDefault(customer => customer.id == id);
            if (nid != null)
            {
                Context.customer.Remove(nid);
                Context.SaveChanges();
            }

        }
    }
}
