using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Practice.DataAccess.SingleEntityRepo.Models
{
    public class Role : IBaseId
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
