using System.Security.Claims;
using claim.Filters;
using Microsoft.AspNetCore.Mvc;

namespace claim.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController:ControllerBase
{
    [HttpGet]
    [Auth]
    public IActionResult Get()
    {
       
        var userName = User.Claims
                              .FirstOrDefault(claim => claim.Type == ClaimTypes.Name);
        return Ok("UserName :" + userName?.Value);
    }
}