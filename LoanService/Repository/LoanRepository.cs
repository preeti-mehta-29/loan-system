using LoanService.DBContext;
using Microsoft.EntityFrameworkCore;
using LoanService.Models;
using LoanService.Repository;

namespace LoanService.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanContext _dbContext;

        public LoanRepository(LoanContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Loan> GetLoanDetails(int userId)
        {
            return _dbContext.Loans.Where(x=>x.UserId == userId).ToList();
        }

        public Loan GetLoanDetailsById(int loanId)
        {
            return _dbContext.Loans.Find(loanId);
        }

        public void CreateLoan(Loan loan)
        {
            loan.AppliedOn = DateTime.Now;
            _dbContext.Loans.Add(loan);
            Save();
        }

        //public IActionResult GetLoanStatus(int loanId)
        //{

        //}

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}