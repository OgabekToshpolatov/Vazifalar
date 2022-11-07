using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using jwt.Dto;
using jwt.Models;
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

    private  readonly string _filePath;
    public JwtController(IOptions<JsonFileOptions> options)
    {
        _filePath = options.Value.FilePath ?? "file.json" ;
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(User.FindFirst(ClaimTypes.Name)?.Value);
    }

    [HttpPost("SignIn")]
    public IActionResult SignIn(string username, string password)
    {
        var users = ReadUser();

        var user = users?.Where(x => x.Username == username).FirstOrDefault();

        if(user is null) return NotFound(new { Error = "User Topilmadi"});
        
        if(user.Password != password) return BadRequest(); 

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

    [HttpPost("SignUp")]
    public IActionResult SignUp(UserDto userDto)
    {
          var user = new User()
          {
            Id = Guid.NewGuid().ToString(),
            Username = userDto.Username,
            Password = userDto.Password,
            Email = userDto.Email,
            Role = userDto.Role
          };

          var users = ReadUser();
           if(users is null) 
           {
             users = new List<User>();
           }
          users!.Add(user);
          SaveUser(users);
          return Ok();
    }

    private void SaveUser(List<User> users)
    {
        var jsonData = JsonConvert.SerializeObject(users);

        System.IO.File.WriteAllText(_filePath, jsonData);
    } 

    private List<User>? ReadUser()
    {
         var jsonData = System.IO.File.ReadAllText(_filePath);

         return JsonConvert.DeserializeObject<List<User>>(jsonData);
    }

}    

    