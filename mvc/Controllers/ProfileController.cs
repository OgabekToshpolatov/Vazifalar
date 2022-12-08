using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Entities;
using mvc.ViewModel;

namespace mvc.Controllers;

public class ProfileController:Controller
{
    private readonly UserManager<AppUser> _userManager;

    public ProfileController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
     
    [HttpGet("/profile")]
    public async Task<IActionResult> Profile()
    {
       var user = await _userManager.GetUserAsync(User);
        
       if (user == null) return View();
    
       var view = user.Adapt<UserView>();
        
       return View(view);
    }
    
}