using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NET_Practice.Areas.Default.Controllers
{
    public class RolesController : Controller
    {
        private IGenericRepository<Role> _rolesRepo;

        public RolesController(IGenericRepository<Role> rolesRepo)
        {
            _rolesRepo = rolesRepo;
        }

        // GET: Default/Roles
        public ActionResult GetAll()
        {
            return View(_rolesRepo.GetAll().ToList());
        }
    }
}