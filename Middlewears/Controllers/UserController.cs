using Microsoft.AspNetCore.Mvc;
using middlewears.Filters;

namespace middlewears.Controllers;

[ApiController]
[Route("api/[controller]")]
[LanguageFilter]
public class UserController:ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return RequestCulture.RequestLanguage switch
        {
            "en" => Ok("Important data"),
            "uz" => Ok("Muhim malumot"),
            _ => throw new InvalidOperationException()
        };
    }  
}