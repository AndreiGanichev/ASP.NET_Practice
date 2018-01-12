using System.Linq;
using ASP.NET_Practice.DataAccess.Interfaces;
using ASP.NET_Practice.DataAccess.Models;

namespace ASP.NET_Practice.DataAccess.SqlRepository
{
    public partial class SqlRepository : IPracticeRepository
    {
        public IQueryable<Role> Roles
        {
            get
            {
                return DbContext.Roles;
            }
        }

        public Role AddRole(Role role)
        {
            var newRole = DbContext.Roles.Add(role);
            DbContext.SaveChanges();
            return newRole;
        }

        public void DeleteRole(Role role)
        {
            DbContext.Roles.Remove(role);
            DbContext.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            DbContext.Entry(role).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
