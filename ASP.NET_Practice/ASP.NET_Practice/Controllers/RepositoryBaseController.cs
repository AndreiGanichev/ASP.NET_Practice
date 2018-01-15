using ASP.NET_Practice.DataAccess.Interfaces;
using Ninject;
using System.Web.Mvc;

namespace ASP.NET_Practice.Controllers
{
    public class RepositoryBaseController : Controller
    {
        //будет проинициализировано при создании экземпляра контроллера исходя из настроек контейнера
        [Inject]
        public IPracticeRepository Repository { get; set; }
    }
}