using System.Linq;
using ASP.NET_Practice.DataAccess.Models;

namespace ASP.NET_Practice.DataAccess.Interfaces
{
    public interface IPracticeRepository
    {
        IQueryable<Role> Roles { get; }
        IQueryable<User> Users { get; }

        Role CreateRole(Role role);
        Role UpdateRole(Role role);
        bool DeleteRole(Role role);
        User CreateUser(User role);
        User UpdateUser(User role);
        bool DeleteUser(User role);
    }
}
