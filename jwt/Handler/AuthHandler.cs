using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace jwt.Handler;

public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public AuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
     ILoggerFactory logger, 
     UrlEncoder encoder, 
     ISystemClock clock) 
     : base(options, logger, encoder, clock)
    {
    }

    protected override async  Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new List<Claim>()
        {
             new Claim(ClaimTypes.Name, "user.Name"),
             new Claim(ClaimTypes.Name, "user.Name!")
        };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);

        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return await Task.FromResult(AuthenticateResult.Success(ticket));
    }
}