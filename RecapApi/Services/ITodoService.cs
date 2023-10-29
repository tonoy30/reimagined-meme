using RecapApi.Entities;

namespace RecapApi.Services;

public interface ITodoService
{
    Task<IEnumerable<Todo>> GetAllTodosAsync(bool trackChanges);
}