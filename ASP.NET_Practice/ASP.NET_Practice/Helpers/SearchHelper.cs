using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET_Practice.Helpers
{
    public static class SearchHelper
    {
        public static IEnumerable<User> FindUsers(IEnumerable<User> users, string searchString)
        {
            searchString = searchString.ToUpperInvariant();
            return users.Where(u => u.FirstName.ToUpperInvariant().Contains(searchString)
                                    || u.Email.ToUpperInvariant().Contains(searchString));
        }
    }
}