using System.Web.Mvc;
using ASP.NET_Practice.Models;
using Ninject;

namespace ASP.NET_Practice.Controllers
{
    public class HomeController : Controller
    {
        //при создании экземпляра контроллера свойство будет проинициализировано исходя из настроек контейнера
        [Inject]
        public IWeapon Weapon { get; set; }

        // GET: Home
        public ActionResult Index()
        {
            return View(Weapon);
        }
    }
}