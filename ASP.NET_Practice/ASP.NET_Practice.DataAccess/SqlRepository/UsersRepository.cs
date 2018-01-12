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

        public User CreateUser(User User)
        {
            try
            {
                var newUser = DbContext.Users.Add(User);
                DbContext.SaveChanges();
                return newUser;
            }
            catch
            {
                return null;
            }
        }

        public bool DeleteUser(User User)
        {
            try
            {
                DbContext.Users.Remove(User);
                DbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User UpdateUser(User User)
        {
            User updatedUser = null;

            if (DeleteUser(User))
            {
                updatedUser = CreateUser(User);
            }

            return updatedUser;
        }
    }
}
