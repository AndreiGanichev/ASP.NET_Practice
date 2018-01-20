using ASP.NET_Practice.Auth;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System.Web.Mvc;

namespace ASP.NET_Practice.Controllers
{
    public class BaseAuthController : Controller
    {
        protected IAuthentication _auth;

        public BaseAuthController(IAuthentication auth)
        {
            _auth = auth;
        }

        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)_auth.CurrentUser.Identity).User;
            }
        }
    }
}