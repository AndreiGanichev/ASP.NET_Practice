using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ASP.NET_Practice.DataAccess.SingleEntityRepo
{
    public class EFDbInitializer : DropCreateDatabaseAlways<PracticeContext>
    {
        protected override void Seed(PracticeContext context)
        {
            base.Seed(context);
            context.Roles.AddRange(GetRoles());
            context.Users.AddRange(GetUsers());
        }

        private IEnumerable<Role> GetRoles()
        {
            var adminRole = new Role
            {
                Id = 1,
                Code = "Admin",
                Name = "Администратор"
            };
            var userRole = new Role
            {
                Id = 2,
                Code = "User",
                Name = "Пользователь"
            };

            return new[] { adminRole, userRole };
        }

        private IEnumerable<User> GetUsers()
        {
            var user1 = new User
            {
                Id = 1,
                Name = "Иван",
                Email = "ivan@nowhere.com",
                RoleId = 1,
                Password = "ivanTheGreat",
                AddAtDate = DateTime.UtcNow
            };

            var user2 = new User
            {
                Id = 1,
                Name = "Петр",
                Email = "petr@somewhere.com",
                RoleId = 2,
                Password = "petrTheFirst",
                AddAtDate = DateTime.UtcNow
            };

            return new[] { user1, user2 };
        }
    }
}
