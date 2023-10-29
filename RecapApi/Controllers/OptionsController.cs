using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RecapApi.Configs;

namespace RecapApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OptionsController : ControllerBase
{
    private readonly ILogger<OptionsController> _logger;
    private readonly ConnectionStringOptions _optionsConnectionStringOptions;

    public OptionsController(ILogger<OptionsController> logger, IOptions<ConnectionStringOptions> options)
    {
        _logger = logger;
        _optionsConnectionStringOptions = options.Value;
    }

    [HttpGet(Name = "GetOptions")]
    public IActionResult GetOptions()
    {
        _logger.LogInformation($"Returning Response From {nameof(GetOptions)}");
        return Ok(_optionsConnectionStringOptions.DefaultConnection);
    }
}