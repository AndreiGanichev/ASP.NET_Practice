using System.Configuration;

namespace ASP.NET_Practice.Global.Config
{
    /// <summary>
    /// Type to map mimeType section from config
    /// </summary>
    public class MimeTypeConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("mimeTypes")]
        public MimeTypeConfigCollection MimeTypes
        {
            get
            {
                return this["mimeTypes"] as MimeTypeConfigCollection;
            }
        }
    }

    /// <summary>
    /// Collection of MimeType config elements
    /// </summary>
    public class MimeTypeConfigCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MimeType();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MimeType)element).Extension;
        }
    }
}