using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using jwt.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace jwt.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JwtController:ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(User.FindFirst(ClaimTypes.Name)?.Value);
    }

    [HttpPost("SignIn")]
    public IActionResult SignIn(string username, string password)
    {
        var keyByte = System.Text.Encoding.UTF8.GetBytes("asda;odbuads;b242342hbiahbasdada");
        var securityKey = new SigningCredentials(new SymmetricSecurityKey(keyByte), SecurityAlgorithms.HmacSha256);

        var security = new JwtSecurityToken(
            issuer:"Project1",
            audience:"Rooom1",
            new Claim[]
            {
                new Claim(ClaimTypes.Name, username)
            },
            expires: DateTime.Now.AddSeconds(10),
            signingCredentials: securityKey);

        var token = new JwtSecurityTokenHandler().WriteToken(security);

        return Ok(token);
    }
}    

    