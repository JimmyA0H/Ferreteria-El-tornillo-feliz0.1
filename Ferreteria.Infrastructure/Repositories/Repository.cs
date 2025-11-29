
using Ferreteria.Core.Entities;
using Ferreteria.Core.Interfaces;
using Ferreteria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Ferreteria.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : EntidadBase
{
    private readonly FerreteriaDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(FerreteriaDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool tracking = false)
    {
        IQueryable<T> query = _dbSet;
        if (!tracking) query = query.AsNoTracking();
        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id, bool tracking = false)
    {
        IQueryable<T> query = _dbSet;
        if (!tracking) query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool tracking = false)
    {
        IQueryable<T> query = _dbSet.Where(predicate);
        if (!tracking) query = query.AsNoTracking();
        return await query.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
