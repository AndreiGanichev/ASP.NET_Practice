using System.Web.Mvc;
using System.Web.Routing;
using NLog;
using ASP.NET_Practice.DataAccess.SingleEntityRepo;
using System.Data.Entity;
using ASP.NET_Practice.Areas.Admin;
using ASP.NET_Practice.Areas.Default;
using ASP.NET_Practice.Mappers;
using ASP.NET_Practice.App_Start;
using System.Web.Optimization;

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

            #region AreasRegistration
            var adminArea = new AdminAreaRegistration();
            var adminAreaContext = new AreaRegistrationContext(adminArea.AreaName, RouteTable.Routes);
            adminArea.RegisterArea(adminAreaContext);

            var defaultArea = new DefaultAreaRegistration();
            var defaultAreaContext = new AreaRegistrationContext(defaultArea.AreaName, RouteTable.Routes);
            defaultArea.RegisterArea(defaultAreaContext);
            #endregion

            //если сразу регистрировать все области, то сначала зарегается Default и тогда до Admin будет не достучаться
            //поэтому используем код выше
            //AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BoundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<PracticeContext>(new EFDbInitializer());
            CommonMapper.Configurate();
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
