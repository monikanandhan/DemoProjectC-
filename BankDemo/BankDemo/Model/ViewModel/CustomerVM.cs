using System.ComponentModel.DataAnnotations.Schema;

namespace BankDemo.Model.ViewModel
{
    public class CustomerVM
    {
      
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float age { get; set; }
        public string Contact1 { get; set; }
        public string Email { get; set; }
        public string Aadhar { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        
        public List<int> loanDId { get; set; }

    }
    public class CustomerwithDetailsVM
    {
        public int id { get; set; }     
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float age { get; set; }
        public string Contact1 { get; set; }
        public string Email { get; set; }
        public string Aadhar { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

       public List<LoanDetails> LoanDetails { get; set; }
        public List<Customer_Loan> customer_Loans { get; set; }
    }
}
