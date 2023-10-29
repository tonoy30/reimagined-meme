using RecapApi.Entities;

namespace RecapApi.Repositories;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetAllTodosAsync(bool trackChanges);
}