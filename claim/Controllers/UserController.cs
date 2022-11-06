using claim.Entities;
using claim.Filters;
using claim.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace claim.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController:ControllerBase
{
    public UserController(IConfiguration configuration)
    {
        _filepath = configuration["FilePath"];
    }
    private readonly string _filepath;
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(ReadUser());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
       var user = ReadUser()?.FirstOrDefault(x => x.Id == id);

       return Ok(user);
    }

    [HttpPost]
    public IActionResult Login(UserModel userModel)
    {
       var user = new User()
       {
         Id = Guid.NewGuid().ToString(),
         Name = userModel.Name,
         Role = userModel.Role,
         Token = Guid.NewGuid().ToString()
       };
       var users = ReadUser();
       if(users is null) 
       {
        users = new List<User>();
       }
       users!.Add(user);

       SaveUser(users);
       return Ok(user);
    }

    private List<User>? ReadUser()
    {
         var jsonData = System.IO.File.ReadAllText(_filepath);

         return JsonConvert.DeserializeObject<List<User>>(jsonData);
    }

    private void SaveUser(List<User> users)
    {
        var jsonData = JsonConvert.SerializeObject(users);

        System.IO.File.WriteAllText(_filepath, jsonData);
    } 

    