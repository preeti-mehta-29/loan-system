using Microsoft.EntityFrameworkCore;
using LoanService.Models;

namespace LoanService.DBContext
{
    public class LoanContext : DbContext
    {
        public LoanContext(DbContextOptions<LoanContext> options) : base(options)
        {
        }
        public LoanContext() { }
        public DbSet<Loan> Loans {  get; set; } 

    }
}
