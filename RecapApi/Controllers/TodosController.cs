using Microsoft.AspNetCore.Mvc;
using RecapApi.Contracts;

namespace RecapApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly IServiceManager _service;

    public TodosController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var todos = await _service.TodoService.GetAllTodosAsync(false);
        return Ok(todos);
    }
}