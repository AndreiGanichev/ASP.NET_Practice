using System.Configuration;

namespace ASP.NET_Practice.Global.Config
{
    /// <summary>
    /// Preview icon size configuration element
    /// </summary>
    public class IconSize : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }

        [ConfigurationProperty("width", IsRequired = false, DefaultValue = "48")]
        public int Width
        {
            get
            {
                return (int)this["width"];
            }
        }

        [ConfigurationProperty("height", IsRequired = false, DefaultValue = "48")]
        public int Height
        {
            get
            {
                return (int)this["height"];
            }
        }
    }
}