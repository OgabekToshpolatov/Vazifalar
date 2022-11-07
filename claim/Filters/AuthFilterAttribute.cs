using System.Security.Claims;
using claim.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace claim.Filters;

public class AuthFilterAttribute : ActionFilterAttribute
{
    private readonly string _filepath;
    public AuthFilterAttribute(IConfiguration configuration)
    {
        _filepath = configuration["FilePath"];
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if(!context.HttpContext.Request.Headers.ContainsKey(HeaderNames.Authorization))
        {
            context.Result = new UnauthorizedResult();
            return ;
        }

        var authorization = context.HttpContext.Request.Headers[HeaderNames.Authorization].ToString();

        var user = ReadUser()?.FirstOrDefault( x => x.Token == authorization);

        if(user is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var claims = new List<Claim>()
        {
            new Claim("Id", user?.Id!),
            new Claim(ClaimTypes.Name, user?.Name!),
            new Claim(ClaimTypes.Role, user?.Role!),
            new Claim("Token", user?.Token!),
        };

        var identity = new ClaimsIdentity(claims);

        var principal = new ClaimsPrincipal(identity);

        context.HttpContext.User = principal;

    }

    private List<User>? ReadUser()
    {
         var jsonData = System.IO.File.ReadAllText(_filepath);

         return JsonConvert.DeserializeObject<List<User>>(jsonData);
    }

    
}