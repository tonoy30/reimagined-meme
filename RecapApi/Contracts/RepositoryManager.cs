using RecapApi.DbContexts;

namespace RecapApi.Contracts;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext _applicationDbContext;


    public RepositoryManager(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }


    public void Save() => _applicationDbContext.SaveChanges();
}