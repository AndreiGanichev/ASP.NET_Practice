using System;
using System.Configuration;
using System.Linq;

namespace ASP.NET_Practice.Global.Config
{
    /// <summary>
    /// Custom app configuration
    /// </summary>
    public class Configuration : IConfiguration
    {
        public IQueryable<IconSize> IconSizes
        {
            get
            {
                var iconConfig = (IconSizesConfigSection)ConfigurationManager.GetSection("iconConfig");
                return iconConfig.IconSizes.OfType<IconSize>().AsQueryable();
            }
        }

        public IQueryable<MimeType> MimeTypes
        {
            get
            {
                var mimeTypesComfig = (MimeTypeConfigSection)ConfigurationManager.GetSection("mimeTypeConfig");
                return mimeTypesComfig.MimeTypes.OfType<MimeType>().AsQueryable();
            }
        }
    }
}