using System.Configuration;

namespace ASP.NET_Practice.Global.Config
{
    /// <summary>
    /// Type to map IconSizes section from config
    /// </summary>
    public class IconSizesConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("iconSizes")]
        public IconSizesCollection IconSizes
        {
            get
            {
                return this["iconSizes"] as IconSizesCollection;
            }
        }
    }

    /// <summary>
    /// Collection of IconSize config elements
    /// </summary>
    public class IconSizesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new IconSize();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((IconSize)element).Name;
        }
    }
}