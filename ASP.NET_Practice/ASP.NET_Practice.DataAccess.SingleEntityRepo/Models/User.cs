using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Practice.DataAccess.SingleEntityRepo.Models
{
    public class User : IBaseId
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime AddAtDate { get; set; }

        public DateTime? ActivateAtDate { get; set; }

        public DateTime? LastVisitDate { get; set; }

        public string PhotoPath { get; set; }

        [Required]
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
