using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class BankContext : DbContext
    {
        public DbSet<UserProfile> Submissions { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Comment> Comments { get; set; } 
    }
}
