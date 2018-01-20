using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System.Security.Principal;
using System.Web;

namespace ASP.NET_Practice.Auth
{
    /// <summary>
    /// Функционал авторизации
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// Конекст (тут мы получаем доступ к запросу и кукисам)
        /// </summary>
        HttpContext HttpContext { get; set; }

        /// <summary>
        /// Процедура входа
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <param name="isPersistent">постоянная авторизация или нет</param>
        /// <returns></returns>
        User Login(string login, string password, bool isPersistent);

        /// <summary>
        /// Выход
        /// </summary>
        void LogOut();

        /// <summary>
        /// Данные о текущем пользователе.
        /// MSDN: A principal object represents the security context of the user on whose behalf the code is running
        /// </summary>
        IPrincipal CurrentUser { get; }
    }
}
