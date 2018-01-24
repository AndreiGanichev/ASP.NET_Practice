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
        public ActionResult Ajax()
        {
            return View(new AuthViewModel());
        }

        [HttpPost]
        public ActionResult Ajax(AuthViewModel authViewModel)
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

            return View("_EnterSuccess");
        }

        public ActionResult Logout()
        {
            _auth.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}