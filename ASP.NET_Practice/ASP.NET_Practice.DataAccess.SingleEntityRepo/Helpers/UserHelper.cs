using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Practice.DataAccess.SingleEntityRepo.Helpers
{
    public static class UserHelper
    {
        /// <summary>
        /// Проверяет есть ли у пользователя <paramref name="user"/> роль с кодом <paramref name="roleCode"/>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleCode">Коды ролей в формате 'roleCode1, roleCode2'</param>
        /// <returns></returns>
        public static bool CheckUserRoles(this User user, string roleCodes)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrWhiteSpace(roleCodes))
            {
                return false;
            }

            var codesArray = roleCodes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return codesArray.Any(c => string.Equals(c, user.Role.Code));
        }
    }
}
