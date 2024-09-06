using DisbursementService.DBContext;
using Microsoft.EntityFrameworkCore;
using DisbursementService.Models;
using DisbursementService.Repository;

namespace DisbursementService.Repository
{
    public class DisbursementRepository : IDisbursementRepository
    {
        private readonly DisbursementContext _dbContext;

        public DisbursementRepository(DisbursementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Disbursement? GetDetailsByLoanId(int loanId)
        {
            return _dbContext.Disbursements.FirstOrDefault(x=> x.LoanId == loanId);
        }
        public Disbursement? GetDisbursementDetails(int Id)
        {
            return _dbContext.Disbursements.Find(Id);
        }
        public IEnumerable<Disbursement> GetUserLoans(int userId)
        {
            return _dbContext.Disbursements.Where(x => x.UserId == userId).ToList();
        }

        public void UpdateDisbursementStatus(Disbursement loan)
        {
            loan.DisbursementStatus = "Pending";
            loan.DisbursedOn = DateTime.Now;
            _dbContext.Disbursements.Add(loan);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}