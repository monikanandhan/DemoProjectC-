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

        public List<LoanDetails> GetLoanDetailsList()=> Context.loanDetails.ToList();

        public LoanDetailsDemoVM GetLoanDetailsByID(int id)
        {
            var LoanDetailsByid = Context.loanDetails.Where(n => n.Id == id).Select(s => new LoanDetailsDemoVM()
            {
                id = s.Id,
                Amount = s.Amount,
                LoanProvided = s.LoanProvided,
                paymentMode = s.paymentMode,
                loanId = s.loandetailsDemo.Select(n => n.loans).ToList()

            }).FirstOrDefault(); 
            return LoanDetailsByid;
        }

        public LoanDetails UpdateLoanDetailsList(int id, LoanDetailsVM loanDetails)
        {
            var nid=Context.loanDetails.FirstOrDefault(x => x.Id==id);  
            if(nid!=null)
            {
                nid.Id = loanDetails.id;
                nid.Amount=loanDetails.Amount;
                nid.LoanProvided=loanDetails.LoanProvided;  
                nid.paymentMode=loanDetails.paymentMode;

                Context.SaveChanges();

            }
            return nid;  
        }

        public void DeleteById(int id)
        {
            var nid = Context.loanDetails.FirstOrDefault(x => x.Id == id);
            if (nid != null)
            {
               
                Context.loanDetails.Remove(nid);
                Context.SaveChanges();

            }

        }

    }
}

