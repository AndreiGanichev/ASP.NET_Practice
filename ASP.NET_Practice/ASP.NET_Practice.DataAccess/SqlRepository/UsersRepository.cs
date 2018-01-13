using System.Linq;
using ASP.NET_Practice.DataAccess.Interfaces;
using ASP.NET_Practice.DataAccess.Models;

namespace ASP.NET_Practice.DataAccess.SqlRepository
{
    public partial class SqlRepository : IPracticeRepository
    {
        public IQueryable<User> Users
        {
            get
            {
                return DbContext.Users;
            }
        }

        public User AddUser(User user)
        {
            var newUser = DbContext.Users.Add(user);
            DbContext.SaveChanges();
            return newUser;
        }

        public void DeleteUser(User user)
        {
            DbContext.Users.Remove(user);
            DbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            DbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
