using ASP.NET_Practice.DataAccess.SingleEntityRepo.Helpers;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using System.Security.Principal;

namespace ASP.NET_Practice.Auth
{
    /// <summary>
    /// Реализация IPrincial - защищенный контекст пользователя, от чьего имени выполняется код
    /// </summary>
    public class UserPrincipal : IPrincipal
    {
        private IIdentity _userIdentity;

        public UserPrincipal(string name, IUserRepository repository)
        {
            var identity = new UserIdentity();
            identity.Init(name, repository);
            _userIdentity = identity;
        }

        public IIdentity Identity
        {
            get
            {
                return _userIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            return ((IUserProvider)_userIdentity)?.User?.CheckUserRoles(role) ?? false; 
        }
    }
}