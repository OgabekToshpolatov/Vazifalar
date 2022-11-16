using Microsoft.AspNetCore.Mvc;

namespace localizer.ValueController;

[ApiController]
[Route("api/[controller]")]
public class ValueController:ControllerBase
{
    private readonly ILogger<ValueController> _logger;

    public ValueController(ILogger<ValueController> logger)
    {
        _logger = logger ;
    }

    [HttpGet]
    public IActionResult Culture(string culture)
    {
        return Ok(culture);
    }


}