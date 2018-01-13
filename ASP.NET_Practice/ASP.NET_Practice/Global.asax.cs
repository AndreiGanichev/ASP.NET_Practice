using System.Web.Mvc;
using System.Web.Routing;
using NLog;
using ASP.NET_Practice.DataAccess;
using System.Data.Entity;

namespace ASP.NET_Practice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Вызывается, когда первый экземпляр HttpApplication создается. Это позволяет создавать объекты доступные для всех экземпляров класса HttpApplication.
        /// </summary>
        protected void Application_Start()
        {
            _logger.Info("Application starting");
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<PracticeContext>(new EFDbInitializer());
        }

        /// <summary>
        /// Приложение инициализируется или при первом вызове. Вызывается для всех экземпляров объекта HttpApplication.
        /// </summary>
        public override void Init()
        {
            base.Init();
            _logger.Info("Application Init");
        }

        /// <summary>
        /// Вызывается непосредственно перед уничтожением объекта HttpApplication
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            _logger.Info("Application Dispose");
        }

        /// <summary>
        ///  Вызывается, когда необработанное исключение случается в приложении
        /// </summary>
        protected void Application_Error()
        {
            _logger.Info("Application Error");
        }

        /// <summary>
        /// Вызывается, когда все созданные ранее экземпляры класса HttpApplication уничтожены (только однажды в течение всего времени жизни приложения).
        /// </summary>
        protected void Application_End()
        {
            _logger.Info("Application End");
        }
    }
}
