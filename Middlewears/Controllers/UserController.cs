using Microsoft.AspNetCore.Mvc;

namespace middlewears.Controllers;

[ApiController]
[Route("api/[controller]")]
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