using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RecapApi.Configs;

namespace RecapApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OptionsController : ControllerBase
{
    private readonly ILogger<OptionsController> _logger;
    private readonly DbConfig _optionsDbConfig;

    public OptionsController(ILogger<OptionsController> logger, IOptions<DbConfig> options)
    {
        _logger = logger;
        _optionsDbConfig = options.Value;
    }

    [HttpGet(Name = "GetOptions")]
    public IActionResult GetOptions()
    {
        _logger.LogInformation($"Returning Response From {nameof(GetOptions)}");
        return Ok(_optionsDbConfig.ConnectionString);
    }
}