using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Practice.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime AddAtDate { get; set; }

        public DateTime? ActivateAtDate { get; set; }

        public DateTime? LastVisitDate { get; set; }

        public string PhotoPath { get; set; }

        [Required]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
