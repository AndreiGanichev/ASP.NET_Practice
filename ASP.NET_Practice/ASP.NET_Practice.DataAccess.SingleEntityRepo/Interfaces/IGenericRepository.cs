using System;
using System.Linq;

namespace ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces
{
    public interface IGenericRepository<T> where T : class, IBaseId
    {
        T Add(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Func<T, bool> predicate);
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
    }
}
