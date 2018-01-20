using ASP.NET_Practice.Auth;
using ASP.NET_Practice.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Practice.Areas.Default.Controllers
{
    public class HomeController : BaseAuthController
    {
        public HomeController(IAuthentication auth) : base(auth) { }

        // GET: Default/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }
    }
}