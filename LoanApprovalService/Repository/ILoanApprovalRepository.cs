using LoanApprovalService.Models;

namespace LoanApprovalService.Repository
{
    public interface ILoanApprovalRepository
    {
        LoanApproval? GetLoanStatus(int loanId);
        void UpdateLoanStatus(LoanApproval data);   
    }
}