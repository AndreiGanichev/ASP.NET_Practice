using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Practice.Models
{
    public class AuthViewModel
    {
        [Required(ErrorMessage = "Введите email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Запомнить пользователя?
        /// </summary>
        public bool IsPersistent { get; set; }
    }
}