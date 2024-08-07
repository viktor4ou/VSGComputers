using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VSGComputers.Data;
using VSGComputers.DataAccess.Repository.Interfaces;

namespace VSGComputers.DataAccess.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly ComputersDbContext db;
        internal DbSet<T> dbSet;
        public Repository(ComputersDbContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(expression);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
