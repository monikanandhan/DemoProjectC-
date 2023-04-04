using BankDemo.Model;
using BankDemo.Model.ViewModel;
using Org.BouncyCastle.Crypto.Prng;

namespace BankDemo.Service
{
    public class LoanDetailsService
    {
        public BankDbContext Context { get; set; }  
        public LoanDetailsService(BankDbContext _context)
        { 
            Context = _context;
        }
       

        public void AddLoanDetails(LoanDetailsVM loanDetails)
        {
            var NewLoanDetails = new LoanDetails()
            {
                Amount = loanDetails.Amount,
                LoanProvided = loanDetails.LoanProvided,
                paymentMode = loanDetails.paymentMode
            };
            Context.loanDetails.Add(NewLoanDetails);
            Context.SaveChanges();
            foreach (var item in loanDetails.loanId)
            {
                var NewResult = new Loan_details()
                {
                    LoanDetailsId = NewLoanDetails.Id,
                    loanId = item

                };
                Context.loan_Details.Add(NewResult);
                Context.SaveChanges();
                
            }
        }

        public List<LoanDetails> GetAllLoanDetails()=>Context.loanDetails.ToList();
    }
}
