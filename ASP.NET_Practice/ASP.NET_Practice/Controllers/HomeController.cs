using System.Web.Mvc;
using ASP.NET_Practice.Models;
using Ninject;
using ASP.NET_Practice.DataAccess.Interfaces;
using System.Linq;

namespace ASP.NET_Practice.Controllers
{
    public class HomeController : Controller
    {
        private IPracticeRepository _repository;

        //при создании экземпляра контроллера исходя из настроек контейнера
        //будут проинициализированы:
        // -аргумент конструктора repository
        // -свойство Weapon c атрибутом Inject
        public HomeController(IPracticeRepository repository)
        {
            _repository = repository;
        }   
 
        
        [Inject]
        public IWeapon Weapon { get; set; }

        // GET: Home
        public ActionResult Index()
        {
            foreach (var role in _repository.Roles)
            {
                var name = role.Name;
            }
            return View(_repository.Roles.ToList());
        }
    }
}