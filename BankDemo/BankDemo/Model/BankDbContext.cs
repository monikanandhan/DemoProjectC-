using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace BankDemo.Model
{
    public class BankDbContext:DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Customer_Loan>().HasOne(c => c.customer).WithMany(cl => cl.customer_Loans).
                HasForeignKey(c => c.CustomerId);

            modelbuilder.Entity<Customer_Loan>().HasOne(c => c.loandetails).WithMany(cl => cl.customer_Loans).
                 HasForeignKey(c => c.loanDetID);

            modelbuilder.Entity<Loan_details>().HasOne(c => c.loans).WithMany(cl => cl.loandetailsDemo).
               HasForeignKey(c => c.loanId);

            modelbuilder.Entity<Loan_details>().HasOne(c => c.LoanDetails).WithMany(cl => cl.loandetailsDemo).
               HasForeignKey(c => c.LoanDetailsId);


        }
        public DbSet<Customer> customer { get; set; }   
        public DbSet<LoanDetails> loanDetails { get; set; } 
        public DbSet<Loan> loans { get; set; }

        public DbSet<Customer_Loan> customer_loan { get; set; }
        public DbSet<Loan_details>  loan_Details { get; set; }

    }
}
