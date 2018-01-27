using ASP.NET_Practice.Global.Config;
using Ninject;
using System.Web.Mvc;

namespace ASP.NET_Practice.Controllers
{
    public class ConfigBaseController : Controller
    {
        /// <summary>
        /// Custom app configuration
        /// </summary>
        [Inject]
        public IConfiguration Configuration { get; set; }
    }
}