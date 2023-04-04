namespace BankDemo.Model
{
    public class Loan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float InterestRate { get;set; }  
        public int LoanTenure { get; set; }

        public List<Loan_details> loandetailsDemo { get; set; }

    }
}
