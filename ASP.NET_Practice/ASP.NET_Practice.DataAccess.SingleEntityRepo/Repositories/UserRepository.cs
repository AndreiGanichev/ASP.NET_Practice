using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System;
using System.Linq;

namespace ASP.NET_Practice.DataAccess.SingleEntityRepo.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PracticeContext dbContext) : base(dbContext) { }

        public User Login(string email, string password)
        {
            return GetAll()
                    .Where(u => u.Email == email && u.Password == password)
                   .FirstOrDefault();
        }
    }
}
