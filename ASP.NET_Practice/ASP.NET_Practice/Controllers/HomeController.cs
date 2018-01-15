using ASP.NET_Practice.Models;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NET_Practice.Controllers
{
    public class HomeController : RepositoryBaseController
    {
        //при создании экземпляра контроллера исходя из настроек контейнера
        //будут проинициализирован аргумент конструктора weapon
        public HomeController(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public IWeapon Weapon { get; set; }

        // GET: Home
        public ActionResult Index()
        {
            foreach (var role in Repository.Roles)
            {
                var name = role.Name;
            }
            return View(Repository.Roles.ToList());
        }
    }
}