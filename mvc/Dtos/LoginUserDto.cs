using System.ComponentModel.DataAnnotations;

namespace mvc.Dtos;

public class LoginUserDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? ReturnUrl { get; set; }
}
