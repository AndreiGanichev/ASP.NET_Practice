using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System;
using System.Linq;
using System.Security.Principal;

namespace ASP.NET_Practice.Auth
{
    /// <summary>
    /// Обертка над пользователем для IPrincipal
    /// </summary>
    public class UserIdentity : IIdentity, IUserProvider
    {
        public User User { get; set; }

        #region IIdentity
        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                return User?.Email ?? "anonym"; 
            }
        }
        #endregion

        public void Init(string email, IUserRepository repository)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                User = repository
                        .GetAll()
                        .Where(u => u.Email == email)
                        .FirstOrDefault();
            }
        }
    }
}