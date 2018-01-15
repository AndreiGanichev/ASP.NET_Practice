using ASP.NET_Practice.DataAccess.SingleEntityRepo;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NET_Practice.Areas.Default.Controllers
{
    public class UsersController : Controller
    {
        private IGenericRepository<User> _usersRepo;

        public UsersController(IGenericRepository<User> usersRepo)
        {
            _usersRepo = usersRepo;
        }

        // GET: SingleEntityRepo
        public ActionResult GetAll()
        {
            var users = _usersRepo.GetAll().IncludeMultiple(user => user.Role).ToList();
            return View(_usersRepo.GetAll().ToList());
        }
    }
}