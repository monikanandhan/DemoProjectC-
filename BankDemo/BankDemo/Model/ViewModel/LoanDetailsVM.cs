namespace BankDemo.Model.ViewModel
{
    public class LoanDetailsVM
    {
        public int id { get; set; }
        public float Amount { get; set; }
       
        public DateTime LoanProvided { get; set; }

        public string paymentMode { get; set; }

        public List<int> loanId { get; set; }
    }
}
