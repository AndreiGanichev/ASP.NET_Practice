using System.Linq;

namespace ASP.NET_Practice.Global.Config
{
    /// <summary>
    /// Interface to work with custom app configuration
    /// </summary>
    public interface IConfiguration
    {
        IQueryable<IconSize> IconSizes { get;}
    }
}
