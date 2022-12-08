using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Dtos;
using mvc.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace mvc.Controllers;

public class AccountController:Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
     public AccountController(
        AppDbContext context,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult SignUp(string returnUrl) => View(new RegisterUserDto() {ReturnUrl = returnUrl});

    [HttpPost]
    public async Task<IActionResult> SignUp(RegisterUserDto dtoModel)
    {
          if(!ModelState.IsValid) return View(dtoModel);

          if(dtoModel.Password != dtoModel.ConfirmPassword) return View(dtoModel);

          if(await _userManager.Users.AnyAsync(u => u.UserName == dtoModel.UserName)) 
           return View(dtoModel);

          var user = dtoModel.Adapt<AppUser>();

          var result = await _userManager.CreateAsync(user, dtoModel.Password);

          if(!result.Succeeded) return View(dtoModel);

          await _signInManager.SignInAsync(user, isPersistent: true);

          return LocalRedirect($"/Account/SignIn?returnUrl={dtoModel.ReturnUrl}");
    }
     
    public IActionResult SignIn(string returnUrl) => View(new LoginUserDto() { ReturnUrl = returnUrl });
    
    [HttpPost]
    public async Task<IActionResult> SignIn(LoginUserDto dtoModel)
    {
       if(!ModelState.IsValid) return View(dtoModel);

       var user = await _userManager.FindByNameAsync(dtoModel.UserName);

       if(user is null ) return View(dtoModel);

       var result = await _signInManager
                 .PasswordSignInAsync(dtoModel.UserName, dtoModel.Password, isPersistent:true,false);

       if(!result.Succeeded) return View(dtoModel);

       return LocalRedirect($"{dtoModel.ReturnUrl ?? "/"}");
    }


}