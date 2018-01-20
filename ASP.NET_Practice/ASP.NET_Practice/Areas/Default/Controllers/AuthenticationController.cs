using ASP.NET_Practice.Auth;
using ASP.NET_Practice.Controllers;
using ASP.NET_Practice.Models;
using System.Web.Mvc;

namespace ASP.NET_Practice.Areas.Default.Controllers
{
    public class AuthenticationController : BaseAuthController
    {
        public AuthenticationController(IAuthentication auth) : base(auth) { }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new AuthViewModel());
        }

        [HttpPost]
        public ActionResult Index(AuthViewModel authViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(authViewModel);
            }

            var user = _auth.Login(authViewModel.Email, authViewModel.Password, authViewModel.IsPersistent);

            if (user == null)
            {
                ModelState["Password"].Errors.Add("Неверный логин или пароль");
                return View(authViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            _auth.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}