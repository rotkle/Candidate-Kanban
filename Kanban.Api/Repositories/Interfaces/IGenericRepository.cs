using System.Linq.Expressions;

/// <summary>
/// Generic repository contain general functions which will be used to interact with any Entity data
/// </summary>
/// <typeparam name="T">Database Entity</typeparam>
public interface IGenericRepository <T> where T: class {
    Task<T> GetById(int id);
    IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    void Insert(T entity);
    void Delete(T entity);
    Task Delete(int id);
    void Update(T entity);
}