using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RecapApi.Contracts;
using RecapApi.DTOs;

namespace RecapApi.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("/api/v{version:apiVersion}/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
    {
        var result = await _service.AuthenticationService.RegisterUser(userForRegistrationDto);
        if (result.Succeeded) return StatusCode(201);
        foreach (var error in result.Errors)
        {
            ModelState.TryAddModelError(error.Code, error.Description);
        }

        return BadRequest(ModelState);
    }
}