using System.Web.Mvc;

namespace ASP.NET_Practice.Areas.Default
{
    public class DefaultAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Default";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {area = "default", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ASP.NET_Practice.Areas.Default.Controllers" } //назначается приоритетным пр-вом имен при анализе запроса
            );
        }
    }
}