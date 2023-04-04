using BankDemo.Model;
using BankDemo.Model.ViewModel;

namespace BankDemo.Service
{
    public class LoanService
    {
        public BankDbContext Context { get; set; }  
        public LoanService(BankDbContext  bankDbContext) 
        { 
            Context = bankDbContext;
        }

        public void AddLoanDetails(LoanVM loan)
        {
            var NewLoan = new Loan()
            {
               
                Name = loan.Name,
                Description = loan.Description,
                InterestRate = loan.InterestRate,
                LoanTenure = loan.LoanTenure
            };
            Context.loans.Add(NewLoan); 
            Context.SaveChanges();
        }

        public List<Loan> GetLoanDetails()=>Context.loans.ToList();
       
    }
}
