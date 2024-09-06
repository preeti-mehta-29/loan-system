using LoanApprovalService.DBContext;
using Microsoft.EntityFrameworkCore;
using LoanApprovalService.Repository;
using LoanApprovalService.Models;

namespace LoanApprovalService.Repository
{
    public class LoanApprovalRepository : ILoanApprovalRepository
    {
        private readonly LoanApprovalDBContext _dbContext;

        public LoanApprovalRepository(LoanApprovalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public LoanApproval? GetLoanStatus(int loanId)
        {
            return _dbContext.LoanApprovals.FirstOrDefault(x => x.LoanId == loanId);
        }
        public void UpdateLoanStatus(LoanApproval data)
        {
            data.Status = "Pending";
            data.UpdatedOn = DateTime.Now;
            _dbContext.LoanApprovals.Add(data);
            _dbContext.SaveChanges();
        }
    }
}