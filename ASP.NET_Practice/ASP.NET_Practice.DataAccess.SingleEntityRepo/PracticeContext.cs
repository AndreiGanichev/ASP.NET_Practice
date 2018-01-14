using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System.Data.Entity;

namespace ASP.NET_Practice.DataAccess.SingleEntityRepo
{
    public class PracticeContext : DbContext
    {
        public PracticeContext(string connectionStringName) : base(connectionStringName) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
