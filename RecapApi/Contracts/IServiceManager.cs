using RecapApi.Services;

namespace RecapApi.Contracts;

public interface IServiceManager
{
    ITodoService TodoService { get; }
}