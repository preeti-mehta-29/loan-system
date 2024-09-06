using DisbursementService.Models;
using Microsoft.EntityFrameworkCore;

namespace DisbursementService.DBContext
{
    public class DisbursementContext : DbContext
    {
        public DisbursementContext(DbContextOptions<DisbursementContext> options) : base(options)
        {
        }
        public DisbursementContext() { }
        public DbSet<Disbursement> Disbursements { get; set; }
    }
}
