using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;

namespace ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Возвращает пользователя с почтой <paramref name="email"/> и паролем <paramref name="password"/>
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Login(string email, string password);
    }
}
