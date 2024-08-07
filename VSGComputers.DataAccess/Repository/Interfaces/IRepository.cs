using System.Linq.Expressions;

namespace VSGComputers.DataAccess.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetBy(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
