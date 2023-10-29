using RecapApi.DbContexts;
using RecapApi.Repositories;

namespace RecapApi.Contracts;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly Lazy<ITodoRepository> _todoRepository;

    public RepositoryManager(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _todoRepository = new Lazy<ITodoRepository>(() => new TodoRepository(applicationDbContext));
    }

    public ITodoRepository TodoRepository => _todoRepository.Value;

    public void Save() => _applicationDbContext.SaveChanges();
}