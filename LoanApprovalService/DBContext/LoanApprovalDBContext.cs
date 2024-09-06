using LoanApprovalService.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanApprovalService.DBContext
{
    public class LoanApprovalDBContext : DbContext
    {
        public LoanApprovalDBContext(DbContextOptions<LoanApprovalDBContext> options) : base(options)
        {
        }
        public LoanApprovalDBContext() { }
        public DbSet<LoanApproval> LoanApprovals {  get; set; } 

    }
}
