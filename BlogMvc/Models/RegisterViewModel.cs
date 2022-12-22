using System.ComponentModel.DataAnnotations;

namespace BlogMvc.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Username Required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password Required")]
    public string Password { get; set; }
    public IFormFile Avatar { get; set; }
    public string ReturnUrl { get; set; }
}