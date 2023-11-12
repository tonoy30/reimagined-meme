using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using RecapApi.Contracts;
using RecapApi.DTOs;

namespace RecapApi.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("/api/v{version:apiVersion}/[controller]")]
[EnableRateLimiting("REDIS_TOKEN_BUCKET_RATE_LIMITER")]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost("register", Name = "RegisterUser")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserForRegistrationDto userForRegistrationDto)
    {
        var result = await _service.AuthenticationService.RegisterUserAsync(userForRegistrationDto);
        if (result.Succeeded) return StatusCode(201);
        foreach (var error in result.Errors)
        {
            ModelState.TryAddModelError(error.Code, error.Description);
        }

        return BadRequest(ModelState);
    }

    [HttpPost("login", Name = "Login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] UserForAuthenticationDto user)
    {
        var isValidUser = await _service.AuthenticationService.ValidateUserAsync(user);
        if (!isValidUser) return Unauthorized();
        return Ok(new { Token = await _service.AuthenticationService.CreateTokenAsync() });
    }
}