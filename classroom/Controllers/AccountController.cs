using classroom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace classroom.Controllers;

public class AccountController:Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
    {
        _logger = logger ;
        _userManager = userManager ;
        _signInManager = signInManager ;
    }

     [HttpGet]
     public IActionResult SignUp()
     {
         return View();
     }

    [HttpPost]
    public async ValueTask<IActionResult> SignUp(SignUpModel model)
    {
        if(string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
        {
            _logger.LogInformation("SignUp Failed");
            return BadRequest(" No password or username entered ");           
        }

        var user = new IdentityUser(model.Username);

        var result =await  _userManager.CreateAsync(user, model.Password);

        if(!result.Succeeded)
        {
            return BadRequest("User not create");
        }

        _logger.LogInformation("user succesfully SignUp");

        return Ok();

    }
}