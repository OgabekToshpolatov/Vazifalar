using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace claim.Filters;

public class AuthAttribute:ActionFilterAttribute
{
    // userni malumotlarini databazadan olamiz.
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        context.Result = new UnauthorizedResult();
         var claims = new List<Claim>()
        {
           new Claim(ClaimTypes.Name,"Ogabek"),
           new Claim(ClaimTypes.Email, "example.com"),
           new Claim(ClaimTypes.Role, "user")  
        };

        var identity = new ClaimsIdentity(claims);

        var principal = new ClaimsPrincipal(identity);

        context.HttpContext.User = principal;

    }
}