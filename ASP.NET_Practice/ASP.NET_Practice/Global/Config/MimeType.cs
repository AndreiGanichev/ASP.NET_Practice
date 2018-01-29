using System.Configuration;

namespace ASP.NET_Practice.Global.Config
{
    /// <summary>
    /// Type to map mime type configuration element
    /// </summary>
    public class MimeType : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }

        [ConfigurationProperty("resource", IsRequired = true)]
        public string Resource
        {
            get
            {
                return this["resource"] as string;
            }
        }

        [ConfigurationProperty("extension", IsRequired = true, IsKey = true)]
        public string Extension
        {
            get
            {
                return this["extension"] as string;
            }
        }

        [ConfigurationProperty("small", IsRequired = true)]
        public string Small
        {
            get
            {
                return this["small"] as string;
            }
        }
    }
}