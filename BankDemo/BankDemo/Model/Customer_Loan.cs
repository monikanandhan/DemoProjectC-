namespace BankDemo.Model
{
    public class Customer_Loan
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
       
        public int loanDetID { get; set; }
        public LoanDetails loandetails { get; set; }
       
    }
}
