using Microsoft.EntityFrameworkCore;
using RecapApi.Contracts;
using RecapApi.DbContexts;
using RecapApi.Entities;

namespace RecapApi.Repositories;

public class TodoRepository : RepositoryBase<Todo>, ITodoRepository
{
    public TodoRepository(ApplicationDbContext applicationDbContext) : base(
        applicationDbContext)
    {
    }

    public async Task<IEnumerable<Todo>> GetAllTodosAsync(bool trackChanges)
        => await FindAll(trackChanges).ToListAsync();
}