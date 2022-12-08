using System.ComponentModel.DataAnnotations;

namespace mvc.Dtos;

public class RegisterUserDto
{
    [Required]
    public string? UserName { get; set; }

    [Required]
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public string? ConfirmPassword { get; set; }

    [Required]
    public string? Email { get; set; }

    public string? ReturnUrl { get; set; }
}