using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NET_Practice.Controllers
{
    public class SingleEntityRepoController : Controller
    {
        IGenericRepository<Role> _rolesRepo;

        public SingleEntityRepoController(IGenericRepository<Role> rolesRepo)
        {
            _rolesRepo = rolesRepo;
        }

        // GET: SingleEntityRepo
        public ActionResult SingleEntityRepo()
        {
            return View(_rolesRepo.GetAll().ToList());
        }
    }
}