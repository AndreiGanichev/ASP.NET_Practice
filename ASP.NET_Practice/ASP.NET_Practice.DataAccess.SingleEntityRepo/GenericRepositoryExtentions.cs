using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ASP.NET_Practice.DataAccess.SingleEntityRepo
{
    public static class GenericRepositoryExtentions
    {
        /// <summary>
        /// Позволяет в обобщенном репозитории "подтягивать" навигационные свойства
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="includingProperties"></param>
        /// <returns></returns>
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includingProperties)
        {
            if(includingProperties != null)
            {
                query = includingProperties.Aggregate(query,
                            (current, property) => current.Include(property));
            }

            return query;
        }
    }
}
