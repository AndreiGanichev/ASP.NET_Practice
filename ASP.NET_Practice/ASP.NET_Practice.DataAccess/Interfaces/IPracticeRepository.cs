using System.Linq;
using ASP.NET_Practice.DataAccess.Models;

namespace ASP.NET_Practice.DataAccess.Interfaces
{
    public interface IPracticeRepository
    {
        IQueryable<Role> Roles { get; }
        IQueryable<User> Users { get; }

        Role AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        User AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
