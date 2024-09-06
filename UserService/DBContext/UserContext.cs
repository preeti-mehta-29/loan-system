using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.DBContext
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public UserContext() { }
        public DbSet<User> Users {  get; set; }
        public DbSet<Session> Sessions {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(x=> x.Email).IsUnique();
            modelBuilder.Entity<Session>().HasIndex(x=> x.SessionId).IsUnique();
        }
    }
}
