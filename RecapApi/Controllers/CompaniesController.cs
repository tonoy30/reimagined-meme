using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RecapApi.Contracts;
using Serilog;

namespace RecapApi.Controllers;

[ApiController]
[Route("/api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompaniesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompaniesAsync()
    {
        try
        {
            var companies = await _service.CompanyService.GetAllCompaniesAsync(false);
            return Ok(companies);
        }
        catch (Exception e)
        {
            Log.Error(e, "{Message}", e.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}