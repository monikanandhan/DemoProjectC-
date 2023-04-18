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

        public Loan GetLoanById(int id)
        {
            var LoanDetails = Context.loans.Where(n => n.Id == id).Select(n => new Loan()
            {
                Id = n.Id,
                Name=n.Name,
                Description=n.Description,
                InterestRate = n.InterestRate,  
                LoanTenure = n.LoanTenure
            }).ToList().FirstOrDefault();
            return LoanDetails;
        }
       
        public Loan UpdateById(int id, LoanVM Loan)
        {
            var loanid=Context.loans.FirstOrDefault(n => n.Id == id);
            if(loanid!=null)
            {
                    loanid.Name=Loan.Name; 
                    loanid.Description=Loan.Description;
                    loanid.InterestRate=Loan.InterestRate;
                    loanid.LoanTenure=Loan.LoanTenure;
                Context.SaveChanges();
            }
            return loanid;
            
        }

        public void DeleteByID(int id)
        {
            var loanid = Context.loans.FirstOrDefault(n => n.Id == id);
            if (loanid != null)
            {
                Context.loans.Remove(loanid);  
                Context.SaveChanges();
            }
           
        }
    }
}
