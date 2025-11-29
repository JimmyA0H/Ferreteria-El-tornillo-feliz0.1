
using Ferreteria.Core.Entities;
using System.Linq.Expressions;

namespace Ferreteria.Core.Interfaces;

public interface IRepository<T> where T : EntidadBase
{
    Task<IEnumerable<T>> GetAllAsync(bool tracking = false);
    Task<T?> GetByIdAsync(int id, bool tracking = false);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool tracking = false);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<int> SaveChangesAsync();
}
