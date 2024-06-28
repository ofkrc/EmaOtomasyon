using System.Linq.Expressions;

namespace EmaAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Find(int id);
        IEnumerable<T> List();
        T Update(T entity);
        T GetById(int id);
        void Delete(int id);
        void RemoveRange(IEnumerable<T> entities);
        IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath);
    }
}
