using System.ComponentModel.DataAnnotations;

namespace BankDemo.Model
{
    public class LoanDetails
    {
        
        public int Id { get; set; }
        public float Amount { get; set; }
        
        public DateTime LoanProvided { get;set; }
        public string paymentMode { get; set; }
        public List<Customer_Loan> customer_Loans { get; set; }
        public List<Loan_details> loandetailsDemo { get; set; }
       
    }
}
