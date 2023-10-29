using RecapApi.Repositories;

namespace RecapApi.Contracts;

public interface IRepositoryManager
{
    ITodoRepository TodoRepository { get; }
    void Save();
}