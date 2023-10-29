using RecapApi.Services;

namespace RecapApi.Contracts;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ITodoService> _todoService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _todoService = new Lazy<ITodoService>(() => new TodoService(repositoryManager));
    }

    public ITodoService TodoService => _todoService.Value;
}