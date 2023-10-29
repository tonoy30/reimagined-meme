using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RecapApi.DbContexts;


namespace RecapApi.Contracts;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly ApplicationDbContext _applicationDbContext;

    protected RepositoryBase(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }


    public IQueryable<T> FindAll(bool trackChanges)
    {
        return trackChanges
            ? _applicationDbContext.Set<T>()
            : _applicationDbContext.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return trackChanges
            ? _applicationDbContext.Set<T>().Where(expression)
            : _applicationDbContext.Set<T>().Where(expression).AsNoTracking();
    }

    public void Create(T entity)
    {
        _applicationDbContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _applicationDbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _applicationDbContext.Set<T>().Remove(entity);
    }
}