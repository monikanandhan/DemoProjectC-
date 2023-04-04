namespace BankDemo.Model
{
    public class Loan_details
    {
        
        public int Id { get; set; }
        public Loan loans { get; set; }
        public int loanId { get; set; }
        public LoanDetails LoanDetails { get; set; }
        public int LoanDetailsId { get; set;}

    }
}
