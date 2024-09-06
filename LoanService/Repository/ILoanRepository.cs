using LoanService.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.Repository
{
    public interface ILoanRepository
    {
        IEnumerable<Loan> GetLoanDetails(int userId);
        Loan GetLoanDetailsById(int loanId);        
        void CreateLoan(Loan loan);
       // IActionResult GetLoanStatus(int loanId);
    }
}
