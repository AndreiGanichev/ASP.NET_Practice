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

        public Role CreateRole(Role role)
        {
            try
            {
                var newRole = DbContext.Roles.Add(role);
                DbContext.SaveChanges();
                return newRole;
            }
            catch
            {
                return null;
            }
        }

        public bool DeleteRole(Role role)
        {
            try
            {
                DbContext.Roles.Remove(role);
                DbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Role UpdateRole(Role role)
        {
            Role updatedRole = null;

            if (DeleteRole(role))
            {
                updatedRole = CreateRole(role);
            }

            return updatedRole;
        }
    }
}
