using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using ASP.NET_Practice.Models;
using ASP.NET_Practice.DataAccess.Interfaces;
using ASP.NET_Practice.DataAccess.SqlRepository;
using ASP.NET_Practice.DataAccess;
using System.Configuration;
using System.Data.Entity;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ASP.NET_Practice.App_Start.NinjectConfigurator), "OnStart")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(ASP.NET_Practice.App_Start.NinjectConfigurator), "Onstop")]
namespace ASP.NET_Practice.App_Start
{
    public static class NinjectConfigurator
    {
        private static Bootstrapper _bootstrapper = new Bootstrapper();

        public static void OnStart()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            _bootstrapper.Initialize(CreateKernel);
        }

        public static void OnStop()
        {
            _bootstrapper.ShutDown();
        }

        /// <summary>
        /// Создаем контейнер, который будет использоваться в приложении
        /// </summary>
        /// <returns></returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(c => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// В этом методе прописывается загрузка модулей и регистрация сервисов.
        /// Модуль - набор биндингов для части приложения(подсистемы), позволяет структурировать биндинги
        /// </summary>
        /// <param name="kernel"></param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IWeapon>().To<Sword>();
            kernel.Bind<IPracticeRepository>().To<SqlRepository>();
            kernel.Bind<PracticeContext>().ToConstructor<PracticeContext>(
                c => new PracticeContext(ConfigurationManager.ConnectionStrings["PracticeContext"].ConnectionString));
        }
    }
}