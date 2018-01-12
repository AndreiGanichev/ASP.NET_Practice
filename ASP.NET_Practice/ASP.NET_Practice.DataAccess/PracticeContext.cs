using System.Data.Entity;
using ASP.NET_Practice.DataAccess.Models;

namespace ASP.NET_Practice.DataAccess
{
    public class PracticeContext : DbContext
    {
        static PracticeContext()
        {
            Database.SetInitializer<PracticeContext>(new EFDbInitializer());
        }

        public PracticeContext(string connectionName) : base(connectionName)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
