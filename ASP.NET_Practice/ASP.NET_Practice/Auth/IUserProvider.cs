using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;

namespace ASP.NET_Practice.Auth
{
    public interface IUserProvider
    {
        User User { get; }
    }
}
