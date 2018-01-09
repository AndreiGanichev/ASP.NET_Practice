using NLog;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ASP.NET_Practice.App_Start.PreAppStart), "PreStart")]
namespace ASP.NET_Practice.App_Start
{
    public static class PreAppStart
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void PreStart()
        {
            _logger.Info("Application PreStart");
        }
    }
}