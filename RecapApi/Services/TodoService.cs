using RecapApi.Contracts;
using RecapApi.Entities;

namespace RecapApi.Services;

public class TodoService : ITodoService
{
    private readonly IRepositoryManager _repository;

    public TodoService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Todo>> GetAllTodosAsync(bool trackChanges)
    {
        try
        {
            var todos = await _repository.TodoRepository.GetAllTodosAsync(trackChanges);
            return todos;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}