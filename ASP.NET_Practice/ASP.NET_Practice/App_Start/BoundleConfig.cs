using System.Web.Optimization;

namespace ASP.NET_Practice.App_Start
{
    public class BoundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-1.*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap*"));
            bundles.Add(new ScriptBundle("~/bundles/common")
                .Include("~/Scripts/MyScripts/common.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                .Include("~/Scripts/jquery-ui-1.*"));
            bundles.Add(new StyleBundle("~/Content/css/jqueryui")
                   .Include("~/Content/jquery-ui-1*"));

            //Важен порядок включения стилей! Сначало кастомные, потом bootstrap
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/Site.css")
                .Include("~/Content/bootstrap*"));

            //Установить в true для включения минификации
            //BundleTable.EnableOptimizations = true;
        }
    }
}