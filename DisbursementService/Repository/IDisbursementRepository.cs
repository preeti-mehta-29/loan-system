using DisbursementService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DisbursementService.Repository
{
    public interface IDisbursementRepository
    {
        Disbursement? GetDetailsByLoanId(int loanId);
        Disbursement? GetDisbursementDetails(int Id);
        IEnumerable<Disbursement> GetUserLoans(int userId);        
        void UpdateDisbursementStatus(Disbursement loan);       
    }
}
