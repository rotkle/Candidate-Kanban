using Kanban.Api.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    internal DataContext _context;
    internal DbSet<T> _dbSet;

    public GenericRepository(DataContext context)
    {
        this._context = context;
        this._dbSet = _context.Set<T>();
    }

    public void Delete(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
    }

    public async Task Delete(int id)
    {
        T entity = await _dbSet.FindAsync(id);

        if (entity == null)
            throw new KeyNotFoundException();

        Delete(entity);
    }

    public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            return orderBy(query);
        }
        else
        {
            return query;
        }
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Insert(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}