using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LoggingController : ControllerBase
{
    private readonly ILogger _logger;

    public LoggingController(ILogger<LoggingController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public void Log()
    {
        _logger.LogInformation("Log method called");
        _logger.LogError(new InvalidCastException(), "Log method called");
    }
}