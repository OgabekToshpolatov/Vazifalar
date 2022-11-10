using logger.Entities;
using logger.Logger;
using logger.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace logger.Controlllers;

[ApiController]
[Route("api/[controller]")]
public class UserController:ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly ILogger _logger;
    public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _logger = new MyFileLogger();
    }

    [HttpPost("SignUp")]
    public async  ValueTask<IActionResult> SignUp(UserModel model)
    {
      var user = new User()
      {
        UserName = model.Username,
        Email = model.Email
      };
      _logger.LogInformation($"{user.UserName} user add ");
      

     var result =  await _userManager.CreateAsync(user, model.Password);

     if(!result.Succeeded)
     {
       return BadRequest("User Create bo`lmadi.");
     }

     _logger.LogInformation("User succesfully SignUp ");

      return Ok($"{model.Username} {model.Password}");
 
    }

    [HttpPost("SignIn")]
    public async ValueTask<IActionResult> SignIn(string name, string password)
    {
       var user = await _userManager.FindByNameAsync(name);

       if(user is null)
       {
        _logger.LogInformation("Username topilmadi");
        return NotFound("Username topilmadi.");
       }

       var res = await _signInManager.PasswordSignInAsync(user, password, true, false);

       if(!res.Succeeded)
       {
        return BadRequest("Sign in qila olmadi.");
       }

       _logger.LogInformation("User succesfully Login");

       return Ok();

    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("Users");
    }
}