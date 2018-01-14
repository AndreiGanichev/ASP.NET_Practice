using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace ASP.NET_Practice.DataAccess.SingleEntityRepo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseId
    {
        private DbSet<T> _entities;
        private PracticeContext _dbContext;

        public GenericRepository(PracticeContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            var newEntity = _entities.Add(entity);
            _dbContext.SaveChanges();
            return newEntity;
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<T> Get(Func<T, bool> predicate)
        {
            return _entities
                .AsNoTracking() //для ускорения работы и снижения потребения памяти
                .Where(e => predicate(e));
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(int id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
