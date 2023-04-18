namespace BankDemo.Model.ViewModel
{
    public class LoanDetailsVM
    {
       public int id { get;set; }
        public float Amount { get; set; }
       
        public DateTime LoanProvided { get; set; }

        public string paymentMode { get; set; }

        //public List<int> customerID { get; set; }

        //public List<Customer_Loan> customer_Loans { get; set; }
        public List<int> loanId { get; set; }



    }
    public class LoanDetailsDemoVM
    {
        public int id { get; set; }
        public float Amount { get; set; }

        public DateTime LoanProvided { get; set; }

        public string paymentMode { get; set; }

        public List<Customer_Loan> customer_Loans { get; set; }

        //public List<Loan_details> loandetailsDemo { get; set; }
        //public List<Customer_Loan> customer_Loans { get; set; }
        public List<Loan> loanId { get; set; }
    }
}
