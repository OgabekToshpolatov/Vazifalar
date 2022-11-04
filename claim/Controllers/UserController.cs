using Microsoft.AspNetCore.Mvc;

namespace claim.Controllers;

public class UserController:ControllerBase
{
    [HttpGet]
    public IActionResult GetMe() => Ok();

    [HttpPost]
    public IActionResult Login()
    {
       return Ok();
    }
}