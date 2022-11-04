using System.Security.Claims;
using claim.Filters;
using claim.Services;
using Microsoft.AspNetCore.Mvc;

namespace claim.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController:ControllerBase
{
    private readonly JsonService _service;

    public UserController(JsonService service)
    {
        _service = service;
    }
    [HttpGet]
   // [Auth]
    public IActionResult Get()
    {
       
        var userName = User.Claims
                              .FirstOrDefault(claim => claim.Type == ClaimTypes.Name);
        return Ok("UserName :" + userName?.Value);
    }

    [HttpPost]
    public IActionResult Login(Services.User user)
    {
        var key = Guid.NewGuid().ToString();
        _service.WriteJson(key, user);

        return Ok(user);
        
    }
}