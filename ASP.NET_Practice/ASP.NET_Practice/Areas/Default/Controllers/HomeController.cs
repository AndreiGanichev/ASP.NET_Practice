using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Practice.Areas.Default.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}