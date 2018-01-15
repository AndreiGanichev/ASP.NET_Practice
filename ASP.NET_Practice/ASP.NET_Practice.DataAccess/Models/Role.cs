using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Practice.DataAccess.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
