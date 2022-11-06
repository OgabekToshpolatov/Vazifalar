using jwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace jwt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JwtController:ControllerBase
{
    [HttpGet]
    [Authorize] 
    public IActionResult GetUsers() => Ok("Users List");

    [HttpPost]
    public IActionResult SignUp()
    {
        return Ok();
    }
}